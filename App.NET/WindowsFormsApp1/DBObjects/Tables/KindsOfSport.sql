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