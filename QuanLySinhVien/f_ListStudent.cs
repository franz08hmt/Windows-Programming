using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ListStudent : Form
    {
        private DataView svView;
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
            DataTable dt = Student.GetStudents();
            svView = new DataView(dt);
            dgvStudents.DataSource = svView;

            dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
            dgvStudents.Columns["Fname"].HeaderText = "Họ";
            dgvStudents.Columns["Lname"].HeaderText = "Tên";
            dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
            dgvStudents.Columns["Dob"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
            dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
            dgvStudents.Columns["Email"].HeaderText = "Email";

            if (dgvStudents.Columns["Pture"] != null)
            {
                dgvStudents.Columns["Pture"].HeaderText = "Hình ảnh";

                ((DataGridViewImageColumn)dgvStudents.Columns["Pture"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            dgvStudents.RowTemplate.Height = 60;
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                row.Height = 60;
            }

            UpdateTotalCount();
        }

        private void UpdateTotalCount()
        {
            int realCount = dgvStudents.AllowUserToAddRows ? dgvStudents.Rows.Count - 1 : dgvStudents.Rows.Count;
            if (realCount < 0) realCount = 0;
            lblTotal.Text = "Tổng số sinh viên: " + realCount.ToString();
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm...") return;

            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT MSSV, Fname, Lname, Dob, Gder, Phone, Email, Pture " +
                               "FROM Student WHERE " +
                               "CAST(MSSV AS NVARCHAR) LIKE @search OR " +
                               "Fname LIKE @search OR Lname LIKE @search";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                svView = new DataView(dt);
                dgvStudents.DataSource = svView;

                if (dgvStudents.Columns["Pture"] != null)
                {
                    dgvStudents.Columns["Pture"].HeaderText = "Hình ảnh";
                }

                UpdateTotalCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            finally { db.closeConnection(); }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm...")
            {
                txtSearch.Text = ""; // Xóa chữ gợi ý đi
                txtSearch.ForeColor = Color.Black; // Chuyển màu chữ thành đen để gõ
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm..."; // Hiện lại chữ gợi ý
                txtSearch.ForeColor = Color.Gray; // Chuyển lại thành màu xám
            }
        }


        private void btRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            txtSearch.Text = "Tìm kiếm...";
            txtSearch.ForeColor = Color.Gray;
        }
        // Lọc giới tính
        private void cboFilterGender_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (svView == null) return;

            string selectedGender = cboFilterGender.Text.Trim();

            // Kiểm tra chính xác chữ hiển thị trên ComboBox của bạn
            if (selectedGender == "Tất cả" || string.IsNullOrEmpty(selectedGender))
            {
                svView.RowFilter = ""; // Xóa bộ lọc
            }
            else
            {
                // Lọc theo giá trị được chọn (Nam hoặc Nữ)
                svView.RowFilter = $"Gder = '{selectedGender}'";
            }

            UpdateTotalCount();
        }

        // Lọc sắp xếp  
        private void cboSortBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (svView == null) return;

            string selectedSort = cboSortBy.Text.Trim();

            if (selectedSort == "Mã sinh viên" || selectedSort == "Mã SV")
            {
                svView.Sort = "MSSV ASC";
            }
            else if (selectedSort == "Tên")
            {
                svView.Sort = "Lname ASC";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;

            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();

            this.Close();
        }

        private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];


                string mssv = row.Cells["MSSV"].Value.ToString();
                string ho = row.Cells["Fname"].Value != null ? row.Cells["Fname"].Value.ToString() : "";
                string ten = row.Cells["Lname"].Value != null ? row.Cells["Lname"].Value.ToString() : "";
                string ngaysinh = row.Cells["Dob"].Value != null ? row.Cells["Dob"].Value.ToString() : DateTime.Now.ToString();
                string gioitinh = row.Cells["Gder"].Value != null ? row.Cells["Gder"].Value.ToString() : "Nam";
                string dienthoai = row.Cells["Phone"].Value != null ? row.Cells["Phone"].Value.ToString() : "";
                string email = row.Cells["Email"].Value != null ? row.Cells["Email"].Value.ToString() : "";

                f_EditStudent editForm = new f_EditStudent();

                editForm.LayThongTinTuDanhSach(mssv, ho, ten, ngaysinh, gioitinh, dienthoai, email);

                editForm.Show();

                this.Close();
            }
        }
    }
}