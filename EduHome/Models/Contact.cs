using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Contact
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Subject is required")]
        [MaxLength(50)]
        public string Subject { get; set; }


        [Required(ErrorMessage = "Message is required")]
        [MaxLength(500)]
        public string Message { get; set; }

        public DateTime AddedDate { get; set; }
    }
}