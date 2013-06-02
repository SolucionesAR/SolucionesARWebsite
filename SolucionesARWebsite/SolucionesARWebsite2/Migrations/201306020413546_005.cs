namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Users");
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            CreateTable(
                "dbo.CreditComments",
                c => new
                    {
                        CreditCommentId = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        CreditProcessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCommentId)
                .ForeignKey("dbo.CreditProcesses", t => t.CreditProcessId, cascadeDelete: true)
                .Index(t => t.CreditProcessId);
            
            CreateTable(
                "dbo.CreditProcessXCompanies",
                c => new
                    {
                        CreditProcessXCompanyId = c.Int(nullable: false, identity: true),
                        CreditProcessId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditProcessXCompanyId)
                .ForeignKey("dbo.CreditProcesses", t => t.CreditProcessId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.CreditProcessId)
                .Index(t => t.CompanyId);
            
            AddColumn("dbo.Companies", "IsFinantial", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transactions", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.CreditProcesses", "Product", c => c.String());
            AddForeignKey("dbo.Transactions", "UserId", "dbo.Users", "UserId", cascadeDelete: false);
            CreateIndex("dbo.Transactions", "UserId");
            DropColumn("dbo.Transactions", "CustomerId");
            DropColumn("dbo.CreditProcesses", "ExtraDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditProcesses", "ExtraDetails", c => c.String());
            AddColumn("dbo.Transactions", "CustomerId", c => c.Int(nullable: false));
            DropIndex("dbo.CreditProcessXCompanies", new[] { "CompanyId" });
            DropIndex("dbo.CreditProcessXCompanies", new[] { "CreditProcessId" });
            DropIndex("dbo.CreditComments", new[] { "CreditProcessId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropForeignKey("dbo.CreditProcessXCompanies", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CreditProcessXCompanies", "CreditProcessId", "dbo.CreditProcesses");
            DropForeignKey("dbo.CreditComments", "CreditProcessId", "dbo.CreditProcesses");
            DropForeignKey("dbo.Transactions", "UserId", "dbo.Users");
            DropColumn("dbo.CreditProcesses", "Product");
            DropColumn("dbo.Transactions", "UserId");
            DropColumn("dbo.Companies", "IsFinantial");
            DropTable("dbo.CreditProcessXCompanies");
            DropTable("dbo.CreditComments");
            CreateIndex("dbo.Transactions", "CustomerId");
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
