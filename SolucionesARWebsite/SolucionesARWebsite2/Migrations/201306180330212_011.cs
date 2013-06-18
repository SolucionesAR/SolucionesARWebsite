namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _011 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditProcessLogs", "CreditProcessId", "dbo.CreditProcesses");
            DropIndex("dbo.CreditProcessLogs", new[] { "CreditProcessId" });
            AddColumn("dbo.CreditProcessLogs", "CreditProcessXCompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.CreditProcessLogs", "CreditProcess_CreditProcessId", c => c.Int());
            AddColumn("dbo.CreditProcessXCompanies", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.CreditProcessXCompanies", "UpdatedAt", c => c.DateTime());
            AddForeignKey("dbo.CreditProcessLogs", "CreditProcessXCompanyId", "dbo.CreditProcessXCompanies", "CreditProcessXCompanyId", cascadeDelete: true);
            AddForeignKey("dbo.CreditProcessLogs", "CreditProcess_CreditProcessId", "dbo.CreditProcesses", "CreditProcessId");
            CreateIndex("dbo.CreditProcessLogs", "CreditProcessXCompanyId");
            CreateIndex("dbo.CreditProcessLogs", "CreditProcess_CreditProcessId");
            DropColumn("dbo.CreditProcessLogs", "CreditProcessId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditProcessLogs", "CreditProcessId", c => c.Int(nullable: false));
            DropIndex("dbo.CreditProcessLogs", new[] { "CreditProcess_CreditProcessId" });
            DropIndex("dbo.CreditProcessLogs", new[] { "CreditProcessXCompanyId" });
            DropForeignKey("dbo.CreditProcessLogs", "CreditProcess_CreditProcessId", "dbo.CreditProcesses");
            DropForeignKey("dbo.CreditProcessLogs", "CreditProcessXCompanyId", "dbo.CreditProcessXCompanies");
            DropColumn("dbo.CreditProcessXCompanies", "UpdatedAt");
            DropColumn("dbo.CreditProcessXCompanies", "CreatedAt");
            DropColumn("dbo.CreditProcessLogs", "CreditProcess_CreditProcessId");
            DropColumn("dbo.CreditProcessLogs", "CreditProcessXCompanyId");
            CreateIndex("dbo.CreditProcessLogs", "CreditProcessId");
            AddForeignKey("dbo.CreditProcessLogs", "CreditProcessId", "dbo.CreditProcesses", "CreditProcessId", cascadeDelete: true);
        }
    }
}
