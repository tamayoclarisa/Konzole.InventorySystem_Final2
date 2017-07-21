namespace Konzole.InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "IV.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        RecUser = c.String(),
                        Recdate = c.DateTime(nullable: false),
                        ModUser = c.String(),
                        Moddate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "IV.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        TIN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LogMessages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EntryTypeId = c.Int(nullable: false),
                        LogTime = c.DateTime(nullable: false),
                        Message = c.String(nullable: false, maxLength: 2048),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "IV.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermissionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Firstname = c.String(nullable: false, maxLength: 255, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Phone = c.String(nullable: false, maxLength: 25, unicode: false),
                        EmailAddress = c.String(maxLength: 255, unicode: false),
                        Address = c.String(nullable: false, maxLength: 500, unicode: false),
                        City = c.String(nullable: false, maxLength: 255, unicode: false),
                        State = c.String(nullable: false, maxLength: 2, unicode: false),
                        PostalCode = c.String(nullable: false, maxLength: 11, unicode: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "IV.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sku = c.String(),
                        UOM = c.Int(nullable: false),
                        RecUser = c.String(),
                        RecDate = c.DateTime(nullable: false),
                        ModUser = c.String(),
                        ModDate = c.DateTime(),
                        IsActive = c.Int(nullable: false),
                        CategoryId_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("IV.Category", t => t.CategoryId_CategoryId)
                .Index(t => t.CategoryId_CategoryId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Permissions_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissions", t => t.Permissions_Id)
                .Index(t => t.Permissions_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "IV.Supplier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        Address = c.String(),
                        Contact = c.String(),
                        Email = c.String(),
                        EWTId = c.Int(nullable: false),
                        VATtypeId = c.Int(nullable: false),
                        Terms = c.Int(nullable: false),
                        Recuser = c.String(),
                        Recdate = c.DateTime(),
                        Moduser = c.Int(nullable: false),
                        ModDate = c.DateTime(),
                        Taxcode = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "IV.UOM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "IV.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ModuleId = c.String(),
                        RecUser = c.String(),
                        Recdate = c.DateTime(nullable: false),
                        ModUser = c.String(),
                        Moddate = c.DateTime(),
                        WithPermission = c.Boolean(nullable: false),
                        RoleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "IV.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCode = c.String(),
                        Description = c.String(),
                        Password = c.String(),
                        Recuser = c.String(),
                        Recdate = c.DateTime(nullable: false),
                        Moduser = c.String(),
                        Moddate = c.DateTime(),
                        LastPasswordChange = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
                "IV.WarehouseLoc",
                c => new
                    {
                        WarehouseLocId = c.Int(nullable: false, identity: true),
                        LocationAddress = c.String(),
                        RecUser = c.String(),
                        Recdate = c.DateTime(nullable: false),
                        ModUser = c.String(),
                        Moddate = c.DateTime(),
                    })
                .PrimaryKey(t => t.WarehouseLocId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("IV.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Roles", "Permissions_Id", "dbo.Permissions");
            DropForeignKey("IV.Product", "CategoryId_CategoryId", "IV.Category");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("IV.UserRole", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Roles", new[] { "Permissions_Id" });
            DropIndex("IV.Product", new[] { "CategoryId_CategoryId" });
            DropTable("IV.WarehouseLoc");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("IV.User");
            DropTable("IV.UserRole");
            DropTable("IV.UOM");
            DropTable("IV.Supplier");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Roles");
            DropTable("IV.Product");
            DropTable("dbo.People");
            DropTable("dbo.Permissions");
            DropTable("IV.Module");
            DropTable("dbo.LogMessages");
            DropTable("IV.Customer");
            DropTable("IV.Category");
        }
    }
}
