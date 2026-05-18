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
        private DataGridView dgvStudents;
        private TextBox txtMSSV, txtFname, txtLname, txtPhone, txtEmail;
        private DateTimePicker dtpDob;
        private ComboBox cboGender;
        private PictureBox picStudent;

        public f_EditDeleteStudent()
        {
            InitializeComponent();
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            UIHelper.ApplyFormStyle(this, "Sửa / Xóa Sinh viên", 900, 600);
            this.Controls.Clear();

            var header = UIHelper.CreateSmallHeader(this, "SỬA / XÓA SINH VIÊN");
            this.Controls.Add(header);

            // DataGridView bên trái
            Panel cardLeft = UIHelper.CreateCard(15, 65, 430, 505);
            this.Controls.Add(cardLeft);

            Label lblList = new Label();
            lblList.Text = "Danh sách sinh viên";
            lblList.Font = new Font("Arial", 10, FontStyle.Bold);
            lblList.ForeColor = UIHelper.PrimaryBlue;
            lblList.AutoSize = false;
            lblList.Size = new Size(400, 25);
            lblList.Location = new Point(10, 10);
            cardLeft.Controls.Add(lblList);

            dgvStudents = new DataGridView();
            dgvStudents.Size = new Size(410, 450);
            dgvStudents.Location = new Point(10, 40);
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.BorderStyle = BorderStyle.None;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.ReadOnly = true;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = UIHelper.PrimaryBlue;
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvStudents.EnableHeadersVisualStyles = false;
            dgvStudents.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            dgvStudents.CellClick += DgvStudents_CellClick;
            cardLeft.Controls.Add(dgvStudents);

            // Card phải - form edit
            Panel cardRight = UIHelper.CreateCard(460, 65, 420, 505);
            this.Controls.Add(cardRight);

            Label lblEdit = new Label();
            lblEdit.Text = "Thông tin sinh viên";
            lblEdit.Font = new Font("Arial", 10, FontStyle.Bold);
            lblEdit.ForeColor = UIHelper.PrimaryBlue;
            lblEdit.AutoSize = false;
            lblEdit.Size = new Size(380, 25);
            lblEdit.Location = new Point(15, 10);
            cardRight.Controls.Add(lblEdit);

            cardRight.Controls.Add(UIHelper.CreateLabel("MSSV", 15, 45));
            txtMSSV = UIHelper.CreateTextBox(15, 62, 380);
            txtMSSV.Enabled = false;
            txtMSSV.BackColor = Color.FromArgb(220, 220, 220);
            cardRight.Controls.Add(txtMSSV);

            cardRight.Controls.Add(UIHelper.CreateLabel("Họ", 15, 100));
            txtFname = UIHelper.CreateTextBox(15, 117, 175);
            cardRight.Controls.Add(txtFname);

            cardRight.Controls.Add(UIHelper.CreateLabel("Tên", 205, 100));
            txtLname = UIHelper.CreateTextBox(205, 117, 175);
            cardRight.Controls.Add(txtLname);

            cardRight.Controls.Add(UIHelper.CreateLabel("Ngày sinh", 15, 157));
            dtpDob = new DateTimePicker();
            dtpDob.Size = new Size(380, 30);
            dtpDob.Location = new Point(15, 174);
            dtpDob.Font = new Font("Arial", 10);
            cardRight.Controls.Add(dtpDob);

            cardRight.Controls.Add(UIHelper.CreateLabel("Giới tính", 15, 214));
            cboGender = new ComboBox();
            cboGender.Items.AddRange(new[] { "Nam", "Nữ", "Khác" });
            cboGender.Font = new Font("Arial", 10);
            cboGender.Size = new Size(380, 30);
            cboGender.Location = new Point(15, 231);
            cboGender.FlatStyle = FlatStyle.Flat;
            cboGender.BackColor = UIHelper.LightBlue;
            cardRight.Controls.Add(cboGender);

            cardRight.Controls.Add(UIHelper.CreateLabel("Điện thoại", 15, 271));
            txtPhone = UIHelper.CreateTextBox(15, 288, 380);
            cardRight.Controls.Add(txtPhone);

            cardRight.Controls.Add(UIHelper.CreateLabel("Email", 15, 328));
            txtEmail = UIHelper.CreateTextBox(15, 345, 380);
            cardRight.Controls.Add(txtEmail);

            // PictureBox + chọn ảnh
            picStudent = new PictureBox();
            picStudent.Size = new Size(60, 60);
            picStudent.Location = new Point(320, 155);
            picStudent.SizeMode = PictureBoxSizeMode.Zoom;
            picStudent.BorderStyle = BorderStyle.FixedSingle;
            picStudent.BackColor = UIHelper.LightBlue;
            cardRight.Controls.Add(picStudent);

            var btnPic = UIHelper.CreateSecondaryButton("Ảnh", 320, 220, 75, 28);
            btnPic.Click += BtnPic_Click;
            cardRight.Controls.Add(btnPic);

            // Buttons
            var btnEdit = UIHelper.CreatePrimaryButton("Sửa", 15, 430, 110);
            btnEdit.Click += BtnEdit_Click;
            cardRight.Controls.Add(btnEdit);

            var btnDelete = UIHelper.CreateSecondaryButton("Xóa", 140, 430, 110);
            btnDelete.BackColor = Color.FromArgb(255, 240, 240);
            btnDelete.ForeColor = Color.FromArgb(204, 0, 0);
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(204, 0, 0);
            btnDelete.Click += BtnDelete_Click;
            cardRight.Controls.Add(btnDelete);

            var btnRefresh = UIHelper.CreateSecondaryButton("Làm mới", 265, 430, 110);
            btnRefresh.Click += BtnRefresh_Click;
            cardRight.Controls.Add(btnRefresh);

            LoadData();
        }

        private void LoadData()
        {
            dgvStudents.DataSource = Student.GetStudents();
            if (dgvStudents.Columns.Count > 0)
            {
                dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
                dgvStudents.Columns["Fname"].HeaderText = "Họ";
                dgvStudents.Columns["Lname"].HeaderText = "Tên";
                dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
                dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
                dgvStudents.Columns["Email"].HeaderText = "Email";
            }
        }

        private void DgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudents.Rows[e.RowIndex];
                txtMSSV.Text = row.Cells["MSSV"].Value.ToString();
                txtFname.Text = row.Cells["Fname"].Value.ToString();
                txtLname.Text = row.Cells["Lname"].Value.ToString();
                dtpDob.Value = Convert.ToDateTime(row.Cells["Dob"].Value);
                cboGender.Text = row.Cells["Gder"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                LoadStudentImage(int.Parse(txtMSSV.Text));
            }
        }

        private void LoadStudentImage(int mssv)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT Pture FROM Student WHERE MSSV=@mssv", db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])result;
                    using (var ms = new MemoryStream(imgBytes))
                        picStudent.Image = Image.FromStream(ms);
                    _selectedImage = imgBytes;
                }
                else { picStudent.Image = null; _selectedImage = null; }
            }
            finally { db.closeConnection(); }
        }

        private void BtnPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                _selectedImage = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Student s = new Student(int.Parse(txtMSSV.Text), txtFname.Text,
                txtLname.Text, dtpDob.Value, cboGender.Text,
                txtPhone.Text, "", "", txtEmail.Text, _selectedImage);
            if (s.EditStudent())
            {
                MessageBox.Show("Sửa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand check = new SqlCommand(
                    "SELECT COUNT(*) FROM Score WHERE MSSV=@mssv", db.conn);
                check.Parameters.AddWithValue("@mssv", int.Parse(txtMSSV.Text));
                if ((int)check.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Không thể xóa! Sinh viên đã có điểm trong hệ thống.",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            finally { db.closeConnection(); }

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên " + txtMSSV.Text + "?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (Student.DeleteStudent(int.Parse(txtMSSV.Text)))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
        }

        private void ClearFields()
        {
            txtMSSV.Text = txtFname.Text = txtLname.Text = "";
            txtPhone.Text = txtEmail.Text = "";
            picStudent.Image = null;
            _selectedImage = null;
        }
    }
}