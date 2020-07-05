using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Home
    {

        public int Id { get; set; }


        [MaxLength(150)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }


        [Required(ErrorMessage = "Subtitle is required")]
        [MaxLength(200)]
        public string SubTitle { get; set; }


        public DateTime CreatedDate { get; set; }


    }
}