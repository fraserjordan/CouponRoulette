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
        public DbSet<CouponHistory> CouponHistory { get; set; }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<BusinessInfo> BusinessInfo { get; set; }

        public static DataContext Create()
        {
            return new DataContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasOptional(x => x.BusinessInfo);
            modelBuilder.Entity<AvailableCoupon>().ToTable("AvailableCoupon");
            modelBuilder.Entity<BusinessInfo>().ToTable("BusinessInfo");
            modelBuilder.Entity<CouponHistory>().ToTable("CouponHistory");
            modelBuilder.Entity<CustomerInfo>().ToTable("CustomerInfo");
            modelBuilder.Entity<SavedCoupon>().ToTable("SavedCoupon");
        }
    }
}