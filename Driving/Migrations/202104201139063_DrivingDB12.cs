namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Widgets", "Widgetcategory_Id", "dbo.WidgetCategories");
            DropIndex("dbo.Widgets", new[] { "Widgetcategory_Id" });
            DropColumn("dbo.Widgets", "Widgetcategory_Id");
            DropTable("dbo.WidgetCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.WidgetCategories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Widgets", "Widgetcategory_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Widgets", "Widgetcategory_Id");
            AddForeignKey("dbo.Widgets", "Widgetcategory_Id", "dbo.WidgetCategories", "Id", cascadeDelete: true);
        }
    }
}
