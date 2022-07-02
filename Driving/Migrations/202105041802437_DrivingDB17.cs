namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseComments", "CourseEntity_Id", "dbo.CourseEntities");
            DropIndex("dbo.CourseComments", new[] { "CourseEntity_Id" });
            AlterColumn("dbo.CourseComments", "CourseEntity_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.CourseComments", "CourseEntity_Id");
            AddForeignKey("dbo.CourseComments", "CourseEntity_Id", "dbo.CourseEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseComments", "CourseEntity_Id", "dbo.CourseEntities");
            DropIndex("dbo.CourseComments", new[] { "CourseEntity_Id" });
            AlterColumn("dbo.CourseComments", "CourseEntity_Id", c => c.Long());
            CreateIndex("dbo.CourseComments", "CourseEntity_Id");
            AddForeignKey("dbo.CourseComments", "CourseEntity_Id", "dbo.CourseEntities", "Id");
        }
    }
}
