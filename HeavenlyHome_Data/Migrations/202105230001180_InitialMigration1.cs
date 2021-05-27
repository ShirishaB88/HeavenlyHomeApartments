namespace HeavenlyHome_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MaintenanceRequest", "Category", c => c.Int(nullable: false));
            AlterColumn("dbo.MaintenanceRequest", "Location", c => c.Int(nullable: false));
            DropColumn("dbo.MaintenanceRequest", "SubCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaintenanceRequest", "SubCategory", c => c.String());
            AlterColumn("dbo.MaintenanceRequest", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.MaintenanceRequest", "Category", c => c.String(nullable: false));
        }
    }
}
