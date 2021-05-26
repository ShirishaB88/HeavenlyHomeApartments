namespace HeavenlyHome_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMaintenaceRequestResidentColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaintenanceRequest", "ResidentID", "dbo.Resident");
            DropIndex("dbo.MaintenanceRequest", new[] { "ResidentID" });
            DropColumn("dbo.MaintenanceRequest", "ResidentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaintenanceRequest", "ResidentID", c => c.Int(nullable: false));
            CreateIndex("dbo.MaintenanceRequest", "ResidentID");
            AddForeignKey("dbo.MaintenanceRequest", "ResidentID", "dbo.Resident", "ResidentID", cascadeDelete: true);
        }
    }
}
