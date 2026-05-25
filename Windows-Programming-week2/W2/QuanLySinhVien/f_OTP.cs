using System;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_OTP : Form
    {
        private string _otpCode;

        public f_OTP(string otpCode)
        {
            InitializeComponent();
            _otpCode = otpCode;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text.Trim() == _otpCode)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng! Vui lòng thử lại.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOTP.Clear();
                txtOTP.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtOTP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}