using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class StudentFeedback
    {

        public int Id { get; set; }



        [MaxLength(150)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [Required(ErrorMessage = "Fullname is required")]
        [MaxLength(100)]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Category is required")]
        [MaxLength(100)]
        public string Category { get; set; }


        [Required(ErrorMessage = "Content is required")]
        [MaxLength(200)]
        public string Content { get; set; }


        public DateTime CreatedDate { get; set; }

    }
}