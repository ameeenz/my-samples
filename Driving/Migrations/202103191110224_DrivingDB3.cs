namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "PictureURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "PictureURL");
        }
    }
}
