namespace enrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        courseID = c.Int(nullable: false, identity: true),
                        courseTitle = c.String(nullable: false, maxLength: 150),
                        courseDescription = c.String(),
                        courseCredits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.courseID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        enrollmentID = c.Int(nullable: false, identity: true),
                        studentID = c.Int(nullable: false),
                        courseID = c.Int(nullable: false),
                        grade = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        AssignedCampus = c.String(nullable: false),
                        EnrollmentSemester = c.String(nullable: false),
                        EnrollmentYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.enrollmentID)
                .ForeignKey("dbo.Courses", t => t.courseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.studentID, cascadeDelete: true)
                .Index(t => t.studentID)
                .Index(t => t.courseID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentID = c.Int(nullable: false, identity: true),
                        studentLastName = c.String(nullable: false, maxLength: 50),
                        studentFirstName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.studentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "studentID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "courseID", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "courseID" });
            DropIndex("dbo.Enrollments", new[] { "studentID" });
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
        }
    }
}
