-- ============================================================
-- Subject  : Windows Programming
-- Topic    : Database Setup – viduDB
-- Student  : Huynh Minh Tai  |  MSSV: 22110068
-- Date     : Week 1
-- ============================================================

-- Step 1: Create the database (run once on localdb)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'viduDB')
BEGIN
    CREATE DATABASE viduDB;
END
GO

USE viduDB;
GO

-- ============================================================
-- Step 2: Create log_in table
--   Stores login credentials for the StudentMIS application.
--   Note: In production, passwords should be hashed (e.g. bcrypt).
-- ============================================================
IF NOT EXISTS (
    SELECT * FROM INFORMATION_SCHEMA.TABLES
    WHERE TABLE_NAME = 'log_in'
)
BEGIN
    CREATE TABLE log_in (
        id       INT           IDENTITY(1,1) PRIMARY KEY,
        username VARCHAR(50)   NOT NULL UNIQUE,
        password VARCHAR(100)  NOT NULL
    );
END
GO

-- ============================================================
-- Step 3: Seed initial test account
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM log_in WHERE username = 'thinh')
BEGIN
    INSERT INTO log_in (username, password) VALUES ('thinh', 'abc');
END

IF NOT EXISTS (SELECT 1 FROM log_in WHERE username = 'admin')
BEGIN
    INSERT INTO log_in (username, password) VALUES ('admin', 'admin123');
END
GO

-- ============================================================
-- Verification query
-- ============================================================
SELECT id, username, password FROM log_in;
GO
