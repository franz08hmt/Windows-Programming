using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_StudentRequest : UserControl
    {
        private My_DB db = new My_DB();
        private string currentMSSV = Globals.GlobalUserName; // Luôn giữ Mã số sinh viên (Ví dụ: 24110001) hoặc 'admin'

        public f_StudentRequest()
        {
            InitializeComponent();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            TruocXuatNguoiDung();
        }

        private void EnsureMSSVColumnIsVarChar()
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS " +
                    "WHERE TABLE_NAME='StudentRequests' AND COLUMN_NAME='MSSV' AND DATA_TYPE='int') " +
                    "BEGIN ALTER TABLE StudentRequests ALTER COLUMN MSSV NVARCHAR(50) END",
                    db.conn);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally { db.closeConnection(); }
        }

        // 🌟 SỰ KIỆN LOAD FORM: Phân quyền chuẩn chỉnh - Chặn đứng HR (2)
        private void f_StudentRequest_Load(object sender, EventArgs e)
        {
            EnsureMSSVColumnIsVarChar();
            // 1. Nếu là HR (Quy ước = 2) -> Trục xuất thẳng tay
            if (Globals.GlobalPosition == 2)
            {
                MessageBox.Show("🤖 [HỆ THỐNG CHẶN TRUY CẬP]: Giao diện gửi phiếu đề nghị này chỉ dành riêng cho Sinh viên và Admin giám sát!\n\nTài khoản HR không có quyền thực thi.",
                                "Từ chối phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TruocXuatNguoiDung();
                return;
            }

            // 2. Nếu là ADMIN (Globals.GlobalPosition == 0) -> Chế độ giám sát tổng quan
            if (Globals.GlobalPosition == 0)
            {
                currentMSSV = "admin"; // 🔒 Chốt chặn an toàn
                txtMSSV.Text = "";
                txtMSSV.ReadOnly = true;

                txtStudentName.Text = "Ban Quản Trị Hệ Thống (Chỉ xem)";
                txtStudentName.ReadOnly = true;

                btnSendRequest.Enabled = false;
                btnSendRequest.Text = "Admin chỉ xem";

                LoadCoursesToComboBox();
                LoadAllRequestsForAdmin(); // Nạp toàn bộ đơn của trường lên Grid cho Admin duyệt
            }
            // 3. Nếu là SINH VIÊN (Globals.GlobalPosition == 1) -> Cho phép gửi đơn
            else
            {
                currentMSSV = Globals.GlobalUserId; // Lấy chuẩn số MSSV

                txtMSSV.Text = currentMSSV;
                txtMSSV.ReadOnly = false;
                btnSendRequest.Enabled = true;

                LayThongTinTenSinhVien();
                LoadCoursesToComboBox();
                LoadRequestHistory(); // Chỉ nạp lịch sử đơn của RIÊNG sinh viên này
            }
        }

        // 🔄 Hàm xử lý trục xuất an toàn: Đóng/Ẩn tận gốc giao diện hiện tại
        private void TruocXuatNguoiDung()
        {
            string currentUserName = Globals.GlobalUserName;
            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();

            // Tìm Form cha đang chứa UserControl này và ẩn/xóa nó đi
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                // Nếu form cha là form phụ, ta đóng hẳn. Nếu là form Main chính, ta gỡ UserControl khỏi Panel
                if (parentForm.Name != "f_Main" && parentForm.Name != "f_HomePage")
                {
                    parentForm.Hide();
                }
            }

            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this); // Xóa bản thân khỏi Panel điều hướng
            }
        }

        private void LoadAllRequestsForAdmin()
        {
            string query = "SELECT ID as 'Mã Yêu Cầu', MSSV as 'MSSV', " +
                           "TenSV as 'Tên Sinh Viên', NgayGui as 'Ngày Gửi', " +
                           "NoiDung as 'Nội Dung Tóm Tắt', TrangThai as 'Trạng Thái' " +
                           "FROM StudentRequests ORDER BY NgayGui DESC";
            try
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                dgvHistory.DataSource = dt;
                DinhDangTrangThaiDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu Admin: " + ex.Message, "Lỗi hệ thống");
            }
        }

        private void DinhDangTrangThaiDGV()
        {
            // TrangThai đã lưu tiếng Việt trong DB, không cần convert
        }

        private void LayThongTinTenSinhVien()
        {
            string query = "SELECT Lname + ' ' + Fname FROM Login WHERE MSGV = @mssv";
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.Add("@mssv", SqlDbType.VarChar).Value = currentMSSV;

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    txtStudentName.Text = result.ToString().Trim();
                    txtStudentName.ReadOnly = true;
                }
                else
                {
                    txtStudentName.Text = "Không tìm thấy tên sinh viên";
                    txtStudentName.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xác thực danh tính: " + ex.Message, "Lỗi hệ thống");
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void LoadCoursesToComboBox()
        {
            string query = "SELECT MaMH, TenMH FROM Course";
            try
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }

                DataRow newRow = dt.NewRow();
                newRow["MaMH"] = "NONE";
                newRow["TenMH"] = "-- Không chọn (Yêu cầu chung) --";
                dt.Rows.InsertAt(newRow, 0);

                cboCourse.DataSource = dt;
                cboCourse.DisplayMember = "TenMH";
                cboCourse.ValueMember = "MaMH";
                cboCourse.SelectedIndex = 0;
            }
            catch { }
        }

        private void LoadRequestHistory()
        {
            string query = "SELECT ID as 'Mã Yêu Cầu', NgayGui as 'Ngày Gửi', " +
                           "NoiDung as 'Nội Dung Tóm Tắt', TrangThai as 'Trạng Thái' " +
                           "FROM StudentRequests WHERE MSSV = @mssv ORDER BY NgayGui DESC";
            try
            {
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    cmd.Parameters.Add("@mssv", SqlDbType.VarChar).Value = currentMSSV;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }

                dgvHistory.DataSource = dt;
                DinhDangTrangThaiDGV();
            }
            catch { }
        }



        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            currentMSSV = txtMSSV.Text.Trim();
            if (string.IsNullOrWhiteSpace(currentMSSV))
            {
                MessageBox.Show("Vui lòng nhập Mã Số Sinh Viên!", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMSSV.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Ní vui lòng nhập chi tiết nội dung yêu cầu/đề nghị trước khi bấm gửi nhé!",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContent.Focus();
                return;
            }

            string loaiYeuCau = cboRequestType.SelectedItem != null ? cboRequestType.SelectedItem.ToString() : "Khác";
            string monHoc = "";
            if (cboCourse.SelectedValue != null && cboCourse.SelectedValue.ToString() != "NONE")
            {
                monHoc = $" [Môn: {cboCourse.Text}]";
            }

            string fullContent = $"[{loaiYeuCau}]{monHoc} -> LÝ DO: {txtContent.Text.Trim()}";
            string insertQuery = "INSERT INTO StudentRequests (MSSV, TenSV, NoiDung, TrangThai) " +
                                 "VALUES (@mssv, @name, @content, N'Chờ xử lý')";

            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(insertQuery, db.conn);

                cmd.Parameters.Add("@mssv", SqlDbType.VarChar).Value = currentMSSV;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtStudentName.Text.Trim();
                cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = fullContent;

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Gửi request yêu cầu lên hệ thống thành công tốt đẹp!",
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtContent.Clear();
                    LoadRequestHistory();
                }
                else
                {
                    MessageBox.Show("Hệ thống không thể lưu phiếu đề nghị!", "Lỗi thực thi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi gửi dữ liệu: " + ex.Message, "Lỗi SQL");
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}