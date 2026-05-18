using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_NewPass : Form
    {
        private string _username;
        private string _token;
        private TextBox txtToken, txtNewPass, txtConfirmPass;

        public f_NewPass(string username, string token = null)
        {
            InitializeComponent();
            _username = username;
            _token = token;
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            UIHelper.ApplyFormStyle(this, "Đặt mật khẩu mới", 420, 420);
            this.Controls.Clear();

            var header = UIHelper.CreateSmallHeader(this, "ĐẶT MẬT KHẨU MỚI");
            this.Controls.Add(header);

            var card = UIHelper.CreateCard(20, 65, 375, 320);
            this.Controls.Add(card);

            card.Controls.Add(UIHelper.CreateTitle("Mật khẩu mới", 20, 15));

            // Token input (chỉ hiện khi dùng link reset)
            if (_token != null)
            {
                card.Controls.Add(UIHelper.CreateLabel("Nhập token từ email (8 ký tự đầu)", 20, 60));
                txtToken = UIHelper.CreateTextBox(20, 77, 335);
                txtToken.MaxLength = 8;
                txtToken.CharacterCasing = CharacterCasing.Upper;
                card.Controls.Add(txtToken);
            }

            int yOffset = _token != null ? 50 : 0;

            card.Controls.Add(UIHelper.CreateLabel("Mật khẩu mới", 20, 120 + yOffset));
            txtNewPass = UIHelper.CreateTextBox(20, 137 + yOffset, 335, true);
            card.Controls.Add(txtNewPass);

            card.Controls.Add(UIHelper.CreateLabel("Xác nhận mật khẩu", 20, 177 + yOffset));
            txtConfirmPass = UIHelper.CreateTextBox(20, 194 + yOffset, 335, true);
            txtConfirmPass.TextChanged += (s, e) =>
            {
                txtConfirmPass.BackColor = txtConfirmPass.Text == txtNewPass.Text
                    ? Color.FromArgb(220, 255, 220)
                    : Color.FromArgb(255, 220, 220);
            };
            card.Controls.Add(txtConfirmPass);

            var btnSave = UIHelper.CreatePrimaryButton("Lưu mật khẩu", 20, 250 + yOffset, 160);
            btnSave.Click += BtnSave_Click;
            card.Controls.Add(btnSave);

            var btnCancel = UIHelper.CreateSecondaryButton("Hủy", 195, 250 + yOffset, 160);
            btnCancel.Click += (s, e) => this.Close();
            card.Controls.Add(btnCancel);
        }

        private bool VerifyToken(string inputToken)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Token, ExpireTime FROM ResetToken " +
                    "WHERE Username=@user AND Used=0", db.conn);
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = _username;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string savedToken = reader["Token"].ToString();
                    DateTime expireTime = (DateTime)reader["ExpireTime"];
                    reader.Close();

                    // So sánh 8 ký tự đầu (uppercase)
                    string tokenPrefix = savedToken.Substring(0, 8).ToUpper();
                    if (inputToken.ToUpper() == tokenPrefix &&
                        DateTime.Now <= expireTime)
                    {
                        // Đánh dấu token đã dùng
                        SqlCommand upd = new SqlCommand(
                            "UPDATE ResetToken SET Used=1 WHERE Username=@user",
                            db.conn);
                        upd.Parameters.Add("@user", SqlDbType.VarChar).Value = _username;
                        upd.ExecuteNonQuery();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            finally { db.closeConnection(); }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Verify token nếu dùng link reset
            if (_token != null)
            {
                if (string.IsNullOrEmpty(txtToken?.Text))
                {
                    MessageBox.Show("Vui lòng nhập token từ email!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!VerifyToken(txtToken.Text))
                {
                    MessageBox.Show("Token không hợp lệ hoặc đã hết hạn!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (string.IsNullOrEmpty(txtNewPass.Text) || txtNewPass.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd1 = new SqlCommand(
                    "UPDATE Login SET Pass=@pass WHERE Username=@user", db.conn);
                cmd1.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtNewPass.Text;
                cmd1.Parameters.Add("@user", SqlDbType.VarChar).Value = _username;
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand(
                    "UPDATE HR SET Pass=@pass2 WHERE Username=@user2", db.conn);
                cmd2.Parameters.Add("@pass2", SqlDbType.VarChar).Value = txtNewPass.Text;
                cmd2.Parameters.Add("@user2", SqlDbType.VarChar).Value = _username;
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }
    }
}