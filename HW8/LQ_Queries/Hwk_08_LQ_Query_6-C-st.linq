<Query Kind="Statements">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

var rrq = from rr in RaceResults					// Query_6-C in statement form
          	where rr.AthleteID == 22
            	orderby rr.Event.EventType ascending, rr.MeetDate
                  select new {
                      rr.Athlete.AthleteName, rr.MeetDate,              
                      rr.Event.EventType, rr.Location.LocationName, rr.FinishTime
                  };
				  
				  rrq.Dump();		// <= this works			
				  var rrqList = rrq.ToList();
				  foreach (var thing in rrqList)	// this works too
				  	thing.Dump();