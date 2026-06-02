using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    public class Course
    {
        // Trường dữ liệu private phục vụ validation cho thuộc tính Sotc
        private int _sotc;

        // Các thuộc tính tự động ánh xạ bảng Course
        public string Mamh { get; set; }
        public string Tenmh { get; set; }
        public int Tuan { get; set; }
        public int Hocky { get; set; }
        public string Decription { get; set; }

        public string Exception { get; set; }

        // 🌟 ĐÃ THÊM (Mục 5.1): Khối thuộc tính Sotc có bộ thiết lập (setter) kiểm tra > 0
        public int Sotc
        {
            get { return _sotc; }
            set { _sotc = value > 0 ? value : 0; }
        }

        public Course() { }

        // 🌟 ĐÃ THÊM (Mục 5.1): Phương thức getCourse nhận SqlCommand linh hoạt 
        // Giúp form con tự xây dựng câu truy vấn (ví dụ check tên môn học trùng bằng parameters)
        public DataTable getCourse(SqlCommand command)
        {
            My_DB db = new My_DB();
            DataTable table = new DataTable();
            try
            {
                // Gán kết nối động từ database của hệ thống vào command được truyền tới
                command.Connection = db.getConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi getCourse: " + ex.Message);
            }
            return table;
        }

        public bool AddCourse()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                string query = "INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) " +
                               "VALUES (@ma, @ten, @sotc, @tuan, @hky, @mota)";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@ma", this.Mamh);
                cmd.Parameters.AddWithValue("@ten", this.Tenmh);
                cmd.Parameters.AddWithValue("@sotc", this.Sotc); // Sẽ lấy giá trị đã qua validation ở setter
                cmd.Parameters.AddWithValue("@tuan", this.Tuan);
                cmd.Parameters.AddWithValue("@hky", this.Hocky);
                cmd.Parameters.AddWithValue("@mota", this.Decription);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }

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