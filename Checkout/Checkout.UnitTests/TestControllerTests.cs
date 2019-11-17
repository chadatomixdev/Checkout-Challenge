using Checkout.API.Controllers;
using Checkout.UnitTests.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Checkout.UnitTests
{
    public class TestControllerTests : IClassFixture<Setup>
    {
        TestController _testController;
        ServiceProvider _serviceProvider;

        public TestControllerTests(Setup setup)
        {
            _serviceProvider = setup.ServiceProvider;
            _testController = new TestController(_serviceProvider.GetService< IConfiguration>());
        }

        [Fact]
        public void GetTestVersion()
        {
            //Act
            var okResult = _testController.Test();

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}