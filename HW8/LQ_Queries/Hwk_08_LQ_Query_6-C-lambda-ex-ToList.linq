<Query Kind="Expression">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

RaceResults.Where(a => a.AthleteID == 22)
			.OrderBy(a => a.Event.EventType)
			.ThenBy(a => a.MeetDate)
			.Select(a => new {a.Athlete.AthleteName, a.MeetDate, a.Event.EventType, a.Location.LocationName, a.FinishTime})
			.Distinct()
			.ToList()

// this returns different order than the other (Query) syntax.....
// but same as Query_6-C-lambda-st, of course!