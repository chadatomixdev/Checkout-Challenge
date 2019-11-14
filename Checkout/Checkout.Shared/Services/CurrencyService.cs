using Checkout.Data.Model;
using Checkout.Data.Services;
using Checkout.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.Shared.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly RepositoryService _contextService;
        public CurrencyService(RepositoryService contextService)
        {
            _contextService = contextService;
        }

        /// <summary>
        /// Return all currencies from the DB
        /// </summary>
        /// <returns></returns>
        public List<Currency> GetAllCurrencies()
        {
            return _contextService.Find<Currency>(x => x.CurrencyId != 0).ToList();
        }

        /// <summary>
        /// Return currency by name
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Currency GetCurrencyByName(string currency)
        {
            return _contextService.Find<Currency>(c => c.Name == currency).FirstOrDefault();
        }

        /// <summary>
        /// Return currency by ID
        /// </summary>
        /// <param name="currencyID"></param>
        /// <returns></returns>
        public Currency GetCurrencyByID(int currencyID)
        {
            return _contextService.Find<Currency>(c => c.CurrencyId == currencyID).FirstOrDefault();
        }
    }
}