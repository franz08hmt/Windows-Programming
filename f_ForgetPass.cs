using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace QuanLySinhVien
{
    public partial class f_ForgetPass : BaseForm
    {
        private string otpCode = "";

        public f_ForgetPass()
        {
            InitializeComponent();
        }

        private string GetUsernameByEmail(string email)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                // LTRIM/RTRIM handles whitespace stored in DB; CI collation for case-insensitive match
                SqlCommand cmd = new SqlCommand(
                    "SELECT Username FROM Login WHERE LTRIM(RTRIM(Email)) = @email COLLATE SQL_Latin1_General_CP1_CI_AS",
                    db.conn);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email.Trim();
                object result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tra cứu email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally { db.closeConnection(); }
        }

        private void BoGocPanel(Panel pnl, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(pnl.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(pnl.Width - radius, pnl.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, pnl.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            pnl.Region = new Region(path);
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
                mail.Subject = "Mã OTP đặt lại mật khẩu — HCMUTE";
                mail.IsBodyHtml = true;
                mail.Body = EmailHelper.BuildOtpHtml(otp, toEmail, "đặt lại mật khẩu");
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi email: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendOTP_Click_1(object sender, EventArgs e)
        {
            // txtFname is the actual email input (txtEmail is the back button in header — wrong name in Designer)
            string emailInput = txtFname.Text.Trim();
            if (string.IsNullOrEmpty(emailInput) || !emailInput.Contains("@"))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = GetUsernameByEmail(emailInput);
            if (username == null)
            {
                MessageBox.Show("Email không tồn tại trong hệ thống!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            otpCode = new Random().Next(100000, 999999).ToString();
            SendOTP(emailInput, otpCode);

            f_OTP otpForm = new f_OTP(otpCode, emailInput);

            if (otpForm.ShowDialog() == DialogResult.OK)
            {
                f_NewPass newPassForm = new f_NewPass(username);
                newPassForm.ShowDialog();

                this.Close();
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            BoGocPanel(panel1, 25);
        }

        private void btnBackLogin_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}