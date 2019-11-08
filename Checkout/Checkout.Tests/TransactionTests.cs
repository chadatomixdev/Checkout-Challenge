using Xunit;

namespace Checkout.Tests
{
    public class TransactionTests
    {
        const string baseURL = "https://checkoutchallengeapi.azurewebsites.net/";

    //TODO Complete implementation of Positive and Negative Checks for processing a transaction
    [Theory]
    [InlineData(10.00)]
    //[InlineData(50.00, "CVV")]
    public void PostTransactionTest(decimal amount)
    {
        //var data = CreateTransactionModelHelper.GetModelTestData(name, surname, email);
        //var response = _apiService.PostTransaction(data);
        //Assert.True(response.StatusName == StatusName.Completed);
    }
   }
}