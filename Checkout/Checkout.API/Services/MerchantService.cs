using Checkout.Data.Model;
using Checkout.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Services
{
    public class MerchantService
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