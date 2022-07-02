namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB8 : DbMigration
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
            
            AddColumn("dbo.Widgets", "WidgetCategory_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Widgets", "WidgetCategory_Id");
            AddForeignKey("dbo.Widgets", "WidgetCategory_Id", "dbo.WidgetCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Widgets", "WidgetCategory_Id", "dbo.WidgetCategories");
            DropIndex("dbo.Widgets", new[] { "WidgetCategory_Id" });
            DropColumn("dbo.Widgets", "WidgetCategory_Id");
            DropTable("dbo.WidgetCategories");
        }
    }
}
