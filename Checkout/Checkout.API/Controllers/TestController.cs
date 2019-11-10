using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        #region Properties
        private IConfiguration _configuration { get; }

        #endregion

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// This returns version information as a base test API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("test/version")]
        public IActionResult Test()
        {
            // Version
           var version = _configuration.GetSection("VersionOptions:Version").Value;

            return Ok(version);
        }
    }
}