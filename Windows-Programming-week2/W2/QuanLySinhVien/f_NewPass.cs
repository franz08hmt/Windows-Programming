using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_NewPass : Form
    {
        private string _username;

        public f_NewPass(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void btnSave_Click(object sender, EventArgs e)
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
                cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtNewPass.Text;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}