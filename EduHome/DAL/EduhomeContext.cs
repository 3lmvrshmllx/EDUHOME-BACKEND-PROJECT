using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EduHome.DAL
{
    public class EduhomeContext : DbContext
    {
        public EduhomeContext() : base("EduHomeConnection")
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BgImage> BgImages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactAdress> ContactAdresses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<CourseComment> CourseComments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventComment> EventComments { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<NoticeBoard> NoticeBoards {get;set;}
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<SocialTeam> SocialTeams { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<StudentFeedback> StudentFeedbacks { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherProfession> TeacherProfessions { get; set; }
        public DbSet<User> Users { get; set; }   

    }
}