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
    public class LoginController : Controller
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
                User loginner = db.Users.FirstOrDefault(u => u.Username ==  vme.UserLogin.Username);

                if (loginner != null)
                {
                    if (Crypto.VerifyHashedPassword(loginner.Password, vme.UserLogin.Password))
                    {
                        Session["Loginner"] = loginner;
                        Session["LoginnerId"] = loginner.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password!");

                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Incorrect Username!");

                }
            }

            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.BgImage = db.BgImages.FirstOrDefault();
           
            return View(models);
          
            
        }

        public ActionResult Logout()
        {
            Session["Loginner"] = null;
            Session["LoginnerId"] = null;

            return RedirectToAction("Index", "Login");
        }


    }
}