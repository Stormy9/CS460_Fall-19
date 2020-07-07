SELECT AthleteName, TeamName, MeetDate, EventType, LocationName, FinishTime 
	FROM Athletes as ath, Teams as tm, Events as ev, Locations as lc, RaceResults as rr
    	WHERE rr.AthleteID = ath.AthleteID
			AND rr.TeamID = tm.TeamID
			AND rr.EventID = ev.EventID
			AND rr.LocationID = lc.LocationID
			AND ath.AthleteName = 'Taylor Pugh'
	ORDER BY EventType ASC, MeetDate ASC;
	-- the example in the lab sheet is NOT sorted 
	--    (paraphrasing) "first by date and secondly by event(type)".....
	--       it *clearly* says "secondly by race distance"
	-- in reality it is sorted *firstly* by race distance, and THEN date.....
	--
	-- I GOT THIS WORKING IN LINQ-PAD!!!  In that notation/syntax/whatever!
	--
--=======================================================================================
-- okay..... so wtf happened here?????
--    first i was getting Brooke's records in triplicate.....
--       tried different things, no change -- or some kind of error.....
--          then suddenly i got it -- her -- correctly again..... yay!  
--             but..... ?????   hahaha!   [=
-- remember i haven't done SQL since Spring Term '17, so 2+ years ago.....   [=
--
-- ah..... i think b/c i had 'TeamName' in SELECT but didn't handle it.....