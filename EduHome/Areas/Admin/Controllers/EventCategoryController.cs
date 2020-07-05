using EduHome.DAL;
using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    public class EventCategoryController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<EventCategory> eventCategories  = db.EventCategories.ToList();
            return View(eventCategories);

        }



        public ActionResult Create()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            return View();
        }


        [HttpPost]
        public ActionResult Create(EventCategory eventCategory)
        {

            if (ModelState.IsValid)
            {

                db.EventCategories.Add(eventCategory);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }

        public ActionResult Update(int id)
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            EventCategory eventCategory = db.EventCategories.Find(id);

            if (eventCategory == null)
            {
                return HttpNotFound();
            }

            return View(eventCategory);
        }


        [HttpPost]
        public ActionResult Update(EventCategory eventCategory)
        {

            if (ModelState.IsValid)
            {

                db.Entry(eventCategory).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(eventCategory);

        }

        public ActionResult Delete(int id)
        {
            EventCategory eventCategory = db.EventCategories.Find(id);

            if (eventCategory == null)
            {
                return HttpNotFound();
            }

            db.EventCategories.Remove(eventCategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}