using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Controllers
{
    public class ContactController : Controller
    {

        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {
            ViewBag.Page = "Contact";

            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.ContactAdresses = db.ContactAdresses.ToList();
            models.BgImage = db.BgImages.FirstOrDefault();
            return View(models);
        }

        [HttpPost]
        public ActionResult Message(ViewModelContact viewModelContact) 
        {
                
                Contact Contact = new Contact();
                Contact.Name = viewModelContact.Name;
                Contact.Email = viewModelContact.Email;
                Contact.Subject = viewModelContact.Subject;
                Contact.Message = viewModelContact.Message;
                Contact.AddedDate = DateTime.Now;

                db.Contacts.Add(Contact);
                db.SaveChanges();

                Session["SuccessfullMessage"] = true;
                return RedirectToAction("Index");

        }


    }
}