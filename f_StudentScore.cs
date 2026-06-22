using MiniSoftware;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLySinhVien
{
    public partial class f_StudentScore : UserControl
    {
        private My_DB db = new My_DB();
        private readonly string geminiApiKey = "Đừng push API lên git nhen";
        private DataTable dtScore = null;

        public f_StudentScore()
        {
            InitializeComponent();
        }

        private void f_StudentScore_Load(object sender, EventArgs e)
        {
            if (Globals.GlobalPosition == 1)
            {
                string mssv = GetMSSVFromLogin();
                if (!string.IsNullOrEmpty(mssv))
                {
                    txtMSSV.Text = mssv;
                    txtMSSV.ReadOnly = true;
                    LoadScoreData(mssv);
                }
            }
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

        private string GetMSSVFromLogin()
        {
            try
            {
                My_DB tempDb = new My_DB();
                tempDb.openConnection();
                string query = "SELECT s.MSSV FROM Student s JOIN Login l ON s.Email = l.Email WHERE l.MSGV = @msgv";
                SqlCommand cmd = new SqlCommand(query, tempDb.conn);
                cmd.Parameters.AddWithValue("@msgv", Globals.GlobalUserId);
                object result = cmd.ExecuteScalar();
                tempDb.closeConnection();
                return result?.ToString() ?? "";
            }
            catch { return ""; }
        }

        // ===================================================================
        // TẢI DỮ LIỆU ĐIỂM
        // ===================================================================
        private void LoadScoreData(string mssv)
        {
            try
            {
                My_DB tempDb = new My_DB();
                tempDb.openConnection();
                string querySV = "SELECT Fname, Lname FROM Student WHERE MSSV = @mssv";
                SqlCommand cmdSV = new SqlCommand(querySV, tempDb.conn);
                cmdSV.Parameters.AddWithValue("@mssv", mssv);
                SqlDataAdapter daSV = new SqlDataAdapter(cmdSV);
                DataTable dtSV = new DataTable();
                daSV.Fill(dtSV);
                tempDb.closeConnection();

                if (dtSV.Rows.Count > 0)
                {
                    txtFname.Text = dtSV.Rows[0]["Fname"].ToString();
                    txtLname.Text = dtSV.Rows[0]["Lname"].ToString();
                }

                tempDb = new My_DB();
                tempDb.openConnection();
                string query =
                    "SELECT c.MaMH AS [Mã MH], c.TenMH AS [Tên Môn], c.SoTC AS [Số TC], " +
                    "s.DiemQT AS [Điểm QT], s.DiemCK AS [Điểm CK], s.DiemTK AS [Điểm TK], " +
                    "s.Mota AS [Ghi Chú] " +
                    "FROM Course c JOIN Score s ON c.MaMH = s.MaMH " +
                    "WHERE s.MSSV = @mssv AND s.DiemTK IS NOT NULL";
                SqlCommand cmd = new SqlCommand(query, tempDb.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtScore = new DataTable();
                da.Fill(dtScore);
                tempDb.closeConnection();

                dgvScore.DataSource = dtScore;
                dgvScore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewRow row in dgvScore.Rows)
                {
                    if (row.IsNewRow) continue;
                    object val = row.Cells["Điểm TK"].Value;
                    if (val == null || val == DBNull.Value) continue;
                    decimal dtk = Convert.ToDecimal(val);
                    if (dtk >= 9m) row.DefaultCellStyle.BackColor = Color.FromArgb(220, 255, 220);
                    else if (dtk >= 8m) row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 255);
                    else if (dtk >= 6.5m) row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200);
                    else if (dtk < 5m) row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                }

                int tongTC = 0;
                double tongDiem = 0;
                foreach (DataRow row in dtScore.Rows)
                {
                    if (row["Điểm TK"] == DBNull.Value) continue;
                    int sotc = Convert.ToInt32(row["Số TC"]);
                    double dtk = Convert.ToDouble(row["Điểm TK"]);
                    tongTC += sotc;
                    tongDiem += dtk * sotc;
                }

                double diemTB = tongTC > 0 ? Math.Round(tongDiem / tongTC, 2) : 0;
                string xepLoai =
                    diemTB >= 9 ? "Xuất Sắc" :
                    diemTB >= 8 ? "Giỏi" :
                    diemTB >= 6.5 ? "Khá" :
                    diemTB >= 5 ? "Trung Bình" : "Yếu";

                lblDiemTB.Text = $"Điểm Trung Bình: {diemTB:F2}";
                lblTongTC.Text = $"Tổng Số Tín Chỉ: {tongTC}";
                lblXepLoai.Text = $"Xếp Loại: {xepLoai}";

                Color mauXL =
                    xepLoai == "Xuất Sắc" ? Color.Purple :
                    xepLoai == "Giỏi" ? Color.DarkGreen :
                    xepLoai == "Khá" ? Color.DarkBlue :
                    xepLoai == "Trung Bình" ? Color.DarkOrange : Color.Red;
                lblXepLoai.ForeColor = mauXL;

                VeBieuDo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================================================================
        // VẼ BIỂU ĐỒ
        // ===================================================================
        private void VeBieuDo()
        {
            if (dtScore == null || dtScore.Rows.Count == 0) return;

            chartScore.Series.Clear();
            chartScore.Titles.Clear();
            chartScore.Titles.Add("So sánh Điểm QT và Điểm CK");
            chartScore.Titles[0].Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            chartScore.Titles[0].ForeColor = Color.FromArgb(0, 61, 149);

            Series seriesQT = new Series("Điểm QT");
            seriesQT.ChartType = SeriesChartType.Column;
            seriesQT.Color = Color.FromArgb(0, 120, 215);
            seriesQT.IsValueShownAsLabel = true;
            seriesQT.Font = new Font("Segoe UI", 8f);

            Series seriesCK = new Series("Điểm CK");
            seriesCK.ChartType = SeriesChartType.Column;
            seriesCK.Color = Color.FromArgb(40, 167, 69);
            seriesCK.IsValueShownAsLabel = true;
            seriesCK.Font = new Font("Segoe UI", 8f);

            foreach (DataRow row in dtScore.Rows)
            {
                string ten = row["Tên Môn"].ToString();
                if (ten.Length > 12) ten = ten.Substring(0, 12) + "...";
                double qt = row["Điểm QT"] == DBNull.Value ? 0 : Convert.ToDouble(row["Điểm QT"]);
                double ck = row["Điểm CK"] == DBNull.Value ? 0 : Convert.ToDouble(row["Điểm CK"]);
                seriesQT.Points.AddXY(ten, qt);
                seriesCK.Points.AddXY(ten, ck);
            }

            chartScore.Series.Add(seriesQT);
            chartScore.Series.Add(seriesCK);
            chartScore.ChartAreas[0].AxisY.Maximum = 10;
            chartScore.ChartAreas[0].AxisY.Minimum = 0;
            chartScore.ChartAreas[0].AxisX.Interval = 1;
            chartScore.ChartAreas[0].BackColor = Color.WhiteSmoke;
            chartScore.BackColor = Color.White;
            chartScore.Legends[0].Font = new Font("Segoe UI", 9f);
        }

        // ===================================================================
        // HIỂN THỊ KẾT QUẢ AI (form tùy chỉnh thay vì MessageBox)
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

            // Header panel
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
                Size = new System.Drawing.Size(620, 28),
                AutoSize = false
            };
            pnlHead.Controls.Add(lblHead);

            // RichTextBox nội dung
            RichTextBox rtb = new RichTextBox
            {
                Text = content,
                Font = new Font("Segoe UI", 10F),
                Location = new System.Drawing.Point(15, 65),
                Size = new System.Drawing.Size(655, 420),
                ReadOnly = true,
                BackColor = Color.FromArgb(248, 250, 252),
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            // Nút OK
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
            btnOK.Click += (s, e) => frmResult.Close();

            frmResult.Controls.Add(pnlHead);
            frmResult.Controls.Add(rtb);
            frmResult.Controls.Add(btnOK);
            using (frmResult) frmResult.ShowDialog(this);
        }

        // ===================================================================
        // NÚT XEM ĐIỂM
        // ===================================================================
        private void btnXemDiem_Click_1(object sender, EventArgs e)
        {
            string mssv = txtMSSV.Text.Trim();
            if (string.IsNullOrEmpty(mssv))
            {
                MessageBox.Show("Vui lòng nhập MSSV!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadScoreData(mssv);
        }

        // ===================================================================
        // NÚT IN TRỰC TIẾP
        // ===================================================================
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            System.Drawing.Printing.PrintDocument doc =
                new System.Drawing.Printing.PrintDocument();

            doc.PrintPage += (s, ev) =>
            {
                Graphics g = ev.Graphics;
                Font fontH = new Font("Segoe UI", 12f, FontStyle.Bold);
                Font fontN = new Font("Segoe UI", 9f);
                Brush brush = Brushes.Black;
                int y = 20;

                g.DrawString("BẢNG ĐIỂM SINH VIÊN", fontH, brush, 200, y); y += 30;
                g.DrawString($"MSSV: {txtMSSV.Text}   Họ tên: {txtFname.Text} {txtLname.Text}", fontN, brush, 20, y); y += 20;
                g.DrawString($"{lblDiemTB.Text}   {lblTongTC.Text}   {lblXepLoai.Text}", fontN, brush, 20, y); y += 30;

                string[] headers = { "Mã MH", "Tên Môn", "Số TC", "QT", "CK", "TK", "Ghi Chú" };
                int[] widths = { 70, 160, 50, 50, 50, 50, 100 };
                int x = 20;
                for (int i = 0; i < headers.Length; i++)
                {
                    g.DrawString(headers[i], new Font("Segoe UI", 9f, FontStyle.Bold), brush, x, y);
                    x += widths[i];
                }
                y += 20;

                if (dtScore != null)
                {
                    foreach (DataRow row in dtScore.Rows)
                    {
                        x = 20;
                        string[] vals = {
                            row["Mã MH"].ToString(), row["Tên Môn"].ToString(),
                            row["Số TC"].ToString(),  row["Điểm QT"].ToString(),
                            row["Điểm CK"].ToString(),row["Điểm TK"].ToString(),
                            row["Ghi Chú"]?.ToString() ?? ""
                        };
                        for (int i = 0; i < vals.Length; i++)
                        {
                            g.DrawString(vals[i], fontN, brush, x, y);
                            x += widths[i];
                        }
                        y += 18;
                    }
                }
            };

            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK) doc.Print();
        }

        // ===================================================================
        // NÚT LƯU WORD
        // ===================================================================
        private void btnLuuWord_Click_1(object sender, EventArgs e)
        {
            if (dtScore == null || dtScore.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu điểm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Word Document|*.docx",
                FileName = $"BangDiem_{txtMSSV.Text}_{DateTime.Now:yyyyMMdd}.docx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var scoreList = new List<Dictionary<string, object>>();
                foreach (DataRow row in dtScore.Rows)
                {
                    scoreList.Add(new Dictionary<string, object>
                    {
                        { "MaMH",   row["Mã MH"].ToString()   },
                        { "TenMH",  row["Tên Môn"].ToString()  },
                        { "SoTC",   row["Số TC"].ToString()    },
                        { "DiemQT", row["Điểm QT"].ToString()  },
                        { "DiemCK", row["Điểm CK"].ToString()  },
                        { "DiemTK", row["Điểm TK"].ToString()  },
                        { "Mota",   row["Ghi Chú"]?.ToString() ?? "" }
                    });
                }

                var value = new Dictionary<string, object>
                {
                    { "Fname",   txtFname.Text   },
                    { "Lname",   txtLname.Text   },
                    { "Mssv",    txtMSSV.Text    },
                    { "DTB",     lblDiemTB.Text  },
                    { "SOTC",    lblTongTC.Text  },
                    { "XEPLOAI", lblXepLoai.Text },
                    { "ky_ten",  "Trưởng Khoa Công Nghệ Thông Tin" },
                    { "Score",   scoreList       }
                };

                string templatePath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "Templates", "BangDiem.docx");

                if (File.Exists(templatePath))
                    MiniWord.SaveAsByTemplate(sfd.FileName, templatePath, value);
                else
                    TaoWordKhongTemplate(sfd.FileName);

                MessageBox.Show("Xuất file Word thành công!\n" + sfd.FileName,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Word: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaoWordKhongTemplate(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><body>");
            sb.AppendLine($"<h2 style='text-align:center'>BẢNG ĐIỂM SINH VIÊN</h2>");
            sb.AppendLine($"<p><b>MSSV:</b> {txtMSSV.Text} &nbsp;&nbsp;<b>Họ tên:</b> {txtFname.Text} {txtLname.Text}</p>");
            sb.AppendLine($"<p>{lblDiemTB.Text} &nbsp;|&nbsp; {lblTongTC.Text} &nbsp;|&nbsp; {lblXepLoai.Text}</p>");
            sb.AppendLine("<table border='1' cellpadding='4' style='border-collapse:collapse;width:100%'>");
            sb.AppendLine("<tr style='background:#003D95;color:white'><th>Mã MH</th><th>Tên Môn</th><th>Số TC</th><th>Điểm QT</th><th>Điểm CK</th><th>Điểm TK</th><th>Ghi Chú</th></tr>");
            if (dtScore != null)
            {
                foreach (DataRow row in dtScore.Rows)
                    sb.AppendLine($"<tr><td>{row["Mã MH"]}</td><td>{row["Tên Môn"]}</td><td>{row["Số TC"]}</td><td>{row["Điểm QT"]}</td><td>{row["Điểm CK"]}</td><td>{row["Điểm TK"]}</td><td>{row["Ghi Chú"]}</td></tr>");
            }
            sb.AppendLine("</table>");
            sb.AppendLine("<p style='text-align:right;margin-top:40px'><b>Trưởng Khoa Công Nghệ Thông Tin</b></p>");
            sb.AppendLine("</body></html>");
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        // ===================================================================
        // [AI] NHẬN XÉT HỌC LỰC
        // ===================================================================
        private async void btnAINhanXet_Click_1(object sender, EventArgs e)
        {
            if (dtScore == null || dtScore.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu điểm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAINhanXet.Enabled = false;
            btnAINhanXet.Text = "⏳ Đang phân tích...";

            try
            {
                string danhSachDiem = "";
                foreach (DataRow row in dtScore.Rows)
                    danhSachDiem += $"{row["Tên Môn"]}: QT={row["Điểm QT"]}, CK={row["Điểm CK"]}, TK={row["Điểm TK"]}; ";

                string ketQua = await AIGoiNhanXetAsync(
                    $"{txtFname.Text} {txtLname.Text}", danhSachDiem,
                    lblDiemTB.Text, lblXepLoai.Text);

                if (!string.IsNullOrEmpty(ketQua))
                    HienThiKetQuaAI("🤖 AI Nhận xét học lực", ketQua);
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
                btnAINhanXet.Enabled = true;
                btnAINhanXet.Text = "🤖 AI Nhận xét";
            }
        }

        // ===================================================================
        // [AI] GỢI Ý MÔN HỌC KỲ TỚI
        // ===================================================================
        private async void btnAIGoiY_Click_1(object sender, EventArgs e)
        {
            if (dtScore == null || dtScore.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu điểm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnAIGoiY.Enabled = false;
            btnAIGoiY.Text = "⏳ Đang phân tích...";

            try
            {
                string monChuaHoc = await LayMonChuaHocAsync(txtMSSV.Text.Trim());
                string diemHienTai = "";
                foreach (DataRow row in dtScore.Rows)
                    diemHienTai += $"{row["Tên Môn"]}: {row["Điểm TK"]}; ";

                string ketQua = await AIGoiYMonHocKyToiAsync(
                    diemHienTai, monChuaHoc, lblXepLoai.Text);

                if (!string.IsNullOrEmpty(ketQua))
                    HienThiKetQuaAI("📅 AI Gợi ý môn học kỳ tới", ketQua);
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
                btnAIGoiY.Enabled = true;
                btnAIGoiY.Text = "📅 AI Gợi ý môn";
            }
        }

        private async Task<string> LayMonChuaHocAsync(string mssv)
        {
            try
            {
                My_DB tempDb = new My_DB();
                tempDb.openConnection();
                string query = "SELECT TenMH FROM Course WHERE MaMH NOT IN (SELECT MaMH FROM Score WHERE MSSV = @mssv)";
                SqlCommand cmd = new SqlCommand(query, tempDb.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                tempDb.closeConnection();

                var sb = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                    sb.Append(row["TenMH"].ToString() + ", ");
                return sb.ToString().TrimEnd(',', ' ');
            }
            catch { return "Không lấy được danh sách môn"; }
        }

        private async Task<string> AIGoiYMonHocKyToiAsync(
            string diemHienTai, string monChuaHoc, string xepLoai)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(60);
                string prompt =
                    $"Dựa trên kết quả học tập sau của sinh viên:\n" +
                    $"Điểm: {diemHienTai}\n" +
                    $"Xếp loại: {xepLoai}\n" +
                    $"Môn chưa học: {monChuaHoc}\n\n" +
                    $"Hãy liệt kê ngắn gọn 3-5 môn nên đăng ký kỳ tới theo định dạng:\n" +
                    $"1. [Tên môn]: [Lý do 1 câu]\n" +
                    $"2. [Tên môn]: [Lý do 1 câu]\n" +
                    $"...\n" +
                    $"KHÔNG viết lời chào, KHÔNG giải thích dài dòng. Chỉ liệt kê danh sách. Tiếng Việt.";

                var payload = new
                {
                    contents = new[] { new { role = "user", parts = new[] { new { text = prompt } } } },
                    generationConfig = new { temperature = 0.5, maxOutputTokens = 1500 }
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

        private async Task<string> AIGoiNhanXetAsync(
            string tenSV, string danhSachDiem, string diemTB, string xepLoai)
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(60);
                string prompt =
                    $"Sinh viên {tenSV} có kết quả học tập:\n{danhSachDiem}\n" +
                    $"{diemTB}, {xepLoai}\n" +
                    $"Hãy viết nhận xét ngắn gọn (3-5 câu, tiếng Việt) về học lực, " +
                    $"chỉ ra môn học tốt, môn cần cải thiện và lời khuyên cụ thể.";

                var payload = new
                {
                    contents = new[] { new { role = "user", parts = new[] { new { text = prompt } } } },
                    generationConfig = new { temperature = 0.7, maxOutputTokens = 1000 }
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

        private void btnBack_Click(object sender, EventArgs e) { }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlInput, 25, e);
        }

    }
}