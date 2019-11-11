using System;
using System.Threading.Tasks;
using Checkout.API.Helpers;
using Checkout.API.Representers;
using Checkout.API.Services;
using Checkout.Data.Model;
using Checkout.Shared.Models;
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
        private readonly MerchantService _merchantService;
        private readonly TransactionService _transactionService;

        #endregion

        #region Constructor
        public TransactionsController(CurrencyService currencyService, CardDetailsService cardDetailsService, MerchantService merchantService, TransactionService transactionService)
        {
            _currencyService = currencyService;
            _cardDetailsService = cardDetailsService;
            _merchantService = merchantService;
            _transactionService = transactionService;
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

            var merchant = new Merchant();
            merchant = _merchantService.GetMerchant(Guid.Parse(transactionRepresenter.MerchantID));

            if (merchant is null)
                return BadRequest("Currency not supported");

            var currency = new Currency();
            currency = _currencyService.GetCurrency(transactionRepresenter.Currency);

            if (currency is null)
                return BadRequest("Currency not supported");

            var cardEntity = new Data.Model.CardDetails();
            cardEntity = _cardDetailsService.GetCardDetails(transactionRepresenter.Card.CardNumber);

            // Verify if the card exists and if it doesnt insert the card into the db
            if (cardEntity is null)
            {
                    //TODO Add automapper to handle model mappings
                    cardEntity.CardNumber = transactionRepresenter.Card.CardNumber;
                    cardEntity.Cvv = transactionRepresenter.Card.Cvv;
                    cardEntity.ExpiryMonth = transactionRepresenter.Card.ExpiryMonth;
                    cardEntity.ExpiryYear = transactionRepresenter.Card.ExpiryYear;
                    cardEntity.HolderName = transactionRepresenter.Card.HolderName;
             
                    _cardDetailsService.AddCard(cardEntity);
            };

            //var expiryConcatenated = $" {transaction.Card.ExpiryMonth}/{transaction.Card.ExpiryYear}";
            //CreditCardHelper.IsCreditCardInfoValid(transaction.Card.CardNumber, expiryConcatenated, transaction.Card.Cvv);

            var transactionEntity = new Data.Model.Transaction();
            transactionEntity.Amount = transactionRepresenter.Amount;
            transactionEntity.Card = cardEntity;
            transactionEntity.CardID = cardEntity.CardDetailsID;
            transactionEntity.Currency = currency;
            transactionEntity.CurrencyID = currency.CurrencyId;
            transactionEntity.Merchant = merchant;
            transactionEntity.MerchantID = merchant.MerchantID;
            transactionEntity.Status = TransactionStatus.Created.ToString();
            transactionEntity.TransactionID = Guid.NewGuid();

            _transactionService.CreateTransaction(transactionEntity);

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