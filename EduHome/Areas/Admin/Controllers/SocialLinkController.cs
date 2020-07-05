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
    public class SocialLinkController : Controller
    {
        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            List<SocialLink> sociallinks = db.SocialLinks.ToList();
            return View(sociallinks);
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
        public ActionResult Create(SocialLink sociallink)
        {

            if (ModelState.IsValid)
            {
                db.SocialLinks.Add(sociallink);
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

            SocialLink sociallink = db.SocialLinks.Find(id);
            return View(sociallink);
        }

        [HttpPost]
        public ActionResult Update(SocialLink sociallink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sociallink).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View();
        }


        public ActionResult Delete(int id)
        {

            SocialLink sociallink = db.SocialLinks.Find(id);

            if (sociallink != null)
            {
                db.SocialLinks.Remove(sociallink);
                db.SaveChanges();

            }

            return RedirectToAction("Index");
        }
    }
}