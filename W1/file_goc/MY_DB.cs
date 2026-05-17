// MY_DB.cs  —  Database Connection Manager
// Subject: Windows Programming  |  Topic: ADO.NET – SqlConnection
// Student: Huynh Minh Tai  |  MSSV: 22110068

using System;
using System.Data.SqlClient;

namespace StudentMIS
{
    /// <summary>
    /// Manages the SQL Server connection for the StudentMIS application.
    /// Uses localdb (MSSQLLocalDB) and the viduDB database.
    /// OOP concept: encapsulation of connection logic in a dedicated class.
    /// </summary>
    public class MY_DB
    {
        // Connection string — adjust Data Source if needed
        private SqlConnection con = new SqlConnection(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=viduDB;Integrated Security=True");

        // Property: expose the connection object (read-only)
        public SqlConnection getConnection
        {
            get { return con; }
        }

        // Open connection (only if currently closed)
        public void openConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        // Close connection (only if currently open)
        public void closeConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
    }
}
