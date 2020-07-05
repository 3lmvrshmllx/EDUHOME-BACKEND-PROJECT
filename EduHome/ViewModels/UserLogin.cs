using EduHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EduHome.ViewModels
{
    public class UserLogin
    {
        
          [Required(ErrorMessage = "Username is required")]
          public string Username { get; set; }


          [Required(ErrorMessage = "Password is required")]
          public string Password { get; set; }

          public Setting Setting { get; set; }
         
          public BgImage BgImage { get; set; }

          public List<SocialLink> SocialLinks { get; set; }
    }
}