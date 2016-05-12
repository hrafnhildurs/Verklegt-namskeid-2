namespace Mooshak2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TeacherId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "TeacherId");
        }
    }
}
