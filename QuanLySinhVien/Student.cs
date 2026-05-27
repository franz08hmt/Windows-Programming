using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    internal class Student
    {
        My_DB db = new My_DB();

        public int MSSV { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Hometown { get; set; }
        public string Email { get; set; }
        public byte[] Pture { get; set; }

        
        public Student()
        {
        }

        
        public Student(int mssv, string fname, string lname, DateTime dob,
            string gender, string phone, string address, string hometown,
            string email, byte[] pture)
        {
            MSSV = mssv; Fname = fname; Lname = lname; Dob = dob;
            Gender = gender; Phone = phone; Address = address;
            Hometown = hometown; Email = email; Pture = pture;
        }

        

        public bool AddStudent()
        {
            try
            {
                db.openConnection();

                string query = "INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture) VALUES " +
                    "(@mssv,@fname,@lname,@dob,@gder,@phone,@addr,@htown,@email,@pic)";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", MSSV);
                cmd.Parameters.AddWithValue("@fname", Fname);
                cmd.Parameters.AddWithValue("@lname", Lname);
                cmd.Parameters.AddWithValue("@dob", Dob);
                cmd.Parameters.AddWithValue("@gder", Gender);
                cmd.Parameters.AddWithValue("@phone", Phone);
                cmd.Parameters.AddWithValue("@addr", Address);
                cmd.Parameters.AddWithValue("@htown", Hometown);
                cmd.Parameters.AddWithValue("@email", Email);

                if (Pture == null)
                {
                    cmd.Parameters.AddWithValue("@pic", SqlBinary.Null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@pic", Pture);
                }

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Rows affected: " + rows, "Debug");
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message + "\n\nStack: " + ex.StackTrace, "Lỗi AddStudent");
                return false;
            }
            finally { db.closeConnection(); }
        }

        public static DataTable GetStudents()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email, Pture FROM Student";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.conn);
                adapter.Fill(dt);
            }
            finally { db.closeConnection(); }
            return dt;
        }

        
        public static DataTable GetStudentsForCombo()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT MSSV, Lname FROM Student";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
            catch { return null; }
            finally { db.closeConnection(); }
        }

     
        public bool RegisterCourse(string mssv, string mamh)
        {
            try
            {
                db.openConnection();
                string query = "INSERT INTO DKMH (MSSV, MaMH) VALUES (@mssv, @mamh)";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv)); // Ép sang kiểu INT khớp DB của bạn
                cmd.Parameters.AddWithValue("@mamh", mamh);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        
        public bool UnregisterCourse(string mssv, string mamh)
        {
            try
            {
                db.openConnection();
                string query = "DELETE FROM DKMH WHERE MSSV = @mssv AND MaMH = @mamh";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv)); // Ép sang kiểu INT khớp DB của bạn
                cmd.Parameters.AddWithValue("@mamh", mamh);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        
        public DataTable GetRegisteredCourses(string mssv)
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT c.MaMH [Mã MH], c.TenMH [Tên môn học], c.SoTC [Số tín chỉ], c.Hky [Học kỳ] " +
                               "FROM DKMH d JOIN Course c ON d.MaMH = c.MaMH " +
                               "WHERE d.MSSV = @mssv";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv)); // Ép sang kiểu INT khớp DB của bạn
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                return dt;
            }
            catch { return null; }
            finally { db.closeConnection(); }
        }

        
        public int GetTotalCreditsBySemester(string mssv, int hky)
        {
            try
            {
                db.openConnection();
                string query = "SELECT ISNULL(SUM(c.SoTC), 0) " +
                               "FROM DKMH d JOIN Course c ON d.MaMH = c.MaMH " +
                               "WHERE d.MSSV = @mssv AND c.Hky = @hky";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv)); // Ép sang kiểu INT khớp DB của bạn
                cmd.Parameters.AddWithValue("@hky", hky);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }
    }
}