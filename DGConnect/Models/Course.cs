using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DGConnect.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "The course name should be under 200 characters long")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }

        public virtual ICollection<CourseReview> Reviews { get; set; }

    }
}