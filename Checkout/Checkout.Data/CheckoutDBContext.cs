using Checkout.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

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
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<CardDetails> CardDetails { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Currency>().ToTable("Currency");
            builder.Entity<Merchant>().ToTable("Merchant");

            builder.Entity<CardDetails>()
            .Property(cd => cd.CardDetailsID)
            .ValueGeneratedOnAdd();

            #region Seed Data

            builder.Entity<Currency>().HasData(
                    new Currency { CurrencyId = 1, Name = "ZAR" },
                    new Currency { CurrencyId = 2, Name = "USD" },
                    new Currency { CurrencyId = 3, Name = "GBP" }
                );

            builder.Entity<Merchant>().HasData(
                    new Merchant { MerchantID = Guid.NewGuid(), Name = "Test Merchant 1", Active = true, Description = "Testing Description 1"},
                    new Merchant { MerchantID = Guid.NewGuid(), Name = "Test Merchant 2", Active = true, Description = "Testing Description 2" },
                    new Merchant { MerchantID = Guid.NewGuid(), Name = "Test Merchant 3", Active = true, Description = "Testing Description 3" }
                );

            #endregion
        }
    }
}