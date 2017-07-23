using System.Data.Entity.Migrations;

namespace Customer.Migrations
{
    public partial class RemoveBusinessFromSavedCoupons : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SavedCoupons", name: "Business_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.SavedCoupons", name: "IX_Business_Id", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SavedCoupons", name: "IX_ApplicationUser_Id", newName: "IX_Business_Id");
            RenameColumn(table: "dbo.SavedCoupons", name: "ApplicationUser_Id", newName: "Business_Id");
        }
    }
}
