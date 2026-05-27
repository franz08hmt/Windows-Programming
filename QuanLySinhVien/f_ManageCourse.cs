using System;
using System.Data;
using System.Data.SqlClient; // Đã thêm thư viện này để thao tác DB
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ManageCourse : Form
    {
        public f_ManageCourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddMa.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAddTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên môn học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((int)nudAddSotc.Value <= 0)
            {
                MessageBox.Show("Số tín chỉ phải > 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((int)nudAddHky.Value < 1 || (int)nudAddHky.Value > 3)
            {
                MessageBox.Show("Học kỳ phải từ 1 đến 3!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Course c = new Course
            {
                Mamh = txtAddMa.Text.Trim(),
                Tenmh = txtAddTen.Text.Trim(),
                Sotc = (int)nudAddSotc.Value,
                Tuan = (int)nudAddTuan.Value,
                Hocky = (int)nudAddHky.Value,
                Decription = txtAddMota.Text.Trim()
            };

            if (c.AddCourse())
            {
                MessageBox.Show("Thêm môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTabAdd();
                btnRefresh_Click(sender, e); // Tự động làm mới bảng sau khi thêm
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Mã môn học có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTabAdd()
        {
            txtAddMa.Clear();
            txtAddTen.Clear();
            nudAddSotc.Value = 0;
            nudAddTuan.Value = 0;
            nudAddHky.Value = 0;
            txtAddMota.Clear();
        }

        // Nút Tìm kiếm này dùng để fetch dữ liệu lên các ô Edit (Giữ nguyên của bạn)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ma = txtEditMa.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Nhập Mã môn học để tìm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Course c = new Course();
            DataTable dt = c.GetCourseByMa(ma);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtEditTen.Text = row["TenMH"].ToString();
                nudEditSotc.Value = Convert.ToInt32(row["SoTC"]);
                nudEditTuan.Value = Convert.ToInt32(row["Tuan"]);
                nudEditHky.Value = Convert.ToInt32(row["Hky"]);
                txtEditMota.Text = row["Mota"].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditMa.Text)) return;

            Course c = new Course
            {
                Mamh = txtEditMa.Text.Trim(),
                Tenmh = txtEditTen.Text.Trim(),
                Sotc = (int)nudEditSotc.Value,
                Tuan = (int)nudEditTuan.Value,
                Hocky = (int)nudEditHky.Value,
                Decription = txtEditMota.Text.Trim()
            };

            if (c.EditCourse())
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRefresh_Click(sender, e); // Tự động làm mới bảng
            }
            else
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string ma = txtEditMa.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma)) return;

            // 🛑 TÍNH NĂNG MỚI: Kiểm tra xem môn học đã có sinh viên đăng ký chưa
            try
            {
                My_DB db = new My_DB();
                db.openConnection();
                SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM DKMH WHERE MaMH = @ma", db.conn);
                cmdCheck.Parameters.AddWithValue("@ma", ma);
                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());
                db.closeConnection();

                if (count > 0)
                {
                    MessageBox.Show("Không thể xóa! Môn học này hiện đang có sinh viên đăng ký.", "Cảnh báo ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Chặn lệnh xóa
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu không vướng ràng buộc thì cho phép xóa
            var confirm = MessageBox.Show($"Xóa môn học '{ma}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Course c = new Course { Mamh = ma };
                if (c.DelCourse())
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTabEdit();
                    btnRefresh_Click(sender, e); // Tự động làm mới bảng
                }
                else
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTabEdit()
        {
            txtEditMa.Clear();
            txtEditTen.Clear();
            nudEditSotc.Value = 0;
            nudEditTuan.Value = 0;
            nudEditHky.Value = 0;
            txtEditMota.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt = Course.GetAllCourses();
            dgvCourse.DataSource = dt;
        }

        // =========================================================================
        // 🚀 CÁC TÍNH NĂNG MỚI BỔ SUNG (TÌM KIẾM & LỌC TRÊN DATAGRIDVIEW)
        // =========================================================================

        // Sự kiện cho nút Tìm kiếm trên bảng (btnSearchList)
        private void btnSearchList_Click(object sender, EventArgs e)
        {
            if (txtSearchList == null) return; // Tránh lỗi nếu chưa tạo control

            string keyword = txtSearchList.Text.Trim();
            try
            {
                My_DB db = new My_DB();
                string query = "SELECT MaMH as 'Mã Môn', TenMH as 'Tên Môn', SoTC as 'Số TC', Tuan as 'Số Tuần', Hky as 'Học Kỳ' " +
                               "FROM Course WHERE MaMH LIKE @key OR TenMH LIKE @key";

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvCourse.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Sự kiện lọc dữ liệu theo ComboBox (cboFilterSemester)
        private void cboFilterSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilterSemester.SelectedItem == null) return;

            string selectedSemester = cboFilterSemester.SelectedItem.ToString();

            // Nếu người dùng chọn xem tất cả
            if (selectedSemester == "Tất cả" || selectedSemester == "All")
            {
                btnRefresh_Click(sender, e);
                return;
            }

            try
            {
                My_DB db = new My_DB();
                string query = "SELECT MaMH as 'Mã Môn', TenMH as 'Tên Môn', SoTC as 'Số TC', Tuan as 'Số Tuần', Hky as 'Học Kỳ' " +
                               "FROM Course WHERE Hky = @hky";

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@hky", selectedSemester);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvCourse.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc học kỳ: " + ex.Message);
            }
        }

        // =========================================================================

        private void tabPage2_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }

        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchList_TextChanged(object sender, EventArgs e)
        {

        }
    }
}