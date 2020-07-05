using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class Event
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }



        [MaxLength(150)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [Required(ErrorMessage = "Venue is required")]
        [MaxLength(50)]
        public string Venue { get; set; }


        [Required(ErrorMessage = "Time is required")]
        [MaxLength(50)]
        public string Time {get; set;}


        [Required(ErrorMessage = "Content is required")]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public int SpeakerId { get; set; }

        public Speaker Speaker { get; set; }

        public int EventCategoryId { get; set; }

        public EventCategory EventCategory { get; set; }

        public List<EventComment> EventComments { get; set; } 

        public DateTime CreatedDate { get; set; }

    }
}