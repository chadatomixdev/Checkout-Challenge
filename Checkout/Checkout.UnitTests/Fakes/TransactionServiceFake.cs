using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.UnitTests
{
    public class TransactionServiceFake : BaseFact, ITransactionService
    {
        private readonly List<Transaction> _mockTransactions;

        public TransactionServiceFake()
        {
            
        }

        public void CreateTransaction(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransactionById(Guid transactionID)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetTransactionsByMerchantID(Guid merchantID)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
