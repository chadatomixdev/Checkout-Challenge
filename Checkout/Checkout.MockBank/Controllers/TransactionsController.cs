using Checkout.MockBank.Moodels;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.MockBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        /// <summary>
        /// Process a Transaction
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("transactions", Name = "ProcessTransaction")]
        public IActionResult ProcessTransaction([FromForm]MockTransaction transaction)
        {

            //Possible test cases 

            //Expired card or expiration date does not match.
            //


            return Ok();
        }
    }
}