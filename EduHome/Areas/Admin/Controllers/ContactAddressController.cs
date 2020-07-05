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
    public class ContactAddressController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<ContactAdress> contactAdresses = db.ContactAdresses.ToList();
            return View(contactAdresses);

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
        public ActionResult Create(ContactAdress contactAdress)
        {

            if (ModelState.IsValid)
            {

                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + contactAdress.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                contactAdress.ImageFile.SaveAs(imagePath);
                contactAdress.Image = imageName;

                db.ContactAdresses.Add(contactAdress);
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

            ContactAdress contactAdress = db.ContactAdresses.Find(id);

            if (contactAdress == null)
            {
                return HttpNotFound();
            }

            return View(contactAdress);
        }


        [HttpPost]
        public ActionResult Update(ContactAdress contactAdress)
        {

            if (ModelState.IsValid)
            {
                ContactAdress ContactAdress = db.ContactAdresses.Find(contactAdress.Id);


                if (contactAdress.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + contactAdress.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), ContactAdress.Image);
                    System.IO.File.Delete(OldimagePath);

                    contactAdress.ImageFile.SaveAs(imagePath);
                    ContactAdress.Image = imageName;

                }

                ContactAdress.Country = contactAdress.Country;
                ContactAdress.Street = contactAdress.Street;
                ContactAdress.CreatedDate = contactAdress.CreatedDate;

                db.Entry(ContactAdress).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(contactAdress);

        }

        public ActionResult Delete(int id)
        {
            ContactAdress contactAdress = db.ContactAdresses.Find(id);

            if (contactAdress == null)
            {
                return HttpNotFound();
            }

            db.ContactAdresses.Remove(contactAdress);
            db.SaveChanges();

            return RedirectToAction("Index");
        }




    }
}