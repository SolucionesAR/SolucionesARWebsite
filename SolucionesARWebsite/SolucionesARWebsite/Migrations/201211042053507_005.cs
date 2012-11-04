namespace SolucionesARWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "StoreName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "StoreName");
        }
    }
}
