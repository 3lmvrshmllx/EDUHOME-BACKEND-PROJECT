using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Blog
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }



        [MaxLength(150)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [Required(ErrorMessage = "Content is required")]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }


        public int BlogCategoryId { get; set; }

        public BlogCategory BlogCategory { get; set; } 


        public int AdminId { get; set; }

        public Admin Admin { get; set; }


        public  DateTime CreatedDate { get; set; }


        public List<BlogComment> BlogComments { get; set; }

    }
}