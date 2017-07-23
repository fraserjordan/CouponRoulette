namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRelationships : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SavedCoupons", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.SavedCoupons", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SavedCoupons", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.SavedCoupons", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
