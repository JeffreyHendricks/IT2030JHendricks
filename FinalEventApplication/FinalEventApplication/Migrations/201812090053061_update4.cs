namespace FinalEventApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        EventTypeId = c.Int(nullable: false, identity: true),
                        EventTypeTitle = c.String(),
                        EventTypeDescription = c.String(),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.EventTypeId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.Event_EventId);
            
            AddColumn("dbo.Events", "EventType_EventTypeId", c => c.Int());
            CreateIndex("dbo.Events", "EventType_EventTypeId");
            AddForeignKey("dbo.Events", "EventType_EventTypeId", "dbo.EventTypes", "EventTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventType_EventTypeId", "dbo.EventTypes");
            DropForeignKey("dbo.EventTypes", "Event_EventId", "dbo.Events");
            DropIndex("dbo.EventTypes", new[] { "Event_EventId" });
            DropIndex("dbo.Events", new[] { "EventType_EventTypeId" });
            DropColumn("dbo.Events", "EventType_EventTypeId");
            DropTable("dbo.EventTypes");
        }
    }
}
