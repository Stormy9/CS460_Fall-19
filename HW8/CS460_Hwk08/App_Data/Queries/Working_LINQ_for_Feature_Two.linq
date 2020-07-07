<Query Kind="Expression" />

from rr in RaceResults									    // THIS IS THE *RIGHT* ONE!!!
	where rr.AthleteID == 22 									   // other way returning
		orderby rr.Event.EventType ascending, rr.MeetDate		    // shitloads of stuff				
			select new {								
				rr.Athlete.AthleteName,								                          // C# Expression
				rr.MeetDate,
				rr.Event.EventType, rr.Location.LocationName, rr.FinishTime }
//
//=======================================================================================
var rrq = from rr in RaceResults
          where rr.AthleteID == 22
          orderby rr.Event.EventType ascending, rr.MeetDate
          select new {
						rr.Athlete.AthleteName,						                        // C# Statement(s)
                        rr.MeetDate,							   
                        rr.Event.EventType, rr.Location.LocationName, rr.FinishTime };

						  rrq.Dump();
//=======================================================================================
RaceResults.Where(a => a.AthleteID == 22)
						.OrderBy(a => a.Event.EventType)
						.ThenBy(a => a.MeetDate)
						.Select(a => new {a.Athlete.AthleteName, 
										  a.MeetDate, 
										  a.Event.EventType, 
										  a.Location.LocationName, 
										  a.FinishTime})
						.Distinct()

// this returns different order than the other (Query) syntax.....
// but same as Query_6-C-lambda-st, of course!							            // C# Expression

//=======================================================================================
int athID = 22;
var stuff = RaceResults.Where(a => a.AthleteID == athID)
						.OrderBy(a => a.Event.EventType)
						.ThenBy(a => a.MeetDate)
						.Select(a => new {a.Athlete.AthleteName, 
											a.MeetDate, 
											a.Event.EventType, 
											a.Location.LocationName, 
											a.FinishTime})
											.Distinct()
											.ToList();
																		                                      // C# Statement
stuff.Dump()	// returns table view								

// returns each thing in a box
foreach(var thing in stuff)					// um, the 'OrderBy' is not working right...
thing.Dump();								// it's going by MeetDate then EventType

//=======================================================================================