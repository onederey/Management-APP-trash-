use OlympiadDB;
GO

DROP VIEW [ParticipantsFromRussia]
GO

CREATE VIEW [ParticipantsFromRussia] AS
SELECT *
FROM [dbo].[Participants]
WHERE [CountryID] = 1;