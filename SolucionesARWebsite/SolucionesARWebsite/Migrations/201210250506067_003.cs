namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentificationTypes",
                c => new
                    {
                        IdentificationTypeId = c.Int(nullable: false, identity: true),
                        IdentificationDescription = c.String(),
                    })
                .PrimaryKey(t => t.IdentificationTypeId);
            
            AddColumn("dbo.Users", "IdentificationTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Nationality", c => c.String());
            AddColumn("dbo.Users", "PasswordKey", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "CompanyId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Users", "IdentificationTypeId", "dbo.IdentificationTypes", "IdentificationTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: false);
            CreateIndex("dbo.Users", "IdentificationTypeId");
            CreateIndex("dbo.Users", "CompanyId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropIndex("dbo.Users", new[] { "IdentificationTypeId" });
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Users", "IdentificationTypeId", "dbo.IdentificationTypes");
            DropColumn("dbo.Users", "CompanyId");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "PasswordKey");
            DropColumn("dbo.Users", "Nationality");
            DropColumn("dbo.Users", "IdentificationTypeId");
            DropTable("dbo.IdentificationTypes");
        }
    }
}
