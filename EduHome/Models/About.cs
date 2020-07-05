using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class About
    {

        public int Id { get; set; }


        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile {get;set;}


        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }


        [Required(ErrorMessage = "Content is required")]
        [MaxLength(500)]
        public string Content { get; set; }


        public DateTime CreatedDate { get; set; }

    }
}