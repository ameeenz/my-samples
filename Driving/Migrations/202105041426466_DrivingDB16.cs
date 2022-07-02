namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB16 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                        CourseEntity_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseEntities", t => t.CourseEntity_Id)
                .Index(t => t.CourseEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseComments", "CourseEntity_Id", "dbo.CourseEntities");
            DropIndex("dbo.CourseComments", new[] { "CourseEntity_Id" });
            DropTable("dbo.CourseComments");
        }
    }
}
