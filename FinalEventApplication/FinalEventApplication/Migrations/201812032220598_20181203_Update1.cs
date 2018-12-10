namespace FinalEventApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20181203_Update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "AvailableTickets", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Events", "EventDescription", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Events", "EventType", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "OrganizerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "OrganizerName", c => c.String());
            AlterColumn("dbo.Events", "Location", c => c.String());
            AlterColumn("dbo.Events", "EventType", c => c.String());
            AlterColumn("dbo.Events", "EventDescription", c => c.String());
            AlterColumn("dbo.Events", "Title", c => c.String());
            DropColumn("dbo.Events", "AvailableTickets");
        }
    }
}
