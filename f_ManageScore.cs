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
using System.Drawing.Drawing2D;

namespace QuanLySinhVien
{
    public partial class f_ManageScore : Form
    {
        public f_ManageScore()
        {
            InitializeComponent();
            RegisterRealTimeValidation();
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

        private void f_ManageScore_Load(object sender, EventArgs e)
        {
            txtTK.ReadOnly = true;
            txtTK.BackColor = Color.LightGray;
            txtXepLoai.ReadOnly = true;
            txtXepLoai.BackColor = Color.LightGray;

            LoadStudentCombo();
            if (cboStudent.SelectedValue != null)
            {
                string mssv = cboStudent.SelectedValue.ToString();
                LoadCoursesRegisteredByStudent(mssv);
                DisplayScoreBoard(mssv);
            }

            if (cboTrongSo.Items.Count > 0) cboTrongSo.SelectedIndex = 0;
        }

        private void LoadStudentCombo()
        {
            cboStudent.DataSource = Student.GetStudents();
            cboStudent.DisplayMember = "Lname";
            cboStudent.ValueMember = "MSSV";
        }

        private void LoadCoursesRegisteredByStudent(string mssv)
        {
            My_DB db = new My_DB();
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT c.MaMH, c.TenMH FROM DKMH d JOIN Course c ON d.MaMH = c.MaMH WHERE d.MSSV = @mssv";
                SqlCommand cmd = new SqlCommand(query, db.conn);
                cmd.Parameters.AddWithValue("@mssv", mssv);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                cboCourse.DataSource = dt;
                cboCourse.DisplayMember = "TenMH";
                cboCourse.ValueMember = "MaMH";
            }
            catch { }
            finally { db.closeConnection(); }
        }

        private void DisplayScoreBoard(string mssv)
        {
            DataTable dt = Score.GetStudentScoreBoard(mssv);
            dgvScores.DataSource = dt;
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (dt == null || dt.Rows.Count == 0)
            {
                txtQT.Clear();
                txtCK.Clear();
                txtTK.Clear();
                txtXepLoai.Clear();
                txtMota.Clear();
            }

            decimal gpa4 = Score.CalculateGPA(mssv);
            lblGPA.Text = $"ĐIỂM GPA TÍCH LŨY: {gpa4:F2} / 4.0";

            string xepLoaiHocLuc = "";
            Color mauChu = Color.Black;

            if (gpa4 >= 3.60m) { xepLoaiHocLuc = "Xuất sắc"; mauChu = Color.Purple; }
            else if (gpa4 >= 3.20m) { xepLoaiHocLuc = "Giỏi"; mauChu = Color.DarkGreen; }
            else if (gpa4 >= 2.50m) { xepLoaiHocLuc = "Khá"; mauChu = Color.Blue; }
            else if (gpa4 >= 2.00m) { xepLoaiHocLuc = "Trung bình"; mauChu = Color.DarkOrange; }
            else { xepLoaiHocLuc = "Yếu / Kém"; mauChu = Color.Red; }

            if (lblXepLoai != null)
            {
                lblXepLoai.Text = $"XẾP LOẠI HỌC LỰC: {xepLoaiHocLuc}";
                lblXepLoai.ForeColor = mauChu;
            }
        }

