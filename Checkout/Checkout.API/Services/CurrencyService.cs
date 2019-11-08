using Checkout.Data.Model;
using Checkout.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Services
{
    public class CurrencyService
    {
        private readonly RepositoryService _contextService;

        public CurrencyService(RepositoryService contextService)
        {
            contextService = _contextService;
        }

        public List<Currency> GetAllCurrencies()
        {
            return _contextService.Find<Currency>(x => x.CurrencyId != 0).ToList();
        }

        public Currency GetCurrency(string currency)
        {



            var currencies = _contextService.Find<Currency>(x => x.CurrencyId != 0).ToList();

            return _contextService.Find<Currency>(c => c.Name == "ZAR").FirstOrDefault();


            //return _contextService.Find<Currency>(c => c.Name == currency).FirstOrDefault();
        }
    }
}
