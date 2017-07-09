namespace Konzole.InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRoleIdOnUserRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("IV.UserRole", "RoleId", c => c.Int());
            CreateIndex("IV.UserRole", "RoleId");
            AddForeignKey("IV.UserRole", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("IV.UserRole", "RoleId", "dbo.Roles");
            DropIndex("IV.UserRole", new[] { "RoleId" });
            DropColumn("IV.UserRole", "RoleId");
        }
    }
}
