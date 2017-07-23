using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class changeCouponHistoryDataTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CouponHistoryEntities", "BusinessId", c => c.String());
            AlterColumn("dbo.CouponHistoryEntities", "CustomerId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CouponHistoryEntities", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.CouponHistoryEntities", "BusinessId", c => c.Int(nullable: false));
        }
    }
}
