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
    public partial class f_EditStudent : Form
    {
        My_DB db = new My_DB();

        public f_EditStudent()
        {
            InitializeComponent();
            RegisterRealTimeValidation();
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
        }

        private void RegisterRealTimeValidation()
        {
            // Bắt sự kiện khi người dùng gõ phím ở ô Họ
            txtFname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtFname.Text.Trim()))
                    erpEdit.SetError(txtFname, "Vui lòng nhập Họ của sinh viên!");
                else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
                    erpEdit.SetError(txtFname, "Họ không được chứa chữ số!");
                else
                    erpEdit.SetError(txtFname, ""); // Hết lỗi thì tự động xóa dấu đỏ
            };

            // Bắt sự kiện khi người dùng gõ phím ở ô Tên
            txtLname.TextChanged += (s, e) => {
                if (string.IsNullOrEmpty(txtLname.Text.Trim()))
                    erpEdit.SetError(txtLname, "Vui lòng nhập Tên của sinh viên!");
                else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
                    erpEdit.SetError(txtLname, "Tên không được chứa chữ số!");
                else
                    erpEdit.SetError(txtLname, "");
            };

            // Bắt sự kiện gõ phím ở ô Điện thoại
            txtPhone.TextChanged += (s, e) => {
                if (!string.IsNullOrEmpty(txtPhone.Text.Trim()) && !long.TryParse(txtPhone.Text.Trim(), out _))
                    erpEdit.SetError(txtPhone, "Số điện thoại không hợp lệ! Chỉ được nhập số.");
                else
                    erpEdit.SetError(txtPhone, "");
            };

            // --- THÊM KHÚC NÀY: Bắt lỗi gõ phím Real-Time cho ô Email ---
            txtEmail.TextChanged += (s, e) => {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern) && txtEmail.Text.Length > 0)
                    erpEdit.SetError(txtEmail, "Định dạng Email không đúng! (Ví dụ: tên@gmail.com hoặc sv@student.hcmute.edu.vn)");
                else
                    erpEdit.SetError(txtEmail, "");
            };
        }

        // Hàm kiểm tra tổng thể trước khi lưu
        private bool ValidateInput()
        {
            bool isValid = true;

            // 1. Kiểm tra Mã số sinh viên
            if (string.IsNullOrEmpty(txtMSSV.Text.Trim()))
            {
                erpEdit.SetError(txtMSSV, "Mã số sinh viên không được để trống!");
                isValid = false;
            }

            // 2. Kiểm tra Họ
            if (string.IsNullOrEmpty(txtFname.Text.Trim()))
            {
                erpEdit.SetError(txtFname, "Vui lòng nhập Họ của sinh viên!");
                isValid = false;
            }
            else if (Regex.IsMatch(txtFname.Text.Trim(), @"\d"))
            {
                erpEdit.SetError(txtFname, "Họ không được chứa chữ số!");
                isValid = false;
            }

            // 3. Kiểm tra Tên
            if (string.IsNullOrEmpty(txtLname.Text.Trim()))
            {
                erpEdit.SetError(txtLname, "Vui lòng nhập Tên của sinh viên!");
                isValid = false;
            }
            else if (Regex.IsMatch(txtLname.Text.Trim(), @"\d"))
            {
                erpEdit.SetError(txtLname, "Tên không được chứa chữ số!");
                isValid = false;
            }

            // 4. Kiểm tra Giới tính (ComboBox)
            if (cboGender.SelectedIndex == -1 || string.IsNullOrEmpty(cboGender.Text))
            {
                erpEdit.SetError(cboGender, "Vui lòng chọn Giới tính!");
                isValid = false;
            }

            // 5. Kiểm tra Số điện thoại
            if (!string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                if (!long.TryParse(txtPhone.Text.Trim(), out _))
                {
                    erpEdit.SetError(txtPhone, "Số điện thoại không hợp lệ! Chỉ được nhập số.");
                    isValid = false;
                }
            }

            // 6. --- ĐÃ SỬA: Chấp nhận mọi định dạng email có tên miền dài như trường HCMUTE ---
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                string email = txtEmail.Text.Trim();
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Pattern mở rộng bẻ gãy giới hạn cụm kí tự cũ

                if (!Regex.IsMatch(email, emailPattern))
                {
                    erpEdit.SetError(txtEmail, "Định dạng Email không hợp lệ! (Chấp nhận đuôi @student.hcmute.edu.vn)");
                    isValid = false;
                }
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

                if (dgvStudents.Columns["Pture"] != null)
                {
                    dgvStudents.Columns["Pture"].HeaderText = "Hình ảnh";
                    ((DataGridViewImageColumn)dgvStudents.Columns["Pture"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }

                dgvStudents.RowTemplate.Height = 50;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LayThongTinTuDanhSach(string mssv, string ho, string ten, string ngaysinh, string gioitinh, string dienthoai, string email)
        {
            txtMSSV.Text = mssv;
            txtFname.Text = ho;
            txtLname.Text = ten;
            txtPhone.Text = dienthoai;
            txtEmail.Text = email;

            if (DateTime.TryParse(ngaysinh, out DateTime date))
            {
                dtpDob.Value = date;
            }

            cboGender.Text = gioitinh;
            txtMSSV.Enabled = false;

            erpEdit.Clear(); // Xóa sạch dấu đỏ thừa khi đổ từ danh sách sang
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;
            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();
            this.Close();
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];

                txtMSSV.Text = row.Cells["MSSV"].Value.ToString();
                txtFname.Text = row.Cells["Fname"].Value.ToString();
                txtLname.Text = row.Cells["Lname"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();

                txtMSSV.Enabled = false;
                if (row.Cells["Dob"].Value != DBNull.Value)
                {
                    dtpDob.Value = Convert.ToDateTime(row.Cells["Dob"].Value);
                }

                string gender = row.Cells["Gder"].Value.ToString().Trim();
                cboGender.Text = gender;

                if (row.Cells["Pture"].Value != DBNull.Value && row.Cells["Pture"].Value != null)
                {
                    byte[] picData = (byte[])row.Cells["Pture"].Value;
                    using (MemoryStream ms = new MemoryStream(picData))
                    {
                        using (Image tempImg = Image.FromStream(ms))
                        {
                            picStudent.Image = new Bitmap(tempImg);
                        }
                    }
                }
                else
                {
                    picStudent.Image = null;
                }

                erpEdit.Clear();
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Không cho phép chỉnh sửa thông tin sinh viên!\nVui lòng sửa lại toàn bộ các vùng nhập liệu sai (có dấu cảnh báo đỏ) trên giao diện.",
                                "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try
            {
                db.openConnection();
                string query = "UPDATE Student SET Fname = @fn, Lname = @ln, Dob = @dob, Gder = @gder, " +
                               "Phone = @phone, Email = @email, Pture = @pic WHERE MSSV = @mssv";

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
                    using (MemoryStream ms = new MemoryStream())
                    {
                        picStudent.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        SqlParameter picParam = new SqlParameter("@pic", SqlDbType.Image);
                        picParam.Value = ms.ToArray();
                        cmd.Parameters.Add(picParam);
                    }
                }
                else
                {
                    SqlParameter picParam = new SqlParameter("@pic", SqlDbType.Image);
                    picParam.Value = DBNull.Value;
                    cmd.Parameters.Add(picParam);
                }

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMSSV.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            dtpDob.Value = DateTime.Now;
            cboGender.SelectedIndex = -1;
            picStudent.Image = null;

            txtMSSV.Enabled = true;
            erpEdit.Clear();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMSSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên muốn xóa khỏi hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên mã " + txtMSSV.Text + " không?",
                                                   "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    db.openConnection();
                    string query = "DELETE FROM Student WHERE MSSV = @mssv";
                    SqlCommand cmd = new SqlCommand(query, db.conn);
                    cmd.Parameters.AddWithValue("@mssv", txtMSSV.Text.Trim());

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa dữ liệu sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRefresh_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { db.closeConnection(); }
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                using (Image img = Image.FromFile(opf.FileName))
                {
                    picStudent.Image = new Bitmap(img);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            BoGocPanel(panel1, 25);
        }
    }
}