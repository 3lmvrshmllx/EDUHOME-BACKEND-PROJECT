using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EduHome.Controllers
{
    public class SignUpController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();           
            models.BgImage = db.BgImages.FirstOrDefault();

            return View(models);


        }


        [HttpPost]
        public ActionResult Index(ViewModelEduhome vme)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.Email == vme.UserRegister.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already in use");
                    
                }

                if (db.Users.Any(u => u.Username == vme.UserRegister.Username))
                {
                    ModelState.AddModelError("Username", "This Username is already in use");
                   
                }

                User User = new User();
                User.Name = vme.UserRegister.Name;
                User.Surname = vme.UserRegister.Surname;
                User.Email = vme.UserRegister.Email;
                User.Username = vme.UserRegister.Username;
                User.PhoneNumber = vme.UserRegister.PhoneNumber;
                User.CreatedDate = DateTime.Now;
                User.Password = Crypto.HashPassword(vme.UserRegister.Password);

                db.Users.Add(User);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }

            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.BgImage = db.BgImages.FirstOrDefault();


            return View(models);
           
        }

       
    }
}