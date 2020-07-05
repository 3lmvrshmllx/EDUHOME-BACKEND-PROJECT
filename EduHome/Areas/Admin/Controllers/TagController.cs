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
    public class TagController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Tag> tags = db.Tags.ToList();
            return View(tags);

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
        public ActionResult Create(Tag tag)
        {

            if (ModelState.IsValid)
            {

                db.Tags.Add(tag);
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

            Tag tag = db.Tags.Find(id);

            if (tag == null)
            {
                return HttpNotFound();
            }

            return View(tag);
        }


        [HttpPost]
        public ActionResult Update(Tag tag)
        {

            if (ModelState.IsValid)
            {

                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(tag);

        }

        public ActionResult Delete(int id)
        {
            Tag tag= db.Tags.Find(id);

            if (tag == null)
            {
                return HttpNotFound();
            }

            db.Tags.Remove(tag);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}