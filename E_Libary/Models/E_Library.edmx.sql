
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/01/2022 21:25:35
-- Generated from EDMX file: D:\code\0468191145\E_Libary\E_Libary\Models\E_Library.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [E_Library];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BaiGiang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BaiGiang];
GO
IF OBJECT_ID(N'[dbo].[DeThi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DeThi];
GO
IF OBJECT_ID(N'[dbo].[GiangDay]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GiangDay];
GO
IF OBJECT_ID(N'[dbo].[HeThongThuVien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeThongThuVien];
GO
IF OBJECT_ID(N'[dbo].[LopHoc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LopHoc];
GO
IF OBJECT_ID(N'[dbo].[MonHoc]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MonHoc];
GO
IF OBJECT_ID(N'[dbo].[NguoiDung]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NguoiDung];
GO
IF OBJECT_ID(N'[dbo].[PhanCong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhanCong];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TaiKhoan]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaiKhoan];
GO
IF OBJECT_ID(N'[dbo].[TaiLieu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaiLieu];
GO
IF OBJECT_ID(N'[dbo].[TaiNguyen]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TaiNguyen];
GO
IF OBJECT_ID(N'[dbo].[TepRieng]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TepRieng];
GO
IF OBJECT_ID(N'[dbo].[ThongBao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ThongBao];
GO
IF OBJECT_ID(N'[dbo].[TroGiup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TroGiup];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BaiGiangs'
CREATE TABLE [dbo].[BaiGiangs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoaiFile] varchar(4)  NULL,
    [Ten] nvarchar(50)  NULL,
    [MaMon] varchar(10)  NULL,
    [TenMon] nvarchar(50)  NULL,
    [Lop] varchar(10)  NULL,
    [ChuDe] nvarchar(50)  NULL,
    [NguoiChinhSua] varchar(10)  NULL,
    [NgayChinhSuaCuoi] datetime  NULL,
    [KichThuoc] float  NULL
);
GO

-- Creating table 'DeThis'
CREATE TABLE [dbo].[DeThis] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoaiFile] varchar(4)  NULL,
    [TenDeThi] nvarchar(max)  NULL,
    [MaMon] varchar(10)  NULL,
    [TenMon] nvarchar(50)  NULL,
    [NguoiTao] varchar(10)  NULL,
    [HinhThuc] nvarchar(20)  NULL,
    [NoiDung] nvarchar(max)  NULL,
    [ThoiLuong] int  NULL,
    [NgayTao] datetime  NULL,
    [NgayThi] datetime  NULL,
    [TinhTrang] bit  NULL,
    [PheDuyet] bit  NULL,
    [NguoiPheDuyet] varchar(10)  NULL,
    [GhiChu] nvarchar(max)  NULL
);
GO

-- Creating table 'GiangDays'
CREATE TABLE [dbo].[GiangDays] (
    [id] int IDENTITY(1,1) NOT NULL,
    [MaMon] varchar(10)  NULL,
    [MaGV] varchar(10)  NULL,
    [MaLop] varchar(10)  NULL,
    [NienKhoa] nchar(10)  NULL
);
GO

-- Creating table 'HeThongThuViens'
CREATE TABLE [dbo].[HeThongThuViens] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MaTruong] char(10)  NOT NULL,
    [TenTruong] nvarchar(50)  NULL,
    [LoaiTruong] nvarchar(20)  NULL,
    [HieuTruong] nvarchar(50)  NULL,
    [Website] varchar(max)  NULL,
    [TenThuVien] nvarchar(50)  NULL,
    [DiaChiTruyCap] varchar(max)  NULL,
    [SĐT] char(10)  NULL,
    [Email] nvarchar(max)  NULL,
    [NgonNgu] varchar(20)  NULL,
    [NienKhoa] nchar(10)  NULL
);
GO

-- Creating table 'LopHocs'
CREATE TABLE [dbo].[LopHocs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MaLop] varchar(10)  NULL,
    [Lop] nvarchar(50)  NULL,
    [NienKhoa] nchar(10)  NULL
);
GO

-- Creating table 'MonHocs'
CREATE TABLE [dbo].[MonHocs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MaMon] varchar(10)  NULL,
    [TenMonHoc] nvarchar(50)  NULL,
    [MoTa] nvarchar(max)  NULL,
    [ToBoMon] nvarchar(50)  NULL,
    [NienKhoa] nchar(10)  NULL,
    [TinhTrang] nvarchar(20)  NULL
);
GO

-- Creating table 'NguoiDungs'
CREATE TABLE [dbo].[NguoiDungs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MaNguoiDung] varchar(10)  NULL,
    [TenNguoiDung] nvarchar(50)  NULL,
    [Email] varchar(max)  NULL,
    [SDT] char(10)  NULL,
    [VaiTro] int  NULL
);
GO

-- Creating table 'PhanCongs'
CREATE TABLE [dbo].[PhanCongs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MaMon] varchar(10)  NULL,
    [Mon] nvarchar(50)  NULL,
    [MaGV] varchar(10)  NULL,
    [Lop] varchar(10)  NULL,
    [ChuDe] nvarchar(50)  NULL,
    [BaiGiang] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TenVaiTro] nvarchar(50)  NULL,
    [MoTa] nvarchar(max)  NULL,
    [MonHoc] int  NULL,
    [TepRiengTu] int  NULL,
    [TaiNguyen] int  NULL,
    [De] int  NULL,
    [ThongBao] int  NULL,
    [PhanQuyen] int  NULL,
    [NguoiDung] int  NULL,
    [NgayChinhSua] datetime  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TaiKhoans'
CREATE TABLE [dbo].[TaiKhoans] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] varchar(max)  NULL,
    [PassWord] varchar(50)  NULL,
    [MaNguoiDung] varchar(10)  NULL
);
GO

-- Creating table 'TaiLieux'
CREATE TABLE [dbo].[TaiLieux] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ma] int  NULL,
    [LoaiTep] varchar(4)  NULL,
    [TenTaiLieu] nvarchar(50)  NULL,
    [PhanLoai] bit  NULL,
    [MaMon] varchar(10)  NULL,
    [TenMon] nvarchar(50)  NULL,
    [NguoiTao] varchar(10)  NULL,
    [NguoiPheDuyet] varchar(10)  NULL,
    [KichThuoc] float  NULL,
    [NgayGui] datetime  NULL,
    [TinhTrang] nvarchar(20)  NULL,
    [GhiChu] nvarchar(max)  NULL
);
GO

