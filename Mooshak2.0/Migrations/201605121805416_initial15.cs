namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentProjects", "AssignmentName", c => c.String());
            AddColumn("dbo.AssignmentProjects", "CourseName", c => c.String());
            AlterColumn("dbo.Submissions", "StudentID", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "StudentID", c => c.String());
            DropColumn("dbo.AssignmentProjects", "CourseName");
            DropColumn("dbo.AssignmentProjects", "AssignmentName");
        }
    }
}
