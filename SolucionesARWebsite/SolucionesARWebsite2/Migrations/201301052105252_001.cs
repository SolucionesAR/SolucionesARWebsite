namespace SolucionesARWebsite2.Migrations
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
                        Dob = c.DateTime(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        PhoneNumber = c.String(),
                        Cellphone = c.String(),
                        OtherPhones = c.String(),
                        Email = c.String(),
                        CreatetedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        Enabled = c.Boolean(nullable: false),
                        Cashback = c.Double(nullable: false),
                        RolId = c.Int(nullable: false),
                        UserReferenceId = c.Int(),
                        IdentificationTypeId = c.Int(nullable: false),
                        Nationality = c.String(),
                        PasswordKey = c.String(),
                        Password = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Profision = c.String(),
                        OtherProducts = c.String(),
                        PersonalReference1 = c.String(),
                        PersonalReference2 = c.String(),
                        DistrictId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Bank = c.String(),
                        BankAccount = c.String(),
                        SinpeAccount = c.String(),
                        RelationshipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Rols", t => t.RolId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserReferenceId)
                .ForeignKey("dbo.IdentificationTypes", t => t.IdentificationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.RelationshipTypes", t => t.RelationshipTypeId, cascadeDelete: true)
                .Index(t => t.RolId)
                .Index(t => t.UserReferenceId)
                .Index(t => t.IdentificationTypeId)
                .Index(t => t.CompanyId)
                .Index(t => t.DistrictId)
                .Index(t => t.RelationshipTypeId);
            
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
                "dbo.IdentificationTypes",
                c => new
                    {
                        IdentificationTypeId = c.Int(nullable: false, identity: true),
                        IdentificationDescription = c.String(),
                    })
                .PrimaryKey(t => t.IdentificationTypeId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyNickName = c.String(),
                        CashBackPercentaje = c.Double(nullable: false),
                        CorporateId = c.String(),
                        CreatetedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        FaxNumber = c.String(),
                        DistrictId = c.Int(nullable: false),
                        ReferencePerson = c.String(),
                        ReferencePersonNumber = c.String(),
                        CreatetedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.DistrictId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CantonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Cantons", t => t.CantonId, cascadeDelete: true)
                .Index(t => t.CantonId);
            
            CreateTable(
                "dbo.Cantons",
                c => new
                    {
                        CantonId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CantonId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
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
                        CustomerId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CustomerId, cascadeDelete: false)
                .Index(t => t.StoreId)
                .Index(t => t.CustomerId);
            
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
                "dbo.GlobalParameters",
                c => new
                    {
                        GlobalParameterId = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Extra = c.String(),
                    })
                .PrimaryKey(t => t.GlobalParameterId);
            
            CreateTable(
                "dbo.CommissionLogs",
                c => new
                    {
                        CommissionLogId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatetedAt = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CommissionLogId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CommissionLogs", new[] { "UserId" });
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropIndex("dbo.Transactions", new[] { "StoreId" });
            DropIndex("dbo.Cantons", new[] { "ProvinceId" });
            DropIndex("dbo.Districts", new[] { "CantonId" });
            DropIndex("dbo.Stores", new[] { "CompanyId" });
            DropIndex("dbo.Stores", new[] { "DistrictId" });
            DropIndex("dbo.Users", new[] { "RelationshipTypeId" });
            DropIndex("dbo.Users", new[] { "DistrictId" });
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropIndex("dbo.Users", new[] { "IdentificationTypeId" });
            DropIndex("dbo.Users", new[] { "UserReferenceId" });
            DropIndex("dbo.Users", new[] { "RolId" });
            DropForeignKey("dbo.CommissionLogs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Transactions", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Cantons", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Districts", "CantonId", "dbo.Cantons");
            DropForeignKey("dbo.Stores", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Stores", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Users", "RelationshipTypeId", "dbo.RelationshipTypes");
            DropForeignKey("dbo.Users", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Users", "IdentificationTypeId", "dbo.IdentificationTypes");
            DropForeignKey("dbo.Users", "UserReferenceId", "dbo.Users");
            DropForeignKey("dbo.Users", "RolId", "dbo.Rols");
            DropTable("dbo.CommissionLogs");
            DropTable("dbo.GlobalParameters");
            DropTable("dbo.RelationshipTypes");
            DropTable("dbo.Transactions");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cantons");
            DropTable("dbo.Districts");
            DropTable("dbo.Stores");
            DropTable("dbo.Companies");
            DropTable("dbo.IdentificationTypes");
            DropTable("dbo.Rols");
            DropTable("dbo.Users");
        }
    }
}
