use OlympiadDB;
GO

IF OBJECT_ID('dbo.Courts') IS NULL
BEGIN
	CREATE TABLE [dbo].[Courts]
	(
		[CourtID] INT NOT NULL  IDENTITY(1,1),
		[Name] NVARCHAR(64) NOT NULL UNIQUE,
		[Location] NVARCHAR(256) NOT NULL,
		PRIMARY KEY (CourtID)
	)
END;
GO

INSERT INTO [dbo].[Courts] (Name, Location)
VALUES
	('Swimming Pool', 'Main Hall'),
	('Tennis Court', 'North Hall'),
	('Skate Park', 'North Hall'),
	('Stadium', 'Main Hall'),
	('Small Stadium', 'West Hall')