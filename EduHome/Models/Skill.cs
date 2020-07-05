using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Skill
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Percent is required")]
        public int Percent { get; set; }


        public DateTime CreatedDate { get; set; }

    }
}