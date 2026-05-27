using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    public class Course
    {
        My_DB db = new My_DB();

        // Các thuộc tính thuộc về môn học
        public string Mamh { get; set; }
        public string Tenmh { get; set; }
        public int Sotc { get; set; }
        public int Tuan { get; set; }
        public int Hocky { get; set; }
        public string Description { get; set; }

        // Hàm khởi tạo không tham số
        public Course() { }

        // Hàm khởi tạo đầy đủ tham số
        public Course(string ma, string ten, int tc, int tuan, int hk, string mota)
        {
            this.Mamh = ma;
            this.Tenmh = ten;
            this.Sotc = tc;
            this.Tuan = tuan;
            this.Hocky = hk;
            this.Description = mota;
        }

        // 1. CHỨC NĂNG: THÊM MÔN HỌC MỚI
        public bool AddCourse()
        {
            try
            {
                db.openConnection();
                string query = "INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES (@ma, @ten, @tc, @tuan, @hk, @mota)";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@ma", Mamh);
                cmd.Parameters.AddWithValue("@ten", Tenmh);
                cmd.Parameters.AddWithValue("@tc", Sotc);
                cmd.Parameters.AddWithValue("@tuan", Tuan);
                cmd.Parameters.AddWithValue("@hk", Hocky);
                cmd.Parameters.AddWithValue("@mota", Description ?? "");

                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        // 2. CHỨC NĂNG: SỬA THÔNG TIN MÔN HỌC
        public bool EditCourse()
        {
            try
            {
                db.openConnection();
                string query = "UPDATE Course SET TenMH = @ten, SoTC = @tc, Tuan = @tuan, Hky = @hk, Mota = @mota WHERE MaMH = @ma";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@ma", Mamh);
                cmd.Parameters.AddWithValue("@ten", Tenmh);
                cmd.Parameters.AddWithValue("@tc", Sotc);
                cmd.Parameters.AddWithValue("@tuan", Tuan);
                cmd.Parameters.AddWithValue("@hk", Hocky);
                cmd.Parameters.AddWithValue("@mota", Description ?? "");

                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        // 3. CHỨC NĂNG: XÓA MÔN HỌC
        public static bool DeleteCourse(string maMH)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                // Nâng cao theo yêu cầu của thầy: Check xem môn này đã có ai học hoặc đăng ký chưa (sẽ áp dụng chặt hơn ở Tuần 6)
                string query = "DELETE FROM Course WHERE MaMH = @ma";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@ma", maMH);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        // 4. CHỨC NĂNG: LẤY TOÀN BỘ DANH SÁCH MÔN HỌC ĐỂ ĐỔ LÊN ĐIỀU KHIỂN
        public static DataTable GetCourses()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT MaMH, TenMH, SoTC, Tuan, Hky, Mota FROM Course";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch { }
            finally { db.closeConnection(); }
            return dt;
        }

        // 5. CHỨC NĂNG NÂNG CAO: TÌM KIẾM MÔN HỌC THEO MÃ HOẶC TÊN
        public static DataTable SearchCourse(string keyword)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT * FROM Course WHERE MaMH LIKE @key OR TenMH LIKE @key";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch { }
            finally { db.closeConnection(); }
            return dt;
        }
    }
}