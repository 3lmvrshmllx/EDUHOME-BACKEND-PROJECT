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
    public class SocialTeamController : Controller
    {
        
        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<SocialTeam> socialTeams = db.SocialTeams.Include("Teacher").ToList();
            return View(socialTeams);
        }


        public ActionResult Create()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            ViewBag.Teachers = db.Teachers.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SocialTeam socialTeam)
        {
            if (ModelState.IsValid)
            {
                db.SocialTeams.Add(socialTeam);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Teachers = db.Teachers.ToList();
            return View(socialTeam);
        }

        public ActionResult Update(int id)
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            SocialTeam socialTeam = db.SocialTeams.Find(id);
            if (socialTeam == null)
            {
                return HttpNotFound();
            }

            ViewBag.Teachers = db.Teachers.ToList();
            return View(socialTeam);
        }

        [HttpPost]
        public ActionResult Update(SocialTeam socialTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialTeam).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Teachers = db.Teachers.ToList();
            return View(socialTeam);
        }

        public ActionResult Delete(int id)
        {
            SocialTeam socialTeam = db.SocialTeams.Find(id);
            if (socialTeam == null)
            {
                return HttpNotFound();
            }

            db.SocialTeams.Remove(socialTeam);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}