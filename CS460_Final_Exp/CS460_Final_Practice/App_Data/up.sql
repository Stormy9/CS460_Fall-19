CREATE TABLE [dbo].[Mission]
(
	[MissionID]		INT IDENTITY (1,1)	NOT NULL,
	[Designation]	NVARCHAR (50)	NOT NULL,
	[Description]	NVARCHAR (50)	NOT NULL,

	CONSTRAINT [PK_dbo.Mission] PRIMARY KEY CLUSTERED ([MissionID] ASC)
);
--=======================================================================================

CREATE TABLE [dbo].[Country]
(
	[CountryID]		INT IDENTITY (1,1)	NOT NULL,
	[CountryName]	NVARCHAR (50)		NOT NULL,

	CONSTRAINT [PK_dbo.Country] PRIMARY KEY CLUSTERED ([CountryID] ASC)
);
--=======================================================================================

CREATE TABLE [dbo].[Astronaut]
(
	[AstronautID]	INT IDENTITY (1,1)	NOT NULL,
	[AstronautName]	NVARCHAR (50)		NOT NULL,
	[Birthday]		DATETIME			NOT NULL,

	[CountryID]		INT					NOT NULL,

	CONSTRAINT [PK_dbo.Astronaut] PRIMARY KEY CLUSTERED ([AstronautID] ASC),

	CONSTRAINT [FK_dbo.Astronaut_dbo.Country_CountryID] FOREIGN KEY ([CountryID])
		REFERENCES [dbo].[Country] ([CountryID])
);
--=======================================================================================

CREATE TABLE [dbo].[Crew]
(
	[CrewID]		INT IDENTITY (1,1)	NOT NULL,
	[Position]		NVARCHAR (50)		NOT NULL,
	
	[AstronautID]	INT					NOT NULL,
	[MissionID]		INT					NOT NULL,

	CONSTRAINT [PK_dbo.Crew] PRIMARY KEY CLUSTERED ([CrewID] ASC),

	CONSTRAINT [FK_dbo.Crew_dbo.Astronaut_AstronautID] FOREIGN KEY ([AstronautID])
		REFERENCES [dbo].[Astronaut] ([AstronautID]),
	
	CONSTRAINT [FK_dbo.Crew_dbo.Mission_MissionID] FOREIGN KEY ([MissionID])
		REFERENCES [dbo].[Mission] ([MissionID])
);
--=======================================================================================

INSERT INTO [dbo].[Mission] (Designation, Description)
	VALUES
	('Expedition 53', 'Exp 53: 53rd expedition to the ISS'),
	('Expedition 52', 'Exp 52: 52nd expedition to the ISS'),
	('STS-112', 'STS-112: 11-day space shuttle mission to the ISS');

INSERT INTO [dbo].[Country] (CountryName)
	VALUES
	('Russia'),
	('Italy'),
	('USA'),
	('Japan');

INSERT INTO [dbo].[Astronaut] (AstronautName, Birthday, CountryID)
	VALUES
	('Possum', 1-19-2008, 3),
	('Sawyer', 1-19-2008, 3),
	('Zoey', 1-19-2008, 1),
	('Lacey', 1-19-2008, 1),
	('Jack', 1-19-2008, 2);

INSERT INTO [dbo].[Crew] (Position, AstronautID, MissionID)
	VALUES
	('Mission Specialist 4', 1, 1),
	('Commander', 2, 3),
	('Flight Engineer 1', 3, 2),
	('Flight Engineer 5', 4, 3);
