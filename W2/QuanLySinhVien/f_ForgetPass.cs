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
        private string otpCode = "";

        public f_ForgetPass()
        {
            InitializeComponent();
        }

        private string GetUsernameByEmail(string email)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Username FROM Login WHERE Email = @email",
                    db.conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
            finally { db.closeConnection(); }
        }

        private void SendOTP(string toEmail, string otp)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(
                    "hmtlqd249@gmail.com",
                    "ddnd acyf pyam gngf");      

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hmtlqd249@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "Mã OTP đặt lại mật khẩu";
                mail.Body = $"Mã OTP của bạn là: {otp}\nMã có hiệu lực trong 5 phút.";
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
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

            // Gửi OTP
            otpCode = new Random().Next(100000, 999999).ToString();
            SendOTP(txtEmail.Text, otpCode);

            // Xác nhận OTP
            f_OTP otpForm = new f_OTP(otpCode);
            if (otpForm.ShowDialog() == DialogResult.OK)
            {
                // Mở form đặt mật khẩu mới
                f_NewPass newPassForm = new f_NewPass(username);
                newPassForm.ShowDialog();
                this.Close();
            }
        }
    }
}