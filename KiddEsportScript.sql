USE [master]
GO
/****** Object:  Database [KiddEsports]    Script Date: 27/05/2024 9:18:37 AM ******/
CREATE DATABASE [KiddEsports]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KiddEsports', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KiddEsports.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KiddEsports_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\KiddEsports_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [KiddEsports] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KiddEsports].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KiddEsports] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KiddEsports] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KiddEsports] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KiddEsports] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KiddEsports] SET ARITHABORT OFF 
GO
ALTER DATABASE [KiddEsports] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KiddEsports] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KiddEsports] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KiddEsports] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KiddEsports] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KiddEsports] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KiddEsports] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KiddEsports] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KiddEsports] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KiddEsports] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KiddEsports] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KiddEsports] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KiddEsports] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KiddEsports] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KiddEsports] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KiddEsports] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KiddEsports] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KiddEsports] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KiddEsports] SET  MULTI_USER 
GO
ALTER DATABASE [KiddEsports] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KiddEsports] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KiddEsports] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KiddEsports] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KiddEsports] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KiddEsports] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [KiddEsports] SET QUERY_STORE = ON
GO
ALTER DATABASE [KiddEsports] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KiddEsports]
GO
/****** Object:  User [Temp]    Script Date: 27/05/2024 9:18:38 AM ******/
CREATE USER [Temp] FOR LOGIN [Temporary] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 27/05/2024 9:18:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Location] [varchar](100) NOT NULL,
	[Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GamePlayed]    Script Date: 27/05/2024 9:18:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GamePlayed](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[GameType] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamResults]    Script Date: 27/05/2024 9:18:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventHeldId] [int] NULL,
	[GamePlayedId] [int] NULL,
	[Team1Id] [int] NULL,
	[Team2Id] [int] NULL,
	[Result] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 27/05/2024 9:18:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[PrimaryContact] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[CompPoints] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TeamResults]  WITH CHECK ADD FOREIGN KEY([EventHeldId])
REFERENCES [dbo].[Events] ([Id])
GO
ALTER TABLE [dbo].[TeamResults]  WITH CHECK ADD FOREIGN KEY([GamePlayedId])
REFERENCES [dbo].[GamePlayed] ([Id])
GO
ALTER TABLE [dbo].[TeamResults]  WITH CHECK ADD FOREIGN KEY([Team1Id])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[TeamResults]  WITH CHECK ADD FOREIGN KEY([Team2Id])
REFERENCES [dbo].[Teams] ([Id])
GO
USE [master]
GO
ALTER DATABASE [KiddEsports] SET  READ_WRITE 
GO
