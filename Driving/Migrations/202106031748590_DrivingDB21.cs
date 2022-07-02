namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        NewsEntity_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsEntities", t => t.NewsEntity_Id, cascadeDelete: true)
                .Index(t => t.NewsEntity_Id);
            
            CreateTable(
                "dbo.NewsLikes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IP = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        NewsEntity_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsEntities", t => t.NewsEntity_Id, cascadeDelete: true)
                .Index(t => t.NewsEntity_Id);
            
            CreateTable(
                "dbo.NewsVisits",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IP = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        NewsEntity_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsEntities", t => t.NewsEntity_Id, cascadeDelete: true)
                .Index(t => t.NewsEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsVisits", "NewsEntity_Id", "dbo.NewsEntities");
            DropForeignKey("dbo.NewsLikes", "NewsEntity_Id", "dbo.NewsEntities");
            DropForeignKey("dbo.NewsComments", "NewsEntity_Id", "dbo.NewsEntities");
            DropIndex("dbo.NewsVisits", new[] { "NewsEntity_Id" });
            DropIndex("dbo.NewsLikes", new[] { "NewsEntity_Id" });
            DropIndex("dbo.NewsComments", new[] { "NewsEntity_Id" });
            DropTable("dbo.NewsVisits");
            DropTable("dbo.NewsLikes");
            DropTable("dbo.NewsComments");
        }
    }
}
