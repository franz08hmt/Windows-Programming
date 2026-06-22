using System;
using System.Net;
using System.Net.Mail; 
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_OTP : BaseForm
    {
        private string _otpCode;
        private string _email;
        private int _timeLeft = 300;

        public f_OTP(string otpCode, string email)
        {
            InitializeComponent();
            _otpCode = otpCode;
            _email = email;
        }

        private void f_OTP_Load_1(object sender, EventArgs e)
        {
            lblMessage.Text = "Nhập mã OTP đã gửi về gmail: " + _email;

            _timeLeft = 300;
            lblTimer.Text = "Còn lại: 05:00";
            btnResend.Enabled = false;

            timerOTP.Start();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_otpCode))
            {
                MessageBox.Show("Mã OTP đã hết hạn! Vui lòng bấm gửi lại mã.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtOTP.Text.Trim() == _otpCode)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng! Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOTP.Clear();
                txtOTP.Focus();
            }
        }

        private void txtOTP_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnBackLogin_Click_1(object sender, EventArgs e)
        {
            f_Login loginForm = new f_Login();
            loginForm.Show();
            this.Close();
        }

        private void timerOTP_Tick(object sender, EventArgs e)
        {
            if (_timeLeft > 0)
            {
                _timeLeft--;
                lblTimer.Text = string.Format("Còn lại: {0:00}:{1:00}", _timeLeft / 60, _timeLeft % 60);
            }
            else
            {
                timerOTP.Stop();
                lblTimer.Text = "Mã OTP đã hết hạn!";
                btnResend.Enabled = true;
                _otpCode = "";
            }
        }

        private void btnResend_Click_1(object sender, EventArgs e)
        {
            try
            {
               
                Random rand = new Random();
                _otpCode = rand.Next(100000, 999999).ToString();

            
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("hmtlqd249@gmail.com", "ddnd acyf pyam gngf");

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("hmtlqd249@gmail.com");
                mail.To.Add(_email); 
                mail.Subject = "Mã OTP mới đặt lại mật khẩu / đăng ký — HCMUTE";
                mail.IsBodyHtml = true;
                mail.Body = EmailHelper.BuildOtpHtml(_otpCode, _email, "đặt lại mật khẩu / đăng ký");

                smtp.Send(mail); 

                MessageBox.Show("Mã OTP mới đã được gửi lại vào Email của bạn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

          
                _timeLeft = 300;
                lblTimer.Text = "Còn lại: 05:00";
                btnResend.Enabled = false; 
                txtOTP.Clear();
                timerOTP.Start(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối gửi lại mã OTP: " + ex.Message, "Hệ thống");
            }
        }

    }
}