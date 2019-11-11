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
        /// <param name="transactionRepresenter"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("process")]
        public async Task<IActionResult> ProcessTransaction(TransactionRepresenter transactionRepresenter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (transactionRepresenter.Amount <= 0)
                return BadRequest("Amount is invalid");

            bool isValid = Guid.TryParse(transactionRepresenter.MerchantID, out Guid guidOutput);
            if (!isValid)
                return BadRequest("Merchant is invalid");

            if (_currencyService.GetCurrency(transactionRepresenter.Currency) is null)
                return BadRequest("Currency not supported");

            // Verify if the card exists and if it doesnt insert the card into the db
            if (_cardDetailsService.GetCardDetails(transactionRepresenter.Card.CardNumber) is null)
            {
                //TODO Add automapper to handle model mappings
                var cardEntity = new Data.Model.CardDetails
                {
                    CardNumber = transactionRepresenter.Card.CardNumber,
                    Cvv = transactionRepresenter.Card.Cvv,
                    ExpiryMonth = transactionRepresenter.Card.ExpiryMonth,
                    ExpiryYear = transactionRepresenter.Card.ExpiryYear,
                    HolderName = transactionRepresenter.Card.HolderName
                };

                _cardDetailsService.AddCard(cardEntity);
            }

            //var expiryConcatenated = $" {transaction.Card.ExpiryMonth}/{transaction.Card.ExpiryYear}";
            //CreditCardHelper.IsCreditCardInfoValid(transaction.Card.CardNumber, expiryConcatenated, transaction.Card.Cvv);

            //var transactionEntity = new Data.Model.


                //TODO add transaction to DB with created status

                //Process transaction through mock acquirer
                var bankResponse = await APIHelper.ProcessTransactionAsync(transactionRepresenter);

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
