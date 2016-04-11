using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGConnect.Models;

namespace DGConnect.Controllers
{
    public class CourseReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CourseReviews
        public ActionResult Index()
        {
            return View(db.CourseReviews.ToList());
        }

        // GET: CourseReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseReview courseReview = db.CourseReviews.Find(id);
            if (courseReview == null)
            {
                return HttpNotFound();
            }
            return View(courseReview);
        }

        // GET: CourseReviews/Create
        public ActionResult Create(int CourseID)
        {
            ViewBag.CourseID = CourseID;
            return View();
        }

        // POST: CourseReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Rating,Body,CourseID,UserID")] CourseReview courseReview)
        {
            if (ModelState.IsValid)
            {
                db.CourseReviews.Add(courseReview);
                db.SaveChanges();
                return RedirectToAction("Details", "Courses", new { @id = courseReview.CourseID } );
            }

            return RedirectToAction("Details", "Courses", new { @id = courseReview.CourseID });
        }

        // GET: CourseReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseReview courseReview = db.CourseReviews.Find(id);
            if (courseReview == null)
            {
                return HttpNotFound();
            }
            return View(courseReview);
        }

        // POST: CourseReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Rating,Body,CourseID,UserID")] CourseReview courseReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseReview);
        }

        // GET: CourseReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseReview courseReview = db.CourseReviews.Find(id);
            if (courseReview == null)
            {
                return HttpNotFound();
            }
            return View(courseReview);
        }

        // POST: CourseReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseReview courseReview = db.CourseReviews.Find(id);
            db.CourseReviews.Remove(courseReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
