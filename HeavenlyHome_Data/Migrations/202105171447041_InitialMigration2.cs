namespace HeavenlyHome_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MaintenanceRequest", newName: "MaintenanceListItems");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MaintenanceListItems", newName: "MaintenanceRequest");
        }
    }
}
