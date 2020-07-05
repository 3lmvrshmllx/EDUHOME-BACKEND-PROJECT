using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class SocialLink
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Icon is required")]
        [MaxLength(50)]
        public string Icon { get; set; }


        [Required(ErrorMessage = "Link is required")]
        [MaxLength(150)]
        public string Link { get; set; }


        public DateTime CreatedDate { get; set; }
    }
}