using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_HomePage : BaseForm
    {
        private string userFullName;

        public f_HomePage() { InitializeComponent(); }

        public f_HomePage(string loginName)
        {
            InitializeComponent();
            this.userFullName = loginName;
        }


        private void ShowUserControl(UserControl uc)
        {
            if (pnlMainContent != null)
            {
                // Tắt hiển thị toàn bộ các linh kiện thống kê gốc ẩn bên dưới panel
                foreach (Control ctrl in pnlMainContent.Controls)
                {
                    ctrl.Visible = false;
                }

                uc.Dock = DockStyle.Fill;
                pnlMainContent.Controls.Add(uc);
                uc.BringToFront();
            }
        }

        private void HienThiTrangChuGoc()
        {
            if (pnlMainContent != null)
            {
                // 1. Tìm và xóa bỏ toàn bộ các UserControl nhúng (như f_AddStudent) ra khỏi panel
                for (int i = pnlMainContent.Controls.Count - 1; i >= 0; i--)
                {
                    if (pnlMainContent.Controls[i] is UserControl)
                    {
                        pnlMainContent.Controls.RemoveAt(i);
                    }
                }

                // 2. Bật hiển thị lại toàn bộ linh kiện Tổng quan hệ thống và Chatbot gốc của ní
                foreach (Control ctrl in pnlMainContent.Controls)
                {
                    ctrl.Visible = true;
                }

                // 3. Tải lại số liệu thống kê mới nhất từ SQL Server đổ lên màn hình
                ThongKeHeThong();
            }
        }

        private void ThongKeHeThong()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                int totalStudents = (int)new SqlCommand("SELECT COUNT(*) FROM Student", db.conn).ExecuteScalar();
                int totalPending = (int)new SqlCommand("SELECT COUNT(*) FROM Login WHERE VALID = 0", db.conn).ExecuteScalar();
                int totalHR = (int)new SqlCommand("SELECT COUNT(*) FROM Login WHERE position = 2", db.conn).ExecuteScalar();

                lblTotalStudents.Text = totalStudents.ToString();
                lblTotalPending.Text = totalPending.ToString();
                lblTotalHR.Text = totalHR.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật bảng tổng quan: " + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void ApplyPermissions()
        {
            int position = Globals.GlobalPosition;

            if (position == 0) // ADMIN
            {
                bttAdd.Visible = true;
                bttList.Visible = true;
                bttFix.Visible = true;
                btnRegisterMenu.Visible = true;
                btnManageCourse.Visible = true;
                button1.Visible = true;
                btnStatistic.Visible = true;
                btnAccountManage.Visible = true;
                btnManageRequest.Visible = true;
                btnStudentScore.Visible = true;

                pnlCardSV.Visible = true;
                pnlCardPending.Visible = true;
                pnlCardHR.Visible = true;
            }
            else if (position == 2) // HR
            {
                bttAdd.Visible = true;
                bttList.Visible = true;
                bttFix.Visible = true;
                btnRegisterMenu.Visible = true;
                btnManageCourse.Visible = true;
                button1.Visible = true;
                btnStatistic.Visible = true;
                btnAccountManage.Visible = false;
                btnManageRequest.Visible = false;

                pnlCardSV.Visible = true;
                pnlCardPending.Visible = false;
                pnlCardHR.Visible = true;
                btnStudentScore.Visible = true;
            }
            else if (position == 1) // STUDENT
            {
                bttAdd.Visible = false;
                bttList.Visible = false;
                bttFix.Visible = false;
                btnManageCourse.Visible = false;
                btnStatistic.Visible = false;
                btnAccountManage.Visible = false;
                btnManageClassroom.Visible = false;

                btnRegisterMenu.Visible = true;
                button1.Visible = true;
                btnManageRequest.Visible = true;
                btnStudentScore.Visible = true;

                pnlCardSV.Visible = false;
                pnlCardPending.Visible = false;
                pnlCardHR.Visible = false;
            }
        }

        private void BoGocPanel(Panel pnl, int radius)
        {
            if (pnl == null || pnl.ClientRectangle.Width <= radius || pnl.ClientRectangle.Height <= radius)
                return;
            try
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.StartFigure();
                    path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                    path.AddArc(new Rectangle(pnl.Width - radius, 0, radius, radius), 270, 90);
                    path.AddArc(new Rectangle(pnl.Width - radius, pnl.Height - radius, radius, radius), 0, 90);
                    path.AddArc(new Rectangle(0, pnl.Height - radius, radius, radius), 90, 90);
                    path.CloseFigure();
                    pnl.Region = new Region(path);
                }
            }
            catch { }
        }
        private void LoadUserAccountInfoCard()
        {
            int position = Globals.GlobalPosition;
            string username = Globals.GlobalUserName; // Lấy MSSV hoặc username từ Session

            try
            {
                // 1. Trường hợp là Sinh viên (Position = 1) -> Moi ảnh đại diện từ bảng Student
                if (position == 1 && !string.IsNullOrEmpty(username))
                {
                    My_DB tempDb = new My_DB();
                    tempDb.openConnection();
                    string query = "SELECT Fname, Lname, Pture FROM Student WHERE MSSV = @mssv";
                    SqlCommand cmd = new SqlCommand(query, tempDb.conn);
                    cmd.Parameters.AddWithValue("@mssv", username);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblUserFullName.Text = reader["Lname"].ToString().Trim() + " " + reader["Fname"].ToString().Trim();
                        lblUserRoleMSSV.Text = "SV/HV/NCS - " + username + Environment.NewLine + "(Còn học)";

                        // Kiểm tra ảnh đại diện sinh viên
                        if (reader["Pture"] != DBNull.Value && reader["Pture"] != null)
                        {
                            byte[] picData = (byte[])reader["Pture"];
                            using (MemoryStream ms = new MemoryStream(picData))
                            {
                                picUserAvatar.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            // Nếu SV chưa có ảnh, nạp logo trường làm dự phòng
                            picUserAvatar.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
                        }
                    }
                    reader.Close();
                    tempDb.closeConnection();
                }
                // 2. 🛠️ VỊ TRÍ SỬA ĐỔI CHÍ MẠNG: Dành cho Admin (0) và HR (2) -> Lôi ảnh từ bảng Login lên
                else
                {
                    lblUserFullName.Text = position == 0 ? "Ban Quản Trị Hệ Thống" : "Phòng Nhân Sự (HR)";
                    lblUserRoleMSSV.Text = "Cán bộ quản lý - " + username;

                    // Khởi tạo luồng kết nối SQL phụ bốc ảnh Admin/HR thời gian thực
                    My_DB tempDb = new My_DB();
                    tempDb.openConnection();
                    string query = "SELECT Pic FROM Login WHERE LOWER(Username) = LOWER(@un) OR LOWER(Username) = LOWER(@fn)";
                    SqlCommand cmd = new SqlCommand(query, tempDb.conn);
                    cmd.Parameters.AddWithValue("@un", username);
                    cmd.Parameters.AddWithValue("@fn", userFullName ?? "");

                    object result = cmd.ExecuteScalar();
                    tempDb.closeConnection();

                    // Nếu cột Pic trong bảng Login đã được lưu ảnh nhị phân thành công
                    if (result != DBNull.Value && result != null)
                    {
                        byte[] picData = (byte[])result;
                        using (MemoryStream ms = new MemoryStream(picData))
                        {
                            picUserAvatar.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        // Nếu Admin/HR chưa từng đổi ảnh cá nhân, hiện logo trường mặc định
                        picUserAvatar.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
                    }
                }

                // Luôn luôn cấu hình bo tròn Avatar cho thẩm mỹ và mượt mà
                if (picUserAvatar != null && picUserAvatar.Image != null)
                {
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddEllipse(0, 0, picUserAvatar.Width - 1, picUserAvatar.Height - 1);
                    picUserAvatar.Region = new Region(gp);
                    picUserAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nạp card thông tin nhân sự: " + ex.Message);
            }
        }



        private void HomePage_Load(object sender, EventArgs e)
        {
            rtbChatHistory.AppendText("🤖 Trợ lý: Xin chào! Tôi có thể giúp gì cho bạn? " +
                "(Ví dụ: 'Thêm SV', 'Xem danh sách', 'Có bao nhiêu sinh viên điểm cao?').\n\n");

            string fullName = !string.IsNullOrEmpty(Globals.GlobalUserName)
                ? Globals.GlobalUserName
                : userFullName;
            lblTroLy.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            ThongKeHeThong();
            ApplyPermissions();
            btnChangeImage.Click += new EventHandler(btnChangeImage_Click);

            LoadUserAccountInfoCard();
        }

        private string ProcessBotResponse(string userInput)
        {
            string input = userInput.ToLower().Trim();
            My_DB db = new My_DB();
            int role = Globals.GlobalPosition;

            try
            {
                if (input.Contains("thêm sv") || input.Contains("them sinh vien"))
                {
                    if (role == 1) return "🤖 Trợ lý: Tài khoản Sinh viên không có quyền truy cập tính năng này!";
                    bttAdd_Click(null, null); return "redirect";
                }
                if (input.Contains("danh sách") || input.Contains("xem danh sach") || input.Contains("danh sach sv"))
                {
                    if (role == 1) return "🤖 Trợ lý: Tài khoản Sinh viên không có quyền xem Danh sách sinh viên!";
                    bttList_Click(null, null); return "redirect";
                }
                if (input.Contains("quản lý môn") || input.Contains("them mon hoc"))
                {
                    if (role == 1) return "🤖 Trợ lý: Tài khoản Sinh viên không có quyền Quản lý môn học!";
                    btnManageCourse_Click(null, null); return "redirect";
                }
                if (input.Contains("điểm cao") || input.Contains("diem cao") || input.Contains("sinh vien gioi"))
                {
                    db.openConnection();
                    int count = Convert.ToInt32(new SqlCommand(
                        "SELECT COUNT(DISTINCT MSSV) FROM Score WHERE DiemTK >= 8.0", db.conn).ExecuteScalar());
                    db.closeConnection();
                    return count > 0
                        ? $"🤖 Trợ lý: Hiện có {count} sinh viên đạt điểm Giỏi trở lên (>= 8.0)."
                        : "🤖 Trợ lý: Chưa có sinh viên nào đạt điểm Giỏi (>= 8.0).";
                }
                if (input.Contains("bao nhiêu sinh viên") || input.Contains("tong so sv") || input.Contains("so luong sv"))
                {
                    db.openConnection();
                    int count = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM Student", db.conn).ExecuteScalar());
                    db.closeConnection();
                    return $"🤖 Trợ lý: Tổng số sinh viên trong hệ thống: {count} sinh viên.";
                }
                if (input.Contains("hello") || input.Contains("hi") || input.Contains("xin chào"))
                    return "🤖 Trợ lý: Xin chào! Tôi có thể hỗ trợ gì cho bạn hôm nay?";
            }
            catch (Exception ex)
            {
                return "🤖 Trợ lý: Lỗi khi truy vấn dữ liệu: " + ex.Message;
            }

            return "🤖 Trợ lý: Tôi chưa hiểu yêu cầu này. Thử gõ 'Thêm SV', 'Danh sách', hoặc 'Bao nhiêu sinh viên' nhé!";
        }

        // ── Sidebar events ──────────────────────────────

        // 🛠️ ĐÃ TÍCH HỢP MỚI: Nút bấm Thêm Sinh Viên nhảy tab Dashboard ngay bên cạnh
        private void bttAdd_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_AddStudent()); // Bốc linh kiện thêm sinh viên đặt vào panel chính
        }

        private void bttList_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_ListStudent());
        }
        private void bttFix_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_EditStudent());
        }
        private void btnRegisterMenu_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_RegisterCourse());
        }
        private void btnManageCourse_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_ManageCourse());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_ManageScore());
        }
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_Statistic());
        }
        private void btnAccountManage_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_AccountManage());
        }
        private void btnManageClassroom_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_ManageClassroom());
        }

        private void btnManageRequest_Click(object sender, EventArgs e)
        {
            if (Globals.GlobalPosition == 1)
            {
                ShowUserControl(new f_StudentRequest());
            }
            else
            {
                ShowUserControl(new f_AdminHandleRequest());
                ThongKeHeThong();
            }
        }

        private void bttLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống không ní?",
                "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 1. Dọn sạch phiên đăng nhập, xóa session tài khoản hiện tại
                Globals.ClearSession();

                // 2. 🛠️ ĐÒN CHÍ MẠNG: Hủy đăng ký sự kiện FormClosed trước khi Close để tránh kích hoạt Application.Exit()
                this.FormClosed -= f_HomePage_FormClosed;

                // 3. Khởi tạo form Login mới và bung lụa lên màn hình
                f_Login loginForm = new f_Login();
                loginForm.Show();

                // 4. Đóng form HomePage hiện tại một cách êm ái, an toàn tuyệt đối
                this.Close();
            }
        }

        private void f_HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["f_Login"] != null && !Application.OpenForms["f_Login"].Visible)
                Application.Exit();
        }

        // ── Chat bot ────────────────────────────────────

        private void btnSendChat_Click(object sender, EventArgs e)
        {
            string userText = txtChatInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            rtbChatHistory.SelectionColor = Color.Blue;
            rtbChatHistory.AppendText("👤 Bạn: " + userText + "\n");
            txtChatInput.Clear();

            string botResponse = ProcessBotResponse(userText);
            if (botResponse == "redirect" || this.IsDisposed) return;

            rtbChatHistory.SelectionColor = Color.DarkGreen;
            rtbChatHistory.AppendText(botResponse + "\n\n");
            rtbChatHistory.ScrollToCaret();
            txtChatInput.Focus();
        }

        private void txtChatInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnSendChat_Click(sender, e); }
        }

        private void pnlChoDuyet_Click(object sender, EventArgs e)
        {
            if (Globals.GlobalPosition == 0) btnAccountManage_Click(sender, e);
        }
        private void btnStudentScore_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_StudentScore());
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_StudentRequest());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_Assign());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowUserControl(new f_Contact());
                

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            HienThiTrangChuGoc();
        }

        private void btnSendChat_Click_1(object sender, EventArgs e)
        {
            string userText = txtChatInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            rtbChatHistory.SelectionColor = Color.Blue;
            rtbChatHistory.AppendText("👤 Bạn: " + userText + "\n");
            txtChatInput.Clear();

            string botResponse = ProcessBotResponse(userText);
            if (botResponse == "redirect" || this.IsDisposed) return;

            rtbChatHistory.SelectionColor = Color.DarkGreen;
            rtbChatHistory.AppendText(botResponse + "\n\n");
            rtbChatHistory.ScrollToCaret();
            txtChatInput.Focus();
        }

        private void pnlCardPending_Click(object sender, EventArgs e)
        {
            if (Globals.GlobalPosition == 0) btnAccountManage_Click(sender, e);
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            int position = Globals.GlobalPosition;
            string username = Globals.GlobalUserName;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Không tìm thấy phiên đăng nhập hợp lệ để cập nhật ảnh!", "Thông báo");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 1. Chuyển đổi ảnh vừa chọn sang mảng nhị phân byte[]
                    byte[] imageBytes = null;
                    using (Image img = Image.FromFile(ofd.FileName))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            // Scale nhẹ ảnh về 150x150 cho nhẹ bộ nhớ Database
                            using (Bitmap bmp = new Bitmap(img, new Size(150, 150)))
                            {
                                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                imageBytes = ms.ToArray();
                            }
                        }
                    }

                    // 2. Kiểm tra phân hệ để thực thi kịch bản SQL tương ứng
                    My_DB tempDb = new My_DB();
                    tempDb.openConnection();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = tempDb.conn;

                    if (position == 1) // Nếu là Sinh viên -> Cập nhật bảng Student
                    {
                        cmd.CommandText = "UPDATE Student SET Pture = @pic WHERE MSSV = @username";
                    }
                    else // Nếu là Admin (0) hoặc HR (2) -> Cập nhật bảng Login
                    {
                        cmd.CommandText = "UPDATE Login SET Pic = @pic WHERE LOWER(TRIM(Username)) = LOWER(@username)";
                        cmd.Parameters.AddWithValue("@fullname", userFullName ?? "");
                    }

                    cmd.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image) { Value = imageBytes });
                    cmd.Parameters.AddWithValue("@username", username);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Đã cập nhật ảnh đại diện cá nhân mới thành công tốt đẹp!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            picUserAvatar.Image = Image.FromStream(ms);
                        }
                        LoadUserAccountInfoCard();
                    }
                    tempDb.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi trong quá trình lưu ảnh mới: " + ex.Message, "Lỗi thực thi");
                }
            }
        }
    }
}