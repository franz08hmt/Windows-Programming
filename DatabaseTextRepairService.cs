using System;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    internal static class DatabaseTextRepairService
    {
        public static void TryRepairMojibakeData()
        {
            try
            {
                RepairStudentTable();
                RepairLoginTable();
                RepairStudentRequestsTable();
                RepairStatisticsData();
            }
            catch
            {
                // Silently ignore to avoid blocking app startup.
            }
        }

        private static void RepairStudentTable()
        {
            My_DB db = new My_DB();
            try
            {
                var updates = new System.Collections.Generic.List<(int MSSV, string Fname, string Lname, string Gder, string Phone, string Email)>();
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT MSSV, Fname, Lname, Gder, Phone, Email FROM Student", db.conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mssv = Convert.ToInt32(reader["MSSV"]);
                        string fname = reader["Fname"].ToString();
                        string lname = reader["Lname"].ToString();
                        string gder = reader["Gder"].ToString();
                        string phone = reader["Phone"].ToString();
                        string email = reader["Email"].ToString();

                        string fixedFname = VietnameseTextHelper.Normalize(fname);
                        string fixedLname = VietnameseTextHelper.Normalize(lname);
                        string fixedGder = NormalizeGender(VietnameseTextHelper.Normalize(gder));
                        string fixedPhone = VietnameseTextHelper.Normalize(phone);
                        string fixedEmail = VietnameseTextHelper.Normalize(email);

                        if (fixedFname != fname || fixedLname != lname || fixedGder != gder || fixedPhone != phone || fixedEmail != email)
                        {
                            updates.Add((mssv, fixedFname, fixedLname, fixedGder, fixedPhone, fixedEmail));
                        }
                    }
                }

                foreach (var item in updates)
                {
                    ApplyStudentUpdate(db, item.MSSV, item.Fname, item.Lname, item.Gder, item.Phone, item.Email);
                }
            }
            finally
            {
                db.closeConnection();
            }
        }

        private static void RepairLoginTable()
        {
            My_DB db = new My_DB();
            try
            {
                var updates = new System.Collections.Generic.List<(string MSGV, string Fname, string Lname)>();
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT MSGV, Fname, Lname FROM Login", db.conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string msgv = reader["MSGV"].ToString();
                        string fname = reader["Fname"].ToString();
                        string lname = reader["Lname"].ToString();
                        string fixedFname = VietnameseTextHelper.Normalize(fname);
                        string fixedLname = VietnameseTextHelper.Normalize(lname);

                        if (fixedFname != fname || fixedLname != lname)
                        {
                            updates.Add((msgv, fixedFname, fixedLname));
                        }
                    }
                }

                foreach (var item in updates)
                {
                    ApplyLoginUpdate(db, item.MSGV, item.Fname, item.Lname);
                }
            }
            finally
            {
                db.closeConnection();
            }
        }

        private static void RepairStudentRequestsTable()
        {
            My_DB db = new My_DB();
            try
            {
                var updates = new System.Collections.Generic.List<(int Id, string TenSv, string NoiDung, string TrangThai)>();
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT ID, TenSV, NoiDung, TrangThai FROM StudentRequests", db.conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        string tenSv = reader["TenSV"].ToString();
                        string noiDung = reader["NoiDung"].ToString();
                        string trangThai = reader["TrangThai"].ToString();

                        string fixedTenSv = VietnameseTextHelper.Normalize(tenSv);
                        string fixedNoiDung = VietnameseTextHelper.Normalize(noiDung);
                        string fixedTrangThai = VietnameseTextHelper.Normalize(trangThai);

                        if (fixedTenSv != tenSv || fixedNoiDung != noiDung || fixedTrangThai != trangThai)
                        {
                            updates.Add((id, fixedTenSv, fixedNoiDung, fixedTrangThai));
                        }
                    }
                }

                foreach (var item in updates)
                {
                    using (SqlCommand update = new SqlCommand(
                        "UPDATE StudentRequests SET TenSV=@ten, NoiDung=@nd, TrangThai=@tt WHERE ID=@id", db.conn))
                    {
                        update.Parameters.AddWithValue("@ten", (object)item.TenSv ?? DBNull.Value);
                        update.Parameters.AddWithValue("@nd", (object)item.NoiDung ?? DBNull.Value);
                        update.Parameters.AddWithValue("@tt", (object)item.TrangThai ?? DBNull.Value);
                        update.Parameters.AddWithValue("@id", item.Id);
                        update.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Table may not exist on older databases.
            }
            finally
            {
                db.closeConnection();
            }
        }

        private static void RepairStatisticsData()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Student SET Gder = N'Nam' " +
                    "WHERE Gder IS NULL OR LTRIM(RTRIM(Gder)) = ''", db.conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Ignore if schema differs.
            }
            finally
            {
                db.closeConnection();
            }
        }

        private static string NormalizeGender(string gder)
        {
            if (string.IsNullOrWhiteSpace(gder))
            {
                return "Nam";
            }

            string value = gder.Trim();
            if (value.Equals("Nam", StringComparison.OrdinalIgnoreCase))
            {
                return "Nam";
            }

            if (value.Equals("Nữ", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Nu", StringComparison.OrdinalIgnoreCase))
            {
                return "Nữ";
            }

            if (value.Equals("Khác", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Khac", StringComparison.OrdinalIgnoreCase))
            {
                return "Khác";
            }

            return value;
        }

        private static void ApplyStudentUpdate(My_DB db, int mssv, string fname, string lname, string gder, string phone, string email)
        {
            using (SqlCommand update = new SqlCommand(
                "UPDATE Student SET Fname=@fn, Lname=@ln, Gder=@gd, Phone=@ph, Email=@em WHERE MSSV=@mssv", db.conn))
            {
                update.Parameters.AddWithValue("@fn", fname);
                update.Parameters.AddWithValue("@ln", lname);
                update.Parameters.AddWithValue("@gd", (object)gder ?? DBNull.Value);
                update.Parameters.AddWithValue("@ph", (object)phone ?? DBNull.Value);
                update.Parameters.AddWithValue("@em", (object)email ?? DBNull.Value);
                update.Parameters.AddWithValue("@mssv", mssv);
                update.ExecuteNonQuery();
            }
        }

        private static void ApplyLoginUpdate(My_DB db, string msgv, string fname, string lname)
        {
            using (SqlCommand update = new SqlCommand(
                "UPDATE Login SET Fname=@fn, Lname=@ln WHERE MSGV=@msgv", db.conn))
            {
                update.Parameters.AddWithValue("@fn", (object)fname ?? DBNull.Value);
                update.Parameters.AddWithValue("@ln", (object)lname ?? DBNull.Value);
                update.Parameters.AddWithValue("@msgv", msgv);
                update.ExecuteNonQuery();
            }
        }
    }
}
