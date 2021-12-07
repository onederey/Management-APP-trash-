USE [master]
GO
/****** Object:  Database [OlympiadDB]    Script Date: 08.12.2021 2:46:11 ******/
CREATE DATABASE [OlympiadDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OlympiadDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OlympiadDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OlympiadDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\OlympiadDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OlympiadDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OlympiadDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OlympiadDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OlympiadDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OlympiadDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OlympiadDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OlympiadDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [OlympiadDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OlympiadDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OlympiadDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OlympiadDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OlympiadDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OlympiadDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OlympiadDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OlympiadDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OlympiadDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OlympiadDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OlympiadDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OlympiadDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OlympiadDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OlympiadDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OlympiadDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OlympiadDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OlympiadDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OlympiadDB] SET RECOVERY FULL 
GO
ALTER DATABASE [OlympiadDB] SET  MULTI_USER 
GO
ALTER DATABASE [OlympiadDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OlympiadDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OlympiadDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OlympiadDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OlympiadDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OlympiadDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'OlympiadDB', N'ON'
GO
ALTER DATABASE [OlympiadDB] SET QUERY_STORE = OFF
GO
USE [OlympiadDB]
GO
/****** Object:  Table [dbo].[Participants]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participants](
	[CountryID] [int] NULL,
	[SportID] [int] NULL,
	[ParticipantID] [int] IDENTITY(100,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[SecondName] [nvarchar](30) NULL,
	[DateOfBirth] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ParticipantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ParticipantsFromRussia]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ParticipantsFromRussia] AS
SELECT *
FROM [dbo].[Participants]
WHERE [CountryID] = 1;
GO
/****** Object:  Table [dbo].[KindsOfSport]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KindsOfSport](
	[KindID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[IsIndividual] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KindID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[ParticipantID] [int] NULL,
	[Place] [smallint] NOT NULL,
	[Result] [nvarchar](256) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ResultsSum]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ResultsSum] AS
	SELECT [Place], [Result], [CountryName], K.[Name] as Sport, [FirstName] + ' ' + [LastName] as Participant
	FROM [dbo].[Results] as R
	INNER JOIN [dbo].[Participants] as P on P.ParticipantID = R.ParticipantID
	INNER JOIN [dbo].[Country] as C on C.ID = P.CountryID
	INNER JOIN [dbo].[KindsOfSport] as K on K.KindID = P.SportID
GO
/****** Object:  View [dbo].[MedalsCount]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[MedalsCount] AS
	SELECT COUNT(*) as MedalsCount, K.[Name] as Sport
	FROM [dbo].[Results] as R
	INNER JOIN [dbo].[Participants] as P on P.ParticipantID = R.ParticipantID
	INNER JOIN [dbo].[KindsOfSport] as K on K.KindID = P.SportID
	GROUP BY K.Name
GO
/****** Object:  Table [dbo].[Courts]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courts](
	[CourtID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[Location] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CourtID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[ReportName] [nvarchar](50) NOT NULL,
	[StoredProcedure] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[SportID] [int] NULL,
	[CourtID] [int] NULL,
	[StartDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (1, N'Russia')
INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (2, N'USA')
INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (3, N'Japan')
INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (4, N'China')
INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (5, N'UK')
INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (6, N'Germany')
INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (7, N'Norway')
INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (8, N'Sweden')
INSERT [dbo].[Country] ([ID], [CountryName]) VALUES (9, N'Finland')
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[Courts] ON 

INSERT [dbo].[Courts] ([CourtID], [Name], [Location]) VALUES (1, N'Swimming Pool', N'Main Hall')
INSERT [dbo].[Courts] ([CourtID], [Name], [Location]) VALUES (2, N'Tennis Court', N'North Hall')
INSERT [dbo].[Courts] ([CourtID], [Name], [Location]) VALUES (3, N'Skate Park', N'North Hall')
INSERT [dbo].[Courts] ([CourtID], [Name], [Location]) VALUES (4, N'Stadium', N'Main Hall')
INSERT [dbo].[Courts] ([CourtID], [Name], [Location]) VALUES (5, N'Small Stadium', N'West Hall')
SET IDENTITY_INSERT [dbo].[Courts] OFF
GO
SET IDENTITY_INSERT [dbo].[KindsOfSport] ON 

INSERT [dbo].[KindsOfSport] ([KindID], [Name], [IsIndividual]) VALUES (1, N'Tennis', 1)
INSERT [dbo].[KindsOfSport] ([KindID], [Name], [IsIndividual]) VALUES (2, N'Football', 0)
INSERT [dbo].[KindsOfSport] ([KindID], [Name], [IsIndividual]) VALUES (3, N'Skate', 1)
INSERT [dbo].[KindsOfSport] ([KindID], [Name], [IsIndividual]) VALUES (4, N'Swimming', 1)
INSERT [dbo].[KindsOfSport] ([KindID], [Name], [IsIndividual]) VALUES (5, N'American Football', 0)
INSERT [dbo].[KindsOfSport] ([KindID], [Name], [IsIndividual]) VALUES (6, N'Hockey', 0)
SET IDENTITY_INSERT [dbo].[KindsOfSport] OFF
GO
SET IDENTITY_INSERT [dbo].[Participants] ON 

INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (1, 1, 102, N'Andrei', N'Morozov', N'Vladimirovich', CAST(N'2000-04-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (2, 2, 103, N'Evgenii', N'Lad', N'', CAST(N'1995-05-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (4, 5, 105, N'Chris', N'Lamb', N'', CAST(N'1999-07-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (5, 4, 106, N'Felix', N'Chest', N'', CAST(N'2001-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (6, 6, 107, N'Andrej', N'Cheese', N'', CAST(N'2001-02-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (7, 4, 108, N'Emily', N'Cheese', N'', CAST(N'2000-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (8, 1, 109, N'Taylor', N'Swift', N'', CAST(N'2000-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (9, 2, 110, N'Bri', N'Tales', N'', CAST(N'2000-08-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Participants] ([CountryID], [SportID], [ParticipantID], [FirstName], [LastName], [SecondName], [DateOfBirth]) VALUES (1, 4, 111, N'Kate', N'Karenina', N'', CAST(N'2000-05-12T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Participants] OFF
GO
SET IDENTITY_INSERT [dbo].[Reports] ON 

INSERT [dbo].[Reports] ([ReportID], [ReportName], [StoredProcedure]) VALUES (1, N'Countries with medals', N'dbo.CountriesMedalsReport_sp')
INSERT [dbo].[Reports] ([ReportID], [ReportName], [StoredProcedure]) VALUES (2, N'Participants results', N'dbo.ParticipantsResults_sp')
INSERT [dbo].[Reports] ([ReportID], [ReportName], [StoredProcedure]) VALUES (3, N'Medium ages of participants', N'dbo.AgesOfParticipants_sp')
INSERT [dbo].[Reports] ([ReportID], [ReportName], [StoredProcedure]) VALUES (4, N'Schedule on date', N'dbo.Schedule_sp')
SET IDENTITY_INSERT [dbo].[Reports] OFF
GO
INSERT [dbo].[Results] ([ParticipantID], [Place], [Result]) VALUES (102, 4, N'0.713685')
INSERT [dbo].[Results] ([ParticipantID], [Place], [Result]) VALUES (103, 1, N'0.713685')
INSERT [dbo].[Results] ([ParticipantID], [Place], [Result]) VALUES (105, 1, N'0.713685')
INSERT [dbo].[Results] ([ParticipantID], [Place], [Result]) VALUES (106, 2, N'0.713685')
GO
INSERT [dbo].[Schedule] ([SportID], [CourtID], [StartDateTime]) VALUES (1, 2, CAST(N'2021-12-01T10:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([SportID], [CourtID], [StartDateTime]) VALUES (2, 4, CAST(N'2021-12-01T12:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([SportID], [CourtID], [StartDateTime]) VALUES (3, 3, CAST(N'2021-12-01T15:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([SportID], [CourtID], [StartDateTime]) VALUES (4, 5, CAST(N'2021-12-01T16:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([SportID], [CourtID], [StartDateTime]) VALUES (5, 4, CAST(N'2021-12-01T16:00:00.000' AS DateTime))
INSERT [dbo].[Schedule] ([SportID], [CourtID], [StartDateTime]) VALUES (6, 4, CAST(N'2021-12-01T19:00:00.000' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Courts__737584F61DF3A944]    Script Date: 08.12.2021 2:46:11 ******/
ALTER TABLE [dbo].[Courts] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KindsOfS__737584F6679C939A]    Script Date: 08.12.2021 2:46:11 ******/
ALTER TABLE [dbo].[KindsOfSport] ADD UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [index_KindsOfSport_Name]    Script Date: 08.12.2021 2:46:11 ******/
CREATE NONCLUSTERED INDEX [index_KindsOfSport_Name] ON [dbo].[KindsOfSport]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [index_Participants_FirstName]    Script Date: 08.12.2021 2:46:11 ******/
CREATE NONCLUSTERED INDEX [index_Participants_FirstName] ON [dbo].[Participants]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Participants] ADD  DEFAULT ('') FOR [SecondName]
GO
ALTER TABLE [dbo].[Participants]  WITH CHECK ADD FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
GO
ALTER TABLE [dbo].[Participants]  WITH CHECK ADD FOREIGN KEY([SportID])
REFERENCES [dbo].[KindsOfSport] ([KindID])
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD FOREIGN KEY([ParticipantID])
REFERENCES [dbo].[Participants] ([ParticipantID])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([CourtID])
REFERENCES [dbo].[Courts] ([CourtID])
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD FOREIGN KEY([SportID])
REFERENCES [dbo].[KindsOfSport] ([KindID])
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD CHECK  (([Place]>(0)))
GO
/****** Object:  StoredProcedure [dbo].[AgesOfParticipants_sp]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AgesOfParticipants_sp]
	@MinAge SMALLINT = NULL,
	@MaxAge SMALLINT = NULL
AS
BEGIN
	DECLARE @Today DATETIME = GETDATE();

	SELECT
		[p].[ParticipantID],
		[p].[FirstName] + ' ' + [p].[LastName] AS [Name],
		DATEDIFF(year, [p].[DateOfBirth], @Today) AS [Years]
	FROM
		[dbo].[Participants] as [p]
	WHERE
		(@MinAge IS NULL OR DATEDIFF(year, [p].[DateOfBirth], @Today) > @MinAge)
		AND (@MaxAge IS NULL OR DATEDIFF(year, [p].[DateOfBirth], @Today) < @MaxAge)
END
GO
/****** Object:  StoredProcedure [dbo].[CountriesMedalsReport_sp]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CountriesMedalsReport_sp]
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
/****** Object:  StoredProcedure [dbo].[ParticipantsResults_sp]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ParticipantsResults_sp]
	@Country NVARCHAR(64) = NULL,
	@Sport NVARCHAR(64) = NULL
AS
BEGIN
	SELECT
		[r].[Place],
		[r].[Result],
		[p].[ParticipantID],
		[p].[FirstName] + ' ' + [p].[LastName] AS [Name],
		[k].[Name] AS [Sport],
		[c].[CountryName]
	FROM
		[dbo].[Results] AS [r]
		INNER JOIN [dbo].[Participants] AS [p] ON [r].[ParticipantID] = [p].[ParticipantID]
		INNER JOIN [dbo].[KindsOfSport] AS [k] ON [p].[SportID] = [k].[KindID]
		INNER JOIN [dbo].[Country] AS [c] ON [p].[CountryID] = [c].[ID]
	WHERE
		(@Country IS NULL OR [c].CountryName = @Country)
		AND (@Sport IS NULL OR [k].[Name] = @Sport)
END
GO
/****** Object:  StoredProcedure [dbo].[Schedule_sp]    Script Date: 08.12.2021 2:46:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Schedule_sp]
	@CurrentDate DATE = NULL
AS
BEGIN
	SELECT
		[s].[StartDateTime],
		[k].[Name],
		[c].[Name] as [CourtName],
		[c].[Location]
	FROM
		[dbo].[Schedule] AS [s]
		INNER JOIN [dbo].[KindsOfSport] AS [k] ON [s].[SportID] = [k].[KindID]
		INNER JOIN [dbo].[Courts] AS [c] ON [c].[CourtID] = [s].[CourtID]
	WHERE
		CAST([s].[StartDateTime] AS DATE) = @CurrentDate
		OR @CurrentDate IS NULL
END
GO
USE [master]
GO
ALTER DATABASE [OlympiadDB] SET  READ_WRITE 
GO
