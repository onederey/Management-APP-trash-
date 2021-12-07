use OlympiadDB;
GO

CREATE TRIGGER ParticipantDelete
ON [dbo].[Participants]
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM [dbo].[Results]
	WHERE [ParticipantID] in (SELECT [ParticipantID] FROM DELETED)

	DELETE FROM [dbo].[Participants]
	WHERE [ParticipantID] in (SELECT [ParticipantID] FROM DELETED)
END