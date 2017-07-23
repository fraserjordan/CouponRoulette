using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class addFromandToDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CouponEntities", "ValidFrom", c => c.DateTime(nullable: false));
            AddColumn("dbo.CouponEntities", "ValidTo", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CouponEntities", "ValidTo");
            DropColumn("dbo.CouponEntities", "ValidFrom");
        }
    }
}
