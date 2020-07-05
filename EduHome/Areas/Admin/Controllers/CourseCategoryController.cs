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
    public class CourseCategoryController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<CourseCategory> courseCategories = db.CourseCategories.ToList();
            return View(courseCategories);

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
        public ActionResult Create(CourseCategory courseCategory)
        {

            if (ModelState.IsValid)
            {

                db.CourseCategories.Add(courseCategory);
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

            CourseCategory courseCategory = db.CourseCategories.Find(id);

            if (courseCategory == null)
            {
                return HttpNotFound();
            }

            return View(courseCategory);
        }


        [HttpPost]
        public ActionResult Update(CourseCategory courseCategory)
        {

            if (ModelState.IsValid)
            {

                db.Entry(courseCategory).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(courseCategory);

        }

        public ActionResult Delete(int id)
        {
            CourseCategory courseCategory = db.CourseCategories.Find(id);

            if (courseCategory == null)
            {
                return HttpNotFound();
            }

            db.CourseCategories.Remove(courseCategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}