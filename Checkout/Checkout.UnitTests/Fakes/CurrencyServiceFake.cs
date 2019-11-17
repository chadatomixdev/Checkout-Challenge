using Checkout.Data.Model;
using Checkout.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Checkout.UnitTests.Fakes
{
    public class CurrencyServiceFake : BaseFake, ICurrencyService
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