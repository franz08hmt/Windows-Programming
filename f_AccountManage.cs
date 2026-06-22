using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_AccountManage : UserControl
    {
        // _split, dgvApproved, btnAI đã được khai báo trong Designer.cs
        private bool _splitterSet = false;

        // Gmail SMTP — xóa trước khi push GitHub
        private const string SMTP_FROM = "taihuynhjg249@gmail.com";
        private const string SMTP_PASS = "dglk qqcf ughh yief";

        // Gemini API key — xóa trước khi push GitHub
        private const string GEMINI_KEY = "";

        public f_AccountManage()
        {
            InitializeComponent();
            BuildSplitLayout();
        }

        // ── Bổ sung label section và style cho _split đã có trong Designer ──
        private void BuildSplitLayout()
        {
            // Tách DGV ra để wrap vào TableLayoutPanel có label
            _split.Panel1.Controls.Remove(dgvAccounts);
            _split.Panel2.Controls.Remove(dgvApproved);

            var lblPend = MakeSectionLabel("⏳  CHỜ DUYỆT", Color.FromArgb(200, 70, 0));
            var lblAppr = MakeSectionLabel("✅  ĐÃ DUYỆT", Color.FromArgb(0, 110, 50));

            var tlp1 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Padding = Padding.Empty, Margin = Padding.Empty
            };
            tlp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tlp1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            tlp1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            dgvAccounts.Dock = DockStyle.Fill;
            tlp1.Controls.Add(lblPend, 0, 0);
            tlp1.Controls.Add(dgvAccounts, 0, 1);
            _split.Panel1.Controls.Add(tlp1);

            var tlp2 = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                Padding = Padding.Empty, Margin = Padding.Empty
            };
            tlp2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tlp2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
            tlp2.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            dgvApproved.Dock = DockStyle.Fill;
            tlp2.Controls.Add(lblAppr, 0, 0);
            tlp2.Controls.Add(dgvApproved, 0, 1);
            _split.Panel2.Controls.Add(tlp2);

            dgvApproved.DoubleClick += dgvApproved_DoubleClick;

            // Wire nút AI (đã có trong Designer, chỉ gán handler)
            btnAI.Click += async (s, e) => await ScanFakeAccountsAsync();

            // Nút Mở khóa — chỉ Admin thấy
            if (Globals.GlobalPosition == 0)
            {
                var btnUnlock = new Button
                {
                    Text      = "🔓 Mở khóa",
                    Location  = new Point(403, 9),
                    Size      = new Size(130, 75),
                    BackColor = Color.FromArgb(180, 60, 0),
                    ForeColor = Color.White,
                    Font      = new Font("Segoe UI", 10, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Cursor    = Cursors.Hand
                };
                btnUnlock.FlatAppearance.BorderSize = 0;
                btnUnlock.Click += BtnUnlock_Click;
                pnlTop.Controls.Add(btnUnlock);
            }

            // Đặt SplitterDistance ngay khi _split có kích thước thực
            // SizeChanged đáng tin hơn BeginInvoke vì fire đúng lúc layout hoàn tất
            _split.SizeChanged += (ss, ee) =>
            {
                if (!_splitterSet && _split.Height > 100)
                {
                    _splitterSet = true;
                    _split.SplitterDistance = Math.Max(150, (int)(_split.Height * 0.38));
                }
            };
        }

        private static Label MakeSectionLabel(string text, Color color) =>
            new Label
            {
                Text = text,
                Dock = DockStyle.Fill,    // Fill the fixed-height TLP row
                Height = 30,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = color,
                BackColor = Color.FromArgb(228, 236, 250),  // light blue band, clearly visible
                Padding = new Padding(8, 5, 0, 0),
                TextAlign = ContentAlignment.MiddleLeft
            };

        // ── Load ───────────────────────────────────────────────────────────
        private void f_AccountManage_Load(object sender, EventArgs e)
        {
            LoadAllGrids();
        }

        private void LoadAllGrids()
        {
            LoadPendingGrid();
            LoadApprovedGrid();
            UpdateStatusCount();
        }

        private void LoadPendingGrid()
        {
            var dt = QueryAccounts("WHERE VALID=0");
            dgvAccounts.DataSource = dt;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.ReadOnly = true;
            dgvAccounts.AllowUserToAddRows = false;
            // Áp dụng style header xanh giống dgvApproved
            dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 61, 149);
            dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAccounts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.RowTemplate.Height = 32;
            dgvAccounts.BackgroundColor = Color.White;
            dgvAccounts.BorderStyle = BorderStyle.None;
        }

        private void LoadApprovedGrid()
        {
            var dt = QueryAccounts("WHERE VALID=1");
            dgvApproved.DataSource = dt;
            dgvApproved.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApproved.ReadOnly = true;
            dgvApproved.AllowUserToAddRows = false;
            dgvApproved.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 61, 149);
            dgvApproved.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvApproved.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvApproved.EnableHeadersVisualStyles = false;
            dgvApproved.RowTemplate.Height = 32;
            dgvApproved.BackgroundColor = Color.White;
            dgvApproved.BorderStyle = BorderStyle.None;
        }

        // Truy vấn Login với cột bổ sung Loại TK, bỏ ảnh để tránh lỗi UI
        private DataTable QueryAccounts(string whereClause)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string sql = $@"
                    SELECT MSGV, Fname, Lname, Username, Email,
                        CASE position
                            WHEN 0 THEN N'Admin'
                            WHEN 1 THEN N'Sinh viên'
                            ELSE N'HR / Giảng viên'
                        END AS [Loại TK]
                    FROM Login {whereClause}
                    ORDER BY MSGV";
                var dt = new DataTable();
                new SqlDataAdapter(sql, db.conn).Fill(dt);
                VietnameseTextHelper.NormalizeColumns(dt, "Fname", "Lname");
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
            finally { db.closeConnection(); }
        }

        private void UpdateStatusCount()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                int pending = Convert.ToInt32(new SqlCommand(
                    "SELECT COUNT(*) FROM Login WHERE VALID=0", db.conn).ExecuteScalar());
                int approved = Convert.ToInt32(new SqlCommand(
                    "SELECT COUNT(*) FROM Login WHERE VALID=1", db.conn).ExecuteScalar());
                lblPending.Text = $"Chờ duyệt: {pending}";
                lblApproved.Text = $"Đã duyệt: {approved}";
            }
            catch { }
            finally { db.closeConnection(); }
        }

        // ── Lấy MSGV và Email từ hàng đang chọn ───────────────────────────
        private string GetSelectedMSGV(DataGridView dgv = null)
        {
            var src = dgv ?? dgvAccounts;
            return src.CurrentRow?.Cells["MSGV"].Value?.ToString();
        }

        private string GetSelectedEmail(DataGridView dgv = null)
        {
            var src = dgv ?? dgvAccounts;
            return src.CurrentRow?.Cells["Email"].Value?.ToString() ?? "";
        }

        private string GetSelectedName(DataGridView dgv = null)
        {
            var src = dgv ?? dgvAccounts;
            if (src.CurrentRow == null) return "";
            string fname = src.CurrentRow.Cells["Fname"].Value?.ToString() ?? "";
            string lname = src.CurrentRow.Cells["Lname"].Value?.ToString() ?? "";
            return $"{lname} {fname}".Trim();
        }

        private bool IsAdmin(DataGridView dgv = null)
        {
            var src = dgv ?? dgvAccounts;
            return src.CurrentRow?.Cells["Loại TK"].Value?.ToString() == "Admin";
        }

        // ── Nút Duyệt ─────────────────────────────────────────────────────
        private async void btnApprove_Click_1(object sender, EventArgs e)
        {
            string msgv = GetSelectedMSGV();
            if (string.IsNullOrEmpty(msgv)) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }

            string ten = GetSelectedName();
            string email = GetSelectedEmail();

            var ok = MessageBox.Show($"Duyệt tài khoản [{ten}]?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok != DialogResult.Yes) return;

            if (UpdateValid(msgv, 1))
            {
                MessageBox.Show("Duyệt tài khoản thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllGrids();

                // Gửi email thông báo bất đồng bộ — không chặn UI
                if (!string.IsNullOrWhiteSpace(email))
                    await SendApprovalEmailAsync(email, ten);
            }
            else
                MessageBox.Show("Thao tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ── Nút Từ chối ───────────────────────────────────────────────────
        private void btnReject_Click_1(object sender, EventArgs e)
        {
            string msgv = GetSelectedMSGV();
            if (string.IsNullOrEmpty(msgv)) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }

            string ten = GetSelectedName();
            var ok = MessageBox.Show($"Từ chối tài khoản [{ten}]?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ok != DialogResult.Yes) return;

            if (UpdateValid(msgv, -1))
            {
                MessageBox.Show("Đã từ chối tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllGrids();
            }
            else
                MessageBox.Show("Thao tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // ── Nút Xóa — bảo vệ Admin & tài khoản đang đăng nhập ────────────
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            // Xác định DGV nào đang có selection (không dùng Focused vì click button làm mất focus)
            DataGridView activeDgv = dgvApproved.SelectedRows.Count > 0 ? dgvApproved : dgvAccounts;

            string msgv = GetSelectedMSGV(activeDgv);
            if (string.IsNullOrEmpty(msgv)) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }

            // Bảo vệ: không cho xóa Admin
            if (IsAdmin(activeDgv))
            {
                MessageBox.Show("Không thể xóa tài khoản Admin!", "Bảo mật",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Bảo vệ: không cho xóa tài khoản đang đăng nhập
            if (msgv == Globals.GlobalUserId)
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Bảo mật",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ten = GetSelectedName(activeDgv);
            var ok = MessageBox.Show($"Xóa vĩnh viễn tài khoản [{ten}]?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ok != DialogResult.Yes) return;

            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                var cmd = new SqlCommand("DELETE FROM Login WHERE MSGV=@msgv", db.conn);
                cmd.Parameters.AddWithValue("@msgv", msgv);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllGrids();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private bool UpdateValid(string msgv, int valid)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                var cmd = new SqlCommand("UPDATE Login SET VALID=@v WHERE MSGV=@m", db.conn);
                cmd.Parameters.AddWithValue("@v", valid);
                cmd.Parameters.AddWithValue("@m", msgv);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e) => LoadAllGrids();

        private void btnBack_Click(object sender, EventArgs e) { }

        // ── Nút Mở khóa (Admin only) ───────────────────────────────────────
        private void BtnUnlock_Click(object sender, EventArgs e)
        {
            DataGridView active = dgvApproved.SelectedRows.Count > 0 ? dgvApproved : dgvAccounts;
            string msgv = GetSelectedMSGV(active);
            if (string.IsNullOrEmpty(msgv))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần mở khóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string name = GetSelectedName(active);
            bool ok = LoginSecurityService.UnlockAccount(msgv);
            MessageBox.Show(ok
                ? $"Đã mở khóa tài khoản [{name}]!"
                : $"Tài khoản [{name}] không bị khóa hoặc có lỗi xảy ra.",
                "Kết quả", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        // ── Double-click vào danh sách đã duyệt → xem thông tin + quản lý ─
        private void dgvApproved_DoubleClick(object sender, EventArgs e)
        {
            string msgv = GetSelectedMSGV(dgvApproved);
            if (string.IsNullOrEmpty(msgv)) return;
            string name  = GetSelectedName(dgvApproved);
            string email = GetSelectedEmail(dgvApproved);

            bool canManage = msgv == Globals.GlobalUserId || Globals.GlobalPosition == 0;

            var dlg = new Form
            {
                Text            = "Thông tin tài khoản",
                Size            = new Size(380, canManage ? 290 : 200),
                StartPosition   = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox     = false, MinimizeBox = false
            };

            var info = new RichTextBox
            {
                Location    = new Point(15, 15), Size = new Size(338, 72),
                ReadOnly    = true, BorderStyle = BorderStyle.None, BackColor = dlg.BackColor,
                Text        = $"MSGV: {msgv}\nHọ tên: {name}\nEmail: {email}"
            };
            dlg.Controls.Add(info);

            if (canManage)
            {
                var btnFace = new Button
                {
                    Text      = "📷 Đăng ký khuôn mặt",
                    Location  = new Point(15, 100), Size = new Size(338, 38),
                    BackColor = Color.FromArgb(0, 120, 215), ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnFace.FlatAppearance.BorderSize = 0;
                btnFace.Click += (s, _) => { dlg.Close(); RegisterFaceForUser(msgv, name); };
                dlg.Controls.Add(btnFace);

                var btnUnlockLocal = new Button
                {
                    Text      = "🔓 Mở khóa tài khoản này",
                    Location  = new Point(15, 148), Size = new Size(338, 38),
                    BackColor = Color.FromArgb(180, 60, 0), ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };
                btnUnlockLocal.FlatAppearance.BorderSize = 0;
                btnUnlockLocal.Click += (s, _) =>
                {
                    LoginSecurityService.UnlockAccount(msgv);
                    MessageBox.Show($"Đã mở khóa [{name}]!", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dlg.Close();
                };
                dlg.Controls.Add(btnUnlockLocal);
            }

            var btnClose = new Button
            {
                Text         = "Đóng",
                Location     = new Point(15, canManage ? 196 : 100),
                Size         = new Size(338, 38),
                DialogResult = DialogResult.Cancel
            };
            dlg.Controls.Add(btnClose);
            dlg.CancelButton = btnClose;
            dlg.ShowDialog(this);
        }

        private void RegisterFaceForUser(string msgv, string name)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title  = $"Chọn ảnh khuôn mặt cho: {name}";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    byte[] imgBytes = File.ReadAllBytes(ofd.FileName);
                    using (var db = new My_DB())
                    {
                        db.openConnection();
                        var cmd = new SqlCommand("UPDATE Login SET FacePhoto=@img WHERE MSGV=@id", db.conn);
                        cmd.Parameters.Add("@img", SqlDbType.VarBinary, -1).Value = imgBytes;
                        cmd.Parameters.AddWithValue("@id", msgv);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Đã đăng ký khuôn mặt cho [{name}]!\nTài khoản này có thể dùng đăng nhập khuôn mặt.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ── Gửi email thông báo sau khi duyệt (Gmail SMTP) ─────────────────
        private async Task SendApprovalEmailAsync(string toEmail, string name)
        {
            await Task.Run(() =>
            {
                try
                {
                    var smtp = new SmtpClient("smtp.gmail.com", 587)
                    {
                        EnableSsl = true,
                        Credentials = new NetworkCredential(SMTP_FROM, SMTP_PASS),
                        Timeout = 8000
                    };
                    var msg = new MailMessage(SMTP_FROM, toEmail)
                    {
                        Subject = "Tài khoản đã được phê duyệt — HCMUTE",
                        IsBodyHtml = true,
                        Body = EmailHelper.BuildApprovalHtml(name, toEmail, toEmail.Split('@')[0])
                    };
                    smtp.Send(msg);
                }
                catch { /* Lỗi gửi email không nên làm crash app */ }
            });
        }

        // ── AI quét tài khoản giả / bất thường (Gemini) ────────────────────
        private async Task ScanFakeAccountsAsync()
        {
            if (dgvAccounts.Rows.Count == 0)
            {
                MessageBox.Show("Không có tài khoản chờ duyệt để quét.", "Thông báo");
                return;
            }

            // Thu thập danh sách pending
            var sb = new StringBuilder();
            foreach (DataGridViewRow row in dgvAccounts.Rows)
            {
                if (row.IsNewRow) continue;
                string m = row.Cells["MSGV"].Value?.ToString() ?? "";
                string fn = row.Cells["Fname"].Value?.ToString() ?? "";
                string ln = row.Cells["Lname"].Value?.ToString() ?? "";
                string em = row.Cells["Email"].Value?.ToString() ?? "";
                string role = row.Cells["Loại TK"].Value?.ToString() ?? "";
                sb.AppendLine($"MSGV={m}, Tên={ln} {fn}, Email={em}, Loại={role}");
            }

            string prompt =
                "Bạn là hệ thống bảo mật phân tích tài khoản người dùng của trường đại học.\n" +
                "Hãy phân tích danh sách tài khoản sau và xác định tài khoản nào có dấu hiệu bất thường " +
                "(email giả, tên vô nghĩa, MSGV không hợp lệ, v.v.).\n" +
                "Với mỗi tài khoản đáng ngờ, hãy liệt kê MSGV và lý do ngắn gọn.\n" +
                "Nếu không có tài khoản bất thường, hãy nói rõ là danh sách có vẻ hợp lệ.\n\n" +
                "Danh sách:\n" + sb;

            string result = await CallGeminiAsync(prompt);

            // Highlight hàng nghi ngờ nếu MSGV xuất hiện trong kết quả AI
            if (!string.IsNullOrEmpty(result))
            {
                foreach (DataGridViewRow row in dgvAccounts.Rows)
                {
                    if (row.IsNewRow) continue;
                    string msgv = row.Cells["MSGV"].Value?.ToString() ?? "";
                    if (result.Contains(msgv))
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 220);
                }
            }

            // Luôn hiển thị kết quả (kể cả khi có lỗi)
            ShowAIResult(string.IsNullOrEmpty(result)
                ? "❌ Không nhận được phản hồi từ AI.\n\nCó thể do:\n• API key chưa hợp lệ (cần key bắt đầu bằng 'AIzaSy...' từ Google AI Studio)\n• Mất kết nối mạng\n\nĐường link lấy key: https://aistudio.google.com/app/apikey"
                : result);
        }

        private async Task<string> CallGeminiAsync(string prompt)
        {
            try
            {
                using (var http = new HttpClient { Timeout = TimeSpan.FromSeconds(20) })
                {
                    string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-3.5-flash:generateContent?key={GEMINI_KEY}";
                    var body = new
                    {
                        contents = new[] { new { parts = new[] { new { text = prompt } } } }
                    };
                    var res = await http.PostAsync(url,
                        new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
                    string json = await res.Content.ReadAsStringAsync();
                    dynamic obj = JsonConvert.DeserializeObject(json);
                    // Lấy text từ response thành công
                    string text = obj?.candidates?[0]?.content?.parts?[0]?.text?.ToString();
                    if (!string.IsNullOrEmpty(text)) return text;
                    // Nếu API trả lỗi, lấy error message từ JSON
                    string errMsg = obj?.error?.message?.ToString();
                    return string.IsNullOrEmpty(errMsg) ? "" : "❌ Lỗi API: " + errMsg;
                }
            }
            catch (Exception ex)
            {
                return "Lỗi kết nối AI: " + ex.Message;
            }
        }

        private void ShowAIResult(string text)
        {
            var f = new Form
            {
                Text = "Kết quả quét AI",
                Size = new Size(720, 520),
                MinimumSize = new Size(480, 320),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.White,
                FormBorderStyle = FormBorderStyle.Sizable,
                MaximizeBox = true,
                MinimizeBox = false
            };
            var rtb = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Text = text,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };
            f.Controls.Add(rtb);
            using (f) f.ShowDialog(this);
        }

        private void btnAI_Click(object sender, EventArgs e)
        {

        }

    }
}
