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
    public class BlogCategoryController : Controller
    {
        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<BlogCategory> blogCategories = db.BlogCategories.ToList();
            return View(blogCategories);

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
        public ActionResult Create(BlogCategory blogCategory)
        {

            if (ModelState.IsValid)
            {

                db.BlogCategories.Add(blogCategory);
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

            BlogCategory blogCategory = db.BlogCategories.Find(id);

            if (blogCategory == null)
            {
                return HttpNotFound();
            }

            return View(blogCategory);
        }


        [HttpPost]
        public ActionResult Update(BlogCategory blogCategory)
        {

            if (ModelState.IsValid)
            {
           
                db.Entry(blogCategory).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(blogCategory);

        }

        public ActionResult Delete(int id)
        {
            BlogCategory blogCategory = db.BlogCategories.Find(id);

            if (blogCategory == null)
            {
                return HttpNotFound();
            }

            db.BlogCategories.Remove(blogCategory);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}