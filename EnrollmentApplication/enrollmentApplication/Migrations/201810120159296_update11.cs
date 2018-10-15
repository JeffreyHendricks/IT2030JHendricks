namespace enrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "courseCredits", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "courseCredits", c => c.Int(nullable: false));
        }
    }
}
