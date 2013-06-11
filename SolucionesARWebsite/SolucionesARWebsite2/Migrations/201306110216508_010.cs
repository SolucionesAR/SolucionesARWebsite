namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _010 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditProcesses", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.CreditProcesses", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditProcesses", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CreditProcesses", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
