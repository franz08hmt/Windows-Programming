using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public class f_TwoFactorSetup : Form
    {
        private Panel pnlHeader;
        private Label lblStatus, lblInstruction, lblSecretTitle, lblCodeHint, lblQrStatus;
        private PictureBox picQR;
        private TextBox txtSecret, txtCode;
        private Button btnEnable, btnDisable, btnClose;

        private string _pendingSecret;
        private string _currentSecret;
        private readonly My_DB db = new My_DB();

        public f_TwoFactorSetup()
        {
            BuildUI();
            EnsureColumnExists();
            LoadCurrentStatus();
        }

        private void BuildUI()
        {
            Text = "Bảo mật 2 yếu tố (2FA)";
            Size = new Size(520, 660);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            BackColor = Color.White;

            pnlHeader = new Panel { Dock = DockStyle.Top, Height = 66, BackColor = Color.FromArgb(21, 67, 137) };
            pnlHeader.Controls.Add(new Label
            {
                Text = "🔒  Bảo Mật 2 Yếu Tố (Google Authenticator)",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(16, 18), AutoSize = true
            });
            Controls.Add(pnlHeader);

            lblStatus = new Label { Location = new Point(20, 84), Size = new Size(476, 26), Font = new Font("Segoe UI", 10) };
            Controls.Add(lblStatus);

            lblInstruction = new Label { Location = new Point(20, 114), Size = new Size(476, 38), Font = new Font("Segoe UI", 9), ForeColor = Color.FromArgb(75, 85, 99) };
            Controls.Add(lblInstruction);

            picQR = new PictureBox
            {
                Location = new Point(150, 158),
                Size = new Size(220, 220),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(248, 250, 252),
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(picQR);

            lblQrStatus = new Label
            {
                Location = new Point(20, 384), Size = new Size(476, 22),
                Text = "⏳ Đang tải mã QR...",
                Font = new Font("Segoe UI", 8.5f), ForeColor = Color.FromArgb(107, 114, 128),
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(lblQrStatus);

            lblSecretTitle = new Label { Text = "Nhập thủ công (Secret key):", Location = new Point(20, 412), AutoSize = true, Font = new Font("Segoe UI", 9), ForeColor = Color.FromArgb(107, 114, 128) };
            Controls.Add(lblSecretTitle);

            txtSecret = new TextBox
            {
                Location = new Point(20, 432), Size = new Size(476, 28),
                ReadOnly = true, Font = new Font("Courier New", 11, FontStyle.Bold),
                BackColor = Color.FromArgb(248, 250, 252),
                TextAlign = HorizontalAlignment.Center, BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(txtSecret);

            lblCodeHint = new Label { Text = "Nhập mã 6 chữ số từ ứng dụng để xác nhận:", Location = new Point(20, 474), AutoSize = true, Font = new Font("Segoe UI", 9), ForeColor = Color.FromArgb(75, 85, 99) };
            Controls.Add(lblCodeHint);

            txtCode = new TextBox
            {
                Location = new Point(160, 496), Size = new Size(200, 36),
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                TextAlign = HorizontalAlignment.Center, MaxLength = 6,
                BorderStyle = BorderStyle.FixedSingle
            };
            txtCode.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { if (btnEnable.Visible) BtnEnable_Click(null, null); else BtnDisable_Click(null, null); } };
            Controls.Add(txtCode);

            btnEnable = new Button
            {
                Text = "✅  Kích hoạt 2FA", Location = new Point(20, 554), Size = new Size(200, 42),
                BackColor = Color.FromArgb(21, 128, 61), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnEnable.FlatAppearance.BorderSize = 0;
            btnEnable.Click += BtnEnable_Click;
            Controls.Add(btnEnable);

            btnDisable = new Button
            {
                Text = "🚫  Tắt 2FA", Location = new Point(20, 554), Size = new Size(200, 42),
                BackColor = Color.FromArgb(185, 28, 28), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnDisable.FlatAppearance.BorderSize = 0;
            btnDisable.Click += BtnDisable_Click;
            Controls.Add(btnDisable);

            btnClose = new Button
            {
                Text = "Đóng", Location = new Point(378, 554), Size = new Size(118, 42),
                BackColor = Color.FromArgb(107, 114, 128), ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };
            btnClose.FlatAppearance.BorderSize = 0;
            Controls.Add(btnClose);
        }

        private void EnsureColumnExists()
        {
            try
            {
                db.openConnection();
                new SqlCommand(
                    "IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Login' AND COLUMN_NAME='TwoFactorSecret') " +
                    "ALTER TABLE Login ADD TwoFactorSecret NVARCHAR(64) NULL", db.conn).ExecuteNonQuery();
            }
            catch { }
            finally { db.closeConnection(); }
        }

        private void LoadCurrentStatus()
        {
            try
            {
                db.openConnection();
                var cmd = new SqlCommand("SELECT TwoFactorSecret FROM Login WHERE MSGV = @id", db.conn);
                cmd.Parameters.AddWithValue("@id", Globals.GlobalUserId);
                var r = cmd.ExecuteScalar();
                _currentSecret = (r == null || r == DBNull.Value) ? null : r.ToString();
            }
            catch { }
            finally { db.closeConnection(); }

            if (!string.IsNullOrEmpty(_currentSecret)) ShowActiveState();
            else ShowSetupState();
        }

        private void ShowSetupState()
        {
            lblStatus.Text = "⚪ 2FA chưa được kích hoạt.";
            lblStatus.ForeColor = Color.FromArgb(107, 114, 128);
            lblInstruction.Text = "Quét mã QR bên dưới bằng Google Authenticator (hoặc nhập secret thủ công):";

            _pendingSecret = TotpHelper.GenerateSecret();
            txtSecret.Text = _pendingSecret;
            LoadQrAsync(_pendingSecret);

            picQR.Visible = true; lblQrStatus.Visible = true;
            lblSecretTitle.Visible = true; txtSecret.Visible = true;
            lblCodeHint.Visible = true; txtCode.Visible = true; txtCode.Clear();
            btnEnable.Visible = true; btnDisable.Visible = false;
        }

        private void ShowActiveState()
        {
            lblStatus.Text = "🟢 2FA đang HOẠT ĐỘNG.";
            lblStatus.ForeColor = Color.FromArgb(21, 128, 61);
            lblInstruction.Text = "Nhập mã 6 chữ số từ Google Authenticator để tắt 2FA:";

            picQR.Visible = false; lblQrStatus.Visible = false;
            lblSecretTitle.Visible = false; txtSecret.Visible = false;
            lblCodeHint.Visible = true; txtCode.Visible = true; txtCode.Clear();
            btnEnable.Visible = false; btnDisable.Visible = true;
        }

        private void LoadQrAsync(string secret)
        {
            picQR.Image = null;
            lblQrStatus.Text = "⏳ Đang tải mã QR...";
            lblQrStatus.ForeColor = Color.FromArgb(107, 114, 128);

            string url = TotpHelper.GetQrUrl(secret, Globals.GlobalUserName);
            var wc = new WebClient();
            wc.DownloadDataCompleted += (s, e) =>
            {
                if (IsDisposed) return;

                if (e.Error != null)
                {
                    Action setErr = () =>
                    {
                        if (!IsDisposed)
                        {
                            lblQrStatus.Text = "❌ Không tải được QR — dùng Secret key bên dưới để nhập thủ công.";
                            lblQrStatus.ForeColor = Color.FromArgb(185, 28, 28);
                        }
                    };
                    if (InvokeRequired) Invoke(setErr); else setErr();
                    return;
                }

                try
                {
                    Action setImg = () =>
                    {
                        if (!IsDisposed)
                        {
                            picQR.Image = Image.FromStream(new MemoryStream(e.Result));
                            lblQrStatus.Text = "✅ Quét QR bằng Google Authenticator.";
                            lblQrStatus.ForeColor = Color.FromArgb(21, 128, 61);
                        }
                    };
                    if (InvokeRequired) Invoke(setImg); else setImg();
                }
                catch
                {
                    Action setErr2 = () =>
                    {
                        if (!IsDisposed)
                        {
                            lblQrStatus.Text = "❌ Lỗi hiển thị QR — dùng Secret key bên dưới.";
                            lblQrStatus.ForeColor = Color.FromArgb(185, 28, 28);
                        }
                    };
                    if (InvokeRequired) Invoke(setErr2); else setErr2();
                }
            };
            wc.DownloadDataAsync(new Uri(url));
        }

        private void BtnEnable_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim().Length != 6)
            {
                MessageBox.Show("Vui lòng nhập đủ 6 chữ số từ Google Authenticator!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!TotpHelper.Verify(_pendingSecret, txtCode.Text))
            {
                MessageBox.Show("Mã xác thực sai! Kiểm tra lại ứng dụng hoặc đảm bảo đồng hồ điện thoại đúng giờ.", "Sai mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Clear(); txtCode.Focus(); return;
            }
            try
            {
                db.openConnection();
                var cmd = new SqlCommand("UPDATE Login SET TwoFactorSecret=@s WHERE MSGV=@id", db.conn);
                cmd.Parameters.AddWithValue("@s", _pendingSecret);
                cmd.Parameters.AddWithValue("@id", Globals.GlobalUserId);
                cmd.ExecuteNonQuery();
                _currentSecret = _pendingSecret;
                MessageBox.Show("✅ 2FA đã được kích hoạt!\nTừ lần đăng nhập tiếp theo bạn sẽ cần nhập mã Google Authenticator.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowActiveState();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            finally { db.closeConnection(); }
        }

        private void BtnDisable_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim().Length != 6)
            {
                MessageBox.Show("Nhập mã 6 chữ số để xác nhận tắt 2FA!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!TotpHelper.Verify(_currentSecret, txtCode.Text))
            {
                MessageBox.Show("Mã xác thực sai!", "Sai mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Clear(); txtCode.Focus(); return;
            }
            try
            {
                db.openConnection();
                var cmd = new SqlCommand("UPDATE Login SET TwoFactorSecret=NULL WHERE MSGV=@id", db.conn);
                cmd.Parameters.AddWithValue("@id", Globals.GlobalUserId);
                cmd.ExecuteNonQuery();
                _currentSecret = null;
                MessageBox.Show("2FA đã được tắt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowSetupState();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            finally { db.closeConnection(); }
        }
    }
}
