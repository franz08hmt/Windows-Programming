using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_HomePage : Form
    {
        private string userFullName;

        public f_HomePage()
        {
            InitializeComponent();
        }

        public f_HomePage(string loginName)
        {
            InitializeComponent();
            this.userFullName = loginName;
        }

        // ĐÃ FIX: Thống kê chính xác số lượng tài khoản HR trường học từ Database thay vì gán cứng bằng 0
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

        // ĐÃ FIX: Bổ sung ẩn/hiện các thẻ thống kê Dashboard nhạy cảm theo phân quyền tuần 10
        private void ApplyPermissions()
        {
            // Lấy quyền hiện tại của người dùng đã đăng nhập từ bộ lưu trữ Global
            int position = Globals.GlobalPosition;

            if (position == 0) // QUYỀN ADMIN (Quản trị viên)
            {
                // Admin nhìn thấy toàn bộ hệ thống
                bttAdd.Visible = true;
                bttList.Visible = true;
                bttFix.Visible = true;
                btnRegisterMenu.Visible = true;
                btnManageCourse.Visible = true;
                button1.Visible = true;
                btnStatistic.Visible = true;
                btnAccountManage.Visible = true; // Nút quản lý tài khoản / Duyệt tài khoản

                // Hiển thị đầy đủ 3 bảng thống kê số liệu tổng quan
                pnlTongSinhVien.Visible = true;
                pnlChoDuyet.Visible = true;
                pnlTaiKhoanHR.Visible = true;
            }
            else if (position == 2) // QUYỀN HR (Nhân sự / Giáo viên)
            {
                // HR được quản lý sinh viên, môn học, điểm, xem thống kê nhưng KHÔNG được duyệt tài khoản
                bttAdd.Visible = true;
                bttList.Visible = true;
                bttFix.Visible = true;
                btnRegisterMenu.Visible = true;
                btnManageCourse.Visible = true;
                button1.Visible = true;
                btnStatistic.Visible = true;

                btnAccountManage.Visible = false; // Ẩn nút Quản lý/Duyệt tài khoản đi

                // Ẩn bảng "Tài khoản chờ duyệt" trên Dashboard vì HR không có quyền duyệt
                pnlTongSinhVien.Visible = true;
                pnlChoDuyet.Visible = false;
                pnlTaiKhoanHR.Visible = true;
            }
            else if (position == 1) // QUYỀN STUDENT (Sinh viên)
            {
                // Sinh viên chỉ được đăng ký môn học và xem điểm của chính mình
                bttAdd.Visible = false;
                bttList.Visible = false;
                bttFix.Visible = false;
                btnManageCourse.Visible = false;
                btnStatistic.Visible = false;
                btnAccountManage.Visible = false;

                btnRegisterMenu.Visible = true; // Mở chức năng đăng ký môn học
                button1.Visible = true;        // Mở chức năng xem điểm

                // Sinh viên không được xem các bảng số liệu tổng quan nhạy cảm của nhà trường
                pnlTongSinhVien.Visible = false;
                pnlChoDuyet.Visible = false;
                pnlTaiKhoanHR.Visible = false;
            }
        }

        // ĐÃ FIX: Thêm kiểm tra null và kích thước an toàn cho tiến trình Bo góc của Panel
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
            catch
            {
                // Tránh lỗi khi luồng giao diện vẽ đè lúc Form chưa khởi tạo xong hoàn toàn
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            rtbChatHistory.AppendText("🤖 Trợ lý: Xin chào! Tôi có thể giúp gì cho bạn? " +
                "(Ví dụ: 'Thêm SV', 'Xem danh sách', 'Có bao nhiêu sinh viên điểm cao?').\n\n");
            lblXinChao.Text = "Xin chào, " + userFullName;
            ThongKeHeThong();
            ApplyPermissions();
        }

        // ĐÃ FIX: Chặn việc đi đường vòng qua Chatbot để mở lậu các chức năng cấm đối với Sinh viên
        private string ProcessBotResponse(string userInput)
        {
            string input = userInput.ToLower().Trim();
            My_DB db = new My_DB();
            int currentRole = Globals.GlobalPosition;

            try
            {
                if (input.Contains("thêm sv") || input.Contains("them sinh vien"))
                {
                    if (currentRole == 1) return "🤖 Trợ lý: Tài khoản Sinh viên không có quyền truy cập tính năng Thêm sinh viên!";
                    bttAdd_Click(null, null);
                    return "redirect";
                }

                if (input.Contains("danh sách") || input.Contains("xem danh sach") || input.Contains("danh sach sv"))
                {
                    if (currentRole == 1) return "🤖 Trợ lý: Tài khoản Sinh viên không có quyền xem Danh sách sinh viên!";
                    bttList_Click(null, null);
                    return "redirect";
                }

                if (input.Contains("quản lý môn") || input.Contains("them mon hoc"))
                {
                    if (currentRole == 1) return "🤖 Trợ lý: Tài khoản Sinh viên không có quyền Quản lý môn học!";
                    btnManageCourse_Click(null, null);
                    return "redirect";
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

        // ĐÃ FIX: Chuyển toàn bộ Show() -> ShowDialog() và loại bỏ this.Close() để tránh sập app
        private void bttAdd_Click(object sender, EventArgs e)
        {
            f_AddStudent addForm = new f_AddStudent();
            addForm.ShowDialog();
            ThongKeHeThong(); // Cập nhật lại số lượng sinh viên sau khi thêm mới
        }

        private void bttList_Click(object sender, EventArgs e)
        {
            f_ListStudent listForm = new f_ListStudent();
            listForm.ShowDialog();
            ThongKeHeThong(); // Cập nhật lại nếu danh sách có xóa/sửa sinh viên
        }

        private void bttFix_Click(object sender, EventArgs e)
        {
            f_EditStudent editForm = new f_EditStudent();
            editForm.ShowDialog();
            ThongKeHeThong();
        }

        private void btnRegisterMenu_Click(object sender, EventArgs e)
        {
            f_RegisterCourse formDangKy = new f_RegisterCourse();
            formDangKy.ShowDialog();
        }

        private void btnManageCourse_Click(object sender, EventArgs e)
        {
            f_ManageCourse formQuanLy = new f_ManageCourse();
            formQuanLy.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_ManageScore formQuanLyDiem = new f_ManageScore();
            formQuanLyDiem.ShowDialog();
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            f_Statistic form = new f_Statistic();
            form.ShowDialog();
            ThongKeHeThong(); // Cập nhật số liệu lỡ như form thống kê làm mới dữ liệu
        }

        private void btnAccountManage_Click(object sender, EventArgs e)
        {
            f_AccountManage form = new f_AccountManage();
            form.ShowDialog();
            ThongKeHeThong(); // Cập nhật lại số liệu thống kê chờ duyệt sau khi admin thao tác xong
        }

        private void bttLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Globals.ClearSession();
                f_Login loginForm = new f_Login();
                loginForm.Show();
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
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSendChat_Click(sender, e);
            }
        }

        // ── Paint events ────────────────────────────────

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }

        // ĐÃ FIX: Sử dụng ép kiểu an toàn từ 'sender' thay vì gọi trực tiếp biến tĩnh từ Designer để chặn NullReferenceException
        private void pnlTongSinhVien_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => BoGocPanel(sender as Panel, 20);

        private void pnlChoDuyet_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => BoGocPanel(sender as Panel, 20);

        private void pnlTaiKhoanHR_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
            => BoGocPanel(sender as Panel, 20);
    }
}