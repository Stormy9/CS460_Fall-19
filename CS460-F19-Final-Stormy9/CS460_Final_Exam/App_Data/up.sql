-- Person table first -- no FK's
CREATE TABLE [dbo].[Person]
(
	[PersonID]		INT IDENTITY (1,1)		NOT NULL,
	[FirstName]		NVARCHAR(50)			NOT NULL,
	[LastName]		NVARCHAR(50)			NOT NULL,


	-- primary key
	CONSTRAINT [PK_dbo.Person] PRIMARY KEY CLUSTERED ([PersonID] ASC)
);
-----------------------------------------------------------------------------------------
-- Event table last <= no 2nd -- two FK's..... um, wait... how do i wanna do this??  ha!
CREATE TABLE [dbo].[Event]		-- no just one FK     i think     [=
(
	[EventID]		INT IDENTITY (1,1)		NOT NULL,
	[EventTitle]	NVARCHAR(50)			NOT NULL,
	[EventStart]	DATETIME				NOT NULL,
	[EventDuration]	INT						NOT NULL,
	[EventLocation]	NVARCHAR(50)			NOT NULL,

	-- FK to represent the event coordinator
	[PersonID]		INT						NOT NULL,
	-- FK to represent the attendee
	--[RsvpID]		INT						NOT NULL,		<= no!

	
	-- primary key
	CONSTRAINT [PK_dbo.Event] PRIMARY KEY CLUSTERED ([EventID] ASC),

	-- foreign keys: FK_ThisTable_OtherTable_OtherTableIDcolumn
	CONSTRAINT [FK_dbo.Event_dbo.Person_PersonID] FOREIGN KEY ([PersonID])
		REFERENCES [dbo].[Person] ([PersonID])

	--CONSTRAINT [FK_dbo.Event_dbo.RSVP_RsvpID] FOREIGN KEY ([RsvpID])
	--	REFERENCES [dbo].[RSVP] ([RsvpID])
);
-----------------------------------------------------------------------------------------
-- RSVP table second<= no, last..... -- one FK <= no, two..... ???  i think   [=
CREATE TABLE [dbo].[RSVP]
(
	[RsvpID]		INT IDENTITY (1,1)		NOT NULL,
	[TimeStamp]		DATETIME				NOT NULL,
	
	-- FK to represent the attendee
	[PersonID]	INT							NOT NULL,
	-- FK to represent the event they are attending
	[EventID]	INT							NOT NULL,


	-- primary key
	CONSTRAINT [PK_dbo.RSVP] PRIMARY KEY CLUSTERED ([RsvpID] ASC),

	-- foreign key: FK_ThisTable_OtherTable_OtherTableIDcolumn
	CONSTRAINT [FK_dbo.RSVP_dbo.Person_PersonID] FOREIGN KEY ([PersonID])
		REFERENCES [dbo].[Person] ([PersonID]),

	CONSTRAINT [FK_dbo.RSVP_dbo.Event_EventID] FOREIGN KEY ([EventID])
		REFERENCES [dbo].[Event] ([EventID])
);
--=======================================================================================
-- seed data to get tables started.....
--
-- Persons
--
INSERT INTO [dbo].[Person] (FirstName, LastName)
	VALUES
		('Julie',  'Morgan'),		-- ID = 1
		('Horacio','Gutierrez'),	-- ID = 2
		('James',  'Bond'),			-- ID = 3
		('Diana',  'Prince'),		-- ID = 4
		('Baby',   'Yoda'),			-- ID = 5
		('Peter',  'Rabbit');		-- ID = 6
-----------------------------------------------------------------------------------------
-- Events..... one FK (PersonID) representing the event coordinator
--
INSERT INTO [dbo].[Event] (EventTitle, EventStart, EventDuration, EventLocation, PersonID)
	VALUES
		('Ghirardelli Wedding',   '01/20/2020 12:00:00', 4, 'State Street Event Center', 1),
		('Spy Retirement Banquet','04/12/2020 17:00:00', 7, 'United Artists Headquarters', 2),
		('Bachelorette Party',    '06/05/2020 19:00:00', 9, 'The Amado', 1);
-----------------------------------------------------------------------------------------
-- RSVPs..... two FKs (PersonID) representing the attendee
--					  (EventID) representing the event they are attending
--
INSERT INTO [dbo].[RSVP] (Timestamp, PersonID, EventID)
	VALUES
		('12/05/2019 09:12:45', 6, 1),
		('11/14/2019 20:01:02', 4, 1),
		('10/05/2019 19:27:16', 3, 2),
		('12/01/2019 12:12:12', 5, 3),
		('12/02/2019 06:07:08', 4, 3);
--=======================================================================================