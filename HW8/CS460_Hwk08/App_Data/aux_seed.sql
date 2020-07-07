-- just so i don't lose track of my practice stuff.....
--    this => https://sqliteonline.com/
--    + this => C:\Users\User\Google Drive\Stormy_Summer'14\_Stormys_School_CCC-WOU\
--                  _CS460-SrSeqI\CS460_SrSeq1_Wk08+Hwk08\sqlite.db
--=======================================================================================
-- Line 31 in 'example_seed.sql' => taken directly from there
--    Load coaches data, no foreign keys here to worry about so we can do
--       a straight insert of just the distinct values  (yay!)
--
INSERT INTO [dbo].[Coaches] ([CoachName])
	SELECT DISTINCT Coach 
		FROM [dbo].[AllData];	-- so why the [ ] here, and not elsewhere
								--   even in Dr. Morse's 'example_seed.sql'??
-----------------------------------------------------------------------------------------
-- Line 36 in 'example_seed.sql' => taken directly from there
--    Load Team data -- a team has a coach, so we need to find the correct entry 
--       in the Coaches table, so we can set the foreign key appropriately
--
INSERT INTO [dbo].[Teams]
	(TeamName,CoachID)
	SELECT DISTINCT ad.Team,cs.CoachID
		FROM dbo.AllData as ad, dbo.Coaches as cs
			WHERE ad.Coach = cs.CoachName;

-----------------------------------------------------------------------------------------
-- Line 43 in 'example_seed.sql'
--    Load all the other tables in a similar fashion.  
--       Race results is the hardest, since it has several FK's.
--          Think joins.   (Troy said inner joins, which makes sense.....)
--             But, in testing @https://sqliteonline.com/ -- which yeah, i know.....
--                but there's enough similarities that you can extrapolate (think/hope!)
--                   And, it all worked in there, as expected/i think it should.....
-----------------------------------------------------------------------------------------
--
-- very close to what i practiced @https://sqliteonline.com/, that *did* work.....
--    minor differences in syntax, of course.....
--       and i reversed order of 'CoachID' and 'TeamID' + better alias
--
INSERT INTO [dbo].[Athletes]
	(AthleteName, Gender, CoachID, TeamID)
	SELECT DISTINCT ad.Athlete, ad.Gender, ch.CoachID, tm.TeamID
		FROM dbo.AllData as ad, dbo.Coaches as ch, dbo.Teams as tm		-- aliases
			WHERE ad.Coach = ch.CoachName
				AND ad.Team = tm.TeamName;

-----------------------------------------------------------------------------------------
INSERT INTO [dbo].[Events]
	(EventType)
	SELECT DISTINCT Event		-- why is 'Event' in blue???
		FROM [dbo].[AllData];	

-----------------------------------------------------------------------------------------
INSERT INTO [dbo].[RaceResults]
	(Location, MeetDate, Gender, FinishTime, AthleteID, CoachID, TeamID, EventID)
	SELECT ad.Location, ad.MeetDate, ad.Gender, ad.RaceTime, ath.AthleteID, ch.CoachID, tm.TeamID, ev.EventID
		FROM dbo.AllData as ad, Athletes as ath, Coaches as ch, Teams as tm, Events as ev
			WHERE ad.Athlete = ath.AthleteName
				AND ad.Coach = ch.CoachName
				AND ad.Team = tm.TeamName
				AND ad.Event = ev.EventType;

--=======================================================================================
-- We don't need this staging table anymore so clear it away
--   EXCEPT -- I want it, for now, because..... well, just because -- and to check/verify
--
-- DROP TABLE [dbo].[AllData];
--=======================================================================================
