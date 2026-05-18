using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_OTP : Form
    {
        private string _otpCode;
        private DateTime _otpTime;
        private TextBox txtOTP;
        private Label lblEmail;
        private System.Windows.Forms.Timer _timer;
        private Label lblCountdown;
        private string _emailTo;

        public string EmailTo
        {
            get { return _emailTo; }
            set
            {
                _emailTo = value;
                if (lblEmail != null)
                    lblEmail.Text = "Mã OTP đã gửi về: " + MaskEmail(value ?? "");
            }
        }

        public f_OTP(string otpCode)
        {
            InitializeComponent();
            _otpCode = otpCode;
            _otpTime = DateTime.Now;
            ApplyStyle();
            StartCountdown();
        }

        private void ApplyStyle()
        {
            UIHelper.ApplyFormStyle(this, "Xác nhận OTP", 420, 380);
            this.Controls.Clear();

            var header = UIHelper.CreateSmallHeader(this, "XÁC NHẬN OTP");
            this.Controls.Add(header);

            var card = UIHelper.CreateCard(20, 65, 375, 280);
            this.Controls.Add(card);

            Label lblIcon = new Label();
            lblIcon.Text = "✉";
            lblIcon.Font = new Font("Arial", 32);
            lblIcon.ForeColor = UIHelper.PrimaryBlue;
            lblIcon.AutoSize = true;
            lblIcon.Location = new Point(155, 15);
            card.Controls.Add(lblIcon);

            card.Controls.Add(UIHelper.CreateTitle("Nhập mã OTP", 20, 65));

            lblEmail = new Label();
            lblEmail.Text = "Mã OTP đã gửi về: " + MaskEmail(_emailTo ?? "");
            lblEmail.Font = new Font("Arial", 9);
            lblEmail.ForeColor = Color.Gray;
            lblEmail.AutoSize = false;
            lblEmail.Size = new Size(335, 20);
            lblEmail.Location = new Point(20, 108);
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            card.Controls.Add(lblEmail);

            lblCountdown = new Label();
            lblCountdown.Text = "Còn lại: 05:00";
            lblCountdown.Font = new Font("Arial", 9, FontStyle.Bold);
            lblCountdown.ForeColor = Color.FromArgb(204, 0, 0);
            lblCountdown.AutoSize = true;
            lblCountdown.Location = new Point(20, 128);
            card.Controls.Add(lblCountdown);

            card.Controls.Add(UIHelper.CreateLabel("Mã OTP (6 số)", 20, 155));
            txtOTP = UIHelper.CreateTextBox(20, 172, 335);
            txtOTP.Font = new Font("Arial", 14, FontStyle.Bold);
            txtOTP.TextAlign = HorizontalAlignment.Center;
            txtOTP.MaxLength = 6;
            card.Controls.Add(txtOTP);

            var btnConfirm = UIHelper.CreatePrimaryButton("Xác nhận", 20, 220, 155);
            btnConfirm.Click += BtnConfirm_Click;
            card.Controls.Add(btnConfirm);

            var btnResend = UIHelper.CreateSecondaryButton("Gửi lại", 195, 220, 155);
            btnResend.Click += BtnResend_Click;
            card.Controls.Add(btnResend);
        }

        private void StartCountdown()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += (s, e) =>
            {
                TimeSpan elapsed = DateTime.Now - _otpTime;
                TimeSpan remaining = TimeSpan.FromMinutes(5) - elapsed;
                if (remaining.TotalSeconds <= 0)
                {
                    _timer.Stop();
                    lblCountdown.Text = "OTP đã hết hạn!";
                    lblCountdown.ForeColor = Color.Red;
                }
                else
                {
                    lblCountdown.Text = $"Còn lại: {remaining.Minutes:00}:{remaining.Seconds:00}";
                    lblCountdown.ForeColor = remaining.TotalSeconds < 60
                        ? Color.Red : Color.FromArgb(204, 0, 0);
                }
            };
            _timer.Start();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if ((DateTime.Now - _otpTime).TotalMinutes >= 5)
            {
                MessageBox.Show("Mã OTP đã hết hạn! Vui lòng gửi lại.",
                    "Hết hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtOTP.Text.Trim() == _otpCode)
            {
                _timer.Stop();
                MessageBox.Show("Xác nhận thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng! Vui lòng thử lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOTP.Clear();
                txtOTP.Focus();
            }
        }

        private void BtnResend_Click(object sender, EventArgs e)
        {
            _otpTime = DateTime.Now;
            _timer.Start();
            lblCountdown.Text = "Còn lại: 05:00";
            MessageBox.Show("Mã OTP mới đã được gửi!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string MaskEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return "";
            int atIndex = email.IndexOf('@');
            if (atIndex <= 2) return email;
            string name = email.Substring(0, 2) +
                          new string('*', atIndex - 2);
            return name + email.Substring(atIndex);
        }
    }
}