using System;
using System.Data;
using System.Data.SqlClient;
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
        public byte[] Picture { get; set; }

        public Student(int mssv, string fname, string lname, DateTime dob,
            string gender, string phone, string address, string hometown,
            string email, byte[] picture)
        {
            MSSV = mssv; Fname = fname; Lname = lname; Dob = dob;
            Gender = gender; Phone = phone; Address = address;
            Hometown = hometown; Email = email; Picture = picture;
        }

        public bool AddStudent()
        {
            try
            {
                db.openConnection();
                string query = "INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email) VALUES " +
                    "(@mssv,@fname,@lname,@dob,@gder,@phone,@addr,@htown,@email)";
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

        public bool EditStudent()
        {
            try
            {
                db.openConnection();
                string query = "UPDATE Student SET Fname=@fname, Lname=@lname, " +
                    "Dob=@dob, Gder=@gder, Phone=@phone, Address=@addr, " +
                    "Htown=@htown, Email=@email WHERE MSSV=@mssv";
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
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi EditStudent");
                return false;
            }
            finally { db.closeConnection(); }
        }

        public static bool DeleteStudent(int mssv)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string query = "DELETE FROM Student WHERE MSSV=@mssv";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi DeleteStudent");
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
                string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email FROM Student";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.conn);
                adapter.Fill(dt);
            }
            finally { db.closeConnection(); }
            return dt;
        }
        // Tìm kiếm sinh viên theo keyword (MSSV, Họ, Tên, Email)
        public static DataTable SearchStudents(string keyword)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string query = @"SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email 
                         FROM Student 
                         WHERE CAST(MSSV AS NVARCHAR) LIKE @kw
                            OR Fname LIKE @kw 
                            OR Lname LIKE @kw 
                            OR Email LIKE @kw";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch { return new DataTable(); }
            finally { db.closeConnection(); }
        }

        // Lấy 1 sinh viên theo MSSV, trả về object Student đầy đủ data
        public static Student GetStudentByID(int mssv)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Student WHERE MSSV=@mssv", db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    byte[] pic = null;
                    if (reader["Pture"] != DBNull.Value)
                        pic = (byte[])reader["Pture"];

                    Student s = new Student(
                        (int)reader["MSSV"],
                        reader["Fname"].ToString(),
                        reader["Lname"].ToString(),
                        (DateTime)reader["Dob"],
                        reader["Gder"].ToString(),
                        reader["Phone"].ToString(),
                        reader["Address"].ToString(),
                        reader["Htown"].ToString(),
                        reader["Email"].ToString(),
                        pic
                    );
                    reader.Close();
                    return s;
                }
                reader.Close();
                return null;
            }
            catch { return null; }
            finally { db.closeConnection(); }
        }
        // Lấy danh sách SV có điểm TB < ngưỡng
        public static DataTable GetLowScoreStudents(double threshold = 5.0)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string query = @"
            SELECT s.MSSV, s.Fname, s.Lname, 
                   ROUND(AVG(sc.Diem), 2) AS DiemTB
            FROM Student s
            INNER JOIN Score sc ON s.MSSV = sc.MSSV
            GROUP BY s.MSSV, s.Fname, s.Lname
            HAVING AVG(sc.Diem) < @threshold
            ORDER BY AVG(sc.Diem) ASC";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@threshold", threshold);
                DataTable dt = new DataTable();
                new SqlDataAdapter(cmd).Fill(dt);
                return dt;
            }
            catch { return new DataTable(); }
            finally { db.closeConnection(); }
        }
    }

}