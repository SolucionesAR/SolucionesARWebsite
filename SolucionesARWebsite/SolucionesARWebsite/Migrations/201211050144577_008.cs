namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _008 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserReferenceId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserReferenceId", c => c.Int(nullable: false));
        }
    }
}
