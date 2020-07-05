using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHome.Controllers
{
    public class BlogController : Controller
    {

        EduhomeContext db = new EduhomeContext();
        public ActionResult Index(int page = 1)
        {
            ViewModelEduhome models = new ViewModelEduhome();

            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.BgImage = db.BgImages.FirstOrDefault();
            models.Blogs = db.Blogs.Include("BlogCategory").OrderByDescending(o=>o.Id).Take(3).ToList();

            ViewModelBlogCategory vmbc = new ViewModelBlogCategory();
            vmbc.Blogs = db.Blogs.ToList();

            ViewModelBlog vmb = new ViewModelBlog();
            vmb.CurrentPage = page;
            vmb.PageCount = Convert.ToInt32(Math.Ceiling(db.Blogs.Count() / 4.0));
            vmb.Blogs = db.Blogs.Include("Admin").OrderByDescending(o => o.Id).Skip((page - 1) * 4).Take(4).ToList();
           

            models.BlogCategories = db.BlogCategories.ToList();
            models.BlogComments = db.BlogComments.ToList();
            models.Tags = db.Tags.ToList();
            models.ViewModelBlog = vmb;
            models.ViewModelBlogCategory = vmbc;

            return View(models);
                    
        }

        public ActionResult BlogDetails(int id)
        {

            ViewModelEduhome models = new ViewModelEduhome();

            models.Blog = db.Blogs.Find(id);
            models.Setting = db.Settings.FirstOrDefault();
            models.SocialLinks = db.SocialLinks.ToList();
            models.BgImage = db.BgImages.FirstOrDefault();
            models.BlogCategories = db.BlogCategories.ToList();
            models.BlogComments = db.BlogComments.ToList();
            models.Blogs = db.Blogs.Include("BlogCategory").OrderByDescending(o => o.Id).Take(3).ToList();
            models.Tags = db.Tags.ToList();

            ViewModelBlogCategory vmbc = new ViewModelBlogCategory();
            vmbc.Blogs = db.Blogs.Include("Admin").ToList();

            models.ViewModelBlogCategory = vmbc;

            return View(models);
        }


        [HttpPost]
        public ActionResult Message(ViewModelBlogComment vmbc,int id)
        {

            if (Session["LoginnerId"] == null) 
            {
                return RedirectToAction("Index","Login");
            }

            BlogComment BlogComment = new BlogComment();
            BlogComment.Comment = vmbc.Message;
            BlogComment.UserId = (int)Session["LoginnerId"];
            BlogComment.BlogId = id;
            BlogComment.AddedDate = DateTime.Now;


            db.BlogComments.Add(BlogComment);
            db.SaveChanges();

            Session["SuccessfullMessage"] = true;
            return RedirectToAction("Index");
        }


    }
}