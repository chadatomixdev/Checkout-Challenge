using Checkout.Data.Model;
using System;
using System.Collections.Generic;

namespace Checkout.Shared.Interfaces
{
    public interface  ITransactionService
    {
        void CreateTransaction(Transaction entity);
        Transaction GetTransactionById(Guid transactionID);
        List<Transaction> GetTransactionsByMerchantID(Guid merchantID);
        void UpdateTransaction(Transaction transaction);
    }
}