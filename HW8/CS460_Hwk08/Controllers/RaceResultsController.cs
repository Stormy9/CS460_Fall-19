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
using CS460_Hwk08.Models.ViewModels;

namespace CS460_Hwk08.Controllers
{
    public class RaceResultsController : Controller
    {
        // we pull in the db through our context class -- like w/Hwk_05 & _06
        private TrackContext db = new TrackContext();

        //===============================================================================
        // GET: RaceResults
        [HttpGet]
        public ActionResult Index()
        {
            // added ordering by meet date
            var raceResults = db.RaceResults.Include(r => r.Athlete)
                                            .Include(r => r.Coach)
                                            .Include(r => r.Event)
                                            .Include(r => r.Location)
                                            .Include(r => r.Team)
                                            .OrderBy(r => r.MeetDate);

            return View(raceResults.ToList());
            // so why does *THIS* 'ToList()' work?????
            // and mine does not in 'ResultsList'?????
            // why no 'IEnumerable' error on this?????
            //
            // and where is '.Include(r => r.MeetDate) up there???  it's in the View.....
            // and where is '.Include( => r.FinishTime)?   oooooh.... okay -- it's only
            //                                             doing the non-native ones.....
            // learn more about '.Include()':
            // https://docs.microsoft.com/en-us/dotnet/api/system.data.objects.objectquery-1.include?view=netframework-4.8
        }
        //===============================================================================
        // GET: RaceResults/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            RaceResult raceResult = db.RaceResults.Find(id);
            if (raceResult == null)
            {
                return HttpNotFound();
            }

            return View(raceResult);
        }

