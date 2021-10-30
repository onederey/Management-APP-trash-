use OlympiadDB;
GO

IF OBJECT_ID('dbo.Reports') IS NULL
BEGIN
	CREATE TABLE [dbo].[Reports]
	(
		[ReportID] INT IDENTITY(1,1),
		[ReportName] NVARCHAR(50) NOT NULL,
		[StoredProcedure] NVARCHAR(100) NOT NULL,
		PRIMARY KEY(ReportID)
	)
END;
GO

INSERT INTO dbo.Reports (ReportName, StoredProcedure)
VALUES 
	(N'Countries with medals', 'dbo.CountriesMedalsReport_sp'),
	(N'Participants results', N'dbo.ParticipantsResults_sp'),
	(N'Medium ages of participants', N'dbo.AgesOfParticipants_sp'),
	(N'Schedule on date', N'dbo.Schedule_sp')