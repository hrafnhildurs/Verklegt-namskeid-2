namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseName", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Semester", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Semester", c => c.String());
            AlterColumn("dbo.Courses", "CourseName", c => c.String());
            AlterColumn("dbo.Courses", "CourseNumber", c => c.String());
        }
    }
}
