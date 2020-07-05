using EduHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.ViewModels
{



    public class ViewModelEduhome
    {
        
        public ViewModelBlogCategory ViewModelBlogCategory {get;set;}
        public ViewModelBlog ViewModelBlog { get; set; }
        public UserLogin UserLogin { get; set; }
        public UserRegister UserRegister { get; set; }
        public About About { get; set; }
        public List<About> Abouts { get; set; }
        public BgImage BgImage { get; set; }
        public List<BgImage> BgImages { get; set; }
        public Blog Blog { get; set; }
        public List<Blog> Blogs { get; set; }
        public BlogCategory BlogCategory { get; set; }
        public List<BlogCategory> BlogCategories { get; set; }
        public BlogComment BlogComment { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public List<ContactAdress> ContactAdresses { get; set; }
        public Course Course { get; set; }
        public List<Course> Courses { get; set; }
        public CourseCategory CourseCategory { get; set; }
        public List<CourseCategory> CourseCategories { get; set; }
        public List<CourseComment> CourseComments { get; set; }
        public Event Event { get; set; }
        public List<Event> Events { get; set; }
        public EventCategory EventCategory { get; set; }
        public List<EventCategory> EventCategories { get; set; }
        public Home Home { get; set; }
        public List<Home> Homes { get; set; }
        public NoticeBoard NoticeBoard { get; set; }
        public List<NoticeBoard> NoticeBoards { get; set; }
        public Setting Setting { get; set; }
        public Skill Skill { get; set; }
        public List<Skill> Skills { get; set; }
        public List<SocialLink> SocialLinks { get; set; }
        public SocialTeam SocialTeam { get; set; }
        public List<SocialTeam> SocialTeams { get; set; }
        public Speaker Speaker { get; set; }
        public List<Speaker> Speakers { get; set; }
        public StudentFeedback StudentFeedback { get; set; }
        public List<StudentFeedback> StudentFeedbacks { get; set; }
        public Tag Tag { get; set; }
        public List<Tag> Tags{ get; set; }
        public Teacher Teacher { get; set; }
        public List<Teacher> Teachers { get; set; }
        public TeacherProfession TeacherProfession { get; set; }
        public List<TeacherProfession> TeacherProfessions { get; set; }

    }
}