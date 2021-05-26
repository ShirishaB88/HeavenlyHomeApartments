namespace HeavenlyHome_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedApplicantPhoneNumberColumn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicant", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicant", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
