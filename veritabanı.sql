USE [master]
GO
/****** Object:  Database [ring2]    Script Date: 26.02.2021 17:04:44 ******/
CREATE DATABASE [ring2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ring2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ring2.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ring2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ring2_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ring2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ring2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ring2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ring2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ring2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ring2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ring2] SET ARITHABORT OFF 
GO
ALTER DATABASE [ring2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ring2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ring2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ring2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ring2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ring2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ring2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ring2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ring2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ring2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ring2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ring2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ring2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ring2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ring2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ring2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ring2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ring2] SET RECOVERY FULL 
GO
ALTER DATABASE [ring2] SET  MULTI_USER 
GO
ALTER DATABASE [ring2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ring2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ring2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ring2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ring2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ring2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ring2', N'ON'
GO
ALTER DATABASE [ring2] SET QUERY_STORE = OFF
GO
USE [ring2]
GO
/****** Object:  Table [dbo].[tblKullanicilar]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKullanicilar](
	[KullaniciID] [int] IDENTITY(1,1) NOT NULL,
	[GorselID] [int] NULL,
	[Admin] [bit] NULL,
 CONSTRAINT [PK_tblKullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGorseller]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGorseller](
	[GorselID] [int] IDENTITY(1,1) NOT NULL,
	[Gorsel] [image] NULL,
 CONSTRAINT [PK_tblGorseller] PRIMARY KEY CLUSTERED 
(
	[GorselID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLogin]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLogin](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [varchar](50) NULL,
	[Sifre] [nvarchar](50) NULL,
	[KullaniciID] [int] NOT NULL,
 CONSTRAINT [PK_tblLogin] PRIMARY KEY CLUSTERED 
(
	[KullaniciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Nick] UNIQUE NONCLUSTERED 
(
	[KullaniciAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[KullaniciListele]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[KullaniciListele]
AS
SELECT dbo.tblLogin.KullaniciAdi, dbo.tblGorseller.Gorsel, dbo.tblLogin.KullaniciID, dbo.tblKullanicilar.Admin
FROM     dbo.tblKullanicilar INNER JOIN
                  dbo.tblLogin ON dbo.tblKullanicilar.KullaniciID = dbo.tblLogin.KullaniciID INNER JOIN
                  dbo.tblGorseller ON dbo.tblKullanicilar.GorselID = dbo.tblGorseller.GorselID
GO
/****** Object:  Table [dbo].[tblKategoriler]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKategoriler](
	[KategoriID] [int] IDENTITY(1,1) NOT NULL,
	[KategoriAdi] [varchar](250) NULL,
 CONSTRAINT [PK_tblKategoriler] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_Kategori] UNIQUE NONCLUSTERED 
(
	[KategoriAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFilmler]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFilmler](
	[FilmID] [int] IDENTITY(1,1) NOT NULL,
	[FilmAdi] [varchar](250) NULL,
	[YonetmenID] [int] NULL,
	[KategoriID] [int] NULL,
	[GorselID] [int] NULL,
	[FilmInfo] [text] NULL,
 CONSTRAINT [PK_tblFilmler] PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UC_FilmAdi] UNIQUE NONCLUSTERED 
(
	[FilmAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblYonetmenler]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblYonetmenler](
	[YonetmenID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NULL,
 CONSTRAINT [PK_tblYonetmenler] PRIMARY KEY CLUSTERED 
(
	[YonetmenID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[FilmListele]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[FilmListele]
AS
SELECT dbo.tblFilmler.FilmAdi, dbo.tblFilmler.FilmInfo, dbo.tblGorseller.Gorsel, dbo.tblKategoriler.KategoriAdi, dbo.tblYonetmenler.Ad, dbo.tblFilmler.FilmID
FROM     dbo.tblFilmler INNER JOIN
                  dbo.tblGorseller ON dbo.tblFilmler.GorselID = dbo.tblGorseller.GorselID INNER JOIN
                  dbo.tblKategoriler ON dbo.tblFilmler.KategoriID = dbo.tblKategoriler.KategoriID INNER JOIN
                  dbo.tblYonetmenler ON dbo.tblFilmler.YonetmenID = dbo.tblYonetmenler.YonetmenID
GO
/****** Object:  Table [dbo].[tblYorumlar]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblYorumlar](
	[YorumID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NULL,
	[Yorum] [text] NULL,
	[Tarih] [datetime] NULL,
	[FilmID] [int] NULL,
 CONSTRAINT [PK_tblYorumlar] PRIMARY KEY CLUSTERED 
(
	[YorumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[YorumListele]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[YorumListele]
AS
SELECT dbo.tblYorumlar.Yorum, dbo.tblYorumlar.Tarih, dbo.tblYorumlar.FilmID, dbo.tblYorumlar.KullaniciID, dbo.tblYorumlar.YorumID, dbo.tblKullanicilar.GorselID, dbo.tblGorseller.Gorsel, dbo.tblLogin.KullaniciAdi
FROM     dbo.tblYorumlar INNER JOIN
                  dbo.tblKullanicilar ON dbo.tblYorumlar.KullaniciID = dbo.tblKullanicilar.KullaniciID INNER JOIN
                  dbo.tblGorseller ON dbo.tblKullanicilar.GorselID = dbo.tblGorseller.GorselID INNER JOIN
                  dbo.tblLogin ON dbo.tblKullanicilar.KullaniciID = dbo.tblLogin.KullaniciID
GO
/****** Object:  View [dbo].[Giris]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Giris]
AS
SELECT dbo.tblKullanicilar.KullaniciID, dbo.tblKullanicilar.Admin, dbo.tblLogin.KullaniciAdi, dbo.tblLogin.Sifre
FROM     dbo.tblKullanicilar INNER JOIN
                  dbo.tblLogin ON dbo.tblKullanicilar.KullaniciID = dbo.tblLogin.KullaniciID
GO
/****** Object:  Table [dbo].[tblLikes]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLikes](
	[LikeID] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciID] [int] NULL,
	[FilmID] [int] NULL,
	[Begendi] [bit] NULL,
 CONSTRAINT [PK_tblLikes] PRIMARY KEY CLUSTERED 
(
	[LikeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblFilmler]  WITH CHECK ADD  CONSTRAINT [FK_tblFilmler_tblGorseller] FOREIGN KEY([GorselID])
REFERENCES [dbo].[tblGorseller] ([GorselID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[tblFilmler] CHECK CONSTRAINT [FK_tblFilmler_tblGorseller]
GO
ALTER TABLE [dbo].[tblFilmler]  WITH CHECK ADD  CONSTRAINT [FK_tblFilmler_tblKategoriler] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[tblKategoriler] ([KategoriID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[tblFilmler] CHECK CONSTRAINT [FK_tblFilmler_tblKategoriler]
GO
ALTER TABLE [dbo].[tblFilmler]  WITH CHECK ADD  CONSTRAINT [FK_tblFilmler_tblYonetmenler] FOREIGN KEY([YonetmenID])
REFERENCES [dbo].[tblYonetmenler] ([YonetmenID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[tblFilmler] CHECK CONSTRAINT [FK_tblFilmler_tblYonetmenler]
GO
ALTER TABLE [dbo].[tblKategoriler]  WITH CHECK ADD  CONSTRAINT [FK_tblKategoriler_tblKategoriler] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[tblKategoriler] ([KategoriID])
GO
ALTER TABLE [dbo].[tblKategoriler] CHECK CONSTRAINT [FK_tblKategoriler_tblKategoriler]
GO
ALTER TABLE [dbo].[tblKullanicilar]  WITH CHECK ADD  CONSTRAINT [FK_tblKullanicilar_tblGorseller] FOREIGN KEY([GorselID])
REFERENCES [dbo].[tblGorseller] ([GorselID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblKullanicilar] CHECK CONSTRAINT [FK_tblKullanicilar_tblGorseller]
GO
ALTER TABLE [dbo].[tblLikes]  WITH CHECK ADD  CONSTRAINT [FK_tblLikes_tblFilmler] FOREIGN KEY([FilmID])
REFERENCES [dbo].[tblFilmler] ([FilmID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblLikes] CHECK CONSTRAINT [FK_tblLikes_tblFilmler]
GO
ALTER TABLE [dbo].[tblLikes]  WITH CHECK ADD  CONSTRAINT [FK_tblLikes_tblKullanicilar] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[tblKullanicilar] ([KullaniciID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblLikes] CHECK CONSTRAINT [FK_tblLikes_tblKullanicilar]
GO
ALTER TABLE [dbo].[tblLogin]  WITH CHECK ADD  CONSTRAINT [FK_tblLogin_tblKullanicilar] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[tblKullanicilar] ([KullaniciID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblLogin] CHECK CONSTRAINT [FK_tblLogin_tblKullanicilar]
GO
ALTER TABLE [dbo].[tblYorumlar]  WITH CHECK ADD  CONSTRAINT [FK_tblYorumlar_tblFilmler] FOREIGN KEY([FilmID])
REFERENCES [dbo].[tblFilmler] ([FilmID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblYorumlar] CHECK CONSTRAINT [FK_tblYorumlar_tblFilmler]
GO
ALTER TABLE [dbo].[tblYorumlar]  WITH CHECK ADD  CONSTRAINT [FK_tblYorumlar_tblKullanicilar] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[tblKullanicilar] ([KullaniciID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblYorumlar] CHECK CONSTRAINT [FK_tblYorumlar_tblKullanicilar]
GO
/****** Object:  StoredProcedure [dbo].[begen]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[begen](
@FilmID int,
@KullaniciID int,
@Begen bit
)
as
begin
if((select COUNT(*) from tblLikes where FilmID=@FilmID and KullaniciID=@KullaniciID)>0)
begin
update tblLikes set Begendi=@Begen where FilmID=FilmID and KullaniciID=@KullaniciID
end
else
begin
insert into tblLikes values (@KullaniciID,@FilmID,@Begen)
end
end
GO
/****** Object:  StoredProcedure [dbo].[FilmEkle]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[FilmEkle](
@FilmAdi varchar(250),
@Kategori varchar(250),
@Yonetmen varchar(50),
@Gorsel image,
@FilmInfo text
)
as
begin
insert into tblGorseller values (@Gorsel)
declare @GorselID int
set @GorselID=@@IDENTITY

if((select count(*) from tblYonetmenler where Ad=@Yonetmen)<=0)
begin
insert into tblYonetmenler values (@Yonetmen)
end

declare @YonetmenID int
set @YonetmenID=(select YonetmenID from tblYonetmenler where Ad=@Yonetmen)

if((select COUNT(*) from tblKategoriler where KategoriAdi=@Kategori)<=0)
begin
insert into tblKategoriler values (@Kategori)
end

declare @KategoriID int
set @KategoriID=(select KategoriID from tblKategoriler where KategoriAdi=@Kategori)

insert into tblFilmler values (@FilmAdi,@YonetmenID,@KategoriID,@GorselID,@FilmInfo)

end
GO
/****** Object:  StoredProcedure [dbo].[FilmSil]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[FilmSil](
@FilmID int)
as
begin
delete from tblFilmler where FilmID=@FilmID
end
GO
/****** Object:  StoredProcedure [dbo].[GirisProc]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GirisProc](
@KullaniciAdi varchar(50)
)
as
begin
    select Admin,Sifre,KullaniciID from Giris where KullaniciAdi=@KullaniciAdi
end
GO
/****** Object:  StoredProcedure [dbo].[KullaniciKayit]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[KullaniciKayit](
@KullaniciAdi varchar(50),
@Sifre nvarchar(50),
@Gorsel image
)
as 
begin
if((select count(*) from KullaniciListele where KullaniciAdi=@KullaniciAdi)<=0)
begin
insert into tblGorseller values (@Gorsel)
insert into tblKullanicilar values(@@IDENTITY,0)
insert into tblLogin values (@KullaniciAdi,@Sifre,@@IDENTITY)
return 1
end
else
begin
return 0
end
end
GO
/****** Object:  StoredProcedure [dbo].[YorumEkle]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[YorumEkle](
@KullaniciID int,
@Yorum text,
@FilmID int
)
as
begin
insert into tblYorumlar values (@KullaniciID,@Yorum,GETDATE(),@FilmID)
end
GO
/****** Object:  StoredProcedure [dbo].[YorumGuncelle]    Script Date: 26.02.2021 17:04:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[YorumGuncelle](
@YorumID int,
@Yorum text
)
as
begin
update tblYorumlar set Yorum=@Yorum,Tarih=GETDATE() where YorumID=@YorumID
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblFilmler"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "tblGorseller"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 126
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblKategoriler"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 126
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblYonetmenler"
            Begin Extent = 
               Top = 26
               Left = 1054
               Bottom = 145
               Right = 1248
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FilmListele'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'FilmListele'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblKullanicilar"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblLogin"
            Begin Extent = 
               Top = 7
               Left = 290
               Bottom = 170
               Right = 484
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Giris'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Giris'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblKullanicilar"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 148
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblLogin"
            Begin Extent = 
               Top = 146
               Left = 502
               Bottom = 309
               Right = 696
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblGorseller"
            Begin Extent = 
               Top = 7
               Left = 532
               Bottom = 126
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'KullaniciListele'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'KullaniciListele'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblYorumlar"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 191
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "tblGorseller"
            Begin Extent = 
               Top = 7
               Left = 294
               Bottom = 126
               Right = 488
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblKullanicilar"
            Begin Extent = 
               Top = 158
               Left = 464
               Bottom = 306
               Right = 658
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblLogin"
            Begin Extent = 
               Top = 7
               Left = 706
               Bottom = 170
               Right = 900
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'YorumListele'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'YorumListele'
GO
USE [master]
GO
ALTER DATABASE [ring2] SET  READ_WRITE 
GO
