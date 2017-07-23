namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCouponTextToAvailableCoupons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvailableCoupons", "CouponText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AvailableCoupons", "CouponText");
        }
    }
}
