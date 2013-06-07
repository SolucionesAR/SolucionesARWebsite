namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _008 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LaboralTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "LaboralTime");
        }
    }
}
