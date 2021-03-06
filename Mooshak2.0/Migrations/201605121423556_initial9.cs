namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TeacherId", c => c.String());
            AddColumn("dbo.AssignmentProjects", "AssignmentName", c => c.String());
            AddColumn("dbo.AssignmentProjects", "CourseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignmentProjects", "CourseName");
            DropColumn("dbo.AssignmentProjects", "AssignmentName");
            DropColumn("dbo.Courses", "TeacherId");
        }
    }
}
