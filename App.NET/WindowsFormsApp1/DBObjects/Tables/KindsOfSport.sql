use OlympiadDB;
GO

IF OBJECT_ID('dbo.KindsOfSport') IS NULL
BEGIN
	CREATE TABLE [dbo].[KindsOfSport]
	(
		[KindID] INT NOT NULL IDENTITY(1,1),
		[Name] NVARCHAR(64) NOT NULL UNIQUE,
		[IsIndividual] BIT NOT NULL,
		PRIMARY KEY (KindID)
	)
END;
GO

INSERT INTO [dbo].[KindsOfSport] (Name, IsIndividual)
VALUES
	('Tennis', 1),
	('Football', 0),
	('Skate', 1),
	('Swimming', 1),
	('American Football', 0),
	('Hockey', 0)


GO

CREATE INDEX index_KindsOfSport_Name
ON dbo.KindsOfSport([Name]);