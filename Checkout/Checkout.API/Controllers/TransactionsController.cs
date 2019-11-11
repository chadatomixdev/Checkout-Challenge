using System;
using System.Threading.Tasks;
using Checkout.API.Helpers;
using Checkout.API.Representers;
using Checkout.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.API.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class TransactionsController : ControllerBase
    {
        #region Properties

        private readonly CurrencyService _currencyService;
        private readonly CardDetailsService _cardDetailsService;

        #endregion

        #region Constructor
        public TransactionsController(CurrencyService currencyService, CardDetailsService cardDetailsService)
        {
            _currencyService = currencyService;
            _cardDetailsService = cardDetailsService;
        }

        #endregion

        /// <summary>
        /// Process a transaction
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("process")]
        public async Task<IActionResult> ProcessTransaction(TransactionRepresenter transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (transaction.Amount <= 0)
                return BadRequest("Amount is invalid");

            bool isValid = Guid.TryParse(transaction.MerchantID, out Guid guidOutput);
            if (!isValid)
                return BadRequest("Merchant is invalid");

            if (_currencyService.GetCurrency(transaction.Currency) is null)
                return BadRequest("Currency not supported");

            // CreditCardHelper.SaveCardDetails(transaction.Card);

            // Verify if the card exists and if it doesnt insert the card into the db
            if (_cardDetailsService.GetCardDetails(transaction.Card.CardNumber) is null)
            {
                //TODO Add automapper to handle model mappings
                var entity = new Data.Model.CardDetails
                {
                    CardNumber = transaction.Card.CardNumber,
                    Cvv = transaction.Card.Cvv,
                    ExpiryMonth = transaction.Card.ExpiryMonth,
                    ExpiryYear = transaction.Card.ExpiryYear,
                    HolderName = transaction.Card.HolderName
                };

                _cardDetailsService.AddCard(entity);
            }

            var expiryConcatenated = $" {transaction.Card.ExpiryMonth}/{transaction.Card.ExpiryYear}";
            CreditCardHelper.IsCreditCardInfoValid(transaction.Card.CardNumber, expiryConcatenated, transaction.Card.Cvv);

                //TODO add transaction to DB with created status

                //Process transaction through mock acquirer
                var bankResponse = await APIHelper.ProcessTransactionAsync(transaction);

            //Update transaction status 

            return Ok();
        }

        /// <summary>
        /// Get transactionb by ID for reconcilliation purposes
        /// </summary>
        /// <param name="merchantID"></param>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTransactionById(Guid merchantID, Guid transactionID)
        {

            return Ok();
        }
    }
}
