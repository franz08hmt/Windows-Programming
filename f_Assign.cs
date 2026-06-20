using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
    
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text;
using System.Text.RegularExpressions;
using System.Speech.Recognition;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Tesseract;
using System.Linq;
using System.Globalization;


namespace QuanLySinhVien
{
    public partial class f_Assign : UserControl
    {
        private My_DB db = new My_DB();
        private bool openedFromList = false;

        byte[] hrImage = null;
        private DataView gvView;
        private string _importFilePath = "";
        private SpeechRecognitionEngine recognizer = null;
        private static readonly HttpClient httpClient = new HttpClient();
        private string _origFname = "";
        private string _origLname = "";
        private string _origGder = "";
        private string _origPhone = "";
        private string _origEmail = "";

        private readonly string apiKey = "Điền API zô, push lên thì xóa đi git nó quét";

        public f_Assign()
        {
            InitializeComponent();
            RegisterRealTimeValidation1();
            SetupSuggestList();

            if (this.Controls.Find("lstSuggest", true).Length > 0)
            {
                lstSuggest.Click += new System.EventHandler(this.lstSuggest_Click);
            }

            this.Resize += (s, e) => this.BeginInvoke(new Action(() =>
            {
                RepositionTab4Controls();
                RepositionPnlFormControls();
            }));
        }

        private void RepositionTab4Controls()
        {
            const int gap     = 8;
            const int minPnlW = 320;

            pnlForm.Anchor = System.Windows.Forms.AnchorStyles.None;

            int containerW = this.ClientSize.Width;
            if (containerW < 400) return;   // chưa layout xong

            int dgvLeft = dgvsuathongtin.Left;
            int dgvTop  = dgvsuathongtin.Top;

            // Tỉ lệ 7:3 — DGV chiếm 70%, pnlForm chiếm 30% phần còn lại
            int available = containerW - dgvLeft - gap;
            int dgvW  = available * 7 / 10;
            int pnlW  = available - dgvW;
            if (pnlW < minPnlW) { pnlW = minPnlW; dgvW = available - pnlW; }

            int pnlLeft = dgvLeft + dgvW + gap;

            dgvsuathongtin.Width = dgvW;
            pnlForm.Left   = pnlLeft;
            pnlForm.Top    = dgvTop;              // căn cùng Y với DGV
            pnlForm.Width  = pnlW;
            pnlForm.Height = dgvsuathongtin.Height;
        }

        private bool _pnlFormInited = false;
        private void RepositionPnlFormControls()
        {
            // Lần đầu: bỏ Anchor tất cả control bên trong pnlForm để layout code hoàn toàn kiểm soát
            if (!_pnlFormInited)
            {
                System.Windows.Forms.Control[] inners = {
                    label14, txtMSGV1, label24, textBox1, label25, textBox2,
                    label17, dateTimePicker1, label18, comboBox1, label23, textBox4,
                    label19, textBox3, label27, textBox5,
                    pictureBox4, button4, btnFix, btnDelete, btnRefresh,
                    label15, label16, label20
                };
                foreach (var c in inners)
                    c.Anchor = System.Windows.Forms.AnchorStyles.None;

                label23.Text  = "Email *";
                label15.Visible = false;
                label16.Visible = false;
                label20.Visible = false;
                dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
                button4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
                _pnlFormInited = true;
            }

            const int pad  = 12;
            const int imgW = 155;
            const int gap  = 10;
            int fieldX = pad + imgW + gap;         // = 177
            int fieldW = pnlForm.Width - fieldX - pad;
            if (fieldW < 140) fieldW = 140;

            // --- Cột PHẢI: MSGV, Họ, Tên, Điện thoại, Địa chỉ, Email ---
            // Row 1  y=20
            label14.SetBounds(fieldX,  20, fieldW, 26);  // MSGV *
            txtMSGV1.SetBounds(fieldX, 50, fieldW, 40);  // bottom=90
            // Row 2  y=106
            label24.SetBounds(fieldX, 106, fieldW, 26);  // Họ *
            textBox1.SetBounds(fieldX, 136, fieldW, 40); // bottom=176
            // Row 3  y=192
            label25.SetBounds(fieldX, 192, fieldW, 26);  // Tên *
            textBox2.SetBounds(fieldX, 222, fieldW, 40); // bottom=262
            // Row 4  y=278
            label19.SetBounds(fieldX, 278, fieldW, 26);  // Điện thoại
            textBox3.SetBounds(fieldX, 308, fieldW, 34); // bottom=342
            // Row 5  y=358
            label27.SetBounds(fieldX, 358, fieldW, 26);  // Địa chỉ *
            textBox5.SetBounds(fieldX, 388, fieldW, 80); // multiline, bottom=468
            // Row 6  y=484
            label23.SetBounds(fieldX, 484, fieldW, 26);  // Email *
            textBox4.SetBounds(fieldX, 514, fieldW, 40); // bottom=554

            // --- Cột TRÁI: ảnh + Ngày sinh + Giới tính (control ngắn) ---
            int btn4W = fieldX - pad - 2;                // = 163, vừa khít trước cột phải
            pictureBox4.SetBounds(pad,  20, imgW, 180);  // ảnh 155×180
            button4.SetBounds(pad,     206, btn4W, 40);  // "Chọn ảnh" đủ chỗ (163px)
            label17.SetBounds(pad,     278, imgW,  26);  // Ngày sinh * — căn Row4
            dateTimePicker1.SetBounds(pad, 308, imgW, 34);
            label18.SetBounds(pad,     358, imgW,  26);  // Giới tính * — căn Row5
            comboBox1.SetBounds(pad,   388, imgW,  34);

            // --- 3 nút dưới cùng ---
            int btnY      = 570;   // 554 + 16
            int totalW    = pnlForm.Width - pad * 4;
            int btnW      = totalW / 3;
            int remainder = totalW - btnW * 3;
            btnFix.SetBounds(pad,                  btnY, btnW,             54);
            btnDelete.SetBounds(pad * 2 + btnW,    btnY, btnW,             54);
            btnRefresh.SetBounds(pad*3 + btnW*2,   btnY, btnW + remainder, 54);
            btnRefresh.Visible = true;
        }

