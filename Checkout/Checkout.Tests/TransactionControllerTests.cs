﻿using Checkout.API.Controllers;
using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
//using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Checkout.Tests
{
    public class TransactionControllerTests
    {
        //private readonly Mock<ITransactionService> _mockRepo;
        private readonly TransactionsController _controller;
        private readonly ICurrencyService _currencyService;
        private readonly ICardDetailsService _cardDetailsService;
        private readonly IMerchantService _merchantService;

        public TransactionControllerTests()
        {
            //_mockRepo = new Mock<ITransactionService>();

            //var t = _mockRepo.Object;

            //_controller = new TransactionsController(_currencyService, _cardDetailsService, _merchantService, _mockRepo.Object);
        }

        #region Process Transaction Tests

        [Fact]
        public void ProcessTransactionTest()
        {

            //var data = CreateTransactionModelHelper.GetModelTestData(name, surname, email);
            //var response = _apiService.PostTransaction(data);
            //Assert.True(response.StatusName == StatusName.Completed);
        }


        #endregion

        #region GetTransactionsByMerchantID Tests

        [Fact]
        public void GetTransactionsByMerchantID_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var merchantID = new Guid("1D620903-D485-4421-958F-8265C0B41844");
 
            // Act
            var okResult = _controller.GetTransactionsByMerchantID(merchantID);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetTransactionsByMerchantID_ExistingGuidPassed_ReturnsList()
        {
            // Arrange
            var merchantID = new Guid("1D620903-D485-4421-958F-8265C0B41844");

            // Act
            var okResult = _controller.GetTransactionsByMerchantID(merchantID);

            // Assert
            var items = Assert.IsType<List<Transaction>>(okResult);
            Assert.NotEmpty(items);
        }

        #endregion

    }
}