using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ManageCourse : Form
    {
        public f_ManageCourse()
        {
            InitializeComponent();
 
            RegisterRealTimeValidation();
        }

        private void VeBoGocPanel(Panel pnl, int radius, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(pnl.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(pnl.Width - radius, pnl.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, pnl.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            pnl.Region = new Region(path);
        }

        private void f_ManageCourse_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void RegisterRealTimeValidation()
        {

            txtAddMa.TextChanged += (s, e) => {
                string text = txtAddMa.Text.Trim();
                if (string.IsNullOrEmpty(text))
                {
                    erpCourse.SetError(txtAddMa, "Mã môn học không được để trống!");
                }
                else if (text.Length > 10)
                {
                    erpCourse.SetError(txtAddMa, $"Mã môn học quá dài ({text.Length}/10 ký tự)! Vui lòng nhập tối đa 10 ký tự.");
                }
                else
                {
                    erpCourse.SetError(txtAddMa, "");
                }
            };

 
            txtAddTen.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtAddTen.Text.Trim()))
                {
                    erpCourse.SetError(txtAddTen, "Tên môn học không được để trống!");
                }
                else
                {
                    erpCourse.SetError(txtAddTen, "");
                }
            };

      
            nudAddSotc.ValueChanged += (s, e) => {
                if (nudAddSotc.Value <= 0)
                {
                    erpCourse.SetError(nudAddSotc, "Số tín chỉ của môn học phải lớn hơn 0!");
                }
                else
                {
                    erpCourse.SetError(nudAddSotc, "");
                }
            };

       
            nudAddHky.ValueChanged += (s, e) => {
                if (nudAddHky.Value < 1 || nudAddHky.Value > 3)
                {
                    erpCourse.SetError(nudAddHky, "Học kỳ không hợp lệ! Chỉ chấp nhận học kỳ từ 1 đến 3.");
                }
                else
                {
                    erpCourse.SetError(nudAddHky, "");
                }
            };


            txtEditTen.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtEditTen.Text.Trim()))
                {
                    erpCourse.SetError(txtEditTen, "Tên môn học chỉnh sửa không được để trống!");
                }
                else
                {
                    erpCourse.SetError(txtEditTen, "");
                }
            };

         
            nudEditSotc.ValueChanged += (s, e) => {
                if (nudEditSotc.Value <= 0)
                {
                    erpCourse.SetError(nudEditSotc, "Số tín chỉ chỉnh sửa phải lớn hơn 0!");
                }
                else
                {
                    erpCourse.SetError(nudEditSotc, "");
                }
            };

        
            nudEditHky.ValueChanged += (s, e) => {
                if (nudEditHky.Value < 1 || nudEditHky.Value > 3)
                {
                    erpCourse.SetError(nudEditHky, "Học kỳ chỉnh sửa chỉ chấp nhận từ 1 đến 3!");
                }
                else
                {
                    erpCourse.SetError(nudEditHky, "");
                }
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            if (!string.IsNullOrEmpty(erpCourse.GetError(txtAddMa)) ||
                !string.IsNullOrEmpty(erpCourse.GetError(txtAddTen)) ||
                !string.IsNullOrEmpty(erpCourse.GetError(nudAddSotc)) ||
                !string.IsNullOrEmpty(erpCourse.GetError(nudAddHky)))
            {
                MessageBox.Show("Không thể thêm môn học!\nVui lòng điều chỉnh lại toàn bộ các vùng nhập liệu đang bị báo lỗi đỏ.",
                                "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                btnRefresh_Click(sender, e);
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
            nudAddSotc.Value = 1;
            nudAddTuan.Value = 1;
            nudAddHky.Value = 1;
            txtAddMota.Clear();
            if (erpCourse != null) erpCourse.Clear(); 
        }

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

              
                if (erpCourse != null)
                {
                    erpCourse.SetError(txtEditTen, "");
                    erpCourse.SetError(nudEditSotc, "");
                    erpCourse.SetError(nudEditHky, "");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditMa.Text)) return;

         
            if (!string.IsNullOrEmpty(erpCourse.GetError(txtEditTen)) ||
                !string.IsNullOrEmpty(erpCourse.GetError(nudEditSotc)) ||
                !string.IsNullOrEmpty(erpCourse.GetError(nudEditHky)))
            {
                MessageBox.Show("Không thể cập nhật môn học!\nVui lòng sửa lại các vùng thông tin đang bị báo lỗi đỏ.",
                                "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEditTen.Text))
            {
                MessageBox.Show("Tên môn học không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((int)nudEditSotc.Value <= 0)
            {
                MessageBox.Show("Số tín chỉ chỉnh sửa phải lớn hơn 0!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((int)nudEditHky.Value < 1 || (int)nudEditHky.Value > 3)
            {
                MessageBox.Show("Học kỳ chỉnh sửa phải từ 1 đến 3!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                ClearTabEdit();
                btnRefresh_Click(sender, e);
            }
            else
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string ma = txtEditMa.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma)) return;

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
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Xóa môn học '{ma}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Course c = new Course { Mamh = ma };
                if (c.DelCourse())
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTabEdit();
                    btnRefresh_Click(sender, e);
                }
                else
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTabEdit()
        {
            txtEditMa.Clear();
            txtEditTen.Clear();
            nudEditSotc.Value = 1;
            nudEditTuan.Value = 1;
            nudEditHky.Value = 1;
            txtEditMota.Clear();
            if (erpCourse != null)
            {
      
                erpCourse.SetError(txtEditTen, "");
                erpCourse.SetError(nudEditSotc, "");
                erpCourse.SetError(nudEditHky, "");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt = Course.GetAllCourses();
            dgvCourse.DataSource = dt;

            if (dgvCourse.Columns["MaMH"] != null) dgvCourse.Columns["MaMH"].HeaderText = "Mã Môn Học";
            if (dgvCourse.Columns["TenMH"] != null) dgvCourse.Columns["TenMH"].HeaderText = "Tên Môn Học";
            if (dgvCourse.Columns["SoTC"] != null) dgvCourse.Columns["SoTC"].HeaderText = "Số Tín Chỉ";
            if (dgvCourse.Columns["Tuan"] != null) dgvCourse.Columns["Tuan"].HeaderText = "Số Tuần Học";
            if (dgvCourse.Columns["Hky"] != null) dgvCourse.Columns["Hky"].HeaderText = "Học Kỳ";
            if (dgvCourse.Columns["Mota"] != null) dgvCourse.Columns["Mota"].HeaderText = "Mô Tả Môn Học";
        }

        private void btnSearchList_Click(object sender, EventArgs e)
        {
            if (txtSearchList == null) return;

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

        private void cboFilterSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilterSemester.SelectedItem == null) return;

            string selectedSemester = cboFilterSemester.SelectedItem.ToString().Trim();

            if (selectedSemester == "Tất cả" || selectedSemester == "All" || string.IsNullOrEmpty(selectedSemester))
            {
                btnRefresh_Click(sender, e);
                return;
            }

            try
            {
                if (int.TryParse(selectedSemester, out int hkyValue))
                {
                    My_DB db = new My_DB();
                    string query = "SELECT MaMH as 'Mã Môn', TenMH as 'Tên Môn', SoTC as 'Số TC', Tuan as 'Số Tuần', Hky as 'Học Kỳ' " +
                                   "FROM Course WHERE Hky = @hky";

                    SqlCommand cmd = new SqlCommand(query, db.getConnection);
                    cmd.Parameters.AddWithValue("@hky", hkyValue);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvCourse.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi bộ lọc học kỳ: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtSearchList_TextChanged(object sender, EventArgs e) { }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;
            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            btnBack_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnBack_Click(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(panel1, 25, e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(panel3, 25, e);
        }
    }
}