namespace Konzole.InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INITIAL : DbMigration
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
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermissionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("IV.UserRole", "RoleId", c => c.Int());
            CreateIndex("IV.UserRole", "RoleId");
            AddForeignKey("IV.UserRole", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("IV.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Roles", "Permissions_Id", "dbo.Permissions");
            DropIndex("dbo.Roles", new[] { "Permissions_Id" });
            DropIndex("IV.UserRole", new[] { "RoleId" });
            DropColumn("IV.UserRole", "RoleId");
            DropTable("IV.WarehouseLoc");
            DropTable("dbo.Permissions");
            DropTable("dbo.Roles");
            DropTable("IV.Category");
        }
    }
}
