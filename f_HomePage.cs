using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void ThongKeHeThong()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                string queryStudents = "SELECT COUNT(*) FROM Student";
                SqlCommand cmdStudents = new SqlCommand(queryStudents, db.conn);
                int totalStudents = (int)cmdStudents.ExecuteScalar();

                string queryPending = "SELECT COUNT(*) FROM Login WHERE VALID = 0";
                SqlCommand cmdPending = new SqlCommand(queryPending, db.conn);
                int totalPending = (int)cmdPending.ExecuteScalar();

                lblTotalStudents.Text = totalStudents.ToString();
                lblTotalPending.Text = totalPending.ToString();

                lblTotalHR.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật bảng tổng quan: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
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

        private void HomePage_Load(object sender, EventArgs e)
        {
            rtbChatHistory.AppendText("🤖 Trợ lý AI: Xin chào! Tôi có thể giúp gì cho bạn? (Ní có thể gõ lệnh nhanh như 'Thêm SV', 'Xem danh sách' hoặc hỏi tôi bất cứ câu hỏi quản lý giáo dục nào nhé).\n\n");

            lblXinChao.Text = "Xin chào, " + userFullName;
            ThongKeHeThong();
        }

        private async Task<string> ProcessBotResponseAsync(string userInput)
        {
            string input = userInput.ToLower().Trim();
            My_DB db = new My_DB();

            try
            {

                if (input.Contains("thêm sv") || input.Contains("them sinh vien"))
                {
                    bttAdd_Click(null, null);
                    return "redirect";
                }
                if (input.Contains("danh sách") || input.Contains("xem danh sach") || input.Contains("danh sach sv"))
                {
                    bttList_Click(null, null);
                    return "redirect";
                }
                if (input.Contains("quản lý môn") || input.Contains("them mon hoc"))
                {
                    btnManageCourse_Click(null, null);
                    return "redirect";
                }

                if (input.Contains("điểm cao") || input.Contains("diem cao") || input.Contains("sinh vien gioi"))
                {
                    db.openConnection();
                    string query = "SELECT COUNT(DISTINCT MSSV) FROM Score WHERE Score >= 8.0";
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    db.closeConnection();

                    if (count > 0)
                        return $"🤖 Trợ lý: Hiện tại hệ thống ghi nhận có {count} sinh viên đạt đầu điểm từ Giỏi trở lên (Score >= 8.0). Thật tuyệt vời!";
                    else
                        return "🤖 Trợ lý: Hiện tại chưa có sinh viên nào đạt điểm tích lũy mức Giỏi (>= 8.0) ní ơi.";
                }

                if (input.Contains("bao nhiêu sinh viên") || input.Contains("tong so sv") || input.Contains("so luong sv"))
                {
                    db.openConnection();
                    string query = "SELECT COUNT(*) FROM Student";
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    db.closeConnection();
                    return $"🤖 Trợ lý: Tổng số lượng sinh viên đang được quản lý trong hệ thống là: {count} sinh viên.";
                }

                if (input.Contains("hello") || input.Contains("hi") || input.Contains("xin chào"))
                {
                    return "🤖 Trợ lý: Xin chào ní! Tôi có thể hỗ trợ gì cho các thao tác quản lý hôm nay không?";
                }

                string promptDinhHuong = $"Bạn là trợ lý ảo thông minh tích hợp trong phần mềm quản lý sinh viên của trường đại học. " +
                                         $"Người dùng hiện tại tên là {userFullName} đang hỏi câu sau, hãy trả lời ngắn gọn, tinh tế và chuyên nghiệp dưới 3 dòng văn bản nhé: {userInput}";

                string kếtQuảAI = await AIService.AskChatGPTAsync(promptDinhHuong);
                return kếtQuảAI;

            }
            catch (Exception ex)
            {
                return "🤖 Trợ lý: Úi, đã xảy ra lỗi nhỏ khi tôi xử lý dữ liệu: " + ex.Message;
            }
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            f_AddStudent addForm = new f_AddStudent();
            addForm.Show();
            this.Close();
        }

        private void bttList_Click(object sender, EventArgs e)
        {
            f_ListStudent listForm = new f_ListStudent();
            listForm.Show();
            this.Close();
        }

        private void bttLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                f_Login loginForm = new f_Login();
                loginForm.Show();
                this.Close();
            }
        }

        private void f_HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["f_Login"] != null && !Application.OpenForms["f_Login"].Visible)
            {
                Application.Exit();
            }
        }

        private void bttFix_Click(object sender, EventArgs e)
        {
            f_EditStudent editForm = new f_EditStudent();
            editForm.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void pnlTongSinhVien_Paint(object sender, PaintEventArgs e)
        {
            BoGocPanel(pnlTongSinhVien, 20);
        }

        private void pnlChoDuyet_Paint(object sender, PaintEventArgs e)
        {
            BoGocPanel(pnlChoDuyet, 20);
        }

        private void pnlTaiKhoanHR_Paint(object sender, PaintEventArgs e)
        {
            BoGocPanel(pnlTaiKhoanHR, 20);
        }

        private void btnRegisterMenu_Click(object sender, EventArgs e)
        {
            f_RegisterCourse formDangKy = new f_RegisterCourse();
            formDangKy.ShowDialog();
            this.Close();
        }

        private void btnManageCourse_Click(object sender, EventArgs e)
        {
            f_ManageCourse formQuanLy = new f_ManageCourse();
            formQuanLy.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_ManageScore formQuanLyDiem = new f_ManageScore();
            formQuanLyDiem.ShowDialog();
            this.Close();
        }

        private async void btnSendChat_Click(object sender, EventArgs e)
        {
            string userText = txtChatInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            // 1. Đổ nội dung người dùng gõ vào RichTextBox
            rtbChatHistory.SelectionColor = Color.Blue;
            rtbChatHistory.AppendText("👤 Bạn: " + userText + "\n");
            txtChatInput.Clear();

            // 2. Lưu lại vị trí hiện tại trước khi báo trạng thái chờ
            int viTriTruocKhiAiChay = rtbChatHistory.TextLength;

            // Hiển thị trạng thái chờ tạm thời
            rtbChatHistory.SelectionColor = Color.Gray;
            rtbChatHistory.AppendText("🤖 Trợ lý AI đang suy nghĩ...\n");

            // 3. Gọi hàm xử lý lấy câu trả lời từ DB hoặc API Gemini
            string botResponse = await ProcessBotResponseAsync(userText);

            if (botResponse == "redirect" || this.IsDisposed) return;

            // 4. XOÁ SẠCH DÒNG CHỜ: Cắt bỏ đoạn chữ "đang suy nghĩ..." dựa trên vị trí đã lưu, không sợ lỗi lệch byte icon nữa!
            rtbChatHistory.Text = rtbChatHistory.Text.Substring(0, viTriTruocKhiAiChay);

            // 5. Đổ kết quả phản hồi chuẩn lên giao diện
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

        private void button2_Click(object sender, EventArgs e)
        {
            f_Statistic formThongKe = new f_Statistic();
            formThongKe.ShowDialog();
            this.Close();
        }
    }
}