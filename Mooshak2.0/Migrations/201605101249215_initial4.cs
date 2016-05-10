namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentProjects", "Input", c => c.String());
            AddColumn("dbo.AssignmentProjects", "Output", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignmentProjects", "Output");
            DropColumn("dbo.AssignmentProjects", "Input");
        }
    }
}
