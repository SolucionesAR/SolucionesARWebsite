namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CantonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Cantons", t => t.CantonId, cascadeDelete: false)
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
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: false)
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
                "dbo.GlobalParameters",
                c => new
                    {
                        GlobalParameterId = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.GlobalParameterId);
            
            AddColumn("dbo.Users", "OtherPhones", c => c.String());
            AddColumn("dbo.Users", "Profision", c => c.String());
            AddColumn("dbo.Users", "OtherProducts", c => c.String());
            AddColumn("dbo.Users", "PersonalReference1", c => c.String());
            AddColumn("dbo.Users", "PersonalReference2", c => c.String());
            AddColumn("dbo.Users", "DistrictId", c => c.Int(nullable: false));
            AddColumn("dbo.Companies", "CompanyNickName", c => c.String());
            AddColumn("dbo.Companies", "Enabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stores", "DistrictId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Users", "DistrictId", "dbo.Districts", "DistrictId", cascadeDelete: false);
            AddForeignKey("dbo.Stores", "DistrictId", "dbo.Districts", "DistrictId", cascadeDelete: false);
            CreateIndex("dbo.Users", "DistrictId");
            CreateIndex("dbo.Stores", "DistrictId");
            DropColumn("dbo.Stores", "CityId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "CityId", c => c.Int(nullable: false));
            DropIndex("dbo.Cantons", new[] { "ProvinceId" });
            DropIndex("dbo.Districts", new[] { "CantonId" });
            DropIndex("dbo.Stores", new[] { "DistrictId" });
            DropIndex("dbo.Users", new[] { "DistrictId" });
            DropForeignKey("dbo.Cantons", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Districts", "CantonId", "dbo.Cantons");
            DropForeignKey("dbo.Stores", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Users", "DistrictId", "dbo.Districts");
            DropColumn("dbo.Stores", "DistrictId");
            DropColumn("dbo.Companies", "Enabled");
            DropColumn("dbo.Companies", "CompanyNickName");
            DropColumn("dbo.Users", "DistrictId");
            DropColumn("dbo.Users", "PersonalReference2");
            DropColumn("dbo.Users", "PersonalReference1");
            DropColumn("dbo.Users", "OtherProducts");
            DropColumn("dbo.Users", "Profision");
            DropColumn("dbo.Users", "OtherPhones");
            DropTable("dbo.GlobalParameters");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cantons");
            DropTable("dbo.Districts");
        }
    }
}
