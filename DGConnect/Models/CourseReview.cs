using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DGConnect.Models
{
    public class CourseReview
    {
        public int ID { get; set; }

        [Required]
        [Range(0,10)]
        public int Rating { get; set; }
        public string Body { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
    }
}