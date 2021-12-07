use OlympiadDB;
GO

DROP VIEW [ResultsSum]

GO

CREATE VIEW [ResultsSum] AS
	SELECT [Place], [Result], [CountryName], K.[Name] as Sport, [FirstName] + ' ' + [LastName] as Participant
	FROM [dbo].[Results] as R
	INNER JOIN [dbo].[Participants] as P on P.ParticipantID = R.ParticipantID
	INNER JOIN [dbo].[Country] as C on C.ID = P.CountryID
	INNER JOIN [dbo].[KindsOfSport] as K on K.KindID = P.SportID