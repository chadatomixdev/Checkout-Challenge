using Checkout.API.Controllers;
using Checkout.API.Representers;
using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.Shared.Representers;
using Checkout.UnitTests.Fakes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Checkout.UnitTests
{
    public class TransactionsControllerTests
    {
        ICurrencyService _currencyService;
        ICardDetailsService _cardDetailsService;
        IMerchantService _merchantsService;
        ITransactionService _transactionsService;
        IBankService _bankService;

        TransactionsController _transactionsController;

        public TransactionsControllerTests()
        {
            _currencyService = new CurrencyServiceFake();
            _merchantsService = new MerchantServiceFake();
            _transactionsService = new TransactionServiceFake();
            _cardDetailsService = new CardDetailsServiceFake();
            _bankService = new BankServiceFake();
            _transactionsController = new TransactionsController(_currencyService, _cardDetailsService, _merchantsService, _transactionsService, _bankService);
        }

        #region ProcessTransaction Tests

        [Fact]
        public void PostTransaction_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var card = new CardDetails { CardNumber = "4242 4242 4242 4242", Cvv = "100", HolderName = "CHADTBONTHUYS", ExpiryMonth = "11", ExpiryYear = "19" };
            var _transaction = new TransactionRepresenter { Amount = 200, Currency = "GBP", Bank = "MockBank", Card = card, MerchantID = "1D620903-D485-4421-958F-8265C0B41844" };

            // Act
            var createdResponse = _transactionsController.ProcessTransaction(_transaction).Result;

            // Assert
            Assert.IsType<OkObjectResult>(createdResponse);
        }

        #endregion

        #region GetTransactionByTransactionID Tests

        [Fact]
        public void GetTransactionById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var transactionGuid = new Guid("CDE77BD3-8714-47AC-A3C3-212F10FFAEB6");

            // Act
            var okResult = _transactionsController.GetTransactionById(transactionGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetTransactionById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var transactionGuid = new Guid("CDE77BD3-8714-47AC-A3C3-212F10FFAEB6");
            var bankReferenceID = "3ec61fc4-8801-4131-8c7e-1128a2d10273";

            // Act
            var okResult = _transactionsController.GetTransactionById(transactionGuid) as OkObjectResult;

            // Assert
            Assert.IsType<TransactionResponseRepresenter>(okResult.Value);
            Assert.Equal(bankReferenceID, (okResult.Value as TransactionResponseRepresenter).BankReferenceID.ToString());
        }

        #endregion

        #region GetTransactionsByMerchantID Tests

        [Fact]
        public void GetTransactionByMerchantIDReturnsOkResult()
        {
            //Arrange
            var merchantID = new Guid("1D620903-D485-4421-958F-8265C0B41844");

            //Act
            var okResult = _transactionsController.GetTransactionsByMerchantID(merchantID);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetTransactionByMerchantIDReturnsAllItems()
        {
            //Arrange
            var merchantID = new Guid("1D620903-D485-4421-958F-8265C0B41844");

            // Act
            var okResult = _transactionsController.GetTransactionsByMerchantID(merchantID) as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Transaction>>(okResult.Value);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void GetTransactionByMerchantID_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            //Arrange
            var merchantID = Guid.NewGuid();

            // Act
            var badRequestResult = _transactionsController.GetTransactionsByMerchantID(merchantID);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }

        #endregion
    }
}