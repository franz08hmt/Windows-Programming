using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    class Classroom
    {
        
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int SiSo { get; set; }
        public string Gvcn { get; set; }

        
        public string Exception { get; private set; }

        private My_DB db = new My_DB();

        
        public bool AddClassroom()
        {
            SqlCommand command = new SqlCommand("INSERT INTO Classroom (MaLop, TenLop, SiSo, GVCN) VALUES (@id, @name, @size, @teacher)", db.conn);
            command.Parameters.AddWithValue("@id", MaLop);
            command.Parameters.AddWithValue("@name", TenLop);
            command.Parameters.AddWithValue("@size", SiSo);
            command.Parameters.AddWithValue("@teacher", Gvcn);

            return ExecuteCommand(command);
        }

        
        public DataTable GetClassrooms(SqlCommand command = null)
        {
            if (command == null)
            {
                command = new SqlCommand("SELECT MaLop AS [Mã Lớp], TenLop AS [Tên Lớp], SiSo AS [Sĩ Số], GVCN AS [GV Chủ Nhiệm] FROM Classroom", db.conn);
            }

            DataTable table = new DataTable();
            try
            {
                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                Exception = ex.Message;
            }
            finally
            {
                db.closeConnection();
            }
            return table;
        }

        
        public bool UpdateClassroom()
        {
            SqlCommand command = new SqlCommand("UPDATE Classroom SET TenLop = @name, SiSo = @size, GVCN = @teacher WHERE MaLop = @id", db.conn);
            command.Parameters.AddWithValue("@id", MaLop);
            command.Parameters.AddWithValue("@name", TenLop);
            command.Parameters.AddWithValue("@size", SiSo);
            command.Parameters.AddWithValue("@teacher", Gvcn);

            return ExecuteCommand(command);
        }

        
        public bool DeleteClassroom(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Classroom WHERE MaLop = @id", db.conn);
            command.Parameters.AddWithValue("@id", id);

            return ExecuteCommand(command);
        }

        
        private bool ExecuteCommand(SqlCommand command)
        {
            try
            {
                db.openConnection();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Exception = ex.Message;
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}