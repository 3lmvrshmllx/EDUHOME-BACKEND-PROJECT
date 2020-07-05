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
    public class StudentFeedbackController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<StudentFeedback> studentFeedbacks = db.StudentFeedbacks.ToList();
            return View(studentFeedbacks);

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
        public ActionResult Create(StudentFeedback studentFeedback)
        {

            if (ModelState.IsValid)
            {

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + studentFeedback.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                studentFeedback.ImageFile.SaveAs(imagePath);
                studentFeedback.Image = imageName;

                db.StudentFeedbacks.Add(studentFeedback);
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

            StudentFeedback studentFeedback = db.StudentFeedbacks.Find(id);

            if (studentFeedback == null)
            {
                return HttpNotFound();
            }

            return View(studentFeedback);
        }


        [HttpPost]
        public ActionResult Update(StudentFeedback studentFeedback)
        {

            if (ModelState.IsValid)
            {
                StudentFeedback StudentFeedback = db.StudentFeedbacks.Find(studentFeedback.Id);


                if (studentFeedback.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + studentFeedback.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), StudentFeedback.Image);
                    System.IO.File.Delete(OldimagePath);

                    studentFeedback.ImageFile.SaveAs(imagePath);
                    StudentFeedback.Image = imageName;

                }

                StudentFeedback.FullName = studentFeedback.FullName;
                StudentFeedback.Category =studentFeedback.Category;
                StudentFeedback.Content = studentFeedback.Content;
                StudentFeedback.CreatedDate = studentFeedback.CreatedDate;

                db.Entry(StudentFeedback).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(studentFeedback);

        }

        public ActionResult Delete(int id)
        {
            StudentFeedback studentFeedback = db.StudentFeedbacks.Find(id);

            if (studentFeedback == null)
            {
                return HttpNotFound();
            }

            db.StudentFeedbacks.Remove(studentFeedback);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}