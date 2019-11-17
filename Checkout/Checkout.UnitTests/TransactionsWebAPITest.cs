using Checkout.API.Controllers;
using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Checkout.UnitTests
{
    public class TransactionsWebAPITest
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICardDetailsService _cardDetailsService;
        private readonly IMerchantService _merchantsService;
        private readonly ITransactionService _transactionsService;

        public TransactionsWebAPITest()
        {
            _currencyService = new CurrencyServiceFake();

        }

        [Fact]
        public async Task GetTransactionByIDSuccess()
        {
            //Arrange
            var fakeTransaction = new Transaction();
            var fakeCurrency = new Currency();
            var fakeMerchant = new Merchant();
            var transactionID = new Guid("1D620903-D485-4421-958F-8265C0B41844");
            var merchantID = new Guid("1D620903-D485-4421-958F-8265C0B41844");




            //_transactionsMock.Setup(t => t.GetTransactionById(transactionID))
            //    .Returns(Task.FromResult(fakeTransaction).Result);

            //_currencyMock.Setup(c => c.GetCurrencyByName("ZAR"))
            //    .Returns(Task.FromResult(fakeCurrency).Result);

            //_merchantsMock.Setup(m => m.GetMerchant(merchantID))
            //     .Returns(Task.FromResult(fakeMerchant).Result);

            //Act
            //var transactionsController = new TransactionsController(_currencyMock.Object, _cardDetailsMock.Object, _merchantsMock.Object, _transactionsMock.Object);
            //var actionResult = await transactionsController.GetTransactionById(transactionID);

            ////Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}