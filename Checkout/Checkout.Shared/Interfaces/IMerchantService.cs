using Checkout.Data.Model;
using System;

namespace Checkout.Shared.Interfaces
{
    public interface IMerchantService
    {
        Merchant GetMerchant(Guid merchantID);
    }
}