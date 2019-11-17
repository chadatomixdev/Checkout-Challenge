using Checkout.API.Controllers;
using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.UnitTests.Fakes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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



        #endregion


        #region GetTransactionByTransactionID Tests

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