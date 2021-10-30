use OlympiadDB;
GO

IF OBJECT_ID('dbo.Country') IS NULL
BEGIN
	CREATE TABLE [dbo].[Country]
	(
		[ID] INT NOT NULL IDENTITY(1,1),
		[CountryName] NVARCHAR(64) NOT NULL,
		PRIMARY KEY (ID)
	)
END;
GO