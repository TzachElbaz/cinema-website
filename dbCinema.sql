USE [master]
GO
/****** Object:  Database [dbCinema]    Script Date: 26/04/2022 14:59:13 ******/
CREATE DATABASE [dbCinema]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbCinema', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbCinema.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbCinema_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\dbCinema_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [dbCinema] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbCinema].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbCinema] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbCinema] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbCinema] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbCinema] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbCinema] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbCinema] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbCinema] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbCinema] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbCinema] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbCinema] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbCinema] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbCinema] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbCinema] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbCinema] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbCinema] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbCinema] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbCinema] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbCinema] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbCinema] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbCinema] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbCinema] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbCinema] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbCinema] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbCinema] SET  MULTI_USER 
GO
ALTER DATABASE [dbCinema] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbCinema] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbCinema] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbCinema] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbCinema] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbCinema] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbCinema] SET QUERY_STORE = OFF
GO
USE [dbCinema]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 26/04/2022 14:59:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientID] [nvarchar](9) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Phone] [nvarchar](11) NULL,
	[Password] [nvarchar](16) NOT NULL,
	[CreditCardNumber] [nvarchar](20) NULL,
	[Role] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 26/04/2022 14:59:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Director] [nvarchar](50) NOT NULL,
	[MovieLength] [nvarchar](5) NULL,
	[Summary] [nvarchar](max) NOT NULL,
	[PosterPhoto] [nvarchar](max) NOT NULL,
	[NumberOfScreenings] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 26/04/2022 14:59:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [nvarchar](9) NOT NULL,
	[MovieID] [int] NOT NULL,
	[ScreeningID] [int] NOT NULL,
	[numberOfTickets] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Screenings]    Script Date: 26/04/2022 14:59:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Screenings](
	[ScreeningID] [int] IDENTITY(1,1) NOT NULL,
	[MovieID] [int] NOT NULL,
	[Day] [nvarchar](10) NULL,
	[Date] [date] NOT NULL,
	[Hour] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_Screenings_1] PRIMARY KEY CLUSTERED 
