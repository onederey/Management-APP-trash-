use OlympiadDB;
GO

IF OBJECT_ID('dbo.Schedule') IS NULL
BEGIN
	CREATE TABLE [dbo].[Schedule]
	(
		[SportID] INT,
		[CourtID] INT,
		[StartDateTime] DATETIME NOT NULL,
		FOREIGN KEY (SportID) REFERENCES KindsOfSport(KindID),
		FOREIGN KEY (CourtID) REFERENCES Courts(CourtID)
	)
END;
GO