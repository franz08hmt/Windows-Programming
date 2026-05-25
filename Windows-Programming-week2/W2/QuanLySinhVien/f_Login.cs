using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_Login : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,     // Tọa độ x góc trên bên trái
        int nTopRect,      // Tọa độ y góc trên bên trái
        int nRightRect,    // Tọa độ x góc dưới bên phải
        int nBottomRect,   // Tọa độ y góc dưới bên phải
        int nWidthEllipse, // Độ bo tròn theo chiều ngang (số càng lớn góc càng tròn)
        int nHeightEllipse // Độ bo tròn theo chiều dọc
    );
        public f_Login()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            bool valid = true;
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Vui lòng nhập tên đăng nhập!");
                valid = false;
            }
            else errorProvider1.SetError(txtUsername, "");

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập mật khẩu!");
                valid = false;
            }
            else errorProvider1.SetError(txtPassword, "");

            if (!rdStudent.Checked && !rdHR.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valid = false;
            }
            return valid;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            int position = rdStudent.Checked ? 1 : 2;

            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string query = "SELECT * FROM Login " +
                    "WHERE Username = @user COLLATE SQL_Latin1_General_CP1_CS_AS " +
                    "AND Pass = @pass COLLATE SQL_Latin1_General_CP1_CS_AS " +
                    "AND position = @pos AND VALID = 1";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@pos", position);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Globals.SetSession(
                        reader["MSGV"].ToString(),
                        reader["Fname"].ToString() + " " + reader["Lname"].ToString(),
                        position);

                    MessageBox.Show("Đăng nhập thành công!\nXin chào: " + Globals.GlobalUserName,
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    f_ListStudent listForm = new f_ListStudent();
                    listForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập hoặc không có quyền truy cập!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f_Register reg = new f_Register();
            reg.ShowDialog();
        }
        private void lnkForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f_ForgetPass forgetPass = new f_ForgetPass();
            forgetPass.ShowDialog();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Họ và tên")
            {
                txtUsername.Text = ""; // Xóa chữ gợi ý đi
                txtUsername.ForeColor = Color.Black; // Chuyển màu chữ thành đen để gõ
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Họ và tên"; // Hiện lại chữ gợi ý
                txtUsername.ForeColor = Color.Gray; // Chuyển lại thành màu xám
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "●●●●●●●●●●")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '●'; // Khi gõ thì ẩn ký tự đi thành dấu chấm đen
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "●●●●●●●●●●";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0'; // Hiện lại text thường để thấy placeholder
            }
        }

        private void f_Login_Load(object sender, EventArgs e)
        {
            pnlBackground.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBackground.Width, pnlBackground.Height, 25, 25));
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 12, 12));
        }
    }
}