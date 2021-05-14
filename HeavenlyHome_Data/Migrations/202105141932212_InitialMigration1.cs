namespace HeavenlyHome_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FloorPlan", "FloorPlanName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FloorPlan", "FloorPlanName");
        }
    }
}
