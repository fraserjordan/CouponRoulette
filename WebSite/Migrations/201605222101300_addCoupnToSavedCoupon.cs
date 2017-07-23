using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class addCoupnToSavedCoupon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CouponEntities", "SavedCoupon_Id", c => c.Int());
            AddColumn("dbo.SavedCoupons", "RedeemedCount", c => c.Int(nullable: false));
            CreateIndex("dbo.CouponEntities", "SavedCoupon_Id");
            AddForeignKey("dbo.CouponEntities", "SavedCoupon_Id", "dbo.SavedCoupons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CouponEntities", "SavedCoupon_Id", "dbo.SavedCoupons");
            DropIndex("dbo.CouponEntities", new[] { "SavedCoupon_Id" });
            DropColumn("dbo.SavedCoupons", "RedeemedCount");
            DropColumn("dbo.CouponEntities", "SavedCoupon_Id");
        }
    }
}
