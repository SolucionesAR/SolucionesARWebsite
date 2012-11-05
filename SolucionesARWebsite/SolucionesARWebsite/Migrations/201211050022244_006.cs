namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _006 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserReferenceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserReferenceId", c => c.Int(nullable: false));
        }
    }
}
