using EduHome.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Models.Admin> admins = db.Admins.ToList();
            return View(admins);
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
        public ActionResult Create(Models.Admin admin) 
        {
            if (ModelState.IsValid) 
            {
                Models.Admin Admin = new Models.Admin();

                if (admin.Password != null) 
                {
                    Admin.Password = Crypto.HashPassword(admin.Password);
                }

                Admin.Name = admin.Name;
                Admin.Surname = admin.Surname;
                Admin.Username = admin.Username;
                Admin.PhoneNumber = admin.PhoneNumber;
                Admin.Email = admin.Email;
                Admin.CreatedDate = admin.CreatedDate;

                db.Admins.Add(Admin);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(admin);
        }


        public ActionResult Update(int id)
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            } 

            Models.Admin admin = db.Admins.Find(id);

            if (admin == null) 
            {
                return HttpNotFound();
            }
            return View(admin);
        }


        [HttpPost]
        public ActionResult Update(Models.Admin admin)
        {
            if (ModelState.IsValid)
            {
                Models.Admin Admin = db.Admins.Find(admin.Id);


                Admin.Name = admin.Name;
                Admin.Surname = admin.Surname;
                Admin.Username = admin.Username;
                Admin.PhoneNumber = admin.PhoneNumber;
                Admin.Email = admin.Email;



                db.Entry(Admin).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(admin);
        }

        public ActionResult Delete(int id)
        {
            Models.Admin admin = db.Admins.Find(id);

            if (admin == null) 
            {
                return HttpNotFound();
            }
            db.Admins.Remove(admin);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}