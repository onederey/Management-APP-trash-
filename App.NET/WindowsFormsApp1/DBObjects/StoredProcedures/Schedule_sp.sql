use OlympiadDB;
GO

IF OBJECT_ID('dbo.Schedule_sp') IS NOT NULL
BEGIN
	DROP PROCEDURE dbo.Schedule_sp
END

GO

CREATE PROCEDURE dbo.Schedule_sp
	@CurrentDate DATE = NULL
AS
BEGIN
	SELECT
		[s].[StartDateTime],
		[k].[Name],
		[c].[Name] as [CourtName],
		[c].[Location]
	FROM
		[dbo].[Schedule] AS [s]
		INNER JOIN [dbo].[KindsOfSport] AS [k] ON [s].[SportID] = [k].[KindID]
		INNER JOIN [dbo].[Courts] AS [c] ON [c].[CourtID] = [s].[CourtID]
	WHERE
		CAST([s].[StartDateTime] AS DATE) = @CurrentDate
END