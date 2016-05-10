namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentProjects", "Deadline", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignmentProjects", "Deadline");
        }
    }
}
