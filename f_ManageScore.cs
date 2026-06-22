using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ManageScore : UserControl
    {
        public f_ManageScore()
        {
            InitializeComponent();
            RegisterRealTimeValidation();
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

        private void f_ManageScore_Load(object sender, EventArgs e)
        {
            txtTK.ReadOnly = true;
            txtTK.BackColor = Color.LightGray;
            txtXepLoai.ReadOnly = true;
            txtXepLoai.BackColor = Color.LightGray;
            nudCKWeight.BackColor = Color.LightGray;

            LoadStudentCombo();

            // Explicitly load data for initially selected student
            // (SelectedIndexChanged may not fire reliably on first bind)
            if (cboStudent.SelectedValue != null)
            {
                string mssv = cboStudent.SelectedValue.ToString();
                if (int.TryParse(mssv, out _))
                {
                    LoadCoursesRegisteredByStudent(mssv);
                    DisplayScoreBoard(mssv);
                }
            }
        }

        private void LoadStudentCombo()
        {
            DataTable dt = Student.GetStudents();
            if (!dt.Columns.Contains("HoTen"))
                dt.Columns.Add("HoTen", typeof(string));

            foreach (DataRow row in dt.Rows)
                row["HoTen"] = VietnameseTextHelper.Normalize(row["Fname"].ToString()) + " " +
                               VietnameseTextHelper.Normalize(row["Lname"].ToString());

            // Set DisplayMember/ValueMember BEFORE DataSource so SelectedIndexChanged
            // fires with the correct SelectedValue (MSSV int) instead of DataRowView
            cboStudent.DisplayMember = "HoTen";
            cboStudent.ValueMember = "MSSV";
            cboStudent.DataSource = dt;
        }

        private void LoadCoursesRegisteredByStudent(string mssv)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();

                // Admin form: hiện tất cả môn từ Course để admin có thể nhập điểm bất kỳ.
                // Ưu tiên môn sinh viên đã đăng ký (DKMH) hoặc đã có điểm (Score) lên đầu.
                string query =
                    "SELECT c.MaMH, c.TenMH, " +
                    "  CASE WHEN EXISTS(SELECT 1 FROM DKMH d WHERE d.MSSV=@mssv AND d.MaMH=c.MaMH) " +
                    "       OR  EXISTS(SELECT 1 FROM Score s WHERE s.MSSV=@mssv AND s.MaMH=c.MaMH) " +
                    "  THEN 0 ELSE 1 END AS SortOrder " +
                    "FROM Course c " +
                    "ORDER BY SortOrder, c.TenMH";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv));

                new SqlDataAdapter(cmd).Fill(dt);

                cboCourse.DataSource = null;
                cboCourse.Items.Clear();

                cboCourse.DataSource = dt;
                cboCourse.DisplayMember = "TenMH";
                cboCourse.ValueMember = "MaMH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách môn học: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void DisplayScoreBoard(string mssv)
        {
            DataTable dt = Score.GetStudentScoreBoard(mssv);
            dgvScores.DataSource = dt;
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dt == null || dt.Rows.Count == 0)
                ClearInputFields();

            decimal gpa = Score.CalculateGPA(mssv);
            lblGPA.Text = $"ĐIỂM GPA TÍCH LŨY: {gpa:F2} / 4.0";

            string xepLoai; Color mau;
            if (gpa >= 3.60m) { xepLoai = "Xuất sắc"; mau = Color.Purple; }
            else if (gpa >= 3.20m) { xepLoai = "Giỏi"; mau = Color.DarkGreen; }
            else if (gpa >= 2.50m) { xepLoai = "Khá"; mau = Color.Blue; }
            else if (gpa >= 2.00m) { xepLoai = "Trung bình"; mau = Color.DarkOrange; }
            else { xepLoai = "Yếu / Kém"; mau = Color.Red; }

            if (lblXepLoai != null)
            {
                lblXepLoai.Text = $"XẾP LOẠI HỌC LỰC: {xepLoai}";
                lblXepLoai.ForeColor = mau;
            }
        }

        // ===================================================================
        // TÍNH ĐIỂM TK THEO TRỌNG SỐ TÙY CHỈNH (nâng cao)
        // ===================================================================
        private void CalculateTotal()
        {
            string cleanQT = txtQT.Text.Trim();
            string cleanCK = txtCK.Text.Trim();

            if (string.IsNullOrEmpty(cleanQT) || string.IsNullOrEmpty(cleanCK))
            {
                txtTK.Clear(); txtXepLoai.Clear(); return;
            }

            if (decimal.TryParse(cleanQT, out decimal qt) &&
                decimal.TryParse(cleanCK, out decimal ck))
            {
                if (qt < 0 || qt > 10 || ck < 0 || ck > 10)
                {
                    txtTK.Clear(); txtXepLoai.Clear(); return;
                }

                // Dùng trọng số tùy chỉnh từ nudQTWeight / nudCKWeight
                decimal wQT = nudQTWeight.Value / 100m;
                decimal wCK = nudCKWeight.Value / 100m;
                decimal tk = Math.Round(qt * wQT + ck * wCK, 2);

                txtTK.Text = tk.ToString("F2");
                txtXepLoai.Text = Score.XepLoaiTheoTK(tk);
            }
            else { txtTK.Clear(); txtXepLoai.Clear(); }
        }

        // Khi đổi hệ số QT → CK tự cập nhật = 100 - QT
        private void nudWeight_ValueChanged(object sender, EventArgs e)
        {
            nudCKWeight.Value = 100 - nudQTWeight.Value;
            CalculateTotal();
        }

        private void RegisterRealTimeValidation()
        {
            txtQT.TextChanged += (s, e) => {
                string text = txtQT.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (!decimal.TryParse(text, out decimal val))
                        erpScore.SetError(txtQT, "Điểm không hợp lệ!");
                    else if (val < 0 || val > 10)
                        erpScore.SetError(txtQT, "Điểm phải từ 0 đến 10!");
                    else
                        erpScore.SetError(txtQT, "");
                }
                else erpScore.SetError(txtQT, "");
                CalculateTotal();
            };

            txtCK.TextChanged += (s, e) => {
                string text = txtCK.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (!decimal.TryParse(text, out decimal val))
                        erpScore.SetError(txtCK, "Điểm không hợp lệ!");
                    else if (val < 0 || val > 10)
                        erpScore.SetError(txtCK, "Điểm phải từ 0 đến 10!");
                    else
                        erpScore.SetError(txtCK, "");
                }
                else erpScore.SetError(txtCK, "");
                CalculateTotal();
            };
        }

        private void ClearInputFields()
        {
            txtQT.Clear(); txtCK.Clear();
            txtTK.Clear(); txtXepLoai.Clear();
            txtMota.Clear();
            erpScore?.Clear();
        }

        // ── Events ──────────────────────────────────────

        private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue != null &&
                cboStudent.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string mssv = cboStudent.SelectedValue.ToString();
                LoadCoursesRegisteredByStudent(mssv);
                DisplayScoreBoard(mssv);
                ClearInputFields();

            }
        }

        private void dgvScores_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvScores.Rows.Count - 1) return;

            DataGridViewRow row = dgvScores.Rows[e.RowIndex];
            string maMH = row.Cells[0].Value?.ToString().Trim() ?? "";

            // 🛠️ ĐÃ SỬA: Chỉ thay đổi vị trí chọn SelectedValue của môn học
            if (!string.IsNullOrEmpty(maMH))
            {
                cboCourse.SelectedValue = maMH;
            }

            txtQT.Text = row.Cells[3].Value?.ToString() ?? "";
            txtCK.Text = row.Cells[4].Value?.ToString() ?? "";
            txtTK.Text = row.Cells[5].Value?.ToString() ?? "";
            txtXepLoai.Text = row.Cells[6].Value?.ToString() ?? "";
            txtMota.Text = row.Cells[7].Value?.ToString() ?? "";

            erpScore?.Clear();
        }

        private void btnSaveScore_Click_1(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboCourse.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Sinh viên và Môn học!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtQT.Text.Trim(), out decimal qt) ||
                !decimal.TryParse(txtCK.Text.Trim(), out decimal ck))
            {
                MessageBox.Show("Điểm QT và CK phải là số hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (qt < 0 || qt > 10 || ck < 0 || ck > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // [AI] Phát hiện bất thường: chênh lệch QT và CK quá 5 điểm
            if (ck - qt > 5)
            {
                DialogResult canh = MessageBox.Show(
                    $"⚠️ AI PHÁT HIỆN BẤT THƯỜNG!\n\n" +
                    $"Điểm CK ({ck:F1}) cao hơn Điểm QT ({qt:F1}) quá 5 điểm.\n" +
                    $"Chênh lệch: {(ck - qt):F1} điểm\n\n" +
                    $"Có thể do nhập sai dữ liệu. Bạn có chắc chắn muốn lưu không?",
                    "AI Phát hiện bất thường",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (canh != DialogResult.Yes) return;
            }
            else if (qt - ck > 5)
            {
                DialogResult canh = MessageBox.Show(
                    $"⚠️ AI PHÁT HIỆN BẤT THƯỜNG!\n\n" +
                    $"Điểm QT ({qt:F1}) cao hơn Điểm CK ({ck:F1}) quá 5 điểm.\n" +
                    $"Chênh lệch: {(qt - ck):F1} điểm\n\n" +
                    $"Có thể do nhập sai dữ liệu. Bạn có chắc chắn muốn lưu không?",
                    "AI Phát hiện bất thường",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (canh != DialogResult.Yes) return;
            }

            // Dùng trọng số tùy chỉnh
            decimal wQT = nudQTWeight.Value / 100m;
            decimal wCK = nudCKWeight.Value / 100m;
            decimal tk = Math.Round(qt * wQT + ck * wCK, 2);
            string xepLoai = Score.XepLoaiTheoTK(tk);
            int mssv = Convert.ToInt32(cboStudent.SelectedValue);
            string mamh = cboCourse.SelectedValue.ToString();

            Score s = new Score(mssv, mamh, qt, ck, tk, xepLoai, txtMota.Text.Trim());

            if (s.SaveScore())
            {
                MessageBox.Show(
                    $"Lưu điểm thành công!\n" +
                    $"Hệ số: QT {nudQTWeight.Value}% / CK {nudCKWeight.Value}%\n" +
                    $"DiemTK = {tk:F2} — {xepLoai}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayScoreBoard(mssv.ToString());
                LoadCoursesRegisteredByStudent(mssv.ToString());
                ClearInputFields();
            }
            else
                MessageBox.Show("Lưu điểm thất bại!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnExportScorePDF_Click(object sender, EventArgs e)
        {
            btnSaveScore_Click_1(sender, e);
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            ClearInputFields();
            if (cboStudent.SelectedValue != null)
            {
                string mssv = cboStudent.SelectedValue.ToString();
                LoadCoursesRegisteredByStudent(mssv);
                DisplayScoreBoard(mssv);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
        }

        // ===================================================================
        // IMPORT ĐIỂM TỪ EXCEL (nâng cao) — dùng EPPlus giống f_ListStudent
        // ===================================================================
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel chứa dữ liệu điểm"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage pkg = new ExcelPackage(new FileInfo(ofd.FileName)))
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets[0];
                    if (ws.Dimension == null)
                    {
                        MessageBox.Show("File Excel trống!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Đọc header row 1 để map cột
                    int colMSSV = -1, colMaMH = -1, colQT = -1, colCK = -1;
                    for (int c = 1; c <= ws.Dimension.End.Column; c++)
                    {
                        string header = ws.Cells[1, c].Text.Trim().ToUpper();
                        if (header == "MSSV") colMSSV = c;
                        if (header == "MAMH") colMaMH = c;
                        if (header == "DIEMQT") colQT = c;
                        if (header == "DIEMCK") colCK = c;
                    }

                    if (colMSSV < 0 || colMaMH < 0 || colQT < 0 || colCK < 0)
                    {
                        MessageBox.Show(
                            "File Excel cần có các cột: MSSV, MaMH, DiemQT, DiemCK\n" +
                            "(không phân biệt hoa thường)",
                            "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int success = 0, fail = 0;
                    decimal wQT = nudQTWeight.Value / 100m;
                    decimal wCK = nudCKWeight.Value / 100m;

                    for (int r = 2; r <= ws.Dimension.End.Row; r++)
                    {
                        try
                        {
                            string mssvStr = ws.Cells[r, colMSSV].Text.Trim();
                            string mamh = ws.Cells[r, colMaMH].Text.Trim();
                            string qtStr = ws.Cells[r, colQT].Text.Trim();
                            string ckStr = ws.Cells[r, colCK].Text.Trim();

                            if (string.IsNullOrEmpty(mssvStr) || string.IsNullOrEmpty(mamh)) { fail++; continue; }

                            int mssv = Convert.ToInt32(mssvStr);
                            decimal qt = Convert.ToDecimal(qtStr);
                            decimal ck = Convert.ToDecimal(ckStr);

                            if (qt < 0 || qt > 10 || ck < 0 || ck > 10) { fail++; continue; }

                            decimal tk = Math.Round(qt * wQT + ck * wCK, 2);
                            string xl = Score.XepLoaiTheoTK(tk);

                            Score s = new Score(mssv, mamh, qt, ck, tk, xl, "Import từ Excel");
                            if (s.SaveScore()) success++;
                            else fail++;
                        }
                        catch { fail++; }
                    }

                    MessageBox.Show(
                        $"Import hoàn tất!\n" +
                        $"Hệ số: QT {nudQTWeight.Value}% / CK {nudCKWeight.Value}%\n" +
                        $"Thành công: {success}  |  Thất bại/Lỗi: {fail}",
                        "Kết quả Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload bảng điểm nếu đang chọn sinh viên
                    if (cboStudent.SelectedValue != null)
                    {
                        string mssv = cboStudent.SelectedValue.ToString();
                        DisplayScoreBoard(mssv);
                        LoadCoursesRegisteredByStudent(mssv);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file Excel: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================================================================
        // [AI] OCR NHẬN DẠNG CHỮ SỐ TỪ ẢNH BẢNG ĐIỂM (nâng cao)
        // ===================================================================
        private void btnOCRScore_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.tiff",
                Title = "Chọn ảnh bảng điểm"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                btnOCRScore.Enabled = false;
                btnOCRScore.Text = "⏳ Đang đọc...";

                // Đọc ảnh và chạy OCR bằng Tesseract
                using (var engine = new Tesseract.TesseractEngine(
                    @"./tessdata", "eng", Tesseract.EngineMode.Default))
                {
                    using (var img = Tesseract.Pix.LoadFromFile(ofd.FileName))
                    {
                        using (var page = engine.Process(img))
                        {
                            string rawText = page.GetText();

                            // Parse ra các số thập phân từ text OCR
                            var numbers = System.Text.RegularExpressions.Regex
                                .Matches(rawText, @"\b\d+([.,]\d+)?\b")
                                .Cast<System.Text.RegularExpressions.Match>()
                                .Select(m => m.Value.Replace(",", "."))
                                .Where(s => decimal.TryParse(s,
                                    System.Globalization.NumberStyles.Any,
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    out decimal val) && val >= 0 && val <= 10)
                                .ToList();

                            if (numbers.Count == 0)
                            {
                                MessageBox.Show(
                                    "OCR không tìm thấy số điểm hợp lệ (0-10) trong ảnh.\n" +
                                    "Vui lòng chụp ảnh rõ hơn và thử lại.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Hiện kết quả và hỏi chọn điền vào ô nào
                            string danhSachSo = string.Join(", ", numbers);
                            string msg =
                                $"OCR đọc được các số điểm: {danhSachSo}\n\n" +
                                $"Raw text:\n{rawText}\n\n" +
                                $"Bạn muốn điền vào:\n" +
                                $"[Yes] Điểm QT = {(numbers.Count > 0 ? numbers[0] : "?")}  " +
                                $"Điểm CK = {(numbers.Count > 1 ? numbers[1] : "?")}\n" +
                                $"[No] Tự điền thủ công";

                            DialogResult dr = MessageBox.Show(msg, "Kết quả OCR",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                            if (dr == DialogResult.Yes)
                            {
                                if (numbers.Count >= 1) txtQT.Text = numbers[0];
                                if (numbers.Count >= 2) txtCK.Text = numbers[1];
                                MessageBox.Show("Đã điền điểm từ OCR thành công!", "Thành công",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi OCR: " + ex.Message + "\n\n" +
                    "Đảm bảo đã cài Tesseract và có thư mục tessdata trong thư mục project.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnOCRScore.Enabled = true;
                btnOCRScore.Text = "📷 OCR Đọc điểm từ ảnh";
            }
        }
        private void txtQT_TextChanged(object sender, EventArgs e) { }
        private void txtCK_TextChanged(object sender, EventArgs e) { }

        private void dgvScores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước khi xuất.", "Thông báo");
                return;
            }

            string mssv = cboStudent.SelectedValue.ToString();
            string studentName = cboStudent.Text;
            DataTable dt = Score.GetStudentScoreBoard(mssv);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Sinh viên này chưa có điểm nào.", "Thông báo");
                return;
            }

            ReportExportService.ExportScoreToPDF(dt, studentName, mssv);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboStudent.SelectedValue.ToString() == "System.Data.DataRowView")
            {
                MessageBox.Show("Ní vui lòng chọn một Sinh viên từ danh sách trước khi xuất bảng điểm nhé!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mssv = cboStudent.SelectedValue.ToString();
            string studentName = cboStudent.Text;

            DataTable dt = Score.GetStudentScoreBoard(mssv);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show($"Sinh viên {studentName} hiện tại chưa có dữ liệu điểm môn học nào để xuất file PDF ní ơi!", "Bảng điểm trống",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {

                ReportExportService.ExportScoreToPDF(dt, studentName, mssv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gặp sự cố phát sinh khi đang dựng cấu trúc tệp PDF: " + ex.Message, "Lỗi phân hệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}