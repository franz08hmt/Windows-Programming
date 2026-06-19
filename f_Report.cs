using Guna.UI2.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_Report : UserControl
    {
        private My_DB db = new My_DB();
        private DataTable _currentData = null;
        private string _reportType = "students";

        public f_Report()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            this.Load += new EventHandler(f_Report_Load);
            cboReportType.SelectedIndexChanged += new EventHandler(CboReportType_SelectedIndexChanged);
            btnPreview.Click += new EventHandler(BtnPreview_Click);
            btnExportPDF.Click += new EventHandler(btnExportPDF_Click_1);
            btnExportExcel.Click += new EventHandler(btnExportExcel_Click_1);
            btnRefresh.Click += new EventHandler(BtnRefresh_Click);
            txtSearch.TextChanged += new EventHandler(TxtSearch_TextChanged);
        }

        private void f_Report_Load(object sender, EventArgs e)
        {
            cboReportType.Items.Clear();
            cboReportType.Items.AddRange(new object[] {
                "Danh sách sinh viên",
                "Bảng điểm tổng hợp",
                "Thống kê xếp loại",
                "Danh sách môn học"
            });
            cboReportType.SelectedIndex = 0;
            LoadReport();
        }

        private void CboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Rows.Count == 0) LoadReport();
            if (_currentData == null || _currentData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xem trước.", "Thông báo");
                return;
            }

            using (Form fPreview = new Form())
            {
                fPreview.Text = "Xem trước — " + lblTitle.Text;
                fPreview.Size = new System.Drawing.Size(950, 620);
                fPreview.StartPosition = FormStartPosition.CenterParent;
                fPreview.BackColor = System.Drawing.Color.White;

                Label lbl = new Label
                {
                    Text = lblTitle.Text,
                    Font = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold),
                    ForeColor = System.Drawing.Color.FromArgb(0, 61, 149),
                    Dock = DockStyle.Top,
                    Height = 42,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                DataGridView dgv = new DataGridView
                {
                    DataSource = _currentData.Copy(),
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
                    AllowUserToAddRows = false,
                    BackgroundColor = System.Drawing.Color.White,
                    BorderStyle = BorderStyle.None,
                    EnableHeadersVisualStyles = false,
                    RowHeadersVisible = false
                };
                dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 73, 125);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);

                fPreview.Controls.Add(dgv);
                fPreview.Controls.Add(lbl);
                fPreview.ShowDialog();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadReport();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterGrid();
        }

        private void LoadReport()
        {
            try
            {
                int idx = cboReportType.SelectedIndex;
                switch (idx)
                {
                    case 0: LoadStudentReport(); _reportType = "students"; break;
                    case 1: LoadScoreReport();   _reportType = "scores";   break;
                    case 2: LoadStatReport();    _reportType = "stats";    break;
                    case 3: LoadCourseReport();  _reportType = "courses";  break;
                }

                lblRowCount.Text = $"Tổng: {dgvReport.Rows.Count} bản ghi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Lỗi");
            }
        }

        private void LoadStudentReport()
        {
            string q = "SELECT MSSV as 'Mã SV', Fname as 'Họ', Lname as 'Tên', " +
                       "CONVERT(VARCHAR,Dob,103) as 'Ngày sinh', Gder as 'Giới tính', " +
                       "Phone as 'Điện thoại', Email FROM Student ORDER BY MSSV";
            _currentData = RunQuery(q);
            dgvReport.DataSource = _currentData;
        }

        private void LoadScoreReport()
        {
            string q = "SELECT s.MSSV, sv.Lname+' '+sv.Fname as 'Họ tên', c.TenMH as 'Môn học', " +
                       "s.DiemQT as 'ĐQT', s.DiemCK as 'ĐCK', s.DiemTK as 'ĐTK', s.XepLoai as 'Xếp loại' " +
                       "FROM Score s JOIN Student sv ON s.MSSV=sv.MSSV JOIN Course c ON s.MaMH=c.MaMH " +
                       "ORDER BY s.MSSV";
            _currentData = RunQuery(q);
            dgvReport.DataSource = _currentData;
        }

        private void LoadStatReport()
        {
            // Xếp loại theo điểm TB của từng SV → tổng = số SV có điểm (khớp chart f_Statistic)
            string q = @"
                SELECT sv.[Xếp loại],
                       COUNT(*)  AS [Số lượng],
                       CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER () AS DECIMAL(5,1)) AS [Tỉ lệ (%)]
                FROM (
                    SELECT MSSV,
                           CASE
                               WHEN AVG(DiemTK) >= 9.0 THEN N'Xuất sắc'
                               WHEN AVG(DiemTK) >= 8.0 THEN N'Giỏi'
                               WHEN AVG(DiemTK) >= 6.5 THEN N'Khá'
                               WHEN AVG(DiemTK) >= 5.0 THEN N'Trung bình'
                               ELSE                          N'Yếu'
                           END AS [Xếp loại]
                    FROM Score
                    WHERE DiemTK IS NOT NULL
                    GROUP BY MSSV
                ) AS sv
                GROUP BY sv.[Xếp loại]
                ORDER BY CASE sv.[Xếp loại]
                    WHEN N'Xuất sắc'   THEN 1
                    WHEN N'Giỏi'       THEN 2
                    WHEN N'Khá'        THEN 3
                    WHEN N'Trung bình' THEN 4
                    WHEN N'Yếu'        THEN 5
                    ELSE 6 END";
            _currentData = RunQuery(q);
            dgvReport.DataSource = _currentData;
        }

        private void LoadCourseReport()
        {
            string q = "SELECT MaMH as 'Mã MH', TenMH as 'Tên môn học', " +
                       "SoTC as 'Số TC', Tuan as 'Tuần', Hky as 'Học kỳ' FROM Course ORDER BY MaMH";
            _currentData = RunQuery(q);
            dgvReport.DataSource = _currentData;
        }

        private DataTable RunQuery(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                new System.Data.SqlClient.SqlDataAdapter(sql, db.conn).Fill(dt);
            }
            catch { }
            finally { db.closeConnection(); }
            return dt;
        }

        private void FilterGrid()
        {
            if (_currentData == null) return;
            string kw = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                dgvReport.DataSource = _currentData;
            }
            else
            {
                DataView dv = _currentData.DefaultView;
                // Filter trên tất cả cột string
                string filter = "";
                foreach (DataColumn col in _currentData.Columns)
                {
                    if (col.DataType == typeof(string))
                    {
                        if (filter != "") filter += " OR ";
                        filter += $"CONVERT([{col.ColumnName}], System.String) LIKE '%{kw}%'";
                    }
                }
                try { dv.RowFilter = filter; } catch { }
                dgvReport.DataSource = dv;
            }
            lblRowCount.Text = $"Tổng: {dgvReport.Rows.Count} bản ghi";
        }

        private void btnExportPDF_Click_1(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo");
                return;
            }

            DataView view = _currentData.DefaultView;
            if (_reportType == "students")
                ReportExportService.ExportStudentListToPDF(view);
            else
                ExportGenericPDF();
        }

        private void ExportGenericPDF()
        {
            MessageBox.Show("Chức năng xuất PDF báo cáo này đang được phát triển.\nVui lòng dùng Export Excel.", "Thông báo");
        }

        private void btnExportExcel_Click_1(object sender, EventArgs e)
        {
            if (_currentData == null || _currentData.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = $"BaoCao_{lblTitle.Text.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}.xlsx";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage pkg = new ExcelPackage())
                    {
                        ExcelWorksheet ws = pkg.Workbook.Worksheets.Add(lblTitle.Text);

                        // Header title
                        ws.Cells[1, 1].Value = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP.HCM";
                        ws.Cells[1, 1, 1, _currentData.Columns.Count].Merge = true;
                        ws.Cells[1, 1].Style.Font.Bold = true;
                        ws.Cells[1, 1].Style.Font.Size = 12;
                        ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[2, 1].Value = lblTitle.Text;
                        ws.Cells[2, 1, 2, _currentData.Columns.Count].Merge = true;
                        ws.Cells[2, 1].Style.Font.Bold = true;
                        ws.Cells[2, 1].Style.Font.Size = 14;
                        ws.Cells[2, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[3, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}   |   Xuất bởi: {Globals.GlobalUserName}";
                        ws.Cells[3, 1, 3, _currentData.Columns.Count].Merge = true;
                        ws.Cells[3, 1].Style.Font.Italic = true;
                        ws.Cells[3, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // Column headers
                        for (int i = 0; i < _currentData.Columns.Count; i++)
                        {
                            var c = ws.Cells[5, i + 1];
                            c.Value = _currentData.Columns[i].ColumnName;
                            c.Style.Font.Bold = true;
                            c.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            c.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(31, 73, 125));
                            c.Style.Font.Color.SetColor(Color.White);
                            c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        // Data rows
                        int row = 6;
                        foreach (DataRow dr in _currentData.Rows)
                        {
                            for (int c = 0; c < _currentData.Columns.Count; c++)
                                ws.Cells[row, c + 1].Value = dr[c]?.ToString() ?? "";

                            if (row % 2 == 0)
                            {
                                ws.Cells[row, 1, row, _currentData.Columns.Count].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                ws.Cells[row, 1, row, _currentData.Columns.Count].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(240, 244, 255));
                            }
                            row++;
                        }

                        ws.Cells.AutoFitColumns();
                        pkg.SaveAs(new FileInfo(sfd.FileName));
                    }

                    DialogResult dr2 = MessageBox.Show(
                        "Xuất Excel thành công!\nBạn có muốn mở file không?",
                        "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr2 == DialogResult.Yes)
                        System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi");
                }
            }
        }

    }
}
