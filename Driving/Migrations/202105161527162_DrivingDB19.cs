namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationFormEntities", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.ApplicationFormEntities", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.ApplicationFormEntities", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationFormEntities", "PhoneNumber", c => c.String());
            AlterColumn("dbo.ApplicationFormEntities", "Email", c => c.String());
            AlterColumn("dbo.ApplicationFormEntities", "FullName", c => c.String());
        }
    }
}
