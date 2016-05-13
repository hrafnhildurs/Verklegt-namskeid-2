namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "ExpectedSubmissionOutput", c => c.String());
            DropColumn("dbo.Submissions", "SubmissionOutput");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "SubmissionOutput", c => c.String());
            DropColumn("dbo.Submissions", "ExpectedSubmissionOutput");
        }
    }
}
