using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ForgetPass : Form
    {
        private TextBox txtEmail;

        public f_ForgetPass()
        {
            InitializeComponent();
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            UIHelper.ApplyFormStyle(this, "Quên mật khẩu", 420, 320);
            this.Controls.Clear();

            var header = UIHelper.CreateSmallHeader(this, "QUÊN MẬT KHẨU");
            this.Controls.Add(header);

            var card = UIHelper.CreateCard(20, 65, 375, 220);
            this.Controls.Add(card);

            card.Controls.Add(UIHelper.CreateTitle("Đặt lại mật khẩu", 20, 15));

            Label lblSub = new Label();
            lblSub.Text = "Nhập email để nhận link đặt lại mật khẩu";
            lblSub.Font = new Font("Arial", 9);
            lblSub.ForeColor = Color.Gray;
            lblSub.AutoSize = false;
            lblSub.Size = new Size(335, 20);
            lblSub.Location = new Point(20, 60);
            card.Controls.Add(lblSub);

            card.Controls.Add(UIHelper.CreateLabel("Email", 20, 88));
            txtEmail = UIHelper.CreateTextBox(20, 105, 335);
            card.Controls.Add(txtEmail);

            var btnSend = UIHelper.CreatePrimaryButton("Gửi link đặt lại", 20, 155, 335);
            btnSend.Click += BtnSend_Click;
            card.Controls.Add(btnSend);
        }

        private string GetUsernameByEmail(string email)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Username FROM Login WHERE Email=@email " +
                    "UNION SELECT Username FROM HR WHERE Email=@email2",
                    db.conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@email2", SqlDbType.VarChar).Value = email;
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
            finally { db.closeConnection(); }
        }

        private string GenerateToken()
        {
            return Guid.NewGuid().ToString("N");
        }

        private void SaveToken(string username, string token)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                // Xóa token cũ của user này
                SqlCommand del = new SqlCommand(
                    "DELETE FROM ResetToken WHERE Username=@user", db.conn);
                del.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
                del.ExecuteNonQuery();

                // Lưu token mới
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO ResetToken (Username, Token, ExpireTime) " +
                    "VALUES (@user, @token, @expire)", db.conn);
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@token", SqlDbType.VarChar).Value = token;
                cmd.Parameters.Add("@expire", SqlDbType.DateTime).Value =
                    DateTime.Now.AddMinutes(30);
                cmd.ExecuteNonQuery();
            }
            finally { db.closeConnection(); }
        }

        private void SendResetLink(string toEmail, string token, string username)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(
                    "hmtlqd249@gmail.com", "ddnd acyf pyam gngf");

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hmtlqd249@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "Đặt lại mật khẩu - HCMUTE";
                mail.IsBodyHtml = true;
                mail.Body = $@"
                <div style='font-family:Arial;max-width:400px;margin:auto;'>
                    <div style='background:#003087;padding:20px;text-align:center;'>
                        <h2 style='color:white;'>ĐẶT LẠI MẬT KHẨU</h2>
                        <p style='color:#aac4ff;'>Hệ thống Quản lý Sinh viên HCMUTE</p>
                    </div>
                    <div style='padding:20px;background:#f5f5f5;'>
                        <p>Xin chào <b>{username}</b>,</p>
                        <p>Mã token đặt lại mật khẩu của bạn:</p>
                        <div style='background:#003087;color:white;padding:15px;
                             text-align:center;border-radius:8px;
                             font-size:18px;letter-spacing:4px;'>
                            {token.Substring(0, 8).ToUpper()}
                        </div>
                        <p style='color:gray;font-size:12px;'>
                            Token có hiệu lực trong <b>30 phút</b>.<br/>
                            Nhập token này vào ứng dụng để đặt lại mật khẩu.
                        </p>
                    </div>
                </div>";
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = GetUsernameByEmail(txtEmail.Text);
            if (username == null)
            {
                MessageBox.Show("Email không tồn tại trong hệ thống!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo token + lưu DB + gửi email
            string token = GenerateToken();
            SaveToken(username, token);
            SendResetLink(txtEmail.Text, token, username);

            MessageBox.Show("Token đặt lại mật khẩu đã được gửi về email!\nKiểm tra hộp thư của bạn.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Mở form nhập token
            f_NewPass newPass = new f_NewPass(username, token);
            newPass.ShowDialog();
            this.Close();
        }
    }
}