-- Creating table 'TaiNguyens'
CREATE TABLE [dbo].[TaiNguyens] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoaiFile] varchar(4)  NULL,
    [Ten] nvarchar(50)  NULL,
    [MaMon] varchar(10)  NULL,
    [TenMon] nvarchar(50)  NULL,
    [Lop] varchar(10)  NULL,
    [ChuDe] nvarchar(50)  NULL,
    [NguoiChinhSua] varchar(10)  NULL,
    [NgayChinhSuaCuoi] datetime  NULL,
    [KichThuoc] float  NULL
);
GO

-- Creating table 'TepRiengs'
CREATE TABLE [dbo].[TepRiengs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TheLoai] varchar(4)  NULL,
    [TenTep] nvarchar(50)  NULL,
    [NguoiSua] varchar(10)  NULL,
    [NgaySuaLanCuoi] datetime  NULL,
    [KichThuoc] float  NULL
);
GO

-- Creating table 'ThongBaos'
CREATE TABLE [dbo].[ThongBaos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PhanLoai] bit  NULL,
    [ChuDe] nvarchar(100)  NULL,
    [NoiDung] nvarchar(max)  NULL,
    [NguoiNhan] varchar(10)  NULL,
    [NguoiGui] varchar(10)  NULL,
    [NgayThongBao] datetime  NULL,
    [TrangThai] nvarchar(50)  NULL
);
GO

-- Creating table 'TroGiups'
CREATE TABLE [dbo].[TroGiups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TieuDe] nvarchar(100)  NULL,
    [NoiDung] nvarchar(max)  NULL,
    [NguoiGui] varchar(10)  NULL,
    [NgayGui] datetime  NULL,
    [TrangThai] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BaiGiangs'
ALTER TABLE [dbo].[BaiGiangs]
ADD CONSTRAINT [PK_BaiGiangs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DeThis'
ALTER TABLE [dbo].[DeThis]
ADD CONSTRAINT [PK_DeThis]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'GiangDays'
ALTER TABLE [dbo].[GiangDays]
ADD CONSTRAINT [PK_GiangDays]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'HeThongThuViens'
ALTER TABLE [dbo].[HeThongThuViens]
ADD CONSTRAINT [PK_HeThongThuViens]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LopHocs'
ALTER TABLE [dbo].[LopHocs]
ADD CONSTRAINT [PK_LopHocs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MonHocs'
ALTER TABLE [dbo].[MonHocs]
ADD CONSTRAINT [PK_MonHocs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NguoiDungs'
ALTER TABLE [dbo].[NguoiDungs]
ADD CONSTRAINT [PK_NguoiDungs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhanCongs'
ALTER TABLE [dbo].[PhanCongs]
ADD CONSTRAINT [PK_PhanCongs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [Id] in table 'TaiKhoans'
ALTER TABLE [dbo].[TaiKhoans]
ADD CONSTRAINT [PK_TaiKhoans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaiLieux'
ALTER TABLE [dbo].[TaiLieux]
ADD CONSTRAINT [PK_TaiLieux]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TaiNguyens'
ALTER TABLE [dbo].[TaiNguyens]
ADD CONSTRAINT [PK_TaiNguyens]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TepRiengs'
ALTER TABLE [dbo].[TepRiengs]
ADD CONSTRAINT [PK_TepRiengs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ThongBaos'
ALTER TABLE [dbo].[ThongBaos]
ADD CONSTRAINT [PK_ThongBaos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TroGiups'
ALTER TABLE [dbo].[TroGiups]
ADD CONSTRAINT [PK_TroGiups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------