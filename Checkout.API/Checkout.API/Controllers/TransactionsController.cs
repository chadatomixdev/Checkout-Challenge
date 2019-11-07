using System;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.API.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class TransactionsController : ControllerBase
    {
        //TODO implement method to process a transaction
        public TransactionsController()
        //[HttpPost]
        //public IEnumerable<WeatherForecast> PostTransaction()
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
