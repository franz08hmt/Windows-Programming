using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

        private System.Windows.Forms.Button btnExportStatExcel;
        private readonly Timer chartAnimationTimer = new Timer();
        private readonly Dictionary<DataPoint, double> chartTargets = new Dictionary<DataPoint, double>();
        private double chartAnimationProgress;

        public f_Statistic()
        {
            InitializeComponent();
            AddExportButton();
            ConfigureChartAnimation();
            this.Resize += f_Statistic_Resize;
        }

        private void ConfigureChartAnimation()
        {
            chartAnimationTimer.Interval = 12;
            chartAnimationTimer.Tick += ChartAnimationTimer_Tick;
        }

        private void AddExportButton()
        {
            btnExportStatExcel = new System.Windows.Forms.Button();
            btnExportStatExcel.Text = "Xuất Excel thống kê";
            btnExportStatExcel.Size = new System.Drawing.Size(150, 34);
            btnExportStatExcel.BackColor = Color.FromArgb(40, 167, 69);
            btnExportStatExcel.ForeColor = Color.White;
            btnExportStatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExportStatExcel.FlatAppearance.BorderSize = 0;
            btnExportStatExcel.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            btnExportStatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnExportStatExcel.Click += new EventHandler(btnExportStatExcel_Click);
            // Đặt sau btnRefresh
            this.Load += (s, e) => {
                if (btnRefresh != null)
                {
                    btnExportStatExcel.Location = new System.Drawing.Point(
                        btnRefresh.Right + 8, btnRefresh.Top);
                    btnRefresh.Parent.Controls.Add(btnExportStatExcel);
                }
            };
        }

        private void btnExportStatExcel_Click(object sender, EventArgs e)
        {
            DataTable dtXepLoai = Score.GetCountByXepLoai();
            DataTable dtGender = GetGenderStats();
            ReportExportService.ExportStatisticsToExcel(dtXepLoai, dtGender);
        }

        private DataTable GetGenderStats()
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string q = "SELECT ISNULL(Gder, 'Khác') AS GioiTinh, COUNT(*) AS SoLuong FROM Student GROUP BY Gder";
                new System.Data.SqlClient.SqlDataAdapter(q, db.conn).Fill(dt);
            }
            catch { }
            finally { db.closeConnection(); }
            return dt;
        }

        private void f_Statistic_Load(object sender, EventArgs e)
        {
            LoadStatisticData();
            ApplyResponsiveLayout();
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
            EnsureStatisticSchemaAndDemoData();

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
            StartChartAnimation();
        }

        private void EnsureStatisticSchemaAndDemoData()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                new SqlCommand(@"
IF OBJECT_ID('dbo.Course', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Course (
        MaMH CHAR(20) PRIMARY KEY,
        TenMH NVARCHAR(100) NOT NULL,
        SoTC INT NOT NULL,
        Tuan INT NULL,
        Hky INT NULL,
        Mota NVARCHAR(MAX) NULL
    );
END", db.conn).ExecuteNonQuery();

                new SqlCommand(@"
IF OBJECT_ID('dbo.Score', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Score (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        MSSV INT NOT NULL,
        MaMH CHAR(20) NOT NULL,
        DiemQT DECIMAL(4,2) NOT NULL,
        DiemCK DECIMAL(4,2) NOT NULL,
        DiemTK DECIMAL(4,2) NOT NULL,
        XepLoai NVARCHAR(30) NULL,
        Mota NVARCHAR(250) NULL
    );
END", db.conn).ExecuteNonQuery();

                int studentCount = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM dbo.Student", db.conn).ExecuteScalar());
                if (studentCount == 0)
                {
                    InsertStudentSeed(db.conn, 22110001, "Nguyễn", "An", new DateTime(2004, 2, 14), "Nam", "0901000001", "TP HCM", "Bình Định", "an@sv.hcmute.edu.vn");
                    InsertStudentSeed(db.conn, 22110002, "Trần", "Bảo Ngọc", new DateTime(2004, 5, 9), "Nữ", "0901000002", "TP HCM", "Đồng Nai", "ngoc@sv.hcmute.edu.vn");
                    InsertStudentSeed(db.conn, 23110003, "Lê", "Minh Khang", new DateTime(2005, 1, 22), "Nam", "0901000003", "TP HCM", "Long An", "khang@sv.hcmute.edu.vn");
                    InsertStudentSeed(db.conn, 23110004, "Phạm", "Thanh Trúc", new DateTime(2005, 8, 18), "Nữ", "0901000004", "TP HCM", "Tây Ninh", "truc@sv.hcmute.edu.vn");
                    InsertStudentSeed(db.conn, 24110005, "Võ", "Gia Huy", new DateTime(2006, 4, 3), "Nam", "0901000005", "TP HCM", "Bến Tre", "huy@sv.hcmute.edu.vn");
                    InsertStudentSeed(db.conn, 24110006, "Đặng", "Khánh Linh", new DateTime(2006, 12, 2), "Nữ", "0901000006", "TP HCM", "Cần Thơ", "linh@sv.hcmute.edu.vn");
                    InsertStudentSeed(db.conn, 25110007, "Bùi", "Hoàng Phúc", new DateTime(2007, 6, 27), "Nam", "0901000007", "TP HCM", "Đà Nẵng", "phuc@sv.hcmute.edu.vn");
                    InsertStudentSeed(db.conn, 25110008, "Huỳnh", "Mai Chi", new DateTime(2007, 9, 15), "Khác", "0901000008", "TP HCM", "An Giang", "chi@sv.hcmute.edu.vn");
                }

                EnsureCourseSeed(db.conn, "CS101", "Lập trình C#", 3, 15, 1, "Nền tảng WinForms");
                EnsureCourseSeed(db.conn, "DB201", "Cơ sở dữ liệu", 3, 15, 1, "SQL Server");
                EnsureCourseSeed(db.conn, "WEB301", "Phát triển Web", 3, 15, 2, "ASP.NET");
                EnsureCourseSeed(db.conn, "AI401", "Nhập môn AI", 3, 15, 2, "Phân tích dữ liệu");

                EnsureBalancedDashboardData(db.conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khởi tạo dữ liệu thống kê: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void EnsureBalancedDashboardData(SqlConnection conn)
        {
            BalanceYearBuckets(conn, 18);
            EnsureScoresForExistingStudents(conn);
        }

        private void BalanceYearBuckets(SqlConnection conn, int targetPerYear)
        {
            int[] years = { 22, 23, 24, 25 };
            foreach (int year in years)
            {
                int current = GetStudentCountByYear(conn, year);
                int ordinal = 1;

                while (current < targetPerYear)
                {
                    int mssv = year * 1000000 + 880000 + ordinal;
                    while (StudentExists(conn, mssv))
                    {
                        ordinal++;
                        mssv = year * 1000000 + 880000 + ordinal;
                    }

                    string gender = PickGenderForBalance(conn, ordinal);
                    DashboardStudentSeed seed = new DashboardStudentSeed(
                        mssv,
                        PickLastName(ordinal),
                        PickFirstName(gender, ordinal),
                        new DateTime(2000 + year + 2, ((ordinal - 1) % 12) + 1, ((ordinal - 1) % 24) + 1),
                        gender,
                        BuildScoreProfile(ordinal));

                    EnsureStudentSeed(conn, seed);
                    EnsureScoreSet(conn, seed);
                    current++;
                    ordinal++;
                }
            }
        }

        private int GetStudentCountByYear(SqlConnection conn, int year)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Student WHERE LEFT(CAST(MSSV AS NVARCHAR(20)), 2) = @year", conn);
            cmd.Parameters.AddWithValue("@year", year.ToString("00"));
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private bool StudentExists(SqlConnection conn, int mssv)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Student WHERE MSSV = @mssv", conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private string PickGenderForBalance(SqlConnection conn, int ordinal)
        {
            int male = CountGender(conn, "Nam");
            int female = CountGender(conn, "Nữ");
            int other = CountGender(conn, "Khác");

            if (other * 8 < Math.Max(1, male + female + other)) return "Khác";
            if (female < male) return "Nữ";
            return ordinal % 2 == 0 ? "Nữ" : "Nam";
        }

        private int CountGender(SqlConnection conn, string gender)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Student WHERE Gder = @gender", conn);
            cmd.Parameters.AddWithValue("@gender", gender);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private string PickLastName(int ordinal)
        {
            string[] values = { "Nguyễn", "Trần", "Lê", "Phạm", "Võ", "Đặng", "Bùi", "Huỳnh", "Đỗ", "Ngô", "Mai", "Cao" };
            return values[(ordinal - 1) % values.Length];
        }

        private string PickFirstName(string gender, int ordinal)
        {
            string[] male = { "Hải Đăng", "Quốc Việt", "Gia Huy", "Tuấn Kiệt", "Minh Quân", "Nhật Minh", "Anh Khoa", "Hoàng Phúc" };
            string[] female = { "Mai Anh", "Minh Châu", "Khánh Linh", "Bảo Trâm", "Ngọc Hân", "Thảo Vy", "Thanh Trúc", "Mai Chi" };
            string[] other = { "Thanh Bình", "Minh An", "Gia Linh", "Bảo Khánh" };

            if (gender == "Khác") return other[(ordinal - 1) % other.Length];
            if (gender == "Nữ") return female[(ordinal - 1) % female.Length];
            return male[(ordinal - 1) % male.Length];
        }

        private decimal[] BuildScoreProfile(int ordinal)
        {
            decimal[][] profiles =
            {
                new decimal[] { 9.2m, 9.0m, 8.8m, 9.3m },
                new decimal[] { 8.4m, 8.1m, 8.6m, 8.2m },
                new decimal[] { 7.2m, 7.5m, 7.0m, 7.8m },
                new decimal[] { 6.1m, 5.8m, 6.4m, 5.6m },
                new decimal[] { 4.8m, 5.1m, 4.6m, 5.3m },
                new decimal[] { 8.9m, 9.1m, 8.7m, 9.0m },
                new decimal[] { 7.9m, 8.0m, 8.3m, 7.7m },
                new decimal[] { 6.7m, 6.9m, 7.1m, 6.5m },
            };

            return profiles[(ordinal - 1) % profiles.Length];
        }

        private void EnsureScoresForExistingStudents(SqlConnection conn)
        {
            DataTable students = new DataTable();
            new SqlDataAdapter("SELECT MSSV FROM dbo.Student WHERE MSSV IS NOT NULL", conn).Fill(students);

            int ordinal = 1;
            foreach (DataRow row in students.Rows)
            {
                int mssv = Convert.ToInt32(row["MSSV"]);
                DashboardStudentSeed seed = new DashboardStudentSeed(
                    mssv,
                    "",
                    "",
                    DateTime.Today,
                    "Nam",
                    BuildScoreProfile(ordinal));
                EnsureScoreSet(conn, seed);
                ordinal++;
            }
        }

        private class DashboardStudentSeed
        {
            public int Mssv { get; }
            public string Fname { get; }
            public string Lname { get; }
            public DateTime Dob { get; }
            public string Gender { get; }
            public decimal[] Scores { get; }

            public DashboardStudentSeed(int mssv, string fname, string lname, DateTime dob, string gender, decimal[] scores)
            {
                Mssv = mssv;
                Fname = fname;
                Lname = lname;
                Dob = dob;
                Gender = gender;
                Scores = scores;
            }
        }

        private void EnsureStudentSeed(SqlConnection conn, DashboardStudentSeed seed)
        {
            SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM dbo.Student WHERE MSSV = @mssv", conn);
            check.Parameters.AddWithValue("@mssv", seed.Mssv);
            if (Convert.ToInt32(check.ExecuteScalar()) > 0) return;

            InsertStudentSeed(conn, seed.Mssv, seed.Fname, seed.Lname, seed.Dob, seed.Gender, "09" + seed.Mssv.ToString().Substring(2, 8), "TP HCM", "HCMUTE", $"{seed.Mssv}@sv.hcmute.edu.vn");
        }

        private void EnsureCourseSeed(SqlConnection conn, string id, string name, int credits, int weeks, int semester, string description)
        {
            SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM dbo.Course WHERE MaMH = @id", conn);
            check.Parameters.AddWithValue("@id", id);
            if (Convert.ToInt32(check.ExecuteScalar()) > 0) return;

            InsertCourseSeed(conn, id, name, credits, weeks, semester, description);
        }

        private void EnsureScoreSet(SqlConnection conn, DashboardStudentSeed seed)
        {
            string[] courses = { "CS101", "DB201", "WEB301", "AI401" };
            for (int i = 0; i < courses.Length; i++)
            {
                SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM dbo.Score WHERE MSSV = @mssv AND RTRIM(MaMH) = @course", conn);
                check.Parameters.AddWithValue("@mssv", seed.Mssv);
                check.Parameters.AddWithValue("@course", courses[i]);
                if (Convert.ToInt32(check.ExecuteScalar()) > 0) continue;

                decimal target = seed.Scores[i];
                decimal midterm = Math.Max(0, Math.Min(10, target - 0.2m));
                decimal finalExam = Math.Max(0, Math.Min(10, target + 0.13m));
                decimal totalScore = Score.TinhDiemTK(midterm, finalExam);
                InsertScoreSeed(conn, seed.Mssv, courses[i], midterm, finalExam, totalScore, Score.XepLoaiTheoTK(totalScore));
            }
        }

        private void InsertStudentSeed(SqlConnection conn, int mssv, string fname, string lname, DateTime dob, string gender, string phone, string address, string hometown, string email)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Student (MSSV, Fname, Lname, Dob, Gder, Phone, Address, Htown, Email, Pture) VALUES (@mssv, @fn, @ln, @dob, @gender, @phone, @address, @hometown, @email, NULL)", conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            cmd.Parameters.AddWithValue("@fn", fname);
            cmd.Parameters.AddWithValue("@ln", lname);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@hometown", hometown);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.ExecuteNonQuery();
        }

        private void InsertCourseSeed(SqlConnection conn, string id, string name, int credits, int weeks, int semester, string description)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Course (MaMH, TenMH, SoTC, Tuan, Hky, Mota) VALUES (@id, @name, @credits, @weeks, @semester, @description)", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@credits", credits);
            cmd.Parameters.AddWithValue("@weeks", weeks);
            cmd.Parameters.AddWithValue("@semester", semester);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.ExecuteNonQuery();
        }

        private void InsertScoreSeed(SqlConnection conn, int mssv, string courseId, decimal midterm, decimal finalExam, decimal totalScore, string rank)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Score (MSSV, MaMH, DiemQT, DiemCK, DiemTK, XepLoai, Mota) VALUES (@mssv, @course, @midterm, @finalExam, @totalScore, @rank, @note)", conn);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            cmd.Parameters.AddWithValue("@course", courseId);
            cmd.Parameters.AddWithValue("@midterm", midterm);
            cmd.Parameters.AddWithValue("@finalExam", finalExam);
            cmd.Parameters.AddWithValue("@totalScore", totalScore);
            cmd.Parameters.AddWithValue("@rank", rank);
            cmd.Parameters.AddWithValue("@note", "Dữ liệu mẫu dashboard");
            cmd.ExecuteNonQuery();
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
                    "SELECT LEFT(CAST(MSSV AS NVARCHAR(20)), 2) AS NamNhapHoc, " +
                    "COUNT(*) AS SoLuong " +
                    "FROM Student " +
                    "WHERE LEN(CAST(MSSV AS NVARCHAR(20))) >= 6 " +
                    "GROUP BY LEFT(CAST(MSSV AS NVARCHAR(20)), 2) " +
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
            chartNam.Titles.Add("Xu hướng sinh viên theo năm nhập học");
            ApplyModernChartStyle(chartNam);

            Series area = new Series("Số SV");
            area.ChartType = SeriesChartType.SplineArea;
            area.Color = Color.FromArgb(80, 14, 165, 233);
            area.BackGradientStyle = GradientStyle.TopBottom;
            area.BackSecondaryColor = Color.FromArgb(12, 74, 110);
            area.BorderWidth = 3;
            area.BorderColor = Color.FromArgb(14, 165, 233);
            area.MarkerStyle = MarkerStyle.Circle;
            area.MarkerSize = 9;
            area.MarkerColor = Color.White;
            area.MarkerBorderWidth = 3;
            area.MarkerBorderColor = Color.FromArgb(14, 165, 233);
            area.IsValueShownAsLabel = true;
            area.LabelFormat = "N0";
            area.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            area.LabelForeColor = Color.FromArgb(15, 23, 42);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string yearLabel = "20" + row["NamNhapHoc"].ToString();
                    area.Points.AddXY(yearLabel, Convert.ToInt32(row["SoLuong"]));
                }
            }

            chartNam.Series.Add(area);
            chartNam.ChartAreas[0].AxisX.Interval = 1;
            chartNam.Legends[0].Enabled = false;
            ConfigureValueAxis(chartNam, GetMaxY(chartNam), true);
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
            chartGpa.Titles.Add("Phổ điểm học lực");
            ApplyModernChartStyle(chartGpa);

            Series s = new Series("Học lực");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            s.LabelFormat = "N0";
            s.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            s.LabelForeColor = Color.FromArgb(15, 23, 42);
            s["PointWidth"] = "0.48";
            s["DrawingStyle"] = "Cylinder";

            Color[] colors = {
                Color.FromArgb(239, 68, 68),
                Color.FromArgb(245, 158, 11),
                Color.FromArgb(59, 130, 246),
                Color.FromArgb(34, 197, 94),
                Color.FromArgb(139, 92, 246)
            };
            int idx = 0;
            if (dtXepLoai != null)
            {
                foreach (DataRow row in dtXepLoai.Rows)
                {
                    int pt = s.Points.AddXY(
                        row["Xếp Loại"].ToString(),
                        Convert.ToInt32(row["Số Lượng"]));
                    s.Points[pt].Color = colors[idx % colors.Length];
                    idx++;
                }
            }

            chartGpa.Series.Add(s);
            chartGpa.ChartAreas[0].AxisX.Interval = 1;
            chartGpa.Legends[0].Enabled = false;
            ConfigureValueAxis(chartGpa, GetMaxY(chartGpa), true);
        }

        // ===================================================================
        // VẼ PIE CHART GIỚI TÍNH
        // ===================================================================
        private void VePieChart(double male, double female, double other)
        {
            chartPie.Series.Clear();
            chartPie.Titles.Clear();
            chartPie.Titles.Add("Tỷ lệ giới tính");
            ApplyModernChartStyle(chartPie);

            Series s = new Series("Giới tính");
            s.ChartType = SeriesChartType.Doughnut;
            s.IsValueShownAsLabel = true;
            s["PieLabelStyle"] = "Outside";
            s["DoughnutRadius"] = "62";
            s["PieDrawingStyle"] = "SoftEdge";
            s.Label = "#VALX: #PERCENT{P0}";
            s.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
            s.LabelForeColor = Color.FromArgb(15, 23, 42);

            s.Points.AddXY("Nam", male);
            s.Points.AddXY("Nữ", female);
            s.Points.AddXY("Khác", other);

            s.Points[0].Color = Color.FromArgb(0, 120, 215);
            s.Points[1].Color = Color.FromArgb(220, 53, 69);
            s.Points[2].Color = Color.FromArgb(40, 167, 69);

            chartPie.Series.Add(s);
            chartPie.Legends[0].Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            chartPie.Legends[0].Docking = Docking.Right;
            chartPie.Legends[0].Alignment = StringAlignment.Center;
            chartPie.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartPie.ChartAreas[0].Area3DStyle.Inclination = 12;
            chartPie.ChartAreas[0].Area3DStyle.Rotation = 8;
        }

        private double GetMaxY(Chart chart)
        {
            double max = 0;
            foreach (Series series in chart.Series)
                foreach (DataPoint point in series.Points)
                    if (point.YValues.Length > 0)
                        max = Math.Max(max, point.YValues[0]);
            return max;
        }

        private void ConfigureValueAxis(Chart chart, double maxValue, bool integerLabels)
        {
            ChartArea area = chart.ChartAreas[0];
            double max = Math.Max(1, maxValue);
            double roundedMax = Math.Ceiling(max * 1.25);
            double interval = Math.Max(1, Math.Ceiling(roundedMax / 5.0));

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = roundedMax;
            area.AxisY.Interval = interval;
            area.AxisY.LabelStyle.Format = integerLabels ? "N0" : "";
            area.AxisY.IsStartedFromZero = true;
        }

        private void StartChartAnimation()
        {
            chartAnimationTimer.Stop();
            chartTargets.Clear();

            foreach (Chart chart in new[] { chartGpa, chartPie, chartNam })
            {
                foreach (Series series in chart.Series)
                {
                    foreach (DataPoint point in series.Points)
                    {
                        double target = point.YValues.Length > 0 ? point.YValues[0] : 0;
                        chartTargets[point] = target;
                        point.YValues[0] = 0.01;
                    }
                }
                chart.Invalidate();
            }

            chartAnimationProgress = 0;
            chartAnimationTimer.Start();
        }

        private void ChartAnimationTimer_Tick(object sender, EventArgs e)
        {
            chartAnimationProgress += 0.035;
            double eased = 1 - Math.Pow(1 - Math.Min(chartAnimationProgress, 1), 3);

            foreach (KeyValuePair<DataPoint, double> pair in chartTargets)
            {
                pair.Key.YValues[0] = Math.Max(0.01, pair.Value * eased);
            }

            chartGpa.Invalidate();
            chartPie.Invalidate();
            chartNam.Invalidate();

            if (chartAnimationProgress >= 1)
            {
                foreach (KeyValuePair<DataPoint, double> pair in chartTargets)
                    pair.Key.YValues[0] = pair.Value;
                chartAnimationTimer.Stop();
            }
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
                string query = "SELECT LEFT(CAST(MSSV AS NVARCHAR(20)), 2) AS Nam, COUNT(*) AS SL FROM Student WHERE LEN(CAST(MSSV AS NVARCHAR(20))) >= 6 GROUP BY LEFT(CAST(MSSV AS NVARCHAR(20)), 2) ORDER BY Nam";
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
        private static Color HoverColor() =>
            ThemeManager.IsDark ? Color.FromArgb(40, 55, 80) : Color.White;

        private void pnlMale_MouseEnter(object sender, EventArgs e)
        {
            Color h = HoverColor();
            pnlMale.BackColor = h; lblMale.BackColor = h;
            lblMale.ForeColor = panMaleColor;
        }
        private void pnlMale_MouseLeave(object sender, EventArgs e)
        {
            pnlMale.BackColor = panMaleColor;
            lblMale.ForeColor = Color.White; lblMale.BackColor = panMaleColor;
        }
        private void pnlFemale_MouseEnter(object sender, EventArgs e)
        {
            Color h = HoverColor();
            pnlFemale.BackColor = h; lblFemale.BackColor = h;
            lblFemale.ForeColor = panFemaleColor;
        }
        private void pnlFemale_MouseLeave(object sender, EventArgs e)
        {
            pnlFemale.BackColor = panFemaleColor;
            lblFemale.ForeColor = Color.White; lblFemale.BackColor = panFemaleColor;
        }
        private void pnlOther_MouseEnter(object sender, EventArgs e)
        {
            Color h = HoverColor();
            pnlOther.BackColor = h; lblOther.BackColor = h;
            lblOther.ForeColor = panOtherColor;
        }
        private void pnlOther_MouseLeave(object sender, EventArgs e)
        {
            pnlOther.BackColor = panOtherColor;
            lblOther.ForeColor = Color.White; lblOther.BackColor = panOtherColor;
        }
        private void pnlTotal_MouseEnter(object sender, EventArgs e)
        {
            Color h = HoverColor();
            pnlTotal.BackColor = h;
            lblTotalTitle.ForeColor = panTotalColor;
            lblTotal.ForeColor = panTotalColor;
        }
        private void pnlTotal_MouseLeave(object sender, EventArgs e)
        {
            pnlTotal.BackColor = panTotalColor;
            lblTotalTitle.ForeColor = Color.White;
            lblTotal.ForeColor = Color.White;
        }

        private void btnRefresh_Click(object sender, EventArgs e) { LoadStatisticData(); ApplyResponsiveLayout(); }
        private void btnBack_Click(object sender, EventArgs e) { }

        private void f_Statistic_Resize(object sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {
            if (pnlCards == null || pnlContent == null || pnlRight == null)
            {
                return;
            }

            int gap = 15;
            int cardCount = 4;
            int cardWidth = Math.Max(180, (pnlCards.Width - gap * (cardCount + 1)) / cardCount);
            int cardX = gap;
            foreach (Panel card in new[] { pnlTotal, pnlMale, pnlFemale, pnlOther })
            {
                card.SetBounds(cardX, 6, cardWidth, 95);
                cardX += cardWidth + gap;
            }

            int leftWidth = Math.Max(360, (int)(pnlContent.Width * 0.30));
            pnlLeft.Width = leftWidth;

            int tableWidth = pnlLeft.ClientSize.Width - 20;
            dgvReport.Width = tableWidth;
            dgvDetail.Width = tableWidth;
            dgvNam.Width = tableWidth;

            int chartGap = 12;
            int chartHeight = Math.Max(180, (pnlRight.ClientSize.Height - chartGap * 4) / 3);
            int chartWidth = pnlRight.ClientSize.Width - 20;

            chartGpa.SetBounds(10, 10, chartWidth, chartHeight);
            chartPie.SetBounds(10, chartGpa.Bottom + chartGap, chartWidth, chartHeight);
            chartNam.SetBounds(10, chartPie.Bottom + chartGap, chartWidth, chartHeight);

            if (btnRefresh != null)
            {
                btnRefresh.Location = new Point(pnlTop.Width - btnRefresh.Width - 10, btnRefresh.Top);
            }

            if (btnExportStatExcel != null && btnRefresh != null)
            {
                btnExportStatExcel.Location = new Point(btnRefresh.Left - btnExportStatExcel.Width - 8, btnRefresh.Top);
            }
        }

        private void ApplyModernChartStyle(Chart chart)
        {
            chart.BackColor = Color.White;
            chart.BorderlineColor = Color.FromArgb(216, 226, 240);
            chart.BorderlineWidth = 1;
            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

            if (chart.Titles.Count > 0)
            {
                chart.Titles[0].Font = new Font("Segoe UI Semibold", 12f, FontStyle.Bold);
                chart.Titles[0].ForeColor = Color.FromArgb(15, 23, 42);
            }

            ChartArea area = chart.ChartAreas[0];
            area.BackColor = Color.FromArgb(250, 252, 255);
            area.BackGradientStyle = GradientStyle.TopBottom;
            area.BackSecondaryColor = Color.White;
            area.BorderColor = Color.Transparent;
            area.BorderWidth = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 236, 246);
            area.AxisX.LabelStyle.Font = new Font("Arial", 10f);
            area.AxisY.LabelStyle.Font = new Font("Arial", 9f);
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(71, 85, 105);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(71, 85, 105);
            area.AxisX.LineColor = Color.FromArgb(203, 213, 225);
            area.AxisY.LineColor = Color.FromArgb(203, 213, 225);
            area.AxisX.MajorTickMark.LineColor = Color.FromArgb(203, 213, 225);
            area.AxisY.MajorTickMark.LineColor = Color.FromArgb(203, 213, 225);
        }

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
