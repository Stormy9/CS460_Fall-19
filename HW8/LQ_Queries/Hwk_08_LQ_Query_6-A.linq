<Query Kind="Expression">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// cleaned-up version of Query 6 <= THEN FIXED b/c hadn't noticed i was getting 18 things, 
//									with each of the 18 things containing 505 things!!!
//									so, shitloads of things..... Oops!!!  hahaha!
//									commenting out what you see, puts it back to just the
from rr in RaceResults				// the 18 things it's *supposed* to be
where rr.AthleteID == 22 

	orderby rr.Event.EventType ascending, rr.MeetDate
												// oops..... no, this is *not* quite working..... 
	select new {								// it returns shitloads of everything.....
		rr.Athlete.AthleteName, 
		
		//match_details = from md in RaceResults.Distinct()
			//select new {					// was using 'match_details' b/c that would
				rr.MeetDate, 				// display 'AthleteName' only once.....
				rr.Event.EventType, 		// BUT, we can just not use that field in our view/table!
				rr.Location.LocationName,	// and that's what was causing shitloads of things to be returned!
				rr.FinishTime
			//}
	}