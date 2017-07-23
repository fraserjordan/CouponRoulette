using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class AddAddressStringActiveCOupons : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CouponActiveEntities", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CouponActiveEntities", "Address");
        }
    }
}
