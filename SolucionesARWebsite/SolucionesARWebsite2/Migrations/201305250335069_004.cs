namespace SolucionesARWebsite2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LName", c => c.String());
            DropColumn("dbo.Customers", "LName1");
            DropColumn("dbo.Customers", "LName2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "LName2", c => c.String());
            AddColumn("dbo.Customers", "LName1", c => c.String());
            DropColumn("dbo.Customers", "LName");
        }
    }
}
