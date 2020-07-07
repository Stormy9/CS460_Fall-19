using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS460_Hwk06.DAL;
using CS460_Hwk06.Models;

namespace CS460_Hwk06.Controllers
{
    public class HomeController : Controller
    {
        // we pull in db through our context class -- like w/Homework project
        private WWIContext db = new WWIContext();

        //===============================================================================
        // GET: main page / search box
        [HttpGet]
        public ActionResult Index()
        {
            // simply returns the stuff in Index.cshtml page
            // which is primarily the search box (at least that's the main point)
            return View();
        }
        //===============================================================================
        // this page is for our search results   (   i hope -- it finally was!  [=   )
        [HttpPost]
        public ActionResult StockItem(string search)
        {
            ViewBag.SearchTerm = search;

            // added at Brittany's suggestion -- worked once i fixed connection string!!!
            // not sure if it would've worked the way i originally had it, or not..... 
            //    and i'm not going back to find out, at this point!
            //    but learn more about IQueryable (than your Quickie-Course today!)
            IQueryable<StockItem> stockItems = db.StockItems;


            // why does context change this from `StockItem` to `StockItems`?
            // the table is `StockItems`..... the model is `StockItem`.....
            // in the context, it's: `public virtual DbSet<StockItem> StockItems`
            //
            //    this had been just all in `return View()` 
            //    -- Brit suggested trying it here..... does/would it make a difference?
            //       is one way preferable?   i suppose this is.....
            stockItems = stockItems.Where(si => si.StockItemName.Contains(search));
            
            return View(stockItems.ToList());
        }
        //===============================================================================
        // to display details of a specific clicked-on item, that was returned in search
        // GET: /Home/StockItemDetails/5
        [HttpGet]
        public ActionResult StockItemDetails(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            // wait -- so this comes from the Model class for StockItem, right?
            StockItem stockItem = db.StockItems.Find(id);
            if (stockItem == null)
            {
                return HttpNotFound();
            }

            return View(stockItem);
        }
        //===============================================================================
    }
}