using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using System.Linq;

namespace Checkout.UnitTests.Fakes
{
    public class BankServiceFake : BaseFake, IBankService
    {
        public Bank GetBankByName(string bank)
        {
            return Banks.Where(b => b.BankName == bank).FirstOrDefault();
        }
    }
}