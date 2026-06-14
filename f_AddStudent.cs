using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Speech.Recognition;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Tesseract;

namespace QuanLySinhVien
{
    public partial class f_AddStudent : UserControl
    {
        byte[] studentImage = null;
        private SpeechRecognitionEngine recognizer = null;
        private static readonly HttpClient httpClient = new HttpClient();

        public f_AddStudent()
        {
            InitializeComponent();
            RegisterRealTimeValidation();
            SetupSuggestList();
        }

        private void SetupSuggestList()
        {
            lstSuggest.Visible = false;
            lstSuggest.BringToFront();
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

        private void RegisterRealTimeValidation()
        {
            txtMSSV.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtMSSV.Text.Trim()))
                    erp2.SetError(txtMSSV, "Mã số sinh viên không được để trống!");
                else if (!int.TryParse(txtMSSV.Text.Trim(), out _))
                    erp2.SetError(txtMSSV, "MSSV bắt buộc phải là số, không chứa chữ hay ký tự đặc biệt!");
                else
                    erp2.SetError(txtMSSV, "");
            };

            txtFname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtFname.Text.Trim()))
                    erp2.SetError(txtFname, "Vui lòng nhập Họ của sinh viên!");
                else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
                    erp2.SetError(txtFname, "Họ không được chứa chữ số!");
                else
                    erp2.SetError(txtFname, "");
            };

            txtLname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtLname.Text.Trim()))
                    erp2.SetError(txtLname, "Vui lòng nhập Tên của sinh viên!");
                else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
                    erp2.SetError(txtLname, "Tên không được chứa chữ số!");
                else
                    erp2.SetError(txtLname, "");
            };

            txtPhone.TextChanged += (s, e) => {
                if (!string.IsNullOrEmpty(txtPhone.Text.Trim()) && !long.TryParse(txtPhone.Text.Trim(), out _))
                    erp2.SetError(txtPhone, "Số điện thoại không hợp lệ! Chỉ được nhập số.");
                else
                    erp2.SetError(txtPhone, "");
            };

            txtEmail.TextChanged += (s, e) => {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern) && txtEmail.Text.Length > 0)
                    erp2.SetError(txtEmail, "Định dạng Email không đúng!");
                else
                    erp2.SetError(txtEmail, "");
            };
        }

        private bool ValidateInput()
        {
            erp2.Clear();
            bool isValid = true;

            if (string.IsNullOrEmpty(txtMSSV.Text.Trim()))
            { erp2.SetError(txtMSSV, "Mã số sinh viên không được để trống!"); isValid = false; }
            else if (!int.TryParse(txtMSSV.Text.Trim(), out _))
            { erp2.SetError(txtMSSV, "MSSV bắt buộc phải là số!"); isValid = false; }

            if (string.IsNullOrEmpty(txtFname.Text.Trim()))
            { erp2.SetError(txtFname, "Vui lòng nhập Họ!"); isValid = false; }
            else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
            { erp2.SetError(txtFname, "Họ không được chứa chữ số!"); isValid = false; }

            if (string.IsNullOrEmpty(txtLname.Text.Trim()))
            { erp2.SetError(txtLname, "Vui lòng nhập Tên!"); isValid = false; }
            else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
            { erp2.SetError(txtLname, "Tên không được chứa chữ số!"); isValid = false; }

            if (cboGender.SelectedIndex == -1 || string.IsNullOrEmpty(cboGender.Text))
            { erp2.SetError(cboGender, "Vui lòng chọn Giới tính!"); isValid = false; }

            if (!string.IsNullOrEmpty(txtPhone.Text.Trim()) && !long.TryParse(txtPhone.Text.Trim(), out _))
            { erp2.SetError(txtPhone, "Số điện thoại không hợp lệ!"); isValid = false; }

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                { erp2.SetError(txtEmail, "Định dạng Email không đúng!"); isValid = false; }
            }

            return isValid;
        }

        private GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        public void LayThongTinSua(string mssv, string ho, string ten, string ngaysinh, string gioitinh, string dienthoai, string email)
        {
            txtMSSV.Text = mssv;
            txtFname.Text = ho;
            txtLname.Text = ten;
            if (DateTime.TryParse(ngaysinh, out DateTime date))
                dtpDob.Value = date;
            cboGender.Text = gioitinh;
            txtPhone.Text = dienthoai;
            txtEmail.Text = email;
            txtMSSV.Enabled = false;
            btnAdd.Text = "Cập nhật";
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Image original = Image.FromFile(ofd.FileName);
                Bitmap resized = new Bitmap(200, 200);
                using (Graphics g = Graphics.FromImage(resized))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(original, 0, 0, 200, 200);
                }
                picStudent.Image = resized;
                MemoryStream ms = new MemoryStream();
                resized.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                studentImage = ms.ToArray();
                original.Dispose();
            }
        }

        private async void txtAddress_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtAddress.Text.Trim();
            if (keyword.Length < 3)
            {
                lstSuggest.Visible = false;
                return;
            }

            try
            {
                string url = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(keyword)}&format=json&limit=5&countrycodes=vn";
                httpClient.DefaultRequestHeaders.UserAgent.Clear();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("QuanLySinhVien/1.0");
                string json = await httpClient.GetStringAsync(url);
                JArray results = JArray.Parse(json);

                lstSuggest.Items.Clear();
                foreach (var item in results)
                    lstSuggest.Items.Add(item["display_name"].ToString());

                if (lstSuggest.Items.Count > 0)
                {
                    lstSuggest.Visible = true;
                    lstSuggest.BringToFront();
                }
                else
                {
                    lstSuggest.Visible = false;
                }
            }
            catch { lstSuggest.Visible = false; }
        }

        private void lstSuggest_Click(object sender, EventArgs e)
        {
            if (lstSuggest.SelectedItem != null)
            {
                txtAddress.Text = lstSuggest.SelectedItem.ToString();
                lstSuggest.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Vui lòng sửa lại các thông tin nhập sai!", "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            DataTable dup = Student.CheckDuplicate(txtFname.Text.Trim(), txtLname.Text.Trim(), dtpDob.Value);
            if (dup.Rows.Count > 0)
            {
                string mssvTrung = dup.Rows[0]["MSSV"].ToString();
                DialogResult res = MessageBox.Show(
                    $"Cảnh báo: Sinh viên '{txtFname.Text} {txtLname.Text}' sinh ngày {dtpDob.Value:dd/MM/yyyy} " +
                    $"có thể đã tồn tại với MSSV {mssvTrung}!\nBạn có muốn tiếp tục thêm mới không?",
                    "Cảnh báo trùng lặp", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.No) return;
            }

            int mssv = Convert.ToInt32(txtMSSV.Text.Trim());
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                if (btnAdd.Text == "Cập nhật")
                {
                    string query = "UPDATE Student SET Fname=@fname, Lname=@lname, Dob=@dob, Gder=@gder, Phone=@phone, Email=@email, Pture=@pic WHERE MSSV=@mssv";
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    cmd.Parameters.AddWithValue("@fname", txtFname.Text.Trim());
                    cmd.Parameters.AddWithValue("@lname", txtLname.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                    cmd.Parameters.AddWithValue("@gder", cboGender.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@pic", studentImage == null ? (object)SqlBinary.Null : studentImage);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Student sv = new Student(mssv, txtFname.Text.Trim(), txtLname.Text.Trim(),
                        dtpDob.Value, cboGender.Text, txtPhone.Text.Trim(),
                        txtAddress.Text.Trim(), "", txtEmail.Text.Trim(), studentImage);

                    if (sv.AddStudent())
                    {
                        MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClear_Click(sender, e);
                    }
                    else
                    {
                        erp2.SetError(txtMSSV, "MSSV đã tồn tại!");
                        MessageBox.Show("MSSV đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMSSV.Focus();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    erp2.SetError(txtMSSV, "MSSV đã tồn tại!");
                    MessageBox.Show("MSSV đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMSSV.Focus();
                }
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear(); txtFname.Clear(); txtLname.Clear();
            dtpDob.Value = DateTime.Now;
            cboGender.SelectedIndex = -1;
            txtPhone.Clear(); txtEmail.Clear();
            txtAddress.Clear();
            lstSuggest.Visible = false;
            picStudent.Image = null;
            studentImage = null;
            erp2.Clear();
            txtMSSV.Focus();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
        }

        private void btnViewlist_Click(object sender, EventArgs e)
        {
        }

        private void btnSpeech_Click(object sender, EventArgs e)
        {
            try
            {
                recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("vi-VN"));
            }
            catch
            {
                recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            }

            try
            {
                recognizer.LoadGrammar(new DictationGrammar());
                recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
                recognizer.SetInputToDefaultAudioDevice();
                btnSpeech.Text = "🎤 Đang nghe...";
                btnSpeech.Enabled = false;
                recognizer.RecognizeAsync(RecognizeMode.Single);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi động mic: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string text = e.Result.Text.ToLower();

            var mssvMatch = Regex.Match(text, @"\d{8}");
            if (mssvMatch.Success)
                txtMSSV.Invoke((Action)(() => txtMSSV.Text = mssvMatch.Value));

            var tenMatch = Regex.Match(text, @"(?:sinh viên|tên)\s+([\w\s]+?)(?:\s+mssv|\s+mã số|$)");
            if (tenMatch.Success)
            {
                string fullName = tenMatch.Groups[1].Value.Trim();
                string[] parts = fullName.Split(' ');
                if (parts.Length >= 2)
                {
                    txtLname.Invoke((Action)(() => txtLname.Text = parts[parts.Length - 1]));
                    txtFname.Invoke((Action)(() => txtFname.Text = string.Join(" ", parts, 0, parts.Length - 1)));
                }
            }

            btnSpeech.Invoke((Action)(() => {
                btnSpeech.Text = "🎤 Giọng nói";
                btnSpeech.Enabled = true;
            }));

            MessageBox.Show("Đã nhận: " + e.Result.Text, "Kết quả");
            recognizer.Dispose();
            recognizer = null;
        }

        private void btnScanCard_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string tessdataPath = Path.Combine(Application.StartupPath, "tessdata");
                    using (var engine = new TesseractEngine(tessdataPath, "vie", EngineMode.Default))
                    using (var img = Pix.LoadFromFile(ofd.FileName))
                    using (var page = engine.Process(img))
                    {
                        string textResult = page.GetText();
                        if (string.IsNullOrEmpty(textResult.Trim()))
                        {
                            MessageBox.Show("Không đọc được chữ! Vui lòng chọn ảnh rõ hơn.", "Thông báo");
                            return;
                        }

                        string[] lines = textResult.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string line in lines)
                        {
                            string cleanLine = line.Trim();
                            string lowerLine = cleanLine.ToLower();

                            if (lowerLine.Contains("mã số") || lowerLine.Contains("id"))
                            {
                                Match mssvMatch = Regex.Match(cleanLine, @"\d{8,10}");
                                if (mssvMatch.Success) txtMSSV.Text = mssvMatch.Value;
                            }

                            if (lowerLine.Contains("họ tên") || lowerLine.Contains("fullname"))
                            {
                                int colonIndex = cleanLine.IndexOf(":");
                                if (colonIndex != -1)
                                {
                                    string fullName = cleanLine.Substring(colonIndex + 1).Trim();
                                    string[] nameParts = fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (nameParts.Length > 0)
                                    {
                                        txtLname.Text = nameParts[nameParts.Length - 1];
                                        txtFname.Text = string.Join(" ", nameParts, 0, nameParts.Length - 1);
                                    }
                                }
                            }

                            if (lowerLine.Contains("ngày sinh") || lowerLine.Contains("dob"))
                            {
                                Match dobMatch = Regex.Match(cleanLine, @"\d{2}/\d{2}/\d{4}|\d{2}-\d{2}-\d{4}");
                                if (dobMatch.Success && DateTime.TryParse(dobMatch.Value.Replace("-", "/"), out DateTime parsedDate))
                                    dtpDob.Value = parsedDate;
                            }

                            if (lowerLine.Contains("nam")) cboGender.Text = "Nam";
                            else if (lowerLine.Contains("nữ") || lowerLine.Contains("nu")) cboGender.Text = "Nữ";
                        }
                        MessageBox.Show("Quét thẻ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi OCR: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
                pnl.Region = new Region(Path);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
                pnl.Region = new Region(Path);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
                pnl.Region = new Region(Path);
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlForm, 25, e);
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlRight, 25, e);
        }
    }
}