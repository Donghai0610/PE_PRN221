USE [master]
GO
/****** Object:  Database [PE_PRN_Fall2023B1]    Script Date: 10/24/2023 12:21:52 PM ******/
CREATE DATABASE [PE_PRN_Fall2023B1]
GO
USE [PE_PRN_Fall2023B1]
GO
/****** Object:  Table [dbo].[Directors]    Script Date: 10/24/2023 12:21:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Dob] [date] NULL,
	[Description] [nvarchar](max) NULL,
	[Male] [bit] NULL,
	[Nationality] [nvarchar](255) NULL,
 CONSTRAINT [PK__Director__3214EC07A4471AD5] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 10/24/2023 12:21:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK__Genres__3214EC07D06A88DE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Genre]    Script Date: 10/24/2023 12:21:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Genre](
	[MovieId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Star]    Script Date: 10/24/2023 12:21:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Star](
	[MovieId] [int] NOT NULL,
	[StarId] [int] NOT NULL,
	[Position] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[StarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 10/24/2023 12:21:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Year] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[DirectorId] [int] NOT NULL,
 CONSTRAINT [PK__Movies__3214EC07B9A2F7FE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 10/24/2023 12:21:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Capacity] [int] NULL,
 CONSTRAINT [PK__Room__3214EC0726CB72F3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedules]    Script Date: 10/24/2023 12:21:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MovieId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[TimeSlotId] [int] NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stars]    Script Date: 10/24/2023 12:21:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Male] [bit] NULL,
	[Description] [nvarchar](max) NULL,
	[Dob] [date] NULL,
	[Nationality] [nvarchar](255) NULL,
 CONSTRAINT [PK__Stars__3214EC07B96D5273] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeSlots]    Script Date: 10/24/2023 12:21:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeSlots](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
 CONSTRAINT [PK__TimeSlot__3214EC07D64F6E27] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Directors] ON 
GO
INSERT [dbo].[Directors] ([Id], [Name], [Dob], [Description], [Male], [Nationality]) VALUES (1, N'Christopher Nolan', CAST(N'1970-07-30' AS Date), N'British-American director', 1, N'British')
GO
INSERT [dbo].[Directors] ([Id], [Name], [Dob], [Description], [Male], [Nationality]) VALUES (2, N'Quentin Tarantino', CAST(N'1963-03-27' AS Date), N'American director', 1, N'American')
GO
INSERT [dbo].[Directors] ([Id], [Name], [Dob], [Description], [Male], [Nationality]) VALUES (3, N'Greta Gerwig', CAST(N'1983-08-04' AS Date), N'American director', 0, N'American')
GO
INSERT [dbo].[Directors] ([Id], [Name], [Dob], [Description], [Male], [Nationality]) VALUES (4, N'James Cameron', CAST(N'1954-08-16' AS Date), N'Canadian director', 1, N'Canadian')
GO
INSERT [dbo].[Directors] ([Id], [Name], [Dob], [Description], [Male], [Nationality]) VALUES (5, N'Steven Spielberg', CAST(N'1946-12-18' AS Date), N'American director', 1, N'American')
GO
INSERT [dbo].[Directors] ([Id], [Name], [Dob], [Description], [Male], [Nationality]) VALUES (6, N'Martin Scorsese', CAST(N'1942-11-17' AS Date), N'American director', 1, N'American')
GO
INSERT [dbo].[Directors] ([Id], [Name], [Dob], [Description], [Male], [Nationality]) VALUES (7, N'Ridley Scott', CAST(N'1937-11-30' AS Date), N'British director', 1, N'British')
GO
SET IDENTITY_INSERT [dbo].[Directors] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (1, N'Science Fiction', N'Movies with futuristic and scientific themes')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (2, N'Thriller', N'Movies that create tension and excitement')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (3, N'Crime', N'Movies involving criminal activities')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (4, N'Drama', N'Movies focused on realistic characters and emotions')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (5, N'Romance', N'Movies about romantic relationships')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (6, N'Adventure', N'Movies filled with action and excitement')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (7, N'Action', N'Movies filled with action and excitement')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (8, N'Comedy', N'Movies meant to make you laugh')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (9, N'Horror', N'Movies designed to scare the audience')
GO
INSERT [dbo].[Genres] ([Id], [Title], [Description]) VALUES (10, N'Fantasy', N'Movies featuring magical or otherworldly elements')
GO
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (1, 1)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (1, 2)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (2, 3)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (2, 4)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 4)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 5)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (4, 4)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (4, 6)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (5, 1)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (5, 6)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (6, 1)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (6, 6)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (7, 1)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (7, 2)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (8, 1)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (8, 6)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (9, 3)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (9, 5)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (10, 3)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (10, 8)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (1, 1, N'Lead Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (1, 2, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (1, 3, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (2, 4, N'Lead Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (2, 5, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (2, 6, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (3, 3, N'Lead Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (3, 5, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (3, 7, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (4, 1, N'Lead Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (4, 3, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (4, 7, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (5, 8, N'Lead Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (5, 9, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (5, 10, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (6, 1, N'Lead Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (6, 9, N'Lead Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (6, 10, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (7, 2, N'Lead Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (7, 3, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (7, 4, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (8, 5, N'Lead Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (8, 6, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (8, 7, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (9, 8, N'Lead Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (9, 9, N'Supporting Female')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (9, 10, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (10, 1, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (10, 2, N'Supporting Male')
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId], [Position]) VALUES (10, 10, N'Lead Female')
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (1, N'Inception', 2010, N'Science fiction thriller', 1)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (2, N'Pulp Fiction', 1994, N'Crime drama', 2)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (3, N'Little Women', 2019, N'Period drama', 3)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (4, N'The Revenant', 2015, N'Survival drama', 1)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (5, N'Avatar', 2009, N'Science fiction adventure', 4)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (6, N'The Avengers', 2012, N'Superhero action', 5)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (7, N'The Dark Knight', 2008, N'Superhero action', 1)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (8, N'Jurassic Park', 1993, N'Science fiction adventure', 6)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (9, N'The Godfather', 1972, N'Crime drama', 7)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year], [Description], [DirectorId]) VALUES (10, N'E.T. the Extra-Terrestrial', 1982, N'Science fiction adventure', 5)
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 
GO
INSERT [dbo].[Rooms] ([Id], [Title], [Capacity]) VALUES (1, N'Room A', 150)
GO
INSERT [dbo].[Rooms] ([Id], [Title], [Capacity]) VALUES (2, N'Room B', 200)
GO
INSERT [dbo].[Rooms] ([Id], [Title], [Capacity]) VALUES (3, N'Room C', 120)
GO
INSERT [dbo].[Rooms] ([Id], [Title], [Capacity]) VALUES (4, N'Room D', 180)
GO
INSERT [dbo].[Rooms] ([Id], [Title], [Capacity]) VALUES (5, N'Room E', 160)
GO
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Schedules] ON 
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (281, 1, 1, 1, CAST(N'2023-10-01' AS Date), CAST(N'2023-10-08' AS Date), N'Special screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (282, 1, 2, 2, CAST(N'2023-10-09' AS Date), CAST(N'2023-10-16' AS Date), N'Regular screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (283, 1, 3, 3, CAST(N'2023-10-17' AS Date), CAST(N'2023-10-24' AS Date), N'Matinee show')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (284, 2, 1, 3, CAST(N'2023-10-18' AS Date), CAST(N'2023-10-25' AS Date), N'Special event')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (285, 2, 4, 1, CAST(N'2023-10-02' AS Date), CAST(N'2023-10-09' AS Date), N'Opening night')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (286, 2, 5, 2, CAST(N'2023-10-10' AS Date), CAST(N'2023-10-17' AS Date), N'Matinee show')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (287, 3, 1, 5, CAST(N'2023-10-11' AS Date), CAST(N'2023-10-18' AS Date), N'Special event')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (288, 3, 2, 1, CAST(N'2023-10-19' AS Date), CAST(N'2023-10-26' AS Date), N'Regular screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (289, 3, 5, 4, CAST(N'2023-10-03' AS Date), CAST(N'2023-10-10' AS Date), N'Exclusive premiere')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (290, 4, 1, 4, CAST(N'2023-10-20' AS Date), CAST(N'2023-10-27' AS Date), N'Special screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (291, 4, 2, 3, CAST(N'2023-10-12' AS Date), CAST(N'2023-10-19' AS Date), N'Matinee show')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (292, 4, 3, 2, CAST(N'2023-10-04' AS Date), CAST(N'2023-10-11' AS Date), N'Regular screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (293, 5, 1, 1, CAST(N'2023-10-18' AS Date), CAST(N'2023-10-22' AS Date), N'Opening night')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (294, 5, 3, 2, CAST(N'2023-10-26' AS Date), CAST(N'2023-10-30' AS Date), N'Special screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (295, 5, 4, 3, CAST(N'2023-10-21' AS Date), CAST(N'2023-10-25' AS Date), N'Regular screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (296, 6, 2, 4, CAST(N'2023-10-16' AS Date), CAST(N'2023-10-20' AS Date), N'Special screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (297, 6, 3, 5, CAST(N'2023-10-24' AS Date), CAST(N'2023-10-30' AS Date), N'Regular screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (298, 6, 4, 1, CAST(N'2023-11-22' AS Date), CAST(N'2023-11-29' AS Date), N'Exclusive premiere')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (299, 7, 1, 3, CAST(N'2023-10-26' AS Date), CAST(N'2023-10-30' AS Date), N'Matinee show')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (300, 7, 2, 4, CAST(N'2023-11-23' AS Date), CAST(N'2023-11-30' AS Date), N'Special event')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (301, 7, 5, 2, CAST(N'2023-10-18' AS Date), CAST(N'2023-10-24' AS Date), N'Regular screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (302, 8, 2, 1, CAST(N'2023-10-08' AS Date), CAST(N'2023-10-15' AS Date), N'Opening night')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (303, 8, 4, 2, CAST(N'2023-10-16' AS Date), CAST(N'2023-10-23' AS Date), N'Regular screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (304, 8, 5, 3, CAST(N'2023-10-24' AS Date), CAST(N'2023-10-31' AS Date), N'Special screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (305, 9, 2, 2, CAST(N'2023-10-25' AS Date), CAST(N'2023-11-01' AS Date), N'Regular screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (306, 9, 4, 4, CAST(N'2023-10-09' AS Date), CAST(N'2023-10-16' AS Date), N'Special screening')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (307, 9, 5, 5, CAST(N'2023-10-17' AS Date), CAST(N'2023-10-24' AS Date), N'Exclusive premiere')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (308, 10, 1, 1, CAST(N'2023-10-10' AS Date), CAST(N'2023-10-17' AS Date), N'Matinee show')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (309, 10, 3, 2, CAST(N'2023-10-18' AS Date), CAST(N'2023-10-25' AS Date), N'Special event')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (310, 10, 4, 3, CAST(N'2023-10-26' AS Date), CAST(N'2023-11-02' AS Date), N'Opening night')
GO
INSERT [dbo].[Schedules] ([Id], [MovieId], [RoomId], [TimeSlotId], [StartDate], [EndDate], [Note]) VALUES (311, 2, 1, NULL, CAST(N'2023-10-06' AS Date), CAST(N'2023-10-18' AS Date), NULL)
GO
SET IDENTITY_INSERT [dbo].[Schedules] OFF
GO
SET IDENTITY_INSERT [dbo].[Stars] ON 
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (1, N'Leonardo DiCaprio', 1, N'American actor', CAST(N'1974-11-11' AS Date), N'American')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (2, N'Brad Pitt', 1, N'American actor', CAST(N'1963-12-18' AS Date), N'American')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (3, N'Saoirse Ronan', 0, N'Irish-American actress', CAST(N'1994-04-12' AS Date), N'Irish')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (4, N'Emma Watson', 0, N'British actress', CAST(N'1990-04-15' AS Date), N'British')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (5, N'Tom Hanks', 1, N'American actor', CAST(N'1956-07-09' AS Date), N'American')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (6, N'Meryl Streep', 0, N'American actress', CAST(N'1949-06-22' AS Date), N'American')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (7, N'Johnny Depp', 1, N'American actor', CAST(N'1963-06-09' AS Date), N'American')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (8, N'Scarlett Johansson', 0, N'American actress', CAST(N'1984-11-22' AS Date), N'American')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (9, N'Robert Downey Jr.', 1, N'American actor', CAST(N'1965-04-04' AS Date), N'American')
GO
INSERT [dbo].[Stars] ([Id], [Name], [Male], [Description], [Dob], [Nationality]) VALUES (10, N'Natalie Portman', 0, N'American-Israeli actress', CAST(N'1981-06-09' AS Date), N'American-Israeli')
GO
SET IDENTITY_INSERT [dbo].[Stars] OFF
GO
SET IDENTITY_INSERT [dbo].[TimeSlots] ON 
GO
INSERT [dbo].[TimeSlots] ([Id], [StartTime], [EndTime]) VALUES (1, CAST(N'09:00:00' AS Time), CAST(N'11:00:00' AS Time))
GO
INSERT [dbo].[TimeSlots] ([Id], [StartTime], [EndTime]) VALUES (2, CAST(N'12:00:00' AS Time), CAST(N'14:00:00' AS Time))
GO
INSERT [dbo].[TimeSlots] ([Id], [StartTime], [EndTime]) VALUES (3, CAST(N'15:00:00' AS Time), CAST(N'17:00:00' AS Time))
GO
INSERT [dbo].[TimeSlots] ([Id], [StartTime], [EndTime]) VALUES (4, CAST(N'18:00:00' AS Time), CAST(N'20:00:00' AS Time))
GO
INSERT [dbo].[TimeSlots] ([Id], [StartTime], [EndTime]) VALUES (5, CAST(N'21:00:00' AS Time), CAST(N'23:00:00' AS Time))
GO
SET IDENTITY_INSERT [dbo].[TimeSlots] OFF
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD  CONSTRAINT [FK__Movie_Gen__Genre__44FF419A] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Movie_Genre] CHECK CONSTRAINT [FK__Movie_Gen__Genre__44FF419A]
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD  CONSTRAINT [FK__Movie_Gen__Movie__440B1D61] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[Movie_Genre] CHECK CONSTRAINT [FK__Movie_Gen__Movie__440B1D61]
GO
ALTER TABLE [dbo].[Movie_Star]  WITH CHECK ADD  CONSTRAINT [FK__Movie_Sta__Movie__3E52440B] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[Movie_Star] CHECK CONSTRAINT [FK__Movie_Sta__Movie__3E52440B]
GO
ALTER TABLE [dbo].[Movie_Star]  WITH CHECK ADD  CONSTRAINT [FK__Movie_Sta__StarI__3F466844] FOREIGN KEY([StarId])
REFERENCES [dbo].[Stars] ([Id])
GO
ALTER TABLE [dbo].[Movie_Star] CHECK CONSTRAINT [FK__Movie_Sta__StarI__3F466844]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK__Movies__Director__398D8EEE] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Directors] ([Id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK__Movies__Director__398D8EEE]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__MovieI__5EBF139D] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK__Schedule__MovieI__5EBF139D]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__RoomId__5CD6CB2B] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Rooms] ([Id])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK__Schedule__RoomId__5CD6CB2B]
GO
ALTER TABLE [dbo].[Schedules]  WITH CHECK ADD  CONSTRAINT [FK__Schedule__TimeSl__5DCAEF64] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[TimeSlots] ([Id])
GO
ALTER TABLE [dbo].[Schedules] CHECK CONSTRAINT [FK__Schedule__TimeSl__5DCAEF64]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [CK__Room__Capacity__4AB81AF0] CHECK  (([Capacity]>=(0)))
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [CK__Room__Capacity__4AB81AF0]
GO
ALTER TABLE [dbo].[TimeSlots]  WITH CHECK ADD  CONSTRAINT [CK__TimeSlot__47DBAE45] CHECK  (([endtime]>=[StartTime]))
GO
ALTER TABLE [dbo].[TimeSlots] CHECK CONSTRAINT [CK__TimeSlot__47DBAE45]
GO
USE [master]
GO
ALTER DATABASE [PE_PRN_Fall2023B1] SET  READ_WRITE 
GO
