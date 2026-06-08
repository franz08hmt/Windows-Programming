using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ManageRequest : BaseForm
    {
        private My_DB db = new My_DB();

        public f_ManageRequest()
        {
            InitializeComponent();
        }

        // ===================================================================
        // LOAD FORM
        // ===================================================================
        private void f_ManageRequest_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            LoadDanhSachRequest();
        }

        // Cấu hình DataGridView: không cho edit, chọn nguyên dòng
        private void ConfigureGrid()
        {
            dgvRequests.ReadOnly = true;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.MultiSelect = false;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.AllowUserToAddRows = false;

            // Highlight màu dòng theo Status khi dữ liệu load xong
            dgvRequests.DataBindingComplete += DgvRequests_DataBindingComplete;
        }

        // ===================================================================
        // TẢI DANH SÁCH REQUEST – JOIN Student để Admin thấy đủ thông tin
        // ===================================================================
        private void LoadDanhSachRequest()
        {
            try
            {
                // JOIN Student để Admin thấy Họ tên, Email, SĐT của sinh viên gửi request
                string query =
                    "SELECT " +
                    "    r.RequestID        AS [Mã YC], " +
                    "    r.MSSV             AS [MSSV], " +
                    "    s.Fname + ' ' + s.Lname AS [Họ và Tên], " +
                    "    s.Email            AS [Email], " +
                    "    s.Phone            AS [Số điện thoại], " +
                    "    r.RequestDate      AS [Ngày gửi], " +
                    "    r.Note             AS [Nội dung yêu cầu], " +
                    "    r.Status           AS [Trạng thái] " +
                    "FROM StudentRequest r " +
                    "INNER JOIN Student s ON r.MSSV = s.MSSV " +
                    "ORDER BY " +
                    "    CASE r.Status WHEN 'Pending' THEN 0 ELSE 1 END, " +  // Pending lên đầu
                    "    r.RequestDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, db.getConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRequests.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách yêu cầu:\n" + ex.Message, "Lỗi kết nối",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tô màu dòng theo trạng thái để Admin dễ nhận biết
        private void DgvRequests_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                switch (status)
                {
                    case "Approved":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(198, 239, 206); // xanh nhạt
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 97, 0);
                        break;
                    case "Declined":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 199, 206); // đỏ nhạt
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(156, 0, 6);
                        break;
                    case "Pending":
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 235, 156); // vàng nhạt
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(102, 71, 0);
                        break;
                }
            }
        }

        // ===================================================================
        // APPROVE – Chấp nhận yêu cầu
        // ===================================================================
        private void btnApprove_Click(object sender, EventArgs e)
        {
            CapNhatTrangThai("Approved");
        }

        // ===================================================================
        // DECLINE – Từ chối yêu cầu
        // ===================================================================
        private void btnDecline_Click(object sender, EventArgs e)
        {
            CapNhatTrangThai("Declined");
        }

        // ===================================================================
        // HÀM CHUNG: CẬP NHẬT TRẠNG THÁI REQUEST
        // ===================================================================
        private void CapNhatTrangThai(string trangThaiMoi)
        {
            if (dgvRequests.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu trong danh sách để xử lý!", "Nhắc nhở",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Không cho Approve/Decline request đã xử lý rồi
            string trangThaiHienTai = dgvRequests.CurrentRow.Cells["Trạng thái"].Value?.ToString() ?? "";
            if (trangThaiHienTai != "Pending")
            {
                MessageBox.Show($"Yêu cầu này đã được xử lý trước đó ({trangThaiHienTai}).\nKhông thể thay đổi!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xác nhận hành động
            string tenSV = dgvRequests.CurrentRow.Cells["Họ và Tên"].Value?.ToString() ?? "";
            string mssv = dgvRequests.CurrentRow.Cells["MSSV"].Value?.ToString() ?? "";
            string confirmMsg = trangThaiMoi == "Approved"
                ? $"✅ Xác nhận CHẤP NHẬN yêu cầu của sinh viên:\n{mssv} – {tenSV}?"
                : $"❌ Xác nhận TỪ CHỐI yêu cầu của sinh viên:\n{mssv} – {tenSV}?";

            DialogResult confirm = MessageBox.Show(confirmMsg, "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Thực hiện cập nhật
            try
            {
                string requestId = dgvRequests.CurrentRow.Cells["Mã YC"].Value.ToString();
                db.openConnection();

                string query = "UPDATE StudentRequest SET Status = @status WHERE RequestID = @id";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@status", trangThaiMoi);
                cmd.Parameters.AddWithValue("@id", requestId);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    string icon = trangThaiMoi == "Approved" ? "✅" : "❌";
                    MessageBox.Show($"{icon} Cập nhật thành công: {trangThaiMoi}!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachRequest(); // Reload lại bảng
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi khi cập nhật:\n" + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}