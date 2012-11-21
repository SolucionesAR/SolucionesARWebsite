namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _010 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "Points", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "Points");
            DropColumn("dbo.Users", "Points");
        }
    }
}
