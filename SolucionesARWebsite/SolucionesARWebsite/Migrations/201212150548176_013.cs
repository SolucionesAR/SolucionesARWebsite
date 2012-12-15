namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _013 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RelationshipTypeId", c => c.Int(nullable: true));
            AddForeignKey("dbo.Users", "RelationshipTypeId", "dbo.RelationshipTypes", "RelationshipTypeId", cascadeDelete: true);
            CreateIndex("dbo.Users", "RelationshipTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "RelationshipTypeId" });
            DropForeignKey("dbo.Users", "RelationshipTypeId", "dbo.RelationshipTypes");
            DropColumn("dbo.Users", "RelationshipTypeId");
        }
    }
}
