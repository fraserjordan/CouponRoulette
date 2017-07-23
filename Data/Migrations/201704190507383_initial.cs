namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActiveCoupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponText = c.String(),
                        DateTimeRedeemed = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AvailableCoupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmountLeft = c.Int(nullable: false),
                        SavedCouponId = c.Int(nullable: false),
                        BusinessInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessInfoes", t => t.BusinessInfo_Id)
                .Index(t => t.BusinessInfo_Id);
            
            CreateTable(
                "dbo.CouponTransactionHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDateTime = c.DateTime(nullable: false),
                        Business_Id = c.String(maxLength: 128),
                        Coupon_Id = c.Int(),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Business_Id)
                .ForeignKey("dbo.SavedCoupons", t => t.Coupon_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .Index(t => t.Business_Id)
                .Index(t => t.Coupon_Id)
                .Index(t => t.Customer_Id);
            
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
                .ForeignKey("dbo.BusinessInfoes", t => t.BusinessInfo_Id)
                .ForeignKey("dbo.CustomerInfoes", t => t.CustomerInfo_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.BusinessInfo_Id)
                .Index(t => t.CustomerInfo_Id);
            
            CreateTable(
                "dbo.BusinessInfoes",
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
                        AddressVerificationStatus = c.Int(nullable: false),
                        AddressVerificationCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SavedCoupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponText = c.String(),
                        AmountRedeemed = c.Int(nullable: false),
                        BusinessInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessInfoes", t => t.BusinessInfo_Id)
                .Index(t => t.BusinessInfo_Id);
            
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
                "dbo.CustomerInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponExpiredCount = c.Int(nullable: false),
                        CompaintCount = c.Int(nullable: false),
                        ActiveCoupon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActiveCoupons", t => t.ActiveCoupon_Id)
                .Index(t => t.ActiveCoupon_Id);
            
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
            DropForeignKey("dbo.CouponTransactionHistories", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CouponTransactionHistories", "Coupon_Id", "dbo.SavedCoupons");
            DropForeignKey("dbo.CouponTransactionHistories", "Business_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CustomerInfo_Id", "dbo.CustomerInfoes");
            DropForeignKey("dbo.CustomerInfoes", "ActiveCoupon_Id", "dbo.ActiveCoupons");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "BusinessInfo_Id", "dbo.BusinessInfoes");
            DropForeignKey("dbo.SavedCoupons", "BusinessInfo_Id", "dbo.BusinessInfoes");
            DropForeignKey("dbo.AvailableCoupons", "BusinessInfo_Id", "dbo.BusinessInfoes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.CustomerInfoes", new[] { "ActiveCoupon_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.SavedCoupons", new[] { "BusinessInfo_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "CustomerInfo_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "BusinessInfo_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CouponTransactionHistories", new[] { "Customer_Id" });
            DropIndex("dbo.CouponTransactionHistories", new[] { "Coupon_Id" });
            DropIndex("dbo.CouponTransactionHistories", new[] { "Business_Id" });
            DropIndex("dbo.AvailableCoupons", new[] { "BusinessInfo_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.CustomerInfoes");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.SavedCoupons");
            DropTable("dbo.BusinessInfoes");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CouponTransactionHistories");
            DropTable("dbo.AvailableCoupons");
            DropTable("dbo.ActiveCoupons");
        }
    }
}
