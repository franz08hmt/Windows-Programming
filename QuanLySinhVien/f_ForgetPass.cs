using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ForgetPass : Form
    {
        // Máy trạng thái của AI: 
        // 0: Đợi email | 1: Hỏi xác nhận gửi link | 2: Đợi mật khẩu mới | 3: Đợi xác nhận MK | 4: Đợi nhập mã Token
        private int botState = 0;
        private string targetEmail = "";
        private string newPassword = "";

        public f_ForgetPass()
        {
            InitializeComponent();
        }

        private void f_ForgetPass_Load(object sender, EventArgs e)
        {
            AddBotMessage("Xin chào! Tôi là trợ lý ảo AI của hệ thống. Có phải bạn đang gặp rắc rối với mật khẩu của mình không?\n\nĐể tôi giúp bạn khôi phục lại nhé. Vui lòng gõ địa chỉ Email bạn đã dùng để đăng ký tài khoản vào khung chat bên dưới.");
        }

        private void AddBotMessage(string msg)
        {
            rtbChat.SelectionAlignment = HorizontalAlignment.Left;
            rtbChat.SelectionColor = System.Drawing.Color.Blue;
            rtbChat.AppendText("🤖 AI: " + msg + "\n\n");
            rtbChat.ScrollToCaret();
        }

        private void AddUserMessage(string msg)
        {
            rtbChat.SelectionAlignment = HorizontalAlignment.Right;
            rtbChat.SelectionColor = System.Drawing.Color.Black;

            if (botState == 2 || botState == 3)
                rtbChat.AppendText("👤 Bạn: " + new string('*', msg.Length) + "\n\n");
            else
                rtbChat.AppendText("👤 Bạn: " + msg + "\n\n");

            rtbChat.ScrollToCaret();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            AddUserMessage(input);
            txtMessage.Clear();
            ProcessChatbotLogic(input);
        }

        // ===================================================================
        // BỘ NÃO ĐIỀU HƯỚNG SỬ DỤNG TOKEN THAY THẾ OTP
        // ===================================================================
        private void ProcessChatbotLogic(string input)
        {
            // TRẠNG THÁI 0: Nhập và kiểm tra Email
            if (botState == 0)
            {
                if (CheckEmailExistsInDB(input))
                {
                    targetEmail = input;
                    botState = 1;
                    AddBotMessage("Tuyệt vời! Hệ thống đã tìm thấy tài khoản của bạn.\n\nBạn có muốn tôi gửi một [Đường link khôi phục mật khẩu bảo mật] chứa mã Token giới hạn trong 5 phút đến email này không? (Gõ 'Có' hoặc 'Không')");
                }
                else
                {
                    AddBotMessage("Rất tiếc, tôi không tìm thấy email '" + input + "' trong dữ liệu. Vui lòng kiểm tra lại chính tả hoặc nhập email khác.");
                }
            }
            // TRẠNG THÁI 1: Xác nhận gửi Link Token
            else if (botState == 1)
            {
                string answer = input.ToLower();
                if (answer.Contains("có") || answer.Contains("ok") || answer.Contains("yes") || answer.Contains("gửi"))
                {
                    AddBotMessage("Đang tiến hành khởi tạo Token bảo mật và gửi link... Vui lòng chờ vài giây.");
                    Application.DoEvents();

                    // 1. Tạo chuỗi Token ngẫu nhiên độc nhất (GUID) và thời gian hết hạn sau 5 phút
                    string token = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(); // Lấy 8 ký tự cho gọn dữ liệu
                    DateTime expiryTime = DateTime.Now.AddMinutes(5);

                    // 2. Lưu Token và Expiry vào Database
                    if (SaveTokenToDB(targetEmail, token, expiryTime))
                    {
                        // 3. Gửi Email chứa link giả lập
                        SendResetLinkEmail(targetEmail, token);

                        botState = 4; // Chuyển sang trạng thái chờ check Token
                        AddBotMessage("📧 Hệ thống đã gửi một Link đặt lại mật khẩu vào Gmail của bạn!\n\nBạn hãy mở mail, sao chép (Copy) đoạn [Mã Token Bảo Mật] nằm ở cuối đường link và dán vào đây để tôi xác thực thời hạn nhé.");
                    }
                    else
                    {
                        AddBotMessage("Gặp sự cố khi thiết lập mã bảo mật trên Database. Hãy thử lại.");
                        botState = 0;
                    }
                }
                else
                {
                    botState = 0;
                    AddBotMessage("Đã hủy quy trình. Nếu bạn muốn dùng email khác, hãy gõ vào đây.");
                }
            }
            // TRẠNG THÁI 4: Xác thực Token và kiểm tra thời hạn (Expiry)
            else if (botState == 4)
            {
                AddBotMessage("Đang tiến hành kiểm tra tính hợp lệ và thời hạn của Token...");
                Application.DoEvents();

                if (ValidateToken(targetEmail, input))
                {
                    botState = 2; // Token hợp lệ và còn hạn -> Cho phép nhập mật khẩu mới trực tiếp
                    AddBotMessage("🎉 Xác thực Token thành công! Mã trùng khớp và nằm trong thời gian hiệu lực (dưới 5 phút).\n\nBây giờ bạn hãy gõ trực tiếp **Mật khẩu mới** muốn thay đổi vào ô chat này nhé.");
                }
                else
                {
                    AddBotMessage("❌ Xác thực thất bại! Mã Token có thể bị sai, hoặc đã quá 5 phút dẫn đến bị hết hạn hệ thống. Vui lòng gõ lại Token chính xác hoặc gõ 'Gửi' để nhận lại link mới.");
                    botState = 1;
                }
            }
            // TRẠNG THÁI 2: Chờ nhập mật khẩu mới
            else if (botState == 2)
            {
                newPassword = input;
                botState = 3;
                AddBotMessage("Đã ghi nhận mật khẩu mới. Bạn hãy gõ lại mật khẩu đó một lần nữa để tôi xác nhận tính chính xác.");
            }
            // TRẠNG THÁI 3: Xác nhận mật khẩu & cập nhật hoàn tất
            else if (botState == 3)
            {
                if (input == newPassword)
                {
                    AddBotMessage("Đang đồng bộ dữ liệu mật khẩu mới lên hệ thống...");
                    Application.DoEvents();

                    if (UpdatePasswordInDB(targetEmail, newPassword))
                    {
                        AddBotMessage("🎉 Tuyệt vời! Mật khẩu của bạn đã được khôi phục thành công bằng cơ chế Token Link nâng cao.\n\nBây giờ bạn có thể click nút [<- Quay lại] để tiến hành đăng nhập.");
                        botState = 0;
                    }
                    else
                    {
                        AddBotMessage("Rất tiếc, đã xảy ra sự cố khi kết nối Database. Hãy thử nhập lại mật khẩu mới.");
                        botState = 2;
                    }
                }
                else
                {
                    AddBotMessage("❌ Mật khẩu nhập lại không trùng khớp! Vui lòng nhập lại mật khẩu mới từ đầu nhé.");
                    botState = 2;
                }
            }
        }

        // ===================================================================
        // TƯƠNG TÁC DATABASE CHO CƠ CHẾ TOKEN + EXPIRY
        // ===================================================================

        private bool CheckEmailExistsInDB(string email)
        {
            My_DB db = new My_DB();
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Count(*) FROM Login WHERE Email LIKE @email UNION ALL SELECT Count(*) FROM HR WHERE Email LIKE @email",
                    db.conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                db.openConnection();
                int totalCount = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) { totalCount += reader.GetInt32(0); }
                }
                return totalCount > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        // Hàm lưu Token cùng thời gian hết hạn xuống DB
        private bool SaveTokenToDB(string email, string token, DateTime expiry)
        {
            My_DB db = new My_DB();
            try
            {
                string query = "UPDATE Login SET ResetToken = @token, ResetExpiry = @expiry WHERE Email = @email; " +
                               "UPDATE HR SET ResetToken = @token, ResetExpiry = @expiry WHERE Email = @email;";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.Add("@token", SqlDbType.VarChar).Value = token;
                cmd.Parameters.Add("@expiry", SqlDbType.DateTime).Value = expiry;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                db.openConnection();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu token: " + ex.Message); return false; }
            finally { db.closeConnection(); }
        }

        // Hàm kiểm tra Token trùng khớp VÀ kiểm tra điều kiện thời gian hiệu lực (Expiry > Giờ hiện tại)
        private bool ValidateToken(string email, string token)
        {
            My_DB db = new My_DB();
            try
            {
                // Truy vấn tìm xem có dòng nào thỏa mãn: đúng email, đúng token và thời hạn Expiry phải lớn hơn thời gian hiện tại (GETDATE())
                string query = "SELECT Count(*) FROM Login WHERE Email = @email AND ResetToken = @token AND ResetExpiry > GETDATE() " +
                               "UNION ALL " +
                               "SELECT Count(*) FROM HR WHERE Email = @email AND ResetToken = @token AND ResetExpiry > GETDATE()";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@token", SqlDbType.VarChar).Value = token;

                db.openConnection();
                int matchCount = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read()) { matchCount += reader.GetInt32(0); }
                }
                return matchCount > 0; // Nếu tìm thấy > 0 tức là Token đúng và chưa hết hạn!
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        private bool UpdatePasswordInDB(string email, string newPass)
        {
            My_DB db = new My_DB();
            try
            {
                // Sau khi đổi xong, Xóa trống Token và Expiry đi (SET NULL) để tránh mã cũ bị dùng lại lần 2
                string query = "UPDATE Login SET Pass = @pass, ResetToken = NULL, ResetExpiry = NULL WHERE Email = @email; " +
                               "UPDATE HR SET Pass = @pass, ResetToken = NULL, ResetExpiry = NULL WHERE Email = @email;";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = newPass;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                db.openConnection();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        // Hàm sinh Link đặt lại mật khẩu và gửi qua SMTP Gmail
        private void SendResetLinkEmail(string toEmail, string token)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("hmtlqd249@gmail.com", "ddnd acyf pyam gngf");

                // Tạo đường link giả lập theo chuẩn hệ thống chứa token
                string resetLink = $"https://qlsv-system.com/identity/reset-password?token={token}";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hmtlqd249@gmail.com", "Hệ Thống Trợ Lý AI");
                mail.To.Add(toEmail);
                mail.Subject = "Yêu cầu khôi phục mật khẩu - Token Link Hết Hạn Sau 5 Phút";
                mail.Body = $"Xin chào,\n\nHệ thống nhận được yêu cầu thay đổi mật khẩu của bạn.\n\n" +
                            $"Vui lòng truy cập đường dẫn bảo mật sau để khôi phục (Hiệu lực trong 5 phút):\n" +
                            $"{resetLink}\n\n" +
                            $"Mã Token bảo mật của bạn là: {token}\n" +
                            $"Hãy sao chép mã Token này dán lại vào khung chat AI để tiếp tục hành động.";

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend.PerformClick();
            }
        }
    }
}