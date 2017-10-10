namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableCoupon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountLeft = c.Int(nullable: false),
                        CouponText = c.String(),
                        Status = c.Int(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        SavedCoupon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.SavedCoupon", t => t.SavedCoupon_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.SavedCoupon_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AccountType = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        BusinessInfo_Id = c.Int(),
                        CustomerInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessInfo", t => t.BusinessInfo_Id)
                .ForeignKey("dbo.CustomerInfo", t => t.CustomerInfo_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.BusinessInfo_Id)
                .Index(t => t.CustomerInfo_Id);
            
            CreateTable(
                "dbo.BusinessInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessName = c.String(),
                        Lat = c.Double(nullable: false),
                        Lng = c.Double(nullable: false),
                        FormattedAddress = c.String(),
                        FormattedPhoneNumber = c.String(),
                        InternationalPhoneNumber = c.String(),
                        GooglePlaceId = c.String(),
                        WebsiteUrl = c.String(),
                        Rating = c.Double(nullable: false),
                        MenuUrl = c.String(),
                        AddressVerificationStatus = c.Int(nullable: false),
                        AddressVerificationCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomerInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponUnRedeemedCount = c.Int(nullable: false),
                        CouponRedeemedCount = c.Int(nullable: false),
                        ComplaintCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SavedCoupon",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponTitle = c.String(),
                        CouponText = c.String(),
                        AmountRedeemed = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Business_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Business_Id)
                .Index(t => t.Business_Id);
            
            CreateTable(
                "dbo.CouponHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        ReasonCreated = c.Int(nullable: false),
                        Customer_Id = c.String(maxLength: 128),
                        SavedCoupon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .ForeignKey("dbo.SavedCoupon", t => t.SavedCoupon_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.SavedCoupon_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CouponHistory", "SavedCoupon_Id", "dbo.SavedCoupon");
            DropForeignKey("dbo.CouponHistory", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AvailableCoupon", "SavedCoupon_Id", "dbo.SavedCoupon");
            DropForeignKey("dbo.SavedCoupon", "Business_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AvailableCoupon", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CustomerInfo_Id", "dbo.CustomerInfo");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "BusinessInfo_Id", "dbo.BusinessInfo");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CouponHistory", new[] { "SavedCoupon_Id" });
            DropIndex("dbo.CouponHistory", new[] { "Customer_Id" });
            DropIndex("dbo.SavedCoupon", new[] { "Business_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "CustomerInfo_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "BusinessInfo_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AvailableCoupon", new[] { "SavedCoupon_Id" });
            DropIndex("dbo.AvailableCoupon", new[] { "Customer_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.CouponHistory");
            DropTable("dbo.SavedCoupon");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.CustomerInfo");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.BusinessInfo");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AvailableCoupon");
        }
    }
}
