using System;
using System.Drawing;
using System.Windows.Forms;
using OtpNet;

namespace QuanLySinhVien
{
    public partial class f_2FA : Form
    {
        private string _username;
        private string _secretKey;
        private TextBox txtCode;
        private Label lblInstruct;

        public f_2FA(string username, string secretKey)
        {
            InitializeComponent();
            _username = username;
            _secretKey = secretKey;
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            UIHelper.ApplyFormStyle(this, "Xác thực 2 bước", 420, 320);
            this.Controls.Clear();

            var header = UIHelper.CreateSmallHeader(this, "XÁC THỰC 2 BƯỚC");
            this.Controls.Add(header);

            var card = UIHelper.CreateCard(20, 70, 370, 210);
            this.Controls.Add(card);

            var lblTitle = UIHelper.CreateTitle("Google Authenticator", 15, 10);
            card.Controls.Add(lblTitle);

            lblInstruct = new Label();
            lblInstruct.Text = "Mở app Google Authenticator\nvà nhập mã 6 số hiển thị:";
            lblInstruct.Font = new Font("Arial", 10);
            lblInstruct.ForeColor = Color.FromArgb(80, 80, 80);
            lblInstruct.AutoSize = false;
            lblInstruct.Size = new Size(340, 45);
            lblInstruct.Location = new Point(15, 50);
            card.Controls.Add(lblInstruct);

            txtCode = UIHelper.CreateTextBox(15, 105, 340);
            txtCode.Font = new Font("Arial", 16, FontStyle.Bold);
            txtCode.TextAlign = HorizontalAlignment.Center;
            txtCode.MaxLength = 6;
            txtCode.KeyPress += (s, e) => {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            };
            card.Controls.Add(txtCode);

            var btnVerify = UIHelper.CreatePrimaryButton("Xác nhận", 15, 155, 160);
            btnVerify.Click += BtnVerify_Click;
            card.Controls.Add(btnVerify);

            var btnCancel = UIHelper.CreateSecondaryButton("Huỷ", 190, 155, 160);
            btnCancel.Click += (s, e) => {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            card.Controls.Add(btnCancel);
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length != 6)
            {
                MessageBox.Show("Vui lòng nhập đủ 6 số!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                byte[] secretBytes = Base32Encoding.ToBytes(_secretKey);
                var totp = new Totp(secretBytes);
                long timeStep;
                bool valid = totp.VerifyTotp(txtCode.Text, out timeStep,
                    VerificationWindow.RfcSpecifiedNetworkDelay);

                if (valid)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mã không đúng hoặc đã hết hạn!\nVui lòng thử lại.",
                        "Xác thực thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Clear();
                    txtCode.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xác thực: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}