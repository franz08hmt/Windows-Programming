using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace QuanLySinhVien
{
    public partial class f_RegisterCourse : UserControl
    {
        private My_DB db = new My_DB();
        private readonly string geminiApiKey = "Đừng push API lên git nhen"; // Dùng lại key hiện tại

        public f_RegisterCourse()
        {
            InitializeComponent();
            this.SizeChanged += new EventHandler(f_RegisterCourse_SizeChanged);
        }

        private void f_RegisterCourse_Load(object sender, EventArgs e)
        {
            Load_Danh_Sach_Sinh_Vien();
            btnAISuggest.Click += new EventHandler(btnAISuggest_Click_1_Handler);
            btnAICheckConflict.Click += new EventHandler(btnAICheckConflict_Click_Handler);
            AdjustLayout();
        }

        // Tái bố cục động khi form resize: 2 listbox lấp đầy chiều rộng, panel arrows ở giữa
        private void f_RegisterCourse_SizeChanged(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int margin = 8;
            int arrowW = 150;    // chiều rộng panel mũi tên
            int totalW = this.Width;

            // Mỗi list chiếm nửa (trừ arrows + margins)
            int listW = (totalW - arrowW - margin * 4) / 2;
            if (listW < 100) return;

            int listH = Math.Max(120, (int)(this.Height * 0.26)); // ~26% chiều cao

            // Vị trí X
            int xLeft  = margin;
            int xArrow = xLeft + listW + margin;
            int xRight = xArrow + arrowW + margin;

            // --- Row 1: Labels ---
            int yLabel = lblBandau.Top;
            lblBandau.SetBounds(xLeft, yLabel, listW, lblBandau.Height);
            lblKetqua.SetBounds(xRight, yLabel, listW, lblKetqua.Height);

            // --- Row 2: ListBoxes + Arrow panel ---
            int yList = lblBandau.Bottom + 4;
            lstBandau.SetBounds(xLeft,  yList, listW,  listH);
            panel1.SetBounds(xArrow, yList, arrowW, listH);
            lstKetqua.SetBounds(xRight, yList, listW,  listH);

            // --- Row 3: lblMonInfo (dưới lstBandau) ---
            int yInfo = yList + listH + 4;
            lblMonInfo.SetBounds(xLeft, yInfo, listW + arrowW + margin * 2, lblMonInfo.Height);

            // --- Row 4: Buttons ---
            int btnY = yInfo + lblMonInfo.Height + 6;
            int btnW = 190;
            int btnH = 52;
            int btnGap = (totalW - margin * 2 - btnW * 5) / 4;
            if (btnGap < 8) btnGap = 8;

            btnRegister.SetBounds(margin, btnY, btnW, btnH);
            btnUnregister.SetBounds(btnRegister.Right + btnGap, btnY, btnW, btnH);
            btnSendRequest.SetBounds(btnUnregister.Right + btnGap, btnY, btnW, btnH);
            btnAISuggest.SetBounds(btnSendRequest.Right + btnGap, btnY, btnW, btnH);
            btnAICheckConflict.SetBounds(btnAISuggest.Right + btnGap, btnY, btnW, btnH);

            // --- Row 5: label "Danh sách môn đã đăng ký" ---
            int yLabel4 = btnY + btnH + 8;
            label4.SetBounds(margin, yLabel4, 400, label4.Height);

            // --- Row 6: DataGrid ---
            int yDgv = yLabel4 + label4.Height + 4;
            int dgvH = Math.Max(100, this.Height - yDgv - margin * 2);
            dgvRegisterList.SetBounds(margin, yDgv, totalW - margin * 2, dgvH);
        }

        private void Load_Danh_Sach_Sinh_Vien()
        {
            try
            {
                string query = "SELECT MSSV, Fname, Lname FROM Student ORDER BY Lname";
                SqlDataAdapter da = new SqlDataAdapter(query, db.getConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                VietnameseTextHelper.NormalizeColumns(dt, "Fname", "Lname");

                if (!dt.Columns.Contains("HoTen"))
                {
                    dt.Columns.Add("HoTen", typeof(string));
                }

                foreach (DataRow row in dt.Rows)
                {
                    row["HoTen"] = row["Fname"].ToString() + " " + row["Lname"].ToString();
                }

                cboStudent.DataSource = dt;
                cboStudent.DisplayMember = "HoTen";
                cboStudent.ValueMember = "MSSV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên: " + ex.Message, "Lỗi");
            }
        }

        private void Load_lstBandau()
        {
            if (cboStudent.SelectedValue == null || cboStudent.SelectedValue is DataRowView) return;
            try
            {
                string mssv = cboStudent.SelectedValue.ToString();
                string query =
                    "SELECT MaMH, MaMH + ' - ' + TenMH AS TenMon FROM Course " +
                    "EXCEPT " +
                    "SELECT c.MaMH, c.MaMH + ' - ' + c.TenMH " +
                    "FROM Course c INNER JOIN Score s ON c.MaMH = s.MaMH WHERE s.MSSV = @mssv";

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lstBandau.Items.Clear();
                lstKetqua.Items.Clear();
                lblMonInfo.Text = "← Chọn môn để xem thông tin";

                foreach (DataRow row in dt.Rows)
                    lstBandau.Items.Add(row["TenMon"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải môn học: " + ex.Message, "Lỗi");
            }
        }

        private void Load_Mon_Hoc_Da_Dang_Ky()
        {
            if (cboStudent.SelectedValue == null || cboStudent.SelectedValue is DataRowView) return;
            try
            {
                string mssv = cboStudent.SelectedValue.ToString();
                string query =
                    "SELECT s.MaMH AS [Mã Môn], c.TenMH AS [Tên Môn Học], c.SoTC AS [Số Tín Chỉ] " +
                    "FROM Score s INNER JOIN Course c ON s.MaMH = c.MaMH WHERE s.MSSV = @mssv";

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRegisterList.DataSource = dt;
            }
            catch { }
        }

        private void cboStudent_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Load_lstBandau();
            Load_Mon_Hoc_Da_Dang_Ky();
        }

        // ===================================================================
        // 4 NÚT DUAL LISTBOX
        // ===================================================================
        private void btnMoveOne_Click_1(object sender, EventArgs e)
        {
            if (lstBandau.SelectedItem == null) return;
            lstKetqua.Items.Add(lstBandau.SelectedItem);
            lstBandau.Items.Remove(lstBandau.SelectedItem);
        }

        private void btnMoveAll_Click_1(object sender, EventArgs e)
        {
            foreach (var item in lstBandau.Items)
                lstKetqua.Items.Add(item);
            lstBandau.Items.Clear();
        }

        private void btnRemoveOne_Click_1(object sender, EventArgs e)
        {
            if (lstKetqua.SelectedItem == null) return;
            lstBandau.Items.Add(lstKetqua.SelectedItem);
            lstKetqua.Items.Remove(lstKetqua.SelectedItem);
        }

        private void btnRemoveAll_Click_1(object sender, EventArgs e)
        {
            foreach (var item in lstKetqua.Items)
                lstBandau.Items.Add(item);
            lstKetqua.Items.Clear();
        }

        // ===================================================================
        // HIỂN THỊ THÔNG TIN MÔN KHI CHỌN (nâng cao)
        // ===================================================================
        private void lstBandau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBandau.SelectedItem == null) return;
            string maMH = lstBandau.SelectedItem.ToString()
                .Split(new string[] { " - " }, StringSplitOptions.None)[0].Trim();
            HienThiThongTinMon(maMH);
        }

        private void lstKetqua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKetqua.SelectedItem == null) return;
            string maMH = lstKetqua.SelectedItem.ToString()
                .Split(new string[] { " - " }, StringSplitOptions.None)[0].Trim();
            HienThiThongTinMon(maMH);
        }

        private void HienThiThongTinMon(string maMH)
        {
            try
            {
                My_DB tempDb = new My_DB();
                tempDb.openConnection();
                string query = "SELECT TenMH, SoTC, Tuan, Hky FROM Course WHERE MaMH = @mamh";
                SqlCommand cmd = new SqlCommand(query, tempDb.conn);
                cmd.Parameters.AddWithValue("@mamh", maMH);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                tempDb.closeConnection();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblMonInfo.Text =
                        $"📚 {row["TenMH"]}  |  " +
                        $"Số TC: {row["SoTC"]}  |  " +
                        $"Số tuần: {row["Tuan"]}  |  " +
                        $"Học kỳ: {row["Hky"]}";
                }
            }
            catch { }
        }

        // ===================================================================
        // TÍNH TỔNG TC (nâng cao)
        // ===================================================================
        private int TinhTongTC()
        {
            int tongTC = 0;

            foreach (var item in lstKetqua.Items)
            {
                string maMH = item.ToString()
                    .Split(new string[] { " - " }, StringSplitOptions.None)[0].Trim();
                try
                {
                    My_DB tempDb = new My_DB();
                    tempDb.openConnection();
                    SqlCommand cmd = new SqlCommand("SELECT SoTC FROM Course WHERE MaMH = @mamh", tempDb.conn);
                    cmd.Parameters.AddWithValue("@mamh", maMH);
                    object result = cmd.ExecuteScalar();
                    tempDb.closeConnection();
                    if (result != null && result != DBNull.Value)
                        tongTC += Convert.ToInt32(result);
                }
                catch { }
            }

            foreach (DataGridViewRow row in dgvRegisterList.Rows)
            {
                if (row.IsNewRow) continue;
                object soTC = row.Cells["Số Tín Chỉ"].Value;
                if (soTC != null && soTC != DBNull.Value)
                    tongTC += Convert.ToInt32(soTC);
            }

            return tongTC;
        }

        // ===================================================================
        // LƯU ĐĂNG KÝ
        // ===================================================================
        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboStudent.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Thông báo");
                return;
            }
            if (lstKetqua.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một môn học để đăng ký!", "Thông báo");
                return;
            }

            int tongTC = TinhTongTC();
            if (tongTC > 24)
            {
                MessageBox.Show(
                    $"Tổng số tín chỉ đăng ký ({tongTC} TC) vượt quá giới hạn 24 TC/học kỳ!\n" +
                    "Vui lòng bỏ bớt môn học.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mssv = cboStudent.SelectedValue.ToString();
            bool allOk = true;

            try
            {
                db.openConnection();
                foreach (var item in lstKetqua.Items)
                {
                    string maMH = item.ToString()
                        .Split(new string[] { " - " }, StringSplitOptions.None)[0].Trim();
                    string query = "INSERT INTO Score (MSSV, MaMH) VALUES (@mssv, @mamh)";
                    SqlCommand cmd = new SqlCommand(query, db.getConnection);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    cmd.Parameters.AddWithValue("@mamh", maMH);
                    try { cmd.ExecuteNonQuery(); }
                    catch { allOk = false; }
                }
                db.closeConnection();

                if (allOk)
                    MessageBox.Show($"Đăng ký thành công! Tổng {tongTC} tín chỉ.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Một số môn đăng ký thất bại (có thể đã đăng ký trước đó).", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                Load_lstBandau();
                Load_Mon_Hoc_Da_Dang_Ky();
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi đăng ký: " + ex.Message, "Lỗi");
            }
        }

        // ===================================================================
        // HỦY ĐĂNG KÝ
        // ===================================================================
        private void btnUnregister_Click_1(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboStudent.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Thông báo");
                return;
            }
            if (dgvRegisterList.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng click chọn dòng môn học cần hủy!", "Thông báo");
                return;
            }
            try
            {
                string maMH = dgvRegisterList.CurrentRow.Cells["Mã Môn"].Value.ToString();
                db.openConnection();
                string query = "DELETE FROM Score WHERE MSSV = @mssv AND MaMH = @mamh";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@mssv", cboStudent.SelectedValue);
                cmd.Parameters.AddWithValue("@mamh", maMH);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Hủy đăng ký thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_lstBandau();
                    Load_Mon_Hoc_Da_Dang_Ky();
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi hủy đăng ký: " + ex.Message, "Lỗi");
            }
        }

        // ===================================================================
        // CÂU 4 – GỬI REQUEST XÁC NHẬN
        // ===================================================================
        private void btnSendRequest_Click_1(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboStudent.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước khi gửi yêu cầu!", "Thông báo");
                return;
            }

            string mssv = cboStudent.SelectedValue.ToString();

            try
            {
                db.openConnection();
                string checkQuery = "SELECT COUNT(*) FROM StudentRequest WHERE MSSV = @mssv AND Status = 'Pending'";
                SqlCommand checkCmd = new SqlCommand(checkQuery, db.getConnection);
                checkCmd.Parameters.AddWithValue("@mssv", mssv);
                int pendingCount = (int)checkCmd.ExecuteScalar();
                db.closeConnection();

                if (pendingCount > 0)
                {
                    MessageBox.Show("Sinh viên này đã có yêu cầu đang chờ duyệt!\nVui lòng chờ Admin xử lý.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi kiểm tra: " + ex.Message, "Lỗi");
                return;
            }

            try
            {
                db.openConnection();
                string insertQuery =
                    "INSERT INTO StudentRequest (MSSV, RequestDate, Note, Status) " +
                    "VALUES (@mssv, GETDATE(), @note, 'Pending')";
                SqlCommand cmd = new SqlCommand(insertQuery, db.getConnection);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                cmd.Parameters.AddWithValue("@note", "Yêu cầu xác nhận thông tin sinh viên để đăng ký học phần");

                if (cmd.ExecuteNonQuery() == 1)
                    MessageBox.Show("✅ Gửi yêu cầu lên Admin thành công!\nVui lòng chờ phê duyệt.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi gửi yêu cầu: " + ex.Message, "Lỗi");
            }
        }

        // ===================================================================
        // [AI] GỢI Ý MÔN HỌC TỐI ƯU (nâng cao)
        // ===================================================================
        private async void btnAISuggest_Click_1_Handler(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboStudent.SelectedValue is DataRowView)
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lstBandau.Items.Count == 0)
            {
                MessageBox.Show("Không có môn học nào để gợi ý!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAISuggest.Enabled = false;
            btnAISuggest.Text = "⏳ Đang phân tích...";

            try
            {
                string danhSachMon = string.Join(", ", lstBandau.Items.Cast<string>());
                string mssv = cboStudent.SelectedValue.ToString();
                string diemDaHoc = LayDiemDaHoc(mssv);
                string ketQua = await AIGoiYMonHocAsync(danhSachMon, diemDaHoc);

                if (!string.IsNullOrEmpty(ketQua))
                    MessageBox.Show(
                        $"🤖 AI Gợi ý môn học tối ưu:\n\n{ketQua}",
                        "AI Gợi ý lịch học",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("AI không trả về kết quả. Vui lòng thử lại.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối AI: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAISuggest.Enabled = true;
                btnAISuggest.Text = "🤖 AI Gợi ý môn học";
            }
        }

        private string LayDiemDaHoc(string mssv)
        {
            try
            {
                My_DB tempDb = new My_DB();
                tempDb.openConnection();
                string query =
                    "SELECT c.TenMH, s.DiemTK FROM Score s " +
                    "JOIN Course c ON s.MaMH = c.MaMH " +
                    "WHERE s.MSSV = @mssv AND s.DiemTK IS NOT NULL";
                SqlCommand cmd = new SqlCommand(query, tempDb.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                tempDb.closeConnection();

                if (dt.Rows.Count == 0) return "Chưa có điểm môn nào";

                var sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                    sb.Append($"{row["TenMH"]}: {row["DiemTK"]:F1}, ");

                return sb.ToString().TrimEnd(',', ' ');
            }
            catch { return "Không lấy được điểm"; }
        }

        private async Task<string> AIGoiYMonHocAsync(string danhSachMon, string diemDaHoc)
        {
            using (HttpClient client = new HttpClient())
            {
                string prompt =
                    $"Bạn là cố vấn học tập đại học.\n" +
                    $"Sinh viên có điểm các môn đã học: {diemDaHoc}\n" +
                    $"Danh sách môn có thể đăng ký: {danhSachMon}\n" +
                    $"Hãy gợi ý 3-5 môn học phù hợp nhất để đăng ký, " +
                    $"dựa trên kết quả học tập và sự liên quan giữa các môn. " +
                    $"Giải thích ngắn gọn lý do cho mỗi môn. Trả lời bằng tiếng Việt.";

                var payload = new
                {
                    contents = new[]
                    {
                        new { role = "user", parts = new[] { new { text = prompt } } }
                    },
                    generationConfig = new { temperature = 0.7, maxOutputTokens = 400 }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={geminiApiKey}";

                HttpResponseMessage response = await client.PostAsync(url, content);
                string rawResult = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(rawResult)) return null;

                dynamic resultObj = JsonConvert.DeserializeObject(rawResult);

                if (resultObj?.candidates != null &&
                    resultObj.candidates[0]?.content?.parts != null)
                    return resultObj.candidates[0].content.parts[0].text.ToString().Trim();

                if (resultObj?.error != null)
                    throw new Exception(resultObj.error.message.ToString());

                return null;
            }
        }


        private async void btnAICheckConflict_Click_Handler(object sender, EventArgs e)
        {
            if (lstKetqua.Items.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một môn học trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAICheckConflict.Enabled = false;
            btnAICheckConflict.Text = "⏳ Đang kiểm tra...";

            try
            {
                string danhSachMon = await LayThongTinMonHocAsync();

                if (string.IsNullOrEmpty(danhSachMon))
                {
                    MessageBox.Show("Không lấy được thông tin môn học.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string ketQua = await AIKiemTraTrungLichAsync(danhSachMon);

                if (!string.IsNullOrEmpty(ketQua))
                    MessageBox.Show(
                        $"🤖 AI Kiểm tra trùng lịch:\n\n{ketQua}",
                        "AI Cảnh báo trùng lịch",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("AI không trả về kết quả. Vui lòng thử lại.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối AI: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAICheckConflict.Enabled = true;
                btnAICheckConflict.Text = "⚠️ AI Kiểm tra trùng lịch";
            }
        }

        private async Task<string> LayThongTinMonHocAsync()
        {
            var sb = new StringBuilder();
            foreach (var item in lstKetqua.Items)
            {
                string maMH = item.ToString()
                    .Split(new string[] { " - " }, StringSplitOptions.None)[0].Trim();
                try
                {
                    My_DB tempDb = new My_DB();
                    tempDb.openConnection();
                    string query = "SELECT TenMH, Tuan, Hky FROM Course WHERE MaMH = @mamh";
                    SqlCommand cmd = new SqlCommand(query, tempDb.conn);
                    cmd.Parameters.AddWithValue("@mamh", maMH);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    tempDb.closeConnection();

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        sb.Append($"Môn: {row["TenMH"]}, Số tuần: {row["Tuan"]}, Học kỳ: {row["Hky"]}. ");
                    }
                }
                catch { }
            }
            return await Task.FromResult(sb.ToString());
        }

        private async Task<string> AIKiemTraTrungLichAsync(string danhSachMon)
        {
            using (HttpClient client = new HttpClient())
            {
                string prompt =
                    $"Bạn là cố vấn học tập đại học.\n" +
                    $"Danh sách môn học sinh viên muốn đăng ký:\n{danhSachMon}\n" +
                    $"Hãy phân tích và cảnh báo nếu có:\n" +
                    $"1. Các môn học cùng học kỳ có khả năng trùng lịch\n" +
                    $"2. Số tuần học quá nhiều trong cùng một kỳ\n" +
                    $"3. Khuyến nghị điều chỉnh nếu cần\n" +
                    $"Trả lời ngắn gọn bằng tiếng Việt, tối đa 5 câu.";

                var payload = new
                {
                    contents = new[]
                    {
                        new { role = "user", parts = new[] { new { text = prompt } } }
                    },
                    generationConfig = new { temperature = 0.5, maxOutputTokens = 300 }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                string url = $"https://generativelanguage.googleapis.com/v1/models/gemini-3.5-flash:generateContent?key={geminiApiKey}";

                HttpResponseMessage response = await client.PostAsync(url, content);
                string rawResult = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(rawResult)) return null;

                dynamic resultObj = JsonConvert.DeserializeObject(rawResult);

                if (resultObj?.candidates != null &&
                    resultObj.candidates[0]?.content?.parts != null)
                    return resultObj.candidates[0].content.parts[0].text.ToString().Trim();

                if (resultObj?.error != null)
                    throw new Exception(resultObj.error.message.ToString());

                return null;
            }
        }

        private void btnBack_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void dgvRegisterList_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { }


        private void btnAISuggest_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAICheckConflict_Click(object sender, EventArgs e)
        {

        }

    }
}