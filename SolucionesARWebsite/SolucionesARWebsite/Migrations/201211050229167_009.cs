namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _009 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Dob", c => c.DateTime());
            AlterColumn("dbo.Users", "CreatetedAt", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "CreatetedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
