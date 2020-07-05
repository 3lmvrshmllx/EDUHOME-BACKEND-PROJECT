using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Course
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100)]
        public string Title { get; set; }


 
        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; } 


        [Required(ErrorMessage = "Content is required")]
        [MaxLength(500)]
        public string Content { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(500)]
        public string AboutCourse { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(500)]
        public string HowToApply { get; set; }


        [Required(ErrorMessage = "Certification is required")]
        [MaxLength(500)]
        public string Certification { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30)]
        public string Starts { get; set; }


        [Required(ErrorMessage = "Duration is required")]
        [MaxLength(20)]
        public string Duration { get; set; }


        [Required(ErrorMessage = "Class duration is required")]
        [MaxLength(20)]
        public string ClassDuration { get; set; }


        [Required(ErrorMessage = "Skill level is required")]
        [MaxLength(20)]
        public string SkillLevel { get; set; }


        [Required(ErrorMessage = "Language is required")]
        [MaxLength(20)]
        public string Language { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public int StudentsCount { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20)]
        public string Assessments { get; set; }


        [Required(ErrorMessage = "Course fee is required")]
        public int CourseFee { get; set; }


        public int CourseCategoryId { get; set; }

        public CourseCategory CourseCategory { get; set; }

        public List<CourseComment> CourseComments { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}