using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.Shared.Representers;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.UnitTests.Fakes
{
    public class BankServiceFake : BaseFake, IBankService
    {
        public Bank GetBankByName(string bank)
        {
            return Banks.Where(b => b.BankName == bank).FirstOrDefault();
        }

        public Task<TransactionCreationRepresenter> ProcessTransaction(TransactionRepresenter transactionRepresenter, string bankURL)
        {
            throw new System.NotImplementedException();
        }
    }
}