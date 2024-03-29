USE [master]
GO
/****** Object:  Database [AirportDispatcher]    Script Date: 20.05.2022 14:52:52 ******/
CREATE DATABASE [AirportDispatcher]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AirportDispatcher', FILENAME = N'C:\Users\311-16(student)\AirportDispatcher.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AirportDispatcher_log', FILENAME = N'C:\Users\311-16(student)\AirportDispatcher_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AirportDispatcher] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AirportDispatcher].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AirportDispatcher] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AirportDispatcher] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AirportDispatcher] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AirportDispatcher] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AirportDispatcher] SET ARITHABORT OFF 
GO
ALTER DATABASE [AirportDispatcher] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AirportDispatcher] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AirportDispatcher] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AirportDispatcher] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AirportDispatcher] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AirportDispatcher] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AirportDispatcher] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AirportDispatcher] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AirportDispatcher] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AirportDispatcher] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AirportDispatcher] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AirportDispatcher] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AirportDispatcher] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AirportDispatcher] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AirportDispatcher] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AirportDispatcher] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AirportDispatcher] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AirportDispatcher] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AirportDispatcher] SET  MULTI_USER 
GO
ALTER DATABASE [AirportDispatcher] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AirportDispatcher] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AirportDispatcher] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AirportDispatcher] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AirportDispatcher] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AirportDispatcher] SET QUERY_STORE = OFF
GO
USE [AirportDispatcher]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [AirportDispatcher]
GO
/****** Object:  Table [dbo].[Airline]    Script Date: 20.05.2022 14:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airline](
	[IdAirline] [int] IDENTITY(1,1) NOT NULL,
	[AirlineName] [nvarchar](max) NOT NULL,
	[AirlineCode] [nchar](3) NOT NULL,
 CONSTRAINT [PK_Airline] PRIMARY KEY CLUSTERED 
(
	[IdAirline] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AirportFrom]    Script Date: 20.05.2022 14:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirportFrom](
	[IdAirportFrom] [int] IDENTITY(1,1) NOT NULL,
	[AirportNameFrom] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AirportFrom] PRIMARY KEY CLUSTERED 
(
	[IdAirportFrom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AirportTo]    Script Date: 20.05.2022 14:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AirportTo](
	[IdAirportTo] [int] IDENTITY(1,1) NOT NULL,
	[AirportNameTo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AirportTo] PRIMARY KEY CLUSTERED 
(
	[IdAirportTo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 20.05.2022 14:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[NumberFlight] [nchar](7) NOT NULL,
	[IdNameAirline] [int] NOT NULL,
	[DepartureDate] [datetime] NOT NULL,
	[CountPlaceAll] [int] NOT NULL,
	[CountPlaceRemains] [int] NOT NULL,
	[AirportFrom] [int] NOT NULL,
	[AirportTo] [int] NOT NULL,
 CONSTRAINT [PK_Flight] PRIMARY KEY CLUSTERED 
(
	[NumberFlight] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passengers]    Script Date: 20.05.2022 14:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passengers](
	[NumberPassport] [nchar](11) NOT NULL,
	[PlaceGiven] [nvarchar](max) NOT NULL,
	[DateGiven] [date] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Birthday] [date] NOT NULL,
 CONSTRAINT [PK_Passengers] PRIMARY KEY CLUSTERED 
(
	[NumberPassport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 20.05.2022 14:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[NumberBooking] [nvarchar](50) NOT NULL,
	[NumberPassengerPassport] [nchar](11) NOT NULL,
	[NumberFlightTicket] [nchar](7) NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[NumberBooking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 20.05.2022 14:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Airline] ON 

INSERT [dbo].[Airline] ([IdAirline], [AirlineName], [AirlineCode]) VALUES (1, N'Уральские Авиалинии', N'URL')
INSERT [dbo].[Airline] ([IdAirline], [AirlineName], [AirlineCode]) VALUES (2, N'Контужные Авиалинии', N'KOA')
INSERT [dbo].[Airline] ([IdAirline], [AirlineName], [AirlineCode]) VALUES (3, N'Радужные Авиалинии', N'RAB')
SET IDENTITY_INSERT [dbo].[Airline] OFF
SET IDENTITY_INSERT [dbo].[AirportFrom] ON 

INSERT [dbo].[AirportFrom] ([IdAirportFrom], [AirportNameFrom]) VALUES (1, N'Кольцово')
INSERT [dbo].[AirportFrom] ([IdAirportFrom], [AirportNameFrom]) VALUES (2, N'Внукого')
INSERT [dbo].[AirportFrom] ([IdAirportFrom], [AirportNameFrom]) VALUES (3, N'Шереметьего')
SET IDENTITY_INSERT [dbo].[AirportFrom] OFF
SET IDENTITY_INSERT [dbo].[AirportTo] ON 

INSERT [dbo].[AirportTo] ([IdAirportTo], [AirportNameTo]) VALUES (1, N'Кольцово')
INSERT [dbo].[AirportTo] ([IdAirportTo], [AirportNameTo]) VALUES (2, N'Внукого')
INSERT [dbo].[AirportTo] ([IdAirportTo], [AirportNameTo]) VALUES (3, N'Шереметьего')
SET IDENTITY_INSERT [dbo].[AirportTo] OFF
INSERT [dbo].[Flight] ([NumberFlight], [IdNameAirline], [DepartureDate], [CountPlaceAll], [CountPlaceRemains], [AirportFrom], [AirportTo]) VALUES (N'KOA-007', 2, CAST(N'2022-04-13T08:04:00.000' AS DateTime), 150, 50, 1, 2)
INSERT [dbo].[Flight] ([NumberFlight], [IdNameAirline], [DepartureDate], [CountPlaceAll], [CountPlaceRemains], [AirportFrom], [AirportTo]) VALUES (N'KOA-010', 2, CAST(N'2022-04-18T08:15:00.000' AS DateTime), 150, 14, 1, 2)
INSERT [dbo].[Flight] ([NumberFlight], [IdNameAirline], [DepartureDate], [CountPlaceAll], [CountPlaceRemains], [AirportFrom], [AirportTo]) VALUES (N'RAB-010', 3, CAST(N'2022-04-26T11:15:00.000' AS DateTime), 150, 12, 2, 1)
INSERT [dbo].[Flight] ([NumberFlight], [IdNameAirline], [DepartureDate], [CountPlaceAll], [CountPlaceRemains], [AirportFrom], [AirportTo]) VALUES (N'URL-006', 1, CAST(N'2023-01-01T11:01:00.000' AS DateTime), 125, 125, 1, 3)
INSERT [dbo].[Flight] ([NumberFlight], [IdNameAirline], [DepartureDate], [CountPlaceAll], [CountPlaceRemains], [AirportFrom], [AirportTo]) VALUES (N'URL-007', 1, CAST(N'2022-04-13T03:04:00.000' AS DateTime), 150, 150, 1, 2)
INSERT [dbo].[Passengers] ([NumberPassport], [PlaceGiven], [DateGiven], [FullName], [Birthday]) VALUES (N'1234-653123', N'Город Екатеринбург', CAST(N'2020-12-19' AS Date), N'Леунов Кирилл Александрович', CAST(N'2002-12-19' AS Date))
INSERT [dbo].[Passengers] ([NumberPassport], [PlaceGiven], [DateGiven], [FullName], [Birthday]) VALUES (N'3215-829352', N'Город Москва', CAST(N'2020-07-22' AS Date), N'Леунова Ангелина Олеговна', CAST(N'2003-06-02' AS Date))
INSERT [dbo].[Passengers] ([NumberPassport], [PlaceGiven], [DateGiven], [FullName], [Birthday]) VALUES (N'3266-152904', N'Гор. Екатеринбург', CAST(N'2016-12-01' AS Date), N'Дедяева Елизавета Алексеевна', CAST(N'2002-12-01' AS Date))
INSERT [dbo].[Passengers] ([NumberPassport], [PlaceGiven], [DateGiven], [FullName], [Birthday]) VALUES (N'7124-789356', N'Город Санкт-Петербург', CAST(N'2021-11-01' AS Date), N'Мягков Николай Николаевич', CAST(N'2003-06-25' AS Date))
INSERT [dbo].[Ticket] ([NumberBooking], [NumberPassengerPassport], [NumberFlightTicket]) VALUES (N'7E5Q66D', N'3266-152904', N'KOA-010')
INSERT [dbo].[Ticket] ([NumberBooking], [NumberPassengerPassport], [NumberFlightTicket]) VALUES (N'AZ1K8AI', N'3215-829352', N'KOA-007')
INSERT [dbo].[Ticket] ([NumberBooking], [NumberPassengerPassport], [NumberFlightTicket]) VALUES (N'KRJVMJC', N'7124-789356', N'RAB-010')
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([IdUser], [Login], [Password]) VALUES (1, N'ReeLune', N'pass123')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_Airline] FOREIGN KEY([IdNameAirline])
REFERENCES [dbo].[Airline] ([IdAirline])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_Airline]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_AirportFrom] FOREIGN KEY([AirportFrom])
REFERENCES [dbo].[AirportFrom] ([IdAirportFrom])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_AirportFrom]
GO
ALTER TABLE [dbo].[Flight]  WITH CHECK ADD  CONSTRAINT [FK_Flight_AirportTo] FOREIGN KEY([AirportTo])
REFERENCES [dbo].[AirportTo] ([IdAirportTo])
GO
ALTER TABLE [dbo].[Flight] CHECK CONSTRAINT [FK_Flight_AirportTo]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Flight] FOREIGN KEY([NumberFlightTicket])
REFERENCES [dbo].[Flight] ([NumberFlight])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Flight]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Passengers] FOREIGN KEY([NumberPassengerPassport])
REFERENCES [dbo].[Passengers] ([NumberPassport])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Passengers]
GO
USE [master]
GO
ALTER DATABASE [AirportDispatcher] SET  READ_WRITE 
GO
