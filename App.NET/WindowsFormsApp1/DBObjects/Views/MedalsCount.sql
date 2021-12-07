use OlympiadDB;
GO

DROP VIEW [MedalsCount]

GO

CREATE VIEW [MedalsCount] AS
	SELECT COUNT(*) as MedalsCount, K.[Name] as Sport
	FROM [dbo].[Results] as R
	INNER JOIN [dbo].[Participants] as P on P.ParticipantID = R.ParticipantID
	INNER JOIN [dbo].[KindsOfSport] as K on K.KindID = P.SportID
	GROUP BY K.Name