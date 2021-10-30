use OlympiadDB;
GO

IF OBJECT_ID('dbo.Results') IS NULL
BEGIN
	CREATE TABLE [dbo].[Results]
	(
		[SportID] INT,
		[ParticipantID] INT,
		[Place] SMALLINT NOT NULL,
		[Result] NVARCHAR(256) NOT NULL,
		CHECK (Place > 0),
		FOREIGN KEY (SportID) REFERENCES KindsOfSport(KindID),
		FOREIGN KEY (ParticipantID) REFERENCES Participants(ParticipantID)
	)
END;
GO