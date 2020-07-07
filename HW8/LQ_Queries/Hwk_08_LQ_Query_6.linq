<Query Kind="Expression">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// NEW-AND-IMPROVED VERSION OF QUERY 5.....										NO IT IS NOT!!!  hahaha!   [=
//    no JOIN'ing of tables required!!!!!										
//      just "drill down" in the RR table to get the pieces you need/want!
//
//			oops..... somehow failed to notice that I was getting 18 items with 505 items each.....bwah!
//
from rr in RaceResults
where rr.Athlete.AthleteName == "Taylor Pugh"
// THIS is the order the instructions ASK for.....
//orderby rr.MeetDate, rr.Event.EventType descending
		// but THIS is what matches the example in the lab sheet!
		orderby rr.Event.EventType ascending, rr.MeetDate
select new {	
	// WITHOUT 'orderby' commented out, i get stupid error.....
	// WITH 'orderby' commented out, it runs fine -- just in whatever-order.....
	// AHA!!!!!   'orderby' works as it should when it's up there..... yay!
	
	rr.Athlete.AthleteName,
	
	// OMG -- just use new alias here, and it all f'ing works!  yay!
	match_details = from md in RaceResults
		select new {
			rr.MeetDate, rr.Event.EventType, rr.Location.LocationName, rr.FinishTime
	}
}
// remember double-quotes & double-equals!
// from Hwk_06:
// stockItems = stockItems.Where(si => si.StockItemName.Contains(search));