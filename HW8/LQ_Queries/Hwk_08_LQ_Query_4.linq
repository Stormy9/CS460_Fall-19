<Query Kind="Expression">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

from rr in RaceResults
where rr.Athlete.AthleteName == "Brooke Rasmussen"
select new {
	rr.Athlete.AthleteName,
	rr.Athlete.Gender,
	rr.Athlete.Team.TeamName,
	rr.Athlete.Coach.CoachName
}
// O. M. G. ..... that up there worked!!!!!
// so this works, but let's try it a different way..... (up above)
// from a in Athletes
//where a.AthleteName == "Brooke Rasmussen"
//select new {
//	a.AthleteName,
//	a.Gender,
//	TeamDetails = from t in Teams
//				where a.CoachID == t.CoachID
//				select new {
//					t.TeamName
//				},
//	CoachDetails = from c in Coaches
//				where a.CoachID == c.CoachID
//				select new {
//					c.CoachName
//				}
//}
// so you need double quotes & double equals!  cool!
// TeamDetails pulls Brooke's appropriate Team Name!!	CoachDetails pulls Brooke's Coach's name!