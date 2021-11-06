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

INSERT INTO dbo.Schedule (SportID, CourtID, StartDateTime)
VALUES
	(1, 2, '2021-12-01 10:00:00'),
	(2, 4, '2021-12-01 12:00:00'),
	(3, 3, '2021-12-01 15:00:00'),
	(4, 5, '2021-12-01 16:00:00'),
	(5, 4, '2021-12-01 16:00:00'),
	(6, 4, '2021-12-01 19:00:00')


