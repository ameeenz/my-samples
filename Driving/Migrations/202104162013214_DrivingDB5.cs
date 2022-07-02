namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdminWidgetAccesses", "adminwidget_Id", "dbo.AdminWidgets");
            DropForeignKey("dbo.AdminWidgetAccesses", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.AdminWidgetAccesses", new[] { "adminwidget_Id" });
            DropIndex("dbo.AdminWidgetAccesses", new[] { "Role_Id" });
            CreateTable(
                "dbo.WidgetAccesses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        widget_Id = c.Long(nullable: false),
                        Role_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetRoles", t => t.Role_Id)
                .ForeignKey("dbo.Widgets", t => t.widget_Id, cascadeDelete: true)
                .Index(t => t.widget_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Widgets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.AdminWidgetAccesses");
            DropTable("dbo.AdminWidgets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdminWidgets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminWidgetAccesses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        adminwidget_Id = c.Long(nullable: false),
                        Role_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.WidgetAccesses", "widget_Id", "dbo.Widgets");
            DropForeignKey("dbo.WidgetAccesses", "Role_Id", "dbo.AspNetRoles");
            DropIndex("dbo.WidgetAccesses", new[] { "Role_Id" });
            DropIndex("dbo.WidgetAccesses", new[] { "widget_Id" });
            DropTable("dbo.Widgets");
            DropTable("dbo.WidgetAccesses");
            CreateIndex("dbo.AdminWidgetAccesses", "Role_Id");
            CreateIndex("dbo.AdminWidgetAccesses", "adminwidget_Id");
            AddForeignKey("dbo.AdminWidgetAccesses", "Role_Id", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AdminWidgetAccesses", "adminwidget_Id", "dbo.AdminWidgets", "Id", cascadeDelete: true);
        }
    }
}
