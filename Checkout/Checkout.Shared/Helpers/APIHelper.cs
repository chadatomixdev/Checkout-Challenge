using Checkout.Shared.Representers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.Shared.Helpers
{
    public static class APIHelper
    {
        public static async Task<HttpResponseMessage> ProcessTransactionAsync(TransactionRepresenter transaction, string bankURL)
        {
            var url = bankURL + "Transactions/transactions";

            var content = new Dictionary<string, string>
            {
                ["TransactionAmount"] = transaction.Amount.ToString(),
                ["cardNumber"] = transaction.Card.CardNumber,
                ["CardCvv"] = transaction.Card.Cvv,
                ["CardHolderName"] = transaction.Card.HolderName,
                ["CardExpiryMonth"] = transaction.Card.ExpiryMonth,
                ["CardExpiryYear"] = transaction.Card.ExpiryYear
            };

            return await WebRequestHelper.MakeAsyncRequest(url, content);
        }
    }
}
