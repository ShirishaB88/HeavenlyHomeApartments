namespace HeavenlyHome_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        FloorPlanID = c.Int(nullable: false),
                        FullAddress = c.String(nullable: false, maxLength: 1000),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.FloorPlan", t => t.FloorPlanID, cascadeDelete: true)
                .Index(t => t.FloorPlanID);
            
            CreateTable(
                "dbo.FloorPlan",
                c => new
                    {
                        FloorPlanID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        FloorPlanName = c.String(nullable: false),
                        NoOfBeds = c.Int(nullable: false),
                        NoOfBaths = c.Int(nullable: false),
                        AreaInSqFt = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        NoOfGarageSpaces = c.Int(nullable: false),
                        Image = c.String(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        CreatedDate = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.FloorPlanID);
            
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        AplicantID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        MoveInDate = c.DateTime(nullable: false),
                        Requirements = c.String(),
                    })
                .PrimaryKey(t => t.AplicantID);
            
            CreateTable(
                "dbo.LeasingInfo",
                c => new
                    {
                        LeasingID = c.Int(nullable: false, identity: true),
                        ResidentID = c.Int(nullable: false),
                        LeaseTerm = c.Int(nullable: false),
                        NoOfOccupants = c.Int(nullable: false),
                        IsPetIncluded = c.Boolean(nullable: false),
                        OccupantsDetails = c.String(nullable: false),
                        LeaseStartDate = c.DateTime(nullable: false),
                        LeaseEndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LeasingID)
                .ForeignKey("dbo.Resident", t => t.ResidentID, cascadeDelete: true)
                .Index(t => t.ResidentID);
            
            CreateTable(
                "dbo.Resident",
                c => new
                    {
                        ResidentID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        AddressID = c.Int(nullable: false),
                        FullName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.ResidentID)
                .ForeignKey("dbo.Address", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.MaintenanceRequest",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        ResidentID = c.Int(nullable: false),
                        Category = c.String(nullable: false),
                        SubCategory = c.String(),
                        Location = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 3000),
                        Status = c.String(),
                        AccessPermission = c.Boolean(nullable: false),
                        RequestDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.RequestID)
                .ForeignKey("dbo.Resident", t => t.ResidentID, cascadeDelete: true)
                .Index(t => t.ResidentID);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        ResidentID = c.Int(nullable: false),
                        PaymentTypeID = c.Int(nullable: false),
                        Rent = c.Double(nullable: false),
                        UtilityAmount = c.Double(nullable: false),
                        PaymentDueDate = c.DateTime(nullable: false),
                        PaymentDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.PaymentType", t => t.PaymentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Resident", t => t.ResidentID, cascadeDelete: true)
                .Index(t => t.ResidentID)
                .Index(t => t.PaymentTypeID);
            
            CreateTable(
                "dbo.PaymentType",
                c => new
                    {
                        PaymentTypeID = c.Int(nullable: false, identity: true),
                        PaymentTypeName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentTypeID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Payment", "ResidentID", "dbo.Resident");
            DropForeignKey("dbo.Payment", "PaymentTypeID", "dbo.PaymentType");
            DropForeignKey("dbo.MaintenanceRequest", "ResidentID", "dbo.Resident");
            DropForeignKey("dbo.LeasingInfo", "ResidentID", "dbo.Resident");
            DropForeignKey("dbo.Resident", "AddressID", "dbo.Address");
            DropForeignKey("dbo.Address", "FloorPlanID", "dbo.FloorPlan");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Payment", new[] { "PaymentTypeID" });
            DropIndex("dbo.Payment", new[] { "ResidentID" });
            DropIndex("dbo.MaintenanceRequest", new[] { "ResidentID" });
            DropIndex("dbo.Resident", new[] { "AddressID" });
            DropIndex("dbo.LeasingInfo", new[] { "ResidentID" });
            DropIndex("dbo.Address", new[] { "FloorPlanID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.UserRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PaymentType");
            DropTable("dbo.Payment");
            DropTable("dbo.MaintenanceRequest");
            DropTable("dbo.Resident");
            DropTable("dbo.LeasingInfo");
            DropTable("dbo.Applicant");
            DropTable("dbo.FloorPlan");
            DropTable("dbo.Address");
        }
    }
}
