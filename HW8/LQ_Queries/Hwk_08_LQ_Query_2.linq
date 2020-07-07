<Query Kind="Expression">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//Athletes.Select(a => a.AthleteName)		// worked
RaceResults.Where(a => a.AthleteID == 22).Select(a => new {a.Athlete.AthleteName, a.AthleteID, a.FinishTime}).Distinct()		// worked

