namespace FinalEventApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "OrderId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderId", c => c.Int(nullable: false));
        }
    }
}
