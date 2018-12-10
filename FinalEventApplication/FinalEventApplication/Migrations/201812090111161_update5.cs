namespace FinalEventApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventTypeTitle", c => c.String(nullable: false));
            DropColumn("dbo.Events", "EventType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventType", c => c.String(nullable: false));
            DropColumn("dbo.Events", "EventTypeTitle");
        }
    }
}
