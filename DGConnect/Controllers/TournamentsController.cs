﻿using System;
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
    public class TournamentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tournaments
        public ActionResult Index()
        {
            return View(db.Tournaments.ToList());
        }

        // GET: Tournaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: Tournaments/Create
        public ActionResult Create(int? CourseID)
        {
            if (CourseID == null)
            {
                CourseID = 0;
            }

            ViewBag.CourseID = CourseID;

            return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,TournamentDate,CourseID")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Tournaments.Add(tournament);
                db.SaveChanges();
                return RedirectToAction("Details", "Courses", new { @id = tournament.CourseID });
            }

            return RedirectToAction("Details", "Courses", new { @id = tournament.CourseID });
        }

        // GET: Tournaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,TournamentDate,CourseID")] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tournament tournament = db.Tournaments.Find(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tournament tournament = db.Tournaments.Find(id);
            db.Tournaments.Remove(tournament);
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
