-- based on how we did Hwk_05
--    + the info gleaned from example seed file + the db schema we came up with
--=======================================================================================
-- Dr. Morse said not to worry about doing it this way for now.....
--    (which is from the Quack-it link from Slack)
--       https://www.quackit.com/sql_server/t-sql/examples/create_database.cfm
--
-- CREATE DATABASE RaceTimes;
-- USE RaceTimes; 
--=======================================================================================
-- besides referring to `up.sql` from Hwk_05.....
-- https://www.quackit.com/sql_server/t-sql/examples/create_table.cfm
--    and etc. from there -- the easiest/quickest to read/get   [=
-- https://www.quackit.com/sql_server/t-sql/examples/create_relationship.cfm
-- 
-- and foreign key stuff -- which of course we didn't have in Hwk_05.....
-- https://launchschool.com/books/sql/read/table_relationships
-- https://docs.microsoft.com/en-us/sql/relational-databases/tables/create-foreign-key-relationships?view=sql-server-ver15
--
--=======================================================================================
--
-- make 'Coaches' table 1st..... 
--    taken directly from 'example_seed.sql' file + our logic   [=
--
--CREATE TABLE [dbo].[Coaches] (
--	[CoachID]		INT IDENTITY (1,1)		NOT NULL,
--	[CoachName]			NVARCHAR (72)			NOT NULL,

--	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([CoachID] ASC)
--);
-----------------------------------------------------------------------------------------
--
-- make 'Teams' table 2nd -- same reasons(ing) as above -- has to come after 'Coaches'
--    every 'Team' has a 'Coach'  (or at least we hope so, and in our case, they just do)
--       so we need to find the correct entry in the 'Coaches' table,
--         so we can appropriately set the Foreign Key here.....
--
--CREATE TABLE [dbo].[Teams] (							-- can do this here too?
--	[TeamID]		INT IDENTITY (1,1)		NOT NULL,		-- PRIMARY KEY,
--	[TeamName]		NVARCHAR(72)			NOT NULL,

--	[CoachID]		INT						NOT NULL,	-- Foreign Key


--	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([TeamID] ASC),

--	CONSTRAINT [FK_dbo.Teams_Coaches] FOREIGN KEY ([CoachID])
--		REFERENCES [dbo].[Coaches] (CoachID)
--);
-----------------------------------------------------------------------------------------
--
-- make 'Athletes' table 3rd..... has to come after 'Teams'
--    every 'Athlete' has a 'Team'..... and a 'Coach', but that's connected via 'Team'
--
CREATE TABLE [dbo].[Athletes]  (
	[AthleteID]			INT IDENTITY (1,1)		NOT NULL,
	[AthleteName]		NVARCHAR(72)			NOT NULL,
	[Gender]			NVARCHAR(6)				NOT NULL,

	[CoachID]	INT						NOT NULL,	-- Foreign Key
	[TeamID]	INT						NOT NULL,	-- Foreign Key


	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([AthleteID] ASC),

	CONSTRAINT [FK_dbo.Athletes_Teams] FOREIGN KEY ([TeamID])
		REFERENCES [dbo].[Teams] (TeamID),

	-- wait... Troy & i came up w/this -- but on 2nd thought, i don't think we need it...
	--    because Athlete => Team => Coach		right???
	--       NO..... we *DO* need it!   [=		(or it'll be better if we have it.....)
	--
	CONSTRAINT [FK_dbo.Athletes_Coaches] FOREIGN KEY ([CoachID])
		REFERENCES [dbo].[Coaches] (CoachID),
);
-----------------------------------------------------------------------------------------
--
-- make 'Events' table 4th..... 
--    we could make it 1st or 2nd b/c no FK's..... but it doesn't really matter and
--      just has to come before the 'RaceResults' table.....
--
--CREATE TABLE [dbo].[Events] (
--	[EventID]			INT IDENTITY (1,1)		NOT NULL,		-- no FK's in
--	[EventType]			NVARCHAR(30)			NOT NULL,		-- this one

--	-- oops, forgot this at first.....
--	CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([EventID] ASC)
--);
-----------------------------------------------------------------------------------------
--
-- make the 'Locations' table before 'RaceResults'..... 
--    i just forgot about it the first time around, so dropped & re-made 'RaceResults'
-- SO..... this would *NOT* create this table, from here.....
--    despite the message 'Command(s) completed successfully', 
--       there was never a new f'ing table.....
--    had to make it -- with this same code -- via MS-SQL-Server Manager..... that did it
--
--CREATE TABLE [dbo].[Locations] (
--	[LocationID]	INT IDENTITY (1,1)		NOT NULL,
--	[LocationName]	NVARCHAR(72)			NOT NULL,

--	CONSTRAINT [PK_dbo.Locations] PRIMARY KEY CLUSTERED ([LocationID] ASC)
--);
-----------------------------------------------------------------------------------------
--
-- make 'RaceResults' table 5th..... has to come after everything else b/c all the FK's.....
--    every 'RaceResults' has 'Athletes' => which have 'Team' => which has 'Coach'
--       so wait -- DO we need multiple FK's here?
--    changed name from 'Events' to 'RaceResults' b/c (a) example_seed.sql from Dr. M
--													  (b) we need a table for 'Events' [=
--
CREATE TABLE [dbo].[RaceResults] (
	[RaceResultID]			INT IDENTITY (1,1)		NOT NULL,

	[LocationID]			INT						NOT NULL,
	--[Location]				NVARCHAR (72)			NOT NULL,

	[MeetDate]				Date					NOT NULL,

	-- was not sure if this should be here..... but i think so?
	[Gender]				NVARCHAR(9)				NOT NULL,

	-- this is where i was gonna make a list of values: 100m, 200m, 400m, etc. 
	--    but i think it should have it's own table?
	--[Type]			NVARCHAR(36)			NOT NULL,		-- 

	[FinishTime]			REAL					NOT NULL,
	
	[AthleteID]		INT			NOT NULL,
	[CoachID]		INT			NOT NULL,
	[TeamID]		INT			NOT NULL,
	[EventID]		INT			NOT NULL,


	CONSTRAINT [PK_dbo.RaceResults] PRIMARY KEY CLUSTERED ([RaceResultID] ASC),
	
	-- lotta these this time.....
	-- and add in this 'Locations' one, too:
	CONSTRAINT [FK_dbo.RaceResults_Locations] FOREIGN KEY ([LocationID])
		REFERENCES [dbo].[Locations] (LocationID),

	CONSTRAINT [FK_dbo.RaceResults_Athletes] FOREIGN KEY ([AthleteID])
		REFERENCES [dbo].[Athletes] (AthleteID),

	CONSTRAINT [FK_dbo.RaceResults_Teams] FOREIGN KEY ([TeamID])
		REFERENCES [dbo].[Teams](TeamID),

	CONSTRAINT [FK_dbo.RaceResults_Coaches] FOREIGN KEY ([CoachID])
		REFERENCES [dbo].[Coaches] (CoachID),

	CONSTRAINT [FK_dbo.RaceResults_Events] FOREIGN KEY ([EventID])
		REFERENCES [dbo].[Events] (EventID)
);
--=======================================================================================
GO