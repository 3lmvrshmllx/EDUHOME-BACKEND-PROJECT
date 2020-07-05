using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Speaker
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Profession is required")]
        [MaxLength(50)]
        public string Profession { get; set; }


        [MaxLength(150)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public List<Event> Events { get; set; }

        public DateTime CreatedDate {get;set;}


    }
}