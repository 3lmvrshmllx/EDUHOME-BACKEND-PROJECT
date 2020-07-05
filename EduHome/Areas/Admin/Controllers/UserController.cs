using EduHome.DAL;
using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index","Login");
            }

            List<User> users = db.Users.ToList();
            return View(users);
        }
    }
}