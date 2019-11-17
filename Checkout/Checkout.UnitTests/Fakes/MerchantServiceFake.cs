using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.UnitTests.Fakes;
using System;

namespace Checkout.UnitTests
{
    public class MerchantServiceFake : BaseFact, IMerchantService
    {
        public Merchant GetMerchant(Guid merchantID)
        {
            throw new NotImplementedException();
        }
    }
}