using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class RemoveActiveCOuponsTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CouponEntities", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.CouponEntities", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            AddColumn("dbo.CouponEntities", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.CouponEntities", "RedeemCode", c => c.String());
            AddColumn("dbo.CouponEntities", "Business_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.CouponEntities", "Customer_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CouponEntities", "Business_Id");
            CreateIndex("dbo.CouponEntities", "Customer_Id");
            AddForeignKey("dbo.CouponEntities", "Business_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CouponEntities", "Customer_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.CouponActiveEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CouponActiveEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Created = c.DateTime(nullable: false),
                        Redeemed = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BusinessId = c.String(),
                        CustomerId = c.String(),
                        BusinessName = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        Address = c.String(),
                        BusinessPhone = c.String(),
                        BusinessWebsite = c.String(),
                        RedeemCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.CouponEntities", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CouponEntities", "Business_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CouponEntities", new[] { "Customer_Id" });
            DropIndex("dbo.CouponEntities", new[] { "Business_Id" });
            DropColumn("dbo.CouponEntities", "Customer_Id");
            DropColumn("dbo.CouponEntities", "Business_Id");
            DropColumn("dbo.CouponEntities", "RedeemCode");
            DropColumn("dbo.CouponEntities", "Status");
            RenameIndex(table: "dbo.CouponEntities", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.CouponEntities", name: "ApplicationUser_Id", newName: "User_Id");
        }
    }
}
