use OlympiadDB;
GO

IF OBJECT_ID('dbo.CountriesMedalsReport_sp') IS NOT NULL
BEGIN
	DROP PROCEDURE dbo.CountriesMedalsReport_sp
END

GO

CREATE PROCEDURE dbo.CountriesMedalsReport_sp
	@ListOfCountries NVARCHAR(500) = 'ALL'
AS
BEGIN
	SELECT 
		[c].[CountryName],
		COUNT([r].[Place]) as [MedalsCount]
	FROM 
		[dbo].[Country] AS [c]
		INNER JOIN [dbo].[Participants] AS [p]  ON [c].ID = [p].[CountryID]
		INNER JOIN [dbo].[Results] AS [r] ON [p].[ParticipantID] = [r].[ParticipantID]
	WHERE
		@ListOfCountries = 'ALL'
			OR [c].[CountryName] in (SELECT value FROM STRING_SPLIT(@ListOfCountries, ','))
	GROUP BY
		[c].[CountryName]
END
GO