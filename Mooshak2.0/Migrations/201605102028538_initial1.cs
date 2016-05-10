namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Assignments", "CourseID");
            AddForeignKey("dbo.Assignments", "CourseID", "dbo.Courses", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Assignments", new[] { "CourseID" });
        }
    }
}
