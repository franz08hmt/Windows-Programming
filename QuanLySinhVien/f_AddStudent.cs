using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using Tesseract;

namespace QuanLySinhVien
{
    public partial class f_AddStudent : Form
    {
        byte[] studentImage = null;

        public f_AddStudent()
        {
            InitializeComponent();
            RegisterRealTimeValidation(); // Kích hoạt tính năng gõ đến đâu báo lỗi đến đó ngay bên cạnh
        }

        // --- Ý 1: TỰ ĐỘNG BÁO LỖI NGAY BÊN CẠNH KHI ĐANG NHẬP (REAL-TIME) ---
        private void RegisterRealTimeValidation()
        {
            txtMSSV.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtMSSV.Text.Trim()))
                    erp2.SetError(txtMSSV, "Mã số sinh viên không được để trống!");
                else if (!int.TryParse(txtMSSV.Text.Trim(), out _))
                    erp2.SetError(txtMSSV, "MSSV bắt buộc phải là số, không chứa chữ hay ký tự đặc biệt!");
                else
                    erp2.SetError(txtMSSV, ""); // Đúng định dạng thì tự động mất dấu đỏ
            };

            // Bắt sự kiện khi người dùng gõ phím ở ô Họ
            txtFname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtFname.Text.Trim()))
                    erp2.SetError(txtFname, "Vui lòng nhập Họ của sinh viên!");
                else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
                    erp2.SetError(txtFname, "Họ không được chứa chữ số!");
                else
                    erp2.SetError(txtFname, "");
            };

            // Bắt sự kiện khi người dùng gõ phím ở ô Tên
            txtLname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtLname.Text.Trim()))
                    erp2.SetError(txtLname, "Vui lòng nhập Tên của sinh viên!");
                else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
                    erp2.SetError(txtLname, "Tên không được chứa chữ số!");
                else
                    erp2.SetError(txtLname, "");
            };

            // Bắt sự kiện gõ phím ở ô Điện thoại
            txtPhone.TextChanged += (s, e) => {
                if (!string.IsNullOrEmpty(txtPhone.Text.Trim()) && !long.TryParse(txtPhone.Text.Trim(), out _))
                    erp2.SetError(txtPhone, "Số điện thoại không hợp lệ! Chỉ được nhập số.");
                else
                    erp2.SetError(txtPhone, "");
            };

            // Bắt sự kiện gõ phím ở ô Email để check real-time đuôi trường học luôn
            txtEmail.TextChanged += (s, e) => {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern) && txtEmail.Text.Length > 0)
                    erp2.SetError(txtEmail, "Định dạng Email không đúng! (Ví dụ: tên@gmail.com hoặc sv@student.hcmute.edu.vn)");
                else
                    erp2.SetError(txtEmail, "");
            };
        }

        private bool ValidateInput()
        {
            // Bước đầu tiên: Xóa sạch các dấu báo lỗi cũ trước khi kiểm tra lại
            erp2.Clear();
            bool isValid = true;

            // 1. Kiểm tra Mã số sinh viên (MSSV)
            if (string.IsNullOrEmpty(txtMSSV.Text.Trim()))
            {
                erp2.SetError(txtMSSV, "Mã số sinh viên không được để trống!");
                isValid = false;
            }
            else if (!int.TryParse(txtMSSV.Text.Trim(), out _))
            {
                erp2.SetError(txtMSSV, "MSSV bắt buộc phải là số, không chứa chữ hay ký tự đặc biệt!");
                isValid = false;
            }

            // 2. Kiểm tra Họ (Last Name)
            if (string.IsNullOrEmpty(txtFname.Text.Trim()))
            {
                erp2.SetError(txtFname, "Vui lòng nhập Họ của sinh viên!");
                isValid = false;
            }
            else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
            {
                erp2.SetError(txtFname, "Họ không được chứa chữ số!");
                isValid = false;
            }

            // 3. Kiểm tra Tên (First Name)
            if (string.IsNullOrEmpty(txtLname.Text.Trim()))
            {
                erp2.SetError(txtLname, "Vui lòng nhập Tên của sinh viên!");
                isValid = false;
            }
            else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
            {
                erp2.SetError(txtLname, "Tên không được chứa chữ số!");
                isValid = false;
            }

            // 4. Kiểm tra Giới tính (ComboBox)
            if (cboGender.SelectedIndex == -1 || string.IsNullOrEmpty(cboGender.Text))
            {
                erp2.SetError(cboGender, "Vui lòng chọn Giới tính!");
                isValid = false;
            }

            // 5. Kiểm tra Số điện thoại
            if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                if (!long.TryParse(txtPhone.Text.Trim(), out _))
                {
                    erp2.SetError(txtPhone, "Số điện thoại không hợp lệ! Chỉ được nhập số.");
                    isValid = false;
                }
            }

            // 6. --- ĐÃ SỬA: Chấp nhận mọi định dạng email cá nhân lẫn email sinh viên dài lòng thòng của trường ---
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                string email = txtEmail.Text.Trim();
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Pattern mở rộng bẻ gãy mọi giới hạn tên miền

                if (!Regex.IsMatch(email, emailPattern))
                {
                    erp2.SetError(txtEmail, "Định dạng Email không đúng! (Chấp nhận cả đuôi @student.hcmute.edu.vn)");
                    isValid = false;
                }
            }
            return isValid;
        }

        private GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        public void LayThongTinSua(string mssv, string ho, string ten, string ngaysinh, string gioitinh, string dienthoai, string email)
        {
            txtMSSV.Text = mssv;
            txtFname.Text = ho;
            txtLname.Text = ten;

            if (DateTime.TryParse(ngaysinh, out DateTime date))
            {
                dtpDob.Value = date;
            }

            cboGender.Text = gioitinh;
            txtPhone.Text = dienthoai;
            txtEmail.Text = email;

            txtMSSV.Enabled = false;
            btnAdd.Text = "Cập nhật";
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                MemoryStream ms = new MemoryStream();
                picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                studentImage = ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Không cho phép tạo sinh viên mới!\nVui lòng sửa lại toàn bộ các thông tin nhập sai (có dấu cảnh báo đỏ) bên cạnh các ô nhập liệu.",
                                "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            int mssv = Convert.ToInt32(txtMSSV.Text.Trim());
            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                if (btnAdd.Text == "Cập nhật")
                {
                    string query = "UPDATE Student SET Fname = @fname, Lname = @lname, Dob = @dob, Gder = @gder, Phone = @phone, Email = @email, Pture = @pic WHERE MSSV = @mssv";
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    cmd.Parameters.AddWithValue("@fname", txtFname.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", txtLname.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                    cmd.Parameters.AddWithValue("@gder", cboGender.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

                    if (studentImage == null) cmd.Parameters.AddWithValue("@pic", System.Data.SqlTypes.SqlBinary.Null);
                    else cmd.Parameters.AddWithValue("@pic", studentImage);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    Student sv = new Student(
                        mssv, txtFname.Text.Trim(), txtLname.Text.Trim(),
                        dtpDob.Value, cboGender.Text, txtPhone.Text.Trim(),
                        "", "", txtEmail.Text.Trim(), studentImage);

                    if (sv.AddStudent())
                    {
                        MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear_Click(sender, e);
                    }
                    else
                    {
                        erp2.SetError(txtMSSV, "Mã số sinh viên này đã tồn tại trên hệ thống!");
                        MessageBox.Show("Không cho phép tạo! Mã số sinh viên đã tồn tại trên hệ thống.", "Lỗi trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMSSV.Focus();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    erp2.SetError(txtMSSV, "Mã số sinh viên này đã tồn tại trên hệ thống!");
                    MessageBox.Show("Không cho phép tạo sinh viên mới!\nMã số sinh viên (MSSV) này đã tồn tại trên hệ thống, vui lòng nhập mã khác.",
                                    "Lỗi trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMSSV.Focus();
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtFname.Clear();
            txtLname.Clear();
            dtpDob.Value = DateTime.Now;
            cboGender.SelectedIndex = -1;
            txtPhone.Clear();
            txtEmail.Clear();
            picStudent.Image = null;
            studentImage = null;

            erp2.Clear();
            txtMSSV.Focus();
        }

        private void btnViewlist_Click(object sender, EventArgs e)
        {
            f_ListStudent listForm = new f_ListStudent();
            listForm.Show();
            this.Close();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;
            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();
            this.Close();
        }

        private void btnScanCard_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string tessdataPath = Path.Combine(Application.StartupPath, "tessdata");

                    using (var engine = new TesseractEngine(tessdataPath, "vie", EngineMode.Default))
                    {
                        using (var img = Pix.LoadFromFile(ofd.FileName))
                        {
                            using (var page = engine.Process(img))
                            {
                                string textResult = page.GetText();

                                if (string.IsNullOrEmpty(textResult.Trim()))
                                {
                                    MessageBox.Show("Không thể đọc được chữ trên thẻ! Vui lòng chọn ảnh rõ nét hơn.", "Thông báo");
                                    return;
                                }

                                string[] lines = textResult.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                                foreach (string line in lines)
                                {
                                    string cleanLine = line.Trim();
                                    string lowerLine = cleanLine.ToLower();

                                    // 1. Nhận dạng MSSV chuẩn từ nhãn thẻ trường học
                                    if (lowerLine.Contains("mã số") || lowerLine.Contains("id"))
                                    {
                                        Match mssvMatch = Regex.Match(cleanLine, @"\d{8,10}");
                                        if (mssvMatch.Success)
                                        {
                                            txtMSSV.Text = mssvMatch.Value;
                                        }
                                    }

                                    // 2. Nhận dạng Họ tên
                                    if (lowerLine.Contains("họ tên") || lowerLine.Contains("fullname"))
                                    {
                                        int colonIndex = cleanLine.IndexOf(":");
                                        if (colonIndex != -1)
                                        {
                                            string fullName = cleanLine.Substring(colonIndex + 1).Trim();
                                            fullName = Regex.Replace(fullName, @"[a-zA-Z]+", m => m.Value.Length > 1 && char.IsLower(m.Value[1]) ? "" : m.Value).Trim();

                                            string[] nameParts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                            if (nameParts.Length > 0)
                                            {
                                                txtLname.Text = nameParts[nameParts.Length - 1];
                                                txtFname.Text = string.Join(" ", nameParts, 0, nameParts.Length - 1);
                                            }
                                        }
                                    }

                                    // 3. Nhận dạng Ngày sinh
                                    if (lowerLine.Contains("ngày sinh") || lowerLine.Contains("dob"))
                                    {
                                        Match dobMatch = Regex.Match(cleanLine, @"\d{2}/\d{2}/\d{4}|\d{2}-\d{2}-\d{4}");
                                        if (dobMatch.Success)
                                        {
                                            if (DateTime.TryParse(dobMatch.Value.Replace("-", "/"), out DateTime parsedDate))
                                            {
                                                dtpDob.Value = parsedDate;
                                            }
                                        }
                                    }

                                    // 4. Nhận dạng Giới tính
                                    if (lowerLine.Contains("nam"))
                                    {
                                        cboGender.Text = "Nam";
                                    }
                                    else if (lowerLine.Contains("nữ") || lowerLine.Contains("nu"))
                                    {
                                        cboGender.Text = "Nữ";
                                    }
                                }
                                MessageBox.Show("Đã quét thẻ và trích xuất thông tin tự động thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi trong quá trình quét OCR: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}