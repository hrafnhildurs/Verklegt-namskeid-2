namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Submissions", "Input", c => c.String());
            AlterColumn("dbo.Submissions", "Result", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "Result", c => c.Boolean(nullable: false));
            DropColumn("dbo.Submissions", "Input");
        }
    }
}
