using Checkout.Data.Model;
using System.Collections.Generic;

namespace Checkout.Shared.Interfaces
{
    public interface ICurrencyService
    {
        List<Currency> GetAllCurrencies();
        Currency GetCurrencyByName(string currency);
        Currency GetCurrencyByID(int currencyID);
    }
}