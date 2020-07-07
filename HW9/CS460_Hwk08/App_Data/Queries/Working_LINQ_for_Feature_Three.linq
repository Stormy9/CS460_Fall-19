RaceResults.Where(a => a.AthleteID == 22).Where(a => a.Event.EventType == "1500").Select(a => new {a.MeetDate, a.FinishTime}).Distinct().ToList()
																	// C# Expression
//=======================================================================================

var graphData = RaceResults.Where(a => a.AthleteID == 22).Where(a => a.Event.EventType == "1500").Select(a => new {a.MeetDate, a.FinishTime}).ToList();

graphData.Dump();													// C# Statement(s)
//=======================================================================================

// except separate it out into 'MeetDate' and 'FinishTime'
// 
// 'MeetDate':
var graphDate = RaceResults.Where(a => a.AthleteID == 22).Where(a => a.Event.EventType == "1500").Select(a => new {a.MeetDate}).ToList();

var graphFinish = RaceResults.Where(a => a.AthleteID == 22).Where(a => a.Event.EventType == "1500").Select(a => new {a.FinishTime}).ToList();

//=======================================================================================
// tested the latter in LINQ-pad -- and it works -- just didn't get screenshots.....