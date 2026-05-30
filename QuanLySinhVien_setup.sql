-- ============================================================
-- Subject  : Windows Programming
-- Topic    : Database Setup -- QuanLySinhVien
-- Student  : Huynh Minh Tai  |  MSSV: 22110068
-- Week     : 2
-- ============================================================

-- Step 1: Tao database
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLySinhVien')
BEGIN
    CREATE DATABASE QuanLySinhVien;
END
GO

USE QuanLySinhVien;
GO

-- ============================================================
-- Step 2: Tao bang Login
-- ============================================================
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Login'
)
BEGIN
    CREATE TABLE Login (
        MSGV        NVARCHAR(20)    PRIMARY KEY,
        Fname       NVARCHAR(50),
        Lname       NVARCHAR(50),
        Username    VARCHAR(50)     NOT NULL,
        Pass        VARCHAR(100)    NOT NULL,
        Email       VARCHAR(100),
        Pic         IMAGE,
        position    INT             DEFAULT 1,  -- 0=Admin, 1=Student, 2=HR
        VALID       BIT             DEFAULT 0   -- 0=Chua duyet, 1=Da duyet
    );
END
GO

-- ============================================================
-- Step 3: Seed tai khoan admin mac dinh
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Login WHERE Username = 'admin')
BEGIN
    INSERT INTO Login (MSGV, Fname, Lname, Username, Pass, Email, position, VALID)
    VALUES ('ADMIN001', N'Quan', N'Tri', 'admin', 'admin123', 'admin@school.edu.vn', 0, 1);
END
GO

-- ============================================================
-- Step 4: Tao bang Student
-- ============================================================
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'Student'
)
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
