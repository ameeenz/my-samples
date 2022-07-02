namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewsCategoryEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.NewsEntities", "NewsCategory_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.NewsEntities", "NewsCategory_Id");
            AddForeignKey("dbo.NewsEntities", "NewsCategory_Id", "dbo.NewsCategoryEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsEntities", "NewsCategory_Id", "dbo.NewsCategoryEntities");
            DropIndex("dbo.NewsEntities", new[] { "NewsCategory_Id" });
            DropColumn("dbo.NewsEntities", "NewsCategory_Id");
            DropTable("dbo.NewsCategoryEntities");
        }
    }
}
