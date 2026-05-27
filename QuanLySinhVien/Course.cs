using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    public class Course
    {
       
        public string Mamh { get; set; }
        public string Tenmh { get; set; }
        public int Sotc { get; set; }
        public int Tuan { get; set; }
        public int Hocky { get; set; }
        public string Decription { get; set; } 

 
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
                cmd.Parameters.AddWithValue("@sotc", this.Sotc);
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