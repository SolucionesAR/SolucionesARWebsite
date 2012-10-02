namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        CedNumber = c.Int(nullable: false),
                        FName = c.String(),
                        LName1 = c.String(),
                        LName2 = c.String(),
                        GeneratedCode = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        PhoneNumber = c.String(),
                        Cellphone = c.String(),
                        Email = c.String(),
                        CreatetedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                        Cashback = c.Double(nullable: false),
                        RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Rols", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RolId);
            
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        RelationshipId = c.Int(nullable: false, identity: true),
                        CreatetedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        UserId1 = c.Int(nullable: false),
                        UserId2 = c.Int(nullable: false),
                        RelationshipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelationshipId)
                .ForeignKey("dbo.Users", t => t.UserId1, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId2, cascadeDelete: false)
                .ForeignKey("dbo.RelationshipTypes", t => t.RelationshipTypeId, cascadeDelete: true)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2)
                .Index(t => t.RelationshipTypeId);
            
            CreateTable(
                "dbo.RelationshipTypes",
                c => new
                    {
                        RelationshipTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatetedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RelationshipTypeId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CashBackPercentaje = c.Double(nullable: false),
                        CorporateId = c.String(),
                        CreatetedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        FaxNumber = c.String(),
                        CityId = c.Int(nullable: false),
                        CreatetedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        BillBarCode = c.String(),
                        Amount = c.Double(nullable: false),
                        CreatetedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        StoreId = c.Int(nullable: false),
                        SalesManId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.SalesManId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CustomerId, cascadeDelete: false)
                .Index(t => t.StoreId)
                .Index(t => t.SalesManId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Transactions", new[] { "SalesManId" });
            DropIndex("dbo.Transactions", new[] { "StoreId" });
            DropIndex("dbo.Stores", new[] { "CompanyId" });
            DropIndex("dbo.Relationships", new[] { "RelationshipTypeId" });
            DropIndex("dbo.Relationships", new[] { "UserId2" });
            DropIndex("dbo.Relationships", new[] { "UserId1" });
            DropIndex("dbo.Users", new[] { "RolId" });
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "SalesManId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Stores", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Relationships", "RelationshipTypeId", "dbo.RelationshipTypes");
            DropForeignKey("dbo.Relationships", "UserId2", "dbo.Users");
            DropForeignKey("dbo.Relationships", "UserId1", "dbo.Users");
            DropForeignKey("dbo.Users", "RolId", "dbo.Rols");
            DropTable("dbo.Transactions");
            DropTable("dbo.Stores");
            DropTable("dbo.Companies");
            DropTable("dbo.RelationshipTypes");
            DropTable("dbo.Relationships");
            DropTable("dbo.Rols");
            DropTable("dbo.Users");
        }
    }
}
