using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.UnitTests
{
    public class TransactionServiceFake : BaseFake, ITransactionService
    {
        public void CreateTransaction(Transaction entity)
        {
            var _transaction = new Transaction { TransactionID = Guid.Parse("70DCAC8B-3F5B-4878-A302-B41111821461"), Amount = 200, Card = CardDetails[0], CardID = CardDetails[0].CardDetailsID, BankReferenceID = Guid.Parse("6CEF9C79-FE93-4DA9-A985-6A4341929AC6"), Currency = Currencies[2], CurrencyID = Currencies[2].CurrencyId, Merchant = Merchants[0], MerchantID = Merchants[0].MerchantID, Status = "Successful", SubStatus = "Successful" };
            Transactions.Add(_transaction);
        }

        public Transaction GetTransactionById(Guid transactionID)
        {
            return Transactions.Where(t => t.TransactionID == transactionID).FirstOrDefault();
        }

        public List<Transaction> GetTransactionsByMerchantID(Guid merchantID)
        {
            return Transactions.Where(t => t.MerchantID == merchantID).ToList();
        }

        public void UpdateTransaction(Transaction transaction)
        {
            var trasaction = Transactions.Where(t => t.TransactionID == transaction.TransactionID);
        }
    }
}
