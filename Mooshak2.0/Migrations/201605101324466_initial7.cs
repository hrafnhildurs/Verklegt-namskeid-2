namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignments", "Deadline", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AssignmentProjects", "Deadline", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssignmentProjects", "Deadline", c => c.String());
            AlterColumn("dbo.Assignments", "Deadline", c => c.String());
        }
    }
}
