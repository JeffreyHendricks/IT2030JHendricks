namespace enrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Age");
        }
    }
}
