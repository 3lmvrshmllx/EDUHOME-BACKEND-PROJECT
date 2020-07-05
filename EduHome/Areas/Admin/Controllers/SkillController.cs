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
    public class SkillController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Skill> skills = db.Skills.ToList();
            return View(skills);

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
        public ActionResult Create(Skill skill)
        {

            if (ModelState.IsValid)
            {

                db.Skills.Add(skill);
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

            Skill skill = db.Skills.Find(id);

            if (skill == null)
            {
                return HttpNotFound();
            }

            return View(skill);
        }


        [HttpPost]
        public ActionResult Update(Skill skill)
        {

            if (ModelState.IsValid)
            {

                db.Entry(skill).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(skill);

        }

        public ActionResult Delete(int id)
        {
            Skill skill = db.Skills.Find(id);

            if (skill == null)
            {
                return HttpNotFound();
            }

            db.Skills.Remove(skill);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}