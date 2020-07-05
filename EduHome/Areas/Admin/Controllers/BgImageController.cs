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
    public class BgImageController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<BgImage> bgImages = db.BgImages.ToList();
            return View(bgImages);

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
        public ActionResult Create(BgImage bgImage)
        {

            if (ModelState.IsValid)
            {
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + bgImage.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                bgImage.ImageFile.SaveAs(imagePath);
                bgImage.Image = imageName;

                db.BgImages.Add(bgImage);
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


            BgImage bgImage = db.BgImages.Find(id);

            if (bgImage == null)
            {
                return HttpNotFound();
            }


            return View(bgImage);
        }

        [HttpPost]
        public ActionResult Update(BgImage bgImage)
        {

            if (ModelState.IsValid)
            {

                BgImage BgImage = db.BgImages.Find(bgImage.Id);

                if (bgImage.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + bgImage.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/img"), BgImage.Image);
                    System.IO.File.Delete(OldImagePath);

                    bgImage.ImageFile.SaveAs(imagePath);
                    BgImage.Image = imageName;
                }

                BgImage.CreatedDate = bgImage.CreatedDate;

                db.Entry(BgImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bgImage);
        }

        public ActionResult Delete(int id)
        {
            BgImage bgimage = db.BgImages.Find(id);

            if (bgimage == null)
            {
                return HttpNotFound();
            }

            db.BgImages.Remove(bgimage);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}