namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _009 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditProcessXCompanies", "CreditStatusId", c => c.Int(nullable: false));
            AddForeignKey("dbo.CreditProcessXCompanies", "CreditStatusId", "dbo.CreditStatus", "CreditStatusId", cascadeDelete: false);
            CreateIndex("dbo.CreditProcessXCompanies", "CreditStatusId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CreditProcessXCompanies", new[] { "CreditStatusId" });
            DropForeignKey("dbo.CreditProcessXCompanies", "CreditStatusId", "dbo.CreditStatus");
            DropColumn("dbo.CreditProcessXCompanies", "CreditStatusId");
        }
    }
}
