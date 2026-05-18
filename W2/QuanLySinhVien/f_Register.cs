using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_Register : Form
    {
        private string otpCode = "";
        private byte[] _picBytes = null;

        // Controls cần dùng trong event
        private TextBox txtFname, txtLname, txtUsername;
        private TextBox txtPassword, txtConfirmPassword, txtEmail;
        private RadioButton rdStudent, rdHR;
        private PictureBox ptbPicture;
        private Label lblStrength;

        public f_Register()
        {
            InitializeComponent();
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            UIHelper.ApplyFormStyle(this, "Đăng ký tài khoản", 520, 680);
            this.Controls.Clear();

            // Header
            var header = UIHelper.CreateSmallHeader(this, "ĐĂNG KÝ TÀI KHOẢN");
            this.Controls.Add(header);

            // Card
            var card = UIHelper.CreateCard(20, 65, 475, 580);
            this.Controls.Add(card);

            // Title
            card.Controls.Add(UIHelper.CreateTitle("Đăng ký", 20, 15));

            // Họ
            card.Controls.Add(UIHelper.CreateLabel("Họ", 20, 65));
            txtFname = UIHelper.CreateTextBox(20, 82, 200);
            card.Controls.Add(txtFname);

            // Tên
            card.Controls.Add(UIHelper.CreateLabel("Tên", 235, 65));
            txtLname = UIHelper.CreateTextBox(235, 82, 200);
            card.Controls.Add(txtLname);

            // Username
            card.Controls.Add(UIHelper.CreateLabel("Tên đăng nhập", 20, 122));
            txtUsername = UIHelper.CreateTextBox(20, 139, 415);
            card.Controls.Add(txtUsername);

            // Password
            card.Controls.Add(UIHelper.CreateLabel("Mật khẩu", 20, 179));
            txtPassword = UIHelper.CreateTextBox(20, 196, 415, true);
            txtPassword.TextChanged += TxtPassword_TextChanged;
            card.Controls.Add(txtPassword);

            // Password strength label
            lblStrength = new Label();
            lblStrength.AutoSize = true;
            lblStrength.Location = new Point(20, 230);
            lblStrength.Font = new Font("Arial", 8);
            card.Controls.Add(lblStrength);

            // Confirm Password
            card.Controls.Add(UIHelper.CreateLabel("Xác nhận mật khẩu", 20, 248));
            txtConfirmPassword = UIHelper.CreateTextBox(20, 265, 415, true);
            txtConfirmPassword.TextChanged += TxtConfirm_TextChanged;
            card.Controls.Add(txtConfirmPassword);

            // Email
            card.Controls.Add(UIHelper.CreateLabel("Email", 20, 305));
            txtEmail = UIHelper.CreateTextBox(20, 322, 415);
            card.Controls.Add(txtEmail);

            // Radio buttons
            card.Controls.Add(UIHelper.CreateLabel("Loại tài khoản", 20, 362));
            rdStudent = new RadioButton();
            rdStudent.Text = "Student";
            rdStudent.Font = new Font("Arial", 9);
            rdStudent.Location = new Point(20, 380);
            rdStudent.AutoSize = true;
            card.Controls.Add(rdStudent);

            rdHR = new RadioButton();
            rdHR.Text = "Human Resource";
            rdHR.Font = new Font("Arial", 9);
            rdHR.Location = new Point(130, 380);
            rdHR.AutoSize = true;
            card.Controls.Add(rdHR);

            // PictureBox
            ptbPicture = new PictureBox();
            ptbPicture.Size = new Size(80, 80);
            ptbPicture.Location = new Point(370, 355);
            ptbPicture.SizeMode = PictureBoxSizeMode.Zoom;
            ptbPicture.BorderStyle = BorderStyle.FixedSingle;
            ptbPicture.BackColor = UIHelper.LightBlue;
            card.Controls.Add(ptbPicture);

            var btnPic = UIHelper.CreateSecondaryButton("Chọn ảnh", 370, 440, 80, 30);
            btnPic.Click += BtnPic_Click;
            card.Controls.Add(btnPic);

            // Buttons
            var btnRegister = UIHelper.CreatePrimaryButton("Đăng ký", 20, 490, 200);
            btnRegister.Click += BtnRegister_Click;
            card.Controls.Add(btnRegister);

            var btnCancel = UIHelper.CreateSecondaryButton("Hủy", 235, 490, 200);
            btnCancel.Click += (s, e) => this.Close();
            card.Controls.Add(btnCancel);
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string pass = txtPassword.Text;
            if (pass.Length == 0)
            {
                lblStrength.Text = "";
                return;
            }

            bool hasUpper = Regex.IsMatch(pass, @"[A-Z]");
            bool hasDigit = Regex.IsMatch(pass, @"[0-9]");
            bool hasSpecial = Regex.IsMatch(pass, @"[!@#$%^&*(),.?""':{}|<>]");
            bool hasLength = pass.Length >= 8;

            int score = (hasUpper ? 1 : 0) + (hasDigit ? 1 : 0) +
                       (hasSpecial ? 1 : 0) + (hasLength ? 1 : 0);

            if (score <= 1)
            {
                lblStrength.Text = "Yếu";
                lblStrength.ForeColor = Color.Red;
            }
            else if (score == 2 || score == 3)
            {
                lblStrength.Text = "Trung bình";
                lblStrength.ForeColor = Color.Orange;
            }
            else
            {
                lblStrength.Text = "Mạnh ✓";
                lblStrength.ForeColor = Color.Green;
            }
        }

        private void TxtConfirm_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == txtPassword.Text)
                txtConfirmPassword.BackColor = Color.FromArgb(220, 255, 220);
            else
                txtConfirmPassword.BackColor = Color.FromArgb(255, 220, 220);
        }

        private void BtnPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ptbPicture.Image = Image.FromFile(ofd.FileName);
                _picBytes = File.ReadAllBytes(ofd.FileName);
            }
        }

        private bool CheckUsernameExists(string username)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                // Check cả Login VÀ HR
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Login WHERE Username=@user " +
                    "UNION ALL SELECT COUNT(*) FROM HR WHERE Username=@user2",
                    db.conn);
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@user2", SqlDbType.VarChar).Value = username;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                return (int)dt.Rows[0][0] > 0 || (int)dt.Rows[1][0] > 0;
            }
            finally { db.closeConnection(); }
        }

        private bool CheckEmailExists(string email)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                // Check cả Login VÀ HR
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Login WHERE Email=@email " +
                    "UNION ALL SELECT COUNT(*) FROM HR WHERE Email=@email2",
                    db.conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@email2", SqlDbType.VarChar).Value = email;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                return (int)dt.Rows[0][0] > 0 || (int)dt.Rows[1][0] > 0;
            }
            finally { db.closeConnection(); }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // Validation cơ bản
            if (string.IsNullOrEmpty(txtFname.Text) || string.IsNullOrEmpty(txtLname.Text) ||
                string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu mạnh
            if (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,}$"))
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự, 1 chữ hoa, 1 số, 1 ký tự đặc biệt!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xác nhận mật khẩu
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rdStudent.Checked && !rdHR.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CheckUsernameExists(txtUsername.Text))
            {
                MessageBox.Show("Username đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CheckEmailExists(txtEmail.Text))
            {
                MessageBox.Show("Email đã được sử dụng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gửi OTP
            otpCode = new Random().Next(100000, 999999).ToString();
            SendOTP(txtEmail.Text, otpCode);

            f_OTP otpForm = new f_OTP(otpCode);
            otpForm.EmailTo = txtEmail.Text;
            if (otpForm.ShowDialog() == DialogResult.OK)
                RegisterUser();
        }

        private void SendOTP(string toEmail, string otp)
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
                mail.Subject = "Mã OTP đăng ký tài khoản - HCMUTE";
                mail.IsBodyHtml = true;
                mail.Body = $@"
                <div style='font-family:Arial;max-width:400px;margin:auto;'>
                    <div style='background:#003087;padding:20px;text-align:center;'>
                        <h2 style='color:white;'>HỆ THỐNG QUẢN LÝ SINH VIÊN</h2>
                    </div>
                    <div style='padding:20px;background:#f5f5f5;'>
                        <p>Mã OTP của bạn là:</p>
                        <h1 style='color:#003087;letter-spacing:8px;'>{otp}</h1>
                        <p style='color:gray;'>Mã có hiệu lực trong <b>5 phút</b>.</p>
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

        private void RegisterUser()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                int position = rdStudent.Checked ? 1 : 2;
                string msgv = (position == 1 ? "SV" : "HR") +
                              DateTime.Now.ToString("yyyyMMddHHmmss");

                string table = position == 2 ? "HR" : "Login";
                string query = $"INSERT INTO {table} " +
                    "(MSGV,Fname,Lname,Username,Pass,Email,Pic,position,VALID) " +
                    "VALUES (@msgv,@fname,@lname,@user,@pass,@email,@pic,@pos,0)";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.Add("@msgv", SqlDbType.NVarChar).Value = msgv;
                cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = txtFname.Text;
                cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = txtLname.Text;
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPassword.Text;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@pic", SqlDbType.Image).Value = (object)_picBytes ?? DBNull.Value;
                cmd.Parameters.Add("@pos", SqlDbType.Int).Value = position;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đăng ký thành công!\nTài khoản đang chờ Admin phê duyệt.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }
    }
}