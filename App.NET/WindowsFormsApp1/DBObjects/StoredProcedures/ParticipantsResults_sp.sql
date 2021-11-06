use OlympiadDB;
GO

IF OBJECT_ID('dbo.ParticipantsResults_sp') IS NOT NULL
BEGIN
	DROP PROCEDURE dbo.ParticipantsResults_sp
END

GO

CREATE PROCEDURE dbo.ParticipantsResults_sp
	@Country NVARCHAR(64) = NULL,
	@Sport NVARCHAR(64) = NULL
AS
BEGIN
	SELECT
		[r].[Place],
		[r].[Result],
		[p].[ParticipantID],
		[p].[FirstName] + ' ' + [p].[LastName] AS [Name],
		[k].[Name] AS [Sport],
		[c].[CountryName]
	FROM
		[dbo].[Results] AS [r]
		INNER JOIN [dbo].[Participants] AS [p] ON [r].[ParticipantID] = [p].[ParticipantID]
		INNER JOIN [dbo].[KindsOfSport] AS [k] ON [p].[SportID] = [k].[KindID]
		INNER JOIN [dbo].[Country] AS [c] ON [p].[CountryID] = [c].[ID]
	WHERE
		(@Country IS NULL OR [c].CountryName = @Country)
		AND (@Sport IS NULL OR [k].[Name] = @Sport)
END