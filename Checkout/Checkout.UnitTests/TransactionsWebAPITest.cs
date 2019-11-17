using Checkout.API.Controllers;
using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Checkout.UnitTests
{
    public class TransactionsWebAPITest
    {
        ICurrencyService _currencyService;
        ICardDetailsService _cardDetailsService;
        IMerchantService _merchantsService;
        ITransactionService _transactionsService;
        TransactionsController _transactionsController;

        public TransactionsWebAPITest()
        {
            _currencyService = new CurrencyServiceFake();
            _merchantsService = new MerchantServiceFake();
            _transactionsService = new TransactionServiceFake();
            _cardDetailsService = new CardDetailsServiceFake();
            _transactionsController = new TransactionsController(_currencyService, _cardDetailsService, _merchantsService, _transactionsService);
        }

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

        #endregion
    }
}