CREATE TABLE [dbo].[Homeworks]		/* use plural db name */
(
	[ID]			INT IDENTITY (1,1)	NOT NULL,

	[Priority]		NVARCHAR(18)        NOT NULL,

    [DueDate]		DATE				NOT NULL,

	[DueTime]		TIME(0)				NOT NULL,

	[Dept]			NVARCHAR(4)			NOT NULL,

	[Course]		NVARCHAR(9)			NOT NULL,

	[Assignment]	NVARCHAR(64)		NOT NULL,

	[Notes]			NTEXT				NOT NULL,

								/* learn more about this syntax */
    CONSTRAINT [PK_dbo.Homeworks] PRIMARY KEY CLUSTERED ([ID] ASC)

);

INSERT INTO [dbo].[Homeworks] (Priority, DueDate, DueTime, Dept, Course, Assignment, Notes) VALUES
    ('super-important','2019-11-11','11:59 PM', 'CS', '123', 'Questions/Answers', 'best to read ch 5 first'),
    ('meh','2019-11-18','11:59 PM','CS','134','write helloWorld program','find out how to write a helloWorld program'),
    ('important','2019-11-13','11:59 PM','MTH','123','chapter 3 problems','do the odd-numbered ones'),
	('regular','2019-11-15','11:59 PM','WR','101','write essay paper','figure out something to write an essay about'),
	('notes','2019-11-14','11:59 PM','CS','142','do up notes over chapters 1-5','make sure you know that crap for the mid-term')
GO