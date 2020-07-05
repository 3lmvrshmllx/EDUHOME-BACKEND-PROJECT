using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class ContactAdress
    {

        public int Id { get; set; }


        [MaxLength(150)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile {get;set;}


        [Required(ErrorMessage = "Country is required")]
        [MaxLength(50)]
        public string Country { get; set; }


        [Required(ErrorMessage = "Street is required")]
        [MaxLength(50)]
        public string Street { get; set; }


        public DateTime CreatedDate { get; set; }

    }
}