using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_Main : Form
    {
        private int _position;
        private TextBox txtChat;
        private Panel pnlChatHistory;

        public f_Main(int position)
        {
            InitializeComponent();
            _position = position;
            ApplyHCMUTEStyle();
        }

        private void ApplyHCMUTEStyle()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new Size(900, 600);
            this.Size = new Size(900, 600);
            this.Resize += (s, e) => this.Region = null;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản lý Sinh viên - HCMUTE";
            this.Controls.Clear();

            Panel header = new Panel();
            header.Size = new Size(900, 70);
            header.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            header.Location = new Point(0, 0);
            header.BackColor = Color.FromArgb(0, 48, 135);
            this.Controls.Add(header);

            PictureBox logo = new PictureBox();
            logo.Size = new Size(50, 50);
            logo.Location = new Point(10, 10);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.BackColor = Color.Transparent;
            try
            {
                var stream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("QuanLySinhVien.logo_hcmute.png");
                if (stream != null) logo.Image = Image.FromStream(stream);
            }
            catch { }
            header.Controls.Add(logo);

            Label lblSystem = new Label();
            lblSystem.Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
            lblSystem.Font = new Font("Arial", 14, FontStyle.Bold);
            lblSystem.ForeColor = Color.White;
            lblSystem.AutoSize = false;
            lblSystem.Size = new Size(500, 40);
            lblSystem.Location = new Point(70, 15);
            lblSystem.TextAlign = ContentAlignment.MiddleLeft;
            header.Controls.Add(lblSystem);

            Label lblUser = new Label();
            lblUser.Text = "Xin chào, " + Globals.GlobalUserName;
            lblUser.Font = new Font("Arial", 9);
            lblUser.ForeColor = Color.FromArgb(200, 220, 255);
            lblUser.AutoSize = false;
            lblUser.Size = new Size(250, 25);
            lblUser.Location = new Point(620, 25);
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            header.Controls.Add(lblUser);

            Panel sidebar = new Panel();
            sidebar.Size = new Size(200, 530);
            sidebar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            sidebar.Location = new Point(0, 70);
            sidebar.BackColor = Color.FromArgb(20, 60, 120);
            this.Controls.Add(sidebar);

            string[] menuNames = { "Thêm Sinh viên", "Danh sách SV", "Sửa / Xóa SV" };
            EventHandler[] menuActions = {
                (s, e) => { this.Hide(); new f_AddStudent().ShowDialog(); this.Show(); },
                (s, e) => { this.Hide(); new f_ListStudent().ShowDialog(); this.Show(); },
                (s, e) => { this.Hide(); new f_EditDeleteStudent().ShowDialog(); this.Show(); }
            };

            for (int i = 0; i < menuNames.Length; i++)
            {
                Button btn = new Button();
                btn.Text = menuNames[i];
                btn.Font = new Font("Arial", 10);
                btn.ForeColor = Color.White;
                btn.BackColor = Color.Transparent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 48, 135);
                btn.Size = new Size(200, 50);
                btn.Location = new Point(0, 20 + i * 55);
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(15, 0, 0, 0);
                btn.Cursor = Cursors.Hand;
                btn.Click += menuActions[i];
                sidebar.Controls.Add(btn);
            }

            if (_position != 1)
            {
                Button btnAdmin = new Button();
                btnAdmin.Text = "Quản lý tài khoản";
                btnAdmin.Font = new Font("Arial", 10);
                btnAdmin.ForeColor = Color.White;
                btnAdmin.BackColor = Color.Transparent;
                btnAdmin.FlatStyle = FlatStyle.Flat;
                btnAdmin.FlatAppearance.BorderSize = 0;
                btnAdmin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 48, 135);
                btnAdmin.Size = new Size(200, 50);
                btnAdmin.Location = new Point(0, 20 + 3 * 55);
                btnAdmin.TextAlign = ContentAlignment.MiddleLeft;
                btnAdmin.Padding = new Padding(15, 0, 0, 0);
                btnAdmin.Cursor = Cursors.Hand;
                sidebar.Controls.Add(btnAdmin);
            }

            Button btnLogout = new Button();
            btnLogout.Text = "Đăng xuất";
            btnLogout.Font = new Font("Arial", 10);
            btnLogout.ForeColor = Color.FromArgb(255, 100, 100);
            btnLogout.BackColor = Color.Transparent;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, 30, 30);
            btnLogout.Size = new Size(200, 50);
            btnLogout.Location = new Point(0, 460);
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.Padding = new Padding(15, 0, 0, 0);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Click += (s, e) => {
                Globals.ClearSession();
                new f_Login().Show();
                this.Close();
            };
            sidebar.Controls.Add(btnLogout);

            Panel dashboard = new Panel();
            dashboard.Size = new Size(680, 530);
            dashboard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            dashboard.Location = new Point(200, 70);
            dashboard.BackColor = Color.FromArgb(240, 242, 245);
            dashboard.AutoScroll = true;
            this.Controls.Add(dashboard);

            Label lblDash = new Label();
            lblDash.Text = "TỔNG QUAN HỆ THỐNG";
            lblDash.Font = new Font("Arial", 13, FontStyle.Bold);
            lblDash.ForeColor = Color.FromArgb(0, 48, 135);
            lblDash.AutoSize = false;
            lblDash.Size = new Size(660, 40);
            lblDash.Location = new Point(10, 15);
            lblDash.TextAlign = ContentAlignment.MiddleLeft;
            dashboard.Controls.Add(lblDash);

            AddStatCard(dashboard, "Tổng Sinh viên", GetCount("SELECT COUNT(*) FROM Student"),
                Color.FromArgb(0, 48, 135), 10, 70);
            AddStatCard(dashboard, "Chờ duyệt", GetCount("SELECT COUNT(*) FROM Login WHERE VALID=0"),
                Color.FromArgb(204, 0, 0), 230, 70);
            AddStatCard(dashboard, "Tài khoản HR", GetCount("SELECT COUNT(*) FROM HR WHERE VALID=1"),
                Color.FromArgb(0, 120, 60), 450, 70);

            LoadSmartAlerts(dashboard);
            LoadChatbot(dashboard);
        }

        private void AddStatCard(Panel parent, string title, string value, Color color, int x, int y)
        {
            Panel card = new Panel();
            card.Size = new Size(200, 100);
            card.Location = new Point(x, y);
            card.BackColor = Color.White;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 20, 20, 180, 90);
            path.AddArc(180, 0, 20, 20, 270, 90);
            path.AddArc(180, 80, 20, 20, 0, 90);
            path.AddArc(0, 80, 20, 20, 90, 90);
            path.CloseAllFigures();
            card.Region = new Region(path);

            Panel stripe = new Panel();
            stripe.Size = new Size(200, 8);
            stripe.Location = new Point(0, 0);
            stripe.BackColor = color;
            card.Controls.Add(stripe);

            Label lblVal = new Label();
            lblVal.Text = value;
            lblVal.Font = new Font("Arial", 24, FontStyle.Bold);
            lblVal.ForeColor = color;
            lblVal.AutoSize = false;
            lblVal.Size = new Size(200, 45);
            lblVal.Location = new Point(0, 15);
            lblVal.TextAlign = ContentAlignment.MiddleCenter;
            card.Controls.Add(lblVal);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Arial", 9);
            lblTitle.ForeColor = Color.Gray;
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(200, 25);
            lblTitle.Location = new Point(0, 65);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            card.Controls.Add(lblTitle);

            parent.Controls.Add(card);
        }

        private string GetCount(string query)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(query, db.conn);
                return cmd.ExecuteScalar().ToString();
            }
            catch { return "0"; }
            finally { db.closeConnection(); }
        }

        private void LoadSmartAlerts(Panel dashboard)
        {
            DataTable lowScore = Student.GetLowScoreStudents(5.0);
            if (lowScore.Rows.Count == 0) return;

            Panel alertPanel = new Panel();
            alertPanel.Size = new Size(640, 40 + lowScore.Rows.Count * 28 + 20);
            alertPanel.Location = new Point(10, 190);
            alertPanel.BackColor = Color.FromArgb(255, 243, 205);
            alertPanel.BorderStyle = BorderStyle.FixedSingle;

            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, 20, 20, 180, 90);
            gp.AddArc(alertPanel.Width - 20, 0, 20, 20, 270, 90);
            gp.AddArc(alertPanel.Width - 20, alertPanel.Height - 20, 20, 20, 0, 90);
            gp.AddArc(0, alertPanel.Height - 20, 20, 20, 90, 90);
            gp.CloseAllFigures();
            alertPanel.Region = new Region(gp);

            Label lblAlert = new Label();
            lblAlert.Text = "⚠️  CẢNH BÁO: " + lowScore.Rows.Count + " sinh viên có điểm TB < 5";
            lblAlert.Font = new Font("Arial", 10, FontStyle.Bold);
            lblAlert.ForeColor = Color.FromArgb(133, 77, 14);
            lblAlert.AutoSize = false;
            lblAlert.Size = new Size(620, 30);
            lblAlert.Location = new Point(10, 8);
            alertPanel.Controls.Add(lblAlert);

            for (int i = 0; i < lowScore.Rows.Count; i++)
            {
                DataRow row = lowScore.Rows[i];
                Label lblSV = new Label();
                lblSV.Text = string.Format("  • MSSV {0} — {1} {2} — Điểm TB: {3}",
                    row["MSSV"], row["Fname"], row["Lname"], row["DiemTB"]);
                lblSV.Font = new Font("Arial", 9);
                lblSV.ForeColor = Color.FromArgb(133, 77, 14);
                lblSV.AutoSize = false;
                lblSV.Size = new Size(620, 25);
                lblSV.Location = new Point(10, 40 + i * 28);
                alertPanel.Controls.Add(lblSV);
            }

            dashboard.Controls.Add(alertPanel);
        }

        private void LoadChatbot(Panel dashboard)
        {
            int alertHeight = Student.GetLowScoreStudents(5.0).Rows.Count > 0 ? 100 : 0;
            int chatY = 200 + alertHeight;

            Label lblChat = new Label();
            lblChat.Text = "🤖 Trợ lý hệ thống";
            lblChat.Font = new Font("Arial", 10, FontStyle.Bold);
            lblChat.ForeColor = UIHelper.PrimaryBlue;
            lblChat.AutoSize = false;
            lblChat.Size = new Size(640, 25);
            lblChat.Location = new Point(10, chatY);
            dashboard.Controls.Add(lblChat);

            pnlChatHistory = new Panel();
            pnlChatHistory.Size = new Size(640, 110);
            pnlChatHistory.Location = new Point(10, chatY + 28);
            pnlChatHistory.BackColor = Color.White;
            pnlChatHistory.BorderStyle = BorderStyle.FixedSingle;
            pnlChatHistory.AutoScroll = true;
            dashboard.Controls.Add(pnlChatHistory);

            AddChatMessage("Bot", "Xin chào! Hỏi tôi bất kỳ điều gì:\n\"thêm SV\", \"danh sách\", \"điểm thấp\"...", UIHelper.PrimaryBlue);

            txtChat = UIHelper.CreateTextBox(10, chatY + 148, 540);
            txtChat.ForeColor = Color.Black;
            txtChat.KeyPress += (s, e) => {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    string msg = txtChat.Text.Trim();
                    if (!string.IsNullOrEmpty(msg))
                        ProcessChat(msg);
                }
            };
            dashboard.Controls.Add(txtChat);

            var btnSend = UIHelper.CreatePrimaryButton("Gửi", 558, chatY + 145, 80, 32);
            btnSend.Click += (s, e) => {
                string msg = txtChat.Text.Trim();
                if (!string.IsNullOrEmpty(msg))
                    ProcessChat(msg);
            };
            dashboard.Controls.Add(btnSend);
        }

        private void AddChatMessage(string sender, string message, Color color)
        {
            int lineCount = message.Split('\n').Length;
            Label lbl = new Label();
            lbl.Text = "[" + sender + "]: " + message;
            lbl.Font = new Font("Arial", 9);
            lbl.ForeColor = color;
            lbl.AutoSize = false;
            lbl.Size = new Size(610, lineCount * 18 + 8);
            lbl.Location = new Point(5, pnlChatHistory.Controls.Count * 30);
            lbl.TextAlign = ContentAlignment.TopLeft;
            pnlChatHistory.Controls.Add(lbl);
            pnlChatHistory.ScrollControlIntoView(lbl);
        }

        private void ProcessChat(string input)
        {
            if (string.IsNullOrEmpty(input)) return;

            AddChatMessage("Bạn", input, Color.FromArgb(60, 60, 60));
            txtChat.Clear();

            // Chuẩn hóa — xóa dấu tiếng Việt để so sánh
            string msg = input.ToLower()
                .Replace("à", "a").Replace("á", "a").Replace("â", "a").Replace("ã", "a")
                .Replace("ă", "a").Replace("ắ", "a").Replace("ặ", "a").Replace("ằ", "a")
                .Replace("ẩ", "a").Replace("ấ", "a").Replace("ầ", "a").Replace("ậ", "a")
                .Replace("ả", "a").Replace("ạ", "a")
                .Replace("è", "e").Replace("é", "e").Replace("ê", "e").Replace("ẹ", "e")
                .Replace("ề", "e").Replace("ế", "e").Replace("ệ", "e").Replace("ể", "e")
                .Replace("ẻ", "e").Replace("ẽ", "e").Replace("ễ", "e")
                .Replace("ì", "i").Replace("í", "i").Replace("ị", "i").Replace("ỉ", "i").Replace("ĩ", "i")
                .Replace("ò", "o").Replace("ó", "o").Replace("ô", "o").Replace("ơ", "o")
                .Replace("ớ", "o").Replace("ợ", "o").Replace("ồ", "o").Replace("ố", "o")
                .Replace("ộ", "o").Replace("ổ", "o").Replace("ọ", "o").Replace("ỏ", "o")
                .Replace("ỗ", "o").Replace("ờ", "o").Replace("ở", "o").Replace("ỡ", "o")
                .Replace("ù", "u").Replace("ú", "u").Replace("ư", "u").Replace("ứ", "u")
                .Replace("ự", "u").Replace("ừ", "u").Replace("ử", "u").Replace("ụ", "u")
                .Replace("ủ", "u").Replace("ũ", "u").Replace("ữ", "u")
                .Replace("ỳ", "y").Replace("ý", "y").Replace("ỵ", "y").Replace("ỷ", "y").Replace("ỹ", "y")
                .Replace("đ", "d");

            if (msg.Contains("them") || msg.Contains("add") || msg.Contains("tao") || msg.Contains("moi sv") || msg.Contains("sinh vien moi"))
            {
                AddChatMessage("Bot", "Đang mở form Thêm Sinh viên...", UIHelper.PrimaryBlue);
                System.Threading.Tasks.Task.Delay(500).ContinueWith(_ =>
                    this.Invoke((Action)(() => { this.Hide(); new f_AddStudent().ShowDialog(); this.Show(); })));
            }
            else if (msg.Contains("danh sach") || msg.Contains("danh") || msg.Contains("list") || msg.Contains("xem sv") || msg.Contains("tat ca"))
            {
                AddChatMessage("Bot", "Đang mở Danh sách Sinh viên...", UIHelper.PrimaryBlue);
                System.Threading.Tasks.Task.Delay(500).ContinueWith(_ =>
                    this.Invoke((Action)(() => { this.Hide(); new f_ListStudent().ShowDialog(); this.Show(); })));
            }
            else if (msg.Contains("sua") || msg.Contains("xoa") || msg.Contains("edit") || msg.Contains("delete") || msg.Contains("cap nhat") || msg.Contains("chinh sua"))
            {
                AddChatMessage("Bot", "Đang mở form Sửa / Xóa Sinh viên...", UIHelper.PrimaryBlue);
                System.Threading.Tasks.Task.Delay(500).ContinueWith(_ =>
                    this.Invoke((Action)(() => { this.Hide(); new f_EditDeleteStudent().ShowDialog(); this.Show(); })));
            }
            else if (msg.Contains("diem") || msg.Contains("score") || msg.Contains("kem") || msg.Contains("thap") || msg.Contains("yeu"))
            {
                DataTable low = Student.GetLowScoreStudents(5.0);
                if (low.Rows.Count == 0)
                    AddChatMessage("Bot", "✅ Không có sinh viên nào có điểm TB < 5.", UIHelper.PrimaryBlue);
                else
                {
                    string res = "⚠️ Có " + low.Rows.Count + " SV điểm TB < 5:\n";
                    foreach (DataRow r in low.Rows)
                        res += "• " + r["Fname"] + " " + r["Lname"] + " — TB: " + r["DiemTB"] + "\n";
                    AddChatMessage("Bot", res.TrimEnd(), UIHelper.PrimaryBlue);
                }
            }
            else if (msg.Contains("thong ke") || msg.Contains("tong") || msg.Contains("bao cao") || msg.Contains("so lieu") || msg.Contains("thong tin"))
            {
                string sv = GetCount("SELECT COUNT(*) FROM Student");
                string cho = GetCount("SELECT COUNT(*) FROM Login WHERE VALID=0");
                AddChatMessage("Bot", "📊 Thống kê:\n• Tổng SV: " + sv + "\n• Chờ duyệt: " + cho, UIHelper.PrimaryBlue);
            }
            else if (msg.Contains("chao") || msg.Contains("hello") || msg.Contains("hi") || msg.Contains("xin chao"))
            {
                AddChatMessage("Bot", "Xin chào " + Globals.GlobalUserName + "! Tôi có thể giúp gì?", UIHelper.PrimaryBlue);
            }
            else
            {
                AddChatMessage("Bot", "❓ Tôi chưa hiểu. Thử:\n\"thêm SV\", \"danh sách\", \"sửa xóa\", \"điểm thấp\", \"thống kê\"",
                    Color.FromArgb(150, 0, 0));
            }
        }
    }
}