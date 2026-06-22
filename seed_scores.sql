-- ================================================================
-- SEED SCRIPT: Bổ sung dữ liệu điểm cho QuanLySinhVien
-- Chạy trong SSMS kết nối G15\SQLEXPRESS > QuanLySinhVien
-- ================================================================

USE QuanLySinhVien;
GO

-- ----------------------------------------------------------------
-- BƯỚC 1: Bổ sung điểm còn thiếu cho Huỳnh Minh Tài (MSSV 22110068)
-- ----------------------------------------------------------------

-- Đăng ký các môn chưa có trong DKMH
INSERT INTO DKMH (MSSV, MaMH)
SELECT 22110068, v.MaMH
FROM (VALUES
    ('ACEN340535'), ('ACEN340635'), ('ACEN440735'), ('ACEN440835'),
    ('GDQP008031'), ('GDQP008032'), ('GDQP008033'),
    ('INIT130185'), ('INPR130285'),
    ('LLCT120205'), ('LLCT120405'), ('LLCT130105'),
    ('MATH132401'), ('MATH132501'), ('MH01'), ('PRTE230385')
) AS v(MaMH)
WHERE NOT EXISTS (SELECT 1 FROM DKMH d WHERE d.MSSV = 22110068 AND d.MaMH = v.MaMH)
  AND EXISTS     (SELECT 1 FROM Course c WHERE c.MaMH = v.MaMH);

-- Nhập điểm cho các môn chưa có
INSERT INTO Score (MSSV, MaMH, DiemQT, DiemCK, DiemTK, XepLoai, Mota)
SELECT MSSV, MaMH, DiemQT, DiemCK, DiemTK, XepLoai, Mota
FROM (VALUES
    (22110068, 'ACEN340635', 7.5, 8.0,  7.80, N'Khá',      N''),
    (22110068, 'ACEN440735', 8.0, 8.5,  8.30, N'Giỏi',     N''),
    (22110068, 'ACEN440835', 7.0, 7.5,  7.30, N'Khá',      N''),
    (22110068, 'GDQP008031', 8.5, 9.0,  8.80, N'Giỏi',     N''),
    (22110068, 'GDQP008032', 9.0, 9.0,  9.00, N'Xuất sắc', N''),
    (22110068, 'GDQP008033', 7.0, 7.5,  7.30, N'Khá',      N''),
    (22110068, 'INPR130285', 6.5, 7.0,  6.80, N'Khá',      N''),
    (22110068, 'LLCT120405', 7.0, 7.5,  7.30, N'Khá',      N''),
    (22110068, 'LLCT130105', 6.0, 6.5,  6.30, N'Khá',      N''),
    (22110068, 'MH01',       8.5, 9.0,  8.80, N'Giỏi',     N''),
    (22110068, 'PRTE230385', 7.5, 8.0,  7.80, N'Khá',      N'')
) AS v(MSSV, MaMH, DiemQT, DiemCK, DiemTK, XepLoai, Mota)
WHERE NOT EXISTS (SELECT 1 FROM Score s WHERE s.MSSV = v.MSSV AND s.MaMH = v.MaMH)
  AND EXISTS     (SELECT 1 FROM Course c WHERE c.MaMH = v.MaMH);

GO

-- ----------------------------------------------------------------
-- BƯỚC 2: Đăng ký TẤT CẢ môn học cho TẤT CẢ sinh viên còn lại
-- ----------------------------------------------------------------

INSERT INTO DKMH (MSSV, MaMH)
SELECT s.MSSV, c.MaMH
FROM Student s
CROSS JOIN Course c
WHERE NOT EXISTS (
    SELECT 1 FROM DKMH d WHERE d.MSSV = s.MSSV AND d.MaMH = c.MaMH
);

GO

-- ----------------------------------------------------------------
-- BƯỚC 3: Nhập điểm tự động cho tất cả (MSSV, MaMH) chưa có điểm
--   - Dùng CHECKSUM(MSSV * seed + ...) để tạo điểm đa dạng nhưng ổn định
--   - DiemQT, DiemCK: phân bố từ 4.5 → 9.5 (có cả khá / giỏi / trung bình / yếu)
-- ----------------------------------------------------------------

INSERT INTO Score (MSSV, MaMH, DiemQT, DiemCK, DiemTK, XepLoai, Mota)
SELECT
    d.MSSV,
    d.MaMH,
    qt,
    ck,
    ROUND(qt * 0.4 + ck * 0.6, 2)                        AS DiemTK,
    CASE
        WHEN ROUND(qt * 0.4 + ck * 0.6, 2) >= 9.0 THEN N'Xuất sắc'
        WHEN ROUND(qt * 0.4 + ck * 0.6, 2) >= 8.0 THEN N'Giỏi'
        WHEN ROUND(qt * 0.4 + ck * 0.6, 2) >= 6.5 THEN N'Khá'
        WHEN ROUND(qt * 0.4 + ck * 0.6, 2) >= 5.0 THEN N'Trung bình'
        ELSE N'Yếu'
    END                                                    AS XepLoai,
    N''                                                    AS Mota
FROM DKMH d
CROSS APPLY (
    -- DiemQT: 4.5 ~ 9.5, step 0.5 (50 bước)
    SELECT CAST(
        4.5 + (ABS(CHECKSUM(d.MSSV * 31 + ASCII(LEFT(d.MaMH, 1)) + 7)) % 11) * 0.5
    AS DECIMAL(4,1)) AS qt
) AS qtCalc(qt)
CROSS APPLY (
    -- DiemCK: 4.5 ~ 9.5, seed khác để không giống DiemQT
    SELECT CAST(
        4.5 + (ABS(CHECKSUM(d.MSSV * 17 + ASCII(LEFT(d.MaMH, 1)) + 3)) % 11) * 0.5
    AS DECIMAL(4,1)) AS ck
) AS ckCalc(ck)
WHERE NOT EXISTS (
    SELECT 1 FROM Score s WHERE s.MSSV = d.MSSV AND s.MaMH = d.MaMH
);

GO

-- ----------------------------------------------------------------
-- KIỂM TRA KẾT QUẢ
-- ----------------------------------------------------------------

SELECT
    s.MSSV,
    st.Fname + N' ' + st.Lname          AS [Họ Tên],
    COUNT(*)                             AS [Số Môn],
    ROUND(AVG(s.DiemTK), 2)             AS [Điểm TB],
    CASE
        WHEN AVG(s.DiemTK) >= 9.0 THEN N'Xuất sắc'
        WHEN AVG(s.DiemTK) >= 8.0 THEN N'Giỏi'
        WHEN AVG(s.DiemTK) >= 6.5 THEN N'Khá'
        WHEN AVG(s.DiemTK) >= 5.0 THEN N'Trung bình'
        ELSE N'Yếu'
    END                                  AS [Học Lực]
FROM Score s
JOIN Student st ON s.MSSV = st.MSSV
GROUP BY s.MSSV, st.Fname, st.Lname
ORDER BY s.MSSV;
GO
