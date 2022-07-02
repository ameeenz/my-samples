namespace Driving.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrivingDB23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        WebSite = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MessageEntities");
        }
    }
}
