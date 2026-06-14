using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLySinhVien
{
    public partial class f_Statistic : UserControl
    {
        private readonly Color panTotalColor = Color.FromArgb(0, 61, 149);
        private readonly Color panMaleColor = Color.FromArgb(0, 120, 215);
        private readonly Color panFemaleColor = Color.FromArgb(220, 53, 69);
        private readonly Color panOtherColor = Color.FromArgb(40, 167, 69);
        private readonly string geminiApiKey = "Đừng push API lên git nhen";

        public f_Statistic()
        {
            InitializeComponent();
        }

        private void f_Statistic_Load(object sender, EventArgs e)
        {
            LoadStatisticData();
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

        // ===================================================================
        // TẢI DỮ LIỆU THỐNG KÊ
        // ===================================================================
        private void LoadStatisticData()
        {
            double total = Student.totalStudent();
            double male = Student.totalMaleStudent();
            double female = Student.totalFemaleStudent();
            double other = Student.totalOtherStudent();

            lblTotal.Text = ((int)total).ToString();
            lblMale.Text = total > 0
                ? $"Nam\n{(int)male} SV\n{(male / total * 100):F1}%"
                : "Nam\n0 SV\n0%";
            lblFemale.Text = total > 0
                ? $"Nữ\n{(int)female} SV\n{(female / total * 100):F1}%"
                : "Nữ\n0 SV\n0%";
            lblOther.Text = total > 0
                ? $"Khác\n{(int)other} SV\n{(other / total * 100):F1}%"
                : "Khác\n0 SV\n0%";

            lblTongSV.Text = $"Tổng SV có điểm: {Score.GetScoreStatistics()?.Rows.Count ?? 0}";
            lblTongMon.Text = $"Tổng môn học: {Score.GetAvgScoreBySubject()?.Rows.Count ?? 0}";

            DataTable dtXepLoai = Score.GetCountByXepLoai();
            dgvReport.DataSource = dtXepLoai;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            StyleDgv(dgvReport);

            DataTable dtStats = Score.GetScoreStatistics();
            dgvDetail.DataSource = dtStats;
            dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            StyleDgv(dgvDetail);

            VeBieuDoCot(dtXepLoai);
            VePieChart(male, female, other);

            // Thống kê theo năm
            LoadThongKeNam();
        }

        // ===================================================================
        // THỐNG KÊ THEO NĂM NHẬP HỌC (lấy 4 số đầu của MSSV)
        // ===================================================================
        private void LoadThongKeNam()
        {
            try
            {
                My_DB db = new My_DB();
                db.openConnection();
                string query =
                    "SELECT LEFT(CAST(MSSV AS NVARCHAR), 2) AS NamNhapHoc, " +
                    "COUNT(*) AS SoLuong " +
                    "FROM Student " +
                    "GROUP BY LEFT(CAST(MSSV AS NVARCHAR), 2) " +
                    "ORDER BY NamNhapHoc";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                db.closeConnection();

                dgvNam.DataSource = dt;
                dgvNam.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                StyleDgv(dgvNam);

                if (dt.Columns["NamNhapHoc"] != null)
                    dgvNam.Columns["NamNhapHoc"].HeaderText = "Năm nhập học";
                if (dt.Columns["SoLuong"] != null)
                    dgvNam.Columns["SoLuong"].HeaderText = "Số lượng SV";

                // Vẽ biểu đồ cột theo năm
                VeBieuDoNam(dt);
            }
            catch (Exception ex)
            {
                lblThongKeNam.Text = "Lỗi tải thống kê năm: " + ex.Message;
            }
        }

        private void VeBieuDoNam(DataTable dt)
        {
            chartNam.Series.Clear();
            chartNam.Titles.Clear();
            chartNam.Titles.Add("Số lượng sinh viên theo năm nhập học");
            chartNam.Titles[0].Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            chartNam.Titles[0].ForeColor = Color.FromArgb(0, 61, 149);

            Series s = new Series("Số SV");
            s.ChartType = SeriesChartType.Column;
            s.Color = Color.FromArgb(0, 120, 215);
            s.IsValueShownAsLabel = true;
            s.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            s.LabelForeColor = Color.FromArgb(0, 61, 149);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    s.Points.AddXY(
                        "20" + row["NamNhapHoc"].ToString(),
                        Convert.ToInt32(row["SoLuong"]));
                }
            }

            chartNam.Series.Add(s);
            chartNam.ChartAreas[0].AxisX.Interval = 1;
            chartNam.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9f);
            chartNam.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 9f);
            chartNam.ChartAreas[0].BackColor = Color.WhiteSmoke;
            chartNam.BackColor = Color.White;
        }

        // ===================================================================
        // STYLE DGV
        // ===================================================================
        private void StyleDgv(DataGridView dgv)
        {
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 61, 149);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 255);
            dgv.RowTemplate.Height = 28;
        }

        // ===================================================================
        // VẼ BIỂU ĐỒ CỘT XẾP LOẠI
        // ===================================================================
        private void VeBieuDoCot(DataTable dtXepLoai)
        {
            chartGpa.Series.Clear();
            chartGpa.Titles.Clear();
            chartGpa.Titles.Add("Phổ Điểm Học Lực");
            chartGpa.Titles[0].Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            chartGpa.Titles[0].ForeColor = Color.FromArgb(0, 61, 149);

            Series s = new Series("Học Lực");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            s.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            s.LabelForeColor = Color.FromArgb(0, 61, 149);

            string[] colors = { "#8B0000", "#FF8C00", "#1E90FF", "#228B22", "#9932CC" };
            int idx = 0;
            if (dtXepLoai != null)
            {
                foreach (DataRow row in dtXepLoai.Rows)
                {
                    int pt = s.Points.AddXY(
                        row["Xếp Loại"].ToString(),
                        Convert.ToInt32(row["Số Lượng"]));
                    s.Points[pt].Color = ColorTranslator.FromHtml(colors[idx % colors.Length]);
                    idx++;
                }
            }

            chartGpa.Series.Add(s);
            chartGpa.ChartAreas[0].AxisX.Interval = 1;
            chartGpa.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9f);
            chartGpa.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 9f);
            chartGpa.ChartAreas[0].BackColor = Color.WhiteSmoke;
            chartGpa.BackColor = Color.White;
        }

        // ===================================================================
        // VẼ PIE CHART GIỚI TÍNH
        // ===================================================================
        private void VePieChart(double male, double female, double other)
        {
            chartPie.Series.Clear();
            chartPie.Titles.Clear();
            chartPie.Titles.Add("Tỷ lệ Giới tính");
            chartPie.Titles[0].Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            chartPie.Titles[0].ForeColor = Color.FromArgb(0, 61, 149);

            Series s = new Series("Giới tính");
            s.ChartType = SeriesChartType.Pie;
            s.IsValueShownAsLabel = true;
            s["PieLabelStyle"] = "Outside";
            s.Font = new Font("Segoe UI", 9f, FontStyle.Bold);

            s.Points.AddXY("Nam", male);
            s.Points.AddXY("Nữ", female);
            s.Points.AddXY("Khác", other);

            s.Points[0].Color = Color.FromArgb(0, 120, 215);
            s.Points[1].Color = Color.FromArgb(220, 53, 69);
            s.Points[2].Color = Color.FromArgb(40, 167, 69);

            chartPie.Series.Add(s);
            chartPie.BackColor = Color.White;
            chartPie.Legends[0].Font = new Font("Segoe UI", 9f);
        }

        // ===================================================================
        // [AI] DASHBOARD INSIGHT
        // ===================================================================
        private async void btnAIDashboard_Click(object sender, EventArgs e)
        {
            btnAIDashboard.Enabled = false;
            btnAIDashboard.Text = "⏳ Đang phân tích...";

            try
            {
                // Thu thập dữ liệu
                double total = Student.totalStudent();
                double male = Student.totalMaleStudent();
                double female = Student.totalFemaleStudent();
                double other = Student.totalOtherStudent();

                DataTable dtXepLoai = Score.GetCountByXepLoai();
                string xepLoaiStr = "";
                if (dtXepLoai != null)
                    foreach (DataRow row in dtXepLoai.Rows)
                        xepLoaiStr += $"{row["Xếp Loại"]}: {row["Số Lượng"]} SV, ";

                // Thống kê theo năm
                string namStr = LayThongKeNamStr();

                string insight = await CallAIDashboardAsync(
                    (int)total, (int)male, (int)female, (int)other,
                    xepLoaiStr, namStr);

                if (!string.IsNullOrEmpty(insight))
                    HienThiKetQuaAI("📊 AI Dashboard Insight", insight);
                else
                    MessageBox.Show("AI không trả về kết quả.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi AI: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAIDashboard.Enabled = true;
                btnAIDashboard.Text = "📊 AI Insight";
            }
        }

        private string LayThongKeNamStr()
        {
            try
            {
                My_DB db = new My_DB();
                db.openConnection();
                string query = "SELECT LEFT(CAST(MSSV AS NVARCHAR), 2) AS Nam, COUNT(*) AS SL FROM Student GROUP BY LEFT(CAST(MSSV AS NVARCHAR), 2) ORDER BY Nam";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                db.closeConnection();

                string result = "";
                foreach (DataRow row in dt.Rows)
                    result += $"20{row["Nam"]}: {row["SL"]} SV, ";
                return result.TrimEnd(',', ' ');
            }
            catch { return "Không có dữ liệu"; }
        }

        private async Task<string> CallAIDashboardAsync(
            int total, int male, int female, int other,
            string xepLoai, string theoNam)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(60);
                string prompt =
                    $"Dữ liệu số lượng sinh viên nhập học:\n{theoNam}\n\n" +
                    $"YÊU CẦU: Chỉ trả lời bằng tiếng Việt thuần túy, KHÔNG dùng ký hiệu toán học, KHÔNG dùng tiếng Anh.\n" +
                    $"Hãy trả lời theo đúng 3 mục sau:\n" +
                    $"1. Xu hướng: [nhận xét tăng/giảm qua các năm]\n" +
                    $"2. Dự đoán năm tới: [con số cụ thể] sinh viên\n" +
                    $"3. Lý do: [giải thích ngắn gọn 1-2 câu]\n" +
                    $"Tổng độ dài không quá 150 từ.";

                var payload = new
                {
                    contents = new[] { new { role = "user", parts = new[] { new { text = prompt } } } },
                    generationConfig = new { temperature = 0.3, maxOutputTokens = 1500 }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                string url = $"https://generativelanguage.googleapis.com/v1/models/gemini-3.5-flash:generateContent?key={geminiApiKey}";
                HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);
                string rawResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(rawResult)) return null;
                dynamic resultObj = JsonConvert.DeserializeObject(rawResult);
                if (resultObj?.candidates != null && resultObj.candidates[0]?.content?.parts != null)
                    return resultObj.candidates[0].content.parts[0].text.ToString().Trim();
                if (resultObj?.error != null)
                    throw new Exception(resultObj.error.message.ToString());
                return null;
            }
        }

        // ===================================================================
        // [AI] DỰ ĐOÁN SỐ LƯỢNG SINH VIÊN NĂM SAU (hồi quy tuyến tính)
        // ===================================================================
        private async void btnAIPredict_Click(object sender, EventArgs e)
        {
            btnAIPredict.Enabled = false;
            btnAIPredict.Text = "⏳ Đang dự đoán...";

            try
            {
                string namStr = LayThongKeNamStr();
                string ketQua = await CallAIPredictAsync(namStr);

                if (!string.IsNullOrEmpty(ketQua))
                    HienThiKetQuaAI("🔮 AI Dự đoán số lượng sinh viên", ketQua);
                else
                    MessageBox.Show("AI không trả về kết quả.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi AI: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAIPredict.Enabled = true;
                btnAIPredict.Text = "🔮 AI Dự đoán";
            }
        }

        private async Task<string> CallAIPredictAsync(string theoNam)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(60);
                string prompt =
                    $"Dữ liệu sinh viên nhập học: {theoNam}\n\n" +
                    $"KHÔNG viết lời chào. KHÔNG giải thích dài dòng. " +
                    $"Mỗi dòng KHÔNG quá 15 từ. " +
                    $"Chỉ trả lời đúng 3 dòng sau bằng tiếng Việt:\n" +
                    $"1. Xu hướng: ...\n" +
                    $"2. Dự đoán năm tới: ... sinh viên\n" +
                    $"3. Lý do: ...";

                var payload = new
                {
                    contents = new[] { new { role = "user", parts = new[] { new { text = prompt } } } },
                    generationConfig = new { temperature = 0.1, maxOutputTokens = 1000 }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                string url = $"https://generativelanguage.googleapis.com/v1/models/gemini-3.5-flash:generateContent?key={geminiApiKey}";
                HttpResponseMessage response = await client.PostAsync(url, content).ConfigureAwait(false);
                string rawResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (string.IsNullOrEmpty(rawResult)) return null;
                dynamic resultObj = JsonConvert.DeserializeObject(rawResult);
                if (resultObj?.candidates != null && resultObj.candidates[0]?.content?.parts != null)
                    return resultObj.candidates[0].content.parts[0].text.ToString().Trim();
                if (resultObj?.error != null)
                    throw new Exception(resultObj.error.message.ToString());
                return null;
            }
        }

        // ===================================================================
        // HIỂN THỊ KẾT QUẢ AI
        // ===================================================================
        private void HienThiKetQuaAI(string title, string content)
        {
            Form frmResult = new Form
            {
                Text = title,
                Size = new System.Drawing.Size(700, 560),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Panel pnlHead = new Panel
            {
                BackColor = Color.FromArgb(0, 61, 149),
                Dock = DockStyle.Top,
                Height = 50
            };
            Label lblHead = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new System.Drawing.Point(15, 12),
                Size = new System.Drawing.Size(660, 28),
                AutoSize = false
            };
            pnlHead.Controls.Add(lblHead);

            RichTextBox rtb = new RichTextBox
            {
                Text = content,
                Font = new Font("Segoe UI", 10F),
                Location = new System.Drawing.Point(15, 65),
                Size = new System.Drawing.Size(660, 420),
                ReadOnly = true,
                BackColor = Color.FromArgb(248, 250, 252),
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            Button btnOK = new Button
            {
                Text = "  OK  ",
                Size = new System.Drawing.Size(110, 38),
                Location = new System.Drawing.Point(285, 490),
                BackColor = Color.FromArgb(0, 61, 149),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            btnOK.FlatAppearance.BorderSize = 0;
            btnOK.Click += (s, ev) => frmResult.Close();

            frmResult.Controls.Add(pnlHead);
            frmResult.Controls.Add(rtb);
            frmResult.Controls.Add(btnOK);
            frmResult.ShowDialog(this);
        }

        // ===================================================================
        // HOVER EFFECTS
        // ===================================================================
        private void pnlMale_MouseEnter(object sender, EventArgs e)
        {
            pnlMale.BackColor = Color.White;
            lblMale.ForeColor = panMaleColor;
            lblMale.BackColor = Color.White;
        }
        private void pnlMale_MouseLeave(object sender, EventArgs e)
        {
            pnlMale.BackColor = panMaleColor;
            lblMale.ForeColor = Color.White;
            lblMale.BackColor = panMaleColor;
        }
        private void pnlFemale_MouseEnter(object sender, EventArgs e)
        {
            pnlFemale.BackColor = Color.White;
            lblFemale.ForeColor = panFemaleColor;
            lblFemale.BackColor = Color.White;
        }
        private void pnlFemale_MouseLeave(object sender, EventArgs e)
        {
            pnlFemale.BackColor = panFemaleColor;
            lblFemale.ForeColor = Color.White;
            lblFemale.BackColor = panFemaleColor;
        }
        private void pnlOther_MouseEnter(object sender, EventArgs e)
        {
            pnlOther.BackColor = Color.White;
            lblOther.ForeColor = panOtherColor;
            lblOther.BackColor = Color.White;
        }
        private void pnlOther_MouseLeave(object sender, EventArgs e)
        {
            pnlOther.BackColor = panOtherColor;
            lblOther.ForeColor = Color.White;
            lblOther.BackColor = panOtherColor;
        }
        private void pnlTotal_MouseEnter(object sender, EventArgs e)
        {
            pnlTotal.BackColor = Color.White;
            lblTotalTitle.ForeColor = panTotalColor;
            lblTotal.ForeColor = panTotalColor;
        }
        private void pnlTotal_MouseLeave(object sender, EventArgs e)
        {
            pnlTotal.BackColor = panTotalColor;
            lblTotalTitle.ForeColor = Color.White;
            lblTotal.ForeColor = Color.White;
        }

        private void btnRefresh_Click(object sender, EventArgs e) { LoadStatisticData(); }
        private void btnBack_Click(object sender, EventArgs e) { }

        private void pnlTotal_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlTotal, 25, e);
        }

        private void pnlMale_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlMale, 25, e);
        }

        private void pnlFemale_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlFemale, 25, e);
        }

        private void pnlOther_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlOther, 25, e);
        }
    }
}