        //===============================================================================
        // GET: RaceResults/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.AthleteID = new SelectList(db.Athletes.OrderBy(a => a.AthleteName), "AthleteID", "AthleteName");
            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), "CoachID", "CoachName");
            ViewBag.EventID = new SelectList(db.Events.OrderBy(e => e.EventType), "EventID", "EventType");
            ViewBag.LocationID = new SelectList(db.Locations.OrderBy(l => l.LocationName), "LocationID", "LocationName");
            ViewBag.TeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName");
            ViewBag.GenderList = genderSelectList;

            return View();
        }

        //-------------------------------------------------------------------------------
        // POST: RaceResults/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RaceResultID,LocationID,MeetDate,Gender,FinishTime,AthleteID,CoachID,TeamID,EventID")] RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                db.RaceResults.Add(raceResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AthleteID = new SelectList(db.Athletes.OrderBy(a => a.AthleteName), "AthleteID", "AthleteName", raceResult.AthleteID);
            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), "CoachID", "CoachName", raceResult.CoachID);
            ViewBag.EventID = new SelectList(db.Events.OrderBy(e => e.EventType), "EventID", "EventType", raceResult.EventID);
            ViewBag.LocationID = new SelectList(db.Locations.OrderBy(l => l.LocationName), "LocationID", "LocationName", raceResult.LocationID);
            ViewBag.TeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName", raceResult.TeamID);

            return View(raceResult);
        }

        //===============================================================================
        // GET: RaceResults/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RaceResult raceResult = db.RaceResults.Find(id);
            if (raceResult == null)
            {
                return HttpNotFound();
            }

            ViewBag.AthleteID = new SelectList(db.Athletes.OrderBy(a => a.AthleteName), "AthleteID", "AthleteName", raceResult.AthleteID);
            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), "CoachID", "CoachName", raceResult.CoachID);
            ViewBag.EventID = new SelectList(db.Events.OrderBy(e => e.EventType), "EventID", "EventType", raceResult.EventID);
            ViewBag.LocationID = new SelectList(db.Locations.OrderBy(l => l.LocationName), "LocationID", "LocationName", raceResult.LocationID);
            ViewBag.TeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName", raceResult.TeamID);
            ViewBag.GenderList = genderSelectList;

            return View(raceResult);
        }

        //-------------------------------------------------------------------------------
        // POST: RaceResults/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RaceResultID,LocationID,MeetDate,Gender,FinishTime,AthleteID,CoachID,TeamID,EventID")] RaceResult raceResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raceResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AthleteID = new SelectList(db.Athletes.OrderBy(a => a.AthleteName), "AthleteID", "AthleteName", raceResult.AthleteID);
            ViewBag.CoachID = new SelectList(db.Coaches.OrderBy(c => c.CoachName), "CoachID", "CoachName", raceResult.CoachID);
            ViewBag.EventID = new SelectList(db.Events.OrderBy(e => e.EventType), "EventID", "EventType", raceResult.EventID);
            ViewBag.LocationID = new SelectList(db.Locations.OrderBy(l => l.LocationName), "LocationID", "LocationName", raceResult.LocationID);
            ViewBag.TeamID = new SelectList(db.Teams.OrderBy(t => t.TeamName), "TeamID", "TeamName", raceResult.TeamID);

            return View(raceResult);
        }

        //===============================================================================
        // GET: RaceResults/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RaceResult raceResult = db.RaceResults.Find(id);
            if (raceResult == null)
            {
                return HttpNotFound();
            }

            return View(raceResult);
        }

        //-------------------------------------------------------------------------------
        // POST: RaceResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RaceResult raceResult = db.RaceResults.Find(id);
            db.RaceResults.Remove(raceResult);
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
        //===============================================================================
        //-------- BOY/GIRL DROP-DOWN LIST IN 'CREATE (and edit) RACE RESULT' -----------
        //
        private IList<SelectListItem> genderSelectList = new List<SelectListItem>
        {
            new SelectListItem
                { Value = "girls", Text="girls" },
            new SelectListItem
                { Value = "boys", Text="boys" },
        };
        //===============================================================================
        //===============================================================================
        // GET: page that shows table of all results for an athlete => part of Feature#2
        [HttpGet]
        public ActionResult Results()
        {
            // this makes the drop-down list from which to choose an athlete.....
            ViewBag.AthleteID = new SelectList(db.Athletes, "AthleteID", "AthleteName");

            return View();
        }
        //===============================================================================
        [HttpPost]
        public ActionResult ResultsList(int AthleteID)
        {
            // so..... based off Hwk06 & the Search Box Feature..... 
            //   we pass in that up there, from the name of the drop-down in the View...
            ViewBag.AthleteID = AthleteID;           // <= passing & reflecting correctly

            IQueryable<RaceResult> list = db.RaceResults;

            var AthName = list.Where(an => an.AthleteID == AthleteID)
                                        .Select(an => an.Athlete.AthleteName);
            ViewBag.AthleteName = AthName;
            // um..... i thought we could do LINQ Queries in here?  Apparently not??
            //   i mean, we have before -- but what the *hell* is *that* returning???
            //---------------------------------------------------------------------------

            // continuing to borrow + adapt from something from Hwk_06.....
            //    just to see if it works..... it can hardly get worse -- haha!   [=
            //       but in hwk_06, it returned a list of items that matched the search
            //          so we'll see..... nothing else works dammit!
            list = list.Where(x => x.AthleteID == AthleteID);

            //RaceResultsViewModel viewModel = new RaceResultsViewModel(list);
                // it does a red squiggle under (list), with this error:
                // "Argument 1: cannot convert from 
                // 'System.Linq.IQueryable<CS460_Hwk08.Models.RaceResult>'
                // to 'CS460_Hwk08.Models.RaceResult'
                // so it suggested this fix, in RaceResultsViewModel:
                //   private IQueryable<RaceResult> list;
                //      so i tried it.....  same fucking error message as before.

            //return View(list.ToList());
                // The model item passed into the dictionary is of type 
                // 'System.Collections.Generic.List`1[CS460_Hwk08.Models.RaceResult]', 
                // but this dictionary requires a model item of type 
                // 'System.Collections.Generic.IEnumerable`1[CS460_Hwk08.Models.ViewModels.RaceResultsViewModel]'
            //
            // is 'ToList()' not an IEnumerable???   oh..... i'm bypassing the ViewModel
            //                                       dammit.  lemme try this.....
            //return View(viewModel);
            // nope!!!  same fucking error as right up there.  dammit!!!!!

            //---------------------------------------------------------------------------
            // "Cannot implicitly convert type 'CS460_Hwk08.Models.RaceResult' to
            //  'Systems.Collections.Generic.IEnumerable<CS460_Hwk08.Models.RaceResult>'.
            // An explicit conversion exists (are you missing a cast?)"        <= what???
            //
            //IEnumerable<RaceResult> ListResults = db.RaceResults.Find(AthleteID);

            //RaceResultsViewModel viewModel = new RaceResultsViewModel(ListResults);

            //return View(viewModel);

            // nope!  still getting the same damned error:
            // The model item passed into the dictionary is of type 
            // 'CS460_Hwk08.Models.ViewModels.RaceResultsViewModel', 
            // but this dictionary requires a model item of type 
            // 'System.Collections.Generic.IEnumerable`1[CS460_Hwk08.Models.ViewModels.RaceResultsViewModel]'.
            //
            // i just don't get it. this was not an issue with the other homework,
            //  nor even with returning the list, from, say, 'Index()' right up at
            //     the top of this page or on any other f'ing 'Index()' page.....
            //
            //---------------------------------------------------------------------------

            // this returns the page w/reflecting the correctly passed-in AthleteID.....
            return View();       // and successfully!  haha!
            //                      just with that weird thing for AthleteName.....

        }
        //===============================================================================
        //===============================================================================
        // GET: page on which to choose athlete stats to view            => aka Feature#3
        [HttpGet]
        public ActionResult Stats()
        {
            // wait..... we don't pass params in *HERE* like the other one!!
            //    do we??  no, if we do, page won't even load in the first place.....
            // and we don't want to send to another page, w/params, just to AJAX?

            // shouldn't these be 'int'?  but it doesn't *like* int.....
            // not even when you do 'Int32.Parse()' -- specially not then!
            string AthID = Request["AthleteID"];
            string EvID = Request["EventID"];

            bool checkAthID = string.IsNullOrEmpty(AthID);
            bool checkEvID = string.IsNullOrEmpty(EvID);

            //---------------------------------------------------------
            // i can NOT get the params to turn into ints!!!
            //    which i need for the queries below!!
            //
            // *WHY* are they being passed in as strings in the first place?!
            // and YES, I typed the Requests to 'int', but it didn't like that

            //int AthIDNm;
            int EvIDNm;
            // 'false' means they are *not* empty/null
            if (checkAthID == false && checkEvID == false)
            {
                int AthIDNm = Int32.Parse(AthID);
                ViewBag.AthIDNum = AthIDNm;

                EvIDNm = Int32.Parse(EvID);
                ViewBag.AthEvNum = EvIDNm;
            }
            // so this seems to work -- BUT... you can't use these ints in the Queries
            //     it says they are unassigned or don't exist 
            //---------------------------------------------------------
            
            ViewBag.AthID = AthID;
            ViewBag.EvID = EvID;

            ViewBag.AthleteID = new SelectList(db.Athletes, "AthleteID", "AthleteName");
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventType");

            // we gotta get the AthleteID & EventID from the drop-downs.....
            //   but not as params passed in *here*... right?? it goes to our own script?
            //      but we gotta have params here, too, to pass into our Queries.....right?

            // LINQ Queries (with example ID's for now):
            var graphDate = db.RaceResults.Where(a => a.AthleteID == 22 && 
                                                            a.Event.EventID == 3)
                                          .Select(a => new { a.MeetDate })
                                          .ToList();

            var graphFinish = db.RaceResults.Where(a => a.AthleteID == 22 && 
                                                                a.Event.EventID == 2)
                                            .Select(a => new { a.FinishTime })
                                            .ToList();

            // HOWEVER..... it seems you can only do one but not both???
            //    if the values get passed here as Query-String params via GET.....
            //       that takes making the form method 'GET' and the button type="submit"
            //
            //    BUT..... to make the jQuery work, you need button type="button"
            //       and even if you triggered the jQuery on selecting the 2nd 
            //          drop-down -- how would you pass the ID's into here, 
            //             to use in the Queries??
            //
            // AND WHY ARE THEY PASSING IN AS 'STRINGS' INSTEAD OF 'INTS'???
            //
            // --------------------------------------------------------------------------
            // so isn't the idea, that we need to get the AthleteID and the EventID
            //   from the user input..... pass those ID's into our LINQ Query,
            //      to produce the correct results.....
            // 
            // the LINQ Queries then produce a list of dates, and a list of finish times.....
            //    then those are passed to the plot.ly API to construct the graphs.....
            // 
            // right?????
            //
            //---------------------------------------------------------------------------

            return View();
        }
        //===============================================================================
        //===============================================================================
    }
}

