using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_AddStudent : Form
    {
        byte[] studentImage = null;

        public f_AddStudent()
        {
            InitializeComponent();
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                MemoryStream ms = new MemoryStream();
                picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                studentImage = ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btnAdd_Click được gọi!", "Debug");
            if (string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtLname.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV và Tên!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMSSV.Text, out int mssv))
            {
                MessageBox.Show("MSSV phải là số!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student sv = new Student(
                mssv, txtFname.Text, txtLname.Text,
                dtpDob.Value, cboGender.Text, txtPhone.Text,
                "", "", txtEmail.Text, studentImage);
            if (sv.AddStudent())
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Thêm thất bại! MSSV có thể đã tồn tại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtFname.Clear();
            txtLname.Clear();
            dtpDob.Value = DateTime.Now;
            cboGender.SelectedIndex = -1;
            txtPhone.Clear();
            txtEmail.Clear();
            picStudent.Image = null;
            studentImage = null;
        }

        private void btnViewlist_Click(object sender, EventArgs e)
        {
            f_ListStudent listForm = new f_ListStudent();
            listForm.Show();
        }

        private void btnEditDelete_Click(object sender, EventArgs e)
        {
            f_EditDeleteStudent frm = new f_EditDeleteStudent();
            frm.ShowDialog();
        }
    }
}