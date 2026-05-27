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
            lblXinChao.Text = "Xin chào, " + userFullName;
            ThongKeHeThong();
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
        }

        private void btnManageCourse_Click(object sender, EventArgs e)
        {
            f_ManageCourse formQuanLy = new f_ManageCourse();
            formQuanLy.ShowDialog();
        }
    }
}