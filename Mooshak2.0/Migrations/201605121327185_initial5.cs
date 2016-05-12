namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "TaughtCourse_ID", "dbo.Courses");
            DropIndex("dbo.AspNetUsers", new[] { "TaughtCourse_ID" });
            DropColumn("dbo.AspNetUsers", "TaughtCourse_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "TaughtCourse_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "TaughtCourse_ID");
            AddForeignKey("dbo.AspNetUsers", "TaughtCourse_ID", "dbo.Courses", "ID");
        }
    }
}
