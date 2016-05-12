namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentProjects", "AssignmentName", c => c.String());
            AddColumn("dbo.AssignmentProjects", "CourseName", c => c.String());
            AlterColumn("dbo.Submissions", "StudentID", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "TeacherId", c => c.String());
            AlterColumn("dbo.Submissions", "StudentID", c => c.String());
            DropColumn("dbo.AssignmentProjects", "CourseName");
            DropColumn("dbo.AssignmentProjects", "AssignmentName");
        }
    }
}
