using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_NewPass : BaseForm
    {
        private string _username;

        public f_NewPass(string username)
        {
            InitializeComponent();
            _username = username;
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text) ||
                string.IsNullOrEmpty(txtConfirmPass.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPass.Clear();
                txtConfirmPass.Focus();
                return;
            }

            if (txtNewPass.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Login SET Pass = @pass WHERE Username = @user",
                    db.conn);
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = HashHelper.HashSHA256(txtNewPass.Text);
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = _username;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đổi mật khẩu thành công!\nVui lòng đăng nhập lại.",
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

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;

            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();

            this.Close();
        }


    }
}