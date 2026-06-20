-- ============================================================
-- DATA SEED  --  QuanLySinhVien  (chạy trong SSMS)
-- Mục tiêu:
--   • 45 sinh viên (5 năm × 6 SV + 15 SV cũ), giới tính cân bằng
--   • Điểm trải đều 5 xếp loại (Xuất sắc / Giỏi / Khá / Trung bình / Yếu)
--   • 5 giảng viên thực (position = 2)
--   • Fix tên admin bị lỗi encoding
-- ============================================================
USE QuanLySinhVien;
GO

-- ============================================================
-- 0. ĐẢM BẢO CỘT MỞ RỘNG TRONG BẢNG Login TỒN TẠI
--    (Dob, Gder, Phone được thêm thủ công sau khi tạo DB)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
               WHERE TABLE_NAME = 'Login' AND COLUMN_NAME = 'Dob')
    ALTER TABLE Login ADD Dob DATETIME NULL;
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
               WHERE TABLE_NAME = 'Login' AND COLUMN_NAME = 'Gder')
    ALTER TABLE Login ADD Gder NVARCHAR(10) NULL;
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
               WHERE TABLE_NAME = 'Login' AND COLUMN_NAME = 'Phone')
    ALTER TABLE Login ADD Phone NVARCHAR(15) NULL;
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
               WHERE TABLE_NAME = 'Login' AND COLUMN_NAME = 'Address')
    ALTER TABLE Login ADD Address NVARCHAR(250) NULL;
GO

-- ============================================================
-- 1. FIX TÊN ADMIN (bị mất dấu tiếng Việt khi insert cũ)
-- ============================================================
UPDATE Login
SET    Fname = N'Quản Trị', Lname = N'Viên'
WHERE  MSGV = 'ADMIN001' AND Username = 'admin';
GO

-- ============================================================
-- 2. CÁC MÔN HỌC (đảm bảo tồn tại trước khi chèn điểm)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'CS101')
    INSERT INTO Course (MaMH,TenMH,SoTC,Tuan,Hky,Mota) VALUES
    ('CS101', N'Lập trình C#', 3, 15, 1, N'Nền tảng WinForms');
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'DB201')
    INSERT INTO Course (MaMH,TenMH,SoTC,Tuan,Hky,Mota) VALUES
    ('DB201', N'Cơ sở dữ liệu', 3, 15, 1, N'SQL Server');
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'WEB301')
    INSERT INTO Course (MaMH,TenMH,SoTC,Tuan,Hky,Mota) VALUES
    ('WEB301', N'Phát triển Web', 3, 15, 2, N'ASP.NET MVC');
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'AI401')
    INSERT INTO Course (MaMH,TenMH,SoTC,Tuan,Hky,Mota) VALUES
    ('AI401', N'Nhập môn AI', 3, 15, 2, N'Phân tích dữ liệu');
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'NET501')
    INSERT INTO Course (MaMH,TenMH,SoTC,Tuan,Hky,Mota) VALUES
    ('NET501', N'Mạng máy tính', 3, 15, 1, N'Giao thức TCP/IP');
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'OOP601')
    INSERT INTO Course (MaMH,TenMH,SoTC,Tuan,Hky,Mota) VALUES
    ('OOP601', N'Lập trình hướng đối tượng', 3, 15, 1, N'Java OOP');
GO

-- ============================================================
-- 3. SỬA DỮ LIỆU CŨ BỊ LỖI ENCODING
-- ============================================================
-- 3a. Sửa Gder không dấu → có dấu
UPDATE Student SET Gder = N'Nữ'   WHERE Gder IN (N'Nu', N'nu', N'NU');
UPDATE Student SET Gder = N'Khác' WHERE Gder IN (N'Khac', N'khac', N'KHAC');

-- 3b. Sửa XepLoai trong Score không dấu → có dấu
--     (setup SQL ban đầu dùng 'Xuat sac', 'Kha', v.v. — Score.cs yêu cầu có dấu)
UPDATE Score SET XepLoai = N'Xuất sắc'  WHERE XepLoai IN (N'Xuat sac', N'xuat sac', N'XUAT SAC');
UPDATE Score SET XepLoai = N'Giỏi'      WHERE XepLoai IN (N'Gioi', N'gioi', N'GIOI');
UPDATE Score SET XepLoai = N'Khá'       WHERE XepLoai IN (N'Kha', N'kha', N'KHA');
UPDATE Score SET XepLoai = N'Trung bình' WHERE XepLoai IN (N'Trung binh', N'trung binh', N'TRUNG BINH');
UPDATE Score SET XepLoai = N'Yếu'       WHERE XepLoai IN (N'Yeu', N'yeu', N'YEU');
GO

