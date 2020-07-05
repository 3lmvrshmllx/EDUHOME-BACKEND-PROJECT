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
    public class HomePageController : Controller
    {
        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Home> homes = db.Homes.ToList();
            return View(homes);

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
        public ActionResult Create(Home home)
        {

            if (ModelState.IsValid)
            {

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + home.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                home.ImageFile.SaveAs(imagePath);
                home.Image = imageName;

                db.Homes.Add(home);
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

            Home home = db.Homes.Find(id);

            if (home == null)
            {
                return HttpNotFound();
            }

            return View(home);
        }


        [HttpPost]
        public ActionResult Update(Home home)
        {

            if (ModelState.IsValid)
            {
                Home Home = db.Homes.Find(home.Id);


                if (home.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + home.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), Home.Image);
                    System.IO.File.Delete(OldimagePath);

                    home.ImageFile.SaveAs(imagePath);
                    Home.Image = imageName;

                }

                Home.Title = home.Title;
                Home.SubTitle = home.SubTitle;
                Home.CreatedDate = home.CreatedDate;

                db.Entry(Home).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(home);

        }

        public ActionResult Delete(int id)
        {
            Home home = db.Homes.Find(id);

            if (home == null)
            {
                return HttpNotFound();
            }

            db.Homes.Remove(home);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}