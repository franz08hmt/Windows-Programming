using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.IO;
using SysColor = System.Drawing.Color;   // alias để tránh conflict với iText Color
using System.Windows.Forms;

namespace QuanLySinhVien
{
    internal static class ReportExportService
    {
        private static readonly string LogoPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Resources", "Logo.png");

        // Dùng Arial (hỗ trợ Unicode tiếng Việt) thay cho Helvetica
        private static PdfFont LoadFont(bool isBold)
        {
            string fontsDir = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            string path = Path.Combine(fontsDir, isBold ? "arialbd.ttf" : "arial.ttf");
            if (File.Exists(path))
                return PdfFontFactory.CreateFont(path, "Identity-H");
            // fallback nếu không tìm thấy arial
            return PdfFontFactory.CreateFont(isBold ? StandardFonts.HELVETICA_BOLD : StandardFonts.HELVETICA);
        }

        // ============================================================
        // XUẤT DANH SÁCH SINH VIÊN — PDF
        // ============================================================
        public static void ExportStudentListToPDF(DataView view)
        {
            if (view == null || view.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = $"DanhSachSV_{DateTime.Now:yyyyMMdd_HHmm}.pdf";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (PdfWriter writer = new PdfWriter(sfd.FileName))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document doc = new Document(pdf, iText.Kernel.Geom.PageSize.A4.Rotate()))
                    {
                        doc.SetMargins(30, 30, 30, 30);
                        PdfFont bold    = LoadFont(true);
                        PdfFont regular = LoadFont(false);

                        // Logo + tiêu đề
                        AddHeader(doc, "DANH SÁCH SINH VIÊN", bold, regular);

                        // Bảng dữ liệu
                        string[] headers = { "Mã SV", "Họ", "Tên", "Ngày sinh", "Giới tính", "Điện thoại", "Email" };
                        string[] cols    = { "MSSV", "Fname", "Lname", "Dob", "Gder", "Phone", "Email" };
                        float[]  widths  = { 60f, 80f, 80f, 90f, 65f, 100f, 140f };

                        Table table = new Table(UnitValue.CreatePointArray(widths));
                        table.SetWidth(UnitValue.CreatePercentValue(100));

                        foreach (string h in headers)
                            table.AddHeaderCell(HeaderCell(h, bold));

                        int rowNum = 0;
                        foreach (DataRowView drv in view)
                        {
                            Color bg = (rowNum % 2 == 0)
                                ? ColorConstants.WHITE
                                : new DeviceRgb(240, 244, 255);
                            rowNum++;

                            foreach (string col in cols)
                            {
                                string val = "";
                                if (col == "Dob" && drv[col] != DBNull.Value)
                                    val = Convert.ToDateTime(drv[col]).ToString("dd/MM/yyyy");
                                else
                                    val = drv[col]?.ToString() ?? "";

                                table.AddCell(new Cell().Add(new Paragraph(val)
                                    .SetFont(regular).SetFontSize(9))
                                    .SetBackgroundColor(bg));
                            }
                        }

                        doc.Add(table);
                        AddFooter(doc, regular, view.Count);
                    }

                    AskOpenFile(sfd.FileName, "PDF");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // XUẤT BẢNG ĐIỂM MỘT SINH VIÊN — PDF (có logo)
        // ============================================================
        public static void ExportScoreToPDF(DataTable scores, string studentName, string mssv)
        {
            if (scores == null || scores.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu điểm để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files|*.pdf";
                sfd.FileName = $"BangDiem_{mssv}_{DateTime.Now:yyyyMMdd}.pdf";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (PdfWriter writer = new PdfWriter(sfd.FileName))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document doc = new Document(pdf, iText.Kernel.Geom.PageSize.A4))
                    {
                        doc.SetMargins(30, 30, 30, 30);
                        PdfFont bold    = LoadFont(true);
                        PdfFont regular = LoadFont(false);

                        AddHeader(doc, "BẢNG ĐIỂM SINH VIÊN", bold, regular);

                        // Thông tin sinh viên
                        doc.Add(new Paragraph($"Sinh viên: {studentName}   |   MSSV: {mssv}   |   Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .SetFont(regular).SetFontSize(10).SetMarginBottom(10));

                        string[] headers = { "Mã MH", "Tên Môn Học", "Số TC", "Điểm QT", "Điểm CK", "Điểm TK", "Xếp Loại" };
                        string[] cols    = { "Mã Môn", "Tên Môn", "Số TC", "Điểm QT", "Điểm CK", "Điểm TK", "Xếp Loại" };
                        float[]  widths  = { 55f, 160f, 40f, 55f, 55f, 55f, 80f };

                        Table table = new Table(UnitValue.CreatePointArray(widths));
                        table.SetWidth(UnitValue.CreatePercentValue(100));

                        foreach (string h in headers)
                            table.AddHeaderCell(HeaderCell(h, bold));

                        int rowNum = 0;
                        foreach (DataRow row in scores.Rows)
                        {
                            Color bg = (rowNum % 2 == 0)
                                ? ColorConstants.WHITE
                                : new DeviceRgb(240, 244, 255);
                            rowNum++;

                            foreach (string col in cols)
                            {
                                string val = row[col]?.ToString() ?? "";
                                var cell = new Cell().Add(new Paragraph(val)
                                    .SetFont(regular).SetFontSize(10))
                                    .SetBackgroundColor(bg);

                                if (col == "XepLoai")
                                    cell.SetTextAlignment(TextAlignment.CENTER);

                                table.AddCell(cell);
                            }
                        }

                        doc.Add(table);
                        AddFooter(doc, regular, scores.Rows.Count);
                    }

                    AskOpenFile(sfd.FileName, "PDF");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // XUẤT THỐNG KÊ ĐIỂM — EXCEL (có chart)
        // ============================================================
        public static void ExportStatisticsToExcel(DataTable dtGpa, DataTable dtGender)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = $"ThongKe_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (ExcelPackage pkg = new ExcelPackage())
                    {
                        // Sheet 1: Thống kê theo GPA
                        if (dtGpa != null && dtGpa.Rows.Count > 0)
                        {
                            ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Xếp loại học lực");
                            ws.Cells[1, 1].Value = "HỆ THỐNG QUẢN LÝ SINH VIÊN - THỐNG KÊ HỌC LỰC";
                            ws.Cells[1, 1, 1, 3].Merge = true;
                            ws.Cells[1, 1].Style.Font.Bold = true;
                            ws.Cells[1, 1].Style.Font.Size = 14;
                            ws.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[2, 1].Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
                            ws.Cells[2, 1, 2, 3].Merge = true;
                            ws.Cells[2, 1].Style.Font.Italic = true;

                            string[] headers = { "Xếp Loại", "Số Lượng", "Tỉ Lệ (%)" };
                            for (int i = 0; i < headers.Length; i++)
                            {
                                var c = ws.Cells[4, i + 1];
                                c.Value = headers[i];
                                c.Style.Font.Bold = true;
                                c.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                c.Style.Fill.BackgroundColor.SetColor(SysColor.FromArgb(31, 73, 125));
                                c.Style.Font.Color.SetColor(SysColor.White);
                                c.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            int total = 0;
                            foreach (DataRow r in dtGpa.Rows)
                                total += Convert.ToInt32(r[1]);

                            int row = 5;
                            foreach (DataRow dr in dtGpa.Rows)
                            {
                                int count = Convert.ToInt32(dr[1]);
                                double pct = total > 0 ? Math.Round(count * 100.0 / total, 1) : 0;
                                ws.Cells[row, 1].Value = dr[0]?.ToString();
                                ws.Cells[row, 2].Value = count;
                                ws.Cells[row, 3].Value = pct;
                                ws.Cells[row, 3].Style.Numberformat.Format = "0.0\"%\"";

                                if (row % 2 == 0)
                                {
                                    ws.Cells[row, 1, row, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    ws.Cells[row, 1, row, 3].Style.Fill.BackgroundColor.SetColor(SysColor.FromArgb(240, 244, 255));
                                }
                                row++;
                            }

                            ws.Cells.AutoFitColumns();

                            // Thêm biểu đồ tròn
                            var chart = ws.Drawings.AddChart("ChartGPA", eChartType.Pie3D) as ExcelPieChart;
                            if (chart != null)
                            {
                                chart.Title.Text = "Phân bố xếp loại học lực";
                                chart.Series.Add(
                                    ws.Cells[5, 2, row - 1, 2],
                                    ws.Cells[5, 1, row - 1, 1]);
                                chart.SetPosition(row + 1, 0, 0, 0);
                                chart.SetSize(400, 300);
                            }
                        }

                        // Sheet 2: Thống kê theo giới tính
                        if (dtGender != null && dtGender.Rows.Count > 0)
                        {
                            ExcelWorksheet ws2 = pkg.Workbook.Worksheets.Add("Theo giới tính");
                            ws2.Cells[1, 1].Value = "THỐNG KÊ SINH VIÊN THEO GIỚI TÍNH";
                            ws2.Cells[1, 1, 1, 2].Merge = true;
                            ws2.Cells[1, 1].Style.Font.Bold = true;
                            ws2.Cells[1, 1].Style.Font.Size = 14;
                            ws2.Cells[1, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            ws2.Cells[3, 1].Value = "Giới Tính";
                            ws2.Cells[3, 2].Value = "Số Lượng";
                            ws2.Cells[3, 1, 3, 2].Style.Font.Bold = true;
                            ws2.Cells[3, 1, 3, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            ws2.Cells[3, 1, 3, 2].Style.Fill.BackgroundColor.SetColor(SysColor.FromArgb(31, 73, 125));
                            ws2.Cells[3, 1, 3, 2].Style.Font.Color.SetColor(SysColor.White);

                            int r2 = 4;
                            foreach (DataRow dr in dtGender.Rows)
                            {
                                ws2.Cells[r2, 1].Value = dr[0]?.ToString();
                                ws2.Cells[r2, 2].Value = Convert.ToInt32(dr[1]);
                                r2++;
                            }
                            ws2.Cells.AutoFitColumns();

                            var chart2 = ws2.Drawings.AddChart("ChartGender", eChartType.ColumnClustered) as ExcelBarChart;
                            if (chart2 != null)
                            {
                                chart2.Title.Text = "Số lượng sinh viên theo giới tính";
                                chart2.Series.Add(
                                    ws2.Cells[4, 2, r2 - 1, 2],
                                    ws2.Cells[4, 1, r2 - 1, 1]);
                                chart2.SetPosition(r2 + 1, 0, 0, 0);
                                chart2.SetSize(400, 300);
                            }
                        }

                        pkg.SaveAs(new FileInfo(sfd.FileName));
                    }

                    AskOpenFile(sfd.FileName, "Excel");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ============================================================
        // HELPERS
        // ============================================================
        private static void AddHeader(Document doc, string title, PdfFont bold, PdfFont regular)
        {
            // Logo bên trái + tiêu đề giữa
            Table header = new Table(new float[] { 80f, 1f });
            header.SetWidth(UnitValue.CreatePercentValue(100)).SetMarginBottom(10);

            Cell logoCell = new Cell();
            if (File.Exists(LogoPath))
            {
                ImageData imgData = ImageDataFactory.Create(LogoPath);
                iText.Layout.Element.Image img = new iText.Layout.Element.Image(imgData)
                    .SetWidth(70).SetHeight(70);
                logoCell.Add(img);
            }
            logoCell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            header.AddCell(logoCell);

            Cell titleCell = new Cell().SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            titleCell.Add(new Paragraph("TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP.HCM")
                .SetFont(regular).SetFontSize(10).SetTextAlignment(TextAlignment.CENTER));
            titleCell.Add(new Paragraph(title)
                .SetFont(bold).SetFontSize(16).SetTextAlignment(TextAlignment.CENTER)
                .SetFontColor(new DeviceRgb(0, 61, 149)));
            titleCell.Add(new Paragraph($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}")
                .SetFont(regular).SetFontSize(9).SetTextAlignment(TextAlignment.RIGHT)
                .SetFontColor(ColorConstants.GRAY));
            header.AddCell(titleCell);

            doc.Add(header);

            // Đường kẻ ngang
            doc.Add(new LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine(1f))
                .SetMarginBottom(10));
        }

        private static Cell HeaderCell(string text, PdfFont font)
        {
            return new Cell()
                .Add(new Paragraph(text).SetFont(font).SetFontSize(10)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER))
                .SetBackgroundColor(new DeviceRgb(0, 61, 149))
                .SetTextAlignment(TextAlignment.CENTER);
        }

        private static void AddFooter(Document doc, PdfFont font, int rowCount)
        {
            doc.Add(new Paragraph($"\nTổng số bản ghi: {rowCount}   |   Xuất bởi: {Globals.GlobalUserName}   |   Hệ thống QuanLySinhVien")
                .SetFont(font).SetFontSize(8)
                .SetFontColor(ColorConstants.GRAY)
                .SetTextAlignment(TextAlignment.RIGHT));
        }

        private static void AskOpenFile(string path, string type)
        {
            DialogResult dr = MessageBox.Show(
                $"Xuất {type} thành công!\nBạn có muốn mở file vừa xuất không?",
                "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
                System.Diagnostics.Process.Start(path);
        }
    }
}
