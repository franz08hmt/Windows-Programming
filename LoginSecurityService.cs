using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    internal static class LoginSecurityService
    {
        // Gmail SMTP cho cảnh báo bảo mật — xóa trước khi push GitHub
        private const string SMTP_FROM = "hmtlqd249@gmail.com";
        private const string SMTP_PASS = "ddnd acyf pyam gngf";

        // Gemini API key — xóa trước khi push GitHub
        private const string GEMINI_KEY = "";

        private const int MAX_ATTEMPTS = 3;
        private static readonly TimeSpan LOCK_DURATION = TimeSpan.FromMinutes(15);

        // Thêm các cột bảo mật vào Login và tạo bảng LoginHistory nếu chưa có
        public static void EnsureSecuritySchema()
        {
            using (var db = new My_DB())
            {
                db.openConnection();
                RunSafe(db, @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Login' AND COLUMN_NAME='LoginAttempts')
                    ALTER TABLE Login ADD LoginAttempts INT NOT NULL DEFAULT 0");
                RunSafe(db, @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Login' AND COLUMN_NAME='LockedUntil')
                    ALTER TABLE Login ADD LockedUntil DATETIME NULL");
                RunSafe(db, @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Login' AND COLUMN_NAME='FacePhoto')
                    ALTER TABLE Login ADD FacePhoto VARBINARY(MAX) NULL");
                RunSafe(db, @"IF OBJECT_ID('dbo.LoginHistory','U') IS NULL
                    CREATE TABLE dbo.LoginHistory (
                        ID        INT IDENTITY(1,1) PRIMARY KEY,
                        Username  VARCHAR(50),
                        AttemptAt DATETIME DEFAULT GETDATE(),
                        Success   BIT NOT NULL
                    )");
            }
        }

        private static void RunSafe(My_DB db, string sql)
        {
            try { new SqlCommand(sql, db.conn).ExecuteNonQuery(); }
            catch { }
        }

        // Trả về thời điểm khóa nếu tài khoản đang bị khóa, null nếu không bị khóa
        public static DateTime? GetLockUntil(string username)
        {
            try
            {
                using (var db = new My_DB())
                {
                    db.openConnection();
                    var cmd = new SqlCommand(
                        "SELECT LockedUntil FROM Login WHERE Username=@u COLLATE SQL_Latin1_General_CP1_CS_AS",
                        db.conn);
                    cmd.Parameters.AddWithValue("@u", username);
                    var val = cmd.ExecuteScalar();
                    if (val == null || val == DBNull.Value) return null;
                    var t = (DateTime)val;
                    return t > DateTime.Now ? t : (DateTime?)null;
                }
            }
            catch { return null; }
        }

        // Ghi nhận thất bại, tự động khóa sau MAX_ATTEMPTS lần
        public static void RecordFailedAttempt(string username)
        {
            try
            {
                using (var db = new My_DB())
                {
                    db.openConnection();
                    // Tăng đếm và đặt LockedUntil khi đạt MAX_ATTEMPTS
                    var cmd = new SqlCommand(@"
                        UPDATE Login
                        SET LoginAttempts = LoginAttempts + 1,
                            LockedUntil   = CASE
                                WHEN LoginAttempts + 1 >= @max
                                THEN DATEADD(MINUTE, 15, GETDATE())
                                ELSE LockedUntil
                            END
                        WHERE Username = @u COLLATE SQL_Latin1_General_CP1_CS_AS", db.conn);
                    cmd.Parameters.AddWithValue("@max", MAX_ATTEMPTS);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        // Đặt lại bộ đếm sau đăng nhập thành công
        public static void ResetAttempts(string username)
        {
            try
            {
                using (var db = new My_DB())
                {
                    db.openConnection();
                    var cmd = new SqlCommand(
                        "UPDATE Login SET LoginAttempts=0, LockedUntil=NULL WHERE Username=@u COLLATE SQL_Latin1_General_CP1_CS_AS",
                        db.conn);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        // Admin mở khóa tài khoản theo MSGV
        public static bool UnlockAccount(string msgv)
        {
            try
            {
                using (var db = new My_DB())
                {
                    db.openConnection();
                    var cmd = new SqlCommand(
                        "UPDATE Login SET LoginAttempts=0, LockedUntil=NULL WHERE MSGV=@id",
                        db.conn);
                    cmd.Parameters.AddWithValue("@id", msgv);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch { return false; }
        }

        // Ghi lịch sử đăng nhập bất đồng bộ
        public static void RecordHistory(string username, bool success)
        {
            Task.Run(() =>
            {
                try
                {
                    using (var db = new My_DB())
                    {
                        db.openConnection();
                        var cmd = new SqlCommand(
                            "INSERT INTO LoginHistory (Username, Success) VALUES (@u, @s)",
                            db.conn);
                        cmd.Parameters.AddWithValue("@u", (object)username ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@s", success ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch { }
            });
        }

        // Phân tích hành vi đăng nhập bất thường bằng AI và gửi email cảnh báo
        public static void AnalyzeAndAlertAsync(string triggerUsername)
        {
            Task.Run(async () =>
            {
                try
                {
                    var sb = new StringBuilder();
                    using (var db = new My_DB())
                    {
                        db.openConnection();
                        var cmd = new SqlCommand(
                            "SELECT TOP 20 Username, AttemptAt, Success FROM LoginHistory ORDER BY ID DESC",
                            db.conn);
                        using (var r = cmd.ExecuteReader())
                            while (r.Read())
                                sb.AppendLine($"User={r["Username"]}, Time={r["AttemptAt"]}, Success={r["Success"]}");
                    }
                    if (sb.Length == 0) return;

                    string prompt =
                        "Phân tích lịch sử đăng nhập hệ thống sau và xác định có dấu hiệu tấn công bất thường không " +
                        "(brute-force, nhiều tài khoản cùng lúc, v.v.). Trả lời ngắn gọn bằng tiếng Việt. " +
                        "Nếu phát hiện bất thường, bắt đầu bằng từ 'CẢNH BÁO:'.\n\n" + sb;

                    string aiResult = await CallGeminiAsync(prompt);

                    if (!string.IsNullOrEmpty(aiResult) && aiResult.Contains("CẢNH BÁO"))
                        await SendAlertEmailAsync(triggerUsername, aiResult);
                }
                catch { }
            });
        }

        private static async Task<string> CallGeminiAsync(string prompt)
        {
            if (string.IsNullOrWhiteSpace(GEMINI_KEY)) return null;
            try
            {
                using (var http = new HttpClient { Timeout = TimeSpan.FromSeconds(15) })
                {
                    string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={GEMINI_KEY}";
                    var body = new { contents = new[] { new { parts = new[] { new { text = prompt } } } } };
                    var res = await http.PostAsync(url,
                        new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
                    string json = await res.Content.ReadAsStringAsync();
                    dynamic obj = JsonConvert.DeserializeObject(json);
                    string text = obj?.candidates?[0]?.content?.parts?[0]?.text?.ToString();
                    return string.IsNullOrEmpty(text) ? null : text;
                }
            }
            catch { return null; }
        }

        private static async Task SendAlertEmailAsync(string username, string aiResult)
        {
            await Task.Run(() =>
            {
                try
                {
                    var smtp = new SmtpClient("smtp.gmail.com", 587)
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(SMTP_FROM, SMTP_PASS),
                        Timeout = 10000
                    };
                    var msg = new MailMessage(SMTP_FROM, SMTP_FROM)
                    {
                        Subject = $"[CẢNH BÁO BẢO MẬT] Hành vi đăng nhập bất thường — {username}",
                        IsBodyHtml = false,
                        Body = $"Cảnh báo bảo mật từ hệ thống QuanLySinhVien:\n\n" +
                               $"Tài khoản liên quan: {username}\n" +
                               $"Thời điểm: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n" +
                               $"Phân tích AI:\n{aiResult}"
                    };
                    smtp.Send(msg);
                }
                catch { }
            });
        }
    }
}
