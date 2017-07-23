using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class addWebsiteToActiveCoupons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CouponActiveEntities", "BusinessWebsite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CouponActiveEntities", "BusinessWebsite");
        }
    }
}
