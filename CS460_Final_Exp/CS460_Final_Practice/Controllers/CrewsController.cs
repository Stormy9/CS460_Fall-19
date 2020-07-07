using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS460_Final_Practice.DAL;
using CS460_Final_Practice.Models;

namespace CS460_Final_Practice.Controllers
{
    public class CrewsController : Controller
    {
        private PracticeContext db = new PracticeContext();

        // GET: Crews
        public ActionResult Index()
        {
            var crews = db.Crews.Include(c => c.Astronaut).Include(c => c.Mission);
            return View(crews.ToList());
        }

        // GET: Crews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // GET: Crews/Create
        public ActionResult Create()
        {
            ViewBag.AstronautID = new SelectList(db.Astronauts, "AstronautID", "AstronautName");
            ViewBag.MissionID = new SelectList(db.Missions, "MissionID", "Designation");
            return View();
        }

        // POST: Crews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CrewID,Position,AstronautID,MissionID")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                db.Crews.Add(crew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AstronautID = new SelectList(db.Astronauts, "AstronautID", "AstronautName", crew.AstronautID);
            ViewBag.MissionID = new SelectList(db.Missions, "MissionID", "Designation", crew.MissionID);
            return View(crew);
        }

        // GET: Crews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            ViewBag.AstronautID = new SelectList(db.Astronauts, "AstronautID", "AstronautName", crew.AstronautID);
            ViewBag.MissionID = new SelectList(db.Missions, "MissionID", "Designation", crew.MissionID);
            return View(crew);
        }

        // POST: Crews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CrewID,Position,AstronautID,MissionID")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crew).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AstronautID = new SelectList(db.Astronauts, "AstronautID", "AstronautName", crew.AstronautID);
            ViewBag.MissionID = new SelectList(db.Missions, "MissionID", "Designation", crew.MissionID);
            return View(crew);
        }

        // GET: Crews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = db.Crews.Find(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // POST: Crews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crew crew = db.Crews.Find(id);
            db.Crews.Remove(crew);
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
