namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _007 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "UserId", c => c.Int(nullable: false, defaultValue: 1));
            AddColumn("dbo.Companies", "IsFinantial", c => c.Boolean(nullable: false));
            AddColumn("dbo.CreditProcesses", "Product", c => c.String());

            CreateIndex("dbo.Transactions", "UserId");
            AddForeignKey("dbo.Transactions", "UserId", "dbo.Users", "UserId", cascadeDelete: false);
            

            


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
            
        }
        
        public override void Down()
        {
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
