namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _014 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "RelationshipTypeId", "dbo.RelationshipTypes");
            DropIndex("dbo.Users", new[] { "RelationshipTypeId" });
            DropColumn("dbo.Users", "RelationshipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RelationshipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RelationshipTypeId");
            AddForeignKey("dbo.Users", "RelationshipTypeId", "dbo.RelationshipTypes", "RelationshipTypeId", cascadeDelete: true);
        }
    }
}
