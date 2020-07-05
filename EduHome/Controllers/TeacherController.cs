using EduHome.DAL;
using EduHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        EduhomeContext db = new EduhomeContext();
        public ActionResult Index()
        {

            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.SocialTeams = db.SocialTeams.ToList();
            models.Teachers = db.Teachers.Include("TeacherProfession").ToList();
            models.BgImage = db.BgImages.FirstOrDefault();
            return View(models);
           
        }


        public ActionResult TeacherDetails(int id) 
        {

            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.SocialTeams = db.SocialTeams.ToList();
            models.Teachers = db.Teachers.Include("TeacherProfession").ToList();
            models.Teacher = db.Teachers.Find(id);
            models.BgImage = db.BgImages.FirstOrDefault();
            models.Skills = db.Skills.ToList();
            return View(models);
        }
    }
}