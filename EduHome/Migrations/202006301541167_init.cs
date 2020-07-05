namespace EduHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        Title = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BgImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 150),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        BlogCategoryId = c.Int(nullable: false),
                        AdminId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId, cascadeDelete: true)
                .Index(t => t.BlogCategoryId)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false, maxLength: 500),
                        BlogId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BlogId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactAdresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        Country = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(nullable: false, maxLength: 50),
                        Message = c.String(nullable: false, maxLength: 500),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Image = c.String(maxLength: 150),
                        Content = c.String(nullable: false, maxLength: 500),
                        AboutCourse = c.String(nullable: false, maxLength: 500),
                        HowToApply = c.String(nullable: false, maxLength: 500),
                        Certification = c.String(nullable: false, maxLength: 500),
                        Starts = c.String(nullable: false, maxLength: 30),
                        Duration = c.String(nullable: false, maxLength: 20),
                        ClassDuration = c.String(nullable: false, maxLength: 20),
                        SkillLevel = c.String(nullable: false, maxLength: 20),
                        Language = c.String(nullable: false, maxLength: 20),
                        StudentsCount = c.Int(nullable: false),
                        Assessments = c.String(nullable: false, maxLength: 20),
                        CourseFee = c.Int(nullable: false),
                        CourseCategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseCategories", t => t.CourseCategoryId, cascadeDelete: true)
                .Index(t => t.CourseCategoryId);
            
            CreateTable(
                "dbo.CourseComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CourseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.EventCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 150),
                        Venue = c.String(nullable: false, maxLength: 50),
                        Time = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        SpeakerId = c.Int(nullable: false),
                        EventCategoryId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventCategories", t => t.EventCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Speakers", t => t.SpeakerId, cascadeDelete: true)
                .Index(t => t.SpeakerId)
                .Index(t => t.EventCategoryId);
            
            CreateTable(
                "dbo.EventComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false, maxLength: 500),
                        UserId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Profession = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Homes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        Title = c.String(nullable: false, maxLength: 50),
                        SubTitle = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NoticeBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(maxLength: 150),
                        LogoMiniRed = c.String(maxLength: 150),
                        LogoMiniWhite = c.String(maxLength: 150),
                        Adress = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        NavbarPhone = c.String(nullable: false, maxLength: 50),
                        SiteName = c.String(nullable: false, maxLength: 50),
                        Copyright = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Percent = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 150),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Icon = c.String(nullable: false, maxLength: 50),
                        Link = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 20),
                        TeacherId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 150),
                        TeacherProfessionId = c.Int(nullable: false),
                        AboutTeacher = c.String(nullable: false, maxLength: 150),
                        Degree = c.String(nullable: false, maxLength: 50),
                        Experience = c.String(nullable: false, maxLength: 50),
                        Hobbies = c.String(nullable: false, maxLength: 50),
                        Faculty = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Skype = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeacherProfessions", t => t.TeacherProfessionId, cascadeDelete: true)
                .Index(t => t.TeacherProfessionId);
            
            CreateTable(
                "dbo.TeacherProfessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 150),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Category = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "TeacherProfessionId", "dbo.TeacherProfessions");
            DropForeignKey("dbo.SocialTeams", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Events", "SpeakerId", "dbo.Speakers");
            DropForeignKey("dbo.EventComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.EventComments", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "EventCategoryId", "dbo.EventCategories");
            DropForeignKey("dbo.CourseComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.CourseComments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CourseCategoryId", "dbo.CourseCategories");
            DropForeignKey("dbo.BlogComments", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogComments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories");
            DropForeignKey("dbo.Blogs", "AdminId", "dbo.Admins");
            DropIndex("dbo.Teachers", new[] { "TeacherProfessionId" });
            DropIndex("dbo.SocialTeams", new[] { "TeacherId" });
            DropIndex("dbo.EventComments", new[] { "EventId" });
            DropIndex("dbo.EventComments", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "EventCategoryId" });
            DropIndex("dbo.Events", new[] { "SpeakerId" });
            DropIndex("dbo.CourseComments", new[] { "UserId" });
            DropIndex("dbo.CourseComments", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "CourseCategoryId" });
            DropIndex("dbo.BlogComments", new[] { "UserId" });
            DropIndex("dbo.BlogComments", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "AdminId" });
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId" });
            DropTable("dbo.Tags");
            DropTable("dbo.Subscribes");
            DropTable("dbo.StudentFeedbacks");
            DropTable("dbo.TeacherProfessions");
            DropTable("dbo.Teachers");
            DropTable("dbo.SocialTeams");
            DropTable("dbo.SocialLinks");
            DropTable("dbo.Skills");
            DropTable("dbo.Settings");
            DropTable("dbo.NoticeBoards");
            DropTable("dbo.Homes");
            DropTable("dbo.Speakers");
            DropTable("dbo.EventComments");
            DropTable("dbo.Events");
            DropTable("dbo.EventCategories");
            DropTable("dbo.CourseComments");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseCategories");
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactAdresses");
            DropTable("dbo.Users");
            DropTable("dbo.BlogComments");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.BgImages");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
