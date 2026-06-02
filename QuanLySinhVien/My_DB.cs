using System.Data.SqlClient;
using System.Configuration;

namespace QuanLySinhVien
{
    internal class My_DB
    {
        public SqlConnection conn = new SqlConnection(
            @"Data Source=G15\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True;Encrypt=False");

        public SqlConnection getConnection
        {
            get { return conn; }
        }

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    }
}