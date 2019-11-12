using System;
using System.Threading.Tasks;
using Checkout.API.Helpers;
using Checkout.API.Representers;
using Checkout.API.Services;
using Checkout.Data.Model;
using Checkout.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            #region Validation
          
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (transactionRepresenter.Amount <= 0)
                return BadRequest("Amount is invalid");

            bool isValid = Guid.TryParse(transactionRepresenter.MerchantID, out Guid merchantID);
            if (!isValid)
                return BadRequest("Merchant is invalid");

            var merchant = new Merchant();
            merchant = _merchantService.GetMerchant(Guid.Parse(transactionRepresenter.MerchantID));

            if (merchant is null)
                return BadRequest("Merchant is invalid");

            var currency = new Currency();
            currency = _currencyService.GetCurrencyByName(transactionRepresenter.Currency);

            if (currency is null)
                return BadRequest("Currency not supported");

            #endregion

            var cardEntity = new Data.Model.CardDetails();
            cardEntity = _cardDetailsService.GetCardDetailsByNumber(transactionRepresenter.Card.CardNumber);

            // Verify if the card exists and if it doesnt insert the card into the db
            if (cardEntity is null)
            {
                //TODO Add automapper to handle model mappings
                cardEntity = new CardDetails
                {
                    CardNumber = transactionRepresenter.Card.CardNumber,
                    Cvv = transactionRepresenter.Card.Cvv,
                    ExpiryMonth = transactionRepresenter.Card.ExpiryMonth,
                    ExpiryYear = transactionRepresenter.Card.ExpiryYear,
                    HolderName = transactionRepresenter.Card.HolderName
                };

                _cardDetailsService.AddCard(cardEntity);
            };

            //var expiryConcatenated = $" {transaction.Card.ExpiryMonth}/{transaction.Card.ExpiryYear}";
            //CreditCardHelper.IsCreditCardInfoValid(transaction.Card.CardNumber, expiryConcatenated, transaction.Card.Cvv);

            //TODO Fix Bug Leading zeros on Amount
            var transactionEntity = new Data.Model.Transaction
            {
                Amount = transactionRepresenter.Amount,
                Card = cardEntity,
                CardID = cardEntity.CardDetailsID,
                Currency = currency,
                CurrencyID = currency.CurrencyId,
                Merchant = merchant,
                MerchantID = merchant.MerchantID,
                Status = TransactionStatus.Created.ToString(),
                TransactionID = Guid.NewGuid()
            };

            _transactionService.CreateTransaction(transactionEntity);

            //Process transaction through mock acquirer
            var bankResponse =  await APIHelper.ProcessTransactionAsync(transactionRepresenter);
            var bankResponseData = bankResponse.Content.ReadAsStringAsync().Result;

           var json = JsonConvert.DeserializeObject<BankResponse>(bankResponseData);
            var transactionCreationRepresenter = new TransactionCreationRepresenter
            {
                BankResponseID = json.BankResponseID,
                Status = json.Status.ToString(),
                SubStatus = json.SubStatus.ToString(),
                TransactionID = transactionEntity.TransactionID
            };

            transactionEntity.BankReferenceID = json.BankResponseID;
            transactionEntity.Status = json.Status.ToString();
            transactionEntity.SubStatus = json.SubStatus.ToString();

            _transactionService.UpdateTransaction(transactionEntity);

            return Ok(transactionCreationRepresenter);
        }

        /// <summary>
        /// Get transactionb by ID for reconcilliation purposes
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTransactionById")]
        public IActionResult GetTransactionById(Guid transactionID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = new TransactionResponseRepresenter();

            var entity = _transactionService.GetTransactionById(transactionID);

            var currency = _currencyService.GetCurrencyByID(entity.CurrencyID);
            response.Currency = currency.Name;
            
            response.Amount = entity.Amount;
            response.BankReferenceID = entity.BankReferenceID;
            response.Status = entity.Status;
            response.SubStatus = entity.SubStatus;

            var card = _cardDetailsService.GetCardDetailsByID(entity.CardID);

            card.CardNumber = CreditCardHelper.MaskCardNumber(card.CardNumber);
            response.Card = card;

            return Ok(response);
        }

        /// <summary>
        /// Get all transactions for merchant
        /// </summary>
        /// <param name="merchantID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTransactions")]
        public IActionResult GetTransactions(Guid merchantID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_transactionService.GetTransactions(merchantID));
        }
    }
}