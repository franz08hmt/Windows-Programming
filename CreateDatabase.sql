-- =============================================================
-- QuanLySinhVien - Script khoi tao toan bo co so du lieu
-- Sinh boi AI (Claude) tu mo ta he thong quan ly sinh vien
-- Chay script nay tren SQL Server de tao DB tu dau
-- =============================================================

USE QuanLySinhVien;
GO

-- ============================================================
-- 1. Bang tai khoan nguoi dung (Admin / Giang vien / Sinh vien)
-- ============================================================
IF OBJECT_ID('dbo.Login', 'U') IS NULL
CREATE TABLE dbo.Login (
    MSGV            NVARCHAR(20)    NOT NULL PRIMARY KEY,
    Fname           NVARCHAR(50)    NULL,
    Lname           NVARCHAR(50)    NULL,
    Username        VARCHAR(50)     NULL,
    Pass            VARCHAR(100)    NULL,
    Email           VARCHAR(100)    NULL,
    Pic             IMAGE           NULL,
    Position        INT             NOT NULL DEFAULT 1,   -- 0=Admin, 1=Sinh vien, 2=Giang vien
    VALID           INT             NOT NULL DEFAULT 1,   -- 1=Active, 0=Inactive
    Dob             DATETIME        NULL,
    Gder            NVARCHAR(10)    NULL,
    Phone           NVARCHAR(15)    NULL,
    Address         NVARCHAR(250)   NULL,
    TwoFactorSecret NVARCHAR(255)   NULL
);
GO

-- ============================================================
-- 2. Bang thong tin sinh vien
-- ============================================================
IF OBJECT_ID('dbo.Student', 'U') IS NULL
CREATE TABLE dbo.Student (
    MSSV    INT             NOT NULL PRIMARY KEY,
    Fname   NVARCHAR(50)    NULL,
    Lname   NVARCHAR(50)    NULL,
    Dob     DATETIME        NULL,
    Gder    NVARCHAR(10)    NULL,
    Phone   NVARCHAR(20)    NULL,
    Address NVARCHAR(250)   NULL,
    Htown   NVARCHAR(100)   NULL,
    Email   NVARCHAR(100)   NULL,
    Pture   IMAGE           NULL
);
GO

-- ============================================================
-- 3. Bang mon hoc
-- ============================================================
IF OBJECT_ID('dbo.Course', 'U') IS NULL
CREATE TABLE dbo.Course (
    MaMH    CHAR(20)        NOT NULL PRIMARY KEY,
    TenMH   NVARCHAR(100)   NULL,
    SoTC    INT             NULL,
    Tuan    INT             NULL,
    Hky     INT             NULL,
    Mota    NVARCHAR(MAX)   NULL
);
GO

-- ============================================================
-- 4. Bang lop hoc
-- ============================================================
IF OBJECT_ID('dbo.Classroom', 'U') IS NULL
CREATE TABLE dbo.Classroom (
    MaLop   CHAR(20)        NOT NULL PRIMARY KEY,
    TenLop  NVARCHAR(100)   NULL,
    SiSo    INT             NULL,
    GVCN    NVARCHAR(100)   NULL
);
GO

-- ============================================================
-- 5. Bang nhom danh ba ca nhan (per user)
-- ============================================================
IF OBJECT_ID('dbo.Groups', 'U') IS NULL
CREATE TABLE dbo.Groups (
    ID      INT             IDENTITY(1,1) PRIMARY KEY,
    Name    NVARCHAR(100)   NOT NULL,
    UserID  NVARCHAR(20)    NOT NULL
);
GO

-- ============================================================
-- 6. Bang danh ba ca nhan (per user)
-- ============================================================
IF OBJECT_ID('dbo.Contact', 'U') IS NULL
CREATE TABLE dbo.Contact (
    ID       INT             IDENTITY(1,1) PRIMARY KEY,
    Fname    NVARCHAR(50)    NOT NULL,
    Lname    NVARCHAR(50)    NOT NULL,
    Dob      DATETIME        NULL,
    Gender   NVARCHAR(10)    NULL,
    Group_ID INT             NULL,
    Phone    NVARCHAR(20)    NULL,
    Address  NVARCHAR(250)   NULL,
    Email    NVARCHAR(100)   NULL,
    Pic      IMAGE           NULL,
    UserID   NVARCHAR(20)    NOT NULL
);
GO

-- ============================================================
-- 7. Bang dang ky mon hoc
-- ============================================================
IF OBJECT_ID('dbo.DKMH', 'U') IS NULL
CREATE TABLE dbo.DKMH (
    MSSV    INT             NOT NULL,
    MaMH    CHAR(20)        NOT NULL,
    PRIMARY KEY (MSSV, MaMH),
    FOREIGN KEY (MSSV) REFERENCES dbo.Student(MSSV),
    FOREIGN KEY (MaMH) REFERENCES dbo.Course(MaMH)
);
GO

-- ============================================================
-- 8. Bang diem (Qua trinh / Cuoi ky / Tong ket)
-- ============================================================
IF OBJECT_ID('dbo.Score', 'U') IS NULL
CREATE TABLE dbo.Score (
    MSSV    INT             NOT NULL,
    MaMH    CHAR(20)        NOT NULL,
    DiemQT  DECIMAL(5,2)    NULL,
    DiemCK  DECIMAL(5,2)    NULL,
    DiemTK  DECIMAL(5,2)    NULL,
    XepLoai NVARCHAR(20)    NULL,
    Mota    NVARCHAR(MAX)   NULL,
    PRIMARY KEY (MSSV, MaMH),
    FOREIGN KEY (MSSV) REFERENCES dbo.Student(MSSV),
    FOREIGN KEY (MaMH) REFERENCES dbo.Course(MaMH)
);
GO

-- ============================================================
-- 9. Bang phan cong giang day (Giang vien - Mon hoc)
-- ============================================================
IF OBJECT_ID('dbo.Assign', 'U') IS NULL
CREATE TABLE dbo.Assign (
    ID      INT             IDENTITY(1,1) PRIMARY KEY,
    ID_HR   NVARCHAR(20)    NULL,
    MaMH    CHAR(20)        NULL,
    FOREIGN KEY (ID_HR) REFERENCES dbo.Login(MSGV),
    FOREIGN KEY (MaMH)  REFERENCES dbo.Course(MaMH)
);
GO

-- ============================================================
-- 10. Bang yeu cau cua sinh vien (gui len admin xu ly)
-- ============================================================
IF OBJECT_ID('dbo.StudentRequests', 'U') IS NULL
CREATE TABLE dbo.StudentRequests (
    ID        INT             IDENTITY(1,1) PRIMARY KEY,
    MSSV      NVARCHAR(50)    NULL,
    TenSV     NVARCHAR(100)   NULL,
    NgayGui   DATETIME        DEFAULT GETDATE(),
    NoiDung   NVARCHAR(MAX)   NULL,
    TrangThai NVARCHAR(50)    DEFAULT N'Cho xu ly'
);
GO

-- =============================================================
-- KIEM TRA: Danh sach bang da tao
-- =============================================================
SELECT TABLE_NAME, TABLE_TYPE
FROM   INFORMATION_SCHEMA.TABLES
WHERE  TABLE_TYPE = 'BASE TABLE'
ORDER  BY TABLE_NAME;
GO
