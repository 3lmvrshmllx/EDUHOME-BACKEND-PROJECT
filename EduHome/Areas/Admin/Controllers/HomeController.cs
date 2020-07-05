using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {

            if (Session["AdminId"] == null) 
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}