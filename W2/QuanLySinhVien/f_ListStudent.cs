using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ListStudent : Form
    {
        private bool _isLoading = true;

        public f_ListStudent()
        {
            InitializeComponent();
        }

        private void f_ListStudent_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            cboGender.SelectedIndex = 0;
            cboSort.SelectedIndex = 0;
            _isLoading = false;
            LoadData();
        }

        private void LoadData()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();

                string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email " +
                               "FROM Student WHERE 1=1";

                if (cboGender.SelectedIndex > 0)
                    query += " AND Gder = @gender";

                if (!string.IsNullOrEmpty(txtSearch.Text))
                    query += " AND (CAST(MSSV AS NVARCHAR) LIKE @search " +
                             "OR Fname LIKE @search OR Lname LIKE @search)";

                if (cboSort.SelectedIndex == 1)
                    query += " ORDER BY MSSV";
                else if (cboSort.SelectedIndex == 2)
                    query += " ORDER BY Lname, Fname";

                SqlCommand cmd = new SqlCommand(query, db.conn);

                if (cboGender.SelectedIndex > 0)
                    cmd.Parameters.AddWithValue("@gender", cboGender.SelectedItem.ToString());

                if (!string.IsNullOrEmpty(txtSearch.Text))
                    cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dgvStudents.DataSource = dt;

                dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
                dgvStudents.Columns["Fname"].HeaderText = "Họ";
                dgvStudents.Columns["Lname"].HeaderText = "Tên";
                dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
                dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
                dgvStudents.Columns["Email"].HeaderText = "Email";

                lblTotal.Text = "Tổng số sinh viên: " + dt.Rows.Count;
            }
            finally { db.closeConnection(); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!_isLoading) LoadData();
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoading) LoadData();
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isLoading) LoadData();
        }
    }
}