namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminWidgetAccesses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        adminwidget_Id = c.Long(nullable: false),
                        Role_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminWidgets", t => t.adminwidget_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.Role_Id)
                .Index(t => t.adminwidget_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.AdminWidgets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdminWidgetAccesses", "Role_Id", "dbo.AspNetRoles");
            DropForeignKey("dbo.AdminWidgetAccesses", "adminwidget_Id", "dbo.AdminWidgets");
            DropIndex("dbo.AdminWidgetAccesses", new[] { "Role_Id" });
            DropIndex("dbo.AdminWidgetAccesses", new[] { "adminwidget_Id" });
            DropTable("dbo.AdminWidgets");
            DropTable("dbo.AdminWidgetAccesses");
        }
    }
}
