using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
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
                btnManageRequest.Visible = true;  // Admin xem toàn bộ request
                btnStudentScore.Visible = true;

                pnlTongSinhVien.Visible = true;
                pnlChoDuyet.Visible = true;
                pnlTaiKhoanHR.Visible = true;
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

                pnlTongSinhVien.Visible = true;
                pnlChoDuyet.Visible = false;
                pnlTaiKhoanHR.Visible = true;
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

                btnRegisterMenu.Visible = true;  // Đăng ký môn học (có nút gửi request bên trong)
                button1.Visible = true;  // Xem điểm
                btnManageRequest.Visible = true;  // Xem trạng thái request của mình
                btnStudentScore.Visible = true;

                pnlTongSinhVien.Visible = false;
                pnlChoDuyet.Visible = false;
                pnlTaiKhoanHR.Visible = false;
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

        private void HomePage_Load(object sender, EventArgs e)
        {
            rtbChatHistory.AppendText("🤖 Trợ lý: Xin chào! Tôi có thể giúp gì cho bạn? " +
                "(Ví dụ: 'Thêm SV', 'Xem danh sách', 'Có bao nhiêu sinh viên điểm cao?').\n\n");

            // FIX ENCODING: gán trực tiếp từ Globals thay vì dùng biến truyền vào constructor
            // vì constructor nhận string từ f_Login có thể bị lỗi encoding nếu dùng VARCHAR
            string fullName = !string.IsNullOrEmpty(Globals.GlobalUserName)
                ? Globals.GlobalUserName
                : userFullName;
            lblXinChao.Text = "Xin chào, " + fullName;

            ThongKeHeThong();
            ApplyPermissions();
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

        private void bttAdd_Click(object sender, EventArgs e)
        {
            new f_AddStudent().ShowDialog();
            ThongKeHeThong();
        }
        private void bttList_Click(object sender, EventArgs e)
        {
            new f_ListStudent().ShowDialog();
            ThongKeHeThong();
        }
        private void bttFix_Click(object sender, EventArgs e)
        {
            new f_EditStudent().ShowDialog();
            ThongKeHeThong();
        }
        private void btnRegisterMenu_Click(object sender, EventArgs e)
        {
            new f_RegisterCourse().ShowDialog();
        }
        private void btnManageCourse_Click(object sender, EventArgs e)
        {
            new f_ManageCourse().ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new f_ManageScore().ShowDialog();
        }
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            new f_Statistic().ShowDialog();
            ThongKeHeThong();
        }
        private void btnAccountManage_Click(object sender, EventArgs e)
        {
            new f_AccountManage().ShowDialog();
            ThongKeHeThong();
        }
        private void btnManageClassroom_Click(object sender, EventArgs e)
        {
            new f_ManageClassroom().Show();
        }

        // CÂU 4 – Mở form Quản lý Request
        private void btnManageRequest_Click(object sender, EventArgs e)
        {
            if (Globals.GlobalPosition == 1) // Student → form gửi & xem request của mình
            {
                new f_StudentRequest().ShowDialog();
            }
            else // Admin/HR → form duyệt toàn bộ request
            {
                new f_ManageRequest().ShowDialog();
                ThongKeHeThong();
            }
        }

        private void bttLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Globals.ClearSession();
                new f_Login().Show();
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
            new f_StudentScore().ShowDialog();
        }

        // ── Paint events ────────────────────────────────

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void pnlTongSinhVien_Paint(object sender, PaintEventArgs e) => BoGocPanel(sender as Panel, 20);
        private void pnlChoDuyet_Paint(object sender, PaintEventArgs e) => BoGocPanel(sender as Panel, 20);
        private void pnlTaiKhoanHR_Paint(object sender, PaintEventArgs e) => BoGocPanel(sender as Panel, 20);
    }
}