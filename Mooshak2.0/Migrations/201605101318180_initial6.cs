namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserCourses", "Course_ID", "dbo.Courses");
            DropIndex("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserCourses", new[] { "Course_ID" });
            AddColumn("dbo.AssignmentProjects", "Deadline", c => c.String());
            AddColumn("dbo.AssignmentProjects", "CourseID", c => c.Int(nullable: false));
            AddColumn("dbo.AssignmentProjects", "Input", c => c.String());
            AddColumn("dbo.AssignmentProjects", "Output", c => c.String());
            AddColumn("dbo.AssignmentProjects", "Submitted", c => c.Boolean(nullable: false));
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
            
            DropColumn("dbo.AssignmentProjects", "Submitted");
            DropColumn("dbo.AssignmentProjects", "Output");
            DropColumn("dbo.AssignmentProjects", "Input");
            DropColumn("dbo.AssignmentProjects", "CourseID");
            DropColumn("dbo.AssignmentProjects", "Deadline");
            CreateIndex("dbo.ApplicationUserCourses", "Course_ID");
            CreateIndex("dbo.ApplicationUserCourses", "ApplicationUser_Id");
            AddForeignKey("dbo.ApplicationUserCourses", "Course_ID", "dbo.Courses", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
