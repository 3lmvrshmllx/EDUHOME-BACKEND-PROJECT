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
    public class CourseController : Controller
    {

        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Course> courses = db.Courses.Include("CourseCategory").ToList();
            return View(courses);
        }

        public ActionResult Create()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            ViewBag.Categories = db.CourseCategories.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(Course course)
        {

            if (ModelState.IsValid)
            {
               Course Course = new Course();

                if (course.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    ViewBag.Categories = db.CourseCategories.ToList();
                    return View(course);

                }
                else
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    course.ImageFile.SaveAs(imagePath);
                    Course.Image = imageName;
                }


                Course.Title = course.Title;
                Course.Content = course.Content;
                Course.AboutCourse = course.AboutCourse;
                Course.HowToApply = course.HowToApply;
                Course.Certification = course.Certification;
                Course.Starts = course.Starts;
                Course.Duration = course.Duration;
                Course.ClassDuration = course.ClassDuration;
                Course.SkillLevel = course.SkillLevel;
                Course.Language = course.Language;
                Course.StudentsCount = course.StudentsCount;
                Course.Assessments = course.Assessments;
                Course.CourseFee = course.CourseFee;
                Course.CourseCategoryId = course.CourseCategoryId;
                Course.CreatedDate = course.CreatedDate;
           

                db.Courses.Add(Course);
                db.SaveChanges();

                return RedirectToAction("Index");

            }

            ViewBag.Categories = db.CourseCategories.ToList();
            return View(course);

        }


        public ActionResult Update(int id)
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            Course course = db.Courses.Find(id);

            if (course == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = db.CourseCategories.ToList();
            return View(course);

        }

        [HttpPost]
        public ActionResult Update(Course course)
        {
            if (ModelState.IsValid)
            {

                Course Course = db.Courses.Find(course.Id);

                if (course.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), Course.Image);

                    course.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(OldimagePath);

                    Course.Image = imageName;

                }

                Course.Title = course.Title;
                Course.Content = course.Content;
                Course.AboutCourse = course.AboutCourse;
                Course.HowToApply = course.HowToApply;
                Course.Certification = course.Certification;
                Course.Starts = course.Starts;
                Course.Duration = course.Duration;
                Course.ClassDuration = course.ClassDuration;
                Course.SkillLevel = course.SkillLevel;
                Course.Language = course.Language;
                Course.StudentsCount = course.StudentsCount;
                Course.Assessments = course.Assessments;
                Course.CourseCategoryId = course.CourseCategoryId;
                Course.CourseFee = course.CourseFee;
                Course.CreatedDate = course.CreatedDate;

                db.Entry(Course).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("index");

            }
            ViewBag.Categories = db.CourseCategories.ToList();
            return View(course);

        }


        public ActionResult Delete(int id)
        {

            Course course = db.Courses.Find(id);

            if (course == null)
            {
                return HttpNotFound();
            }

            db.Courses.Remove(course);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}