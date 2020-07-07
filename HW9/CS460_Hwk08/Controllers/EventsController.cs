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
    public class EventsController : Controller
    {
        // we pull in the db through our context class -- like w/Hwk_05 & _06
        private TrackContext db = new TrackContext();

        //===============================================================================
        // GET: Events
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }
        //===============================================================================
        // GET: Events/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            return View(@event);
        }
        //===============================================================================
        // GET: Events/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //-------------------------------------------------------------------------------
        // POST: Events/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventType")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(@event);
        }
        //===============================================================================
        // GET: Events/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            return View(@event);
        }
        //-------------------------------------------------------------------------------
        // POST: Events/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventID,EventType")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(@event);
        }
        //===============================================================================
        // GET: Events/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            return View(@event);
        }
        //-------------------------------------------------------------------------------
        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
