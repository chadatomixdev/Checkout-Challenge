using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Checkout.Data
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<CheckoutDBContext>
    {
        public CheckoutDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CheckoutDBContext>();
            builder.UseSqlServer("Server=");

            return new CheckoutDBContext(builder.Options);
        }
    }
}