//=======================================================================================
//=======================================================================================
//
// so why does the '.ToList()' thing work w/ 'Index()', but not here???
//          -- in 'ResultsList(int AthleteID) --
// both have => @model IEnumerable<CS460_Hwk08.Models.RaceResult> on View
// but this keeps complaining that i'm not doing 'IEnumerable' here.....
//-----------------------------------------------------------------------
// this had been up in 'ResultsList(AthleteID)'.....
// // so this also returns the same (virtually so) error message as on line 236:
//IEnumerable<RaceResult> ResultsList = db.RaceResults;

//// this works perfectly -- returns results correctly -- in LINQ-pad.....
//var rrq = ResultsList.Where(a => a.AthleteID == AthleteID)
//                     .OrderBy(a => a.Event.EventType)
//                     .ThenBy(a => a.MeetDate)
//                     .Select(a => new RaceResultsViewModel { a.Athlete.AthleteName,
//                                                             a.MeetDate, 
//                                                             a.Event.EventType, 
//                                                             a.Location.LocationName,
//                                                             a.FinishTime })
//                     .Distinct()
//                     .ToList();     
//
//            return View(rrq);
// this gives this error:
//-----------------------
// The model item passed into the dictionary is of type 
// 'System.Collections.Generic.List`1[<>f__AnonymousType1`5[System.String,System.DateTime,System.String,System.String,System.Single]]',
// but this dictionary requires a model item of type 
// 'System.Collections.Generic.IEnumerable`1[CS460_Hwk08.Models.RaceResult]'.
//---------------------------------------------------------------------------


