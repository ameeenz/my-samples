namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        Ttile = c.String(),
                        Description = c.String(),
                        PictureURL = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FAQEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Answer = c.String(),
                        Question = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NewsEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Author = c.String(),
                        Ttile = c.String(),
                        Description = c.String(),
                        PictureURL = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewsEntities");
            DropTable("dbo.FAQEntities");
            DropTable("dbo.CourseEntities");
        }
    }
}
