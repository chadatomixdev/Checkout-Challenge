using Checkout.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Data
{
    /// <summary>
    /// Database Context for Entity Framework
    /// </summary>
    public class CheckoutDBContext : DbContext
    {
        public CheckoutDBContext(DbContextOptions options) : base(options)
        {
            //Create the DB if it does not exist and apply pending migrations
            Database.Migrate();
        }

        #region DBSets 

        public virtual DbSet<Currency> Currencies { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Currency>().ToTable("Currency");

            #region Seed Data

            builder.Entity<Currency>().HasData(
                    new Currency { CurrencyId = 1, Name = "ZAR" },
                    new Currency { CurrencyId = 2, Name = "USD" },
                    new Currency { CurrencyId = 3, Name = "GBP" }
                );

            #endregion
        }
    }
}