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
    public class SettingController : Controller
    {
        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Setting> settings = db.Settings.ToList();
            return View(settings);

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
        public ActionResult Create(Setting setting)
        {

            if (ModelState.IsValid)
            {

                string logoName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + setting.LogoFile.FileName;
                string logoPath = Path.Combine(Server.MapPath("~/Uploads/img"), logoName);


                string lRedName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + setting.LogoMiniRedFile.FileName;
                string lRedPath = Path.Combine(Server.MapPath("~/Uploads/img"), lRedName);


                string lWhiteName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + setting.LogoMiniWhiteFile.FileName;
                string lWhitePath = Path.Combine(Server.MapPath("~/Uploads/img"), lWhiteName);


                setting.LogoFile.SaveAs(logoPath);
                setting.LogoMiniRedFile.SaveAs(lRedPath);
                setting.LogoMiniWhiteFile.SaveAs(lWhitePath);

                setting.Logo = logoName;
                setting.LogoMiniRed = lRedName;
                setting.LogoMiniWhite = lWhiteName;

                db.Settings.Add(setting);
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

            Setting setting = db.Settings.Find(id);

            if (setting == null)
            {
                return HttpNotFound();
            }

            return View(setting);
        }


        [HttpPost]
        public ActionResult Update(Setting setting)
        {

            if (ModelState.IsValid)
            {
                Setting Setting = db.Settings.Find(setting.Id);


                if (setting.LogoFile != null)
                {
                    string logoName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + setting.LogoFile.FileName;
                    string logoPath = Path.Combine(Server.MapPath("~/Uploads/img"), logoName);

                    string OldlogoPath = Path.Combine(Server.MapPath("~/Uploads/img"),Setting.Logo);
                    System.IO.File.Delete(OldlogoPath);

                    setting.LogoFile.SaveAs(logoPath);
                    Setting.Logo = logoName;

                }


                if (setting.LogoMiniRedFile != null)
                {
                    string lRedName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + setting.LogoMiniRedFile.FileName;
                    string lRedPath = Path.Combine(Server.MapPath("~/Uploads/img"), lRedName);

                    string OldlRedPath = Path.Combine(Server.MapPath("~/Uploads/img"), Setting.LogoMiniRed);
                    System.IO.File.Delete(OldlRedPath);

                    setting.LogoMiniRedFile.SaveAs(lRedPath);
                    Setting.LogoMiniRed = lRedName;

                }


                if (setting.LogoMiniWhiteFile != null)
                {
                    string lWhiteName = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + setting.LogoMiniWhiteFile.FileName;
                    string lWhitePath = Path.Combine(Server.MapPath("~/Uploads/img"), lWhiteName);

                    string OldlWhitePath = Path.Combine(Server.MapPath("~/Uploads/img"), Setting.LogoMiniWhite);
                    System.IO.File.Delete(OldlWhitePath);

                    setting.LogoMiniWhiteFile.SaveAs(lWhitePath);
                    Setting.Logo = lWhiteName;
                }

                Setting.Adress = setting.Adress;
                Setting.PhoneNumber = setting.PhoneNumber;
                Setting.NavbarPhone = setting.NavbarPhone;
                Setting.SiteName = setting.SiteName;
                Setting.Copyright = setting.Copyright;
                Setting.CreatedDate = setting.CreatedDate;

                db.Entry(Setting).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(setting);

        }

        public ActionResult Delete(int id)
        {
            Setting setting = db.Settings.Find(id);

            if (setting == null)
            {
                return HttpNotFound();
            }

            db.Settings.Remove(setting);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}