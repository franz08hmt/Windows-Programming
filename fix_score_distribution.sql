-- ================================================================
-- FIX: Phân bổ lại điểm đủ 5 mức xếp loại, tỉ lệ hợp lí
--   ~10% Xuất sắc | ~20% Giỏi | ~40% Khá | ~20% Trung bình | ~10% Yếu
-- Chạy trong SSMS kết nối G15\SQLEXPRESS > QuanLySinhVien
-- ================================================================

USE QuanLySinhVien;
GO

-- ----------------------------------------------------------------
-- BƯỚC 1: Xếp từng sinh viên vào mức học lực theo ROW_NUMBER
--   Dùng CEILING để phân chia đúng tỉ lệ với bất kì số SV nào
-- ----------------------------------------------------------------

WITH sv_ranked AS (
    SELECT MSSV,
           ROW_NUMBER() OVER (ORDER BY MSSV) AS rn,
           COUNT(*)     OVER ()              AS total
    FROM (SELECT DISTINCT MSSV FROM Score) t
),
sv_level AS (
    SELECT MSSV,
           CASE
               WHEN rn <= CEILING(total * 0.10) THEN 'XS'  -- ~10% Xuất sắc
               WHEN rn <= CEILING(total * 0.30) THEN 'G'   -- ~20% Giỏi
               WHEN rn <= CEILING(total * 0.70) THEN 'K'   -- ~40% Khá
               WHEN rn <= CEILING(total * 0.90) THEN 'TB'  -- ~20% Trung bình
               ELSE                                  'Y'   -- ~10% Yếu
           END AS lv
    FROM sv_ranked
)
UPDATE s
SET
    -- DiemQT: biến thiên theo từng môn học trong cùng 1 mức
    s.DiemQT = CAST(CASE l.lv
        -- Xuất sắc : [9.0 – 9.5]
        WHEN 'XS' THEN 9.0 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 1)) % 2) * 0.5
        -- Giỏi     : [8.0 – 8.5]
        WHEN 'G'  THEN 8.0 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 1)) % 2) * 0.5
        -- Khá      : [6.5 – 7.5]
        WHEN 'K'  THEN 6.5 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 1)) % 3) * 0.5
        -- Trung bình: [5.0 – 6.0]
        WHEN 'TB' THEN 5.0 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 1)) % 3) * 0.5
        -- Yếu      : [3.5 – 4.5]
        ELSE           3.5 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 1)) % 3) * 0.5
    END AS DECIMAL(4,1)),

    -- DiemCK: seed khác (tham số cuối = 2) để không trùng DiemQT
    s.DiemCK = CAST(CASE l.lv
        WHEN 'XS' THEN 9.0 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 2)) % 2) * 0.5
        WHEN 'G'  THEN 8.0 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 2)) % 2) * 0.5
        WHEN 'K'  THEN 6.5 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 2)) % 3) * 0.5
        WHEN 'TB' THEN 5.0 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 2)) % 3) * 0.5
        ELSE           3.5 + (ABS(CHECKSUM(s.MSSV, s.MaMH, 2)) % 3) * 0.5
    END AS DECIMAL(4,1))
FROM Score s
JOIN sv_level l ON s.MSSV = l.MSSV;

GO

-- ----------------------------------------------------------------
-- BƯỚC 2: Tính lại DiemTK và XepLoai từ DiemQT / DiemCK mới
-- ----------------------------------------------------------------

UPDATE Score
SET
    DiemTK  = ROUND(DiemQT * 0.4 + DiemCK * 0.6, 2),
    XepLoai = CASE
        WHEN ROUND(DiemQT * 0.4 + DiemCK * 0.6, 2) >= 9.0 THEN N'Xuất sắc'
        WHEN ROUND(DiemQT * 0.4 + DiemCK * 0.6, 2) >= 8.0 THEN N'Giỏi'
        WHEN ROUND(DiemQT * 0.4 + DiemCK * 0.6, 2) >= 6.5 THEN N'Khá'
        WHEN ROUND(DiemQT * 0.4 + DiemCK * 0.6, 2) >= 5.0 THEN N'Trung bình'
        ELSE N'Yếu'
    END;
GO

-- ----------------------------------------------------------------
-- KIỂM TRA: Số sinh viên theo từng mức (dựa trên điểm TB)
-- ----------------------------------------------------------------

WITH sv_avg AS (
    SELECT MSSV, AVG(DiemTK) AS AvgTK
    FROM Score
    GROUP BY MSSV
),
sv_xl AS (
    SELECT CASE
               WHEN AvgTK >= 9.0 THEN N'Xuất sắc'
               WHEN AvgTK >= 8.0 THEN N'Giỏi'
               WHEN AvgTK >= 6.5 THEN N'Khá'
               WHEN AvgTK >= 5.0 THEN N'Trung bình'
               ELSE N'Yếu'
           END AS XepLoai,
           CASE
               WHEN AvgTK >= 9.0 THEN 1
               WHEN AvgTK >= 8.0 THEN 2
               WHEN AvgTK >= 6.5 THEN 3
               WHEN AvgTK >= 5.0 THEN 4
               ELSE 5
           END AS SortOrd
    FROM sv_avg
)
SELECT XepLoai, COUNT(*) AS SoSinhVien
FROM sv_xl
GROUP BY XepLoai, SortOrd
ORDER BY SortOrd
    END;
GO
