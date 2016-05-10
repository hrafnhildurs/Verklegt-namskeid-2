namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserCourses",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Course_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Course_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_ID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Course_ID);
            
            DropColumn("dbo.AssignmentProjects", "Deadline");
            DropColumn("dbo.AssignmentProjects", "CourseID");
            DropColumn("dbo.AssignmentProjects", "Input");
            DropColumn("dbo.AssignmentProjects", "Output");
            DropColumn("dbo.AssignmentProjects", "Submitted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignmentProjects", "Submitted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AssignmentProjects", "Output", c => c.String());
            AddColumn("dbo.AssignmentProjects", "Input", c => c.String());
            AddColumn("dbo.AssignmentProjects", "CourseID", c => c.Int(nullable: false));
            AddColumn("dbo.AssignmentProjects", "Deadline", c => c.String());
            DropForeignKey("dbo.ApplicationUserCourses", "Course_ID", "dbo.Courses");
            DropForeignKey("dbo.ApplicationUserCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCourses", new[] { "Course_ID" });
            DropIndex("dbo.ApplicationUserCourses", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserCourses");
        }
    }
}