-- ============================================================
-- 4. SINH VIÊN MỚI  (30 SV × 5 năm, cân bằng Nam/Nữ/Khác)
--    MSSV: YYMMXXXX  — dùng 101-106 tránh xung đột với dữ liệu cũ
-- ============================================================

-- ── Năm 2021 ──────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=21110101)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (21110101,N'Trần',N'Minh Quân',  '2003-03-15',N'Nam', N'0901110101',N'quan21@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=21110102)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (21110102,N'Nguyễn',N'Thu Hà',   '2003-07-22',N'Nữ', N'0901110102',N'ha21@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=21110103)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (21110103,N'Lê',N'Hoàng Phúc',   '2003-11-08',N'Nam', N'0901110103',N'phuc21@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=21110104)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (21110104,N'Phạm',N'Ngọc Lan',   '2003-02-14',N'Nữ', N'0901110104',N'lan21@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=21110105)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (21110105,N'Võ',N'Thanh Tùng',   '2003-05-30',N'Nam', N'0901110105',N'tung21@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=21110106)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (21110106,N'Đặng',N'Kim Chi',     '2003-09-18',N'Khác',N'0901110106',N'chi21@sv.hcmute.edu.vn');

-- ── Năm 2022 (bổ sung, tránh 22110001-22110092 cũ) ────────
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=22110101)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (22110101,N'Bùi',N'Quốc Hùng',   '2004-01-12',N'Nam', N'0901220101',N'hung22@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=22110102)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (22110102,N'Hồ',N'Thanh Thảo',   '2004-04-25',N'Nữ', N'0901220102',N'thao22@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=22110103)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (22110103,N'Đinh',N'Văn Long',    '2004-08-03',N'Nam', N'0901220103',N'long22@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=22110104)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (22110104,N'Mai',N'Diễm Hương',   '2004-12-20',N'Nữ', N'0901220104',N'huong22@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=22110105)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (22110105,N'Phan',N'Đức Anh',     '2004-06-14',N'Nam', N'0901220105',N'anh22@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=22110106)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (22110106,N'Lý',N'Quỳnh Như',     '2004-10-07',N'Nữ', N'0901220106',N'nhu22@sv.hcmute.edu.vn');

-- ── Năm 2023 ──────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=23110101)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (23110101,N'Ngô',N'Minh Đức',     '2005-02-28',N'Nam', N'0901230101',N'duc23@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=23110102)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (23110102,N'Tô',N'Bích Ngân',     '2005-06-15',N'Nữ', N'0901230102',N'ngan23@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=23110103)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (23110103,N'Châu',N'Văn Hải',     '2005-10-22',N'Nam', N'0901230103',N'hai23@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=23110104)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (23110104,N'Đỗ',N'Thanh Vân',     '2005-03-09',N'Nữ', N'0901230104',N'van23@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=23110105)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (23110105,N'Trương',N'Quang Vinh','2005-07-18',N'Nam', N'0901230105',N'vinh23@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=23110106)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (23110106,N'Vũ',N'Hải Yến',       '2005-11-30',N'Khác',N'0901230106',N'yen23@sv.hcmute.edu.vn');

-- ── Năm 2024 ──────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=24110101)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (24110101,N'Lê',N'Anh Tuấn',      '2006-01-25',N'Nam', N'0901240101',N'tuan24@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=24110102)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (24110102,N'Nguyễn',N'Phương Linh','2006-05-12',N'Nữ', N'0901240102',N'linh24@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=24110103)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (24110103,N'Trần',N'Công Danh',   '2006-09-04',N'Nam', N'0901240103',N'danh24@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=24110104)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (24110104,N'Phạm',N'Thị Hoa',     '2006-02-17',N'Nữ', N'0901240104',N'hoa24@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=24110105)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (24110105,N'Hoàng',N'Văn Thắng',  '2006-06-28',N'Nam', N'0901240105',N'thang24@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=24110106)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (24110106,N'Lương',N'Bảo Châu',   '2006-10-15',N'Khác',N'0901240106',N'chau24@sv.hcmute.edu.vn');

-- ── Năm 2025 ──────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=25110101)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (25110101,N'Đinh',N'Trọng Nghĩa', '2007-03-08',N'Nam', N'0901250101',N'nghia25@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=25110102)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (25110102,N'Đoàn',N'Thị Mỹ',      '2007-07-19',N'Nữ', N'0901250102',N'my25@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=25110103)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (25110103,N'Phan',N'Thanh Sơn',   '2007-11-11',N'Nam', N'0901250103',N'son25@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=25110104)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (25110104,N'Nguyễn',N'Khánh Huyền','2007-04-23',N'Nữ', N'0901250104',N'huyen25@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=25110105)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (25110105,N'Lê',N'Đức Khôi',      '2007-08-30',N'Nam', N'0901250105',N'khoi25@sv.hcmute.edu.vn');
IF NOT EXISTS (SELECT 1 FROM Student WHERE MSSV=25110106)
    INSERT INTO Student (MSSV,Fname,Lname,Dob,Gder,Phone,Email) VALUES
    (25110106,N'Bùi',N'Minh Thư',     '2007-12-05',N'Nữ', N'0901250106',N'thu25@sv.hcmute.edu.vn');
