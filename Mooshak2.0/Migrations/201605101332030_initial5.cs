namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "SubmissionOutput", c => c.String());
            AlterColumn("dbo.Submissions", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.AssignmentProjects", "Submitted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignmentProjects", "Submitted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Submissions", "Date", c => c.String());
            DropColumn("dbo.Submissions", "SubmissionOutput");
        }
    }
}
