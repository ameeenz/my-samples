namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationFormEntities", "FullName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationFormEntities", "FullName", c => c.String(nullable: false));
        }
    }
}
