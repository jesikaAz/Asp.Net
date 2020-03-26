namespace OgameLikeTP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Planets", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Resources", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.SolarSystems", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SolarSystems", "Name", c => c.String());
            AlterColumn("dbo.Resources", "Name", c => c.String());
            AlterColumn("dbo.Planets", "Name", c => c.String());
        }
    }
}
