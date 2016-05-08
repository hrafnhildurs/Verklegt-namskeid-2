namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseNumber");
        }
    }
}
