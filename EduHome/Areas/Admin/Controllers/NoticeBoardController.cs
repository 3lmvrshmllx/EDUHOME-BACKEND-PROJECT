using EduHome.DAL;
using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Areas.Admin.Controllers
{
    public class NoticeBoardController : Controller
    {
        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<NoticeBoard> noticeBoards = db.NoticeBoards.ToList();
            return View(noticeBoards);

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
        public ActionResult Create(NoticeBoard noticeBoard)
        {

            if (ModelState.IsValid)
            {

                db.NoticeBoards.Add(noticeBoard);
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

            NoticeBoard noticeBoard = db.NoticeBoards.Find(id);

            if (noticeBoard == null)
            {
                return HttpNotFound();
            }

            return View(noticeBoard);
        }


        [HttpPost]
        public ActionResult Update(NoticeBoard noticeBoard)
        {

            if (ModelState.IsValid)
            {

                db.Entry(noticeBoard).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(noticeBoard);

        }

        public ActionResult Delete(int id)
        {
            NoticeBoard noticeBoard = db.NoticeBoards.Find(id);

            if (noticeBoard == null)
            {
                return HttpNotFound();
            }

            db.NoticeBoards.Remove(noticeBoard);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}