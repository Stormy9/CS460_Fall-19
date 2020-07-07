-- ################### SEED DATA ######################
-- lines 1 thru 30 from 'example_seed.sql' file (w/my own path of course)
--
-- extract data from .csv file and load it into an initial staging db
--    create a staging table to hold all the seed data.....
--       we'll query this table, in order to extract what we need 
--          to then insert into our real tables
--
--	taken directly from 'example_seed.sql' file
--
--CREATE TABLE [dbo].[AllData]
--(
--	[Location]		NVARCHAR(50),
--	[MeetDate]		DATETIME,
--	[Team]			NVARCHAR(50),
--	[Coach]			NVARCHAR(50),
--	[Event]			NVARCHAR(20),
--	[Gender]		NVARCHAR(20),
--	[Athlete]		NVARCHAR(50),
--	[RaceTime]		REAL
--);
--=======================================================================================
-- hard code the full path to the csv file.....
--    it'll be better this way when we run this in Hwk_09 to build an Azure db
--
--BULK INSERT [dbo].[AllData]
--	FROM "C:\Users\User\stormy\racetimes.csv"
--	WITH
--	(
--		FIELDTERMINATOR = ',',
--		ROWTERMINATOR = '0x0a',	-- the \n did not work; thanks Tanner!
--		FIRSTROW = 2
--	);
--=======================================================================================
--=======================================================================================
-- Line 31 in 'example_seed.sql' => taken directly from there
--    Load coaches data, no foreign keys here to worry about so we can do
--       a straight insert of just the distinct values  (yay!)
--
--INSERT INTO [dbo].[Coaches] ([CoachName])
--	SELECT DISTINCT Coach 
--		FROM [dbo].[AllData];	-- so why the [ ] here, and not elsewhere
--								--   even in Dr. Morse's 'example_seed.sql'??
-----------------------------------------------------------------------------------------
-- Line 36 in 'example_seed.sql' => taken directly from there
--    Load Team data -- a team has a coach, so we need to find the correct entry 
--       in the Coaches table, so we can set the foreign key appropriately
--
-- it's not the other way around, because a team exists if the coach leaves.....
--    (that's why 'Team' isn't a FK to 'Coach')
--
--INSERT INTO [dbo].[Teams]
--	(TeamName,CoachID)
--	SELECT DISTINCT ad.Team,cs.CoachID
--		FROM dbo.AllData as ad, dbo.Coaches as cs
--			WHERE ad.Coach = cs.CoachName;

-----------------------------------------------------------------------------------------
-- Line 43 in 'example_seed.sql'
--    Load all the other tables in a similar fashion.  
--       Race results is the hardest, since it has several FK's.
--          Think joins.   (Troy said inner joins, which makes sense.....)
--             But, in testing @https://sqliteonline.com/ -- which yeah, i know.....
--                but there's enough similarities that you can extrapolate (think/hope!)
--                   And, it all worked in there, as expected/i think it should.....
-- Brittany said: "The commas are joining your tables".....
--    which i'd forgotten about.  it's been 2 years since i've done SQL!
-----------------------------------------------------------------------------------------
--
-- very close to what i practiced @https://sqliteonline.com/, that *did* work.....
--    minor differences in syntax, of course.....
--       and i reversed order of 'CoachID' and 'TeamID' + better alias
--
--INSERT INTO [dbo].[Athletes]
--	(AthleteName, Gender, CoachID, TeamID)
--	SELECT DISTINCT ad.Athlete, ad.Gender, ch.CoachID, tm.TeamID
--		FROM dbo.AllData as ad, dbo.Coaches as ch, dbo.Teams as tm		-- aliases
--			WHERE ad.Coach = ch.CoachName
--				AND ad.Team = tm.TeamName;

-----------------------------------------------------------------------------------------
--INSERT INTO [dbo].[Events]
--	(EventType)
--	SELECT DISTINCT Event		-- why is 'Event' in blue???
--		FROM [dbo].[AllData];	

-----------------------------------------------------------------------------------------
--INSERT INTO [dbo].[Locations]
--	(LocationName)
--	SELECT DISTINCT Location
--		FROM [dbo].[AllData];
-----------------------------------------------------------------------------------------
--
-- the others are all commented out b/c i had to re-do/make 'RaceResults', 
--    since i forgot a 'Location' table!
--
INSERT INTO [dbo].[RaceResults]
	(LocationID, MeetDate, Gender, FinishTime, AthleteID, CoachID, TeamID, EventID)
	SELECT lc.LocationID, ad.MeetDate, ad.Gender, ad.RaceTime, 
			ath.AthleteID, ch.CoachID, tm.TeamID, ev.EventID
		FROM dbo.AllData as ad, Athletes as ath, Coaches as ch, Teams as tm, 
				Events as ev, Locations as lc
			WHERE ad.Location = lc.LocationName
				AND ad.Athlete = ath.AthleteName
				AND ad.Coach = ch.CoachName
				AND ad.Team = tm.TeamName
				AND ad.Event = ev.EventType;

--=======================================================================================
-- We don't need this staging table anymore so clear it away
--   EXCEPT -- I want it, for now, because..... well, just because -- and to check/verify
--
-- DROP TABLE [dbo].[AllData];
--=======================================================================================
