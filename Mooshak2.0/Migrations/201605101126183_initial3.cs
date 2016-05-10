namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentProjects", "CourseID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignmentProjects", "CourseID");
        }
    }
}
