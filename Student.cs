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

        public Student() { }

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
                cmd.Parameters.AddWithValue("@pic", Pture == null ? (object)SqlBinary.Null : Pture);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi AddStudent");
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
                VietnameseTextHelper.NormalizeColumns(dt, "Fname", "Lname", "Gder", "Phone", "Email");
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
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.conn);
                adapter.Fill(dt);
                VietnameseTextHelper.NormalizeColumns(dt, "Lname");
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
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv));
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
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv));
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
                               "FROM DKMH d JOIN Course c ON d.MaMH = c.MaMH WHERE d.MSSV = @mssv";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv));
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
                string query = "SELECT ISNULL(SUM(c.SoTC), 0) FROM DKMH d JOIN Course c ON d.MaMH = c.MaMH " +
                               "WHERE d.MSSV = @mssv AND c.Hky = @hky";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv));
                cmd.Parameters.AddWithValue("@hky", hky);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }

        public static Student GetStudentByID(int mssv)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE MSSV = @mssv", db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Student(
                        Convert.ToInt32(reader["MSSV"]),
                        VietnameseTextHelper.Normalize(reader["Fname"].ToString()),
                        VietnameseTextHelper.Normalize(reader["Lname"].ToString()),
                        Convert.ToDateTime(reader["Dob"]),
                        VietnameseTextHelper.Normalize(reader["Gder"].ToString()),
                        VietnameseTextHelper.Normalize(reader["Phone"].ToString()),
                        VietnameseTextHelper.Normalize(reader["Address"].ToString()),
                        VietnameseTextHelper.Normalize(reader["Htown"].ToString()),
                        VietnameseTextHelper.Normalize(reader["Email"].ToString()),
                        reader["Pture"] == DBNull.Value ? null : (byte[])reader["Pture"]
                    );
                }
                return null;
            }
            catch { return null; }
            finally { db.closeConnection(); }
        }

        public static DataTable SearchStudents(string keyword)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email, Pture FROM Student " +
                               "WHERE CAST(MSSV AS NVARCHAR) LIKE @kw OR Fname LIKE @kw OR Lname LIKE @kw";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                VietnameseTextHelper.NormalizeColumns(dt, "Fname", "Lname", "Gder", "Phone", "Email");
                return dt;
            }
            catch { return new DataTable(); }
            finally { db.closeConnection(); }
        }

        public static double totalStudent()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student", db.conn);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }

        public static double totalMaleStudent()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE Gder = N'Nam'", db.conn);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }

        public static double totalFemaleStudent()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE Gder IN (N'Nữ', N'Nu')", db.conn);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }

        public static double totalOtherStudent()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE Gder IN (N'Khác', N'Khac')", db.conn);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch { return 0; }
            finally { db.closeConnection(); }
        }
        public static DataTable CheckDuplicate(string fname, string lname, DateTime dob)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT MSSV, Fname, Lname, Dob FROM Student " +
                               "WHERE Fname = @fname AND Lname = @lname AND CAST(Dob AS DATE) = CAST(@dob AS DATE)";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@dob", dob.Date);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                VietnameseTextHelper.NormalizeColumns(dt, "Fname", "Lname");
                return dt;
            }
            catch { return new DataTable(); }
            finally { db.closeConnection(); }
        }
    }
}
