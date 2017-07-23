using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CouponEntities", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CouponEntities", "Category");
        }
    }
}
