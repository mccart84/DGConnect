using DGConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DGConnect.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var topRated =
                from r in db.Courses
                orderby r.Reviews.Average(review => review.Rating) descending
                select r;

            ViewBag.topRatedCourses = topRated.Take(5);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult TopRatedCourses()
        {
            var averageRating = db.Courses
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Take(5)
                .ToList();

            return PartialView(averageRating);
        }

        public ActionResult UpcomingTournaments()
        {
            var upcomingTournaments = db.Tournaments
                .Where(t => t.TournamentDate >= DateTime.Now)
                .OrderBy(t => t.TournamentDate)
                .Take(5)
                .ToList();

            return PartialView(upcomingTournaments);
        }
    }
}