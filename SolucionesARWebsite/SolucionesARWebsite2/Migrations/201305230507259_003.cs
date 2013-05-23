namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditProcesses",
                c => new
                    {
                        CreditProcessId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CreditStatusId = c.Int(nullable: false),
                        ExtraDetails = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CreditProcessId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.CreditStatus", t => t.CreditStatusId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId)
                .Index(t => t.CreditStatusId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName1 = c.String(),
                        LName2 = c.String(),
                        CedNumber = c.String(),
                        PhoneNumber = c.String(),
                        Boss = c.String(),
                        Possition = c.String(),
                        Salary = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.CreditStatus",
                c => new
                    {
                        CreditStatusId = c.Int(nullable: false, identity: true),
                        CreditStatusDescription = c.String(),
                    })
                .PrimaryKey(t => t.CreditStatusId);
            
            CreateTable(
                "dbo.CreditProcessLogs",
                c => new
                    {
                        CreditProcessLogId = c.Int(nullable: false, identity: true),
                        CreditProcessId = c.Int(nullable: false),
                        ChangeDate = c.DateTime(nullable: false),
                        LastStatusId = c.Int(nullable: false),
                        NewStatusId = c.Int(nullable: false),
                        CreditStatus_CreditStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.CreditProcessLogId)
                .ForeignKey("dbo.CreditProcesses", t => t.CreditProcessId, cascadeDelete: true)
                .ForeignKey("dbo.CreditStatus", t => t.LastStatusId, cascadeDelete: false)
                .ForeignKey("dbo.CreditStatus", t => t.NewStatusId, cascadeDelete: false)
                .ForeignKey("dbo.CreditStatus", t => t.CreditStatus_CreditStatusId)
                .Index(t => t.CreditProcessId)
                .Index(t => t.LastStatusId)
                .Index(t => t.NewStatusId)
                .Index(t => t.CreditStatus_CreditStatusId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CreditProcessLogs", new[] { "CreditStatus_CreditStatusId" });
            DropIndex("dbo.CreditProcessLogs", new[] { "NewStatusId" });
            DropIndex("dbo.CreditProcessLogs", new[] { "LastStatusId" });
            DropIndex("dbo.CreditProcessLogs", new[] { "CreditProcessId" });
            DropIndex("dbo.CreditProcesses", new[] { "CreditStatusId" });
            DropIndex("dbo.CreditProcesses", new[] { "CompanyId" });
            DropIndex("dbo.CreditProcesses", new[] { "UserId" });
            DropIndex("dbo.CreditProcesses", new[] { "CustomerId" });
            DropForeignKey("dbo.CreditProcessLogs", "CreditStatus_CreditStatusId", "dbo.CreditStatus");
            DropForeignKey("dbo.CreditProcessLogs", "NewStatusId", "dbo.CreditStatus");
            DropForeignKey("dbo.CreditProcessLogs", "LastStatusId", "dbo.CreditStatus");
            DropForeignKey("dbo.CreditProcessLogs", "CreditProcessId", "dbo.CreditProcesses");
            DropForeignKey("dbo.CreditProcesses", "CreditStatusId", "dbo.CreditStatus");
            DropForeignKey("dbo.CreditProcesses", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CreditProcesses", "UserId", "dbo.Users");
            DropForeignKey("dbo.CreditProcesses", "CustomerId", "dbo.Customers");
            DropTable("dbo.CreditProcessLogs");
            DropTable("dbo.CreditStatus");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditProcesses");
        }
    }
}
