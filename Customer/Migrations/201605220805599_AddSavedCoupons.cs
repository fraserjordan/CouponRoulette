using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class AddSavedCoupons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedCoupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(nullable: false),
                        Category = c.Int(nullable: false),
                        RedeemCode = c.String(),
                        Business_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Business_Id)
                .Index(t => t.Business_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavedCoupons", "Business_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SavedCoupons", new[] { "Business_Id" });
            DropTable("dbo.SavedCoupons");
        }
    }
}