GO

-- ============================================================
-- 5. ĐIỂM SỐ CHO 30 SINH VIÊN MỚI
--    Phân bố mục tiêu (mỗi SV 2 môn):
--      Xuất sắc (≥9.0): ~12 bản ghi
--      Giỏi     (8-8.9): ~16 bản ghi
--      Khá      (6.5-7.9): ~20 bản ghi
--      Trung bình (5-6.4): ~10 bản ghi
--      Yếu      (<5.0): ~6 bản ghi
--    XepLoai PHẢI khớp chính xác với Score.cs:
--      N'Xuất sắc', N'Giỏi', N'Khá', N'Trung bình', N'Yếu'
-- ============================================================

-- ── 2021 ──────────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110101 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110101,'CS101', 9.5, 9.5, 9.50, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110101 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110101,'DB201', 8.5, 9.0, 8.80, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110102 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110102,'CS101', 8.0, 8.5, 8.30, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110102 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110102,'WEB301',7.5, 8.0, 7.80, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110103 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110103,'DB201', 9.0, 9.5, 9.30, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110103 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110103,'AI401', 7.0, 7.5, 7.30, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110104 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110104,'CS101', 7.5, 7.0, 7.20, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110104 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110104,'WEB301',6.0, 6.5, 6.30, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110105 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110105,'DB201', 5.5, 6.0, 5.80, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110105 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110105,'AI401', 8.5, 8.0, 8.20, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110106 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110106,'CS101', 3.5, 4.0, 3.80, N'Yếu');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=21110106 AND MaMH='NET501')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (21110106,'NET501',7.0, 7.5, 7.30, N'Khá');

-- ── 2022 thêm ─────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110101 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110101,'CS101', 9.0, 9.5, 9.30, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110101 AND MaMH='OOP601')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110101,'OOP601',8.0, 8.5, 8.30, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110102 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110102,'DB201', 7.0, 7.5, 7.30, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110102 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110102,'WEB301',6.5, 7.0, 6.80, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110103 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110103,'CS101', 5.5, 5.0, 5.20, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110103 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110103,'AI401', 8.5, 9.0, 8.80, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110104 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110104,'DB201', 9.5, 9.5, 9.50, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110104 AND MaMH='NET501')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110104,'NET501',8.0, 8.5, 8.30, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110105 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110105,'WEB301',4.0, 3.5, 3.70, N'Yếu');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110105 AND MaMH='OOP601')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110105,'OOP601',6.0, 5.5, 5.70, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110106 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110106,'CS101', 7.5, 8.0, 7.80, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=22110106 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (22110106,'DB201', 6.0, 6.5, 6.30, N'Trung bình');

-- ── 2023 ──────────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110101 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110101,'CS101', 8.5, 8.0, 8.20, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110101 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110101,'AI401', 9.0, 9.5, 9.30, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110102 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110102,'DB201', 7.0, 6.5, 6.70, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110102 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110102,'WEB301',5.5, 5.0, 5.20, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110103 AND MaMH='OOP601')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110103,'OOP601',3.5, 4.0, 3.80, N'Yếu');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110103 AND MaMH='NET501')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110103,'NET501',7.5, 7.0, 7.20, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110104 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110104,'CS101', 9.5, 9.0, 9.20, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110104 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110104,'DB201', 8.0, 8.5, 8.30, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110105 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110105,'AI401', 6.5, 7.0, 6.80, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110105 AND MaMH='OOP601')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110105,'OOP601',5.0, 5.5, 5.30, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110106 AND MaMH='NET501')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110106,'NET501',8.5, 8.0, 8.20, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=23110106 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (23110106,'WEB301',6.0, 6.5, 6.30, N'Trung bình');

