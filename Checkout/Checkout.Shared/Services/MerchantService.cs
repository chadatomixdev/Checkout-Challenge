using Checkout.Data.Model;
using Checkout.Data.Services;
using Checkout.Shared.Interfaces;
using System;
using System.Linq;

namespace Checkout.Shared.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly RepositoryService _contextService;

        public MerchantService(RepositoryService contextService)
        {
            _contextService = contextService;
        }

        /// <summary>
        /// Search for the merchant by merchantID
        /// </summary>
        /// <param name="merchantID"></param>
        /// <returns></returns>
        public Merchant GetMerchant(Guid merchantID)
        {
            return _contextService.Find<Merchant>(m => m.MerchantID == merchantID).FirstOrDefault();
        }
    }
}