        private void BoGocPanel(Panel pnl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(pnl.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(pnl.Width - radius, pnl.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, pnl.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            pnl.Region = new Region(path);
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

        private void f_Assign_Load(object sender, EventArgs e)
        {
            EnsureLoginTeacherColumns();
            LoadHRToComboBox();
            LoadCoursesToComboBox();
            LoadAssignList();
            LoadTeacherData();
            LoadData1();

            dgvsuathongtin.CellClick += new DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // BeginInvoke: đợi AutoScale hoàn tất trước khi reposition
            this.BeginInvoke(new Action(() =>
            {
                RepositionTab4Controls();
                RepositionPnlFormControls();
            }));
        }

        private void EnsureLoginTeacherColumns()
        {
            const string query = @"
IF COL_LENGTH('dbo.Login', 'Dob') IS NULL
    ALTER TABLE dbo.Login ADD Dob DATETIME NULL;
IF COL_LENGTH('dbo.Login', 'Gder') IS NULL
    ALTER TABLE dbo.Login ADD Gder NVARCHAR(10) NULL;
IF COL_LENGTH('dbo.Login', 'Phone') IS NULL
    ALTER TABLE dbo.Login ADD Phone NVARCHAR(15) NULL;
IF COL_LENGTH('dbo.Login', 'Address') IS NULL
    ALTER TABLE dbo.Login ADD Address NVARCHAR(250) NULL;";

            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand(query, db.conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra cấu trúc bảng giảng viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private bool ValidateInput()
        {
            erpEdit.Clear(); // Xóa sạch dấu đỏ cũ của Tab Sửa
            bool isValid = true;

            if (string.IsNullOrEmpty(txtMSGV1.Text.Trim()))
            { erpEdit.SetError(txtMSGV1, "Mã số giảng viên không được để trống!"); isValid = false; }

            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            { erpEdit.SetError(textBox1, "Vui lòng nhập Họ!"); isValid = false; }
            else if (Regex.IsMatch(textBox1.Text.Trim(), @"\d"))
            { erpEdit.SetError(textBox1, "Họ không được chứa chữ số!"); isValid = false; }

            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            { erpEdit.SetError(textBox2, "Vui lòng nhập Tên!"); isValid = false; }
            else if (Regex.IsMatch(textBox2.Text.Trim(), @"\d"))
            { erpEdit.SetError(textBox2, "Tên không được chứa chữ số!"); isValid = false; }

            if (comboBox1.SelectedIndex == -1 || string.IsNullOrEmpty(comboBox1.Text))
            { erpEdit.SetError(comboBox1, "Vui lòng chọn Giới tính!"); isValid = false; }

            if (!string.IsNullOrEmpty(textBox3.Text.Trim()) && !long.TryParse(textBox3.Text.Trim(), out _))
            { erpEdit.SetError(textBox3, "Số điện thoại không hợp lệ! Chỉ được nhập số."); isValid = false; }

            if (!string.IsNullOrEmpty(textBox4.Text.Trim()))
            {
                if (!Regex.IsMatch(textBox4.Text.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                { erpEdit.SetError(textBox4, "Định dạng Email không hợp lệ!"); isValid = false; }
            }

            return isValid;
        }

        private bool ValidateInput1()
        {
            erp2.Clear(); // Xóa sạch dấu đỏ cũ của Tab Thêm
            bool isValid = true;

            if (string.IsNullOrEmpty(txtMSGV.Text.Trim()))
            { erp2.SetError(txtMSGV, "Mã số giảng viên không được để trống!"); isValid = false; }
            else if (!Regex.IsMatch(txtMSGV.Text.Trim(), @"^\d+$"))
            { erp2.SetError(txtMSGV, "Mã số giảng viên bắt buộc phải là ký tự số!"); isValid = false; }

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
            { erp2.SetError(txtPhone, "Số điện thoại không hợp lệ! Chỉ được nhập số."); isValid = false; }

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                { erp2.SetError(txtEmail, "Định dạng Email không đúng!"); isValid = false; }
            }

            return isValid;
        }
        private void LoadData1()
        {
            try
            {
                string query = "SELECT MSGV, Fname, Lname, Dob, Gder, Phone, Email, Address, Pic FROM Login WHERE position = 2 AND VALID = 'True'";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvsuathongtin.DataSource = dt;

                dgvsuathongtin.Columns["MSGV"].HeaderText = "Mã GV";
                dgvsuathongtin.Columns["Fname"].HeaderText = "Họ";
                dgvsuathongtin.Columns["Lname"].HeaderText = "Tên";
                dgvsuathongtin.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvsuathongtin.Columns["Dob"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvsuathongtin.Columns["Gder"].HeaderText = "Giới tính";
                dgvsuathongtin.Columns["Phone"].HeaderText = "Điện thoại";
                dgvsuathongtin.Columns["Email"].HeaderText = "Email";

                // 🛠️ SỬA LỖI 1: Ánh xạ chuẩn tên trường từ DataTable vào Grid để hiện Địa chỉ lên dòng
                if (dgvsuathongtin.Columns["Address"] != null)
                {
                    dgvsuathongtin.Columns["Address"].HeaderText = "Địa chỉ";
                    dgvsuathongtin.Columns["Address"].DataPropertyName = "Address";
                }

                if (dgvsuathongtin.Columns["Pic"] != null)
                {
                    dgvsuathongtin.Columns["Pic"].HeaderText = "Hình ảnh";
                    ((DataGridViewImageColumn)dgvsuathongtin.Columns["Pic"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                dgvsuathongtin.RowTemplate.Height = 40;
                dgvsuathongtin.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
                dgvsuathongtin.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                dgvsuathongtin.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);

                dgvsuathongtin.Columns["MSGV"].MinimumWidth  = 55;
                dgvsuathongtin.Columns["Fname"].MinimumWidth = 55;
                dgvsuathongtin.Columns["Lname"].MinimumWidth = 80;
                dgvsuathongtin.Columns["Dob"].MinimumWidth   = 80;
                dgvsuathongtin.Columns["Gder"].MinimumWidth  = 55;
                dgvsuathongtin.Columns["Phone"].MinimumWidth = 90;
                dgvsuathongtin.Columns["Email"].MinimumWidth = 100;
                if (dgvsuathongtin.Columns["Address"] != null)
                    dgvsuathongtin.Columns["Address"].MinimumWidth = 80;
                if (dgvsuathongtin.Columns["Pic"] != null)
                    dgvsuathongtin.Columns["Pic"].MinimumWidth = 50;
                dgvsuathongtin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách giảng viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetOriginalValues(string fname, string lname, string gder, string phone, string email)
        {
            _origFname = fname;
            _origLname = lname;
            _origGder = gder;
            _origPhone = phone;
            _origEmail = email;

            CheckHighlight();
        }

        private void CheckHighlight()
        {
            textBox1.BackColor = textBox1.Text.Trim() != _origFname ? Color.LightYellow : Color.White;
            textBox2.BackColor = textBox2.Text.Trim() != _origLname ? Color.LightYellow : Color.White;
            comboBox1.BackColor = comboBox1.Text != _origGder ? Color.LightYellow : Color.White;
            textBox3.BackColor = textBox3.Text.Trim() != _origPhone ? Color.LightYellow : Color.White;
            textBox4.BackColor = textBox4.Text.Trim() != _origEmail ? Color.LightYellow : Color.White;
        }
        public void LayThongTinTuDanhSach(string msgv, string ho, string ten, string ngaysinh, string gioitinh, string dienthoai, string email)
        {
            openedFromList = true;
            txtMSGV1.Text = msgv;
            textBox1.Text = ho;
            textBox2.Text = ten;
            textBox3.Text = dienthoai;
            textBox4.Text = email;
            if (DateTime.TryParse(ngaysinh, out DateTime date))
                dateTimePicker1.Value = date;
            comboBox1.Text = gioitinh;
            txtMSGV1.Enabled = false; // Khóa cứng khóa chính không cho đổi bậy
            erpEdit.Clear();

            SetOriginalValues(ho, ten, gioitinh, dienthoai, email);
        }

        private void LoadHRToComboBox()
        {
            // Đồng bộ đồng nhất lôi dữ liệu nhân sự từ bảng Login (position = 2) của ní lên
            string query = "SELECT MSGV, Lname + ' ' + Fname AS HoTen FROM Login WHERE position = 2 AND VALID = 'True'";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cboHR.DataSource = dt;
                cboHR.DisplayMember = "HoTen";
                cboHR.ValueMember = "MSGV";
            }
            catch { }
        }

        private void LoadCoursesToComboBox()
        {
            string query = "SELECT MaMH, TenMH FROM Course";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cboCourse.DataSource = dt;
                cboCourse.DisplayMember = "TenMH";
                cboCourse.ValueMember = "MaMH";
            }
            catch { }
        }

        private void LoadAssignList()
        {
            string query = "SELECT h.MSGV as 'Mã GV', h.Fname + ' ' + h.Lname AS 'Giảng Viên phụ trách', " +
                           "c.MaMH as 'Mã Môn', c.TenMH as 'Tên Môn Học', c.SoTC as 'Số Tín Chỉ' " +
                           "FROM Assign a " +
                           "JOIN Login h ON a.ID_HR = h.MSGV " +
                           "JOIN Course c ON a.MaMH = c.MaMH";
            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvAssign.DataSource = dt;

                dgvAssign.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAssign.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (SqlException sqlEx)
            {
                // Chỉ ghi nhận log ngầm ra cửa sổ Output để debug, tuyệt đối không quăng popup làm nghẽn mạch lưu dữ liệu
                Console.WriteLine("Lỗi nạp lưới dữ liệu: " + sqlEx.Message);
            }
            catch { }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra ràng buộc lựa chọn trên giao diện
            if (cboHR.SelectedValue == null || cboCourse.SelectedValue == null)
            {
                MessageBox.Show("Ní vui lòng chọn đầy đủ Giảng viên và Môn học trước khi bấm phân công nhé!", "Thiếu thông tin");
                return;
            }

            string selectedHR = cboHR.SelectedValue.ToString().Trim();
            string selectedCourse = cboCourse.SelectedValue.ToString().Trim();

            try
            {
                db.openConnection();

                // 2. KIỂM TRA TRÙNG LỊCH DẠY: Check xem cặp (Mã GV, Mã Môn) đã tồn tại chưa
                string checkDupQuery = "SELECT COUNT(*) FROM Assign WHERE ID_HR = @ID_HR AND MaMH = @mamh";
                SqlCommand cmdCheckDup = new SqlCommand(checkDupQuery, db.conn);
                cmdCheckDup.Parameters.AddWithValue("@ID_HR", selectedHR);
                cmdCheckDup.Parameters.AddWithValue("@mamh", selectedCourse);
                int isDuplicate = (int)cmdCheckDup.ExecuteScalar();

                if (isDuplicate > 0)
                {
                    MessageBox.Show("Giảng viên này đã được phân công đảm nhận môn này trước đó rồi ní ơi!", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. 🛠️ CHỨC NĂNG MỚI BỌC THÉP: Đếm số môn hiện tại của giảng viên để chặn nếu vượt quá 5 môn
                string checkCountQuery = "SELECT COUNT(*) FROM Assign WHERE ID_HR = @ID_HR";
                SqlCommand cmdCheckCount = new SqlCommand(checkCountQuery, db.conn);
                cmdCheckCount.Parameters.AddWithValue("@ID_HR", selectedHR);
                int currentCourses = (int)cmdCheckCount.ExecuteScalar();

                if (currentCourses >= 5)
                {
                    MessageBox.Show($"Không thể phân công! Giảng viên này đã dạy tối đa {currentCourses}/5 môn quy định rồi ní ơi!",
                                    "Vượt quá giới hạn phân công", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; // Chặn đứng luồng chạy, không cho chèn dữ liệu
                }

                // 4. THỰC HIỆN LƯU DỮ LIỆU: Thỏa mãn mọi điều kiện trên mới chạy lệnh chèn này
                string insertQuery = "INSERT INTO Assign (ID_HR, MaMH) VALUES (@ID_HR, @mamh)";
                SqlCommand cmdInsert = new SqlCommand(insertQuery, db.conn);
                cmdInsert.Parameters.AddWithValue("@ID_HR", selectedHR);
                cmdInsert.Parameters.AddWithValue("@mamh", selectedCourse);

                if (cmdInsert.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Phân công giảng viên vào môn học thành công tốt đẹp!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAssignList(); // Nạp lại lưới hiển thị lập tức
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi kết nối hoặc cấu trúc bảng Database: " + sqlEx.Message, "Lỗi thực thi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống phát sinh: " + ex.Message, "Lỗi");
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối an toàn
            }
        }

        private void btnDeleteAssign_Click(object sender, EventArgs e)
        {
            if (dgvAssign.CurrentRow == null)
            {
                MessageBox.Show("Ní vui lòng chọn một dòng phân công trên bảng để hủy nhé!", "Thông báo");
                return;
            }

            string msgv = dgvAssign.CurrentRow.Cells["Mã GV"].Value.ToString();
            string maMH = dgvAssign.CurrentRow.Cells["Mã Môn"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Ní có chắc muốn hủy phân công môn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM Assign WHERE ID_HR = @id_hr AND MaMH = @mamh";
                try
                {
                    db.openConnection();
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@id_hr", msgv);
                    cmd.Parameters.AddWithValue("@mamh", maMH);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Đã hủy phân công dạy môn này thành công!", "Thành công");
                        LoadAssignList();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hủy phân công: " + ex.Message);
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }
        private void LoadTeacherData()
        {
            try
            {
                string query = "SELECT MSGV, Fname, Lname, Dob, Gder, Phone, Email, Address, Pic FROM Login WHERE position = 2 AND VALID = 'True'";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt == null) return;

                gvView = new DataView(dt);
                dgvStudents.DataSource = gvView;

                dgvStudents.Columns["MSGV"].HeaderText = "Mã GV";
                dgvStudents.Columns["Fname"].HeaderText = "Họ";
                dgvStudents.Columns["Lname"].HeaderText = "Tên";
                dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Dob"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
                dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
                dgvStudents.Columns["Email"].HeaderText = "Email";

                // 🛠️ SỬA LỖI 3: Ánh xạ chuẩn DataPropertyName cột Địa chỉ cho bảng tab Danh sách (dgvStudents)
                if (dgvStudents.Columns["Address"] != null)
                {
                    dgvStudents.Columns["Address"].HeaderText = "Địa chỉ";
                    dgvStudents.Columns["Address"].DataPropertyName = "Address";
                }

                if (dgvStudents.Columns["Pic"] != null)
                {
                    dgvStudents.Columns["Pic"].HeaderText = "Hình ảnh";
                    ((DataGridViewImageColumn)dgvStudents.Columns["Pic"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                // Đồng bộ phông chữ phẳng, dãn cách dòng mượt mà cho lưới dgvStudents
                dgvStudents.RowTemplate.Height = 40;
                dgvStudents.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
                dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                dgvStudents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);

                dgvStudents.Columns["MSGV"].MinimumWidth  = 75;
                dgvStudents.Columns["Fname"].MinimumWidth = 75;
                dgvStudents.Columns["Lname"].MinimumWidth = 125;
                dgvStudents.Columns["Dob"].MinimumWidth   = 105;
                dgvStudents.Columns["Gder"].MinimumWidth  = 95;
                dgvStudents.Columns["Phone"].MinimumWidth = 115;
                dgvStudents.Columns["Email"].MinimumWidth = 185;
                if (dgvStudents.Columns["Address"] != null)
                    dgvStudents.Columns["Address"].MinimumWidth = 155;
                if (dgvStudents.Columns["Pic"] != null)
                    dgvStudents.Columns["Pic"].MinimumWidth = 65;

                UpdateTotalCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách giảng viên: " + ex.Message);
            }
        }
        private void UpdateTotalCount()
        {
            if (dgvStudents.DataSource == null) return;
            int realCount = dgvStudents.AllowUserToAddRows ? dgvStudents.Rows.Count - 1 : dgvStudents.Rows.Count;
            if (realCount < 0) realCount = 0;
            lblTotal.Text = "Tổng số giảng viên: " + realCount;
        }

        // THANH TÌM KIẾM GIẢNG VIÊN (Mã số, Họ, Tên)
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void RegisterRealTimeValidation1()
        {
            txtMSGV.TextChanged += (s, e) => {
                string input = txtMSGV.Text.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    erp2.SetError(txtMSGV, "Mã số giảng viên không được để trống!");
                }
                else if (!Regex.IsMatch(input, @"^\d+$")) // Ép định dạng chỉ chấp nhận số từ 0-9
                {
                    erp2.SetError(txtMSGV, "Mã số giảng viên bắt buộc phải là ký tự số, không được phép chứa chữ cái!");
                }
                else
                {
                    erp2.SetError(txtMSGV, "");
                }
            };

            txtFname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtFname.Text.Trim()))
                    erp2.SetError(txtFname, "Vui lòng nhập Họ!");
                else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
                    erp2.SetError(txtFname, "Họ không được chứa chữ số!");
                else
                    erp2.SetError(txtFname, "");
            };

            txtLname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtLname.Text.Trim()))
                    erp2.SetError(txtLname, "Vui lòng nhập Tên!");
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
            textBox1.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(textBox1.Text.Trim()))
                    erpEdit.SetError(textBox1, "Vui lòng nhập Họ!");
                else if (Regex.IsMatch(textBox1.Text.Trim(), @"\d"))
                    erpEdit.SetError(textBox1, "Họ không được chứa chữ số!");
                else
                    erpEdit.SetError(textBox1, "");
            };

            textBox2.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(textBox2.Text.Trim()))
                    erpEdit.SetError(textBox2, "Vui lòng nhập Tên!");
                else if (Regex.IsMatch(textBox2.Text.Trim(), @"\d"))
                    erpEdit.SetError(textBox2, "Tên không được chứa chữ số!");
                else
                    erpEdit.SetError(textBox2, "");
            };

            textBox3.TextChanged += (s, e) => {
                if (!string.IsNullOrEmpty(textBox3.Text.Trim()) && !long.TryParse(textBox3.Text.Trim(), out _))
                    erpEdit.SetError(textBox3, "Số điện thoại không hợp lệ!");
                else
                    erpEdit.SetError(textBox3, "");
            };

            textBox4.TextChanged += (s, e) => {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (!Regex.IsMatch(textBox4.Text.Trim(), emailPattern) && textBox4.Text.Length > 0)
                    erpEdit.SetError(textBox4, "Định dạng Email không đúng!");
                else
                    erpEdit.SetError(textBox4, "");
            };
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                LoadHRToComboBox();
                LoadAssignList();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                LoadTeacherData();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                LoadData1();
            }
        }

        private void SetupSuggestList()
        {
            if (this.Controls.Find("lstSuggest", true).Length > 0)
            {
                lstSuggest.Visible = false;
                lstSuggest.BringToFront();
            }
        }

        // 🛠️ VÁ LỖI 1: Thay thế bảng 'HR' thành bảng quản lý 'Login' đồng nhất với DB thực tế của ní
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput1())
            {
                MessageBox.Show("Vui lòng sửa lại các thông tin nhập thêm chưa đúng quy định (Xem ký hiệu đỏ)!", "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            string maSoGV = txtMSGV.Text.Trim();

            // SỬA TAY: Cập nhật chuỗi chèn đầy đủ thuộc tính vào bảng Login
            string query = "INSERT INTO Login (Username, Pass, Fname, Lname, position, MSGV, Dob, Gder, Phone, Email, Address, VALID) " +
                           "VALUES (@msgv, @msgv, @fname, @lname, 2, @msgv, @dob, @gder, @phone, @email, @address, 'True')";

            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@msgv", maSoGV);
                cmd.Parameters.AddWithValue("@fname", txtFname.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", txtLname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                cmd.Parameters.AddWithValue("@gder", cboGender.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Thêm giảng viên mới vào hệ thống thành công tốt đẹp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClear_Click_1(sender, e);
                    LoadTeacherData(); // Làm tươi lại bảng hiển thị lập tức
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    erp2.SetError(txtMSGV, "Mã số giảng viên này đã tồn tại!");
                    MessageBox.Show("Mã số giảng viên (MSGV) đã tồn tại trên hệ thống!", "Lỗi trùng khóa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMSGV.Focus();
                }
                else
                    MessageBox.Show("Lỗi Database: " + ex.Message, "Lỗi hệ thống");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message);
            }
            finally { db.closeConnection(); }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtMSGV.Clear(); txtFname.Clear(); txtLname.Clear();
            dtpDob.Value = DateTime.Now;
            cboGender.SelectedIndex = -1;
            txtPhone.Clear(); txtEmail.Clear(); txtAddress.Clear();
            if (this.Controls.Find("lstSuggest", true).Length > 0) lstSuggest.Visible = false;
            picStudent.Image = null;
            hrImage = null;
            erp2.Clear();
            txtMSGV.Focus();
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
                hrImage = ms.ToArray();
                original.Dispose();
            }
        }

        private async void txtAddress_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtAddress.Text.Trim();
            if (keyword.Length < 3 || this.Controls.Find("lstSuggest", true).Length == 0)
            {
                if (this.Controls.Find("lstSuggest", true).Length > 0) lstSuggest.Visible = false;
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
                else { lstSuggest.Visible = false; }
            }
            catch { lstSuggest.Visible = false; }
        }

        private void btnSpeech_Click_1(object sender, EventArgs e)
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
                MessageBox.Show("Không thể kích hoạt Micro: " + ex.Message, "Lỗi thiết bị");
                btnSpeech.Enabled = true;
            }
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string text = e.Result.Text.ToLower();

            var msgvMatch = Regex.Match(text, @"\d{3,8}");
            if (msgvMatch.Success)
                txtMSGV.Invoke((Action)(() => txtMSGV.Text = msgvMatch.Value));

            var tenMatch = Regex.Match(text, @"(?:giảng viên|thầy|cô|tên)\s+([\w\s]+?)(?:\s+mã số|$)");
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
                btnSpeech.Text = "🎤 Nhập bằng giọng nói";
                btnSpeech.Enabled = true;
            }));

            MessageBox.Show("Hệ thống nhận diện giọng nói được: " + e.Result.Text, "Kết quả");
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
                            MessageBox.Show("Ảnh mờ, không thể nhận diện ký tự! Thử lại bằng hình nét hơn nhé.", "Thông báo");
                            return;
                        }

                        string[] lines = textResult.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string line in lines)
                        {
                            string cleanLine = line.Trim();
                            string lowerLine = cleanLine.ToLower();

                            if (lowerLine.Contains("mã") || lowerLine.Contains("id") || lowerLine.Contains("msgv"))
                            {
                                Match codeMatch = Regex.Match(cleanLine, @"\d{4,10}");
                                if (codeMatch.Success) txtMSGV.Text = codeMatch.Value;
                            }

                            if (lowerLine.Contains("họ tên") || lowerLine.Contains("tên") || lowerLine.Contains("name"))
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

                            if (lowerLine.Contains("sinh") || lowerLine.Contains("dob"))
                            {
                                Match dobMatch = Regex.Match(cleanLine, @"\d{2}/\d{2}/\d{4}|\d{2}-\d{2}-\d{4}");
                                if (dobMatch.Success && DateTime.TryParse(dobMatch.Value.Replace("-", "/"), out DateTime parsedDate))
                                    dtpDob.Value = parsedDate;
                            }

                            if (lowerLine.Contains("nam")) cboGender.Text = "Nam";
                            else if (lowerLine.Contains("nữ") || lowerLine.Contains("nu")) cboGender.Text = "Nữ";
                        }
                        MessageBox.Show("Trích xuất OCR dữ liệu thẻ giảng viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi bộ thư viện OCR: " + ex.Message, "Lỗi hệ thống");
                }
            }
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

        private void btnViewlist_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
                pnl.Region = new Region(Path);
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
                pnl.Region = new Region(Path);
        }

        // 🛠️ VÁ LỖI 3: Hàm điền văn bản từ ListBox vào TextBox hoạt động chuẩn xác khi được click
        private void lstSuggest_Click(object sender, EventArgs e)
        {
            if (lstSuggest.SelectedItem != null)
            {
                txtAddress.Text = lstSuggest.SelectedItem.ToString();
                lstSuggest.Visible = false; // Ẩn danh sách đi sau khi chọn thành công
            }
        }

        private void button3_Click(object sender, EventArgs e) {  }
        private void button1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) {  }
        private void dgvAssign_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cboHR_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void pnlHeader_Paint(object sender, PaintEventArgs e) { }
        private void ptLogo_Click(object sender, EventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }

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

        private void cboFilterGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvView == null) return;
            string selected = cboFilterGender.Text.Trim();
            gvView.RowFilter = (selected == "Tất cả" || string.IsNullOrEmpty(selected)) ? "" : $"Gder = '{selected}'";
            UpdateTotalCount();
        }

        private void cboSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvView == null) return;
            string selected = cboSortBy.Text.Trim();
            if (selected == "Mã giảng viên" || selected == "Mã sinh viên")
                gvView.Sort = "MSGV ASC";
            else if (selected == "Tên")
                gvView.Sort = "Lname ASC";
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = $"DanhSachGV_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage pkg = new ExcelPackage())
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Danh sách GV");
                    string[] headers = { "Mã GV", "Họ", "Tên", "Ngày sinh", "Giới tính", "Điện thoại", "Email" };
                    string[] colNames = { "MSGV", "Fname", "Lname", "Dob", "Gder", "Phone", "Email" };

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
                    foreach (DataRowView drv in gvView)
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

                DialogResult dr = MessageBox.Show("Export danh sách giảng viên thành công! Bạn có muốn mở file Excel lên không?",
                                                  "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi Export Excel: " + ex.Message); }
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Chọn file Excel danh sách giảng viên"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            _importFilePath = ofd.FileName;
            lblFilePath.Text = Path.GetFileName(_importFilePath);

            lblStatus.Text = "Đang kết nối AI phân tích cấu trúc file và ánh xạ giảng viên...";
            lblStatus.ForeColor = Color.OrangeRed;

            PreviewExcelWithAI(_importFilePath);
        }

        private async void PreviewExcelWithAI(string path)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage pkg = new ExcelPackage(new FileInfo(path)))
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets[0];
                    if (ws.Dimension == null) { MessageBox.Show("File Excel trống rỗng ní ơi!"); return; }

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

                    if (string.IsNullOrEmpty(apiKey) || apiKey.Trim().StartsWith("Điền API"))
                    {
                        MessageBox.Show("Hệ thống chạy ở chế độ Local (Chưa có API Key AI). Đang tự động map cột thủ công.", "Lưu ý");
                        ProcessLocalBackup(excelHeaders, excelRows);
                        return;
                    }

                    string aiResponseJson = await CallGeminiToAnalyze(excelHeaders, excelRows);

                    if (!string.IsNullOrEmpty(aiResponseJson))
                    {
                        DataTable dtPreview = JsonConvert.DeserializeObject<DataTable>(aiResponseJson);
                        dgvPreview.DataSource = dtPreview;

                        if (dgvPreview.Columns["Lỗi"] != null) dgvPreview.Columns["Lỗi"].Visible = false;

                        lblStatus.Text = $"AI ánh xạ dữ liệu thành công! Sẵn sàng xử lý {dtPreview.Rows.Count} giảng viên.";
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
                // Đại tu Prompt hướng mục tiêu nhận diện Giảng viên (MSGV) thay vì sinh viên
                string prompt = "Bạn là trợ lý AI thông minh tích hợp trong ứng dụng Quản lý giảng viên.\n" +
                                "Nhiệm vụ 1 (Ánh xạ cột): Hãy phân tích các tiêu đề cột thô của file Excel sau: " + JsonConvert.SerializeObject(headers) + " " +
                                "để ánh xạ một cách thông minh vào các thuộc tính hệ thống: MSGV, Họ, Tên, Ngày sinh, Giới tính, Điện thoại, Email.\n" +
                                "Nhiệm vụ 2 (Kiểm tra lỗi): Đọc và phân tích mảng dữ liệu thô này: " + JsonConvert.SerializeObject(rows) + ".\n" +
                                "Hãy kiểm tra xem dòng nào bị khuyết MSGV, khuyết Tên, hoặc cột Ngày sinh có sai định dạng ngày tháng không. Nếu có lỗi, ghi rõ lý do vào thuộc tính 'Lỗi', nếu không lỗi để trống.\n" +
                                "Hãy chuẩn hóa ngày sinh về định dạng dd/MM/yyyy.\n" +
                                "YÊU CẦU BẮT BUỘC: Chỉ trả về duy nhất chuỗi JSON là một mảng các đối tượng chứa chính xác các khóa sau: 'MSGV', 'Họ', 'Tên', 'Ngày sinh', 'Giới tính', 'Điện thoại', 'Email', 'Lỗi'. Không kèm theo bất kỳ văn bản giải thích hay ký tự định dạng markdown nào cả.";

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

                    dynamic resultObj = JsonConvert.DeserializeObject(rawResult);

                    if (resultObj.candidates != null && resultObj.candidates[0].content != null && resultObj.candidates[0].content.parts != null)
                    {
                        string cleanJson = resultObj.candidates[0].content.parts[0].text.ToString();
                        cleanJson = cleanJson.Replace("```json", "").Replace("```", "").Trim();
                        return cleanJson;
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            }
        }

        private void ProcessLocalBackup(List<string> headers, List<List<string>> rows)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MSGV"); dt.Columns.Add("Họ"); dt.Columns.Add("Tên");
            dt.Columns.Add("Ngày sinh"); dt.Columns.Add("Giới tính");
            dt.Columns.Add("Điện thoại"); dt.Columns.Add("Email");
            dt.Columns.Add("Lỗi");

            foreach (var row in rows)
            {
                if (row.Count < 3) continue;
                string msgv = row[0];
                string fname = row[1];
                string lname = row[2];
                string dob = row.Count > 3 ? row[3] : "";
                string gder = row.Count > 4 ? row[4] : "";
                string phone = row.Count > 5 ? row[5] : "";
                string email = row.Count > 6 ? row[6] : "";

                string err = "";
                if (string.IsNullOrEmpty(msgv)) err += "Khuyết MSGV; ";
                if (string.IsNullOrEmpty(fname) || string.IsNullOrEmpty(lname)) err += "Khuyết Tên; ";

                dt.Rows.Add(msgv, fname, lname, dob, gder, phone, email, err);
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

        private void dgvPreview_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvsuathongtin.Rows[e.RowIndex];

            txtMSGV1.Text = row.Cells["MSGV"].Value?.ToString() ?? "";
            textBox1.Text = row.Cells["Fname"].Value?.ToString() ?? "";
            textBox2.Text = row.Cells["Lname"].Value?.ToString() ?? "";
            textBox3.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            textBox4.Text = row.Cells["Email"].Value?.ToString() ?? "";

            if (dgvsuathongtin.Columns.Contains("Address"))
            {
                textBox5.Text = row.Cells["Address"].Value?.ToString() ?? "";
            }

            txtMSGV1.Enabled = false;

            if (row.Cells["Dob"].Value != DBNull.Value && row.Cells["Dob"].Value != null)
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Dob"].Value);

            comboBox1.Text = row.Cells["Gder"].Value?.ToString().Trim() ?? "";

            // 🛠️ SỬA LỖI 2: Đổi tên linh kiện nhận ảnh từ picStudent sang pictureBox4 cho khớp Design thực tế
            if (row.Cells["Pic"].Value != DBNull.Value && row.Cells["Pic"].Value != null)
            {
                byte[] picData = (byte[])row.Cells["Pic"].Value;
                using (MemoryStream ms = new MemoryStream(picData))
                using (Image tempImg = Image.FromStream(ms))
                {
                    if (pictureBox4.Image != null) pictureBox4.Image.Dispose();
                    pictureBox4.Image = new Bitmap(tempImg);
                }
            }
            else
            {
                pictureBox4.Image = null;
            }

            erpEdit.Clear();

            SetOriginalValues(
                textBox1.Text.Trim(),
                textBox2.Text.Trim(),
                comboBox1.Text,
                textBox3.Text.Trim(),
                textBox4.Text.Trim()
            );
        }

        private void btnFix_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Vui lòng sửa lại các thông tin nhập sai!", "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try
            {
                db.openConnection();

                string query = "UPDATE Login SET Fname=@fn, Lname=@ln, Dob=@dob, Gder=@gder, Phone=@phone, Email=@email, Address=@address, Pic=@pic WHERE MSGV=@msgv";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@msgv", txtMSGV1.Text.Trim());
                cmd.Parameters.AddWithValue("@fn", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@gder", comboBox1.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());

                if (picStudent.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picStudent.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        cmd.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image) { Value = ms.ToArray() });
                    }
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image) { Value = DBNull.Value });
                }

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật thông tin giảng viên thành công tốt đẹp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetOriginalValues(textBox1.Text.Trim(), textBox2.Text.Trim(), comboBox1.Text, textBox3.Text.Trim(), textBox4.Text.Trim());
                    LoadData1(); // Làm tươi lưới bảng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSGV1.Text))
            {
                MessageBox.Show("Ní vui lòng chọn giảng viên cần xóa từ bảng bên trái trước nhé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenGV = $"{textBox1.Text.Trim()} {textBox2.Text.Trim()}";
            DialogResult confirm = MessageBox.Show($"Ní có chắc chắn muốn xóa giảng viên {tenGV} (MSGV: {txtMSGV1.Text}) không?\nHành động này sẽ tự động hủy toàn bộ môn dạy đang phân công của GV này!",
                                                   "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                db.openConnection();

                // 🛠️ BỌC THÉP: Gỡ sạch lịch phân công dạy trong bảng Assign trước để tránh nổ lỗi khóa ngoại
                string deleteAssign = "DELETE FROM Assign WHERE ID_HR = @msgv";
                SqlCommand cmdAssign = new SqlCommand(deleteAssign, db.conn);
                cmdAssign.Parameters.AddWithValue("@msgv", txtMSGV1.Text.Trim());
                cmdAssign.ExecuteNonQuery();

                // Sau đó mới xóa thực thể nhân sự tại bảng Login
                string deleteLogin = "DELETE FROM Login WHERE MSGV = @msgv";
                SqlCommand cmdLogin = new SqlCommand(deleteLogin, db.conn);
                cmdLogin.Parameters.AddWithValue("@msgv", txtMSGV1.Text.Trim());

                if (cmdLogin.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã xóa giảng viên ra khỏi hệ thống thành công tốt đẹp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefresh_Click_1(sender, e); // Gọi hàm dọn dẹp sạch giao diện
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lệnh xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtMSGV1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = -1;
            picStudent.Image = null;
            txtMSGV1.Enabled = true;

            _origFname = _origLname = _origGder = _origPhone = _origEmail = "";
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;

            erpEdit.Clear();
            LoadData1();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog
            {
                Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif"
            };
            if (opf.ShowDialog() == DialogResult.OK)
            {
                using (Image img = Image.FromFile(opf.FileName))
                    picStudent.Image = new Bitmap(img);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (this.Controls.Find("panel1", true).Length > 0)
            {
            }
        }

        private void dgvAssign_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvAssign.Rows[e.RowIndex];

            // Bốc "Mã GV" và "Mã Môn" ngầm từ dòng được chọn gán thẳng vào SelectedValue của ComboBox
            if (row.Cells["Mã GV"].Value != null)
                cboHR.SelectedValue = row.Cells["Mã GV"].Value.ToString().Trim();

            if (row.Cells["Mã Môn"].Value != null)
                cboCourse.SelectedValue = row.Cells["Mã Môn"].Value.ToString().Trim();
        }


        private void guna2Shapes4_Click(object sender, EventArgs e)
        {

        }


        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (gvView == null || gvView.Count == 0)
            {
                MessageBox.Show("Danh sách giảng viên hiện tại đang trống, không có dữ liệu để xuất file PDF ní ơi!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Trích xuất dữ liệu giảng viên hiện tại trên lưới thành bảng DataTable
                DataTable dtTeachers = gvView.ToTable();

                // 🚀 GIẢI PHÁP CHÍ MẠNG: Ép kiểu sang DataView và tận dụng luôn hàm xuất PDF bọc thép của sinh viên
                DataView dvTeachers = new DataView(dtTeachers);
                ReportExportService.ExportStudentListToPDF(dvTeachers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gặp sự cố phát sinh khi đang kết xuất file PDF: " + ex.Message,
                                "Lỗi phân hệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pnlForm_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
