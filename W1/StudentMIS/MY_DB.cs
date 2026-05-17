// MY_DB.cs  —  Database Connection Manager
// Subject: Windows Programming  |  Topic: ADO.NET – SqlConnection
// Student: Huynh Minh Tai  |  MSSV: 22110068

using System;
using System.Data.SqlClient;

namespace StudentMIS
{
    public class MY_DB
    {
        private SqlConnection con = new SqlConnection(
            @"Data Source=G15\SQLEXPRESS;Initial Catalog=viduDB;Integrated Security=True");

        public SqlConnection getConnection
        {
            get { return con; }
        }

        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
    }
}