namespace FinalEventApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Count = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        TicketCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EventId", "dbo.Events");
            DropIndex("dbo.Orders", new[] { "EventId" });
            DropTable("dbo.Orders");
        }
    }
}
