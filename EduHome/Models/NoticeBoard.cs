using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class NoticeBoard
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Time is required")]
        [MaxLength(50)]
        public string Time { get; set; }


        [Required(ErrorMessage = "Content is required")]
        [MaxLength(200)]
        public string Content { get; set; }


        public DateTime CreatedDate { get; set; }


    }
}