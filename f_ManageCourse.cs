using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

            Course course = new Course();
            course.Mamh = txtAddMa.Text.Trim();
            course.Tenmh = txtAddTen.Text.Trim();
            course.Tuan = (int)nudAddTuan.Value; 
            course.Hocky = (int)nudAddHky.Value;   
            course.Decription = txtAddMota.Text.Trim();

            if (checkCoursName(course.Tenmh))
            {
                MessageBox.Show("Tên môn học đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((int)nudAddTuan.Value < 10)
            {
                MessageBox.Show("Số Tuần Học Không Hợp Lệ (tối thiểu 10)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nudAddSotc.Value.ToString().All(char. IsDigit) && verif())
            {
                course.Sotc = (int)nudAddSotc.Value;

                if (course.AddCourse())
                {
                    MessageBox.Show("Thêm khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTabAdd();
                    btnRefresh_Click(sender, e);
                }
                else
                {

                    MessageBox.Show("Lỗi: " + (course.Exception ?? "Mã môn học có thể đã tồn tại."), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        bool checkCoursName(string name)
        {
            Course course = new Course();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE TenMH LIKE @name");
            cmd.Parameters.AddWithValue("@name", name);

            DataTable dt = course.getCourse(cmd);
            return dt != null && dt.Rows.Count > 0;
        }

        bool verif()
        {
            if (string.IsNullOrWhiteSpace(txtAddMa.Text) ||
                string.IsNullOrWhiteSpace(txtAddTen.Text) ||
                string.IsNullOrWhiteSpace(txtAddMota.Text))
            {
                return false;
            }
            return true;
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

        private async void btnAISuggest_Click(object sender, EventArgs e)
        {
            string tenMon = txtAddTen.Text.Trim();
            int soTC = (int)nudAddSotc.Value;

            // 1. Chặn nếu người dùng lười chưa gõ tên môn mà đã đòi gọi AI
            if (string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show("Ní ơi, vui lòng nhập Tên môn học vào trước thì AI mới phân tích được chứ!",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddTen.Focus();
                return;
            }

            // 2. Chuyển giao diện sang trạng thái chờ
            txtAddMota.Text = "🤖 Trợ lý AI đang tiến hành phân tích đề cương đào tạo chuẩn CDIO, ní đợi vài giây nhé...";
            btnAISuggest.Enabled = false; // Khóa nút lại để người dùng không bấm liên tục làm treo lệnh

            // 3. Xây dựng câu Prompt "ép" ChatGPT phải trả về đúng cấu trúc từ khóa cố định
            // Việc ép cấu trúc giúp C# lát nữa dùng lệnh cắt chuỗi (Split) phân bổ vào đúng ô cực kỳ dễ dàng
            string prompt = $"Hãy phân tích môn học mang tên '{tenMon}' hiện đang thiết lập {soTC} tín chỉ theo chuẩn khung CDIO. " +
                            $"Yêu cầu bạn tính toán đưa ra đề xuất số tuần học phù hợp (môn nặng thực hành hoặc đồ án thì tuần dài hơn). " +
                            $"Hãy trả về câu trả lời duy nhất khớp chính xác theo cấu trúc 3 dòng sau đây, không viết thêm lời chào hay giải thích gì khác:\n" +
                            $"Tuan: [Chỉ ghi một con số nguyên số tuần từ 10 đến 15]\n" +
                            $"Mota: [Ghi 3-4 câu mô tả đề cương môn học ngắn gọn, chuyên nghiệp, nêu rõ chuẩn đầu ra kiến thức kỹ năng đạt được]";

            // 4. Gọi lệnh chạy ngầm bắn lên OpenAI (Chờ phản hồi mà không gây đơ giao diện nhờ từ khóa await)
            string aiResult = await AIService.AskChatGPTAsync(prompt);

            // 5. Tiếp nhận chuỗi phản hồi từ AI và bóc tách dữ liệu đổ lên Form
            try
            {
                // Cắt toàn bộ văn bản trả về thành các dòng dựa vào ký tự xuống dòng '\n'
                string[] lines = aiResult.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                string s_tuan = "";
                string s_mota = "";

                foreach (string line in lines)
                {
                    // Nếu dòng bắt đầu bằng chữ Tuan: thì cắt lấy phần số phía sau
                    if (line.StartsWith("Tuan:"))
                        s_tuan = line.Replace("Tuan:", "").Trim();

                    // Nếu dòng bắt đầu bằng chữ Mota: thì cắt lấy đoạn mô tả văn bản
                    if (line.StartsWith("Mota:"))
                        s_mota = line.Replace("Mota:", "").Trim();
                }

                // 6. Đổ dữ liệu thông minh vừa bóc tách ngược lại các linh kiện trên giao diện

                // Đổ số tuần đề xuất vào NumericUpDown ô số tuần học
                if (!string.IsNullOrEmpty(s_tuan) && int.TryParse(s_tuan, out int soTuanDeXuat))
                {
                    // Ràng buộc bảo vệ: Nếu số tuần học AI đề xuất hợp lệ >= 10 thì mới gán
                    if (soTuanDeXuat >= 10 && soTuanDeXuat <= 20)
                    {
                        nudAddTuan.Value = soTuanDeXuat;
                    }
                }

                // Đổ văn bản mô tả vào ô RichTextBox/TextBox Mô tả chương trình môn học
                if (!string.IsNullOrEmpty(s_mota))
                {
                    txtAddMota.Text = s_mota;
                }
                else
                {
                    // Phòng hờ trường hợp AI không trả về đúng cấu trúc, ta ném toàn bộ văn bản thô vào ô mô tả cho người dùng tự xem
                    txtAddMota.Text = aiResult;
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi bóc tách ngoài ý muốn, hiển thị nguyên văn chuỗi AI phản hồi
                txtAddMota.Text = "[Lỗi xử lý chuỗi chữ của AI]: " + ex.Message + "\n\nKẾT QUẢ GỐC:\n" + aiResult;
            }
            finally
            {
                // 7. Hoàn tất quá trình, mở khóa lại nút bấm để sử dụng cho môn tiếp theo
                btnAISuggest.Enabled = true;
            }
        }
    }
}