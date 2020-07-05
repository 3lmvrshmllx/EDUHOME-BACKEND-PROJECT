using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Setting
    {

        public int Id { get; set; }



        [MaxLength(150)]
        public string Logo { get; set; }


        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }



        [MaxLength(150)]
        public string LogoMiniRed { get; set; }


        [NotMapped]
        public HttpPostedFileBase LogoMiniRedFile { get; set; }


        [MaxLength(150)]
        public string LogoMiniWhite { get; set; }


        [NotMapped]
        public HttpPostedFileBase LogoMiniWhiteFile { get; set; }


        [Required(ErrorMessage = "Adress is required")]
        [MaxLength(50)]
        public string Adress { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(50)]
        public string NavbarPhone { get; set; }


        [Required(ErrorMessage = "Site name is required")]
        [MaxLength(50)]
        public string SiteName { get; set; }


        [Required(ErrorMessage = "Copyright is required")]
        [MaxLength(50)]
        public string Copyright { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}