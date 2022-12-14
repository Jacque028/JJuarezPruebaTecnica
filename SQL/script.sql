USE [master]
GO
/****** Object:  Database [JJuarezPruebaTecnica]    Script Date: 12/9/2022 6:35:38 PM ******/
CREATE DATABASE [JJuarezPruebaTecnica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JJuarezPruebaTecnica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JJuarezPruebaTecnica.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JJuarezPruebaTecnica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JJuarezPruebaTecnica_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JJuarezPruebaTecnica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET ARITHABORT OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET RECOVERY FULL 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET  MULTI_USER 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JJuarezPruebaTecnica', N'ON'
GO
USE [JJuarezPruebaTecnica]
GO
/****** Object:  StoredProcedure [dbo].[LibroAdd]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroAdd]
@Nombre  VARCHAR(50),
@IdAutor INT,
@NumeroPaginas INT, 
@FechaPublicacion VARCHAR(20),
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS 
INSERT INTO Libro(Nombre, IdAutor, NumeroPaginas, FechaPublicacion, IdEditorial, Edicion, IdGenero) 
VALUES (@Nombre,
		@IdAutor,
		@NumeroPaginas,
		CONVERT (DATE,@FechaPublicacion,105), 
		@IdEditorial,
		@Edicion,
		@IdGenero);
GO
/****** Object:  StoredProcedure [dbo].[LibroDelete]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroDelete]
@IdLibro INT 
AS 
DELETE FROM Libro
WHERE Libro.[IdLibro] = @IdLibro; 
GO
/****** Object:  StoredProcedure [dbo].[LibroGetAll]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetAll]AS	SELECT [IdLibro]      ,Libro.[Nombre]      ,Autor.[IdAutor]	  ,Autor.[Nombre] AS NombreAutor      ,Libro.[NumeroPaginas]      ,Libro.[FechaPublicacion]      ,Editorial.[IdEditorial]	  ,Editorial.[Nombre] AS NombreEditorial      ,Libro.[Edicion]      ,GENERO.[IdGenero]	  ,GENERO.[Nombre] AS NombreGenero  FROM [Libro]  INNER JOIN Autor ON Autor.IdAutor = Libro.IdAutor  INNER JOIN Editorial ON Editorial.IdEditorial = Libro.IdEditorial  INNER JOIN GENERO ON GENERO.IdGenero = Libro.IdGenero
GO
/****** Object:  StoredProcedure [dbo].[LibroGetById]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroGetById]@IdLibro INT ASSELECT Libro.[IdLibro]      ,Libro.[Nombre]      ,Autor.[IdAutor]	  ,Autor.[Nombre] AS 'NombreAutor'      ,Libro.[NumeroPaginas]      ,Libro.[FechaPublicacion]      ,Editorial.[IdEditorial]	  ,Editorial.[Nombre] AS 'NombreEditorial'      ,Libro.[Edicion]      ,GENERO.[IdGenero]	  ,GENERO.[Nombre] AS 'NombreGenero'FROM Libro  INNER JOIN Autor ON Autor.IdAutor = Libro.IdAutor  INNER JOIN Editorial ON Editorial.IdEditorial = Libro.IdEditorial  INNER JOIN GENERO ON GENERO.IdGenero = Libro.IdGeneroWHERE Libro.[IdLibro] = @IdLibro; 
GO
/****** Object:  StoredProcedure [dbo].[LibroUpdate]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LibroUpdate] 
@IdLibro INT, 
@Nombre VARCHAR(20),
@IdAutor INT,
@NumeroPaginas INT, 
@FechaPublicacion VARCHAR(20),
@IdEditorial INT,
@Edicion VARCHAR(50),
@IdGenero INT
AS
UPDATE Libro
SET [Nombre] = @Nombre,
	[IdAutor] = @IdAutor,
	[NumeroPaginas] = @NumeroPaginas,
	[FechaPublicacion] = CONVERT (DATE, @FechaPublicacion,105), 
	[IdEditorial] = @IdEditorial,
	[Edicion] = @Edicion,
	[IdGenero] = @IdGenero
WHERE Libro.[IdLibro] = @IdLibro 
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Editorial](
	[IdEditorial] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GENERO]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GENERO](
	[IdGenero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 12/9/2022 6:35:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Libro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[IdAutor] [int] NULL,
	[NumeroPaginas] [int] NULL,
	[FechaPublicacion] [date] NULL,
	[IdEditorial] [int] NULL,
	[Edicion] [varchar](50) NULL,
	[IdGenero] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([IdAutor])
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdEditorial])
REFERENCES [dbo].[Editorial] ([IdEditorial])
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdGenero])
REFERENCES [dbo].[GENERO] ([IdGenero])
GO
USE [master]
GO
ALTER DATABASE [JJuarezPruebaTecnica] SET  READ_WRITE 
GO
