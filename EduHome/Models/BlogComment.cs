using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class BlogComment
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        [MaxLength(500)]
        public string Comment { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime  AddedDate  { get; set; }

    }
}