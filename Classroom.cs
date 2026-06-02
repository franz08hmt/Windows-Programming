using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    public class Classroom
    {
        private My_DB db = new My_DB();

        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int SiSo { get; set; }
        public string Gvcn { get; set; }
        public string Exception { get; private set; }

        public bool AddClassroom()
        {
            string query = "INSERT INTO Classroom (MaLop, TenLop, SiSo, GVCN) VALUES (@malop, @tenlop, @siso, @gvcn)";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@malop", MaLop);
                cmd.Parameters.AddWithValue("@tenlop", TenLop);
                cmd.Parameters.AddWithValue("@siso", SiSo);
                cmd.Parameters.AddWithValue("@gvcn", Gvcn);

                db.openConnection();
                bool result = cmd.ExecuteNonQuery() == 1;
                db.closeConnection();
                return result;
            }
            catch (Exception ex)
            {
                this.Exception = ex.Message;
                return false;
            }
        }

        public static DataTable GetClassrooms()
        {
            My_DB myDb = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT MaLop as 'Mã Lớp', TenLop as 'Tên Lớp', SiSo as 'Sĩ Số', GVCN as 'GV Chủ Nhiệm' FROM Classroom";
                SqlCommand cmd = new SqlCommand(query, myDb.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch { }
            return dt;
        }

        public bool EditClassroom()
        {
            string query = "UPDATE Classroom SET TenLop = @tenlop, SiSo = @siso, GVCN = @gvcn WHERE MaLop = @malop";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@malop", MaLop);
                cmd.Parameters.AddWithValue("@tenlop", TenLop);
                cmd.Parameters.AddWithValue("@siso", SiSo);
                cmd.Parameters.AddWithValue("@gvcn", Gvcn);

                db.openConnection();
                bool result = cmd.ExecuteNonQuery() == 1;
                db.closeConnection();
                return result;
            }
            catch (Exception ex)
            {
                this.Exception = ex.Message;
                return false;
            }
        }

        public bool DelClassroom()
        {
            string query = "DELETE FROM Classroom WHERE MaLop = @malop";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@malop", MaLop);

                db.openConnection();
                bool result = cmd.ExecuteNonQuery() == 1;
                db.closeConnection();
                return result;
            }
            catch (Exception ex)
            {
                this.Exception = ex.Message;
                return false;
            }
        }
    }
}