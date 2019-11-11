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
    }
}
