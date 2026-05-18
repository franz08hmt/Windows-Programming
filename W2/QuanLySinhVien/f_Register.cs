using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_Register : Form
    {
        private string otpCode = "";

        public f_Register()
        {
            InitializeComponent();
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
                mail.Subject = "Mã OTP đăng ký tài khoản";
                mail.Body = $"Mã OTP của bạn là: {otp}\nMã có hiệu lực trong 5 phút.";
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChoosePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ptbPicture.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validation
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

            if (!rdStudent.Checked && !rdHR.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra username tồn tại
            if (CheckUsernameExists(txtUsername.Text))
            {
                MessageBox.Show("Username đã tồn tại! Vui lòng chọn tên khác.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            // Kiểm tra email tồn tại
            if (CheckEmailExists(txtEmail.Text))
            {
                MessageBox.Show("Email đã được sử dụng! Vui lòng dùng email khác.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            // Gửi OTP
            otpCode = GenerateOTP();
            SendOTP(txtEmail.Text, otpCode);

            // Mở form OTP
            f_OTP otpForm = new f_OTP(otpCode);
            if (otpForm.ShowDialog() == DialogResult.OK)
            {
                RegisterUser();
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

                // Chuyển ảnh sang byte[]
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
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPassword.Text;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}