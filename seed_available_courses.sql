-- ================================================================
-- seed_available_courses.sql
-- Tạo lại dữ liệu thực tế: mỗi SV chỉ đã học 8 môn (có điểm),
-- các môn còn lại sẽ hiện trong "Môn học có thể đăng ký"
-- Chạy trong SSMS kết nối G15\SQLEXPRESS > QuanLySinhVien
-- ================================================================

USE QuanLySinhVien;
GO

-- ----------------------------------------------------------------
-- BƯỚC 1: Trong Score, giữ 8 môn đầu (seed cố định) cho mỗi SV
--         → các môn còn lại trở thành "chưa đăng ký"
-- ----------------------------------------------------------------

WITH ranked AS (
    SELECT MSSV, MaMH,
           ROW_NUMBER() OVER (
               PARTITION BY MSSV
               ORDER BY ABS(CHECKSUM(MSSV, MaMH, 13))  -- seed cố định
           ) AS rn
    FROM Score
)
DELETE s
FROM Score s
JOIN ranked r ON s.MSSV = r.MSSV AND s.MaMH = r.MaMH
WHERE r.rn > 8;
GO

-- ----------------------------------------------------------------
-- BƯỚC 2: Đồng bộ DKMH khớp với Score
--         (DKMH dùng bởi Student.cs và f_ManageScore.cs)
-- ----------------------------------------------------------------

DELETE FROM DKMH;
GO

INSERT INTO DKMH (MSSV, MaMH)
SELECT MSSV, MaMH FROM Score;
GO

-- ----------------------------------------------------------------
-- KIỂM TRA
-- ----------------------------------------------------------------

-- Tổng quan bảng
SELECT 'Score'  AS [Bảng], COUNT(*) AS [Tổng rows], COUNT(DISTINCT MSSV) AS [Số SV] FROM Score UNION ALL
SELECT 'DKMH',              COUNT(*),                 COUNT(DISTINCT MSSV)             FROM DKMH  UNION ALL
SELECT 'Course',            COUNT(*),                 NULL                              FROM Course;
GO

-- Số môn mỗi SV còn trong Score và số môn available
SELECT
    s.MSSV,
    COUNT(s.MaMH)                                   AS [Môn đã học],
    (SELECT COUNT(*) FROM Course) - COUNT(s.MaMH)   AS [Môn có thể đăng ký]
FROM Score s
GROUP BY s.MSSV
ORDER BY s.MSSV;
GO
