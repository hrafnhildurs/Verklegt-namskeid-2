namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initia5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserCourses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserCourses", new[] { "Course_ID" });
            AddColumn("dbo.Courses", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Courses", "Teacher_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "TaughtCourse_ID", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Course_ID", c => c.Int());
            CreateIndex("dbo.Courses", "ApplicationUser_Id");
            CreateIndex("dbo.Courses", "Teacher_Id");
            CreateIndex("dbo.AspNetUsers", "TaughtCourse_ID");
            CreateIndex("dbo.AspNetUsers", "Course_ID");
            AddForeignKey("dbo.Courses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "TaughtCourse_ID", "dbo.Courses", "ID");
            AddForeignKey("dbo.AspNetUsers", "Course_ID", "dbo.Courses", "ID");
            AddForeignKey("dbo.Courses", "Teacher_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AssignmentProjects", "AssignmentName");
            DropColumn("dbo.AssignmentProjects", "CourseName");
            DropTable("dbo.ApplicationUserCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserCourses",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Course_ID });
            
            AddColumn("dbo.AssignmentProjects", "CourseName", c => c.String());
            AddColumn("dbo.AssignmentProjects", "AssignmentName", c => c.String());
            DropForeignKey("dbo.Courses", "Teacher_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.AspNetUsers", "TaughtCourse_ID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Course_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "TaughtCourse_ID" });
            DropIndex("dbo.Courses", new[] { "Teacher_Id" });
            DropIndex("dbo.Courses", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Course_ID");
            DropColumn("dbo.AspNetUsers", "TaughtCourse_ID");
            DropColumn("dbo.Courses", "Teacher_Id");
            DropColumn("dbo.Courses", "ApplicationUser_Id");
            CreateIndex("dbo.ApplicationUserCourses", "Course_ID");
            CreateIndex("dbo.ApplicationUserCourses", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserCourses", "Course_ID", "dbo.Courses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
