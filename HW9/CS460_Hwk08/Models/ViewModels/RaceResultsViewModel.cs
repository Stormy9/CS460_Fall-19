using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS460_Hwk08.Models.ViewModels 
{
    //===================================================================================
    // this is the 'class level'..... inside our 'namespace'
    public class RaceResultsViewModel
    {
        // ..... and this is the constructor, for the class `RaceResultsViewModel`
        public RaceResultsViewModel(RaceResult result)
        {
            // and here we define all those properties given below.....
            //    like the 'drill down' thing we do in LINQ-pad/LINQ Queries.....
            //      when needed, anyway.....     recognize these?   [=

            RaceResultID = result.RaceResultID;

            AthleteID = result.Athlete.AthleteID;

            AthleteName = result.Athlete.AthleteName;

            MeetDate = result.MeetDate;

            EventType = result.Event.EventType;

            LocationName = result.Location.LocationName;

            FinishTime = result.FinishTime;

            // not sure how to handle the 'Where' clause here..... or if i need to?
            //  (the 'Where' from my original LINQ Query, which worked  [=  )
            //    w/AthleteID coming from Controller (if i've got the connections correct)
            //
            //       i don't see a 'Where' in the Dr.M Slack example from Hwk_06.....
            //        speaking of which -- why is 'Select' in there twice??  top & bottom?
            //         *maybe* i get what's going on?? but would like to confirm... [=
            //
            // i can *not* figure out wth is going on here..... 
            //    i'm going from examples from the Dr.M video + Slack snippet
            //       + an example from classmate from Hwk_06.....
            //          but this thing is jut *not* happy.....
            //
        //    RRQ = RaceResult.OrderBy(qr => EventType)   // 'RaceResult does not contain a
        //                    .ThenBy(qr => MeetDate)     //  definition for OrderBy'  wth?
        //                    .Select(qr => new RaceResultsViewModel { AthleteName, 
        //                                                             MeetDate,
        //                                                             EventType, 
        //                                                             Locationname,
        //                                                             FinishTime })
        //                    .Distinct();    // '} expected' ..... the fuck??
        //                    .ToList();  // 'the name 'ToList' does not exist 
        }                               //  in the current context' ..... what??
        //-------------------------------------------------------------------------------
        // end of constructor
        //===============================================================================

        // this was auto-added on an error suggestion, but doesn't do jack shit.....
        public RaceResultsViewModel(IQueryable<RaceResult> list)
        {
            this.list = list;
        }

        // 
        // for the whole 'Select' part.....
        // 'cannot initialize type RaceResultViewModel with a collection
        // initializer because it does not implement 
        // System.Collections.IEnumerable'..... what??
        //
        // that Query ^^^ works perfectly -- returns correct results correctly -- 
        //     in LINQ-pad anyway   [=
        //
        //    also it started out being in my 'RaceResultsController', because that's
        //       where i thought it went -- but apparently it goes in here   [=
        //
        //-------------------------------------------------------------------------------
        //
        // SO => we are outside of the constructor -- but still inside the class
        //
        // these are class definitions with properties 
        //                                      -- or are they just called 'Properties'?
        //
        public int RaceResultID { get; private set; }

        public int AthleteID { get; private set; }

        public string AthleteName { get; private set; }

        public DateTime MeetDate { get; private set; }

        public string EventType { get; private set; }

        public string LocationName { get; private set; }

        public float FinishTime { get; private set; }

        // trying this based on Dr.M's Slack example..... 
        public IEnumerable<RaceResultsViewModel> RRQ { get; private set; }
        //
        // but this thing hates it.  haha!   [=


        // this was auto-added on an error suggestion, but doesn't do jack shit.....
        private IQueryable<RaceResult> list;

        //===============================================================================
    }
}
//
//=======================================================================================
//=======================================================================================
// Dr.M on Slack in response to my shit-ton of questions (haha!):
// Only partly answering your questions … a view model isn’t backed by the database.  
//    It is simply a regular class that we use to hold data and perform calculations. 
//      Pass it what it needs and then use the view model to pass to the view.  
//         The view can then just extract what it needs to build the UI.  
// OrderCount was an inner class in the view model and was used to have a concrete type.
//    The last @model you have above it the correct one. 
//       And your LINQ query should go inside the view model.
// me:  and per Dr.M's Slack example, it goes inside the Constructor.....