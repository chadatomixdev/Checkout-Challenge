using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using System;
using System.Linq;

namespace Checkout.UnitTests.Fakes
{
    public class MerchantServiceFake : BaseFake, IMerchantService
    {
        public Merchant GetMerchant(Guid merchantID)
        {
            return Merchants.Where(m => m.MerchantID == merchantID).FirstOrDefault();
        }
    }
}