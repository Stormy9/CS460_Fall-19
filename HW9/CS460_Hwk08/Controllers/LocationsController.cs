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
    public class LocationsController : Controller
    {
        // we pull in the db through our context class -- like w/Hwk_05 & _06
        private TrackContext db = new TrackContext();

        //===============================================================================
        // GET: Locations
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Locations.ToList());
        }
        //===============================================================================
        // GET: Locations/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }

            return View(location);
        }
        //===============================================================================
        // GET: Locations/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //-------------------------------------------------------------------------------
        // POST: Locations/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to,
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationID,LocationName")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(location);
        }
        //===============================================================================
        // GET: Locations/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }

            return View(location);
        }
        //-------------------------------------------------------------------------------
        // POST: Locations/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationID,LocationName")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(location);
        }
        //===============================================================================
        // GET: Locations/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }

            return View(location);
        }
        //-------------------------------------------------------------------------------
        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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
