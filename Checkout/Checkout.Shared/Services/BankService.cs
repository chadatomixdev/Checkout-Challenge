using Checkout.Data.Model;
using Checkout.Data.Services;
using Checkout.Shared.Interfaces;
using System;
using System.Linq;

namespace Checkout.Shared.Services
{
    public class BankService : IBankService
    {
        private readonly RepositoryService _contextService;

        public BankService(RepositoryService contextService)
        {
            _contextService = contextService;
        }

        /// <summary>
        /// Get bank by the banks name
        /// </summary>
        /// <param name="bank"></param>
        /// <returns></returns>
        public Bank GetBankByName(string bank)
        {
            return _contextService.Find<Bank>(b => b.BankName == bank).FirstOrDefault();
        }
    }
}