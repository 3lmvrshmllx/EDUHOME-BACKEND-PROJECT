using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EduHome.Models
{
    public class BgImage
    {
        public int Id { get; set; }


        [MaxLength(150)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}