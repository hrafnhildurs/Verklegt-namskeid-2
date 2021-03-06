namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TeacherId", c => c.String());
            AddColumn("dbo.Submissions", "AssignmentID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "TeacherId");
            DropColumn("dbo.Submissions", "AssignmentID");
        }
    }
}
