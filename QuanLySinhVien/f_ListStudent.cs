using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ListStudent : BaseForm
    {
        private DataView svView;
        private string _importFilePath = "";

        // API Key 
        private readonly string apiKey = "Điền API zô, push lên thì xóa đi git nó quét";

        public f_ListStudent()
        {
            InitializeComponent();
        }

        private void f_ListStudent_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvStudents.CellDoubleClick += (s, ev) =>
            {
                if (ev.RowIndex < 0) return;
                f_EditStudent editForm = new f_EditStudent();
                editForm.ShowDialog();
                LoadData();
            };
        }

 
        private void LoadData()
        {
            try
            {
                DataTable dt = Student.GetStudents();
                if (dt == null) return;

                svView = new DataView(dt);
                dgvStudents.DataSource = svView;

                dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
                dgvStudents.Columns["Fname"].HeaderText = "Họ";
                dgvStudents.Columns["Lname"].HeaderText = "Tên";
                dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Dob"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
                dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
                dgvStudents.Columns["Email"].HeaderText = "Email";

                if (dgvStudents.Columns["Pture"] != null)
                {
                    dgvStudents.Columns["Pture"].HeaderText = "Hình ảnh";
                    ((DataGridViewImageColumn)dgvStudents.Columns["Pture"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                dgvStudents.RowTemplate.Height = 60;
                foreach (DataGridViewRow row in dgvStudents.Rows)
                    row.Height = 60;

                UpdateTotalCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách: " + ex.Message);
            }
        }

        private void UpdateTotalCount()
        {
            if (dgvStudents.DataSource == null) return;
            int realCount = dgvStudents.AllowUserToAddRows ? dgvStudents.Rows.Count - 1 : dgvStudents.Rows.Count;
            if (realCount < 0) realCount = 0;
            lblTotal.Text = "Tổng số sinh viên: " + realCount;
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm..." || svView == null) return;

            string keyword = txtSearch.Text.Trim().Replace("'", "''"); 
            if (string.IsNullOrEmpty(keyword))
            {
                svView.RowFilter = ""; 
            }
            else
            {
          
                svView.RowFilter = $"MSSV LIKE '%{keyword}%' OR Fname LIKE '%{keyword}%' OR Lname LIKE '%{keyword}%'";
            }
            UpdateTotalCount();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

       
        private void cboFilterGender_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (svView == null) return;
            string selected = cboFilterGender.Text.Trim();
            svView.RowFilter = (selected == "Tất cả" || string.IsNullOrEmpty(selected)) ? "" : $"Gder = '{selected}'";
            UpdateTotalCount();
        }

        private void cboSortBy_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (svView == null) return;
            string selected = cboSortBy.Text.Trim();
            if (selected == "Mã sinh viên")
                svView.Sort = "MSSV ASC";
            else if (selected == "Tên")
                svView.Sort = "Lname ASC";
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"DanhSachSV_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage pkg = new ExcelPackage())
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Danh sách SV");
                    string[] headers = { "Mã SV", "Họ", "Tên", "Ngày sinh", "Giới tính", "Điện thoại", "Email" };
                    string[] colNames = { "MSSV", "Fname", "Lname", "Dob", "Gder", "Phone", "Email" };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = ws.Cells[1, i + 1];
                        cell.Value = headers[i];
                        cell.Style.Font.Bold = true;
                        cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(31, 73, 125));
                        cell.Style.Font.Color.SetColor(Color.White);
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }

                    int rowIdx = 2;
                    foreach (DataRowView drv in svView)
                    {
                        for (int c = 0; c < colNames.Length; c++)
                        {
                            var val = drv[colNames[c]];
                            ws.Cells[rowIdx, c + 1].Value = (colNames[c] == "Dob" && val != DBNull.Value)
                                ? Convert.ToDateTime(val).ToString("dd/MM/yyyy")
                                : val?.ToString() ?? "";
                        }
                        rowIdx++;
                    }
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();
                    pkg.SaveAs(new FileInfo(sfd.FileName));
                }

                DialogResult dr = MessageBox.Show("Export thành công! Bạn có muốn mở file Excel vừa xuất lên không?",
                                                  "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Export: " + ex.Message); }
        }

        
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel danh sách sinh viên"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            _importFilePath = ofd.FileName;
            lblFilePath.Text = Path.GetFileName(_importFilePath);

            lblStatus.Text = "Đang kết nối AI phân tích cấu trúc file và kiểm tra lỗi...";
            lblStatus.ForeColor = Color.OrangeRed;

            PreviewExcelWithAI(_importFilePath);
        }

      
        private async void PreviewExcelWithAI(string path)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage pkg = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets[0];
                    if (ws.Dimension == null) { MessageBox.Show("File Excel trống!"); return; }

                    List<string> excelHeaders = new List<string>();
                    List<List<string>> excelRows = new List<List<string>>();

                    int startCol = ws.Dimension.Start.Column;
                    int endCol = ws.Dimension.End.Column;
                    int endRow = ws.Dimension.End.Row;

              
                    for (int c = startCol; c <= endCol; c++)
                    {
                        excelHeaders.Add(ws.Cells[1, c].Text.Trim());
                    }

        
                    for (int r = 2; r <= endRow; r++)
                    {
                        List<string> rowData = new List<string>();
                        for (int c = startCol; c <= endCol; c++)
                        {
                            rowData.Add(ws.Cells[r, c].Text.Trim());
                        }
                        excelRows.Add(rowData);
                    }

                    if (string.IsNullOrEmpty(apiKey) || apiKey.Trim() == "")
                    {
                        MessageBox.Show("Hệ thống đang chạy ở chế độ Local (Chưa điền API Key AI). Hãy bổ sung API Key để kích hoạt Trí Tuệ Nhân Tạo.", "Lưu ý");
                        ProcessLocalBackup(excelHeaders, excelRows);
                        return;
                    }

                 
                    string aiResponseJson = await CallGeminiToAnalyze(excelHeaders, excelRows);

                    if (!string.IsNullOrEmpty(aiResponseJson))
                    {
                       
                        DataTable dtPreview = JsonConvert.DeserializeObject<DataTable>(aiResponseJson);
                        dgvPreview.DataSource = dtPreview;

                        if (dgvPreview.Columns["Lỗi"] != null) dgvPreview.Columns["Lỗi"].Visible = false;

                        lblStatus.Text = $"AI ánh xạ dữ liệu thành công! Sẵn sàng xử lý {dtPreview.Rows.Count} dòng.";
                        lblStatus.ForeColor = Color.DarkGreen;
                    }
                    else
                    {
                        ProcessLocalBackup(excelHeaders, excelRows);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phân tích AI: " + ex.Message);
                lblStatus.Text = "Lỗi nạp file Excel.";
                lblStatus.ForeColor = Color.Red;
            }
        }

 
        private async Task<string> CallGeminiToAnalyze(List<string> headers, List<List<string>> rows)
        {
            using (HttpClient client = new HttpClient())
            {
                string prompt = "Bạn là trợ lý AI thông minh tích hợp trong ứng dụng Quản lý sinh viên.\n" +
                                "Nhiệm vụ 1 (Ánh xạ cột): Hãy phân tích các tiêu đề cột thô của file Excel sau: " + JsonConvert.SerializeObject(headers) + " " +
                                "để ánh xạ một cách thông minh vào các thuộc tính hệ thống: MSSV, Họ, Tên, Ngày sinh, Giới tính, Điện thoại, Email.\n" +
                                "Nhiệm vụ 2 (Kiểm tra lỗi): Đọc và phân tích mảng dữ liệu thô này: " + JsonConvert.SerializeObject(rows) + ".\n" +
                                "Hãy kiểm tra xem dòng nào bị khuyết MSSV, khuyết Tên, hoặc cột Ngày sinh có sai định dạng ngày tháng không. Nếu có lỗi, ghi rõ lý do vào thuộc tính 'Lỗi', nếu không lỗi để trống.\n" +
                                "Hãy chuẩn hóa ngày sinh về định dạng dd/MM/yyyy.\n" +
                                "YÊU CẦU BẮT BUỘC: Chỉ trả về duy nhất chuỗi JSON là một mảng các đối tượng chứa chính xác các khóa sau: 'MSSV', 'Họ', 'Tên', 'Ngày sinh', 'Giới tính', 'Điện thoại', 'Email', 'Lỗi'. Không kèm theo bất kỳ văn bản giải thích hay ký tự định dạng markdown nào cả.";

                var payload = new
                {
                    contents = new[] {
                        new {
                            role = "user",
                            parts = new[] { new { text = prompt } }
                        }
                    },
                    generationConfig = new
                    {
                        responseMimeType = "application/json",
                        temperature = 0.2
                    }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
                string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}";

                try
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    string rawResult = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(rawResult)) return null;

                    if (rawResult.Trim().StartsWith("<"))
                    {
                        MessageBox.Show("Mạng Wi-Fi đang chặn kết nối hoặc API Key không hợp lệ (Phản hồi HTML).", "Cảnh báo");
                        return null;
                    }

                    dynamic resultObj = JsonConvert.DeserializeObject(rawResult);

 
                    if (resultObj.candidates != null && resultObj.candidates[0].content != null && resultObj.candidates[0].content.parts != null)
                    {
                        string cleanJson = resultObj.candidates[0].content.parts[0].text.ToString();
                        cleanJson = cleanJson.Replace("```json", "").Replace("```", "").Trim();
                        return cleanJson;
                    }
                    else if (resultObj.error != null)
                    {
                        MessageBox.Show("Lỗi hệ thống từ Google API: " + resultObj.error.message.ToString(), "Thông báo lỗi");
                        return null;
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi kết nối HTTP: " + ex.Message);
                    return null;
                }
            }
        }


        private void ProcessLocalBackup(List<string> headers, List<List<string>> rows)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MSSV"); dt.Columns.Add("Họ"); dt.Columns.Add("Tên");
            dt.Columns.Add("Ngày sinh"); dt.Columns.Add("Giới tính");
            dt.Columns.Add("Điện thoại"); dt.Columns.Add("Email");
            dt.Columns.Add("Lỗi");

            foreach (var row in rows)
            {
                if (row.Count < 3) continue;
                string mssv = row[0];
                string fname = row[1];
                string lname = row[2];
                string dob = row.Count > 3 ? row[3] : "";
                string gder = row.Count > 4 ? row[4] : "";
                string phone = row.Count > 5 ? row[5] : "";
                string email = row.Count > 6 ? row[6] : "";

                string err = "";
                if (string.IsNullOrEmpty(mssv)) err += "Khuyết MSSV; ";
                if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname)) err += "Khuyết Tên; ";

                dt.Rows.Add(mssv, fname, lname, dob, gder, phone, email, err);
            }
            dgvPreview.DataSource = dt;
            if (dgvPreview.Columns["Lỗi"] != null) dgvPreview.Columns["Lỗi"].Visible = false;
            lblStatus.Text = "Đọc file ở chế độ Local (Không AI).";
            lblStatus.ForeColor = Color.DarkBlue;
        }


        private void dgvPreview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPreview.Rows[e.RowIndex].Cells["Lỗi"].Value != null)
            {
                string errorStr = dgvPreview.Rows[e.RowIndex].Cells["Lỗi"].Value.ToString();
                if (!string.IsNullOrEmpty(errorStr))
                {
                    dgvPreview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                    dgvPreview.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dgvPreview.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int success = 0, fail = 0;
            My_DB db = new My_DB();

            try
            {
                db.openConnection();
                foreach (DataGridViewRow row in dgvPreview.Rows)
                {
                    if (row.IsNewRow) continue;

                    string err = row.Cells["Lỗi"].Value?.ToString() ?? "";
                    if (!string.IsNullOrEmpty(err)) { fail++; continue; }

                    string mssv = row.Cells["MSSV"].Value?.ToString().Trim() ?? "";
                    string fname = row.Cells["Họ"].Value?.ToString().Trim() ?? "";
                    string lname = row.Cells["Tên"].Value?.ToString().Trim() ?? "";
                    string dobStr = row.Cells["Ngày sinh"].Value?.ToString().Trim() ?? "";
                    string gder = row.Cells["Giới tính"].Value?.ToString().Trim() ?? "";
                    string phone = row.Cells["Điện thoại"].Value?.ToString().Trim() ?? "";
                    string email = row.Cells["Email"].Value?.ToString().Trim() ?? "";

                    try
                    {
                        DateTime.TryParseExact(dobStr, new[] { "dd/MM/yyyy", "yyyy-MM-dd", "MM/dd/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dob);

                        SqlCommand cmd = new SqlCommand(
                            "IF EXISTS (SELECT 1 FROM Student WHERE MSSV = @mssv) " +
                            "BEGIN " +
                            "   UPDATE Student SET Fname=@fn, Lname=@ln, Dob=@dob, Gder=@gder, Phone=@phone, Email=@email WHERE MSSV = @mssv " +
                            "END " +
                            "ELSE " +
                            "BEGIN " +
                            "   INSERT INTO Student (MSSV, Fname, Lname, Dob, Gder, Phone, Email) VALUES (@mssv, @fn, @ln, @dob, @gder, @phone, @email) " +
                            "END", db.conn);

                        cmd.Parameters.AddWithValue("@mssv", mssv);
                        cmd.Parameters.AddWithValue("@fn", fname);
                        cmd.Parameters.AddWithValue("@ln", lname);
                        cmd.Parameters.AddWithValue("@dob", dob == DateTime.MinValue ? (object)DBNull.Value : dob);
                        cmd.Parameters.AddWithValue("@gder", gder);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", email);

                        cmd.ExecuteNonQuery();
                        success++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi ở sinh viên {mssv}: {ex.Message}", "Lỗi Import", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        fail++;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi kết nối DB: " + ex.Message); }
            finally { db.closeConnection(); }

            MessageBox.Show($"Import hoàn tất!\nThành công/Đã cập nhật: {success}\nThất bại/Lỗi định dạng: {fail}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (success > 0)
            {
                LoadData();
                tabControl1.SelectedTab = tabDanhSach;
            }
        }

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}