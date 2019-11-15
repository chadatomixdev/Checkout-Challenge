using Checkout.API.Controllers;
using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Moq;
using System;
using System.Collections.Generic;

namespace Checkout.UnitTests
{
    public abstract class BaseTransactionsControllerTests
    {
        private readonly Mock<ICurrencyService> _currencyMock;
        private readonly Mock<ICardDetailsService> _cardDetailsMock;
        private readonly Mock<IMerchantService> _merchantsMock;
        private readonly Mock<ITransactionService> _transactionsMock;
        protected readonly TransactionsController TransactionsControllerUnderTest;


        List<Transaction> _transactions = new List<Transaction>();




        protected BaseTransactionsControllerTests(List<Transactions> transactions, List<Currencies> currencies, List<Merchants> merchants)
        {
            SeedData();

            Items = items;
            MockService = new Mock<IToDoItemService>();
            MockService.Setup(svc => svc.GetItemsAsync())
                .ReturnsAsync(Items);
            ControllerUnderTest = new ToDoController(MockService.Object);
        }

        private void SeedData()
        {
            throw new NotImplementedException();
        }
    }
}