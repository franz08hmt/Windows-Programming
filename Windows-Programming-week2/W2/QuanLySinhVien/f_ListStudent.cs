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

        private void btAdd_Click(object sender, EventArgs e)
        {
            f_AddStudent formThem = new f_AddStudent();
            formThem.ShowDialog();
            LoadData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null || dgvStudents.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa từ danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Lấy giá trị MSSV của dòng đang được chọn
            string mssv = dgvStudents.CurrentRow.Cells["MSSV"].Value.ToString();

            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                string checkScoreQuery = "SELECT COUNT(*) FROM Score WHERE MSSV = @mssv";
                SqlCommand checkCmd = new SqlCommand(checkScoreQuery, db.conn);
                checkCmd.Parameters.AddWithValue("@mssv", mssv);

                int scoreCount = (int)checkCmd.ExecuteScalar(); // Lấy ra số lượng dòng điểm tìm được

                if (scoreCount > 0)
                {
                    // Nếu tìm thấy lớn hơn 0 dòng điểm -> Chặn luôn không cho xóa!
                    MessageBox.Show($"Không thể xóa sinh viên có mã {mssv} vì sinh viên này đã có điểm trong hệ thống!",
                        "Không cho phép xóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; // Dừng hàm lại, không chạy xuống code xóa bên dưới nữa
                }


                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên có mã {mssv} không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM Student WHERE MSSV = @mssv";
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        MessageBox.Show("Xóa thông tin sinh viên thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sinh viên hoặc xóa không thành công!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã chọn dòng nào trên bảng chưa
            if (dgvStudents.CurrentRow == null || dgvStudents.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa từ danh sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Khởi tạo Form f_AddStudent
            f_AddStudent formSua = new f_AddStudent();

            // 3. Lấy dữ liệu từ các dòng đang chọn trên DataGridView
            string mssv = dgvStudents.CurrentRow.Cells["MSSV"].Value.ToString();
            string ho = dgvStudents.CurrentRow.Cells["Fname"].Value.ToString();
            string ten = dgvStudents.CurrentRow.Cells["Lname"].Value.ToString();
            string ngaysinh = dgvStudents.CurrentRow.Cells["Dob"].Value.ToString();
            string gioitinh = dgvStudents.CurrentRow.Cells["Gder"].Value.ToString();
            string dienthoai = dgvStudents.CurrentRow.Cells["Phone"].Value.ToString();
            string email = dgvStudents.CurrentRow.Cells["Email"].Value.ToString();

            // 4. Truyền toàn bộ dữ liệu này sang các ô nhập liệu bên Form Sửa
            formSua.LayThongTinSua(mssv, ho, ten, ngaysinh, gioitinh, dienthoai, email);

            // 5. Hiển thị Form lên dưới dạng hộp thoại
            formSua.ShowDialog();

            // 6. Sau khi người dùng sửa xong và đóng form lại, load lại bảng dữ liệu
            LoadData();
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
    }
}