using Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data
{
    using System.Data.Entity;

    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<SavedCoupon> SavedCoupons { get; set; }
        public DbSet<AvailableCoupon> AvailableCoupons { get; set; }
        public DbSet<ActiveCoupon> ActiveCoupons { get; set; }
        public DbSet<CouponTransactionHistory> CouponTransactionHistory { get; set; }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasOptional(x => x.BusinessInfo);
        }
    }
}