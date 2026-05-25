using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace QuanLySinhVien
{
    public partial class f_AddStudent : Form
    {
        byte[] studentImage = null;

        public f_AddStudent()
        {
            InitializeComponent();
        }

        private GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        // Hàm này dùng để nhận thông tin từ form danh sách truyền sang
        public void LayThongTinSua(string mssv, string ho, string ten, string ngaysinh, string gioitinh, string dienthoai, string email)
        {
            txtMSSV.Text = mssv;
            txtFname.Text = ho;
            txtLname.Text = ten;

            // Chuyển chuỗi ngày tháng về kiểu DateTime để gán vào DateTimePicker
            if (DateTime.TryParse(ngaysinh, out DateTime date))
            {
                dtpDob.Value = date; // dtpDob là tên cái DateTimePicker của bạn
            }

            cboGender.Text = gioitinh; // cboGender là ComboBox giới tính
            txtPhone.Text = dienthoai;
            txtEmail.Text = email;

            // Mẹo: Khi sửa thì không cho người dùng sửa khóa chính (MSSV) để tránh lỗi Database
            txtMSSV.Enabled = false;

            // Đổi tên nút "Thêm" mặc định thành chữ "Cập nhật" để người dùng không bị nhầm
            btnAdd.Text = "Cập nhật";
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picStudent.Image = Image.FromFile(ofd.FileName);
                MemoryStream ms = new MemoryStream();
                picStudent.Image.Save(ms, picStudent.Image.RawFormat);
                studentImage = ms.ToArray();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txtMSSV.Text) || string.IsNullOrEmpty(txtLname.Text))
            {
                MessageBox.Show("Vui lòng nhập MSSV và Tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMSSV.Text, out int mssv))
            {
                MessageBox.Show("MSSV phải là số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                // TRƯỜNG HỢP 1: XỬ LÝ CẬP NHẬT (SỬA) DATA
                if (btnAdd.Text == "Cập nhật")
                {
                    // Phải dùng lệnh UPDATE chứ không dùng INSERT INTO ní nhé
                    string query = "UPDATE Student SET Fname = @fname, Lname = @lname, Dob = @dob, Gder = @gder, Phone = @phone, Email = @email, Pture = @pic WHERE MSSV = @mssv";
                    SqlCommand cmd = new SqlCommand(query, db.conn);

                    // Nạp tham số khớp 100% với các tên @ trong chuỗi query ở trên
                    cmd.Parameters.AddWithValue("@mssv", mssv);
                    cmd.Parameters.AddWithValue("@fname", txtFname.Text);
                    cmd.Parameters.AddWithValue("@lname", txtLname.Text);
                    cmd.Parameters.AddWithValue("@dob", dtpDob.Value);
                    cmd.Parameters.AddWithValue("@gder", cboGender.Text);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    // Xử lý nạp ảnh thẻ (nếu ảnh null thì truyền DBNull)
                    if (studentImage == null)
                        cmd.Parameters.AddWithValue("@pic", SqlBinary.Null);
                    else
                        cmd.Parameters.AddWithValue("@pic", studentImage);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close(); // Sửa xong thì đóng form quay về danh sách luôn
                }
                // TRƯỜNG HỢP 2: XỬ LÝ THÊM MỚI SINH VIÊN
                else
                {
                    // Gọi đối tượng Student và hàm AddStudent() bạn đã viết sẵn
                    Student sv = new Student(
                        mssv, txtFname.Text, txtLname.Text,
                        dtpDob.Value, cboGender.Text, txtPhone.Text,
                        "", "", txtEmail.Text, studentImage);

                    if (sv.AddStudent())
                    {
                        MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Thêm xong tự động đóng tab quay về ban đầu
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại! MSSV có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi: " + ex.Message, "Lỗi hệ thống");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtFname.Clear();
            txtLname.Clear();
            dtpDob.Value = DateTime.Now;
            cboGender.SelectedIndex = -1;
            txtPhone.Clear();
            txtEmail.Clear();
            picStudent.Image = null;
            studentImage = null;
        }

        private void btnViewlist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
            {
                pnl.Region = new Region(Path);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
            {
                pnl.Region = new Region(Path);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = (Panel)sender;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath Path = GetRoundPath(new RectangleF(0, 0, pnl.Width, pnl.Height), 20))
            {
                pnl.Region = new Region(Path);
            }
        }
    }

}