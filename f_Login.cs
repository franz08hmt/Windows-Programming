using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_Login : BaseForm
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        private static readonly string PREFS_FILE =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "userprefs.dat");

        private CheckBox  _chkRemember;
        private LinkLabel _lnkFaceLogin;

        public f_Login()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            string userText = (txtUsername.Text == "Tên đăng nhập" || txtUsername.Text == "Họ và tên") ? "" : txtUsername.Text;
            string passText = (txtPassword.Text == "●●●●●●●●●●") ? "" : txtPassword.Text;

            bool valid = true;
            if (string.IsNullOrEmpty(userText))
            {
                errorProvider1.SetError(txtUsername, "Vui lòng nhập tên đăng nhập!");
                valid = false;
            }
            else errorProvider1.SetError(txtUsername, "");

            if (string.IsNullOrEmpty(passText))
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập mật khẩu!");
                valid = false;
            }
            else errorProvider1.SetError(txtPassword, "");

            // Cập nhật kiểm tra phải chọn 1 trong 3 nút quyền
            if (!rdAdmin.Checked && !rdStudent.Checked && !rdHR.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = false;
            }
            return valid;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string username      = txtUsername.Text.Trim();
            string passwordInput = txtPassword.Text;
            int    position      = rdAdmin.Checked ? 0 : rdStudent.Checked ? 1 : 2;

            // 1. Kiểm tra khóa tài khoản
            DateTime? lockUntil = LoginSecurityService.GetLockUntil(username);
            if (lockUntil.HasValue)
            {
                int mins = (int)Math.Ceiling((lockUntil.Value - DateTime.Now).TotalMinutes);
                MessageBox.Show($"Tài khoản đang bị khóa tạm thời!\nVui lòng thử lại sau {mins} phút.",
                    "Tài khoản bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                // 2. Lấy thông tin user kèm Pass — so mật khẩu trong code (không trong SQL)
                string query =
                    "SELECT MSGV, Fname, Lname, position, Email, Pass FROM Login " +
                    "WHERE Username = @user COLLATE SQL_Latin1_General_CP1_CS_AS " +
                    "AND position = @pos AND VALID = 1";

                SqlCommand    cmd    = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pos",  position);
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    reader.Close();
                    LoginSecurityService.RecordHistory(username, false);
                    MessageBox.Show("Sai thông tin đăng nhập hoặc tài khoản chưa được Admin phê duyệt!",
                        "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string msgv       = reader["MSGV"].ToString();
                string fname      = VietnameseTextHelper.Normalize(reader.GetString(reader.GetOrdinal("Fname")));
                string lname      = VietnameseTextHelper.Normalize(reader.GetString(reader.GetOrdinal("Lname")));
                string fullName   = fname.Trim() + " " + lname.Trim();
                string email      = reader["Email"]?.ToString() ?? "";
                string storedPass = reader["Pass"]?.ToString() ?? "";
                reader.Close();

                // 3. Xác minh mật khẩu — SHA-256 hoặc plaintext cũ (tự nâng cấp)
                bool passwordOk  = false;
                bool needUpgrade = false;

                if (HashHelper.IsHash(storedPass))
                    passwordOk = storedPass == HashHelper.HashSHA256(passwordInput);
                else if (storedPass == passwordInput)
                    { passwordOk = true; needUpgrade = true; }

                if (!passwordOk)
                {
                    LoginSecurityService.RecordFailedAttempt(username);
                    LoginSecurityService.RecordHistory(username, false);
                    LoginSecurityService.AnalyzeAndAlertAsync(username);

                    DateTime? newLock = LoginSecurityService.GetLockUntil(username);
                    MessageBox.Show(newLock.HasValue
                        ? "Đăng nhập sai 3 lần! Tài khoản bị khóa trong 15 phút."
                        : "Sai thông tin đăng nhập hoặc tài khoản chưa được Admin phê duyệt!",
                        newLock.HasValue ? "Tài khoản bị khóa" : "Lỗi đăng nhập",
                        MessageBoxButtons.OK,
                        newLock.HasValue ? MessageBoxIcon.Error : MessageBoxIcon.Error);
                    return;
                }

                // 4. Nâng cấp plaintext → SHA-256 ngầm
                if (needUpgrade)
                {
                    try
                    {
                        var upd = new SqlCommand("UPDATE Login SET Pass=@h WHERE MSGV=@id", db.conn);
                        upd.Parameters.AddWithValue("@h",  HashHelper.HashSHA256(passwordInput));
                        upd.Parameters.AddWithValue("@id", msgv);
                        upd.ExecuteNonQuery();
                    }
                    catch { }
                }

                // 5. Reset bộ đếm + ghi lịch sử
                LoginSecurityService.ResetAttempts(username);
                LoginSecurityService.RecordHistory(username, true);

                // 6. Kiểm tra 2FA
                string twoFactorSecret = GetTwoFactorSecret(db, msgv);
                if (!string.IsNullOrEmpty(twoFactorSecret))
                {
                    using (var dlg = new f_TwoFactorVerify())
                    {
                        if (dlg.ShowDialog(this) != DialogResult.OK ||
                            !TotpHelper.Verify(twoFactorSecret, dlg.EnteredCode))
                        {
                            MessageBox.Show("Mã xác thực 2FA không đúng. Đăng nhập bị từ chối!",
                                "Xác thực thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // 7. Remember Me
                SaveRememberMe(_chkRemember?.Checked == true ? username : null);

                // 8. Mở trang chính
                CompleteLogin(msgv, fullName, position, email);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        // ── Đăng nhập bằng khuôn mặt ─────────────────────────────────────
        private void LnkFaceLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string username = (txtUsername.Text == "Tên đăng nhập" || txtUsername.Text == "Họ và tên")
                ? "" : txtUsername.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập trước khi dùng nhận diện khuôn mặt!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!rdAdmin.Checked && !rdStudent.Checked && !rdHR.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int position = rdAdmin.Checked ? 0 : rdStudent.Checked ? 1 : 2;
            DateTime? lock2 = LoginSecurityService.GetLockUntil(username);
            if (lock2.HasValue)
            {
                int mins = (int)Math.Ceiling((lock2.Value - DateTime.Now).TotalMinutes);
                MessageBox.Show($"Tài khoản đang bị khóa!\nVui lòng thử lại sau {mins} phút.",
                    "Tài khoản bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var faceForm = new f_FaceLogin(username, position))
            {
                if (faceForm.ShowDialog(this) != DialogResult.OK) return;
            }

            // Khuôn mặt khớp → hoàn tất đăng nhập
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                var cmd2 = new SqlCommand(
                    "SELECT MSGV, Fname, Lname, position, Email FROM Login " +
                    "WHERE Username=@user COLLATE SQL_Latin1_General_CP1_CS_AS " +
                    "AND position=@pos AND VALID=1", db.conn);
                cmd2.Parameters.AddWithValue("@user", username);
                cmd2.Parameters.AddWithValue("@pos",  position);
                var r2 = cmd2.ExecuteReader();

                if (!r2.Read()) { r2.Close(); return; }
                string msgv2     = r2["MSGV"].ToString();
                string fname2    = VietnameseTextHelper.Normalize(r2.GetString(r2.GetOrdinal("Fname")));
                string lname2    = VietnameseTextHelper.Normalize(r2.GetString(r2.GetOrdinal("Lname")));
                string fullName2 = fname2.Trim() + " " + lname2.Trim();
                string email2    = r2["Email"]?.ToString() ?? "";
                r2.Close();

                LoginSecurityService.ResetAttempts(username);
                LoginSecurityService.RecordHistory(username, true);

                string secret = GetTwoFactorSecret(db, msgv2);
                if (!string.IsNullOrEmpty(secret))
                {
                    using (var dlg = new f_TwoFactorVerify())
                    {
                        if (dlg.ShowDialog(this) != DialogResult.OK ||
                            !TotpHelper.Verify(secret, dlg.EnteredCode))
                        {
                            MessageBox.Show("Mã xác thực 2FA không đúng!",
                                "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                SaveRememberMe(_chkRemember?.Checked == true ? username : null);
                CompleteLogin(msgv2, fullName2, position, email2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void CompleteLogin(string msgv, string fullName, int position, string email)
        {
            Globals.SetSession(msgv, fullName, position, email);
            MessageBox.Show("Đăng nhập thành công!\nXin chào: " + fullName,
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            new f_HomePage(fullName).Show();
            this.Hide();
        }

        private string GetTwoFactorSecret(My_DB database, string msgv)
        {
            try
            {
                var cmd = new SqlCommand("SELECT TwoFactorSecret FROM Login WHERE MSGV=@id", database.conn);
                cmd.Parameters.AddWithValue("@id", msgv);
                var r = cmd.ExecuteScalar();
                return (r == null || r == DBNull.Value) ? null : r.ToString();
            }
            catch { return null; }
        }

        private void SaveRememberMe(string username)
        {
            try
            {
                if (username != null) File.WriteAllText(PREFS_FILE, username);
                else if (File.Exists(PREFS_FILE)) File.Delete(PREFS_FILE);
            }
            catch { }
        }

        private void f_Login_Load(object sender, EventArgs e)
        {
            btnLogin.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 12, 12));

            // Khởi tạo schema bảo mật ngầm
            Task.Run(() => { try { LoginSecurityService.EnsureSecuritySchema(); } catch { } });

            // Remember Me checkbox — thêm vào pnlForm (giữa btnLogin và lnkRegister)
            _chkRemember = new CheckBox
            {
                Text      = "Nhớ tên đăng nhập",
                AutoSize  = true,
                Font      = new Font("Segoe UI", 8.5f),
                ForeColor = Color.DimGray,
                Location  = new Point(89, 423)
            };
            pnlForm.Controls.Add(_chkRemember);

            // Face Login link — thêm bên dưới lnkForgetPass
            _lnkFaceLogin = new LinkLabel
            {
                Text      = "🔍 Đăng nhập bằng khuôn mặt",
                AutoSize  = true,
                Font      = new Font("Segoe UI", 8.5f),
                LinkColor = Color.CadetBlue,
                Location  = new Point(89, 474)
            };
            _lnkFaceLogin.LinkClicked += LnkFaceLogin_LinkClicked;
            pnlForm.Controls.Add(_lnkFaceLogin);
            pnlForm.Size = new Size(pnlForm.Width, 508);

            // Nạp username đã lưu (Remember Me)
            if (File.Exists(PREFS_FILE))
            {
                string saved = File.ReadAllText(PREFS_FILE).Trim();
                if (!string.IsNullOrEmpty(saved))
                {
                    txtUsername.Text      = saved;
                    txtUsername.ForeColor = Color.Black;
                    _chkRemember.Checked  = true;
                }
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new f_Register().ShowDialog();
            this.Show();
        }

        private void lnkForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new f_ForgetPass().ShowDialog();
            this.Show();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Họ và tên" || txtUsername.Text == "Tên đăng nhập")
            { txtUsername.Text = ""; txtUsername.ForeColor = Color.Black; }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            { txtUsername.Text = "Tên đăng nhập"; txtUsername.ForeColor = Color.Gray; }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "●●●●●●●●●●")
            { txtPassword.Text = ""; txtPassword.ForeColor = Color.Black; txtPassword.PasswordChar = '●'; }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            { txtPassword.Text = "●●●●●●●●●●"; txtPassword.ForeColor = Color.Gray; txtPassword.PasswordChar = '\0'; }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
    }
}