        private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue != null &&
                cboStudent.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string mssv = cboStudent.SelectedValue.ToString();
                LoadCoursesRegisteredByStudent(mssv);
                DisplayScoreBoard(mssv);
            }
        }

        private void RegisterRealTimeValidation()
        {
            txtQT.TextChanged += (s, e) => {
                string text = txtQT.Text.Trim();
                if (string.IsNullOrEmpty(text))
                {
                    erpScore.SetError(txtQT, "");
                }
                else if (!decimal.TryParse(text, out decimal val))
                {
                    erpScore.SetError(txtQT, "Điểm quá trình không được chứa chữ hoặc ký tự đặc biệt!");
                }
                else if (val < 0 || val > 10)
                {
                    erpScore.SetError(txtQT, "Điểm số phải nằm trong khoảng từ 0 đến 10!");
                }
                else
                {
                    erpScore.SetError(txtQT, "");
                }
                CalculateTotal();
            };

            txtCK.TextChanged += (s, e) => {
                string text = txtCK.Text.Trim();
                if (string.IsNullOrEmpty(text))
                {
                    erpScore.SetError(txtCK, "");
                }
                else if (!decimal.TryParse(text, out decimal val))
                {
                    erpScore.SetError(txtCK, "Điểm cuối kỳ không được chứa chữ hoặc ký tự đặc biệt!");
                }
                else if (val < 0 || val > 10)
                {
                    erpScore.SetError(txtCK, "Điểm số phải nằm trong khoảng từ 0 đến 10!");
                }
                else
                {
                    erpScore.SetError(txtCK, "");
                }
                CalculateTotal();
            };
        }

        private void CalculateTotal()
        {
            string cleanQT = txtQT.Text.Trim();
            string cleanCK = txtCK.Text.Trim();

            if (string.IsNullOrEmpty(cleanQT) || string.IsNullOrEmpty(cleanCK))
            {
                txtTK.Clear();
                txtXepLoai.Clear();
                return;
            }

            if (decimal.TryParse(cleanQT, out decimal qt) && decimal.TryParse(cleanCK, out decimal ck))
            {
                if (qt < 0 || qt > 10 || ck < 0 || ck > 10)
                {
                    txtTK.Clear();
                    txtXepLoai.Clear();
                    return;
                }

                decimal heSoQT = 0.5m;
                decimal heSoCK = 0.5m;

                if (cboTrongSo.SelectedItem != null)
                {
                    string strTrongSo = cboTrongSo.SelectedItem.ToString();
                    string[] mangHeSo = strTrongSo.Split('/');
                    if (mangHeSo.Length == 2)
                    {
                        heSoQT = Convert.ToDecimal(mangHeSo[0]) / 100m;
                        heSoCK = Convert.ToDecimal(mangHeSo[1]) / 100m;
                    }
                }

                decimal tk = Math.Round((qt * heSoQT) + (ck * heSoCK), 2);
                txtTK.Text = tk.ToString("F2");

                if (tk >= 9.0m) txtXepLoai.Text = "Xuất sắc";
                else if (tk >= 8.0m) txtXepLoai.Text = "Giỏi";
                else if (tk >= 6.5m) txtXepLoai.Text = "Khá";
                else if (tk >= 5.0m) txtXepLoai.Text = "Trung bình";
                else txtXepLoai.Text = "Yếu";
            }
            else
            {
                txtTK.Clear();
                txtXepLoai.Clear();
            }
        }

        private void txtQT_TextChanged(object sender, EventArgs e) => CalculateTotal();
        private void txtCK_TextChanged(object sender, EventArgs e) => CalculateTotal();

        private void btnBack_Click(object sender, EventArgs e)
        {
            string currentUserName = Globals.GlobalUserName;
            f_HomePage homeForm = new f_HomePage(currentUserName);
            homeForm.Show();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtQT.Clear();
            txtCK.Clear();
            txtTK.Clear();
            txtXepLoai.Clear();
            txtMota.Clear();
            txtQT.Focus();
        }

        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboCourse.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Sinh viên và Môn học cần nhập điểm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtQT.Text.Trim(), out decimal qt) || !decimal.TryParse(txtCK.Text.Trim(), out decimal ck))
            {
                MessageBox.Show("Điểm quá trình và Điểm cuối kỳ phải là dữ liệu số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qt < 0 || qt > 10 || ck < 0 || ck > 10)
            {
                MessageBox.Show("Điểm số nhập vào phải nằm trong thang điểm quy định từ 0 đến 10!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtTK.Text.Trim(), out decimal tk))
            {
                MessageBox.Show("Hệ thống chưa ghi nhận được Điểm tổng kết. Vui lòng kiểm tra lại việc nhập Điểm quá trình và Điểm cuối kỳ!", "Lỗi xử lý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string xepLoai = txtXepLoai.Text.Trim();

            // 🛠️ SỬA LỖI TẠI ĐÂY: Chuyển đổi mã sinh viên sang kiểu số nguyên (int)
            if (!int.TryParse(cboStudent.SelectedValue.ToString(), out int mssv))
            {
                MessageBox.Show("Mã số sinh viên không hợp lệ (Phải là kiểu số)!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mamh = cboCourse.SelectedValue.ToString();
            string mota = txtMota.Text.Trim();

            // Khởi tạo lớp Score thành công với tham số đầu tiên là int mssv
            Score coreScore = new Score(mssv, mamh, qt, ck, tk, xepLoai, mota);

            if (coreScore.SaveScore())
            {
                MessageBox.Show("Đã thực hiện cập nhật và lưu thông tin điểm số thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayScoreBoard(mssv.ToString());
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống, không thể lưu điểm số.\nVui lòng kiểm tra lại cấu hình tên bảng hoặc tên cột trong cơ sở dữ liệu SQL Server!", "Thao tác thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(panel1, 25, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(panel2, 25, e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(panel3, 25, e);
        }

        private void dgvScores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvScores.Rows.Count - 1)
            {
                DataGridViewRow row = dgvScores.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    cboCourse.SelectedValue = row.Cells[0].Value.ToString();
                }

                if (row.Cells[3].Value != null)
                {
                    string diemThanhPhan = row.Cells[3].Value.ToString();
                    try
                    {
                        string[] phanDoan = diemThanhPhan.Split('|');
                        if (phanDoan.Length == 2)
                        {
                            string qtPart = phanDoan[0].Replace("QT:", "").Trim();
                            string ckPart = phanDoan[1].Replace("CK:", "").Trim();

                            txtQT.Text = qtPart;
                            txtCK.Text = ckPart;
                        }
                    }
                    catch
                    {
                        txtQT.Text = diemThanhPhan;
                        txtCK.Clear();
                    }
                }
                else
                {
                    txtQT.Clear();
                    txtCK.Clear();
                }

                txtTK.Text = row.Cells[4].Value?.ToString() ?? "";
                txtXepLoai.Text = row.Cells[5].Value?.ToString() ?? "";
                txtMota.Text = row.Cells[6].Value?.ToString() ?? "";

                if (erpScore != null)
                {
                    erpScore.Clear();
                }
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (erpScore != null && (!string.IsNullOrEmpty(erpScore.GetError(txtQT)) || !string.IsNullOrEmpty(erpScore.GetError(txtCK))))
            {
                MessageBox.Show("Không thể thực hiện chỉnh sửa thông tin điểm số!\nVui lòng sửa lại dữ liệu bị báo lỗi đỏ trên giao diện.",
                                "Thao tác bị chặn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (cboStudent.SelectedValue == null || cboCourse.SelectedValue == null ||
                string.IsNullOrEmpty(txtQT.Text.Trim()) || string.IsNullOrEmpty(txtCK.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn môn học từ bảng điểm chi tiết và nhập đầy đủ điểm số trước khi bấm Sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🛠️ SỬA LỖI TẠI ĐÂY: Đồng bộ chỉnh sửa ép kiểu int cho mssv tại hàm Fix
            int mssv = int.Parse(cboStudent.SelectedValue.ToString());
            string mamh = cboCourse.SelectedValue.ToString();

            decimal qt = Convert.ToDecimal(txtQT.Text.Trim().Replace('.', ','));
            decimal ck = Convert.ToDecimal(txtCK.Text.Trim().Replace('.', ','));
            decimal tk = Convert.ToDecimal(txtTK.Text.Trim().Replace('.', ','));

            string xepLoai = txtXepLoai.Text.Trim();
            string mota = txtMota.Text.Trim();

            Score coreScore = new Score(mssv, mamh, qt, ck, tk, xepLoai, mota);

            if (coreScore.SaveScore())
            {
                MessageBox.Show("Cập nhật thông tin điểm số sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayScoreBoard(mssv.ToString());
            }
            else
            {
                MessageBox.Show("Cập nhật điểm thất bại! Vui lòng kiểm tra lại kết nối cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboTrongSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
}