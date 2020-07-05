using System;
using EduHome.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EduHome.ViewModels;

namespace EduHome.Controllers
{
    public class AboutController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            ViewBag.Page = "About";

            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.About = db.Abouts.FirstOrDefault();
            models.BgImage = db.BgImages.FirstOrDefault();
            models.SocialTeams = db.SocialTeams.ToList();
            models.Teachers = db.Teachers.Include("TeacherProfession").Take(4).ToList();
            models.StudentFeedback = db.StudentFeedbacks.FirstOrDefault();
            models.NoticeBoards = db.NoticeBoards.ToList();
            return View(models);
        }
    }
}