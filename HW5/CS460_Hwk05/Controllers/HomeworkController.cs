using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS460_Hwk05.DAL;
using CS460_Hwk05.Models;

namespace CS460_Hwk05.Controllers
{
    public class HomeworkController : Controller
    {
        private HomeworkContext db = new HomeworkContext();

        //===============================================================================
        //-------------------------- INDEX ----------------------------
        // GET: Homework
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Homeworks.ToList());
        }

        //===============================================================================
        //------------------------ DETAILS ----------------------------
        // GET: Homework/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework homework = db.Homeworks.Find(id);
            if (homework == null)
            {
                return HttpNotFound();
            }
            return View(homework);
        }

        //==============================================================================
        //-------------- CREATE >> GET FRESH/EMPTY FORM ---------------
        // GET: Homework/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.PriorityList = prioritySelectList;
            return View();
        }

        //----------------- CREATE >> SEND INPUT DATA -----------------
        // POST: Homework/Create
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to,
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Priority,DueDate,DueTime,Dept,Course,Assignment,Notes")] Homework homework)
        {
            if (ModelState.IsValid)
            {
                db.Homeworks.Add(homework);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PriorityList = prioritySelectList;
            return View(homework);
        }

        //===============================================================================
        //------------- EDIT >> PULL UP RECORD TO EDIT ----------------
        // GET: Homework/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework homework = db.Homeworks.Find(id);
            if (homework == null)
            {
                return HttpNotFound();
            }
            return View(homework);
        }

        //------------- EDIT >> REFLECT MODIFIED DATA -----------------
        // POST: Homework/Edit/5
        // To protect from overposting attacks, 
        // please enable the specific properties you want to bind to, 
        // for more details see https://go.microsoft.com/fwlink/?LinkId=317598
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Priority,DueDate,DueTime,Dept,Course,Assignment,Notes")] Homework homework)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homework).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homework);
        }

        //===============================================================================
        //------------ DELETE >> GET RECORD TO DELETE -----------------
        // GET: Homework/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homework homework = db.Homeworks.Find(id);
            if (homework == null)
            {
                return HttpNotFound();
            }
            return View(homework);
        }

        //-------------------------------------------------------------
        // POST: Homework/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Homework homework = db.Homeworks.Find(id);
            db.Homeworks.Remove(homework);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //===============================================================================
        //---------- WAIT..... WHAT IS THIS FOR (or do)? --------------
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //===============================================================================
        //------------ STUFF FOR DROP-DOWN LIST IN 'CREATE' -----------
        //
        private IList<SelectListItem> prioritySelectList = new List<SelectListItem>
        {
            new SelectListItem
                { Value = "super-important", Text="super-important" },
            new SelectListItem
                { Value = "important", Text="important" },
            new SelectListItem
                { Value = "regular", Text="regular" },
            new SelectListItem
                { Value = "meh", Text="meh" },
            new SelectListItem
                { Value = "notes", Text="notes" }
        };
        //===============================================================================
    }
}