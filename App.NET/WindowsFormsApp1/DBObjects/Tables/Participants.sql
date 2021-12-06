--DEFAULT, CHECK, FOREIGN KEY
use OlympiadDB;
GO

IF OBJECT_ID('dbo.Participants') IS NULL
BEGIN
	CREATE TABLE [dbo].[Participants]
	(
		[CountryID] INT,
		[SportID] INT,
		[ParticipantID] INT IDENTITY(100,1),
		[FirstName] NVARCHAR(30) NOT NULL,
		[LastName] NVARCHAR(30) NOT NULL,
		[SecondName] NVARCHAR(30) DEFAULT '',
		[DateOfBirth] DATETIME NOT NULL,
		PRIMARY KEY (ParticipantID),
		FOREIGN KEY (SportID) REFERENCES KindsOfSport(KindID),
		FOREIGN KEY (CountryID) REFERENCES Country(ID)
	)
END;
GO

INSERT INTO [dbo].[Participants] (CountryID, SportID, FirstName, LastName, SecondName, DateOfBirth)
VALUES
	( 1, 1, 'Andrei', 'Morozov', 'Vladimirovich', '29.04.2000'),
	( 2, 2, 'Evgenii', 'Lad', '', '05.05.1995'),
	( 3, 1, 'Mark', 'Forest', 'Chris', '12.01.1998'),
	( 4, 5, 'Chris', 'Lamb', '', '07.10.1999'),
	( 5, 4, 'Felix', 'Chest', '', '12.12.2001'),
	( 6, 6, 'Andrej', 'Cheese', '', '28.02.2001'),
	( 7, 4, 'Emily', 'Cheese', '', '03.04.2000'),
	( 8, 1, 'Taylor', 'Swift', '', '03.04.2000'),
	( 9, 2, 'Bri', 'Tales', '', '08.09.2000'),
	( 1, 4, 'Kate', 'Karenina', '', '05.12.2000')

GO

CREATE INDEX index_Participants_FirstName
ON dbo.Participants(FirstName);