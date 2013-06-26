namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _012 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditComments", "creditProcessXCompanyId", c => c.Int(nullable: false, defaultValue: 1));
            AddForeignKey("dbo.CreditComments", "creditProcessXCompanyId", "dbo.CreditProcessXCompanies", "CreditProcessXCompanyId", cascadeDelete: false);
            CreateIndex("dbo.CreditComments", "creditProcessXCompanyId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CreditComments", new[] { "creditProcessXCompanyId" });
            DropForeignKey("dbo.CreditComments", "creditProcessXCompanyId", "dbo.CreditProcessXCompanies");
            DropColumn("dbo.CreditComments", "creditProcessXCompanyId");
        }
    }
}
