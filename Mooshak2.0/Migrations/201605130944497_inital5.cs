namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "ExpectedSubmissionOutput", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Submissions", "ExpectedSubmissionOutput");
        }
    }
}
