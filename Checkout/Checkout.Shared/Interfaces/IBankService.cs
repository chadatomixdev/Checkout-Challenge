using Checkout.Data.Model;
using Checkout.Shared.Representers;
using System.Threading.Tasks;

namespace Checkout.Shared.Interfaces
{
    public interface IBankService
    {
        Task<TransactionCreationRepresenter> ProcessTransaction(TransactionRepresenter transactionRepresenter, string bankURL);
        Bank GetBankByName(string bank);
    }
}