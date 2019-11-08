using System;
using Checkout.API.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.API.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class TransactionsController : ControllerBase
    {
        #region Properties

        #endregion

        /// <summary>
        /// Post a transaction
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        [HttpPost]
        [Route("transactions", Name = "PostTransaction")]
        public IActionResult PostTransaction()
        {
        
            
            
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
