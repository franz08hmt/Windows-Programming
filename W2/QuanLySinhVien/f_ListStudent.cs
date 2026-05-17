using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ListStudent : Form
    {
        public f_ListStudent()
        {
            InitializeComponent();
        }

        private void f_ListStudent_Load(object sender, EventArgs e)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email " +
                               "FROM Student WHERE " +
                               "CAST(MSSV AS NVARCHAR) LIKE @search OR " +
                               "Fname LIKE @search OR Lname LIKE @search";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dgvStudents.DataSource = dt;
            }
            finally { db.closeConnection(); }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}