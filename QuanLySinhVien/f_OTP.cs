using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OtpNet; // Thư viện xử lý thuật toán TOTP
using QRCoder; // Thư viện sinh mã QR Code

namespace QuanLySinhVien
{
    public partial class f_OTP : Form
    {
        // Khai báo các biến dùng chung cho cả 2 chế độ
        private string _email;
        private string _otpCode;
        private bool _is2FAMode;
        private int _timeLeft = 300; // 300 giây = 5 phút cho Email OTP

        // Các biến dành riêng cho chế độ 2FA
        private string _secretKey;
        private Totp _totp;

        // Cập nhật hàm tạo nhận 3 tham số để đồng bộ với Form Register
        public f_OTP(string otpCode, string email, bool is2FAMode)
        {
            InitializeComponent();
            _otpCode = otpCode;
            _email = email;
            _is2FAMode = is2FAMode;

            // Nếu người dùng chọn xác thực qua App 2FA -> Khởi tạo khóa bí mật
            if (_is2FAMode)
            {
                byte[] secretBytes = KeyGeneration.GenerateRandomKey(20);
                _secretKey = Base32Encoding.ToString(secretBytes);
                _totp = new Totp(secretBytes);
            }
        }

        private void f_OTP_Load_1(object sender, EventArgs e)
        {
            if (_is2FAMode)
            {
                // GIAO DIỆN CHẾ ĐỘ 2FA
                lblMessage.Text = "Dùng ứng dụng Google Authenticator quét mã QR bên dưới để nhận mã:";
                lblTimer.Text = "Mã tự động đổi mỗi 30 giây trên App";
                timerOTP.Stop();

                // Hiển thị mã QR và sinh hình ảnh QR
                picQRCode.Visible = true;
                picQRCode.BringToFront(); // Đưa QR lên trên logo Gmail
                Generate2FAQRCode();
            }
            else
            {
                // GIAO DIỆN CHẾ ĐỘ EMAIL OTP
                lblMessage.Text = "Nhập mã OTP đã gửi về email:";
                picQRCode.Visible = false; // Ẩn QR Code để lộ logo Gmail ra

                // Bắt đầu đếm ngược 5 phút
                _timeLeft = 300;
                timerOTP.Start();
            }
        }

        // Hàm helper sinh mã QR chứa thông tin cấu hình 2FA
        private void Generate2FAQRCode()
        {
            try
            {
                // Định dạng chuẩn để các app Authenticator (Google/Microsoft) nhận diện
                string issuer = "QLSV_System";
                string provisionUrl = $"otpauth://totp/{issuer}:{_email}?secret={_secretKey}&issuer={issuer}";

                // Dùng thư viện QRCoder để vẽ hình QR Code
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(provisionUrl, QRCodeGenerator.ECCLevel.Q))
                using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
                {
                    byte[] qrCodeBytes = qrCode.GetGraphic(20);
                    using (MemoryStream ms = new MemoryStream(qrCodeBytes))
                    {
                        picQRCode.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sinh mã QR Code 2FA: " + ex.Message, "Hệ thống");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string userInput = txtOTP.Text.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Vui lòng nhập mã xác thực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_is2FAMode)
            {
                // XỬ LÝ KIỂM TRA MÃ 2FA
                long timeStepMatched = 0;

                // Đã sửa lỗi VerificationWindow: Xóa tham số thứ 3
                bool isValid = _totp.VerifyTotp(userInput, out timeStepMatched);

                if (isValid)
                {
                    MessageBox.Show("Xác thực bảo mật 2FA thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mã xác thực không đúng hoặc đã hết hạn! Vui lòng kiểm tra lại ứng dụng Authenticator.", "Lỗi bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOTP.Clear();
                    txtOTP.Focus();
                }
            }
            else
            {
                // XỬ LÝ KIỂM TRA MÃ EMAIL OTP
                if (userInput == _otpCode)
                {
                    MessageBox.Show("Xác thực Email thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mã OTP không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOTP.Clear();
                    txtOTP.Focus();
                }
            }
        }

        private void timerOTP_Tick(object sender, EventArgs e)
        {
            // Chỉ chạy đếm ngược nếu đang ở chế độ Email OTP
            if (!_is2FAMode)
            {
                if (_timeLeft > 0)
                {
                    _timeLeft--;
                    int minutes = _timeLeft / 60;
                    int seconds = _timeLeft % 60;
                    lblTimer.Text = $"Còn lại: {minutes:00}:{seconds:00}";
                }
                else
                {
                    timerOTP.Stop();
                    MessageBox.Show("Mã OTP đã hết hạn! Vui lòng đăng ký lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            f_Login loginForm = new f_Login();
            loginForm.Show();
            this.Close();
        }

        private void btnResend_Click(object sender, EventArgs e)
        {
            // Code gửi lại mã OTP (nếu bạn cần xử lý sau này)
        }

        private void txtOTP_TextChanged(object sender, EventArgs e)
        {
            // Hàm sự kiện bỏ trống
        }
    }
}