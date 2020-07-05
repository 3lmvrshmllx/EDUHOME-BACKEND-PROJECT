using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Controllers
{
    public class CoursesController : Controller
    {
        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {
            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.Courses = db.Courses.ToList();
            models.BgImage = db.BgImages.FirstOrDefault();
            return View(models);
        }


        public ActionResult CourseDetails(int id)
        {
            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.Course = db.Courses.Find(id);
            models.Courses = db.Courses.ToList();
            models.CourseCategories = db.CourseCategories.ToList();
            models.CourseComments = db.CourseComments.ToList();
            models.BgImage = db.BgImages.FirstOrDefault();
            models.Blogs = db.Blogs.Include("Admin").OrderByDescending(o=>o.Id).Take(3).ToList();
            models.Tags = db.Tags.ToList();
            return View(models);
        }


     
        [HttpPost]
        public ActionResult Message(ViewModelCourseComment vmcm,int id)
        {

            if (Session["LoginnerId"] == null) 
            {
                return RedirectToAction("Index","Login");
            }

            CourseComment CourseComment = new CourseComment();
            CourseComment.UserId = (int)Session["LoginnerId"];
            CourseComment.CourseId = id;
            CourseComment.Comment = vmcm.Message;           
            CourseComment.AddedDate = DateTime.Now;

            db.CourseComments.Add(CourseComment);
            db.SaveChanges();

            Session["SuccessfullComment"] = true;
            return RedirectToAction("Index");
        }




    }
}