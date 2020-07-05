using EduHome.DAL;
using EduHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                Models.Admin admin = db.Admins.FirstOrDefault(a => a.Username == login.Username);

                if (admin != null) 
                {
                    if (Crypto.VerifyHashedPassword(admin.Password,login.Password))
                    {
                        Session["Admin"] = admin;
                        Session["AdminId"] = admin.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else 
                    {
                        ModelState.AddModelError("Password","Password is incorrect");
                    }
                }

                else 
                {
                    ModelState.AddModelError("Username","Username is incorrect");
                }

            }

            return View();
        }

    }
}