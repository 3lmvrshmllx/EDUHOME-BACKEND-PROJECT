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
    public class SpeakerController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Speaker> speakers = db.Speakers.ToList();
            return View(speakers);

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
        public ActionResult Create(Speaker speaker)
        {

            if (ModelState.IsValid)
            {

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + speaker.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                speaker.ImageFile.SaveAs(imagePath);
                speaker.Image = imageName;

                db.Speakers.Add(speaker);
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

            Speaker speaker = db.Speakers.Find(id);

            if (speaker == null)
            {
                return HttpNotFound();
            }

            return View(speaker);
        }


        [HttpPost]
        public ActionResult Update(Speaker speaker)
        {

            if (ModelState.IsValid)
            {
                Speaker Speaker = db.Speakers.Find(speaker.Id);


                if (speaker.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + speaker.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), Speaker.Image);
                    System.IO.File.Delete(OldimagePath);

                    speaker.ImageFile.SaveAs(imagePath);
                    Speaker.Image = imageName;

                }

                Speaker.Name = speaker.Name;
                Speaker.Profession = speaker.Profession;
                Speaker.CreatedDate = speaker.CreatedDate;

                db.Entry(Speaker).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(speaker);

        }

        public ActionResult Delete(int id)
        {
            Speaker speaker = db.Speakers.Find(id);

            if (speaker == null)
            {
                return HttpNotFound();
            }

            db.Speakers.Remove(speaker);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}