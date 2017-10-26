namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDatesDataToCouponEntities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvailableCoupon", "DateActivated", c => c.DateTime(nullable: false));
            AddColumn("dbo.AvailableCoupon", "DateAssigned", c => c.DateTime(nullable: false));
            AddColumn("dbo.SavedCoupon", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.CustomerInfo", "ComplaintCount");
            DropColumn("dbo.SavedCoupon", "AmountRedeemed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SavedCoupon", "AmountRedeemed", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerInfo", "ComplaintCount", c => c.Int(nullable: false));
            DropColumn("dbo.SavedCoupon", "DateCreated");
            DropColumn("dbo.AvailableCoupon", "DateAssigned");
            DropColumn("dbo.AvailableCoupon", "DateActivated");
        }
    }
}
