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
using System.Net.Http;
using System.Threading.Tasks;

namespace QuanLySinhVien
{
    public partial class f_Register : Form
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

        // ===================================================================
        // TÍNH NĂNG AI NÂNG CAO: COMPUTER VISION OCR TRÍCH XUẤT MSSV TỪ ẢNH
        // ===================================================================
        private async void btnChoosePic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                ptbPicture.Image = Image.FromFile(filePath);

                // Tiến hành gọi hàm AI quét chữ từ ảnh thẻ không làm đơ giao diện
                await ExtractMSSVFromCardAsync(filePath);
            }
        }

        private async Task ExtractMSSVFromCardAsync(string filePath)
        {
            try
            {
                // Hiển thị trạng thái chờ xử lý AI
                this.Cursor = Cursors.WaitCursor;

                using (var client = new HttpClient())
                {
                    var form = new MultipartFormDataContent();
                    var imageBytes = File.ReadAllBytes(filePath);

                    form.Add(new ByteArrayContent(imageBytes, 0, imageBytes.Length), "file", Path.GetFileName(filePath));
                    form.Add(new StringContent("helloworld"), "apikey"); // API Key miễn phí thử nghiệm toàn cầu
                    form.Add(new StringContent("eng"), "language");       // Quét ký tự số theo bảng tiếng Anh công nghệ cao
                    form.Add(new StringContent("true"), "isOverlayRequired");

                    // Gửi ảnh lên Máy chủ AI xử lý thị giác máy tính
                    var response = await client.PostAsync("https://api.ocr.space/parse/image", form);
                    var jsonResult = await response.Content.ReadAsStringAsync();

                    // Phân tích văn bản từ JSON một cách an toàn
                    string keyword = "\"ParsedText\":\"";
                    int index = jsonResult.IndexOf(keyword);

                    if (index != -1)
                    {
                        int start = index + keyword.Length;
                        int end = jsonResult.IndexOf("\"", start);
                        string parsedText = jsonResult.Substring(start, end - start);

                        parsedText = parsedText.Replace("\\r\\n", "\n").Replace("\\n", "\n");

                        // Quét Regex tìm mẫu định dạng Mã số sinh viên gồm đúng 8 chữ số liên tiếp
                        var mssvMatch = Regex.Match(parsedText, @"\b\d{8}\b");

                        if (mssvMatch.Success)
                        {
                            string detectedMSSV = mssvMatch.Value;

                            // Tự động điền dữ liệu thông minh vào Form
                            txtUsername.Text = detectedMSSV;
                            txtEmail.Text = detectedMSSV + "@student.hcmute.edu.vn";

                            this.Cursor = Cursors.Default;
                            MessageBox.Show($"[AI Computer Vision] Đã quét thành công ảnh thẻ!\n" +
                                            $"-> Phát hiện mã định danh MSSV: {detectedMSSV}\n" +
                                            $"-> Hệ thống đã tự động điền Username và Email trường cho bạn.",
                                            "Trích xuất dữ liệu AI thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi Fail-safe: Nếu mất mạng, hệ thống bỏ qua không làm sập (crash) ứng dụng
                Console.WriteLine("Lỗi phân tích AI OCR: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // ===================================================================

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validation các trường bắt buộc không để trống
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

            // Kiểm tra username tồn tại
            if (CheckUsernameExists(txtUsername.Text))
            {
                MessageBox.Show("Username đã tồn tại! Vui lòng chọn tên khác.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            // Kiểm tra email tồn tại trong Database
            if (CheckEmailExists(txtEmail.Text))
            {
                MessageBox.Show("Email đã được sử dụng! Vui lòng dùng email khác.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            // CHỨC NĂNG AI: KIỂM TRA EMAIL TẠM THỜI (DISPOSABLE EMAIL)
            Cursor.Current = Cursors.WaitCursor;
            if (IsDisposableEmail(txtEmail.Text.Trim()))
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hệ thống bảo mật phát hiện đây là Email tạm thời (Disposable Email)!\n" +
                                "Vui lòng sử dụng các dịch vụ Email chính thức (như Gmail, Outlook, hoặc email trường) để đăng ký.",
                                "Cảnh báo bảo mật AI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            // =====================================================================
            // CẬP NHẬT MỚI: XỬ LÝ LỰA CHỌN PHƯƠNG THỨC XÁC THỰC (EMAIL HOẶC APP 2FA)
            // =====================================================================

            // Đọc trạng thái của RadioButton rb2FAApp (Kiểm tra xem người dùng có chọn 2FA không)
            bool use2FA = rb2FAApp.Checked;

            if (!use2FA)
            {
                // Nếu KHÔNG dùng 2FA (tức là dùng Email OTP) -> Mới tạo mã và gửi Mail
                otpCode = GenerateOTP();
                SendOTP(txtEmail.Text, otpCode);
            }
            else
            {
                // Nếu dùng 2FA -> Không gửi mail, để trống mã otpCode vì App tự sinh mã
                otpCode = "";
            }

            Cursor.Current = Cursors.Default;

            // Mở form OTP và truyền 3 tham số (mã OTP, Email, cờ chọn 2FA)
            f_OTP otpForm = new f_OTP(otpCode, txtEmail.Text.Trim(), use2FA);

            if (otpForm.ShowDialog() == DialogResult.OK)
            {
                RegisterUser();
            }
            else
            {
                MessageBox.Show("Xác thực OTP thất bại hoặc đã bị hủy! Hủy quá trình đăng ký thành viên.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsDisposableEmail(string email)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string url = $"https://disposable.debounce.io/?email={Uri.EscapeDataString(email)}";
                    string response = client.DownloadString(url);
                    return response.Contains("\"disposable\":\"true\"");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool ValidatePasswordStrength(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, pattern);
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string pass = txtPassword.Text;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";

            if (!Regex.IsMatch(pass, pattern))
            {
                erp1.SetError(txtPassword, "Mật khẩu yếu! Cần ≥ 8 ký tự, gồm chữ hoa, chữ thường, số và ký tự đặc biệt.");
            }
            else
            {
                erp1.SetError(txtPassword, "");
            }

            if (!string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                txtConfirmPassword_TextChanged(sender, e);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern) && txtEmail.Text.Length > 0)
            {
                erp1.SetError(txtEmail, "Định dạng Email không hợp lệ! (Ví dụ: abc@gmail.com)");
            }
            else
            {
                erp1.SetError(txtEmail, "");
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form login = Application.OpenForms["f_Login"];
            if (login != null)
            {
                login.Show();
            }
            else
            {
                new f_Login().Show();
            }
            this.Close();
        }

        private void txtConfirmPassword_TextChanged_1(object sender, EventArgs e)
        {
            // Để trống nhằm giữ tương thích nếu Designer tự liên kết sự kiện cũ
        }
    }
}