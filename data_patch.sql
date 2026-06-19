-- ============================================================
-- DATA PATCH  --  QuanLySinhVien
-- Mục tiêu: sửa tên bị lỗi "?", bổ sung DOB thiếu, fix giới tính sai
-- Chạy trong SSMS SAU KHI đã chạy data_seed.sql
-- ============================================================
USE QuanLySinhVien;
GO

-- ============================================================
-- 1. SỬA TÊN BỊ LỖI ENCODING (chứa ký tự ? thay vì chữ Việt)
-- ============================================================

-- 22110021: "Nguy?n" → "Nguyễn"  (ễ = U+1EC5 bị mất khi INSERT qua VARCHAR)
UPDATE Student SET Fname = N'Nguyễn'
WHERE MSSV = 22110021 AND Fname LIKE N'Nguy%n';

-- 22110023: "Tr?n" → "Trần",  "Đ?c Cu?ng" → "Đức Cường"
UPDATE Student SET Fname = N'Trần', Lname = N'Đức Cường'
WHERE MSSV = 22110023 AND (Fname LIKE N'Tr_n' OR Lname LIKE N'%Cu_ng');

-- ============================================================
-- 2. BỔ SUNG NGÀY SINH THIẾU (năm 2004 ~ sinh viên khoá 22)
-- ============================================================
UPDATE Student SET Dob = '2004-03-10' WHERE MSSV = 22110001 AND Dob IS NULL;
UPDATE Student SET Dob = '2004-09-15' WHERE MSSV = 22110021 AND Dob IS NULL;
UPDATE Student SET Dob = '2004-11-20' WHERE MSSV = 22110026 AND Dob IS NULL;
UPDATE Student SET Dob = '2004-07-05' WHERE MSSV = 22110033 AND Dob IS NULL;
UPDATE Student SET Dob = '2004-02-28' WHERE MSSV = 22110040 AND Dob IS NULL;
UPDATE Student SET Dob = '2004-06-14' WHERE MSSV = 22110044 AND Dob IS NULL;
UPDATE Student SET Dob = '2004-12-01' WHERE MSSV = 22110081 AND Dob IS NULL;
UPDATE Student SET Dob = '2004-08-19' WHERE MSSV = 22110092 AND Dob IS NULL;
GO

-- ============================================================
-- 3. SỬA GIỚI TÍNH SAI
--    22110040: "Lê Thị Thu" + tên "Hương" → rõ ràng là Nữ, không phải Nam
-- ============================================================
UPDATE Student SET Gder = N'Nữ'
WHERE MSSV = 22110040 AND Gder = N'Nam';
GO

-- ============================================================
-- 4. KIỂM TRA KẾT QUẢ
-- ============================================================
SELECT MSSV,
       Fname + N' ' + Lname AS [Họ Tên],
       CONVERT(VARCHAR(10), Dob, 103) AS [Ngày sinh],
       Gder AS [Giới tính]
FROM Student
WHERE MSSV IN (22110001, 22110021, 22110023, 22110026,
               22110033, 22110040, 22110044, 22110081, 22110092)
ORDER BY MSSV;
GO
