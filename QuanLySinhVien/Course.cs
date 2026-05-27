using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    public class Course
    {
        // 1. Các thuộc tính khớp 100% với code Form của bạn
        public string Mamh { get; set; }
        public string Tenmh { get; set; }
        public int Sotc { get; set; }
        public int Tuan { get; set; }
        public int Hocky { get; set; }
        public string Decription { get; set; } // Khớp với chữ "Decription" bạn viết ở form

        // 2. HÀM THÊM MÔN HỌC (Đây chính là phần code quyết định nút THÊM chạy)
        public bool AddCourse()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                // Câu lệnh SQL thêm dữ liệu vào bảng Course (hoặc tên bảng của bạn trong DB)
                string query = "INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) " +
                               "VALUES (@ma, @ten, @sotc, @tuan, @hky, @mota)";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@ma", this.Mamh);
                cmd.Parameters.AddWithValue("@ten", this.Tenmh);
                cmd.Parameters.AddWithValue("@sotc", this.Sotc);
                cmd.Parameters.AddWithValue("@tuan", this.Tuan);
                cmd.Parameters.AddWithValue("@hky", this.Hocky);
                cmd.Parameters.AddWithValue("@mota", this.Decription);

                int result = cmd.ExecuteNonQuery();

                // Nếu số dòng ảnh hưởng > 0 tức là thêm thành công
                return result > 0;
            }
            catch (Exception)
            {
                // Nếu trùng mã môn học (Primary Key) hoặc lỗi kết nối sẽ nhảy vào đây
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }

        // =========================================================================
        // TIỆN TAY LÀM SẴN CÁC HÀM CÒN LẠI CHO TAB SỬA/XÓA/DANH SÁCH CỦA BẠN LUÔN:
        // =========================================================================

        // Hàm Tìm kiếm môn học theo Mã (Phục vụ cho btnSearch_Click của bạn)
        public DataTable GetCourseByMa(string ma)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT * FROM Course WHERE MaMH = @ma";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@ma", ma);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                db.closeConnection();
            }
        }

        // Hàm Sửa môn học (Phục vụ cho btnEdit_Click của bạn)
        public bool EditCourse()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string query = "UPDATE Course SET TenMH = @ten, SoTC = @sotc, Tuan = @tuan, Hky = @hky, Mota = @mota WHERE MaMH = @ma";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@ma", this.Mamh);
                cmd.Parameters.AddWithValue("@ten", this.Tenmh);
                cmd.Parameters.AddWithValue("@sotc", this.Sotc);
                cmd.Parameters.AddWithValue("@tuan", this.Tuan);
                cmd.Parameters.AddWithValue("@hky", this.Hocky);
                cmd.Parameters.AddWithValue("@mota", this.Decription);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        // Hàm Xóa môn học (Phục vụ cho btnDel_Click của bạn)
        public bool DelCourse()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string query = "DELETE FROM Course WHERE MaMH = @ma";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@ma", this.Mamh);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        // Hàm lấy toàn bộ danh sách môn học (Phục vụ cho btnRefresh_Click của bạn)
        public static DataTable GetAllCourses()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT * FROM Course";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
            catch { return null; }
            finally { db.closeConnection(); }
        }
    }
}