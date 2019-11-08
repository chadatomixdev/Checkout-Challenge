using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Checkout.EFMigrations
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<CheckoutDBContext>
    {
        public CheckoutDBContext CreateDbContext(string[] args)
        {
            //TODO Change to Azure Key Vault Temporary for now. NB DO NOT COMMIT DB Connection String
            var builder = new DbContextOptionsBuilder<CheckoutDBContext>();
            builder.UseSqlServer("Server=checkoutchallenge.database.windows.net;Database=checkout;User Id=chadbonthuys@checkoutchallenge.database.windows.net;Password=a63*WF5A761g;MultipleActiveResultSets=true;");

            return new CheckoutDBContext(builder.Options);
        }
    }
}