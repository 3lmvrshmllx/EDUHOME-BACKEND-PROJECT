using EduHome.DAL;
using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    public class EventController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Event> events = db.Events.Include("EventCategory").Include("Speaker").ToList();
            return View(events);
        }

        public ActionResult Create()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            ViewBag.Categories = db.EventCategories.ToList();
            ViewBag.Speakers = db.Speakers.ToList();

            return View();
        }


        [HttpPost]
        public ActionResult Create(Event evnt)
        {

            if (ModelState.IsValid)
            {
                Event Event = new Event();

                if (evnt.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    ViewBag.Categories = db.EventCategories.ToList();
                    ViewBag.Speakers = db.Speakers.ToList();

                    return View(evnt);

                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + evnt.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    evnt.ImageFile.SaveAs(imagePath);
                    Event.Image = imageName;
                }


                Event.Title = evnt.Title;
                Event.Time = evnt.Time;
                Event.Venue = evnt.Venue;
                Event.Content = evnt.Content;
                Event.EventCategoryId = evnt.EventCategoryId;
                Event.SpeakerId = evnt.SpeakerId;
                Event.CreatedDate = evnt.CreatedDate;


                db.Events.Add(Event);
                db.SaveChanges();

                return RedirectToAction("Index");

            }

            ViewBag.Categories = db.CourseCategories.ToList();
            ViewBag.Speakers = db.Speakers.ToList();

            return View(evnt);

        }


        public ActionResult Update(int id)
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            Event evnt = db.Events.Find(id);

            if (evnt == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = db.EventCategories.ToList();
            ViewBag.Speakers = db.Speakers.ToList();

            return View(evnt);

        }

        [HttpPost]
        public ActionResult Update(Event evnt)
        {
            if (ModelState.IsValid)
            {

                Event Event = db.Events.Find(evnt.Id);

                if (evnt.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + evnt.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), Event.Image);

                    evnt.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(OldimagePath);

                    Event.Image = imageName;

                }


                Event.Title = evnt.Title;
                Event.Time = evnt.Time;
                Event.Venue = evnt.Venue;
                Event.Content = evnt.Content;
                Event.EventCategoryId = evnt.EventCategoryId;
                Event.SpeakerId = evnt.SpeakerId;
                Event.CreatedDate = evnt.CreatedDate;

                db.Entry(Event).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("index");

            }
            ViewBag.Categories = db.EventCategories.ToList();
            ViewBag.Speakers = db.Speakers.ToList();

            return View(evnt);

        }


        public ActionResult Delete(int id)
        {

            Event evnt = db.Events.Find(id);

            if (evnt == null)
            { 
              return HttpNotFound();
            }

             db.Events.Remove(evnt);
             db.SaveChanges();

             return RedirectToAction("Index");

        }


    }
}