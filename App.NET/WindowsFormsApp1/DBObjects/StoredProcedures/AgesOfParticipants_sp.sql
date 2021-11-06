use OlympiadDB;
GO

IF OBJECT_ID('dbo.AgesOfParticipants_sp') IS NOT NULL
BEGIN
	DROP PROCEDURE dbo.AgesOfParticipants_sp
END

GO

CREATE PROCEDURE dbo.AgesOfParticipants_sp
	@MinAge SMALLINT = NULL,
	@MaxAge SMALLINT = NULL
AS
BEGIN
	DECLARE @Today DATETIME = GETDATE();

	SELECT
		[p].[ParticipantID],
		[p].[FirstName] + ' ' + [p].[LastName] AS [Name],
		DATEDIFF(year, [p].[DateOfBirth], @Today) AS [Years]
	FROM
		[dbo].[Participants] as [p]
	WHERE
		(@MinAge IS NULL OR DATEDIFF(year, [p].[DateOfBirth], @Today) > @MinAge)
		AND (@MaxAge IS NULL OR DATEDIFF(year, [p].[DateOfBirth], @Today) < @MaxAge)
END