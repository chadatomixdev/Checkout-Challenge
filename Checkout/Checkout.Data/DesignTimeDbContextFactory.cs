using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Checkout.Data
{
    /// <summary>
    /// Implementation of the IDesignTimeDbContextFactory interface to bypass the requirment of specifying
    /// the DBContext in the application startup for Migrations
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CheckoutDBContext>
    {
        public CheckoutDBContext CreateDbContext(string[] args)
        {
            //TODO store the db config in Azure Key Vault. Temp for now, do not commit for security purposes
            var builder = new DbContextOptionsBuilder<CheckoutDBContext>();
            builder.UseSqlServer("server=checkoutchallenge.database.windows.net;Database=checkoutchallengedb;User Id=chadbonthuys@checkoutchallenge.database.windows.net;Password=a63*WF5A761g;MultipleActiveResultSets=true;");

            return new CheckoutDBContext(builder.Options);
        }
    }
}