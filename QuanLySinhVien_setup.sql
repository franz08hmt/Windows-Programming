-- ============================================================
-- Subject  : Windows Programming
-- Topic    : Database Setup -- QuanLySinhVien
-- ============================================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLySinhVien')
BEGIN
    CREATE DATABASE QuanLySinhVien;
END
GO

USE QuanLySinhVien;
GO

-- ============================================================
-- Core tables
-- ============================================================
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Login')
BEGIN
    CREATE TABLE Login (
        MSGV        NVARCHAR(20)    PRIMARY KEY,
        Fname       NVARCHAR(50),
        Lname       NVARCHAR(50),
        Username    VARCHAR(50)     NOT NULL,
        Pass        VARCHAR(100)    NOT NULL,
        Email       VARCHAR(100),
        Dob         DATETIME,
        Gder        NVARCHAR(10),
        Phone       NVARCHAR(15),
        Address     NVARCHAR(250),
        Pic         IMAGE,
        position    INT             DEFAULT 1,
        VALID       BIT             DEFAULT 0
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM Login WHERE Username = 'admin')
BEGIN
    INSERT INTO Login (MSGV, Fname, Lname, Username, Pass, Email, position, VALID)
    VALUES ('ADMIN001', N'Quan Tri', N'Vien', 'admin', 'admin123', 'admin@school.edu.vn', 0, 1);
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Student')
BEGIN
    CREATE TABLE Student (
        MSSV        INT             PRIMARY KEY,
        Fname       NVARCHAR(50)    NOT NULL,
        Lname       NVARCHAR(30)    NOT NULL,
        Dob         DATETIME,
        Gder        NVARCHAR(10),
        Phone       NVARCHAR(15),
        Address     NVARCHAR(200),
        Htown       NVARCHAR(100),
        Email       NVARCHAR(100),
        Pture       IMAGE
    );
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Groups')
BEGIN
    CREATE TABLE Groups (
        ID      INT IDENTITY(1,1) PRIMARY KEY,
        Name    NVARCHAR(100) NOT NULL,
        UserID  NVARCHAR(20)  NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Contact')
BEGIN
    CREATE TABLE Contact (
        ID       INT IDENTITY(1,1) PRIMARY KEY,
        Fname    NVARCHAR(50)  NOT NULL,
        Lname    NVARCHAR(50)  NOT NULL,
        Dob      DATETIME      NULL,
        Gender   NVARCHAR(10)  NULL,
        Group_ID INT           NULL,
        Phone    NVARCHAR(20)  NULL,
        Address  NVARCHAR(250) NULL,
        Email    NVARCHAR(100) NULL,
        Pic      IMAGE         NULL,
        UserID   NVARCHAR(20)  NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Classroom')
BEGIN
    CREATE TABLE Classroom (
        MaLop NVARCHAR(20) PRIMARY KEY,
        TenLop NVARCHAR(100) NOT NULL,
        SiSo INT NULL,
        GVCN NVARCHAR(100) NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Course')
BEGIN
    CREATE TABLE Course (
        MaMH  CHAR(20)      PRIMARY KEY,
        TenMH NVARCHAR(100) NOT NULL,
        SoTC  INT           NOT NULL,
        Tuan  INT           NULL,
        Hky   INT           NULL,
        Mota  NVARCHAR(MAX) NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Score')
BEGIN
    CREATE TABLE Score (
        ID      INT IDENTITY(1,1) PRIMARY KEY,
        MSSV    INT           NOT NULL,
        MaMH    CHAR(20)      NOT NULL,
        DiemQT  DECIMAL(4,2)  NOT NULL,
        DiemCK  DECIMAL(4,2)  NOT NULL,
        DiemTK  DECIMAL(4,2)  NOT NULL,
        XepLoai NVARCHAR(30)  NULL,
        Mota    NVARCHAR(250) NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DKMH')
BEGIN
    CREATE TABLE DKMH (
        MSSV INT      NOT NULL,
        MaMH CHAR(20) NOT NULL,
        CONSTRAINT PK_DKMH PRIMARY KEY (MSSV, MaMH)
    );
END
GO

-- ============================================================
-- Demo data for contacts and charts
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Student)
BEGIN
    INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture)
    VALUES
    (22110001, N'Nguyen', N'An', '2004-02-14', N'Nam', N'0901000001', N'TP HCM', N'Binh Dinh', N'an@sv.hcmute.edu.vn', NULL),
    (22110002, N'Tran', N'Bao Ngoc', '2004-05-09', N'Nu', N'0901000002', N'TP HCM', N'Dong Nai', N'ngoc@sv.hcmute.edu.vn', NULL),
    (23110003, N'Le', N'Minh Khang', '2005-01-22', N'Nam', N'0901000003', N'TP HCM', N'Long An', N'khang@sv.hcmute.edu.vn', NULL),
    (23110004, N'Pham', N'Thanh Truc', '2005-08-18', N'Nu', N'0901000004', N'TP HCM', N'Tay Ninh', N'truc@sv.hcmute.edu.vn', NULL),
    (24110005, N'Vo', N'Gia Huy', '2006-04-03', N'Nam', N'0901000005', N'TP HCM', N'Ben Tre', N'huy@sv.hcmute.edu.vn', NULL),
    (24110006, N'Dang', N'Khanh Linh', '2006-12-02', N'Nu', N'0901000006', N'TP HCM', N'Can Tho', N'linh@sv.hcmute.edu.vn', NULL),
    (25110007, N'Bui', N'Hoang Phuc', '2007-06-27', N'Nam', N'0901000007', N'TP HCM', N'Da Nang', N'phuc@sv.hcmute.edu.vn', NULL),
    (25110008, N'Huynh', N'Mai Chi', '2007-09-15', N'Khac', N'0901000008', N'TP HCM', N'An Giang', N'chi@sv.hcmute.edu.vn', NULL);
END
GO

IF NOT EXISTS (SELECT 1 FROM Course)
BEGIN
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota)
    VALUES
    ('CS101', N'Lap trinh C#', 3, 15, 1, N'Nen tang WinForms'),
    ('DB201', N'Co so du lieu', 3, 15, 1, N'SQL Server'),
    ('WEB301', N'Phat trien Web', 3, 15, 2, N'ASP.NET'),
    ('AI401', N'Nhap mon AI', 3, 15, 2, N'Phan tich du lieu');
END
GO

IF NOT EXISTS (SELECT 1 FROM Score)
BEGIN
    INSERT INTO Score (MSSV, MaMH, DiemQT, DiemCK, DiemTK, XepLoai, Mota)
    SELECT s.MSSV, c.MaMH, v.DiemQT, v.DiemCK,
           ROUND(v.DiemQT * 0.4 + v.DiemCK * 0.6, 2),
           CASE
               WHEN ROUND(v.DiemQT * 0.4 + v.DiemCK * 0.6, 2) >= 9 THEN N'Xuat sac'
               WHEN ROUND(v.DiemQT * 0.4 + v.DiemCK * 0.6, 2) >= 8 THEN N'Gioi'
               WHEN ROUND(v.DiemQT * 0.4 + v.DiemCK * 0.6, 2) >= 6.5 THEN N'Kha'
               WHEN ROUND(v.DiemQT * 0.4 + v.DiemCK * 0.6, 2) >= 5 THEN N'Trung binh'
               ELSE N'Yeu'
           END,
           N'Du lieu mau dashboard'
    FROM Student s
    CROSS JOIN Course c
    CROSS APPLY (
        SELECT
            CAST(5.0 + ((ABS(CHECKSUM(CAST(s.MSSV AS NVARCHAR(20)) + c.MaMH)) % 45) / 10.0) AS DECIMAL(4,2)) AS DiemQT,
            CAST(5.2 + ((ABS(CHECKSUM(c.MaMH + CAST(s.MSSV AS NVARCHAR(20)))) % 43) / 10.0) AS DECIMAL(4,2)) AS DiemCK
    ) v;
END
GO

IF NOT EXISTS (SELECT 1 FROM Groups WHERE UserID = N'0')
BEGIN
    INSERT INTO Groups (Name, UserID)
    VALUES (N'Gia dinh', N'0'), (N'Ban cung lop', N'0'), (N'Giang vien', N'0'), (N'Doi tac hoc tap', N'0');

    INSERT INTO Contact (Fname, Lname, Dob, Gender, Group_ID, Phone, Address, Email, Pic, UserID)
    SELECT N'Nguyen', N'Minh Anh', '2004-03-12', N'Nu', ID, N'0901234567', N'Quan 1, TP HCM', N'minhanh@example.com', NULL, N'0'
    FROM Groups WHERE Name = N'Gia dinh' AND UserID = N'0';

    INSERT INTO Contact (Fname, Lname, Dob, Gender, Group_ID, Phone, Address, Email, Pic, UserID)
    SELECT N'Tran', N'Quoc Bao', '2003-07-24', N'Nam', ID, N'0912345678', N'Thu Duc, TP HCM', N'quocbao@example.com', NULL, N'0'
    FROM Groups WHERE Name = N'Ban cung lop' AND UserID = N'0';

    INSERT INTO Contact (Fname, Lname, Dob, Gender, Group_ID, Phone, Address, Email, Pic, UserID)
    SELECT N'Le', N'Hoang Nam', '1990-11-04', N'Nam', ID, N'0987654321', N'HCMUTE, TP Thu Duc', N'hoangnam@hcmute.edu.vn', NULL, N'0'
    FROM Groups WHERE Name = N'Giang vien' AND UserID = N'0';
END
GO
