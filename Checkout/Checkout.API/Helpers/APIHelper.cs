using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Helpers
{
    public static class APIHelper
    {

        public static async Task<bool> ProcessTransactionAsync()
        {
            var url = WebRequestHelper.BaseUrl + "Transactions/transactions";

            var content = new Dictionary<string, string>
            {
            };

            var response = await WebRequestHelper.MakeAsyncRequest(url, content);

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}