-- ── 2024 ──────────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110101 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110101,'CS101', 7.5, 8.0, 7.80, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110101 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110101,'DB201', 9.0, 9.5, 9.30, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110102 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110102,'WEB301',8.0, 8.5, 8.30, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110102 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110102,'AI401', 7.0, 7.5, 7.30, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110103 AND MaMH='OOP601')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110103,'OOP601',5.5, 6.0, 5.80, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110103 AND MaMH='NET501')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110103,'NET501',4.0, 4.5, 4.30, N'Yếu');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110104 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110104,'CS101', 8.5, 9.0, 8.80, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110104 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110104,'AI401', 6.5, 7.0, 6.80, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110105 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110105,'DB201', 5.0, 5.5, 5.30, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110105 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110105,'WEB301',7.5, 7.0, 7.20, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110106 AND MaMH='NET501')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110106,'NET501',9.0, 9.0, 9.00, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=24110106 AND MaMH='OOP601')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (24110106,'OOP601',8.0, 7.5, 7.70, N'Khá');

-- ── 2025 ──────────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110101 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110101,'CS101', 8.0, 8.5, 8.30, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110101 AND MaMH='OOP601')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110101,'OOP601',6.0, 6.5, 6.30, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110102 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110102,'DB201', 3.5, 3.0, 3.20, N'Yếu');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110102 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110102,'WEB301',7.0, 7.5, 7.30, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110103 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110103,'AI401', 9.5, 9.0, 9.20, N'Xuất sắc');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110103 AND MaMH='NET501')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110103,'NET501',8.5, 8.0, 8.20, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110104 AND MaMH='CS101')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110104,'CS101', 7.0, 7.5, 7.30, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110104 AND MaMH='OOP601')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110104,'OOP601',5.5, 5.0, 5.20, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110105 AND MaMH='DB201')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110105,'DB201', 8.0, 8.5, 8.30, N'Giỏi');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110105 AND MaMH='WEB301')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110105,'WEB301',6.5, 6.0, 6.20, N'Trung bình');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110106 AND MaMH='AI401')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110106,'AI401', 7.5, 8.0, 7.80, N'Khá');
IF NOT EXISTS (SELECT 1 FROM Score WHERE MSSV=25110106 AND MaMH='NET501')
    INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai) VALUES (25110106,'NET501',9.0, 9.5, 9.30, N'Xuất sắc');
GO

-- ============================================================
-- 6. GIẢNG VIÊN MỚI (position=2, VALID=1)
--    Username=Pass=MSGV để tiện test login
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV001')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV001',N'Nguyễn',N'Văn Hùng','GV001','GV001','hung@hcmute.edu.vn',
            '1985-04-12',N'Nam',N'0909001001',N'Quận 1, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV002')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV002',N'Trần',N'Thị Mai','GV002','GV002','mai@hcmute.edu.vn',
            '1988-09-25',N'Nữ',N'0909001002',N'Quận 3, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV003')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV003',N'Lê',N'Minh Tùng','GV003','GV003','tung@hcmute.edu.vn',
            '1990-02-18',N'Nam',N'0909001003',N'Quận 5, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV004')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV004',N'Phạm',N'Thanh Hoa','GV004','GV004','hoa@hcmute.edu.vn',
            '1992-06-30',N'Nữ',N'0909001004',N'Quận 7, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV005')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV005',N'Hoàng',N'Đức Thắng','GV005','GV005','thang@hcmute.edu.vn',
            '1987-11-05',N'Nam',N'0909001005',N'Quận 9, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV006')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV006',N'Vũ',N'Thành Long','GV006','GV006','long@hcmute.edu.vn',
            '1989-03-14',N'Nam',N'0909001006',N'Quận Bình Thạnh, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV007')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV007',N'Đặng',N'Thị Lan Anh','GV007','GV007','lananh@hcmute.edu.vn',
            '1991-07-22',N'Nữ',N'0909001007',N'Quận Gò Vấp, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV008')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV008',N'Bùi',N'Quốc Hưng','GV008','GV008','hung2@hcmute.edu.vn',
            '1986-12-09',N'Nam',N'0909001008',N'Quận Tân Bình, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV009')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV009',N'Ngô',N'Thị Hương','GV009','GV009','huong@hcmute.edu.vn',
            '1993-05-17',N'Nữ',N'0909001009',N'Quận Phú Nhuận, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'GV010')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('GV010',N'Lý',N'Minh Khoa','GV010','GV010','khoa@hcmute.edu.vn',
            '1984-08-28',N'Nam',N'0909001010',N'Quận 10, TP.HCM', 2, 1);
