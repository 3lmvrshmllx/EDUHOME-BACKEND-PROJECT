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
    public class TeacherProfessionController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<TeacherProfession> teacherProfessions = db.TeacherProfessions.ToList();
            return View(teacherProfessions);

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
        public ActionResult Create(TeacherProfession teacherProfession)
        {

            if (ModelState.IsValid)
            {

                db.TeacherProfessions.Add(teacherProfession);
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

            TeacherProfession teacherProfession = db.TeacherProfessions.Find(id);

            if (teacherProfession == null)
            {
                return HttpNotFound();
            }

            return View(teacherProfession);
        }


        [HttpPost]
        public ActionResult Update(TeacherProfession teacherProfession)
        {

            if (ModelState.IsValid)
            {

                db.Entry(teacherProfession).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(teacherProfession);

        }

        public ActionResult Delete(int id)
        {
            TeacherProfession teacherProfession = db.TeacherProfessions.Find(id);

            if (teacherProfession == null)
            {
                return HttpNotFound();
            }

            db.TeacherProfessions.Remove(teacherProfession);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}