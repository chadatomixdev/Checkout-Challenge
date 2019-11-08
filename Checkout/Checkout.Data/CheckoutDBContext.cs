using Microsoft.EntityFrameworkCore;

namespace Checkout.Data
{
    public class CheckoutDBContext : DbContext
    {
        /// <summary>
        /// Database Context for Entity Framework
        /// </summary>
        public CheckoutDBContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        #region DBSets

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}