(
	[ScreeningID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Clients] ([ClientID], [FirstName], [LastName], [Email], [Phone], [Password], [CreditCardNumber], [Role]) VALUES (N'012345678', N'Admin1', N'Admin2', N'Admin@Admin.com', N'', N'Admin123', N'', N'Admin')
INSERT [dbo].[Clients] ([ClientID], [FirstName], [LastName], [Email], [Phone], [Password], [CreditCardNumber], [Role]) VALUES (N'112233445', N'Rina', N'Levi', N'rina@gmail.com', N'0541111117', N'rina123', N'1112223330010100', N'User')
INSERT [dbo].[Clients] ([ClientID], [FirstName], [LastName], [Email], [Phone], [Password], [CreditCardNumber], [Role]) VALUES (N'123456789', N'Simcha', N'Cohen', N'simcha@hotmail.co.il', N'', N'123456', N'1122334455667788', N'User')
INSERT [dbo].[Clients] ([ClientID], [FirstName], [LastName], [Email], [Phone], [Password], [CreditCardNumber], [Role]) VALUES (N'305542979', N'Tsah', N'Elbaz', N'tsah.elbaz@gmail.com', N'', N'Te20491', N'1112223334445567', N'User')
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieID], [Title], [Director], [MovieLength], [Summary], [PosterPhoto], [NumberOfScreenings]) VALUES (2, N'Spider-Man: No Way Home', N'Jon Watts', N'02:28', N'With Spider-Man''s identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.', N'assets\posters\spiderman.jpg', 3)
INSERT [dbo].[Movies] ([MovieID], [Title], [Director], [MovieLength], [Summary], [PosterPhoto], [NumberOfScreenings]) VALUES (3, N'Encanto', N'Walt Disney', N'01:42', N'A Colombian teenage girl has to face the frustration of being the only member of her family without magical powers.', N'assets\posters\encanto.jpg', 2)
INSERT [dbo].[Movies] ([MovieID], [Title], [Director], [MovieLength], [Summary], [PosterPhoto], [NumberOfScreenings]) VALUES (4, N'Dune', N'
Denis Villeneuve', N'02:35', N'A noble family becomes embroiled in a war for control over the galaxy''s most valuable asset while its scion becomes troubled by visions of a dark future.', N'assets\posters\dune.jpg', 2)
INSERT [dbo].[Movies] ([MovieID], [Title], [Director], [MovieLength], [Summary], [PosterPhoto], [NumberOfScreenings]) VALUES (5, N'The Matrix Resurrections', N'The Matrix Resurrections', N'02:28', N'Return to a world of two realities: one, everyday life; the other, what lies behind it. To find out if his reality is a construct, to truly know himself, Mr. Anderson will have to choose to follow the white rabbit once more.', N'assets\posters\matrix4.jpg', 0)
INSERT [dbo].[Movies] ([MovieID], [Title], [Director], [MovieLength], [Summary], [PosterPhoto], [NumberOfScreenings]) VALUES (6, N'Pain And Glory', N'
Pedro Almodóvar', N'01:53', N'A film director reflects on the choices he''s made in life as the past and present come crashing down around him.', N'assets\posters\pain and glory.jpg', 2)
INSERT [dbo].[Movies] ([MovieID], [Title], [Director], [MovieLength], [Summary], [PosterPhoto], [NumberOfScreenings]) VALUES (9, N'The Secrets of Dumbledore', N'David Yates', N'02:22', N'The third installment of "Fantastic Beasts and Where to Find Them," which follows the continuing adventures of Newt Scamander.', N'assets\posters\the secrets of dumbledor.jpg', 2)
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderID], [ClientID], [MovieID], [ScreeningID], [numberOfTickets]) VALUES (18, N'305542979', 9, 35, 2)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [MovieID], [ScreeningID], [numberOfTickets]) VALUES (21, N'112233445', 3, 4, 3)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [MovieID], [ScreeningID], [numberOfTickets]) VALUES (25, N'112233445', 2, 1, 1)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [MovieID], [ScreeningID], [numberOfTickets]) VALUES (31, N'123456789', 3, 37, 2)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [MovieID], [ScreeningID], [numberOfTickets]) VALUES (49, N'112233445', 6, 36, 1)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [MovieID], [ScreeningID], [numberOfTickets]) VALUES (51, N'305542979', 6, 41, 8)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Screenings] ON 

INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (1, 2, N'Thursday', CAST(N'2022-04-14' AS Date), N'19:30')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (4, 3, N'Friday', CAST(N'2022-04-15' AS Date), N'12:00')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (6, 4, N'Friday', CAST(N'2022-04-15' AS Date), N'20:00')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (24, 2, N'Saturday', CAST(N'2022-04-16' AS Date), N'22:15')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (25, 4, N'Sunday', CAST(N'2022-04-17' AS Date), N'20:30')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (35, 9, N'Friday', CAST(N'2022-04-22' AS Date), N'22:30')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (36, 6, N'Friday', CAST(N'2022-04-22' AS Date), N'22:45')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (37, 3, N'Saturday', CAST(N'2022-04-23' AS Date), N'21:41')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (41, 6, N'Friday', CAST(N'2022-04-29' AS Date), N'21:45')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (43, 9, N'Friday', CAST(N'2022-04-29' AS Date), N'22:15')
INSERT [dbo].[Screenings] ([ScreeningID], [MovieID], [Day], [Date], [Hour]) VALUES (46, 2, N'Saturday', CAST(N'2022-04-30' AS Date), N'20:45')
SET IDENTITY_INSERT [dbo].[Screenings] OFF
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Movies]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Screenings] FOREIGN KEY([ScreeningID])
REFERENCES [dbo].[Screenings] ([ScreeningID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Screenings]
GO
ALTER TABLE [dbo].[Screenings]  WITH CHECK ADD  CONSTRAINT [FK_Screenings_Movies] FOREIGN KEY([MovieID])
REFERENCES [dbo].[Movies] ([MovieID])
GO
ALTER TABLE [dbo].[Screenings] CHECK CONSTRAINT [FK_Screenings_Movies]
GO
USE [master]
GO
ALTER DATABASE [dbCinema] SET  READ_WRITE 
GO
