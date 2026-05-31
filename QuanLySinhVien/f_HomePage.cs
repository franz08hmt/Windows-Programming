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
            rtbChatHistory.AppendText("🤖 Trợ lý: Xin chào! Tôi có thể giúp gì cho bạn? (Ví dụ: Bạn có thể gõ 'Thêm SV', 'Xem danh sách', 'Có bao nhiêu sinh viên điểm cao?').\n\n");

            lblXinChao.Text = "Xin chào, " + userFullName;
            ThongKeHeThong();
        }

        private string ProcessBotResponse(string userInput)
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
            }
            catch (Exception ex)
            {
                return "🤖 Trợ lý: Úi, đã xảy ra lỗi nhỏ khi tôi truy vấn cơ sở dữ liệu: " + ex.Message;
            }

            return "🤖 Trợ lý: Tôi chưa hiểu rõ câu lệnh của bạn lắm. Ní có thể gõ lại các từ khóa như 'Thêm SV', 'Danh sách', hoặc 'Điểm cao' để tôi hỗ trợ nhé!";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

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

        private void btnSendChat_Click(object sender, EventArgs e)
        {
            string userText = txtChatInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

      
            rtbChatHistory.SelectionColor = Color.Blue;
            rtbChatHistory.AppendText("👤 Bạn: " + userText + "\n");

    
            txtChatInput.Clear();

        
            string botResponse = ProcessBotResponse(userText);

     
            if (botResponse == "redirect" || this.IsDisposed)
            {
                return;
            }

       
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
    }
}