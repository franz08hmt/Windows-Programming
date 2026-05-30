using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class Score
    {
        private My_DB db = new My_DB();

        // Đồng bộ chính xác thuộc tính theo cấu trúc bảng cơ sở dữ liệu thực tế
        public string Mssv { get; set; }
        public string Mamh { get; set; } // Map vào cột Course_ID trong cơ sở dữ liệu
        public decimal Diemqt { get; set; }
        public decimal Diemck { get; set; }
        public decimal Diemtk { get; set; } // Map vào cột Score trong cơ sở dữ liệu
        public string XepLoai { get; set; }
        public string Mota { get; set; }

        public Score() { }

        // Constructor nhận đầy đủ các tham số truyền sang từ giao diện nhập điểm
        public Score(string mssv, string mamh, decimal qt, decimal ck, decimal tk, string xepLoai, string mota)
        {
            this.Mssv = mssv;
            this.Mamh = mamh;
            this.Diemqt = qt;
            this.Diemck = ck;
            this.Diemtk = tk;
            this.XepLoai = xepLoai;
            this.Mota = mota;
        }

        /// <summary>
        /// Hàm thực hiện lưu hoặc cập nhật điểm số dựa trên cấu trúc bảng thực tế: MSSV, Course_ID, Score, Description, XepLoai, Mota
        /// </summary>
        public bool SaveScore()
        {
            try
            {
                db.openConnection();

                string checkQuery = "SELECT COUNT(*) FROM Score WHERE MSSV = @mssv AND Course_ID = @mamh";
                SqlCommand checkCmd = new SqlCommand(checkQuery, db.conn);
                checkCmd.Parameters.AddWithValue("@mssv", Mssv);
                checkCmd.Parameters.AddWithValue("@mamh", Mamh);

                // ĐÃ TỐI ƯU: Sử dụng Convert.ToInt32 để tránh lỗi ép kiểu Object sang Int của SQL Driver
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                string query = "";
                if (exists > 0)
                {
                    query = "UPDATE Score SET Score = @tk, Description = @desc, XepLoai = @xl, Mota = @mota WHERE MSSV = @mssv AND Course_ID = @mamh";
                }
                else
                {
                    query = "INSERT INTO Score (MSSV, Course_ID, Score, Description, XepLoai, Mota) VALUES (@mssv, @mamh, @tk, @desc, @xl, @mota)";
                }

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Mssv);
                cmd.Parameters.AddWithValue("@mamh", Mamh);
                cmd.Parameters.AddWithValue("@tk", Diemtk);
                cmd.Parameters.AddWithValue("@desc", $"QT: {Diemqt:F1} | CK: {Diemck:F1}");
                cmd.Parameters.AddWithValue("@xl", XepLoai ?? "");
                cmd.Parameters.AddWithValue("@mota", Mota ?? "");

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu:\n{sqlEx.Message}", "Lỗi SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi hệ thống: " + ex.Message);
                return false;
            }
            finally { db.closeConnection(); }
        }

        /// <summary>
        /// Nạp bảng hiển thị điểm chi tiết lên DataGridView theo từng MSSV sinh viên
        /// </summary>
        public static DataTable GetStudentScoreBoard(string mssv)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();

                string query = @"SELECT s.Course_ID AS [Mã Môn], c.TenMH AS [Tên Môn], c.SoTC AS [Số Tín Chỉ], 
                                s.Description AS [Điểm thành phần], s.Score AS [Điểm Tổng Kết],
                                s.XepLoai AS [Xếp Loại], s.Mota AS [Ghi chú]
                         FROM Score s 
                         JOIN Course c ON s.Course_ID = c.MaMH
                         WHERE s.MSSV = @mssv";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch { }
            finally { db.closeConnection(); }
            return dt;
        }

        public static decimal CalculateGPA(string mssv)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                string query = @"SELECT SUM(
                                    CASE 
                                        WHEN s.Score >= 8.5 THEN 4.0
                                        WHEN s.Score >= 8.0 THEN 3.5
                                        WHEN s.Score >= 7.0 THEN 3.0
                                        WHEN s.Score >= 6.5 THEN 2.5
                                        WHEN s.Score >= 5.5 THEN 2.0
                                        WHEN s.Score >= 5.0 THEN 1.5
                                        WHEN s.Score >= 4.0 THEN 1.0
                                        ELSE 0.0
                                    END * c.SoTC
                                 ) / SUM(c.SoTC) 
                                 FROM Score s 
                                 JOIN Course c ON s.Course_ID = c.MaMH 
                                 WHERE s.MSSV = @mssv
                                 HAVING SUM(c.SoTC) > 0"; // <--- Chống bốc lỗi chia cho 0 ở đây ní ơi!

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    return Math.Round(Convert.ToDecimal(result), 2);
                }
                return 0; // Trả về 0 nếu sinh viên chưa học môn nào thay vì crash app
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }
    }
}