using Checkout.Data.Model;
using Checkout.Data.Services;
using Checkout.Shared.Helpers;
using Checkout.Shared.Interfaces;
using Checkout.Shared.Models;
using Checkout.Shared.Representers;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

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

        /// <summary>
        /// Process a tranction through an acquirer
        /// </summary>
        /// <param name="transactionRepresenter"></param>
        /// <param name="bankURL"></param>
        /// <returns></returns>
        public async Task<TransactionCreationRepresenter> ProcessTransaction(TransactionRepresenter transactionRepresenter, string bankURL)
        {
            //Process transaction through acquirer
            var bankResponse = await APIHelper.ProcessTransactionAsync(transactionRepresenter, bankURL);
            var bankResponseData = bankResponse.Content.ReadAsStringAsync().Result;

            var json = JsonConvert.DeserializeObject<BankResponse>(bankResponseData);
            var transactionCreationRepresenter = new TransactionCreationRepresenter
            {
                BankResponseID = json.BankResponseID,
                Status = json.Status.ToString(),
                SubStatus = json.SubStatus.ToString(),
            };

            return transactionCreationRepresenter;
        }
    }
}