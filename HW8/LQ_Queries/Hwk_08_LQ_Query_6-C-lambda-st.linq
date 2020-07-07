<Query Kind="Statements">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

int athID = 22;
var stuff = RaceResults.Where(a => a.AthleteID == athID)
						.OrderBy(a => a.Event.EventType)
						.ThenBy(a => a.MeetDate)
						.Select(a => new {a.Athlete.AthleteName, a.MeetDate, a.Event.EventType, a.Location.LocationName, a.FinishTime})
						.Distinct()
						.ToList();

//foreach(var thing in stuff)		// um, the 'OrderBy' is not working right.....
stuff.Dump();					// it's going by MeetDate then EventType