namespace FinalEventApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EvenArtUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventArtUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventArtUrl");
        }
    }
}
