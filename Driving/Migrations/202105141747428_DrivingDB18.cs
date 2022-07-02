namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationFormEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Course_Id = c.Long(nullable: false),
                        Car_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarEntities", t => t.Car_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseEntities", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Car_Id);
            
            CreateTable(
                "dbo.CarEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationFormEntities", "Course_Id", "dbo.CourseEntities");
            DropForeignKey("dbo.ApplicationFormEntities", "Car_Id", "dbo.CarEntities");
            DropIndex("dbo.ApplicationFormEntities", new[] { "Car_Id" });
            DropIndex("dbo.ApplicationFormEntities", new[] { "Course_Id" });
            DropTable("dbo.CarEntities");
            DropTable("dbo.ApplicationFormEntities");
        }
    }
}
