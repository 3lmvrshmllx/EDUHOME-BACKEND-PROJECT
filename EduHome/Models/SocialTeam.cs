using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class SocialTeam
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Icon is required")]
        [MaxLength(50)]
        public string Icon { get; set; }


        [Required(ErrorMessage = "Link is required")]
        [MaxLength(150)]
        public string Link { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(20)]
        public string Name { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}