USE [master]
GO
/****** Object:  Database [DB_Nimap_MachineTest]    Script Date: 03-06-2024 10:16:02 ******/
CREATE DATABASE [DB_Nimap_MachineTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Nimap_MachineTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_Nimap_MachineTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Nimap_MachineTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_Nimap_MachineTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Nimap_MachineTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DB_Nimap_MachineTest', N'ON'
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET QUERY_STORE = OFF
GO
USE [DB_Nimap_MachineTest]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 03-06-2024 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 03-06-2024 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsActive]) VALUES (1, N'Wafers', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsActive]) VALUES (2, N'Electronics', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsActive]) VALUES (3, N'Clothes', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsActive]) VALUES (1001, N'Vehicles', 1)
INSERT [dbo].[Category] ([CategoryId], [CategoryName], [IsActive]) VALUES (1002, N'Perfumes', 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId]) VALUES (1, N'Balaji', 1)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId]) VALUES (2, N'A.C', 2)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId]) VALUES (3, N'T.V', 2)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId]) VALUES (4, N'Shirts', 3)
INSERT [dbo].[Product] ([ProductId], [ProductName], [CategoryId]) VALUES (5, N'T-Shirts', 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
/****** Object:  StoredProcedure [dbo].[SpCategory]    Script Date: 03-06-2024 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpCategory]
	@CategoryId int,
    @CategoryName NVARCHAR(100),
    @IsActiv BIT,
	@IUFlag nvarchar(1)
AS
BEGIN
	if(@IUFlag='I')
	begin
    INSERT INTO Category (CategoryName,IsActive)
    VALUES (@CategoryName, @IsActiv)
	end
	if(@IUFlag='U')
	begin
	Update Category set CategoryName=@CategoryName,IsActive=@IsActiv where CategoryId=@CategoryId
	end
END;
GO
/****** Object:  StoredProcedure [dbo].[SpProduct]    Script Date: 03-06-2024 10:16:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SpProduct]
	@ProductId int,
    @ProductName NVARCHAR(100),
	@CategoryId int,
	@Flag nvarchar(1)
as begin
if(@Flag='I')
begin
    INSERT INTO Product(ProductName,CategoryId)
    VALUES (@ProductName,@CategoryId)
	end
if(@Flag='U')
begin
update Product set ProductName=@ProductName,CategoryId=@CategoryId where ProductId=@ProductId
end
end
GO
USE [master]
GO
ALTER DATABASE [DB_Nimap_MachineTest] SET  READ_WRITE 
GO
