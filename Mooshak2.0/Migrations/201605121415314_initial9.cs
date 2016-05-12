namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AssignmentProjects", "AssignmentName");
            DropColumn("dbo.AssignmentProjects", "CourseName");
            AlterColumn("dbo.Submissions", "StudentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignmentProjects", "CourseName", c => c.String());
            AddColumn("dbo.AssignmentProjects", "AssignmentName", c => c.String());
            AlterColumn("dbo.Submissions", "StudentID", c => c.String());
        }
    }
}
