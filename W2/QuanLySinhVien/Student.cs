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
    }
}