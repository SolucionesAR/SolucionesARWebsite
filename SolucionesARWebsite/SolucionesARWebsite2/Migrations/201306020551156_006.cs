namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditProcesses", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CreditProcesses", new[] { "CompanyId" });
            AddColumn("dbo.CreditProcesses", "Company_CompanyId", c => c.Int());
            AddForeignKey("dbo.CreditProcesses", "Company_CompanyId", "dbo.Companies", "CompanyId");
            CreateIndex("dbo.CreditProcesses", "Company_CompanyId");
            DropColumn("dbo.CreditProcesses", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditProcesses", "CompanyId", c => c.Int(nullable: false));
            DropIndex("dbo.CreditProcesses", new[] { "Company_CompanyId" });
            DropForeignKey("dbo.CreditProcesses", "Company_CompanyId", "dbo.Companies");
            DropColumn("dbo.CreditProcesses", "Company_CompanyId");
            CreateIndex("dbo.CreditProcesses", "CompanyId");
            AddForeignKey("dbo.CreditProcesses", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
    }
}
