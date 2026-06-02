using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_RegisterCourse : Form
    {
        private My_DB db = new My_DB();

        public f_RegisterCourse()
        {
            InitializeComponent();
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

        // 5.3 Sự kiện Load: Đồng bộ nạp dữ liệu danh sách SV cho CẢ 2 ô ComboBox ở 2 Tab
        private void f_RegisterCourse_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 244, 247);

            // 1. Gọi hàm nạp song song dữ liệu lên cboStudent (Tab 1) và comboBox2 (Tab 2)
            LoadStudentsToComboBox();

            // 2. Thiết lập chọn sẵn Học kỳ 1 làm mặc định ban đầu nếu có dữ liệu Items
            if (cboHky.Items.Count > 0)
            {
                cboHky.SelectedIndex = 0;
            }

            // 3. Nạp dữ liệu mặc định ban đầu cho cả 2 Tab nếu ComboBox đã sẵn sàng
            if (cboStudent.SelectedValue != null && cboHky.SelectedItem != null &&
                cboStudent.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                HienThiMonHocChuaDangKy();
            }
            if (comboBox2.SelectedValue != null && comboBox2.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                TaiDanhSachMonDaDangKy();
            }

        }

        // ✨ ĐỒNG BỘ: Nạp danh sách Sinh viên lên CẢ HAI ComboBox độc lập
        private void LoadStudentsToComboBox()
        {
            try
            {
                string query = "SELECT MSSV, Lname + ' ' + Fname AS Hoten FROM Student";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Nạp cho ô cboStudent (Của Tab 1)
                DataTable table1 = new DataTable();
                adapter.Fill(table1);
                cboStudent.DataSource = table1;
                cboStudent.DisplayMember = "Hoten";
                cboStudent.ValueMember = "MSSV";

                // Nạp cho ô comboBox2 (Của Tab 2)
                DataTable table2 = new DataTable();
                adapter.Fill(table2);
                comboBox2.DataSource = table2;
                comboBox2.DisplayMember = "Hoten";
                comboBox2.ValueMember = "MSSV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên lên các ComboBox: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🌟 CHỨC NĂNG CHÍNH ĐĂNG KÝ (Tab 1): Lấy mã SV từ cboStudent để chạy SQL EXCEPT loại trừ môn
        private void HienThiMonHocChuaDangKy()
        {
            if (cboStudent.SelectedValue == null || cboHky.SelectedItem == null ||
                cboStudent.SelectedValue.ToString() == "System.Data.DataRowView") return;

            lstBandau.Items.Clear();
            string selectedMSSV = cboStudent.SelectedValue.ToString().Trim();
            int selectedHky = int.Parse(cboHky.SelectedItem.ToString());

            string sql = "(SELECT MaMH FROM Course WHERE Hky = @hky)" +
                         " EXCEPT " +
                         "(SELECT MaMH FROM DKMH WHERE MSSV = @mssv)";

            try
            {
                SqlCommand cmd = new SqlCommand(sql, db.getConnection);
                cmd.Parameters.AddWithValue("@hky", selectedHky);
                cmd.Parameters.AddWithValue("@mssv", selectedMSSV);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstBandau.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi dữ liệu loại trừ EXCEPT ở Tab 1: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CapNhatTongTinChi();
        }

        // ⚡ SỰ KIỆN TAB 1: Khi chọn sinh viên khác trên cboStudent (Tab 1)
        private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboStudent.SelectedValue.ToString() == "System.Data.DataRowView") return;

            lstKetqua.Items.Clear();
            HienThiMonHocChuaDangKy();
        }

        private void cboHky_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstKetqua.Items.Clear();
            HienThiMonHocChuaDangKy();
        }


        #region 🔄 LOGIC ĐIỀU KHIỂN ĐIỀU HƯỚNG 4 NÚT LUÂN CHUYỂN DUAL LISTBOX

        private void btnMoveSelected_Click(object sender, EventArgs e)
        {
            if (lstBandau.SelectedItem != null)
            {
                string item = lstBandau.SelectedItem.ToString();
                lstKetqua.Items.Add(item);
                lstBandau.Items.Remove(item);
                CapNhatTongTinChi();
            }
        }

        private void btnMoveAll_Click(object sender, EventArgs e)
        {
            foreach (var item in lstBandau.Items)
            {
                lstKetqua.Items.Add(item);
            }
            lstBandau.Items.Clear();
            CapNhatTongTinChi();
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            if (lstKetqua.SelectedItem != null)
            {
                string item = lstKetqua.SelectedItem.ToString();
                lstBandau.Items.Add(item);
                lstKetqua.Items.Remove(item);
                CapNhatTongTinChi();
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            foreach (var item in lstKetqua.Items)
            {
                lstBandau.Items.Add(item);
            }
            lstKetqua.Items.Clear();
            CapNhatTongTinChi();
        }

        #endregion


        #region 🔧 CHỨC NĂNG NÂNG CAO TRIỂN KHAI TRÊN LISTBOX VÀ HẠN MỨC TC

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox currentListBox = (ListBox)sender;
            if (currentListBox.SelectedItem == null) return;

            string maMH = currentListBox.SelectedItem.ToString();

            Course courseInstance = new Course();
            DataTable dt = courseInstance.GetCourseByMa(maMH);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                lblChiTietMon.Text = $"📖 Môn học: {r["TenMH"]}\r\n" +
                                     $"🔹 Số tín chỉ: {r["SoTC"]} TC\r\n" +
                                     $"⏱️ Thời lượng: {r["Tuan"]} tuần";
            }
        }

        private void lstBandau_SelectedIndexChanged(object sender, EventArgs e) => lst_SelectedIndexChanged(sender, e);
        private void lstKetqua_SelectedIndexChanged(object sender, EventArgs e) => lst_SelectedIndexChanged(sender, e);

        private int TinhTongTinChiChonDangKy()
        {
            int tongTC = 0;
            foreach (var item in lstKetqua.Items)
            {
                Course courseInstance = new Course();
                DataTable dt = courseInstance.GetCourseByMa(item.ToString());

                if (dt != null && dt.Rows.Count > 0)
                {
                    tongTC += Convert.ToInt32(dt.Rows[0]["SoTC"]);
                }
            }
            return tongTC;
        }

        private void CapNhatTongTinChi()
        {
            int tong = TinhTongTinChiChonDangKy();
            lblTongTC.Text = $"Tổng số tín chỉ đã chọn: {tong} / 24 TC";

            if (tong > 24)
                lblTongTC.ForeColor = Color.Red;
            else
                lblTongTC.ForeColor = Color.DarkGreen;
        }

        #endregion


        // 🌟 CHỨC NĂNG LƯU ĐĂNG KÝ MÔN HỌC (Sử dụng cboStudent của Tab 1)
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || lstKetqua.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn Sinh viên và nhặt các Môn học cần đăng ký vào giỏ hàng kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mssv = cboStudent.SelectedValue.ToString().Trim();

            int tongTC = TinhTongTinChiChonDangKy();
            if (tongTC > 24)
            {
                MessageBox.Show($"Lưu dữ liệu thất bại! Tổng số tín chỉ ní lựa chọn đang là {tongTC} TC, đã vượt giới hạn tối đa cho phép của một học kỳ (Tối đa 24 TC).",
                                "Vượt quá hạn mức học kỳ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool flag = true;
            try
            {
                db.openConnection();

                for (int i = 0; i < lstKetqua.Items.Count; i++)
                {
                    string maMH = lstKetqua.Items[i].ToString();

                    string insertQuery = "INSERT INTO DKMH (MSSV, MaMH) VALUES (@mssv, @mamh)";
                    SqlCommand cmdInsert = new SqlCommand(insertQuery, db.conn);
                    cmdInsert.Parameters.AddWithValue("@mssv", mssv);
                    cmdInsert.Parameters.AddWithValue("@mamh", maMH);

                    if (cmdInsert.ExecuteNonQuery() <= 0)
                    {
                        flag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                flag = false;
                MessageBox.Show("Đã xảy ra sự cố trong quá trình lưu dữ liệu: " + ex.Message, "Lỗi truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }

            if (flag)
            {
                MessageBox.Show("Chúc mừng ní! Đã thực hiện Đăng Ký Môn Học Thành Công!", "Thành công tốt đẹp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstKetqua.Items.Clear();
                HienThiMonHocChuaDangKy(); // Làm mới kho môn chưa đăng ký ở Tab 1
                TaiDanhSachMonDaDangKy();   // Tự động quét cập nhật bảng DataGridView bên Tab 2 luôn
            }
            else
            {
                MessageBox.Show("Thao tác đăng ký thất bại! Vui lòng kiểm tra lại cấu trúc hệ thống.", "Lỗi thực thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 🌟 NÂNG CAO [AI]: Kết nối Trợ lý AI Gemini (Dùng cboStudent của Tab 1)
        private async void btn_AIExtra_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null) return;
            string mssv = cboStudent.SelectedValue.ToString().Trim();

            lblChiTietMon.Text = "🤖 Trợ lý AI Gemini đang phân tích bảng điểm lịch sử quá khứ của ní, đợi vài giây nhé...";
            btn_AIExtra.Enabled = false;

            string lichSuDiem = "";
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT MaMH, Score FROM Score WHERE MSSV = @mssv", db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    lichSuDiem += $"Môn: {r["MaMH"]} - Điểm: {r["Score"]}; ";
                }
                db.closeConnection();
            }
            catch { }

            if (string.IsNullOrEmpty(lichSuDiem)) lichSuDiem = "Sinh viên năm nhất, chưa ghi nhận lịch sử điểm số môn cũ.";
            string cacMonHocKyNayOpen = string.Join(", ", lstBandau.Items.Cast<string>());

            string prompt = $"Sinh viên mang MSSV {mssv} có lịch sử điểm học tập các học phần cũ là: {lichSuDiem}. " +
                            $"Học kỳ hiện tại hệ thống đang mở các môn học sau: {cacMonHocKyNayOpen}. " +
                            $"Dựa vào triết lý thiết kế chương trình đào tạo kỹ thuật chuẩn CDIO quốc tế, hãy đưa ra 1 lời khuyên ngắn gọn (tối đa 3 dòng) " +
                            $"tư vấn định hướng sinh viên này nên ưu tiên click chọn đăng ký học môn nào trước trong danh sách môn mở của học kỳ này.";

            string aiGoiY = await AIService.AskChatGPTAsync(prompt);

            lblChiTietMon.Text = $"🤖 [AI TƯ VẤN LỘ TRÌNH ĐÀO TẠO]:\r\n\r\n{aiGoiY}";
            btn_AIExtra.Enabled = true;
        }


        #region 📋 LOGIC XỬ LÝ TAB 2 - MÔN ĐÃ ĐĂNG KÝ (Sử dụng comboBox2 riêng biệt của Tab 2)

        // 🛠️ Hàm load bảng lấy mã SV trực tiếp từ comboBox2 (Tab 2)
        private void TaiDanhSachMonDaDangKy()
        {
            if (comboBox2.SelectedValue == null || comboBox2.SelectedValue.ToString() == "System.Data.DataRowView") return;

            string mssv = comboBox2.SelectedValue.ToString().Trim();

            string query = "SELECT d.MaMH as 'Mã Môn', c.TenMH as 'Tên Môn Học', c.SoTC as 'Số Tín Chỉ' " +
                           "FROM DKMH d JOIN Course c ON d.MaMH = c.MaMH " +
                           "WHERE d.MSSV = @mssv";

            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (dgvDaDangKy != null)
                {
                    dgvDaDangKy.DataSource = table;
                    dgvDaDangKy.BackgroundColor = Color.White;
                    dgvDaDangKy.BorderStyle = BorderStyle.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống khi tải danh sách môn đã đăng ký ở Tab 2: " + ex.Message, "Lỗi SQL");
            }
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null || comboBox2.SelectedValue.ToString() == "System.Data.DataRowView") return;

            TaiDanhSachMonDaDangKy(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue == null || dgvDaDangKy.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng nhấp chọn một dòng môn học trong bảng dưới đây để hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mssv = comboBox2.SelectedValue.ToString().Trim();
            string mamh = dgvDaDangKy.CurrentRow.Cells["Mã Môn"].Value.ToString().Trim();
            string tenmh = dgvDaDangKy.CurrentRow.Cells["Tên Môn Học"].Value.ToString().Trim();

            try
            {
                db.openConnection();

                // 🌟 ĐÃ SỬA CHUẨN: Đổi thành 'Course_ID' trùng khớp hoàn toàn với bảng Score trong SQL Server của ní
                string checkScoreQuery = "SELECT COUNT(*) FROM Score WHERE MSSV = @mssv AND Course_ID = @mamh";
                SqlCommand cmdCheck = new SqlCommand(checkScoreQuery, db.conn);
                cmdCheck.Parameters.AddWithValue("@mssv", mssv);
                cmdCheck.Parameters.AddWithValue("@mamh", mamh);

                int hasScore = Convert.ToInt32(cmdCheck.ExecuteScalar());

                // Nếu kết quả > 0 nghĩa là đã có điểm lưu trong DB -> Khóa xích chặn đứng, cấm hủy!
                if (hasScore > 0)
                {
                    MessageBox.Show($"Không thể hủy học phần! Môn học [{tenmh}] của sinh viên này đã được nhập điểm vào hệ thống dữ liệu. Không được phép chỉnh sửa hoặc xóa học phần đã hoàn thành!",
                                    "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; // Ngắt hàm luôn
                }

                // Nếu kiểm tra an toàn (chưa có điểm), tiến hành hỏi xác nhận và xóa khỏi bảng DKMH
                DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn HỦY đăng ký học phần [{tenmh}] ({mamh}) không?",
                                                  "Xác nhận hủy đăng ký", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM DKMH WHERE MSSV = @mssv AND MaMH = @mamh";
                    SqlCommand cmdDel = new SqlCommand(deleteQuery, db.conn);
                    cmdDel.Parameters.AddWithValue("@mssv", mssv);
                    cmdDel.Parameters.AddWithValue("@mamh", mamh);

                    if (cmdDel.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show($"Đã hủy đăng ký thành công môn học [{tenmh}]!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật làm mới lại giao diện hiển thị cả 2 Tab
                        TaiDanhSachMonDaDangKy();
                        HienThiMonHocChuaDangKy();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình xác thực điểm số và hủy môn: " + ex.Message, "Lỗi hệ thống");
            }
            finally
            {
                db.closeConnection();
            }
        }

        #endregion

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;
            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;
            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();
            this.Close();
        }
    }
}