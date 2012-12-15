namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _012 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relationships", "RelationshipTypeId", "dbo.RelationshipTypes");
            DropIndex("dbo.Relationships", new[] { "RelationshipTypeId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Relationships", "RelationshipTypeId");
            AddForeignKey("dbo.Relationships", "RelationshipTypeId", "dbo.RelationshipTypes", "RelationshipTypeId", cascadeDelete: true);
        }
    }
}
