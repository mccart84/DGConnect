using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DGConnect.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TournamentDate { get; set; }
        public int CourseID { get; set; }
    }
}