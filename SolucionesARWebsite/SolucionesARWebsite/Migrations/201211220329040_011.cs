namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _011 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "SalesManId", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "SalesManId" });
            DropColumn("dbo.Transactions", "SalesManId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "SalesManId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "SalesManId");
            AddForeignKey("dbo.Transactions", "SalesManId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
