using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Tesseract;

namespace QuanLySinhVien
{
    public partial class f_AddStudent : Form
    {
        private TextBox txtMSSV, txtFname, txtLname, txtPhone, txtEmail;
        private DateTimePicker dtpDob;
        private ComboBox cboGender;
        private PictureBox picStudent;
        private byte[] _picBytes = null;

        public f_AddStudent()
        {
            InitializeComponent();
            ApplyStyle();
        }

        private void ApplyStyle()
        {
            UIHelper.ApplyFormStyle(this, "Thêm Sinh viên", 620, 580);
            this.Controls.Clear();

            var header = UIHelper.CreateSmallHeader(this, "THÊM SINH VIÊN");
            this.Controls.Add(header);

            // Card trái
            var cardLeft = UIHelper.CreateCard(15, 65, 370, 480);
            this.Controls.Add(cardLeft);

            cardLeft.Controls.Add(UIHelper.CreateTitle("Thông tin SV", 15, 10));

            cardLeft.Controls.Add(UIHelper.CreateLabel("Mã số sinh viên", 15, 55));
            txtMSSV = UIHelper.CreateTextBox(15, 72, 340);
            cardLeft.Controls.Add(txtMSSV);

            cardLeft.Controls.Add(UIHelper.CreateLabel("Họ", 15, 112));
            txtFname = UIHelper.CreateTextBox(15, 129, 155);
            cardLeft.Controls.Add(txtFname);

            cardLeft.Controls.Add(UIHelper.CreateLabel("Tên", 185, 112));
            txtLname = UIHelper.CreateTextBox(185, 129, 155);
            cardLeft.Controls.Add(txtLname);

            cardLeft.Controls.Add(UIHelper.CreateLabel("Ngày sinh", 15, 169));
            dtpDob = new DateTimePicker();
            dtpDob.Size = new Size(340, 30);
            dtpDob.Location = new Point(15, 186);
            dtpDob.Font = new Font("Arial", 10);
            cardLeft.Controls.Add(dtpDob);

            cardLeft.Controls.Add(UIHelper.CreateLabel("Giới tính", 15, 226));
            cboGender = new ComboBox();
            cboGender.Items.AddRange(new[] { "Nam", "Nữ", "Khác" });
            cboGender.Font = new Font("Arial", 10);
            cboGender.Size = new Size(340, 30);
            cboGender.Location = new Point(15, 243);
            cboGender.FlatStyle = FlatStyle.Flat;
            cboGender.BackColor = UIHelper.LightBlue;
            cardLeft.Controls.Add(cboGender);

            cardLeft.Controls.Add(UIHelper.CreateLabel("Điện thoại", 15, 283));
            txtPhone = UIHelper.CreateTextBox(15, 300, 340);
            cardLeft.Controls.Add(txtPhone);

            cardLeft.Controls.Add(UIHelper.CreateLabel("Email", 15, 340));
            txtEmail = UIHelper.CreateTextBox(15, 357, 340);
            cardLeft.Controls.Add(txtEmail);

            // Buttons
            var btnAdd = UIHelper.CreatePrimaryButton("Thêm", 15, 415, 160);
            btnAdd.Click += BtnAdd_Click;
            cardLeft.Controls.Add(btnAdd);

            var btnClear = UIHelper.CreateSecondaryButton("Xóa trắng", 190, 415, 160);
            btnClear.Click += BtnClear_Click;
            cardLeft.Controls.Add(btnClear);

            // Card phải - ảnh
            var cardRight = UIHelper.CreateCard(400, 65, 200, 480);
            this.Controls.Add(cardRight);

            Label lblPhoto = new Label();
            lblPhoto.Text = "Ảnh đại diện";
            lblPhoto.Font = new Font("Arial", 10, FontStyle.Bold);
            lblPhoto.ForeColor = UIHelper.PrimaryBlue;
            lblPhoto.AutoSize = false;
            lblPhoto.Size = new Size(180, 25);
            lblPhoto.Location = new Point(10, 15);
            lblPhoto.TextAlign = ContentAlignment.MiddleCenter;
            cardRight.Controls.Add(lblPhoto);

            picStudent = new PictureBox();
            picStudent.Size = new Size(160, 160);
            picStudent.Location = new Point(20, 45);
            picStudent.SizeMode = PictureBoxSizeMode.Zoom;
            picStudent.BorderStyle = BorderStyle.FixedSingle;
            picStudent.BackColor = UIHelper.LightBlue;
            cardRight.Controls.Add(picStudent);

            var btnPic = UIHelper.CreatePrimaryButton("Chọn ảnh", 20, 215, 160);
            btnPic.Click += BtnPic_Click;
            cardRight.Controls.Add(btnPic);

            var btnScanCard = UIHelper.CreateSecondaryButton("🔍 Quét thẻ SV", 20, 263, 160);
            btnScanCard.Click += BtnScanCard_Click;
            cardRight.Controls.Add(btnScanCard);

            var btnList = UIHelper.CreateSecondaryButton("Danh sách SV", 10, 415, 180);
            btnList.Click += (s, e) =>
            {
                f_ListStudent frm = new f_ListStudent();
                frm.ShowDialog();
            };
            cardRight.Controls.Add(btnList);
        }

