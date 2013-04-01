namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "StoreId", "dbo.Stores");
            DropIndex("dbo.Transactions", new[] { "StoreId" });
            AddColumn("dbo.Transactions", "TransactionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Transactions", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "Comision", c => c.Double(nullable: false));
            AddForeignKey("dbo.Transactions", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
            CreateIndex("dbo.Transactions", "CompanyId");
            DropColumn("dbo.Transactions", "StoreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "StoreId", c => c.Int(nullable: false));
            DropIndex("dbo.Transactions", new[] { "CompanyId" });
            DropForeignKey("dbo.Transactions", "CompanyId", "dbo.Companies");
            DropColumn("dbo.Transactions", "Comision");
            DropColumn("dbo.Transactions", "CompanyId");
            DropColumn("dbo.Transactions", "TransactionDate");
            CreateIndex("dbo.Transactions", "StoreId");
            AddForeignKey("dbo.Transactions", "StoreId", "dbo.Stores", "StoreId", cascadeDelete: true);
        }
    }
}
