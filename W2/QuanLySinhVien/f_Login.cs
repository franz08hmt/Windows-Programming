using OtpNet;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLySinhVien
{
    public partial class f_Login : Form
    {
        public f_Login()
        {
            InitializeComponent();
            ApplyHCMUTEStyle();
        }

        private void ApplyHCMUTEStyle()
        {
            // Form
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(500, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập - Quản lý Sinh viên";

            // Xóa hết controls cũ
            this.Controls.Clear();

            // ===== LOGO =====
            PictureBox logo = new PictureBox();
            logo.Size = new Size(80, 80);
            logo.Location = new Point((this.ClientSize.Width - 80) / 2, 20);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                var stream = asm.GetManifestResourceStream("QuanLySinhVien.logo_hcmute.png");
                if (stream != null) logo.Image = Image.FromStream(stream);
            }
            catch { }
            this.Controls.Add(logo);

            // ===== TÊN TRƯỜNG =====
            Label lblSchool1 = new Label();
            lblSchool1.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP.HCM";
            lblSchool1.Font = new Font("Arial", 10, FontStyle.Bold);
            lblSchool1.ForeColor = Color.FromArgb(0, 48, 135);
            lblSchool1.AutoSize = false;
            lblSchool1.Size = new Size(460, 25);
            lblSchool1.Location = new Point(20, 110);
            lblSchool1.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(lblSchool1);

            // ===== CARD =====
            Panel card = new Panel();
            card.Size = new Size(400, 380);
            card.Location = new Point(50, 150);
            card.BackColor = Color.White;
            RoundPanel(card, 10);
            this.Controls.Add(card);

            // ===== TIÊU ĐỀ ĐĂNG NHẬP =====
            Label lblTitle = new Label();
            lblTitle.Text = "ĐĂNG NHẬP";
            lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 48, 135);
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(360, 40);
            lblTitle.Location = new Point(20, 20);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            card.Controls.Add(lblTitle);

            Label lblSub = new Label();
            lblSub.Text = "Hệ thống quản lý sinh viên";
            lblSub.Font = new Font("Arial", 9);
            lblSub.ForeColor = Color.Gray;
            lblSub.AutoSize = false;
            lblSub.Size = new Size(360, 20);
            lblSub.Location = new Point(20, 58);
            card.Controls.Add(lblSub);

            // ===== RADIO BUTTONS =====
            Panel pnlRadio = new Panel();
            pnlRadio.Size = new Size(360, 30);
            pnlRadio.Location = new Point(20, 85);
            pnlRadio.BackColor = Color.White;

            rdStudent = new RadioButton();
            rdStudent.Text = "Student";
            rdStudent.Font = new Font("Arial", 9);
            rdStudent.Location = new Point(0, 5);
            rdStudent.AutoSize = true;

            rdHR = new RadioButton();
            rdHR.Text = "Human Resource";
            rdHR.Font = new Font("Arial", 9);
            rdHR.Location = new Point(100, 5);
            rdHR.AutoSize = true;

            pnlRadio.Controls.Add(rdStudent);
            pnlRadio.Controls.Add(rdHR);
            card.Controls.Add(pnlRadio);

            // ===== USERNAME =====
            Label lblUser = new Label();
            lblUser.Text = "Tên đăng nhập";
            lblUser.Font = new Font("Arial", 8);
            lblUser.ForeColor = Color.FromArgb(0, 48, 135);
            lblUser.Location = new Point(20, 125);
            lblUser.AutoSize = true;
            card.Controls.Add(lblUser);

            txtUsername = new TextBox();
            txtUsername.Font = new Font("Arial", 11);
            txtUsername.Size = new Size(360, 35);
            txtUsername.Location = new Point(20, 143);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.BackColor = Color.FromArgb(235, 240, 250);
            card.Controls.Add(txtUsername);

            // ===== PASSWORD =====
            Label lblPass = new Label();
            lblPass.Text = "Mật khẩu";
            lblPass.Font = new Font("Arial", 8);
            lblPass.ForeColor = Color.FromArgb(0, 48, 135);
            lblPass.Location = new Point(20, 188);
            lblPass.AutoSize = true;
            card.Controls.Add(lblPass);

            txtPassword = new TextBox();
            txtPassword.Font = new Font("Arial", 11);
            txtPassword.Size = new Size(360, 35);
            txtPassword.Location = new Point(20, 206);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BackColor = Color.FromArgb(235, 240, 250);
            txtPassword.PasswordChar = '*';
            card.Controls.Add(txtPassword);

            // ===== BUTTON ĐĂNG NHẬP =====
            Button btnLogin = new Button();
            btnLogin.Text = "Đăng nhập";
            btnLogin.Font = new Font("Arial", 11, FontStyle.Bold);
            btnLogin.Size = new Size(360, 45);
            btnLogin.Location = new Point(20, 260);
            btnLogin.BackColor = Color.FromArgb(0, 48, 135);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Click += new EventHandler(btnLogin_Click);
            RoundButton(btnLogin, 8);
            card.Controls.Add(btnLogin);

            // ===== LINKS =====
            LinkLabel lnkNewUser = new LinkLabel();
            lnkNewUser.Text = "New user?";
            lnkNewUser.Font = new Font("Arial", 9);
            lnkNewUser.Location = new Point(20, 320);
            lnkNewUser.AutoSize = true;
            lnkNewUser.LinkColor = Color.FromArgb(0, 48, 135);
            lnkNewUser.Click += new EventHandler(lnkNewUser_LinkClicked);
            card.Controls.Add(lnkNewUser);

            LinkLabel lnkForget = new LinkLabel();
            lnkForget.Text = "Quên mật khẩu?";
            lnkForget.Font = new Font("Arial", 9);
            lnkForget.Location = new Point(270, 320);
            lnkForget.AutoSize = true;
            lnkForget.LinkColor = Color.FromArgb(0, 48, 135);
            lnkForget.Click += new EventHandler(lnkForgetPass_LinkClicked);
            card.Controls.Add(lnkForget);
        }

        private void RoundPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(panel.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(panel.Width - radius * 2, panel.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, panel.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            panel.Region = new Region(path);
        }

        private void RoundButton(Button btn, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(btn.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(btn.Width - radius * 2, btn.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, btn.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            btn.Region = new Region(path);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) ||
                string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rdStudent.Checked && !rdHR.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pos = rdStudent.Checked ? 1 : 2;
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string query = "SELECT * FROM Login WHERE Username=@user " +
                    "AND Pass=@pass AND VALID=1 AND (position=@pos OR position=0)";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@pos", pos);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Globals.SetSession(
                        reader["MSGV"].ToString(),
                        reader["Fname"].ToString(),
                        (int)reader["position"]
                    );
                    reader.Close();

                    //2FA 
                    string secretKey = GetSecretKey(txtUsername.Text); // lấy từ DB

                    if (string.IsNullOrEmpty(secretKey))
                    {
                        // Chưa bật 2FA → hỏi có muốn bật không
                        var result = MessageBox.Show(
                            "Bạn chưa bật xác thực 2 bước.\nBật ngay để tăng bảo mật?",
                            "Bảo mật tài khoản",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            secretKey = GenerateAndSave2FA(txtUsername.Text);
                            MessageBox.Show(
                                "Secret Key của bạn:\n\n" + secretKey +
                                "\n\nNhập key này vào Google Authenticator\n(chọn 'Enter setup key')",
                                "Thiết lập 2FA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            f_2FA twoFA = new f_2FA(txtUsername.Text, secretKey);
                            if (twoFA.ShowDialog() != DialogResult.OK)
                                return;
                        }
                    }
                    else
                    {
                        // Đã bật 2FA -> yêu cầu nhập code
                        f_2FA twoFA = new f_2FA(txtUsername.Text, secretKey);
                        if (twoFA.ShowDialog() != DialogResult.OK)
                            return; // Huỷ -> không cho vào
                    }

                    MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_Main frm = new f_Main(Globals.GlobalPosition);
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Sai thông tin đăng nhập hoặc không có quyền truy cập!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally { db.closeConnection(); }
        }
        private string GetSecretKey(string username)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                // Kiểm tra Login trước
                SqlCommand cmd = new SqlCommand(
                    "SELECT SecretKey FROM Login WHERE Username=@user", db.conn);
                cmd.Parameters.AddWithValue("@user", username);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return result.ToString();

                // Kiểm tra HR
                cmd = new SqlCommand(
                    "SELECT SecretKey FROM HR WHERE Username=@user", db.conn);
                cmd.Parameters.AddWithValue("@user", username);
                result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return result.ToString();

                return null;
            }
            catch { return null; }
            finally { db.closeConnection(); }
        }

        private string GenerateAndSave2FA(string username)
        {
            // Tạo secret key ngẫu nhiên
            byte[] key = KeyGeneration.GenerateRandomKey(20);
            string secretKey = Base32Encoding.ToString(key);

            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                // Update Login
                SqlCommand cmd1 = new SqlCommand(
                    "UPDATE Login SET SecretKey=@key WHERE Username=@user", db.conn);
                cmd1.Parameters.AddWithValue("@key", secretKey);
                cmd1.Parameters.AddWithValue("@user", username);
                cmd1.ExecuteNonQuery();

                // Update HR
                SqlCommand cmd2 = new SqlCommand(
                    "UPDATE HR SET SecretKey=@key2 WHERE Username=@user2", db.conn);
                cmd2.Parameters.AddWithValue("@key2", secretKey);
                cmd2.Parameters.AddWithValue("@user2", username);
                cmd2.ExecuteNonQuery();

                return secretKey;
            }
            catch { return secretKey; }
            finally { db.closeConnection(); }
        }
        private void lnkNewUser_LinkClicked(object sender, EventArgs e)
        {
            f_Register frm = new f_Register();
            frm.ShowDialog();
        }

        private void lnkForgetPass_LinkClicked(object sender, EventArgs e)
        {
            f_ForgetPass frm = new f_ForgetPass();
            frm.ShowDialog();
        }
    }
}