IF NOT EXISTS (SELECT 1 FROM Login WHERE MSGV = 'HR001')
    INSERT INTO Login (MSGV,Fname,Lname,Username,Pass,Email,Dob,Gder,Phone,Address,position,VALID)
    VALUES ('HR001',N'Trịnh',N'Thị Bảo Châu','HR001','HR001','bauchau@hcmute.edu.vn',
            '1990-01-15',N'Nữ',N'0909002001',N'Quận 12, TP.HCM', 2, 1);
GO

-- ============================================================
-- 7. CẬP NHẬT ĐẦY ĐỦ THÔNG TIN GIẢNG VIÊN
--    Điền Dob, Gder, Phone, Address cho các bản ghi còn thiếu
--    (chỉ UPDATE khi field đang NULL để không ghi đè dữ liệu hợp lệ)
-- ============================================================
UPDATE Login SET Dob='1985-04-12', Gder=N'Nam',  Phone=N'0909001001', Address=N'Quận 1, TP.HCM'
WHERE MSGV='GV001' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1988-09-25', Gder=N'Nữ',   Phone=N'0909001002', Address=N'Quận 3, TP.HCM'
WHERE MSGV='GV002' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1990-02-18', Gder=N'Nam',  Phone=N'0909001003', Address=N'Quận 5, TP.HCM'
WHERE MSGV='GV003' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1992-06-30', Gder=N'Nữ',   Phone=N'0909001004', Address=N'Quận 7, TP.HCM'
WHERE MSGV='GV004' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1987-11-05', Gder=N'Nam',  Phone=N'0909001005', Address=N'Quận 9, TP.HCM'
WHERE MSGV='GV005' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1989-03-14', Gder=N'Nam',  Phone=N'0909001006', Address=N'Quận Bình Thạnh, TP.HCM'
WHERE MSGV='GV006' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1991-07-22', Gder=N'Nữ',   Phone=N'0909001007', Address=N'Quận Gò Vấp, TP.HCM'
WHERE MSGV='GV007' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1986-12-09', Gder=N'Nam',  Phone=N'0909001008', Address=N'Quận Tân Bình, TP.HCM'
WHERE MSGV='GV008' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1993-05-17', Gder=N'Nữ',   Phone=N'0909001009', Address=N'Quận Phú Nhuận, TP.HCM'
WHERE MSGV='GV009' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1984-08-28', Gder=N'Nam',  Phone=N'0909001010', Address=N'Quận 10, TP.HCM'
WHERE MSGV='GV010' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
UPDATE Login SET Dob='1990-01-15', Gder=N'Nữ',   Phone=N'0909002001', Address=N'Quận 12, TP.HCM'
WHERE MSGV='HR001' AND (Dob IS NULL OR Gder IS NULL OR Phone IS NULL OR Address IS NULL);
GO

-- ============================================================
-- 8. KIỂM TRA KẾT QUẢ
-- ============================================================
SELECT 'Tổng sinh viên'     AS [Bảng],   COUNT(*) AS [Số lượng] FROM Student
UNION ALL
SELECT 'Tổng bản ghi điểm', COUNT(*) FROM Score
UNION ALL
SELECT 'Tổng giảng viên',   COUNT(*) FROM Login WHERE position = 2
UNION ALL
SELECT 'Tổng môn học',      COUNT(*) FROM Course;

SELECT Gder AS [Giới tính], COUNT(*) AS [Số SV] FROM Student GROUP BY Gder ORDER BY Gder;

SELECT XepLoai AS [Xếp loại], COUNT(*) AS [Số bản ghi điểm]
FROM Score WHERE XepLoai IS NOT NULL
GROUP BY XepLoai
ORDER BY CASE XepLoai
    WHEN N'Xuất sắc'  THEN 1
    WHEN N'Giỏi'      THEN 2
    WHEN N'Khá'       THEN 3
    WHEN N'Trung bình' THEN 4
    WHEN N'Yếu'       THEN 5 ELSE 6 END;
GO
