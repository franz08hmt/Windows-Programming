using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_EditDeleteStudent : Form
    {
        private byte[] _selectedImage = null;

        public f_EditDeleteStudent()
        {
            InitializeComponent();
        }

        private void f_EditDeleteStudent_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvStudents.DataSource = Student.GetStudents();
            dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
            dgvStudents.Columns["Fname"].HeaderText = "Họ";
            dgvStudents.Columns["Lname"].HeaderText = "Tên";
            dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
            dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
            dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
            dgvStudents.Columns["Email"].HeaderText = "Email";
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                txtMSSV.Text = row.Cells["MSSV"].Value.ToString();
                txtFname.Text = row.Cells["Fname"].Value.ToString();
                txtLname.Text = row.Cells["Lname"].Value.ToString();
                dtpDob.Value = Convert.ToDateTime(row.Cells["Dob"].Value);
                cboGender.Text = row.Cells["Gder"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtMSSV.Enabled = false;

                // Load ảnh từ DB
                LoadStudentImage(int.Parse(txtMSSV.Text));
            }
        }

        private void LoadStudentImage(int mssv)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Pture FROM Student WHERE MSSV=@mssv", db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])result;
                    using (MemoryStream ms = new MemoryStream(imgBytes))
                        picStudent.Image = Image.FromStream(ms);
                    _selectedImage = imgBytes;
                }
                else
                {
                    picStudent.Image = null;
                    _selectedImage = null;
                }
            }
            finally { db.closeConnection(); }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                _selectedImage = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa!", "Thông báo");
                return;
            }

            Student s = new Student(
                int.Parse(txtMSSV.Text),
                txtFname.Text, txtLname.Text,
                dtpDob.Value, cboGender.Text,
                txtPhone.Text, "", "", txtEmail.Text, _selectedImage
            );

            if (s.EditStudent())
            {
                MessageBox.Show("Sửa thành công!", "Thông báo");
                LoadData();
            }
            else
                MessageBox.Show("Sửa thất bại!", "Lỗi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo");
                return;
            }

            // Kiểm tra có điểm trong bảng Score không
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Score WHERE MSSV=@mssv", db.conn);
                checkCmd.Parameters.AddWithValue("@mssv", int.Parse(txtMSSV.Text));
                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa! Sinh viên này đã có điểm trong hệ thống.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            finally { db.closeConnection(); }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên " + txtMSSV.Text + "?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (Student.DeleteStudent(int.Parse(txtMSSV.Text)))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    LoadData();
                    ClearFields();
                }
                else
                    MessageBox.Show("Xóa thất bại!", "Lỗi");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }

        private void ClearFields()
        {
            txtMSSV.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            picStudent.Image = null;
            _selectedImage = null;
            txtMSSV.Enabled = false;
        }
    }
}