using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Teacher
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }




        [MaxLength(150)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        public int TeacherProfessionId { get; set; }


        public TeacherProfession TeacherProfession { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(500)]
        public string AboutTeacher { get; set; }


        [Required(ErrorMessage = "Degree is required")]
        [MaxLength(50)]
        public string Degree { get; set; }


        [Required(ErrorMessage = "Experience is required")]
        [MaxLength(50)]
        public string Experience { get; set; }


        [Required(ErrorMessage = "Hobbie is required")]
        [MaxLength(50)]
        public string Hobbies { get; set; }


        [Required(ErrorMessage = "Faculty is required")]
        [MaxLength(50)]
        public string Faculty { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Phone number is required")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Skype is required")]
        [MaxLength(50)]
        public string Skype { get; set; }

        public List<SocialTeam> SocialTeams { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}