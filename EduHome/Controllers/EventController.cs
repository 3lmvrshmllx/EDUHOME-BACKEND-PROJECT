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
    public class EventController : Controller
    {

        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {
            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();           
            models.BgImage = db.BgImages.FirstOrDefault();
            models.Events = db.Events.Include("EventCategory").ToList();
            models.EventCategories = db.EventCategories.ToList();
            models.Blogs = db.Blogs.Include("Admin").Include("BlogCategory").OrderByDescending(o => o.Id).Take(3).ToList();
            models.Tags = db.Tags.ToList();
            return View(models);
            
        }


        public ActionResult EventDetails(int id) 
        {

            ViewModelEduhome models = new ViewModelEduhome();

            models.Event = db.Events.Find(id);
            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.BgImage = db.BgImages.FirstOrDefault();
            models.Events = db.Events.Include("Speaker").Include("EventCategory").ToList();
            models.EventCategories = db.EventCategories.ToList();
            models.Blogs = db.Blogs.Include("Admin").OrderByDescending(o => o.Id).Take(3).ToList();
            models.Tags = db.Tags.ToList();
      
            return View(models);



        }


        [HttpPost]
        public ActionResult Message(ViewModelEventComment vmec, int id)
        {

            if (Session["LoginnerId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            EventComment EventComment = new EventComment();
            EventComment.Comment = vmec.Message;
            EventComment.UserId = (int)Session["LoginnerId"];
            EventComment.EventId = id;
            EventComment.CreatedDate = DateTime.Now;


            db.EventComments.Add(EventComment);
            db.SaveChanges();

            Session["SuccessfullEventComment"] = true;
            return RedirectToAction("Index");
        }

    }
}