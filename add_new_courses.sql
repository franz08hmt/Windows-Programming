-- ================================================================
-- add_new_courses.sql
-- Thêm 20 môn học mới vào Course table
-- Hky bị giới hạn 1-3 bởi CHECK constraint → tất cả dùng trong range đó
-- Chạy trong SSMS kết nối G15\SQLEXPRESS > QuanLySinhVien
-- ================================================================

USE QuanLySinhVien;
GO

-- ── HỌC KỲ 2 ─────────────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'SE201')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('SE201', N'Kỹ nghệ phần mềm', 3, 15, 2, N'Quy trình phát triển phần mềm chuyên nghiệp');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'OS202')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('OS202', N'Hệ điều hành', 3, 15, 2, N'Linux, tiến trình, quản lý bộ nhớ');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'DSA203')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('DSA203', N'Cấu trúc dữ liệu và giải thuật', 3, 15, 2, N'Stack, Queue, Tree, Sorting, Searching');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'UI204')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('UI204', N'Thiết kế giao diện người dùng', 2, 15, 2, N'UX/UI, Figma, nguyên tắc thiết kế');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'PROB205')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('PROB205', N'Xác suất thống kê', 3, 15, 2, N'Ứng dụng trong khoa học dữ liệu');

-- ── HỌC KỲ 3 ─────────────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'ML301')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('ML301', N'Học máy', 3, 15, 3, N'Supervised, Unsupervised, Neural Networks');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'MOB302')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('MOB302', N'Lập trình di động', 3, 15, 3, N'Android & iOS với Flutter/React Native');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'SEC303')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('SEC303', N'An toàn thông tin', 3, 15, 3, N'Mật mã học, bảo mật mạng, OWASP Top 10');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'CLOUD304')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('CLOUD304', N'Điện toán đám mây', 3, 15, 3, N'AWS, Azure, Docker, Kubernetes cơ bản');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'PM305')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('PM305', N'Quản lý dự án phần mềm', 2, 15, 3, N'Agile, Scrum, Kanban, ước lượng dự án');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'ALGO306')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('ALGO306', N'Thiết kế và phân tích giải thuật', 3, 15, 3, N'Dynamic Programming, Graph, NP-Complete');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'EMBED307')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('EMBED307', N'Hệ thống nhúng', 3, 15, 3, N'Arduino, ARM Cortex, lập trình vi điều khiển');

-- ── 8 MÔN CÒN LẠI — dùng Hky=3 (max cho phép) ──────────────────
IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'DL401')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('DL401', N'Học sâu (Deep Learning)', 3, 15, 3, N'CNN, RNN, Transformer, ứng dụng thực tế');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'IOT402')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('IOT402', N'Internet of Things', 3, 15, 3, N'Cảm biến, giao thức MQTT, nền tảng IoT');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'DEVOPS403')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('DEVOPS403', N'DevOps & CI/CD', 2, 15, 3, N'Jenkins, GitLab CI, triển khai tự động');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'BIGDATA404')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('BIGDATA404', N'Xử lý dữ liệu lớn', 3, 15, 3, N'Hadoop, Spark, data pipeline');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'GRAPH405')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('GRAPH405', N'Đồ họa máy tính', 3, 15, 3, N'OpenGL, ray tracing, rendering pipeline');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'DIST406')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('DIST406', N'Hệ thống phân tán', 3, 15, 3, N'Microservices, CAP theorem, consensus');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'BCHAIN501')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('BCHAIN501', N'Công nghệ Blockchain', 2, 15, 3, N'Smart contract, Ethereum, ứng dụng phi tập trung');

IF NOT EXISTS (SELECT 1 FROM Course WHERE MaMH = 'NLPAI502')
    INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES
    ('NLPAI502', N'Xử lý ngôn ngữ tự nhiên', 3, 15, 3, N'NLP, LLM, chatbot, phân tích văn bản tiếng Việt');

GO

-- ── KIỂM TRA ─────────────────────────────────────────────────────
SELECT COUNT(*) AS [Tổng môn học] FROM Course;
GO

SELECT MaMH, TenMH, SoTC, Hky
FROM Course
WHERE MaMH IN (
    'SE201','OS202','DSA203','UI204','PROB205',
    'ML301','MOB302','SEC303','CLOUD304','PM305','ALGO306','EMBED307',
    'DL401','IOT402','DEVOPS403','BIGDATA404','GRAPH405','DIST406',
    'BCHAIN501','NLPAI502'
)
ORDER BY Hky, MaMH;
GO
