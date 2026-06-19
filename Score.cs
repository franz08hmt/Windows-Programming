using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class Score
    {
        private My_DB db = new My_DB();

        public int Mssv { get; set; }
        public string Mamh { get; set; }
        public decimal Diemqt { get; set; }
        public decimal Diemck { get; set; }
        public decimal Diemtk { get; set; }
        public string XepLoai { get; set; }
        public string Mota { get; set; }

        public Score() { }

        public Score(int mssv, string mamh, decimal qt, decimal ck, decimal tk, string xepLoai, string mota)
        {
            Mssv = mssv; Mamh = mamh;
            Diemqt = qt; Diemck = ck; Diemtk = tk;
            XepLoai = xepLoai; Mota = mota;
        }

        public static decimal TinhDiemTK(decimal qt, decimal ck)
            => Math.Round(qt * 0.4m + ck * 0.6m, 2);

        public static string XepLoaiTheoTK(decimal tk)
        {
            if (tk >= 9.0m) return "Xuất sắc";
            if (tk >= 8.0m) return "Giỏi";
            if (tk >= 6.5m) return "Khá";
            if (tk >= 5.0m) return "Trung bình";
            return "Yếu";
        }

        public bool SaveScore()
        {
            try
            {
                db.openConnection();

                string checkQuery = "SELECT COUNT(*) FROM Score WHERE MSSV=@mssv AND MaMH=@mamh";
                SqlCommand checkCmd = new SqlCommand(checkQuery, db.conn);
                checkCmd.Parameters.AddWithValue("@mssv", Mssv);
                checkCmd.Parameters.AddWithValue("@mamh", Mamh);
                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                string query = exists > 0
                    ? "UPDATE Score SET DiemQT=@qt, DiemCK=@ck, DiemTK=@tk, XepLoai=@xl, Mota=@mota WHERE MSSV=@mssv AND MaMH=@mamh"
                    : "INSERT INTO Score (MSSV,MaMH,DiemQT,DiemCK,DiemTK,XepLoai,Mota) VALUES (@mssv,@mamh,@qt,@ck,@tk,@xl,@mota)";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Mssv);
                cmd.Parameters.AddWithValue("@mamh", Mamh);
                cmd.Parameters.AddWithValue("@qt", Diemqt);
                cmd.Parameters.AddWithValue("@ck", Diemck);
                cmd.Parameters.AddWithValue("@tk", Diemtk);
                cmd.Parameters.AddWithValue("@xl", XepLoai ?? "");
                cmd.Parameters.AddWithValue("@mota", Mota ?? "");

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { db.closeConnection(); }
        }

        public static DataTable GetStudentScoreBoard(string mssv)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = @"
                    SELECT s.MaMH    AS [Mã Môn],
                           c.TenMH   AS [Tên Môn],
                           c.SoTC    AS [Số TC],
                           s.DiemQT  AS [Điểm QT],
                           s.DiemCK  AS [Điểm CK],
                           s.DiemTK  AS [Điểm TK],
                           s.XepLoai AS [Xếp Loại],
                           s.Mota    AS [Ghi Chú]
                    FROM Score s
                    JOIN Course c ON s.MaMH = c.MaMH
                    WHERE s.MSSV = @mssv";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv));
                new SqlDataAdapter(cmd).Fill(dt);
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
                string query = @"
                    SELECT SUM(
                        CASE
                            WHEN s.DiemTK >= 8.5 THEN 4.0
                            WHEN s.DiemTK >= 8.0 THEN 3.5
                            WHEN s.DiemTK >= 7.0 THEN 3.0
                            WHEN s.DiemTK >= 6.5 THEN 2.5
                            WHEN s.DiemTK >= 5.5 THEN 2.0
                            WHEN s.DiemTK >= 5.0 THEN 1.5
                            WHEN s.DiemTK >= 4.0 THEN 1.0
                            ELSE 0.0
                        END * c.SoTC
                    ) / SUM(c.SoTC)
                    FROM Score s
                    JOIN Course c ON s.MaMH = c.MaMH
                    WHERE s.MSSV = @mssv
                    HAVING SUM(c.SoTC) > 0";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv));
                object result = cmd.ExecuteScalar();
                return (result != null && result != DBNull.Value)
                    ? Math.Round(Convert.ToDecimal(result), 2) : 0;
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }

        // ── Tuần 09: Thống kê ──────────────────────────

        public static DataTable GetScoreStatistics()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = @"
                    SELECT st.MSSV,
                           st.Fname + ' ' + st.Lname AS [Họ Tên],
                           ROUND(AVG(s.DiemTK), 2)   AS [Điểm TB],
                           CASE
                               WHEN AVG(s.DiemTK) >= 9   THEN N'Xuất sắc'
                               WHEN AVG(s.DiemTK) >= 8   THEN N'Giỏi'
                               WHEN AVG(s.DiemTK) >= 6.5 THEN N'Khá'
                               WHEN AVG(s.DiemTK) >= 5   THEN N'Trung bình'
                               ELSE N'Yếu'
                           END AS [Xếp Loại]
                    FROM Student st
                    JOIN Score s ON st.MSSV = s.MSSV
                    GROUP BY st.MSSV, st.Fname, st.Lname
                    ORDER BY AVG(s.DiemTK) DESC";
                new SqlDataAdapter(new SqlCommand(query, db.conn)).Fill(dt);
            }
            catch { }
            finally { db.closeConnection(); }
            return dt;
        }

        public static DataTable GetCountByXepLoai()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                // Xếp loại theo điểm TB của từng sinh viên (không đếm bản ghi điểm thô)
                // → tổng Số Lượng = số SV có điểm, khớp với lblTongSV
                string query = @"
                    SELECT sv_grade.XepLoai AS [Xếp Loại],
                           COUNT(*)         AS [Số Lượng]
                    FROM (
                        SELECT MSSV,
                               CASE
                                   WHEN AVG(DiemTK) >= 9.0 THEN N'Xuất sắc'
                                   WHEN AVG(DiemTK) >= 8.0 THEN N'Giỏi'
                                   WHEN AVG(DiemTK) >= 6.5 THEN N'Khá'
                                   WHEN AVG(DiemTK) >= 5.0 THEN N'Trung bình'
                                   ELSE N'Yếu'
                               END AS XepLoai
                        FROM Score
                        WHERE DiemTK IS NOT NULL
                        GROUP BY MSSV
                    ) AS sv_grade
                    GROUP BY sv_grade.XepLoai
                    ORDER BY CASE sv_grade.XepLoai
                        WHEN N'Xuất sắc'   THEN 1
                        WHEN N'Giỏi'       THEN 2
                        WHEN N'Khá'        THEN 3
                        WHEN N'Trung bình' THEN 4
                        WHEN N'Yếu'        THEN 5
                        ELSE 6
                    END";
                new SqlDataAdapter(new SqlCommand(query, db.conn)).Fill(dt);
            }
            catch { }
            finally { db.closeConnection(); }
            return dt;
        }

        public static DataTable GetAvgScoreBySubject()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = @"
                    SELECT c.TenMH          AS [Môn Học],
                           ROUND(AVG(s.DiemTK), 2) AS [Điểm TB]
                    FROM Score s
                    JOIN Course c ON s.MaMH = c.MaMH
                    GROUP BY c.TenMH
                    ORDER BY c.TenMH";
                new SqlDataAdapter(new SqlCommand(query, db.conn)).Fill(dt);
            }
            catch { }
            finally { db.closeConnection(); }
            return dt;
        }
    }
}
