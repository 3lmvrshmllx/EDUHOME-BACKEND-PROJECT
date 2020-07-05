using EduHome.DAL;
using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    public class EventCommentController : Controller
    {
        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<EventComment> eventComments = db.EventComments.Include("Event").Include("User").ToList();
            return View(eventComments);
        }
    }
}