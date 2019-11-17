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
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Currency>().ToTable("Currencies");
            builder.Entity<Merchant>().ToTable("Merchants");
            builder.Entity<Bank>().ToTable("Banks");
            builder.Entity<Transaction>().ToTable("Transactions");

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

            builder.Entity<Bank>().HasData(
                    new Bank { BankID  = 1, BankName = "MockBank", BankURL = "https://checkoutmockbank.azurewebsites.net/" },
                    new Bank { BankID = 2, BankName = "LocalTestBank", BankURL = "http://localhost:62268/" }
                );

            #endregion
        }
    }
}