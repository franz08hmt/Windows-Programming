using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class f_TwoFactorVerify : Form
    {
        private TextBox txtCode;
        public string EnteredCode => txtCode.Text.Trim();

        public f_TwoFactorVerify()
        {
            Text = "Xác thực 2 yếu tố";
            Size = new Size(370, 270);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            BackColor = Color.White;

            var hdr = new Panel { Dock = DockStyle.Top, Height = 58, BackColor = Color.FromArgb(21, 67, 137) };
            hdr.Controls.Add(new Label
            {
                Text = "🔒  Xác Thực 2 Yếu Tố",
                ForeColor = Color.White, Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(14, 14), AutoSize = true
            });
            Controls.Add(hdr);

            Controls.Add(new Label
            {
                Text = "Tài khoản này đã bật xác thực 2 yếu tố.",
                Location = new Point(20, 76), Size = new Size(320, 22),
                Font = new Font("Segoe UI", 9.5F), ForeColor = Color.FromArgb(55, 65, 81)
            });
            Controls.Add(new Label
            {
                Text = "Nhập mã 6 chữ số từ Google Authenticator:",
                Location = new Point(20, 102), Size = new Size(320, 22),
                Font = new Font("Segoe UI", 9.5F), ForeColor = Color.FromArgb(55, 65, 81)
            });

            txtCode = new TextBox
            {
                Location = new Point(80, 132), Size = new Size(200, 36),
                Font = new Font("Segoe UI", 19, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Center, MaxLength = 6,
                BorderStyle = BorderStyle.FixedSingle
            };
            txtCode.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) Confirm(); };
            Controls.Add(txtCode);

            var btnOK = new Button
            {
                Text = "✔  Xác nhận", Location = new Point(20, 186), Size = new Size(155, 38),
                BackColor = Color.FromArgb(21, 67, 137), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.Click += (s, e) => Confirm();
            Controls.Add(btnOK);

            var btnCancel = new Button
            {
                Text = "Hủy", Location = new Point(235, 186), Size = new Size(110, 38),
                BackColor = Color.FromArgb(107, 114, 128), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            Controls.Add(btnCancel);
        }

        private void Confirm()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
