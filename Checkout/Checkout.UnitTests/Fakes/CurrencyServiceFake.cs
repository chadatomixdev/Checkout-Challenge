using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using Checkout.UnitTests.Fakes;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.UnitTests
{
    public class CurrencyServiceFake : BaseFact, ICurrencyService
    {
        public List<Currency> GetAllCurrencies()
        {
            return Currencies;
        }

        public Currency GetCurrencyByID(int currencyID)
        {
            return Currencies.Where(c => c.CurrencyId == currencyID).FirstOrDefault();
        }

        public Currency GetCurrencyByName(string currency)
        {
            return Currencies.Where(c => c.Name == currency).FirstOrDefault();
        }
    }
}