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
    public class AthletesController : Controller
    {
        // we pull in the db through our context class -- like w/Hwk_05 & _06
        private TrackContext db = new TrackContext();

        //===============================================================================
        // GET: Athletes
        [HttpGet]
        public ActionResult Index()
        {
            // think i figured out the ordering thing??  yep!!
            var athletes = db.Athletes.Include(a => a.Coach)
                                      .Include(a => a.Team)
                                      .OrderBy(a => a.AthleteName);

            return View(athletes.ToList());
        }
        //===============================================================================
        // GET: Athletes/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return HttpNotFound();
            }

            return View(athlete);
        }
        //===============================================================================
        // GET: Athletes/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), "CoachID", "CoachName");
            ViewBag.TeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName");
            ViewBag.GenderList = genderSelectList;

            return View();
        }
        //-------------------------------------------------------------------------------
        // POST: Athletes/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to,
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AthleteID,AthleteName,Gender,CoachID,TeamID")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Athletes.Add(athlete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), 
                                                "CoachID", "CoachName", athlete.CoachID);
            ViewBag.TeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), 
                                                   "TeamID", "TeamName", athlete.TeamID);
            ViewBag.GenderList = genderSelectList;

            return View(athlete);
        }
        //===============================================================================
        // GET: Athletes/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), 
                                                "CoachID", "CoachName", athlete.CoachID);
            ViewBag.TeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), 
                                                   "TeamID", "TeamName", athlete.TeamID);
            ViewBag.GenderList = genderSelectList;

            return View(athlete);
        }
        //-------------------------------------------------------------------------------
        // POST: Athletes/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AthleteID,AthleteName,Gender,CoachID,TeamID")]
                                                    Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(athlete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), 
                                                "CoachID", "CoachName", athlete.CoachID);
            ViewBag.TeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), 
                                                   "TeamID", "TeamName", athlete.TeamID);

            return View(athlete);
        }
        //===============================================================================
        // GET: Athletes/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return HttpNotFound();
            }

            return View(athlete);
        }
        //-------------------------------------------------------------------------------
        // POST: Athletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Athlete athlete = db.Athletes.Find(id);
            db.Athletes.Remove(athlete);
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
        //------------ BOY/GIRL DROP-DOWN LIST IN 'CREATE (and edit) ATHLETE' -----------
        //
        private IList<SelectListItem> genderSelectList = new List<SelectListItem>
        {
            new SelectListItem
                { Value = "girls", Text="girls" },
            new SelectListItem
                { Value = "boys", Text="boys" },
        };
        //===============================================================================
        //// GET: page on which to choose athlete stats to view
        //[HttpGet]
        //public ActionResult Stats()
        //{                                     // um, don't put this here.....
        //    return View();                    // put it in RaceResultsController (?)
        //}                                     //                              YES ^
        ////=============================================================================
        ///
        //===============================================================================
        // 
        // FROM HOMEWORK SIX (HomeController)
        //    private WWIContext db = new WWIContext(); <= up-top of code part
        //
        //    ViewBag.SearchTerm = search; <= 'search' <- passed-in param to ActionResult
        //
        //    IQueryable<StockItem> stockItems = db.StockItems;
        //
        //       'StockItem' => is the Model name.....
        //       'db.StockItems' => is a table name in the db ref'd  (the WWI one)
        //
        //       stockItems = stockItems.Where(si => si.StockItemName.Contains(search));
        //       return View(stockItems.ToList());
        // 
        //       another example:  StockItem stockItem = db.StockItems.Find(id);
    }
}
