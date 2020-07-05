using EduHome.ViewModels;
using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduHome.DAL;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            ViewBag.Page = "Home";

            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.Homes = db.Homes.ToList();
            models.About = db.Abouts.FirstOrDefault();
            models.Courses = db.Courses.Take(3).ToList();
            models.NoticeBoards = db.NoticeBoards.ToList();
            models.StudentFeedback = db.StudentFeedbacks.FirstOrDefault();
            models.Events = db.Events.Take(4).ToList();
            models.Blogs = db.Blogs.Include("Admin").Take(3).ToList();
            models.BlogComments = db.BlogComments.ToList();
            return View(models);
        }

 
        [HttpPost]
        public ActionResult Subscribe(ViewModelSubscribe viewModelsubscribe) 
        {

           if (string.IsNullOrEmpty(viewModelsubscribe.Email))
           {
               Session["EmptyMail"] = true;
               return RedirectToAction("Index");
           }

           if(db.Subscribes.Any(u => u.Email == viewModelsubscribe.Email))
           {
               Session["Subscriber"] = true;
               ModelState.AddModelError("Email", "You are a subscriber!");
               return RedirectToAction("Index");
         
           }

            Subscribe Subscribe = new Subscribe();
            Subscribe.Email = viewModelsubscribe.Email;
            Subscribe.AddedDate = DateTime.Now;

            db.Subscribes.Add(Subscribe);
            db.SaveChanges();

            Session["SuccessfullSub"] = true;

            return RedirectToAction("Index");

           
        }

       
    }
}