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
    public class CoachesController : Controller
    {
        // we pull in the db through our context class -- like w/Hwk_05 & _06
        private TrackContext db = new TrackContext();

        //===============================================================================
        // GET: Coaches
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Coaches.ToList());
        }
        //===============================================================================
        // GET: Coaches/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }

            return View(coach);
        }
        //===============================================================================
        // GET: Coaches/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //-------------------------------------------------------------------------------
        // POST: Coaches/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to,
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoachID,CoachName")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Coaches.Add(coach);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(coach);
        }
        //===============================================================================
        // GET: Coaches/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }

            return View(coach);
        }
        //-------------------------------------------------------------------------------
        // POST: Coaches/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to,
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoachID,CoachName")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coach).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(coach);
        }

        //===============================================================================
        // GET: Coaches/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }

            return View(coach);
        }

        //-------------------------------------------------------------------------------
        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coach coach = db.Coaches.Find(id);
            db.Coaches.Remove(coach);
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
