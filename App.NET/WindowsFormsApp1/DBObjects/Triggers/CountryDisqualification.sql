use OlympiadDB;
GO

CREATE TRIGGER CountryDisqualification
ON [dbo].[Country]
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM [dbo].[Results]
	WHERE [ParticipantID] in 
		(
			SELECT P.[ParticipantID] 
			FROM DELETED as D
			INNER JOIN [dbo].[Participants] as P on P.[CountryID] = D.[ID]
		)

	DELETE FROM [dbo].[Participants]
	WHERE [ParticipantID] in 
		(
			SELECT P.[ParticipantID] 
			FROM DELETED as D
			INNER JOIN [dbo].[Participants] as P on P.[CountryID] = D.[ID]
		)

		DELETE FROM [dbo].[Country]
		WHERE [ID] in (SELECT ID FROM DELETED)
END