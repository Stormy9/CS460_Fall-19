<Query Kind="Statements">
  <Connection>
    <ID>56a439b1-5330-47fd-bad9-b49dd1dbb15a</ID>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Track.mdf</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 'C# Statement' version of Query 6-A		(or not.....)
//											(it says 'Query successful' yet does not return anything..... haha!)
int athlete = 22;

	var results = (from rr in RaceResults.Distinct() // STILL getting 505 things!!!
			  		where rr.Athlete.AthleteID == athlete
			  		orderby rr.Event.EventType ascending, rr.MeetDate
					select new {		
								rr.Athlete.AthleteName,
							
								match_details = from md in RaceResults.Distinct()	// STILL GETTING 505 ITEMS!!!
								select new {
										rr.MeetDate, rr.Event.EventType, rr.Location.LocationName, rr.FinishTime
								}
					}).First();	// '.Distinct()' did not work, either
					
	// does not like 'DistinctBy' found on StackOverflow
	// make it 'Distinct' and does not like that, either for the part in the()
	//var temp = results.Distinct(i => i.Athlete.AthleteID);
	
	// in this is has a problem w/ 'Athlete.AthleteID' and with just 'AthleteID'
	//var temp = results.GroupBy(x => x.AthleteID).Select(y => y.First());
					// using '.First()' up there, now it doesn't like 'results' here.....
					//foreach(var thing in results)
						results.Dump(); // STILL GETTING 505 THINGS!!!!!