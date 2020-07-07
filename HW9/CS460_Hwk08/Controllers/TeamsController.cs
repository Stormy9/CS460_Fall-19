using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS460_Hwk08.DAL; 
using CS460_Hwk08.Models;

namespace CS460_Hwk08.Controllers
{
    public class TeamsController : Controller
    {
        // we pull in the db through our context class -- like w/Hwk_05 & _06
        private TrackContext db = new TrackContext();

        //===============================================================================
        // GET: Teams
        [HttpGet]
        public ActionResult Index()
        {
            var teams = db.Teams.Include(t => t.Coach);

            return View(teams.ToList());
        }
        //===============================================================================
        // GET: Teams/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }
        //===============================================================================
        // GET: Teams/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), "CoachID", "CoachName");

            return View();
        }
        //-------------------------------------------------------------------------------
        // POST: Teams/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamID,TeamName,CoachID")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachID = new SelectList(db.Coaches, "CoachID", "CoachName", team.CoachID);

            return View(team);
        }
        //===============================================================================
        // GET: Teams/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachID = new SelectList(db.Coaches, "CoachID", "CoachName", team.CoachID);

            return View(team);
        }
        //-------------------------------------------------------------------------------
        // POST: Teams/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to,
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamID,TeamName,CoachID")] Team team)
        {
            if (ModelState.IsValid)
            {
                db.Entry(team).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoachID = new SelectList(db.Coaches, "CoachID", "CoachName", team.CoachID);

            return View(team);
        }
        //===============================================================================
        // GET: Teams/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }
        //-------------------------------------------------------------------------------
        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Team team = db.Teams.Find(id);
            db.Teams.Remove(team);
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
        //===============================================================================
    }
}
