using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Admin
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(50)]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Username is required")]
        [MaxLength(50)]
        public string Username { get; set; }



        [MaxLength(250)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }


        public DateTime CreatedDate { get; set; }


    }
}