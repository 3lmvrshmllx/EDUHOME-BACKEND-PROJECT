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
    public class BlogController : Controller
    {

        EduhomeContext db = new EduhomeContext();

        public ActionResult Index()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            List<Blog> blogs = db.Blogs.Include("BlogCategory").ToList();
            return View(blogs);
        }

        public ActionResult Create()
        {

            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            ViewBag.Categories = db.BlogCategories.ToList();
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog) 
        {
           
            if (ModelState.IsValid) 
            {
                Blog Blog = new Blog();

                if (blog.ImageFile == null) 
                {
                    ModelState.AddModelError("","Image is required");
                    ViewBag.Categories = db.BlogCategories.ToList();
                    return View(blog);

                }
                else 
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    blog.ImageFile.SaveAs(imagePath);
                    Blog.Image = imageName;
                }


                Blog.Title = blog.Title;
                Blog.BlogCategoryId = blog.BlogCategoryId;
                Blog.Content = blog.Content;
                Blog.CreatedDate = blog.CreatedDate;
                Blog.AdminId = (int)Session["AdminId"];

                db.Blogs.Add(Blog);
                db.SaveChanges();

                return RedirectToAction("Index");
                
            }

            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);

        }


        public ActionResult Update(int id) 
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Index", "Login");

            }

            Blog blog = db.Blogs.Find(id);
            
            if (blog == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Blog blog) 
        {
            if (ModelState.IsValid)
            {

                Blog Blog = db.Blogs.Find(blog.Id);

                if (blog.ImageFile != null) 
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/img"), imageName);

                    string OldimagePath = Path.Combine(Server.MapPath("~/Uploads/img"), Blog.Image);

                    blog.ImageFile.SaveAs(imagePath);
                    System.IO.File.Delete(OldimagePath);

                    Blog.Image = imageName;

                }

                Blog.Title = blog.Title;
                Blog.BlogCategoryId = blog.BlogCategoryId;
                Blog.Content = blog.Content;

                db.Entry(Blog).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("index");

            }
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);

        }


        public ActionResult Delete(int id) 
        {

            Blog blog = db.Blogs.Find(id);

            if (blog == null)
            {
                return HttpNotFound();
            }

            db.Blogs.Remove(blog);
            db.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}