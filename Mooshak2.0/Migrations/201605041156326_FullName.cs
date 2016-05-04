namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        StudentID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                        SubmittedCode = c.String(),
                        Result = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
            DropTable("dbo.Submissions");
        }
    }
}
