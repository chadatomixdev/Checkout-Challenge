using Checkout.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.UnitTests.Fakes
{
    public class BaseFact
    {
        public List<Currency> Currencies = new List<Currency>();

        public BaseFact()
        {
            GenerateMockCurrencies();
            GenrateMockMerchants();
        }

        private void GenerateMockCurrencies()
        {
            var _currency1 = new Currency
            {
                CurrencyId = 1,
                Name = "ZAR"
            };

            var _currency2 = new Currency
            {
                CurrencyId = 2,
                Name = "USD"
            };

            var _currency3 = new Currency
            {
                CurrencyId = 3,
                Name = "GBP"
            };

            Currencies.Add(_currency1);
            Currencies.Add(_currency2);
            Currencies.Add(_currency3);
        }

        private void GenrateMockMerchants()
        {
            throw new NotImplementedException();
        }
    }
}