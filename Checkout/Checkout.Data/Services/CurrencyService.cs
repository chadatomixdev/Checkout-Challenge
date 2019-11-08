using Checkout.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Data.Services
{
    public class CurrencyService
    {
        private readonly RepositoryService _contextService;

        public List<Currency> GetAllCurrencies()
        {
            return _contextService.Find<Currency>(x => x.CurrencyId != 0).ToList();
        }

        public Currency GetCurrency(string currency)
        {
            return _contextService.Find<Currency>(c => c.Name == currency).FirstOrDefault();
        }
    }
}