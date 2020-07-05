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
    public class AboutController : Controller
    {
        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<About> abouts = db.Abouts.ToList();
            return View(abouts);

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
        public ActionResult Create(About about)
        {

            if (ModelState.IsValid)
            {

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + about.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                about.ImageFile.SaveAs(imagePath);
                about.Image = imageName;

                db.Abouts.Add(about);
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

            About about = db.Abouts.Find(id);

            if (about == null)
            {
                return HttpNotFound();
            }

            return View(about);
        }


        [HttpPost]
        public ActionResult Update(About about)
        {

            if (ModelState.IsValid)
            {
                About About = db.Abouts.Find(about.Id);
            
             
                if (about.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + about.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), About.Image);
                    System.IO.File.Delete(OldimagePath);

                    about.ImageFile.SaveAs(imagePath);
                    About.Image = imageName;

                }

                About.Title = about.Title;
                About.Content = about.Content;
                About.CreatedDate = about.CreatedDate;

                db.Entry(About).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(about);

        }

        public ActionResult Delete(int id) 
        {
            About about = db.Abouts.Find(id);

            if (about == null) 
            {
                return HttpNotFound();
            }

            db.Abouts.Remove(about);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}