using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_RegisterCourse : Form
    {
        private My_DB db = new My_DB();

        public f_RegisterCourse()
        {
            InitializeComponent();
        }

        private void f_RegisterCourse_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 244, 247);

            if (dgvRegisterList != null)
            {
                dgvRegisterList.BackgroundColor = Color.White;
                dgvRegisterList.BorderStyle = BorderStyle.None;
                dgvRegisterList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            LoadStudentsToComboBox();
            LoadCoursesToComboBox();
        }

        private void LoadStudentsToComboBox()
        {
            try
            {
                string query = "SELECT MSSV, Lname + ' ' + Fname AS Hoten FROM Student";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                cboStudent.DataSource = table;
                cboStudent.DisplayMember = "Hoten";
                cboStudent.ValueMember = "MSSV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCoursesToComboBox()
        {
            try
            {
                string query = "SELECT MaMH, TenMH FROM Course";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                cboCourse.DataSource = table;
                cboCourse.DisplayMember = "TenMH";
                cboCourse.ValueMember = "MaMH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách môn học: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue != null && cboStudent.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                LoadRegisteredCourses(cboStudent.SelectedValue.ToString());
            }
        }

        private void LoadRegisteredCourses(string mssv)
        {
            try
            {
                string query = "SELECT d.MaMH as 'Mã Môn', c.TenMH as 'Tên Môn Học', c.SoTC as 'Số Tín Chỉ' " +
                               "FROM DKMH d JOIN Course c ON d.MaMH = c.MaMH " +
                               "WHERE d.MSSV = @mssv";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                cmd.Parameters.AddWithValue("@mssv", mssv);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (dgvRegisterList != null)
                    dgvRegisterList.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách môn đã đăng ký: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboCourse.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Sinh viên và Môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

    
            string selectedMSSV = cboStudent.SelectedValue.ToString().Trim();
            string selectedMaMH = cboCourse.SelectedValue.ToString().Trim();

            try
            {
   
                string checkQuery = @"
            SELECT 
                c1.Hky, 
                c1.SoTC AS SoTCMonMoi,
                (SELECT ISNULL(SUM(c2.SoTC), 0) 
                 FROM DKMH d 
                 JOIN Course c2 ON d.MaMH = c2.MaMH 
                 WHERE d.MSSV = @mssv AND c2.Hky = c1.Hky) AS TongTCDaDangKy
            FROM Course c1 
            WHERE c1.MaMH = @mamh";

                int hky = 0;
                int soTCMonMoi = 0;
                int tongTCDaDangKy = 0;

                SqlCommand cmdCheck = new SqlCommand(checkQuery, db.getConnection);
                cmdCheck.Parameters.AddWithValue("@mssv", selectedMSSV);
                cmdCheck.Parameters.AddWithValue("@mamh", selectedMaMH);

                SqlDataAdapter da = new SqlDataAdapter(cmdCheck);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    hky = Convert.ToInt32(dt.Rows[0]["Hky"]);
                    soTCMonMoi = Convert.ToInt32(dt.Rows[0]["SoTCMonMoi"]);
                    tongTCDaDangKy = Convert.ToInt32(dt.Rows[0]["TongTCDaDangKy"]);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin môn học này trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

     
                MessageBox.Show($"[KIỂM TRA DỮ LIỆU]:\n" +
                                $"- Môn học này thuộc: Học kỳ {hky}\n" +
                                $"- Số tín chỉ môn này: {soTCMonMoi} TC\n" +
                                $"- Số tín chỉ ĐÃ ĐĂNG KÝ ở Học kỳ {hky} trước đó: {tongTCDaDangKy} TC\n" +
                                $"- Tổng số sau khi cộng thêm: {tongTCDaDangKy + soTCMonMoi} TC",
                                "Hệ thống theo dõi TC");

       
                if (tongTCDaDangKy + soTCMonMoi > 24)
                {
                    MessageBox.Show($"Không thể đăng ký! Trong Học kỳ {hky}, sinh viên này đã đăng ký {tongTCDaDangKy} TC.\n" +
                                    $"Nếu đăng ký thêm môn này ({soTCMonMoi} TC) sẽ vượt quá giới hạn tối đa 24 TC của một học kỳ!",
                                    "Cảnh báo vượt hạn mức tín chỉ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

   
                db.openConnection();
                string query = "INSERT INTO DKMH (MSSV, MaMH) VALUES (@mssv, @mamh)";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", selectedMSSV);
                cmd.Parameters.AddWithValue("@mamh", selectedMaMH);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đăng ký môn học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRegisteredCourses(selectedMSSV); // Nạp lại bảng hiển thị
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Sinh viên này đã đăng ký môn học này rồi!", "Trùng lịch học", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void dgvRegisterList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mamh = dgvRegisterList.Rows[e.RowIndex].Cells["Mã Môn"].Value.ToString();
                string tenmh = dgvRegisterList.Rows[e.RowIndex].Cells["Tên Môn Học"].Value.ToString();
                string mssv = cboStudent.SelectedValue.ToString();

                DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn HỦY đăng ký môn học [{tenmh}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        db.openConnection();
                        SqlCommand cmd = new SqlCommand("DELETE FROM DKMH WHERE MSSV = @mssv AND MaMH = @mamh", db.conn);
                        cmd.Parameters.AddWithValue("@mssv", mssv);
                        cmd.Parameters.AddWithValue("@mamh", mamh);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Hủy môn học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadRegisteredCourses(mssv);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        db.closeConnection();
                    }
                }
            }
        }
    }
}