namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserReferenceId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Users", "UserReferenceId", "dbo.Users", "UserId");
            CreateIndex("dbo.Users", "UserReferenceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserReferenceId" });
            DropForeignKey("dbo.Users", "UserReferenceId", "dbo.Users");
            DropColumn("dbo.Users", "UserReferenceId");
        }
    }
}
