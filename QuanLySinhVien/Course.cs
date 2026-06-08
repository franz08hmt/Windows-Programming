using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    public class Course
    {
        private My_DB my_db = new My_DB();
        private int _sotc;

        public string Mamh { get; set; }
        public string Tenmh { get; set; }
        public int Tuan { get; set; }
        public int Hocky { get; set; }
        public string Decription { get; set; }
        public string Exception { get; private set; }

        // Validation trong setter theo yêu cầu đề bài
        public int Sotc
        {
            get { return _sotc; }
            set { _sotc = value > 0 ? value : 0; }
        }

        // Phương thức getCourse linh hoạt nhận SqlCommand từ Form con (Giữ nguyên của bạn)
        public DataTable getCourse(SqlCommand command)
        {
            command.Connection = my_db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                this.Exception = ex.Message;
            }
            return table;
        }

        // ===================================================================
        // 🚀 CÁC PHƯƠNG THỨC TĨNH (STATIC) ĐỂ SỬA TRIỆT ĐỂ LỖI Ở f_ManageCourse.cs
        // ===================================================================

        // 1. Hàm lấy toàn bộ danh sách môn học tĩnh (Giải quyết lỗi dòng 344)
        public static DataTable GetAllCourses()
        {
            My_DB tempDb = new My_DB();
            SqlCommand command = new SqlCommand("SELECT * FROM Course", tempDb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu có ngoại lệ xảy ra khi truy vấn dữ liệu
            }
            return table;
        }

        // 2. Hàm lấy chi tiết môn học tĩnh theo Mã môn học (Giải quyết lỗi dòng 208)
        public static DataTable GetCourseByMa(string courseId)
        {
            My_DB tempDb = new My_DB();
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE MaMH = @id", tempDb.getConnection);
            command.Parameters.AddWithValue("@id", courseId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu có ngoại lệ xảy ra khi truy vấn dữ liệu
            }
            return table;
        }

        // ===================================================================
        // 🛠️ CÁC PHƯƠNG THỨC XỬ LÝ DỮ LIỆU CŨ CỦA BẠN (GIỮ NGUYÊN HOÀN TOÀN)
        // ===================================================================

        public bool AddCourse()
        {
            SqlCommand command = new SqlCommand(
                "INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES (@mamh, @tenmh, @sotc, @tuan, @hky, @mota)",
                my_db.getConnection);

            command.Parameters.Add("@mamh", SqlDbType.Char, 20).Value = Mamh;
            command.Parameters.Add("@tenmh", SqlDbType.NVarChar, 100).Value = Tenmh;
            command.Parameters.Add("@sotc", SqlDbType.Int).Value = Sotc;
            command.Parameters.Add("@tuan", SqlDbType.Int).Value = Tuan;
            command.Parameters.Add("@hky", SqlDbType.Int).Value = Hocky;
            command.Parameters.Add("@mota", SqlDbType.NVarChar, -1).Value = Decription;

            return ExecuteCommand(command);
        }

        public bool EditCourse()
        {
            SqlCommand command = new SqlCommand(
                "UPDATE Course SET TenMH=@tenmh, SoTC=@sotc, Tuan=@tuan, Hky=@hky, Mota=@mota WHERE MaMH=@mamh",
                my_db.getConnection);

            command.Parameters.Add("@mamh", SqlDbType.Char, 20).Value = Mamh;
            command.Parameters.Add("@tenmh", SqlDbType.NVarChar, 100).Value = Tenmh;
            command.Parameters.Add("@sotc", SqlDbType.Int).Value = Sotc;
            command.Parameters.Add("@tuan", SqlDbType.Int).Value = Tuan;
            command.Parameters.Add("@hky", SqlDbType.Int).Value = Hocky;
            command.Parameters.Add("@mota", SqlDbType.NVarChar, -1).Value = Decription;

            return ExecuteCommand(command);
        }

        public bool DelCourse()
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE MaMH=@mamh", my_db.getConnection);
            command.Parameters.Add("@mamh", SqlDbType.Char, 20).Value = Mamh;
            return ExecuteCommand(command);
        }

        private bool ExecuteCommand(SqlCommand command)
        {
            try
            {
                my_db.openConnection();
                bool result = command.ExecuteNonQuery() == 1;
                my_db.closeConnection();
                return result;
            }
            catch (Exception ex)
            {
                this.Exception = ex.Message;
                my_db.closeConnection();
                return false;
            }
        }
    }
}