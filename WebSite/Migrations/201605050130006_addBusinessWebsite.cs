using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class addBusinessWebsite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BusinesssWebsite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BusinesssWebsite");
        }
    }
}
