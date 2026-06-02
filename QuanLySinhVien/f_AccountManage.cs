using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_AccountManage : Form
    {
        public f_AccountManage()
        {
            InitializeComponent();
        }

        private void f_AccountManage_Load(object sender, EventArgs e)
        {
            LoadPendingAccounts();
        }

        private void LoadPendingAccounts()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                string query = @"SELECT MSGV, Fname, Lname, Username, Email,
                                CASE position WHEN 1 THEN N'Sinh viên' WHEN 2 THEN N'HR' ELSE N'Admin' END AS [Loại TK],
                                CASE VALID WHEN 0 THEN N'Chờ duyệt' WHEN 1 THEN N'Đã duyệt' ELSE N'Từ chối' END AS [Trạng thái]
                                FROM Login ORDER BY VALID ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, db.conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvAccounts.DataSource = dt;
                dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvAccounts.ReadOnly = true;
                dgvAccounts.AllowUserToAddRows = false;

                UpdateStatusCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void UpdateStatusCount()
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                int pending = Convert.ToInt32(new SqlCommand(
                    "SELECT COUNT(*) FROM Login WHERE VALID=0", db.conn).ExecuteScalar());
                int approved = Convert.ToInt32(new SqlCommand(
                    "SELECT COUNT(*) FROM Login WHERE VALID=1", db.conn).ExecuteScalar());
                lblPending.Text = $"Chờ duyệt: {pending}";
                lblApproved.Text = $"Đã duyệt: {approved}";
            }
            catch { }
            finally { db.closeConnection(); }
        }

        private string GetSelectedMSGV()
        {
            if (dgvAccounts.CurrentRow == null) return null;
            return dgvAccounts.CurrentRow.Cells["MSGV"].Value?.ToString();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string msgv = GetSelectedMSGV();
            if (string.IsNullOrEmpty(msgv)) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }

            string ten = dgvAccounts.CurrentRow.Cells["Fname"].Value + " " +
                         dgvAccounts.CurrentRow.Cells["Lname"].Value;

            var confirm = MessageBox.Show($"Duyệt tài khoản [{ten}]?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            if (UpdateValid(msgv, 1))
            {
                MessageBox.Show("Duyệt tài khoản thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingAccounts();
            }
            else
                MessageBox.Show("Thao tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            string msgv = GetSelectedMSGV();
            if (string.IsNullOrEmpty(msgv)) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }

            string ten = dgvAccounts.CurrentRow.Cells["Fname"].Value + " " +
                         dgvAccounts.CurrentRow.Cells["Lname"].Value;

            var confirm = MessageBox.Show($"Từ chối tài khoản [{ten}]?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            if (UpdateValid(msgv, -1))
            {
                MessageBox.Show("Đã từ chối tài khoản!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPendingAccounts();
            }
            else
                MessageBox.Show("Thao tác thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msgv = GetSelectedMSGV();
            if (string.IsNullOrEmpty(msgv)) { MessageBox.Show("Vui lòng chọn tài khoản!"); return; }

            string ten = dgvAccounts.CurrentRow.Cells["Fname"].Value + " " +
                         dgvAccounts.CurrentRow.Cells["Lname"].Value;

            var confirm = MessageBox.Show($"Xóa vĩnh viễn tài khoản [{ten}]?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Login WHERE MSGV=@msgv", db.conn);
                cmd.Parameters.AddWithValue("@msgv", msgv);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPendingAccounts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private bool UpdateValid(string msgv, int valid)
        {
            My_DB db = new My_DB();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Login SET VALID=@valid WHERE MSGV=@msgv", db.conn);
                cmd.Parameters.AddWithValue("@valid", valid);
                cmd.Parameters.AddWithValue("@msgv", msgv);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch { return false; }
            finally { db.closeConnection(); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingAccounts();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}