using System;
using System.Threading.Tasks;
using Checkout.API.Helpers;
using Checkout.API.Representers;
using Checkout.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.API.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class TransactionsController : ControllerBase
    {
        #region Properties

        private readonly CurrencyService _currencyService;

        #endregion

        #region Constructor
        public TransactionsController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        #endregion

        /// <summary>
        /// Process a transaction
        /// </summary>======
        /// <returns></returns>
        //[Authorize]
        [HttpPost]
        [Route("process")]
        public async Task<IActionResult> ProcessTransaction(TransactionRepresenter transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (transaction.Amount <= 0)
                return BadRequest("Amount is invalid");

            bool isValid = Guid.TryParse(transaction.MerchantID, out Guid guidOutput);
            if (!isValid)
                return BadRequest("Merchant is invalid");

            if (_currencyService.GetCurrency(transaction.Currency) is null)
                return BadRequest("Currency not supported");


            //TODO CC Validation 


            //POST to mock bank 
            //Update transaction status 

            //TODO Create transaction in DB 

            //Process transaction through mock acquirer
            var processed = await APIHelper.ProcessTransactionAsync(transaction);


            return Ok();
        }



        //TODO implement method to get all transactions for a merchant


        //TODO implemennt method to get a specific transaction with details for a merchant

        //[HttpGet]
        //public IEnumerable<WeatherForecast> GetTransactionById()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

    }
}
