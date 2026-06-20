using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QuanLySinhVien
{
    public partial class f_EditStudent : UserControl
    {
        My_DB db = new My_DB();
        private bool openedFromList = false;


        private string _origFname = "";
        private string _origLname = "";
        private string _origGder = "";
        private string _origPhone = "";
        private string _origEmail = "";

        public f_EditStudent()
        {
            InitializeComponent();
            RegisterRealTimeValidation();
            this.Resize += (s, e) => ArrangeEditStudentLayout();
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

        private void f_EditStudent_Load_1(object sender, EventArgs e)
        {
            LoadData();
            ArrangeEditStudentLayout();
        }

        private void ArrangeEditStudentLayout()
        {
            if (dgvStudents == null || pnlForm == null || this.Width <= 0 || this.Height <= 0) return;

            SuspendLayout();

            const int left = 7;
            const int top = 113;
            const int gap = 20;
            const int rightMargin = 18;
            int panelHeight = Math.Max(680, Math.Min(860, this.ClientSize.Height - top - 28));

            pnlForm.Top = top;
            pnlForm.Height = panelHeight;
            pnlForm.Left = Math.Max(left + 520, this.ClientSize.Width - pnlForm.Width - rightMargin);

            dgvStudents.Left = left;
            dgvStudents.Top = top;
            dgvStudents.Width = Math.Max(520, pnlForm.Left - gap - left);
            dgvStudents.Height = panelHeight;
            ApplyStudentGridColumnLayout();

            guna2Separator1.Width = Math.Max(600, this.ClientSize.Width - 24);
            guna2Separator2.Width = guna2Separator1.Width;
            guna2Separator2.Top = Math.Max(dgvStudents.Bottom, pnlForm.Bottom) + 24;

            ResumeLayout(false);
        }

        private void ApplyStudentGridColumnLayout()
        {
            if (dgvStudents == null || dgvStudents.Columns.Count == 0) return;

            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetGridColumn("MSSV", 90, 85);
            SetGridColumn("Fname", 90, 85);
            SetGridColumn("Lname", 120, 95);
            SetGridColumn("Dob", 105, 95);
            SetGridColumn("Gder", 80, 75);
            SetGridColumn("Phone", 110, 100);
            SetGridColumn("Email", 230, 180);
            SetGridColumn("Address", 210, 150);
            SetGridColumn("Pture", 55, 45);
        }

        private void SetGridColumn(string columnName, float fillWeight, int minimumWidth)
        {
            if (!dgvStudents.Columns.Contains(columnName)) return;

            dgvStudents.Columns[columnName].FillWeight = fillWeight;
            dgvStudents.Columns[columnName].MinimumWidth = minimumWidth;
        }


        private void RegisterRealTimeValidation()
        {
            txtFname.TextChanged += (s, e) =>
            {
                if (string.IsNullOrEmpty(txtFname.Text.Trim()))
                    erpEdit.SetError(txtFname, "Vui lòng nhập Họ của sinh viên!");
                else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
                    erpEdit.SetError(txtFname, "Họ không được chứa chữ số!");
                else
                    erpEdit.SetError(txtFname, "");
                CheckHighlight();
            };

            txtLname.TextChanged += (s, e) =>
            {
                if (string.IsNullOrEmpty(txtLname.Text.Trim()))
                    erpEdit.SetError(txtLname, "Vui lòng nhập Tên của sinh viên!");
                else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
                    erpEdit.SetError(txtLname, "Tên không được chứa chữ số!");
                else
                    erpEdit.SetError(txtLname, "");
                CheckHighlight();
            };

            txtPhone.TextChanged += (s, e) =>
            {
                if (!string.IsNullOrEmpty(txtPhone.Text.Trim()) && !long.TryParse(txtPhone.Text.Trim(), out _))
                    erpEdit.SetError(txtPhone, "Số điện thoại không hợp lệ! Chỉ được nhập số.");
                else
                    erpEdit.SetError(txtPhone, "");
                CheckHighlight();
            };

            txtEmail.TextChanged += (s, e) =>
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern) && txtEmail.Text.Length > 0)
                    erpEdit.SetError(txtEmail, "Định dạng Email không đúng!");
                else
                    erpEdit.SetError(txtEmail, "");
                CheckHighlight();
            };

      
            cboGender.SelectedIndexChanged += (s, e) => CheckHighlight();
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtMSSV.Text.Trim()))
            { erpEdit.SetError(txtMSSV, "Mã số sinh viên không được để trống!"); isValid = false; }

            if (string.IsNullOrEmpty(txtFname.Text.Trim()))
            { erpEdit.SetError(txtFname, "Vui lòng nhập Họ!"); isValid = false; }
            else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
            { erpEdit.SetError(txtFname, "Họ không được chứa chữ số!"); isValid = false; }

            if (string.IsNullOrEmpty(txtLname.Text.Trim()))
            { erpEdit.SetError(txtLname, "Vui lòng nhập Tên!"); isValid = false; }
            else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
            { erpEdit.SetError(txtLname, "Tên không được chứa chữ số!"); isValid = false; }

            if (cboGender.SelectedIndex == -1 || string.IsNullOrEmpty(cboGender.Text))
            { erpEdit.SetError(cboGender, "Vui lòng chọn Giới tính!"); isValid = false; }

            if (!string.IsNullOrEmpty(txtPhone.Text.Trim()) && !long.TryParse(txtPhone.Text.Trim(), out _))
            { erpEdit.SetError(txtPhone, "Số điện thoại không hợp lệ!"); isValid = false; }

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                { erpEdit.SetError(txtEmail, "Định dạng Email không hợp lệ!"); isValid = false; }
            }

            return isValid;
        }

       
        private void LoadData()
        {
            try
            {
                DataTable dt = Student.GetStudents();
                dgvStudents.DataSource = dt;

                dgvStudents.Columns["MSSV"].HeaderText = "Mã SV";
                dgvStudents.Columns["Fname"].HeaderText = "Họ";
                dgvStudents.Columns["Lname"].HeaderText = "Tên";
                dgvStudents.Columns["Dob"].HeaderText = "Ngày sinh";
                dgvStudents.Columns["Dob"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvStudents.Columns["Gder"].HeaderText = "Giới tính";
                dgvStudents.Columns["Phone"].HeaderText = "Điện thoại";
                dgvStudents.Columns["Email"].HeaderText = "Email";
                if (dgvStudents.Columns["Address"] != null)
                {
                    dgvStudents.Columns["Address"].HeaderText = "Địa chỉ";
                }

                dgvStudents.RowTemplate.Height = 50;
                ApplyStudentGridColumnLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
        private void SaveHistory(string mssv)
        {
            try
            {
                SqlCommand cmdGet = new SqlCommand(
                    "SELECT Fname, Lname, Dob, Gder, Phone, Email FROM Student WHERE MSSV = @mssv",
                    db.conn);
                cmdGet.Parameters.AddWithValue("@mssv", mssv);

                using (SqlDataReader reader = cmdGet.ExecuteReader())
                {
                    if (!reader.Read()) return;

                    string oldFname = reader["Fname"].ToString();
                    string oldLname = reader["Lname"].ToString();
                    DateTime oldDob = Convert.ToDateTime(reader["Dob"]);
                    string oldGder = reader["Gder"].ToString();
                    string oldPhone = reader["Phone"].ToString();
                    string oldEmail = reader["Email"].ToString();
                    reader.Close();

                    SqlCommand cmdHist = new SqlCommand(
                        "INSERT INTO StudentHistory " +
                        "(MSSV, OldFname, OldLname, OldDob, OldGder, OldPhone, OldEmail, ChangedBy) " +
                        "VALUES (@mssv, @fn, @ln, @dob, @gder, @phone, @email, @by)",
                        db.conn);
                    cmdHist.Parameters.AddWithValue("@mssv", mssv);
                    cmdHist.Parameters.AddWithValue("@fn", oldFname);
                    cmdHist.Parameters.AddWithValue("@ln", oldLname);
                    cmdHist.Parameters.AddWithValue("@dob", oldDob);
                    cmdHist.Parameters.AddWithValue("@gder", oldGder);
                    cmdHist.Parameters.AddWithValue("@phone", oldPhone);
                    cmdHist.Parameters.AddWithValue("@email", oldEmail);
                    cmdHist.Parameters.AddWithValue("@by", Globals.GlobalUserName);
                    cmdHist.ExecuteNonQuery();
                }
            }
            catch {  }
        }

      
        private void SetOriginalValues(string fname, string lname, string gder,
                                       string phone, string email)
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
            txtFname.BackColor = txtFname.Text.Trim() != _origFname ? Color.LightYellow : Color.White;
            txtLname.BackColor = txtLname.Text.Trim() != _origLname ? Color.LightYellow : Color.White;
            cboGender.BackColor = cboGender.Text != _origGder ? Color.LightYellow : Color.White;
            txtPhone.BackColor = txtPhone.Text.Trim() != _origPhone ? Color.LightYellow : Color.White;
            txtEmail.BackColor = txtEmail.Text.Trim() != _origEmail ? Color.LightYellow : Color.White;
        }

    
        public void LayThongTinTuDanhSach(string mssv, string ho, string ten, string ngaysinh,
                                          string gioitinh, string dienthoai, string email)
        {
            openedFromList = true;
            txtMSSV.Text = mssv;
            txtFname.Text = ho;
            txtLname.Text = ten;
            txtPhone.Text = dienthoai;
            txtEmail.Text = email;
            if (DateTime.TryParse(ngaysinh, out DateTime date))
                dtpDob.Value = date;
            cboGender.Text = gioitinh;
            txtMSSV.Enabled = false;
            erpEdit.Clear();

       
            SetOriginalValues(ho, ten, gioitinh, dienthoai, email);
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
        }


        private void dgvStudents_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                // Bọc lót an toàn bốc dữ liệu tránh lỗi trống chuỗi NullReference
                txtMSSV.Text = row.Cells["MSSV"].Value?.ToString() ?? "";
                txtFname.Text = row.Cells["Fname"].Value?.ToString() ?? "";
                txtLname.Text = row.Cells["Lname"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtMSSV.Enabled = false;


                if (row.DataGridView.Columns.Contains("Address") && row.Cells["Address"].Value != DBNull.Value && row.Cells["Address"].Value != null)
                {
                    txtAddress.Text = row.Cells["Address"].Value.ToString();
                }
                else
                {
                    txtAddress.Text = ""; // Trả về chuỗi trống an toàn nếu DB chưa lưu địa chỉ
                }

                // Kiểm tra và nạp ngày sinh
                if (row.DataGridView.Columns.Contains("Dob") && row.Cells["Dob"].Value != DBNull.Value && row.Cells["Dob"].Value != null)
                    dtpDob.Value = Convert.ToDateTime(row.Cells["Dob"].Value);

                // Kiểm tra và nạp giới tính
                if (row.DataGridView.Columns.Contains("Gder") && row.Cells["Gder"].Value != null)
                    cboGender.Text = row.Cells["Gder"].Value.ToString().Trim();


                if (row.DataGridView.Columns.Contains("Pture") && row.Cells["Pture"].Value != DBNull.Value && row.Cells["Pture"].Value != null)
                {
                    byte[] picData = (byte[])row.Cells["Pture"].Value;
                    using (MemoryStream ms = new MemoryStream(picData))
                    {

                        if (picStudent.Image != null) picStudent.Image.Dispose();
                        picStudent.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    picStudent.Image = null;
                }

                erpEdit.Clear();

                SetOriginalValues(
                    txtFname.Text.Trim(),
                    txtLname.Text.Trim(),
                    cboGender.Text,
                    txtPhone.Text.Trim(),
                    txtEmail.Text.Trim()
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi click chọn sinh viên: " + ex.Message);
            }
        }


        private void btnFix_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Vui lòng sửa lại các thông tin nhập sai!",
                    "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try
            {
                db.openConnection();
                SaveHistory(txtMSSV.Text.Trim());

                string query =
                    "UPDATE Student SET Fname=@fn, Lname=@ln, Dob=@dob, Gder=@gder, " +
                    "Phone=@phone, Email=@email, Pture=@pic WHERE MSSV=@mssv";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", txtMSSV.Text.Trim());
                cmd.Parameters.AddWithValue("@fn", txtFname.Text.Trim());
                cmd.Parameters.AddWithValue("@ln", txtLname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                cmd.Parameters.AddWithValue("@gder", cboGender.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

                if (picStudent.Image != null)
                {
                    using (Bitmap bmpClone = new Bitmap(picStudent.Image))
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bmpClone.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        cmd.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image) { Value = ms.ToArray() });
                    }
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@pic", SqlDbType.Image) { Value = DBNull.Value });
                }

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Cập nhật thành công tốt đẹp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SetOriginalValues(
                        txtFname.Text.Trim(),
                        txtLname.Text.Trim(),
                        cboGender.Text,
                        txtPhone.Text.Trim(),
                        txtEmail.Text.Trim()
                    );

                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát sinh khi cập nhật thông tin: " + ex.Message, "Lỗi phân hệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên muốn xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenSV = $"{txtFname.Text.Trim()} {txtLname.Text.Trim()}";
            DialogResult confirm = MessageBox.Show(
                $"Bạn chắc chắn muốn xóa SV {tenSV} (MSSV: {txtMSSV.Text})?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                db.openConnection();

            
                new SqlCommand("DELETE FROM Score WHERE MSSV = @mssv", db.conn)
                {
                    Parameters = { new SqlParameter("@mssv", txtMSSV.Text.Trim()) }
                }.ExecuteNonQuery();

                new SqlCommand("DELETE FROM DKMH WHERE MSSV = @mssv", db.conn)
                {
                    Parameters = { new SqlParameter("@mssv", txtMSSV.Text.Trim()) }
                }.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Student WHERE MSSV = @mssv", db.conn);
                cmd.Parameters.AddWithValue("@mssv", txtMSSV.Text.Trim());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnRefresh_Click_1(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            dtpDob.Value = DateTime.Now;
            cboGender.SelectedIndex = -1;
            picStudent.Image = null;
            txtMSSV.Enabled = true;

      
            _origFname = _origLname = _origGder = _origPhone = _origEmail = "";
            txtFname.BackColor = Color.White;
            txtLname.BackColor = Color.White;
            cboGender.BackColor = Color.White;
            txtPhone.BackColor = Color.White;
            txtEmail.BackColor = Color.White;

            erpEdit.Clear();
            LoadData();
        }

  
        private void btnChooseImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Chọn ảnh chân dung sinh viên";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] imageBytes = File.ReadAllBytes(ofd.FileName);

                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        using (Image tempImg = Image.FromStream(ms))
                        {
                            if (picStudent.Image != null)
                            {
                                picStudent.Image.Dispose();
                            }

                            picStudent.Image = new Bitmap(tempImg);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải hình ảnh: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            BoGocPanel(panel1, 25);
        }

        private void pnlForm_Paint(object sender, PaintEventArgs e)
        {
            BoGocPanel(pnlForm, 25);
        }

        private void btnChooseImage_MouseDown(object sender, MouseEventArgs e)
        {
            btnChooseImage.Size = new Size(256, 81);
            btnChooseImage.Location = new Point(btnChooseImage.Location.X + 2, btnChooseImage.Location.Y + 1);
        }

        private void btnChooseImage_MouseUp(object sender, MouseEventArgs e)
        {
            btnChooseImage.Size = new Size(260, 83);
            btnChooseImage.Location = new Point(btnChooseImage.Location.X - 2, btnChooseImage.Location.Y - 1);
        }

        private void btnFix_MouseDown(object sender, MouseEventArgs e)
        {
            btnFix.Size = new Size(186, 83);
            btnFix.Location = new Point(btnFix.Location.X + 2, btnFix.Location.Y + 1);
        }

        private void btnFix_MouseUp(object sender, MouseEventArgs e)
        {
            btnFix.Size = new Size(190, 85);
            btnFix.Location = new Point(btnFix.Location.X - 2, btnFix.Location.Y - 1);
        }

        private void btnClear_MouseDown(object sender, MouseEventArgs e)
        {
            btnClear.Size = new Size(186, 83);
            btnClear.Location = new Point(btnClear.Location.X + 2, btnClear.Location.Y + 1);
        }

        private void btnClear_MouseUp(object sender, MouseEventArgs e)
        {
            btnClear.Size = new Size(190, 85);
            btnClear.Location = new Point(btnClear.Location.X - 2, btnClear.Location.Y - 1);
        }

        private void btnRefresh_MouseDown(object sender, MouseEventArgs e)
        {
            btnRefresh.Size = new Size(186, 83);
            btnRefresh.Location = new Point(btnRefresh.Location.X + 2, btnRefresh.Location.Y + 1);
        }

        private void btnRefresh_MouseUp(object sender, MouseEventArgs e)
        {
            btnRefresh.Size = new Size(190, 85);
            btnRefresh.Location = new Point(btnRefresh.Location.X - 2, btnRefresh.Location.Y - 1);
        }
    }
}
