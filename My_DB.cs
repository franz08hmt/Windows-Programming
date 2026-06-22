using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace QuanLySinhVien
{
    internal class My_DB : IDisposable
    {
        public SqlConnection conn;
        private DateTime? _openedAt;
        private string _callerClass;

        public My_DB()
        {
            // Đọc connection string từ App.config; fallback về hardcode nếu chưa cấu hình
            string connStr = ConfigurationManager.ConnectionStrings["QuanLySinhVien"]?.ConnectionString
                ?? @"Data Source=G15\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True;Encrypt=False";
            conn = new SqlConnection(connStr);
        }

        public SqlConnection getConnection => conn;

        public void openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                _openedAt = DateTime.Now;
                _callerClass = new StackFrame(1, false).GetMethod()?.DeclaringType?.Name ?? "Unknown";
                ConnectionLogger.LogOpen(_openedAt.Value, _callerClass);
            }
        }

        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                if (_openedAt.HasValue)
                {
                    ConnectionLogger.LogClose(_openedAt.Value, _callerClass ?? "Unknown");
                    _openedAt = null;
                }
            }
        }

        // IDisposable: đảm bảo kết nối luôn được đóng kể cả khi quên gọi closeConnection
        public void Dispose()
        {
            closeConnection();
            conn?.Dispose();
        }
    }
}
