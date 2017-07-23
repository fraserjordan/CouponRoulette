namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuUrlToBusinessInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusinessInfoes", "MenuUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BusinessInfoes", "MenuUrl");
        }
    }
}
