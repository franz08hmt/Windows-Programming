using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ListStudent : Form
    {
        private bool _isLoading = true;
        private TextBox txtSearch;
        private ComboBox cboGender, cboSort;
        private DataGridView dgvStudents;
        private Label lblTotal;

        public f_ListStudent()
        {
            InitializeComponent();
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            UIHelper.ApplyFormStyle(this, "Danh sách Sinh viên", 850, 600);
            this.Controls.Clear();

            var header = UIHelper.CreateSmallHeader(this, "DANH SÁCH SINH VIÊN");
            this.Controls.Add(header);

            // Toolbar
            Panel toolbar = new Panel();
            toolbar.Size = new Size(850, 50);
            toolbar.Location = new Point(0, 55);
            toolbar.BackColor = Color.White;
            this.Controls.Add(toolbar);

            // Search
            toolbar.Controls.Add(UIHelper.CreateLabel("Tìm kiếm:", 10, 15));
            txtSearch = UIHelper.CreateTextBox(80, 12, 200);
            txtSearch.TextChanged += (s, e) => { if (!_isLoading) LoadData(); };
            toolbar.Controls.Add(txtSearch);

            // Gender filter
            toolbar.Controls.Add(UIHelper.CreateLabel("Giới tính:", 300, 15));
            cboGender = new ComboBox();
            cboGender.Items.AddRange(new[] { "Tất cả", "Nam", "Nữ", "Khác" });
            cboGender.SelectedIndex = 0;
            cboGender.Font = new Font("Arial", 9);
            cboGender.Size = new Size(100, 28);
            cboGender.Location = new Point(370, 12);
            cboGender.FlatStyle = FlatStyle.Flat;
            cboGender.SelectedIndexChanged += (s, e) => { if (!_isLoading) LoadData(); };
            toolbar.Controls.Add(cboGender);

            // Sort
            toolbar.Controls.Add(UIHelper.CreateLabel("Sắp xếp:", 490, 15));
            cboSort = new ComboBox();
            cboSort.Items.AddRange(new[] { "Mặc định", "Theo MSSV", "Theo Tên" });
            cboSort.SelectedIndex = 0;
            cboSort.Font = new Font("Arial", 9);
            cboSort.Size = new Size(120, 28);
            cboSort.Location = new Point(555, 12);
            cboSort.FlatStyle = FlatStyle.Flat;
            cboSort.SelectedIndexChanged += (s, e) => { if (!_isLoading) LoadData(); };
            toolbar.Controls.Add(cboSort);

            // DataGridView
            dgvStudents = new DataGridView();
            dgvStudents.Size = new Size(820, 450);
            dgvStudents.Location = new Point(15, 115);
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
            this.Controls.Add(dgvStudents);

            // Total label
            lblTotal = new Label();
            lblTotal.Text = "Tổng số sinh viên: 0";
            lblTotal.Font = new Font("Arial", 9, FontStyle.Bold);
            lblTotal.ForeColor = UIHelper.PrimaryBlue;
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(15, 572);
            this.Controls.Add(lblTotal);

            _isLoading = false;
            LoadData();
        }

        private void LoadData()
        {
            // Nếu có search keyword → dùng SearchStudents()
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                DataTable result = Student.SearchStudents(txtSearch.Text);

                // Áp dụng thêm filter giới tính nếu có
                if (cboGender.SelectedIndex > 0)
                {
                    string gender = cboGender.SelectedItem.ToString();
                    DataView dv = result.DefaultView;
                    dv.RowFilter = "Gder = '" + gender + "'";
                    result = dv.ToTable();
                }

                // Sắp xếp
                if (cboSort.SelectedIndex == 1)
                    result.DefaultView.Sort = "MSSV ASC";
                else if (cboSort.SelectedIndex == 2)
                    result.DefaultView.Sort = "Lname ASC, Fname ASC";

                dgvStudents.DataSource = result.DefaultView.ToTable();
                ApplyColumnHeaders();
                lblTotal.Text = "Tổng số sinh viên: " + dgvStudents.Rows.Count;
                return;
            }

            // Không có search → query bình thường
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email FROM Student WHERE 1=1";

                if (cboGender.SelectedIndex > 0)
                    query += " AND Gder=@gender";
                if (cboSort.SelectedIndex == 1) query += " ORDER BY MSSV";
                else if (cboSort.SelectedIndex == 2) query += " ORDER BY Lname, Fname";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                if (cboGender.SelectedIndex > 0)
                    cmd.Parameters.AddWithValue("@gender", cboGender.SelectedItem.ToString());

                new SqlDataAdapter(cmd).Fill(dt);
                dgvStudents.DataSource = dt;
                ApplyColumnHeaders();
                lblTotal.Text = "Tổng số sinh viên: " + dt.Rows.Count;
            }
            finally { db.closeConnection(); }
        }

        private void ApplyColumnHeaders()
        {
            if (dgvStudents.Columns.Count == 0) return;
            if (dgvStudents.Columns.Contains("MSSV")) dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
            if (dgvStudents.Columns.Contains("Fname")) dgvStudents.Columns["Fname"].HeaderText = "Họ";
            if (dgvStudents.Columns.Contains("Lname")) dgvStudents.Columns["Lname"].HeaderText = "Tên";
            if (dgvStudents.Columns.Contains("Dob")) dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
            if (dgvStudents.Columns.Contains("Gder")) dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
            if (dgvStudents.Columns.Contains("Phone")) dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
            if (dgvStudents.Columns.Contains("Email")) dgvStudents.Columns["Email"].HeaderText = "Email";
        }
    }
}