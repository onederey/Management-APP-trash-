--DEFAULT, CHECK, FOREIGN KEY
use OlympiadDB;
GO

IF OBJECT_ID('dbo.Participants') IS NULL
BEGIN
	CREATE TABLE [dbo].[Participants]
	(
		[CountryID] INT,
		[SportID] INT,
		[ParticipantID] INT IDENTITY(100,1),
		[FirstName] NVARCHAR(30) NOT NULL,
		[LastName] NVARCHAR(30) NOT NULL,
		[SecondName] NVARCHAR(30) DEFAULT '',
		[DateOfBirth] DATETIME NOT NULL,
		PRIMARY KEY (ParticipantID),
		FOREIGN KEY (SportID) REFERENCES KindsOfSport(KindID),
		FOREIGN KEY (CountryID) REFERENCES Country(ID)
	)
END;
GO