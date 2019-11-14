using Checkout.API.Controllers;
using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Checkout.UnitTests
{
    public class TransactionsWebAPITest
    {

        private readonly Mock<ICurrencyService> _currencyMock;
        private readonly Mock<ICardDetailsService> _cardDetailsMock;
        private readonly Mock<IMerchantService> _merchantsMock;
        private readonly Mock<ITransactionService> _transactionsMock;

        public TransactionsWebAPITest()
        {
            _currencyMock = new Mock<ICurrencyService>();
            _cardDetailsMock = new Mock<ICardDetailsService>();
            _merchantsMock = new Mock<IMerchantService>();
            _transactionsMock = new Mock<ITransactionService>();
        }


        [Fact]
        public async Task GetTransactionByID()
        {
            //Arrange
            var fakeTransaction = new Transaction();
            var fakeCurrency = new Currency();
            var transactionID = new Guid("1D620903-D485-4421-958F-8265C0B41844");

            _transactionsMock.Setup(t => t.GetTransactionById(transactionID))
                .Returns(Task.FromResult(fakeTransaction).Result);

            _currencyMock.Setup(c => c.GetCurrencyByName("ZAR"))
                .Returns(Task.FromResult(fakeCurrency).Result);

            //_currencyMock.Setup(c => c.GetCurrencyByName("ZAR"))
            //    .Returns(Task.FromResult(fakeCurrency).Result);

            //Act
            var transactionsController = new TransactionsController(_currencyMock.Object, _cardDetailsMock.Object, _merchantsMock.Object, _transactionsMock.Object);
            var actionResult = await transactionsController.GetTransactionById(transactionID);

            ////Assert
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, (int)System.Net.HttpStatusCode.OK);
        }
    }
}
