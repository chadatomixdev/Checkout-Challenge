using Checkout.Data.Model;

namespace Checkout.Shared.Interfaces
{
    public interface IBankService
    {
        Bank GetBankByName(string bank);
    }
}