using Checkout.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Data
{
    /// <summary>
    /// Database Context for Entity Framework
    /// </summary>
    public class CheckoutDBContext : DbContext
    {
        public CheckoutDBContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        #region DBSets 

        //public virtual DbSet<BudgetPeriods> BudgetPeriods { get; set; }
        //public virtual DbSet<CardDetails> CardDetails { get; set; }
        //public virtual DbSet<Merchant> Merchant { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Merchant>(entity =>
            //{

            //});

            builder.Entity<Test>().ToTable("Test");

        }

        #region Seed Data



        #endregion
    }
}