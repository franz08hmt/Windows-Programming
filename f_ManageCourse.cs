using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ManageCourse : UserControl
    {
        private My_DB db = new My_DB();
        private readonly string geminiApiKey = "Đừng push API lên git nhen";

        public f_ManageCourse()
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
        private void f_ManageCourse_Load(object sender, EventArgs e)
        {
            nudAddTuan.Minimum = 10;
            nudAddTuan.Value = 10;
            nudAddSotc.Minimum = 1;
            nudAddSotc.Value = 1;
            nudAddHky.Minimum = 1;
            nudAddHky.Maximum = 9;
            nudAddHky.Value = 1;

            nudEditTuan.Minimum = 10;
            nudEditSotc.Minimum = 1;
            nudEditHky.Minimum = 1;
            nudEditHky.Maximum = 9;

            cboFilterSemester.Items.Clear();
            cboFilterSemester.Items.Add("Tất cả");
            for (int i = 1; i <= 9; i++)
                cboFilterSemester.Items.Add(i.ToString());
            cboFilterSemester.SelectedIndex = 0;
            cboFilterSemester.SelectedIndexChanged += new EventHandler(cboFilterSemester_SelectedIndexChanged);

            btnRefresh.Click += new EventHandler(btnRefresh_Click_Handler);
            btnSearchList.Click += new EventHandler(btnSearchList_Click);
            txtSearchList.TextChanged += new EventHandler(txtSearchList_TextChanged);
            dgvCourse.CellDoubleClick += new DataGridViewCellEventHandler(dgvCourse_CellDoubleClick);

            SetupAutocomplete();

            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDel.Click += new EventHandler(btnDel_Click);
            btnAIGenMota.Click += new EventHandler(btnAIGenMota_Click_Handler);
            btnAICDIO.Click += new EventHandler(btnAICDIO_Click_Handler);

            HienThiDanhSach();
        }

        // ===================================================================
        // AUTOCOMPLETE (nâng cao)
        // ===================================================================
        private void SetupAutocomplete()
        {
            try
            {
                string query = "SELECT TenMH FROM Course";
                SqlDataAdapter da = new SqlDataAdapter(query, db.getConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                    col.Add(row["TenMH"].ToString());

                txtAddTen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtAddTen.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtAddTen.AutoCompleteCustomSource = col;

                txtEditTen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtEditTen.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtEditTen.AutoCompleteCustomSource = col;
            }
            catch { }
        }

        // ===================================================================
        // [AI] SINH MÔ TẢ MÔN HỌC TỰ ĐỘNG (nâng cao)
        // ===================================================================
        private async void btnAIGenMota_Click_Handler(object sender, EventArgs e)
        {
            string tenMon = txtAddTen.Text.Trim();
            int soTC = (int)nudAddSotc.Value;

            if (string.IsNullOrWhiteSpace(tenMon))
            {
                MessageBox.Show("Vui lòng nhập Tên môn học trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAIGenMota.Enabled = false;
            btnAIGenMota.Text = "⏳ Đang tạo...";

            try
            {
                string moTa = await GenMoTaMonHocAsync(tenMon, soTC);
                if (!string.IsNullOrEmpty(moTa))
                {
                    txtAddMota.Text = moTa;
                    MessageBox.Show("AI đã sinh mô tả môn học thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                btnAIGenMota.Enabled = true;
                btnAIGenMota.Text = "🤖 AI Sinh mô tả";
            }
        }

        private async Task<string> GenMoTaMonHocAsync(string tenMon, int soTC)
        {
            using (HttpClient client = new HttpClient())
            {
                string prompt =
                    $"Hãy viết mô tả ngắn gọn (2-3 câu, bằng tiếng Việt) cho môn học đại học sau:\n" +
                    $"Tên môn: {tenMon}\n" +
                    $"Số tín chỉ: {soTC}\n" +
                    $"Yêu cầu: Mô tả nội dung chính, mục tiêu học tập, và kỹ năng sinh viên đạt được. " +
                    $"Chỉ trả về đoạn mô tả, không có tiêu đề hay giải thích thêm.";

                var payload = new
                {
                    contents = new[]
                    {
                        new { role = "user", parts = new[] { new { text = prompt } } }
                    },
                    generationConfig = new { temperature = 0.7, maxOutputTokens = 200 }
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

        // ===================================================================
        // [AI] ĐỀ XUẤT SỐ TUẦN / SỐ TC THEO CHUẨN CDIO (nâng cao)
        // ===================================================================
        private async void btnAICDIO_Click_Handler(object sender, EventArgs e)
        {
            string tenMon = txtAddTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(tenMon))
            {
                MessageBox.Show("Vui lòng nhập Tên môn học trước!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAICDIO.Enabled = false;
            btnAICDIO.Text = "⏳ Đang phân tích...";

            try
            {
                string ketQua = await DeXuatCDIOAsync(tenMon);

                if (!string.IsNullOrEmpty(ketQua))
                {
                    int sotc = 0;
                    int sotuan = 0;

                    // Parse định dạng SoTC:X|SoTuan:Y
                    foreach (string part in ketQua.Split(
                        new char[] { '|', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string p = part.Trim();
                        if (p.ToUpper().Contains("SOTC") ||
                            p.ToUpper().Contains("TÍN CHỈ") ||
                            p.ToUpper().Contains("TC:"))
                        {
                            var match = System.Text.RegularExpressions.Regex.Match(p, @"\d+");
                            if (match.Success) int.TryParse(match.Value, out sotc);
                        }
                        if (p.ToUpper().Contains("SOTUAN") ||
                            p.ToUpper().Contains("TUẦN") ||
                            p.ToUpper().Contains("TUAN:"))
                        {
                            var match = System.Text.RegularExpressions.Regex.Match(p, @"\d+");
                            if (match.Success) int.TryParse(match.Value, out sotuan);
                        }
                    }

                    // Fallback: lấy 2 số đầu tiên trong chuỗi
                    if (sotc == 0 || sotuan == 0)
                    {
                        var allNums = System.Text.RegularExpressions.Regex
                            .Matches(ketQua, @"\b\d+\b")
                            .Cast<System.Text.RegularExpressions.Match>()
                            .Select(m => int.Parse(m.Value))
                            .Where(n => n >= 1 && n <= 20)
                            .ToList();

                        if (allNums.Count >= 1 && sotc == 0) sotc = allNums[0];
                        if (allNums.Count >= 2 && sotuan == 0) sotuan = allNums[1];
                    }

                    // Fallback: tìm trực tiếp trong raw string
                    if (sotc == 0 && ketQua.Contains("SoTC:"))
                    {
                        var m = System.Text.RegularExpressions.Regex.Match(
                            ketQua, @"SoTC:(\d+)");
                        if (m.Success) int.TryParse(m.Groups[1].Value, out sotc);
                    }
                    if (sotuan == 0 && ketQua.Contains("SoTuan:"))
                    {
                        var m = System.Text.RegularExpressions.Regex.Match(
                            ketQua, @"SoTuan:(\d+)");
                        if (m.Success) int.TryParse(m.Groups[1].Value, out sotuan);
                    }
                    if (sotuan == 0 && sotc > 0)
                        sotuan = sotc * 5;
                    if (sotuan < 10) sotuan = 10;
                    if (sotuan > 20) sotuan = 20;

                    // Điền vào form
                    if (sotc >= 1 && sotc <= 10) nudAddSotc.Value = sotc;
                    if (sotuan >= 10 && sotuan <= 20) nudAddTuan.Value = sotuan;
                    // Điền vào form
                    if (sotc >= 1 && sotc <= 10) nudAddSotc.Value = sotc;
                    if (sotuan >= 10 && sotuan <= 20) nudAddTuan.Value = sotuan;

                    MessageBox.Show(
                        $"AI đề xuất theo chuẩn CDIO cho môn '{tenMon}':\n\n" +
                        $"Số tín chỉ: {(sotc > 0 ? sotc.ToString() : "Không xác định")}\n" +
                        $"Số tuần:    {(sotuan > 0 ? sotuan.ToString() : "Không xác định")}",
                        "AI Đề xuất CDIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                btnAICDIO.Enabled = true;
                btnAICDIO.Text = "📐 AI Đề xuất TC/Tuần (CDIO)";
            }
        }

        private async Task<string> DeXuatCDIOAsync(string tenMon)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(60);

                string prompt =
                    $"For university course '{tenMon}', reply ONLY in this exact format: " +
                    $"SoTC:X|SoTuan:Y where X is an integer credits (1-10) and Y is integer weeks (10-20). " +
                    $"Example: SoTC:3|SoTuan:15. No explanation, no other text.";

                var payload = new
                {
                    contents = new[]
                    {
                        new { parts = new[] { new { text = prompt } } }
                    },
                    generationConfig = new { temperature = 0.1, maxOutputTokens = 200 }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                string url = $"https://generativelanguage.googleapis.com/v1/models/gemini-3.5-flash:generateContent?key={geminiApiKey}";

                HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);
                string rawResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(rawResult)) return null;

                dynamic resultObj = JsonConvert.DeserializeObject(rawResult);

                try
                {
                    if (resultObj?.candidates != null)
                    {
                        var candidate = resultObj.candidates[0];
                        if (candidate?.content?.parts != null)
                            return candidate.content.parts[0].text.ToString().Trim();
                    }
                }
                catch { }

                // Fallback: tìm SoTC: trực tiếp trong raw JSON
                if (rawResult.Contains("SoTC:"))
                {
                    int idx = rawResult.IndexOf("SoTC:");
                    // Lấy toàn bộ từ SoTC: đến hết
                    string extracted = rawResult.Substring(idx)
                        .Replace("\\n", "\n")
                        .Replace("\\r", "")
                        .Replace("\"", "")
                        .Trim();
                    // Chỉ lấy dòng đầu tiên chứa SoTC
                    string[] lines = extracted.Split('\n');
                    return lines[0].Trim();
                }

                if (resultObj?.error != null)
                    throw new Exception(resultObj.error.message.ToString());

                return null;
            }
        }

        // ===================================================================
        // TAB THÊM MÔN HỌC
        // ===================================================================
        private void btnAdd_Click_Handler(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddMa.Text) ||
                string.IsNullOrWhiteSpace(txtAddTen.Text))


            {

                MessageBox.Show("Vui lòng nhập đầy đủ Mã và Tên môn học!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((int)nudAddTuan.Value < 10)
            {
                MessageBox.Show("Số tuần tối thiểu phải là 10!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckTenMonTonTai(txtAddTen.Text.Trim()))
            {
                MessageBox.Show("Tên môn học đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                db.openConnection();
                string query =
                    "INSERT INTO Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) " +
                    "VALUES (@mamh, @tenmh, @sotc, @tuan, @hky, @mota)";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mamh", txtAddMa.Text.Trim());
                cmd.Parameters.AddWithValue("@tenmh", txtAddTen.Text.Trim());
                cmd.Parameters.AddWithValue("@sotc", (int)nudAddSotc.Value);
                cmd.Parameters.AddWithValue("@tuan", (int)nudAddTuan.Value);
                cmd.Parameters.AddWithValue("@hky", (int)nudAddHky.Value);
                cmd.Parameters.AddWithValue("@mota", txtAddMota.Text.Trim());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm môn học thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAddForm();
                    HienThiDanhSach();
                    SetupAutocomplete();
                }
                db.closeConnection();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                db.closeConnection();
                MessageBox.Show("Mã môn học đã tồn tại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckTenMonTonTai(string tenMH, string maMonHienTai = "")
        {
            try
            {
                string query = string.IsNullOrEmpty(maMonHienTai)
                    ? "SELECT COUNT(*) FROM Course WHERE TenMH = @tenmh"
                    : "SELECT COUNT(*) FROM Course WHERE TenMH = @tenmh AND MaMH <> @mamh";

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@tenmh", tenMH);
                if (!string.IsNullOrEmpty(maMonHienTai))
                    cmd.Parameters.AddWithValue("@mamh", maMonHienTai);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch { return false; }
        }

        private void ClearAddForm()
        {
            txtAddMa.Clear();
            txtAddTen.Clear();
            txtAddMota.Clear();
            nudAddSotc.Value = 1;
            nudAddTuan.Value = 10;
            nudAddHky.Value = 1;
        }

        // ===================================================================
        // TAB SỬA MÔN HỌC
        // ===================================================================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditMa.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã môn học cần tìm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string query = "SELECT * FROM Course WHERE MaMH = @mamh";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@mamh", txtEditMa.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtEditTen.Text = row["TenMH"].ToString();
                    nudEditSotc.Value = Convert.ToDecimal(row["SoTC"]);
                    nudEditTuan.Value = Convert.ToDecimal(row["Tuan"]);
                    nudEditHky.Value = Convert.ToDecimal(row["Hky"]);
                    txtEditMota.Text = row["Mota"]?.ToString() ?? "";
                    txtEditMa.Enabled = false;
                }
                else
                    MessageBox.Show("Không tìm thấy môn học với mã: " + txtEditMa.Text,
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditMa.Text) ||
                string.IsNullOrWhiteSpace(txtEditTen.Text))
            {
                MessageBox.Show("Vui lòng tìm môn học trước khi sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((int)nudEditTuan.Value < 10)
            {
                MessageBox.Show("Số tuần tối thiểu phải là 10!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckTenMonTonTai(txtEditTen.Text.Trim(), txtEditMa.Text.Trim()))
            {
                MessageBox.Show("Tên môn học đã được dùng bởi môn khác!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                db.openConnection();
                string query =
                    "UPDATE Course SET TenMH=@tenmh, SoTC=@sotc, Tuan=@tuan, Hky=@hky, Mota=@mota " +
                    "WHERE MaMH=@mamh";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mamh", txtEditMa.Text.Trim());
                cmd.Parameters.AddWithValue("@tenmh", txtEditTen.Text.Trim());
                cmd.Parameters.AddWithValue("@sotc", (int)nudEditSotc.Value);
                cmd.Parameters.AddWithValue("@tuan", (int)nudEditTuan.Value);
                cmd.Parameters.AddWithValue("@hky", (int)nudEditHky.Value);
                cmd.Parameters.AddWithValue("@mota", txtEditMota.Text.Trim());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật môn học thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEditMa.Enabled = true;
                    HienThiDanhSach();
                    SetupAutocomplete();
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi sửa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditMa.Text))
            {
                MessageBox.Show("Vui lòng tìm môn học trước khi xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult confirm = MessageBox.Show(
                $"Bạn chắc chắn muốn xóa môn học '{txtEditTen.Text}' ({txtEditMa.Text})?\n" +
                "Toàn bộ điểm và đăng ký liên quan sẽ bị xóa!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                db.openConnection();
                string maMH = txtEditMa.Text.Trim();

                new SqlCommand("DELETE FROM Score WHERE MaMH = @mamh", db.conn)
                { Parameters = { new SqlParameter("@mamh", maMH) } }
                    .ExecuteNonQuery();

                new SqlCommand("DELETE FROM DKMH WHERE MaMH = @mamh", db.conn)
                { Parameters = { new SqlParameter("@mamh", maMH) } }
                    .ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("DELETE FROM Course WHERE MaMH = @mamh", db.conn);
                cmd.Parameters.AddWithValue("@mamh", maMH);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa môn học thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEditMa.Text = "";
                    txtEditTen.Text = "";
                    txtEditMota.Text = "";
                    nudEditSotc.Value = 1;
                    nudEditTuan.Value = 10;
                    nudEditHky.Value = 1;
                    txtEditMa.Enabled = true;
                    HienThiDanhSach();
                    SetupAutocomplete();
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi xóa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCourse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvCourse.Rows[e.RowIndex];

            txtEditMa.Text = row.Cells["MaMH"].Value?.ToString() ?? "";
            txtEditTen.Text = row.Cells["TenMH"].Value?.ToString() ?? "";
            nudEditSotc.Value = Convert.ToDecimal(row.Cells["SoTC"].Value ?? 1);
            nudEditTuan.Value = Convert.ToDecimal(row.Cells["Tuan"].Value ?? 10);
            nudEditHky.Value = Convert.ToDecimal(row.Cells["Hky"].Value ?? 1);
            txtEditMota.Text = row.Cells["Mota"].Value?.ToString() ?? "";
            txtEditMa.Enabled = false;

            tabControl1.SelectedTab = tabEdit;
        }

        // ===================================================================
        // TAB DANH SÁCH
        // ===================================================================
        private void HienThiDanhSach(string filter = "", int hky = 0)
        {
            try
            {
                string query =
                    "SELECT MaMH, TenMH, SoTC, Tuan, Hky AS [Học kỳ], Mota " +
                    "FROM Course WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(filter))
                    query += " AND (MaMH LIKE @filter OR TenMH LIKE @filter)";
                if (hky > 0)
                    query += " AND Hky = @hky";
                query += " ORDER BY Hky, MaMH";

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                if (!string.IsNullOrWhiteSpace(filter))
                    cmd.Parameters.AddWithValue("@filter", "%" + filter + "%");
                if (hky > 0)
                    cmd.Parameters.AddWithValue("@hky", hky);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCourse.DataSource = dt;
                dgvCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchList_Click(object sender, EventArgs e)
        {
            int hky = 0;
            if (cboFilterSemester.SelectedItem != null &&
                cboFilterSemester.SelectedItem.ToString() != "Tất cả")
                int.TryParse(cboFilterSemester.SelectedItem.ToString(), out hky);
            HienThiDanhSach(txtSearchList.Text.Trim(), hky);
        }

        private void txtSearchList_TextChanged(object sender, EventArgs e)
        {
            btnSearchList_Click(sender, e);
        }

        private void cboFilterSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSearchList_Click(sender, e);
        }

        private void btnRefresh_Click_Handler(object sender, EventArgs e)
        {
            txtSearchList.Clear();
            cboFilterSemester.SelectedIndex = 0;
            HienThiDanhSach();
        }

        private void btnBack_Click_Handler(object sender, EventArgs e)
        {
        }

        // ===================================================================
        // SỰ KIỆN TRỐNG
        // ===================================================================
        private void button1_Click_1(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Hien_Thi_Danh_Sach_Mon_Hoc() { HienThiDanhSach(); }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(panel3, 25, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(panel1, 25, e);
        }
    }
}