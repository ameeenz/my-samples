namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        Ip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Visits");
        }
    }
}
