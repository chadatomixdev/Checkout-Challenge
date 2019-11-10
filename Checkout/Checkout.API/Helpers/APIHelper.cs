using Checkout.API.Representers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Helpers
{
    public static class APIHelper
    {

        public static async Task<bool> ProcessTransactionAsync(TransactionRepresenter transaction)
        {
            var url = WebRequestHelper.BaseUrl + "Transactions/transactions";

            var content = new Dictionary<string, string>
            {
                ["TransactionAmount"] = transaction.Amount.ToString(),
                ["cardNumber"] = transaction.Card.CardNumber,
                ["CardCvv"] = transaction.Card.Cvv,
                ["CardHolderName"] = transaction.Card.HolderName,
                ["CardExpiryMonth"] = transaction.Card.ExpiryMonth,
                ["CardExpiryYear"] = transaction.Card.ExpiryYear
            };

            var response = await WebRequestHelper.MakeAsyncRequest(url, content);

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}