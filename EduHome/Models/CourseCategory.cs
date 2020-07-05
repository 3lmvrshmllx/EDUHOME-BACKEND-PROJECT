using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class CourseCategory
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }


        public List<Course> Courses { get; set; }

    }
}