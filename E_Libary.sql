USE [master]
GO
/****** Object:  Database [E_Library]    Script Date: 04/15/2022 11:09:58 ******/
CREATE DATABASE [E_Library] ON  PRIMARY 
( NAME = N'E_Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\E_Library.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'E_Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\E_Library_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [E_Library] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [E_Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [E_Library] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [E_Library] SET ANSI_NULLS OFF
GO
ALTER DATABASE [E_Library] SET ANSI_PADDING OFF
GO
ALTER DATABASE [E_Library] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [E_Library] SET ARITHABORT OFF
GO
ALTER DATABASE [E_Library] SET AUTO_CLOSE ON
GO
ALTER DATABASE [E_Library] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [E_Library] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [E_Library] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [E_Library] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [E_Library] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [E_Library] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [E_Library] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [E_Library] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [E_Library] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [E_Library] SET  ENABLE_BROKER
GO
ALTER DATABASE [E_Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [E_Library] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [E_Library] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [E_Library] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [E_Library] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [E_Library] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [E_Library] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [E_Library] SET  READ_WRITE
GO
ALTER DATABASE [E_Library] SET RECOVERY SIMPLE
GO
ALTER DATABASE [E_Library] SET  MULTI_USER
GO
ALTER DATABASE [E_Library] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [E_Library] SET DB_CHAINING OFF
GO
USE [E_Library]
GO
/****** Object:  Table [dbo].[TaiNguyen]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiNguyen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiFile] [varchar](4) NULL,
	[Ten] [nvarchar](50) NULL,
	[MonHoc] [int] NULL,
	[Lop] [varchar](10) NULL,
	[ChuDe] [nvarchar](50) NULL,
	[NguoiChinhSua] [int] NULL,
	[NgayChinhSuaCuoi] [datetime] NULL,
	[KichThuoc] [float] NULL,
 CONSTRAINT [PK_TaiNguyen] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TaiNguyen] ON
INSERT [dbo].[TaiNguyen] ([Id], [LoaiFile], [Ten], [MonHoc], [Lop], [ChuDe], [NguoiChinhSua], [NgayChinhSuaCuoi], [KichThuoc]) VALUES (1, N'pptx', N'Láp ráp phần cứng', NULL, N'SCMT19', N'Chủ đề nâng cao', NULL, CAST(0x0000ADAC00000000 AS DateTime), 5.3)
SET IDENTITY_INSERT [dbo].[TaiNguyen] OFF
/****** Object:  Table [dbo].[TaiLieu]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiLieu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenTaiLieu] [nvarchar](50) NULL,
	[MonHoc] [varchar](10) NULL,
	[PhanLoai] [varchar](10) NULL,
	[NguoiTao] [nvarchar](50) NULL,
	[NguoiPheDuyet] [nvarchar](50) NULL,
	[NgayGui] [datetime] NULL,
	[TinhTrang] [nvarchar](20) NULL,
	[GhiChu] [text] NULL,
 CONSTRAINT [PK_ToBoMon] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TaiLieu] ON
INSERT [dbo].[TaiLieu] ([Id], [TenTaiLieu], [MonHoc], [PhanLoai], [NguoiTao], [NguoiPheDuyet], [NgayGui], [TinhTrang], [GhiChu]) VALUES (1, N'Vẽ sơ đồ ER', N'CSDL', N'docx', N'Phạm Văn Sơn', N'Âu Minh Chánh', CAST(0x0000ADA100000000 AS DateTime), N'Đã duyệt', N'Làm bài t?p')
INSERT [dbo].[TaiLieu] ([Id], [TenTaiLieu], [MonHoc], [PhanLoai], [NguoiTao], [NguoiPheDuyet], [NgayGui], [TinhTrang], [GhiChu]) VALUES (3, N'Hệ quản trị cơ sở dữ liệu', N'CSDL', N'docx', N'Vũ Yến Ny', N'Nguyễn Tuấn Anh', CAST(0x0000AE6000000000 AS DateTime), N'Đã duyệt', N'')
SET IDENTITY_INSERT [dbo].[TaiLieu] OFF
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[MaNguoiDung] [varchar](10) NULL,
	[Ten] [nvarchar](50) NULL,
	[VaiTro] [int] NULL,
 CONSTRAINT [PK_TaiKhoan_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON
INSERT [dbo].[TaiKhoan] ([Id], [UserName], [PassWord], [MaNguoiDung], [Ten], [VaiTro]) VALUES (1, N'minhhieu08', N'9longgiang', NULL, NULL, NULL)
INSERT [dbo].[TaiKhoan] ([Id], [UserName], [PassWord], [MaNguoiDung], [Ten], [VaiTro]) VALUES (2, N'minhhieu', N'123456', N'NMH', N'Nguyễn Minh Hiếu', 3)
INSERT [dbo].[TaiKhoan] ([Id], [UserName], [PassWord], [MaNguoiDung], [Ten], [VaiTro]) VALUES (5, N'minhhieu', N'123456', N'NMH', N'Nguyễn Minh Hiếu', NULL)
INSERT [dbo].[TaiKhoan] ([Id], [UserName], [PassWord], [MaNguoiDung], [Ten], [VaiTro]) VALUES (6, N'0468191145', N'123456', N'PLAT', N'Phạm Lê Anh Tài', 3)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenVaiTro] [nvarchar](50) NULL,
	[MoTa] [text] NULL,
	[MonHoc] [int] NULL,
	[TepRiengTu] [int] NULL,
	[TaiNguyen] [int] NULL,
	[De] [int] NULL,
	[ThongBao] [int] NULL,
	[PhanQuyen] [int] NULL,
	[NguoiDung] [int] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([Id], [TenVaiTro], [MoTa], [MonHoc], [TepRiengTu], [TaiNguyen], [De], [ThongBao], [PhanQuyen], [NguoiDung]) VALUES (1, N'AdMin', N'Qu?n lý t?t c?', 777, 777, 777, 777, 777, 777, 777)
INSERT [dbo].[Role] ([Id], [TenVaiTro], [MoTa], [MonHoc], [TepRiengTu], [TaiNguyen], [De], [ThongBao], [PhanQuyen], [NguoiDung]) VALUES (2, N'Giảng viên', N'Qu?n lý giáo trình', 777, 777, 777, 777, 777, 456, 456)
INSERT [dbo].[Role] ([Id], [TenVaiTro], [MoTa], [MonHoc], [TepRiengTu], [TaiNguyen], [De], [ThongBao], [PhanQuyen], [NguoiDung]) VALUES (3, N'Học sinh', N'Giao bài', 345, 345, 333, 222, 223, 345, 345)
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[MonHoc]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MonHoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaMon] [varchar](10) NULL,
	[TenMonHoc] [nvarchar](20) NULL,
	[GiangVien] [nvarchar](50) NULL,
	[MoTa] [text] NULL,
	[ToBoMon] [nvarchar](50) NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[MonHoc] ON
INSERT [dbo].[MonHoc] ([Id], [MaMon], [TenMonHoc], [GiangVien], [MoTa], [ToBoMon]) VALUES (1, N'QTM19', N'Lập trình web', N'Trần Thanh Tuấn', N'Web', N'Công nghệ thông tin')
INSERT [dbo].[MonHoc] ([Id], [MaMon], [TenMonHoc], [GiangVien], [MoTa], [ToBoMon]) VALUES (2, N'QTM19', N'Photoshop', N'Đặng Văn Lâm', N'Thi?t k? d? h?a', N'Công nghệ thông tin')
INSERT [dbo].[MonHoc] ([Id], [MaMon], [TenMonHoc], [GiangVien], [MoTa], [ToBoMon]) VALUES (3, N'SCMTA', N'Phần cứng máy tính', N'Võ Công Khanh', N'Các thành phân máy tính', N'Công nghệ thông tin')
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
/****** Object:  Table [dbo].[LopHoc]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Lop] [nvarchar](50) NULL,
	[GVPhuTrach] [nvarchar](50) NULL,
 CONSTRAINT [PK_LopHoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LopHoc] ON
INSERT [dbo].[LopHoc] ([Id], [Lop], [GVPhuTrach]) VALUES (1, N'Sửa chữa máy tính', N'Nguyễn Võ Công Khanh')
INSERT [dbo].[LopHoc] ([Id], [Lop], [GVPhuTrach]) VALUES (3, N'Quản trị mạng', N'Trần Thanh Tuấn')
SET IDENTITY_INSERT [dbo].[LopHoc] OFF
/****** Object:  Table [dbo].[HeThongThuVien]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HeThongThuVien](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaTruong] [char](10) NOT NULL,
	[TenTruong] [nvarchar](50) NULL,
	[LoaiTruong] [nvarchar](20) NULL,
	[HieuTruong] [nvarchar](50) NULL,
	[Website] [varchar](max) NULL,
	[TenThuVien] [nvarchar](50) NULL,
	[DiaChiTruyCap] [varchar](max) NULL,
	[SĐT] [int] NULL,
	[Email] [nvarchar](max) NULL,
	[NgonNgu] [varchar](20) NULL,
	[NienKhoa] [nchar](10) NULL,
 CONSTRAINT [PK_HeThongThuVien] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[HeThongThuVien] ON
INSERT [dbo].[HeThongThuVien] ([Id], [MaTruong], [TenTruong], [LoaiTruong], [HieuTruong], [Website], [TenThuVien], [DiaChiTruyCap], [SĐT], [Email], [NgonNgu], [NienKhoa]) VALUES (1, N'234       ', N'Pham', N'xzxh', N'fdc', NULL, N'vsd', N'dhfhsud', 33434, N'sdfdsd', N'sdfsfsdcv', N'2019-2022 ')
INSERT [dbo].[HeThongThuVien] ([Id], [MaTruong], [TenTruong], [LoaiTruong], [HieuTruong], [Website], [TenThuVien], [DiaChiTruyCap], [SĐT], [Email], [NgonNgu], [NienKhoa]) VALUES (2, N'CKC       ', N'Cao Đẳng Kỹ Thuật Cao Thắng', N'', N'Phạm Văn Sơn', N'www.caothang.edu.vn', N'E3', N'', 999833921, N'@caothang.edu.vn', N'Ti?ng vi?t', N'2021-2022 ')
INSERT [dbo].[HeThongThuVien] ([Id], [MaTruong], [TenTruong], [LoaiTruong], [HieuTruong], [Website], [TenThuVien], [DiaChiTruyCap], [SĐT], [Email], [NgonNgu], [NienKhoa]) VALUES (4, N'CKC       ', N'Cao Đẳng Kỹ Thuật Cao Thắng', N'', N'Thân Trường Vũ', N'www.caothang.edu.vn', N'E5', N'', 999833921, N'@caothang.edu.vn', N'English', N'2020-2021 ')
SET IDENTITY_INSERT [dbo].[HeThongThuVien] OFF
/****** Object:  Table [dbo].[DeThi]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DeThi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LoaiFile] [varchar](4) NULL,
	[TenDeThi] [nvarchar](max) NULL,
	[MonHoc] [varchar](10) NULL,
	[NguoiTao] [nvarchar](50) NULL,
	[HinhThuc] [nvarchar](20) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[ThoiLuong] [int] NULL,
	[NgayTao] [datetime] NULL,
	[NgayThi] [datetime] NULL,
	[TinhTrang] [bit] NULL,
	[PheDuyet] [bit] NULL,
	[NguoiPheDuyet] [nvarchar](50) NULL,
	[GhiChu] [text] NULL,
 CONSTRAINT [PK_QuanLyDeThi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[DeThi] ON
INSERT [dbo].[DeThi] ([ID], [LoaiFile], [TenDeThi], [MonHoc], [NguoiTao], [HinhThuc], [NoiDung], [ThoiLuong], [NgayTao], [NgayThi], [TinhTrang], [PheDuyet], [NguoiPheDuyet], [GhiChu]) VALUES (1, N'3', N'Kiểm tra', N'2', N'Pham', N'fasdfsd', N'dfsdfs', 120, CAST(0x0000ACCA00000000 AS DateTime), CAST(0x0000AD2600000000 AS DateTime), 1, 1, N'3', N'dbkjsdbfsbdjvgbs')
SET IDENTITY_INSERT [dbo].[DeThi] OFF
/****** Object:  Table [dbo].[BaiGiang]    Script Date: 04/15/2022 11:10:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BaiGiang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoaiFile] [varchar](4) NULL,
	[Ten] [nvarchar](50) NULL,
	[MonHoc] [varchar](10) NULL,
	[Lop] [varchar](10) NULL,
	[ChuDe] [nvarchar](max) NULL,
	[NguoiChinhSua] [nvarchar](50) NULL,
	[NgayChinhSuaCuoi] [datetime] NULL,
	[KichThuoc] [float] NULL,
 CONSTRAINT [PK_BaiGiang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BaiGiang] ON
INSERT [dbo].[BaiGiang] ([Id], [LoaiFile], [Ten], [MonHoc], [Lop], [ChuDe], [NguoiChinhSua], [NgayChinhSuaCuoi], [KichThuoc]) VALUES (1, N'pptx', N'Tìm hiểu về HTML', N'LTWEB', N'QTM19B', N'Chủ đề tự chọn', N'Nguyễn Tường An', CAST(0x0000ADAC00000000 AS DateTime), 2.4)
INSERT [dbo].[BaiGiang] ([Id], [LoaiFile], [Ten], [MonHoc], [Lop], [ChuDe], [NguoiChinhSua], [NgayChinhSuaCuoi], [KichThuoc]) VALUES (3, N'doc', N'Láp ráp phần cứng', N'LTWEB', N'QTM19A', N'Chủ đề nâng cao', N'Phạm Tuấn Huy', CAST(0x0000ADAC00000000 AS DateTime), 2.4)
SET IDENTITY_INSERT [dbo].[BaiGiang] OFF
