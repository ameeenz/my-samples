namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB13 : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Widgets", "Widgetcategory_Id", c => c.Long());
            CreateIndex("dbo.Widgets", "Widgetcategory_Id");
            AddForeignKey("dbo.Widgets", "Widgetcategory_Id", "dbo.WidgetCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Widgets", "Widgetcategory_Id", "dbo.WidgetCategories");
            DropIndex("dbo.Widgets", new[] { "Widgetcategory_Id" });
            DropColumn("dbo.Widgets", "Widgetcategory_Id");
            DropTable("dbo.WidgetCategories");
        }
    }
}
