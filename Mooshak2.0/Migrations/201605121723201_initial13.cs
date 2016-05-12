namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Submissions", "StudentID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Submissions", "StudentID", c => c.Int(nullable: false));
        }
    }
}
