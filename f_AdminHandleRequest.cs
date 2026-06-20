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
    public partial class f_AdminHandleRequest : UserControl
    {
        private My_DB db = new My_DB();
        private int selectedRequestID = -1;
        public f_AdminHandleRequest()
        {
            InitializeComponent();
            this.Resize += f_AdminHandleRequest_Resize;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;
            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();
        }

        // 🌟 SỰ KIỆN LOAD FORM: Chặn đứng Sinh viên (1), chỉ cho Admin (0) và HR (2) lọt vào
        private void f_AdminHandleRequest_Load(object sender, EventArgs e)
        {
            if (Globals.GlobalPosition == 1)
            {
                MessageBox.Show("🚫 [CẢNH BÁO BẢO MẬT]: Tài khoản Sinh viên không có quyền truy cập vào phân hệ phê duyệt của Ban Giám Hiệu/Giáo vụ!\n\nHệ thống sẽ trục xuất bạn ra màn hình chính.",
                                "Từ chối quyền truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                // 🔄 1. Khởi tạo và hiển thị lại trang chủ cho Sinh viên
                string currentUserName = Globals.GlobalUserName;
                f_HomePage homeForm = new f_HomePage(currentUserName);
                homeForm.Show();

                // 🔄 2. LỆNH CHÍ MẠNG: Tìm Form chứa UserControl này để đóng triệt để, không cho hiển thị rò rỉ dữ liệu
                Form parentForm = this.FindForm();
                if (parentForm != null)
                {
                    parentForm.Hide(); // Ẩn form cũ đi ngay lập tức
                                       // Nếu đây là UserControl nằm trong Panel của Form chính, ta có thể dùng:
                                       // this.Controls.Clear(); hoặc xóa nó khỏi Panel cha:
                    if (this.Parent != null)
                    {
                        this.Parent.Controls.Remove(this);
                    }
                }
                return; // Ngắt luồng, tuyệt đối không chạy code truy vấn SQL phía dưới!
            }

            // --- NẾU LÀ ADMIN (0) HOẶC HR (2) THÌ TIẾP TỤC THỰC THI HIỂN THỊ DỮ LIỆU ---
            if (cboStatusFilter.Items.Count == 0)
            {
                cboStatusFilter.Items.AddRange(new object[] { "Tất cả", "Chờ duyệt", "Đã duyệt", "Từ chối" });
            }
            cboStatusFilter.SelectedIndex = 0; // Mặc định bộ lọc "Tất cả"

            LoadRequestsData(); // Tải dữ liệu lên bảng DataGridView công khai cho Admin/HR xử lý
            ApplyResponsiveLayout();

            // Đăng ký các sự kiện tìm kiếm thời gian thực
            txtSearch.TextChanged -= (s, ev) => LoadRequestsData(); // Hủy đăng ký cũ nếu có để tránh lặp sự kiện
            txtSearch.TextChanged += (s, ev) => LoadRequestsData();
            cboStatusFilter.SelectedIndexChanged -= (s, ev) => LoadRequestsData();
            cboStatusFilter.SelectedIndexChanged += (s, ev) => LoadRequestsData();
        }

        private void LoadRequestsData()
        {
            string query = "SELECT ID as 'Mã Yêu Cầu', MSSV as 'MSSV', " +
                           "TenSV as 'Tên Sinh Viên', NgayGui as 'Ngày Gửi', " +
                           "NoiDung as 'Nội Dung Yêu Cầu', TrangThai as 'Trạng Thái' " +
                           "FROM StudentRequests WHERE 1=1";

            string statusSelected = cboStatusFilter.SelectedItem?.ToString() ?? "Tất cả";
            if (statusSelected == "Chờ duyệt") query += " AND TrangThai = N'Chờ xử lý'";
            else if (statusSelected == "Đã duyệt") query += " AND TrangThai = N'Đã duyệt'";
            else if (statusSelected == "Từ chối") query += " AND TrangThai = N'Từ chối'";

            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                query += " AND (CAST(MSSV AS NVARCHAR) LIKE @key OR TenSV LIKE @key)";
            }

            query += " ORDER BY NgayGui DESC";

            try
            {
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                if (!string.IsNullOrEmpty(keyword))
                {
                    cmd.Parameters.AddWithValue("@key", "%" + keyword + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                VietnameseTextHelper.NormalizeColumns(dt, "Tên Sinh Viên", "Nội Dung Yêu Cầu", "Trạng Thái");

                dgvRequests.DataSource = dt;

                if (dgvRequests.Columns.Count >= 6)
                {
                    dgvRequests.Columns["Mã Yêu Cầu"].Width = 130;
                    dgvRequests.Columns["MSSV"].Width = 100;
                    dgvRequests.Columns["Tên Sinh Viên"].Width = 170;
                    dgvRequests.Columns["Ngày Gửi"].Width = 120;
                    dgvRequests.Columns["Nội Dung Yêu Cầu"].Width = 260;
                    dgvRequests.Columns["Trạng Thái"].Width = 130;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách yêu cầu: " + ex.Message, "Lỗi hệ thống");
            }
        }

        private void dgvRequests_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvRequests.Rows.Count)
            {
                DataGridViewRow row = dgvRequests.Rows[e.RowIndex];
                selectedRequestID = Convert.ToInt32(row.Cells[0].Value);

                string rawContent = VietnameseTextHelper.Normalize(row.Cells["Nội Dung Yêu Cầu"].Value?.ToString() ?? "");
                txtRequestDetails.Text = rawContent.Replace(" -> ", Environment.NewLine + "➡️ ");
                txtRequestDetails.ReadOnly = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedRequestID == -1)
            {
                MessageBox.Show("Ní vui lòng click chọn một yêu cầu cụ thể từ danh sách bên trái trước nhé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string updateQuery = "UPDATE StudentRequests SET TrangThai = N'Đã duyệt' WHERE ID = @id";
            ExecuteStatusUpdate(updateQuery, "Phê duyệt yêu cầu thành công tốt đẹp!");
        }

        private void btnDecline_Click_1(object sender, EventArgs e)
        {
            if (selectedRequestID == -1)
            {
                MessageBox.Show("Ní vui lòng click chọn một yêu cầu cụ thể từ danh sách bên trái trước nhé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Ní có chắc chắn muốn TỪ CHỐI đơn đề nghị này của sinh viên không?", "Xác nhận từ chối", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                string updateQuery = "UPDATE StudentRequests SET TrangThai = N'Từ chối' WHERE ID = @id";
                ExecuteStatusUpdate(updateQuery, "Đã từ chối đơn đề nghị của sinh viên.");
            }
        }

        private void ExecuteStatusUpdate(string sqlQuery, string successMessage)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(sqlQuery, db.conn);
                cmd.Parameters.AddWithValue("@id", selectedRequestID);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(successMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedRequestID = -1;
                    txtRequestDetails.Clear();
                    LoadRequestsData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã phiếu yêu cầu tương ứng hoặc dữ liệu bị nghẽn!", "Lỗi cập nhật");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi cơ sở dữ liệu: " + ex.Message, "Lỗi SQL");
            }
            finally
            {
                db.closeConnection();
            }
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void f_AdminHandleRequest_Resize(object sender, EventArgs e)
        {
            ApplyResponsiveLayout();
        }

        private void ApplyResponsiveLayout()
        {




        }

    }
}