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
    public class TeacherController : Controller
    {
        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Teacher> teachers = db.Teachers.Include("TeacherProfession").ToList();
            return View(teachers);
        }

        public ActionResult Create()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            ViewBag.Professions = db.TeacherProfessions.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {

            if (ModelState.IsValid)
            {
                Teacher Teacher = new Teacher();

                if (teacher.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    ViewBag.Professions = db.TeacherProfessions.ToList();
                    return View(teacher);

                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    teacher.ImageFile.SaveAs(imagePath);
                    Teacher.Image = imageName;
                }


                Teacher.Name = teacher.Name;
                Teacher.TeacherProfessionId = teacher.TeacherProfessionId;
                Teacher.AboutTeacher = teacher.AboutTeacher;
                Teacher.Degree = teacher.Degree;
                Teacher.Experience = teacher.Experience;
                Teacher.Hobbies = teacher.Hobbies;
                Teacher.Faculty = teacher.Faculty;
                Teacher.Email = teacher.Email;
                Teacher.PhoneNumber = teacher.PhoneNumber;
                Teacher.Skype = teacher.Skype;
                Teacher.CreatedDate = teacher.CreatedDate;


                db.Teachers.Add(Teacher);
                db.SaveChanges();

                return RedirectToAction("Index");

            }

            ViewBag.Professions = db.TeacherProfessions.ToList();
            return View(teacher);

        }


        public ActionResult Update(int id)
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            Teacher teacher = db.Teachers.Find(id);

            if (teacher== null)
            {
                return HttpNotFound();
            }

            ViewBag.Professions = db.TeacherProfessions.ToList();
            return View(teacher);

        }

        [HttpPost]
        public ActionResult Update(Teacher teacher)
        {
            if (ModelState.IsValid)
            {

                Teacher Teacher = db.Teachers.Find(teacher.Id);

                if (teacher.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), Teacher.Image);

                    teacher.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(OldimagePath);

                    Teacher.Image = imageName;

                }


                Teacher.Name = teacher.Name;
                Teacher.TeacherProfessionId = teacher.TeacherProfessionId;
                Teacher.AboutTeacher = teacher.AboutTeacher;
                Teacher.Degree = teacher.Degree;
                Teacher.Experience = teacher.Experience;
                Teacher.Hobbies = teacher.Hobbies;
                Teacher.Faculty = teacher.Faculty;
                Teacher.Email = teacher.Email;
                Teacher.PhoneNumber = teacher.PhoneNumber;
                Teacher.Skype = teacher.Skype;
                Teacher.CreatedDate = teacher.CreatedDate;

                db.Entry(Teacher).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("index");

            }
            ViewBag.Professions = db.TeacherProfessions.ToList();
            return View(teacher);

        }


        public ActionResult Delete(int id)
        {

            Teacher teacher = db.Teachers.Find(id);

            if (teacher == null)
            {
                return HttpNotFound();
            }

            db.Teachers.Remove(teacher);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}