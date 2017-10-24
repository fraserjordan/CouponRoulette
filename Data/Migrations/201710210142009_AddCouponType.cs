namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCouponType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedCoupon", "CouponType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SavedCoupon", "CouponType");
        }
    }
}
