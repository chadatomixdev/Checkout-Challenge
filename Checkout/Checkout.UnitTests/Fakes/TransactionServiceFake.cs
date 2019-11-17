using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.UnitTests.Fakes
{
    public class TransactionServiceFake : BaseFake, ITransactionService
    {
        public Currency Currency = new Currency();
        public Merchant Merchant = new Merchant();
        public CardDetails CardDetailsFake = new CardDetails();

        public TransactionServiceFake()
        {
            Currency = Currencies[2];
            Merchant = Merchants[0];
            CardDetailsFake = CardDetails[0];
        }

        public void CreateTransaction(Transaction entity)
        {
            Transactions.Add(entity);
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
