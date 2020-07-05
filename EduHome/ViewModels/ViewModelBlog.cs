using EduHome.DAL;
using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduHome.ViewModels
{
    public class ViewModelBlog
    {

        public int PageCount { get; set; }

        public int CurrentPage { get; set; }

        public List<Blog> Blogs { get; set; }


    }
}