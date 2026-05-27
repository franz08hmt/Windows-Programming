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
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );

        public f_Login()
        {
            InitializeComponent();
        }

        private bool ValidateInput()
        {
            // Bỏ qua nếu người dùng chưa nhập gì mà vẫn để chữ gợi ý
            string userText = (txtUsername.Text == "Tên đăng nhập" || txtUsername.Text == "Họ và tên") ? "" : txtUsername.Text;
            string passText = (txtPassword.Text == "●●●●●●●●●●") ? "" : txtPassword.Text;

            bool valid = true;
            if (string.IsNullOrEmpty(userText))
            {
                errorProvider1.SetError(txtUsername, "Vui lòng nhập tên đăng nhập!");
                valid = false;
            }
            else errorProvider1.SetError(txtUsername, "");

            if (string.IsNullOrEmpty(passText))
            {
                errorProvider1.SetError(txtPassword, "Vui lòng nhập mật khẩu!");
                valid = false;
            }
            else errorProvider1.SetError(txtPassword, "");

            if (!rdStudent.Checked && !rdHR.Checked)
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@pos", position);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string fullName = reader["Fname"].ToString() + " " + reader["Lname"].ToString();

                    Globals.SetSession(
                        reader["MSGV"].ToString(),
                        fullName,
                        position);

                    MessageBox.Show("Đăng nhập thành công!\nXin chào: " + Globals.GlobalUserName,
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đóng DataReader TRƯỚC KHI mở form mới để tránh lỗi Database
                    reader.Close();

                    f_HomePage homeForm = new f_HomePage(fullName);
                    homeForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập hoặc không có quyền truy cập!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                }
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

        // Mở đúng form f_Register (Đăng ký tài khoản)
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            f_Register reg = new f_Register();
            reg.ShowDialog();
            this.Show(); // Hiện lại form login khi tắt form đăng ký
        }

        private void lnkForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            f_ForgetPass forgetPass = new f_ForgetPass();
            forgetPass.ShowDialog();
            this.Show();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Họ và tên" || txtUsername.Text == "Tên đăng nhập")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Tên đăng nhập";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "●●●●●●●●●●")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.PasswordChar = '●';
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "●●●●●●●●●●";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.PasswordChar = '\0';
            }
        }

        private void f_Login_Load(object sender, EventArgs e)
        {
            pnlBackground.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlBackground.Width, pnlBackground.Height, 25, 25));
            btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 12, 12));
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) { }
    }
}