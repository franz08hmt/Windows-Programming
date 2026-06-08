using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_StudentRequest : BaseForm
    {
        private My_DB db = new My_DB();

        public f_StudentRequest()
        {
            InitializeComponent();
        }

        private void f_StudentRequest_Load(object sender, EventArgs e)
        {
            ConfigureGrid();

            // Thử tự động điền MSSV nếu join được qua Email
            TuDongDienMSSV();

            // Load lịch sử request nếu đã có MSSV
            if (!string.IsNullOrWhiteSpace(txtMSSV.Text))
                LoadRequestCuaToi();
        }

        private void ConfigureGrid()
        {
            dgvMyRequests.ReadOnly = true;
            dgvMyRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyRequests.MultiSelect = false;
            dgvMyRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyRequests.AllowUserToAddRows = false;
            dgvMyRequests.DataBindingComplete += DgvMyRequests_DataBindingComplete;
        }

        // Thử tự động điền MSSV qua Email
        private void TuDongDienMSSV()
        {
            try
            {
                db.openConnection();
                string query =
                    "SELECT s.MSSV FROM Student s " +
                    "INNER JOIN Login l ON s.Email = l.Email " +
                    "WHERE l.MSGV = @msgv";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@msgv", Globals.GlobalUserId);
                object result = cmd.ExecuteScalar();
                db.closeConnection();

                if (result != null && result != DBNull.Value)
                {
                    txtMSSV.Text = result.ToString();
                    txtMSSV.ReadOnly = true; // Đã tìm được, khóa lại
                }
            }
            catch { db.closeConnection(); }
        }

        private void LoadRequestCuaToi()
        {
            if (!int.TryParse(txtMSSV.Text.Trim(), out int mssv))
            {
                lblStatus.Text = "Vui lòng nhập MSSV hợp lệ.";
                return;
            }
            try
            {
                string query =
                    "SELECT " +
                    "    r.RequestID   AS [Mã YC], " +
                    "    r.RequestDate AS [Ngày gửi], " +
                    "    r.Note        AS [Nội dung yêu cầu], " +
                    "    r.Status      AS [Trạng thái] " +
                    "FROM StudentRequest r " +
                    "WHERE r.MSSV = @mssv " +
                    "ORDER BY r.RequestDate DESC";

                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMyRequests.DataSource = dt;
                lblStatus.Text = dt.Rows.Count > 0
                    ? "Trạng thái gần nhất: " + dt.Rows[0]["Trạng thái"].ToString()
                    : "Bạn chưa gửi yêu cầu nào.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        // Nút xem lịch sử sau khi nhập MSSV thủ công
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadRequestCuaToi();
        }

        private void DgvMyRequests_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMyRequests.Rows)
            {
                string status = row.Cells["Trạng thái"].Value?.ToString() ?? "";
                switch (status)
                {
                    case "Approved":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(198, 239, 206);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(0, 97, 0);
                        break;
                    case "Declined":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 199, 206);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(156, 0, 6);
                        break;
                    case "Pending":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 156);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(102, 71, 0);
                        break;
                }
            }
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMSSV.Text.Trim(), out int mssv))
            {
                MessageBox.Show("Vui lòng nhập MSSV hợp lệ (số nguyên)!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra MSSV có tồn tại trong bảng Student không
            try
            {
                db.openConnection();
                string checkSV = "SELECT COUNT(*) FROM Student WHERE MSSV = @mssv";
                SqlCommand chkCmd = new SqlCommand(checkSV, db.getConnection);
                chkCmd.Parameters.AddWithValue("@mssv", mssv);
                int exists = (int)chkCmd.ExecuteScalar();
                db.closeConnection();

                if (exists == 0)
                {
                    MessageBox.Show("MSSV không tồn tại trong hệ thống!\nVui lòng kiểm tra lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi kiểm tra MSSV: " + ex.Message, "Lỗi");
                return;
            }

            // Kiểm tra đã có Pending chưa
            try
            {
                db.openConnection();
                string checkQuery = "SELECT COUNT(*) FROM StudentRequest WHERE MSSV = @mssv AND Status = 'Pending'";
                SqlCommand checkCmd = new SqlCommand(checkQuery, db.getConnection);
                checkCmd.Parameters.AddWithValue("@mssv", mssv);
                int pending = (int)checkCmd.ExecuteScalar();
                db.closeConnection();

                if (pending > 0)
                {
                    MessageBox.Show("Đã có yêu cầu đang chờ duyệt.\nVui lòng chờ Admin xử lý!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi kiểm tra: " + ex.Message, "Lỗi");
                return;
            }

            // Gửi request
            try
            {
                db.openConnection();
                string insertQuery =
                    "INSERT INTO StudentRequest (MSSV, RequestDate, Note, Status) " +
                    "VALUES (@mssv, GETDATE(), @note, 'Pending')";

                SqlCommand cmd = new SqlCommand(insertQuery, db.getConnection);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(txtNote.Text)
                    ? "Yêu cầu xác nhận thông tin sinh viên"
                    : txtNote.Text.Trim());

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("✅ Gửi yêu cầu thành công!\nVui lòng chờ Admin phê duyệt.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNote.Clear();
                    LoadRequestCuaToi();
                }
                db.closeConnection();
            }
            catch (Exception ex)
            {
                db.closeConnection();
                MessageBox.Show("Lỗi gửi yêu cầu: " + ex.Message, "Lỗi");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) { this.Close(); }
    }
}