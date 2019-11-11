using Checkout.Data.Model;
using Checkout.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Services
{
    public class TransactionService
    {
        private readonly RepositoryService _contextService;
        public TransactionService(RepositoryService contextService)
        {
            _contextService = contextService;
        }

        /// <summary>
        /// Add new transaction to the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void CreateTransaction(Transaction entity)
        {
            _contextService.Add(entity);
        }

        /// <summary>
        /// Get transaction by ID
        /// </summary>
        /// <param name="transactionID"></param>
        /// <returns></returns>
        public Transaction GetTransactionById(Guid transactionID)
        {
            return _contextService.Find<Transaction>(t => t.TransactionID == transactionID).FirstOrDefault();
        }

        /// <summary>
        /// Get all transactions for merchant
        /// </summary>
        /// <param name="merchantID"></param>
        /// <returns></returns>
        public List<Transaction> GetTransactions(Guid merchantID)
        {
            var transaction = _contextService.Find<Transaction>(t => t.MerchantID == merchantID).ToList();

             return _contextService.Find<Transaction>(t => t.MerchantID == merchantID).ToList();
        }
    }
}