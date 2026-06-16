-- ============================================================
-- FIX "Gi?i" / "Xu?t s?c" / "Trung b?nh" trong bảng Score
-- Root cause: cột XepLoai là VARCHAR → mất dấu khi lưu Unicode
-- Giải pháp: ALTER sang NVARCHAR rồi tính lại từ DiemTK (decimal)
-- ============================================================
USE QuanLySinhVien;
GO

-- ── Bước 1: Đổi cột XepLoai sang NVARCHAR nếu đang là VARCHAR ───────────────
IF EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME  = 'Score'
      AND COLUMN_NAME = 'XepLoai'
      AND DATA_TYPE   = 'varchar'
)
BEGIN
    ALTER TABLE Score ALTER COLUMN XepLoai NVARCHAR(30) NULL;
    PRINT 'XepLoai đã được đổi sang NVARCHAR(30)';
END
ELSE
BEGIN
    PRINT 'XepLoai đã là NVARCHAR — bỏ qua ALTER';
END
GO

-- ── Bước 2: Tính lại XepLoai từ DiemTK (decimal, không bị mất dấu) ──────────
-- Áp dụng cho TẤT CẢ bản ghi (ghi đè mọi giá trị cũ sai/thiếu)
UPDATE Score
SET XepLoai =
    CASE
        WHEN DiemTK >= 9.0 THEN N'Xuất sắc'
        WHEN DiemTK >= 8.0 THEN N'Giỏi'
        WHEN DiemTK >= 6.5 THEN N'Khá'
        WHEN DiemTK >= 5.0 THEN N'Trung bình'
        ELSE                     N'Yếu'
    END
WHERE DiemTK IS NOT NULL;
GO

-- ── Bước 3: Kiểm tra kết quả ─────────────────────────────────────────────────
SELECT
    XepLoai     AS [Xếp loại],
    COUNT(*)    AS [Số bản ghi],
    MIN(DiemTK) AS [DiemTK min],
    MAX(DiemTK) AS [DiemTK max]
FROM Score
GROUP BY XepLoai
ORDER BY
    CASE XepLoai
        WHEN N'Xuất sắc'   THEN 1
        WHEN N'Giỏi'       THEN 2
        WHEN N'Khá'        THEN 3
        WHEN N'Trung bình' THEN 4
        WHEN N'Yếu'        THEN 5
        ELSE 6
    END;
GO

-- ── Bước 4: Sửa luôn cột TenMH trong Course (cũng có thể bị varchar) ─────────
IF EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME  = 'Course'
      AND COLUMN_NAME = 'TenMH'
      AND DATA_TYPE   = 'varchar'
)
BEGIN
    ALTER TABLE Course ALTER COLUMN TenMH NVARCHAR(100) NOT NULL;
    PRINT 'Course.TenMH đã được đổi sang NVARCHAR';
END
GO

-- Cập nhật lại tên môn học với đúng dấu
UPDATE Course SET TenMH = N'Lập trình C#'              WHERE MaMH = 'CS101'  AND TenMH NOT LIKE N'%ậ%';
UPDATE Course SET TenMH = N'Cơ sở dữ liệu'             WHERE MaMH = 'DB201'  AND TenMH NOT LIKE N'%ữ%';
UPDATE Course SET TenMH = N'Phát triển Web'             WHERE MaMH = 'WEB301' AND TenMH NOT LIKE N'%á%';
UPDATE Course SET TenMH = N'Nhập môn AI'                WHERE MaMH = 'AI401'  AND TenMH NOT LIKE N'%ậ%';
UPDATE Course SET TenMH = N'Mạng máy tính'              WHERE MaMH = 'NET501' AND TenMH NOT LIKE N'%ạ%';
UPDATE Course SET TenMH = N'Lập trình hướng đối tượng'  WHERE MaMH = 'OOP601' AND TenMH NOT LIKE N'%ớ%';
GO

PRINT 'Hoàn tất! Chart sẽ hiển thị đúng tiếng Việt sau khi khởi động lại app.';
GO
