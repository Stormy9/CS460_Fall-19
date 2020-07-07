<Query Kind="Expression">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from a in Athletes									// THIS IS THE ONE USING TWO TABLES!!!
where a.AthleteName == "Taylor Pugh"
select new {
	a.AthleteName,
	MeetDetails = from rr in RaceResults
				where a.AthleteID == rr.AthleteID
				
				// THIS is what the instructions ask for.....
				//orderby rr.MeetDate, rr.Event.EventType descending
				
				// but THIS is what matches the example in the instructions!
				orderby rr.Event.EventType ascending, rr.MeetDate
				
				select new {
					rr.MeetDate, rr.Event.EventType, rr.Location.LocationName, rr.FinishTime
				}
}
// remember double-quotes & double-equals!
// from Hwk_06:
// stockItems = stockItems.Where(si => si.StockItemName.Contains(search));