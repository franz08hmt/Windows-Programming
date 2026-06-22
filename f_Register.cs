using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLySinhVien
{
    public partial class f_Register : BaseForm
    {
        private string otpCode = "";

        public f_Register()
        {
            InitializeComponent();
        }

        private GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        private bool CheckUsernameExists(string username)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Login WHERE Username = @user",
                    db.conn);
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = username;
                return (int)cmd.ExecuteScalar() > 0;
            }
            finally { db.closeConnection(); }
        }

        private bool CheckEmailExists(string email)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Login WHERE Email = @email",
                    db.conn);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                return (int)cmd.ExecuteScalar() > 0;
            }
            finally { db.closeConnection(); }
        }

        private string GenerateOTP()
        {
            return new Random().Next(100000, 999999).ToString();
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
                mail.Subject = "Mã OTP đăng ký tài khoản — HCMUTE";
                mail.IsBodyHtml = true;
                mail.Body = EmailHelper.BuildOtpHtml(otp, toEmail, "đăng ký tài khoản");
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoosePic_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ptbPicture.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFname.Text) ||
                string.IsNullOrEmpty(txtLname.Text) ||
                string.IsNullOrEmpty(txtUsername.Text) ||
                string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(erp1.GetError(txtPassword)))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin. Mật khẩu phải đạt độ MẠNH và trùng khớp trước khi đăng ký!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!string.IsNullOrEmpty(erp1.GetError(txtFname)) ||
                !string.IsNullOrEmpty(erp1.GetError(txtLname)) ||
                !string.IsNullOrEmpty(erp1.GetError(txtUsername)) ||
                !string.IsNullOrEmpty(erp1.GetError(txtConfirmPassword)) ||
                !string.IsNullOrEmpty(erp1.GetError(txtEmail)))
            {
                MessageBox.Show("Vui lòng sửa các thông tin bị lỗi trước khi đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Username đã tồn tại! Vui lòng chọn tên khác.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (CheckEmailExists(txtEmail.Text))
            {
                MessageBox.Show("Email đã được sử dụng! Vui lòng dùng email khác.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }


            otpCode = GenerateOTP();
            SendOTP(txtEmail.Text, otpCode);


            f_OTP otpForm = new f_OTP(otpCode, txtEmail.Text.Trim());

            if (otpForm.ShowDialog() == DialogResult.OK)
            {
                RegisterUser();
            }
            else
            {
                MessageBox.Show("Xác thực OTP thất bại! Hủy quá trình đăng ký thành viên.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


                byte[] picBytes = null;
                if (ptbPicture.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ptbPicture.Image.Save(ms, ptbPicture.Image.RawFormat);
                    picBytes = ms.ToArray();
                }

                string query = "INSERT INTO Login " +
                    "(MSGV, Fname, Lname, Username, Pass, Email, Pic, position, VALID) " +
                    "VALUES (@msgv,@fname,@lname,@user,@pass,@email,@pic,@pos,0)";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.Add("@msgv", SqlDbType.NVarChar).Value = msgv;
                cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = txtFname.Text;
                cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = txtLname.Text;
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = HashHelper.HashSHA256(txtPassword.Text);
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@pic", SqlDbType.Image).Value = (object)picBytes ?? DBNull.Value;
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f_Register_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
            {
                pnl.Region = new Region(Path);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
            {
                pnl.Region = new Region(Path);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
            {
                pnl.Region = new Region(Path);
            }
        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {
            if (txtFname.Text.Any(char.IsDigit))
            {
                erp1.SetError(txtFname, "Họ không được chứa chữ số!");
            }
            else
            {
                erp1.SetError(txtFname, "");
            }
        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {
            if (txtLname.Text.Any(char.IsDigit))
            {
                erp1.SetError(txtLname, "Tên không được chứa chữ số!");
            }
            else
            {
                erp1.SetError(txtLname, "");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Contains(" "))
            {
                erp1.SetError(txtUsername, "Username không được chứa khoảng trắng!");
            }
            else if (txtUsername.Text.Length < 4 && txtUsername.Text.Length > 0)
            {
                erp1.SetError(txtUsername, "Username phải có ít nhất 4 ký tự!");
            }
            else
            {
                erp1.SetError(txtUsername, "");
            }
        }

        private void txtPassword_TextChanged_1(object sender, EventArgs e)
        {
            string pass = txtPassword.Text;


            if (pass.Length < 8)
            {
                erp1.SetError(txtPassword, "Mật khẩu quá ngắn! Phải từ 8 ký tự trở lên.");
                return;
            }


            bool hasUpper = pass.Any(char.IsUpper);
            bool hasLower = pass.Any(char.IsLower);
            bool hasDigit = pass.Any(char.IsDigit);
            bool hasSpecial = pass.Any(ch => !char.IsLetterOrDigit(ch));


            if (!hasUpper || !hasLower || !hasDigit || !hasSpecial)
            {
                erp1.SetError(txtPassword, "Mật khẩu yếu! Phải bao gồm cả chữ hoa, chữ thường, số và ký tự đặc biệt (VD: @, #, $).");
            }
            else
            {
                erp1.SetError(txtPassword, "");
            }


            if (!string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                txtConfirmPassword_TextChanged_1(sender, e);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern) && txtEmail.Text.Length > 0)
            {
                erp1.SetError(txtEmail, "Định dạng Email không hợp lệ! (Ví dụ: abc@gmail.com hoặc sv@student.hcmute.edu.vn)");
            }
            else
            {
                erp1.SetError(txtEmail, "");
            }
        }

        private void txtConfirmPassword_TextChanged_1(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                erp1.SetError(txtConfirmPassword, "Mật khẩu xác nhận không trùng khớp!");
            }
            else
            {
                erp1.SetError(txtConfirmPassword, "");
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}