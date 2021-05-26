namespace HeavenlyHome_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedResidentPhoneNumberColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resident", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resident", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
