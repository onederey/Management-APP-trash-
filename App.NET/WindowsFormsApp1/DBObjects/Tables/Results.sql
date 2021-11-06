use OlympiadDB;
GO

IF OBJECT_ID('dbo.Results') IS NOT NULL
BEGIN
	DROP TABLE [dbo].[Results]
END
GO

IF OBJECT_ID('dbo.Results') IS NULL
BEGIN
	CREATE TABLE [dbo].[Results]
	(
		[ParticipantID] INT,
		[Place] SMALLINT NOT NULL,
		[Result] NVARCHAR(256) NOT NULL,
		CHECK (Place > 0),
		FOREIGN KEY (ParticipantID) REFERENCES Participants(ParticipantID)
	)
END;
GO

INSERT INTO [dbo].[Results] (ParticipantID, Place, Result)
VALUES
	(100, 1, RAND(6)),
	(101, 2, RAND(6)),
	(102, 4, RAND(6)),
	(103, 1, RAND(6)),
	(104, 6, RAND(6)),
	(105, 1, RAND(6)),
	(106, 2, RAND(6))

