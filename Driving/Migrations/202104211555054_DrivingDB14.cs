namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Widgets", "Widgetcategory_Id", "dbo.WidgetCategories");
            DropIndex("dbo.Widgets", new[] { "Widgetcategory_Id" });
            AlterColumn("dbo.Widgets", "Widgetcategory_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Widgets", "Widgetcategory_Id");
            AddForeignKey("dbo.Widgets", "Widgetcategory_Id", "dbo.WidgetCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Widgets", "Widgetcategory_Id", "dbo.WidgetCategories");
            DropIndex("dbo.Widgets", new[] { "Widgetcategory_Id" });
            AlterColumn("dbo.Widgets", "Widgetcategory_Id", c => c.Long());
            CreateIndex("dbo.Widgets", "Widgetcategory_Id");
            AddForeignKey("dbo.Widgets", "Widgetcategory_Id", "dbo.WidgetCategories", "Id");
        }
    }
}
