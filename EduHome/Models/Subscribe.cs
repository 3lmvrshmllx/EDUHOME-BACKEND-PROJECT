using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Subscribe
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50)]
        public string Email { get; set; }

        public DateTime AddedDate { get; set; }
    }
}