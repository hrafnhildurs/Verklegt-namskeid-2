namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial18 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Submissions", "ExpectedSubmissionOutput");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "ExpectedSubmissionOutput", c => c.String());
        }
    }
}