        private void BtnPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                _picBytes = File.ReadAllBytes(ofd.FileName);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtFname.Text) ||
                string.IsNullOrEmpty(txtLname.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMSSV.Text, out int mssv))
            {
                MessageBox.Show("MSSV phải là số!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Student s = new Student(mssv, txtFname.Text, txtLname.Text,
                dtpDob.Value, cboGender.Text, txtPhone.Text,
                "", "", txtEmail.Text, _picBytes);

            if (s.AddStudent())
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = txtFname.Text = txtLname.Text = "";
            txtPhone.Text = txtEmail.Text = "";
            cboGender.SelectedIndex = -1;
            picStudent.Image = null;
            _picBytes = null;
        }

        private void BtnScanCard_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Chọn ảnh thẻ sinh viên";
                dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";

                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    picStudent.Image = Image.FromFile(dlg.FileName);
                    picStudent.SizeMode = PictureBoxSizeMode.Zoom;
                    _picBytes = File.ReadAllBytes(dlg.FileName);

                    string tessDataPath = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "tessdata");

                    using (var engine = new TesseractEngine(tessDataPath, "vie+eng", EngineMode.Default))
                    using (var img = Pix.LoadFromFile(dlg.FileName))
                    using (var page = engine.Process(img))
                    {
                        string text = page.GetText();
                        ExtractAndFillFromOCR(text);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi OCR: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ExtractAndFillFromOCR(string rawText)
        {
            string text = rawText.Replace("\n", " ").Replace("\r", " ");
            bool found = false;

            // Tìm MSSV — dãy số 8 chữ số bắt đầu bằng 2x
            Match mssvMatch = Regex.Match(text, @"\b(2[0-9]{7})\b");
            if (mssvMatch.Success)
            {
                txtMSSV.Text = mssvMatch.Value;
                found = true;
            }

            // Tìm họ tên — dòng sau "Họ và tên"
            Match nameMatch = Regex.Match(text,
                @"[Hh]ọ\s*(và|va)\s*[Tt]ên\s*[:\-]?\s*([A-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚÝĂĐƠƯ][^\d]{5,40})",
                RegexOptions.IgnoreCase);
            if (nameMatch.Success)
            {
                string fullName = nameMatch.Groups[2].Value.Trim();
                string[] parts = fullName.Split(' ');
                if (parts.Length >= 2)
                {
                    txtLname.Text = parts[parts.Length - 1];
                    txtFname.Text = string.Join(" ", parts, 0, parts.Length - 1);
                    found = true;
                }
            }

            // Tìm ngày sinh — dd/MM/yyyy hoặc dd-MM-yyyy
            Match dobMatch = Regex.Match(text, @"\b(\d{1,2})[\/\-](\d{1,2})[\/\-](\d{4})\b");
            if (dobMatch.Success)
            {
                if (DateTime.TryParseExact(dobMatch.Value,
                    new[] { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy" },
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dob))
                {
                    dtpDob.Value = dob;
                    found = true;
                }
            }

            if (found)
                MessageBox.Show("✅ Đã trích xuất thông tin từ thẻ SV!\nKiểm tra lại trước khi lưu.",
                    "OCR thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("⚠️ Không nhận dạng được thông tin.\nVui lòng nhập tay hoặc thử ảnh khác.",
                    "OCR không nhận dạng được", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}