using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_AddCourse : BaseForm
    {
        private My_DB db = new My_DB();

        public f_AddCourse()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Kiểm tra ràng buộc dữ liệu cơ bản
            if (string.IsNullOrEmpty(txb_MaMH.Text) || string.IsNullOrEmpty(txb_TenMH.Text) || cbb_Hocky.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Course course = new Course();
            course.Mamh = txb_MaMH.Text;
            course.Tenmh = txb_TenMH.Text;
            course.Tuan = (int)Updown_Period.Value;
            course.Hocky = int.Parse(cbb_Hocky.SelectedItem.ToString());
            course.Decription = rtb_Decription.Text;

            // 1. Kiểm tra tên môn học trùng (NÂNG CAO: Chống SQL Injection)
            if (checkCoursName(course.Tenmh))
            {
                MessageBox.Show("Tên môn học đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 2. Kiểm tra số tuần tối thiểu >= 10
            else if ((int)Updown_Period.Value < 10)
            {
                MessageBox.Show("Số Tuần Học Không Hợp Lệ (tối thiểu 10)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 3. Kiểm tra số tín chỉ phải là số hợp lệ
            else if (txb_SoTC.Text.All(char.IsDigit) && !string.IsNullOrEmpty(txb_SoTC.Text))
            {
                course.Sotc = int.Parse(txb_SoTC.Text);

                if (course.AddCourse())
                {
                    MessageBox.Show("Thêm khóa học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Vui lòng kiểm tra lại mã môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Số tín chỉ phải nhập bằng số và không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔧 TÍCH HỢP NÂNG CAO: Sử dụng Parameters để chống lỗi bảo mật SQL Injection
        private bool checkCoursName(string name)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE TenMH LIKE @name", db.getConnection);
            cmd.Parameters.AddWithValue("@name", name);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows.Count > 0;
        }

        private void ClearForm()
        {
            txb_MaMH.Clear();
            txb_TenMH.Clear();
            txb_SoTC.Clear();
            Updown_Period.Value = 10;
            cbb_Hocky.SelectedIndex = -1;
            rtb_Decription.Clear();
        }
    }
}