namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Submissions", "AssignmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Submissions", "AssignmentID", c => c.Int(nullable: false));
        }
    }
}
