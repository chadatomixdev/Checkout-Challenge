using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Checkout.API.Helpers;
using Checkout.API.Representers;
using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.Shared.Models;
using Checkout.Shared.Services;
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

        private readonly ICurrencyService _currencyService;
        private readonly ICardDetailsService _cardDetailsService;
        private readonly IMerchantService _merchantService;
        private readonly ITransactionService _transactionService;
        private readonly IBankService _bankService;

        #endregion

        #region Constructor
        public TransactionsController(ICurrencyService currencyService, ICardDetailsService cardDetailsService, IMerchantService merchantService, ITransactionService transactionService, IBankService bankService)
        {
            _currencyService = currencyService;
            _cardDetailsService = cardDetailsService;
            _merchantService = merchantService;
            _transactionService = transactionService;
            _bankService = bankService;
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

            var bank = new Bank();
            bank = _bankService.GetBankByName(transactionRepresenter.Bank);

            if (bank is null)
                return BadRequest("Bank not supported");

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
                TransactionID = Guid.NewGuid(),
                Bank = bank,
                BankID = bank.BankID
            };

            _transactionService.CreateTransaction(transactionEntity);

            //Process transaction through mock acquirer
            var bankResponse =  await APIHelper.ProcessTransactionAsync(transactionRepresenter, bank.BankURL);
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
        public ActionResult GetTransactionById(Guid transactionID)
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
        [Route("GetTransactionsByMerchantID")]
        public ActionResult GetTransactionsByMerchantID(Guid merchantID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var merchant = new Merchant();
            merchant = _merchantService.GetMerchant(merchantID);

            if (merchant is null)
                return BadRequest("Merchant is invalid");

            var transactions = _transactionService.GetTransactionsByMerchantID(merchantID);

            if (transactions.Count == 0)
                return NotFound();

            return Ok(transactions);
        }
    }
}