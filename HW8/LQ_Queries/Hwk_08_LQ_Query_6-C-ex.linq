<Query Kind="Expression">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from rr in RaceResults										// THIS IS THE *RIGHT* ONE!!!
	where rr.AthleteID == 22 								
		orderby rr.Event.EventType ascending, rr.MeetDate									
			select new {								
				rr.Athlete.AthleteName, rr.MeetDate, rr.Event.EventType,
				rr.Location.LocationName, rr.FinishTime, rr.AthleteID
			}

												// other way returning shitloads of stuff