namespace EduHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "AboutTeacher", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "AboutTeacher", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
