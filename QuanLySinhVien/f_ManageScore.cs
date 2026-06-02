using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
                cmd.Parameters.AddWithValue("@mssv", Convert.ToInt32(mssv));
                new SqlDataAdapter(cmd).Fill(dt);
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
                ClearInputFields();

            decimal gpa = Score.CalculateGPA(mssv);
            lblGPA.Text = $"ĐIỂM GPA TÍCH LŨY: {gpa:F2} / 4.0";

            string xepLoai; Color mau;
            if (gpa >= 3.60m) { xepLoai = "Xuất sắc"; mau = Color.Purple; }
            else if (gpa >= 3.20m) { xepLoai = "Giỏi"; mau = Color.DarkGreen; }
            else if (gpa >= 2.50m) { xepLoai = "Khá"; mau = Color.Blue; }
            else if (gpa >= 2.00m) { xepLoai = "Trung bình"; mau = Color.DarkOrange; }
            else { xepLoai = "Yếu / Kém"; mau = Color.Red; }

            if (lblXepLoai != null)
            {
                lblXepLoai.Text = $"XẾP LOẠI HỌC LỰC: {xepLoai}";
                lblXepLoai.ForeColor = mau;
            }
        }

        private void CalculateTotal()
        {
            string cleanQT = txtQT.Text.Trim();
            string cleanCK = txtCK.Text.Trim();

            if (string.IsNullOrEmpty(cleanQT) || string.IsNullOrEmpty(cleanCK))
            {
                txtTK.Clear(); txtXepLoai.Clear(); return;
            }

            if (decimal.TryParse(cleanQT, out decimal qt) && decimal.TryParse(cleanCK, out decimal ck))
            {
                if (qt < 0 || qt > 10 || ck < 0 || ck > 10)
                {
                    txtTK.Clear(); txtXepLoai.Clear(); return;
                }

                decimal tk = Score.TinhDiemTK(qt, ck); // 40% QT + 60% CK
                txtTK.Text = tk.ToString("F2");
                txtXepLoai.Text = Score.XepLoaiTheoTK(tk);
            }
            else
            {
                txtTK.Clear(); txtXepLoai.Clear();
            }
        }

        private void RegisterRealTimeValidation()
        {
            txtQT.TextChanged += (s, e) => {
                string text = txtQT.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (!decimal.TryParse(text, out decimal val))
                        erpScore.SetError(txtQT, "Điểm không hợp lệ!");
                    else if (val < 0 || val > 10)
                        erpScore.SetError(txtQT, "Điểm phải từ 0 đến 10!");
                    else
                        erpScore.SetError(txtQT, "");
                }
                else erpScore.SetError(txtQT, "");
                CalculateTotal();
            };

            txtCK.TextChanged += (s, e) => {
                string text = txtCK.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (!decimal.TryParse(text, out decimal val))
                        erpScore.SetError(txtCK, "Điểm không hợp lệ!");
                    else if (val < 0 || val > 10)
                        erpScore.SetError(txtCK, "Điểm phải từ 0 đến 10!");
                    else
                        erpScore.SetError(txtCK, "");
                }
                else erpScore.SetError(txtCK, "");
                CalculateTotal();
            };
        }

        private void ClearInputFields()
        {
            txtQT.Clear(); txtCK.Clear();
            txtTK.Clear(); txtXepLoai.Clear();
            txtMota.Clear();
            erpScore?.Clear();
        }

        // ── Events ──────────────────────────────────────

        private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue != null &&
                cboStudent.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                string mssv = cboStudent.SelectedValue.ToString();
                LoadCoursesRegisteredByStudent(mssv);
                DisplayScoreBoard(mssv);
                ClearInputFields();
            }
        }

        private void dgvScores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvScores.Rows.Count - 1) return;

            DataGridViewRow row = dgvScores.Rows[e.RowIndex];

            // Chọn môn học tương ứng trong ComboBox
            if (row.Cells[0].Value != null)
                cboCourse.SelectedValue = row.Cells[0].Value.ToString();

            // Điền điểm vào form (cột: MãMôn, TênMôn, SoTC, DiemQT, DiemCK, DiemTK, XepLoai, GhiChu)
            txtQT.Text = row.Cells[3].Value?.ToString() ?? "";
            txtCK.Text = row.Cells[4].Value?.ToString() ?? "";
            txtTK.Text = row.Cells[5].Value?.ToString() ?? "";
            txtXepLoai.Text = row.Cells[6].Value?.ToString() ?? "";
            txtMota.Text = row.Cells[7].Value?.ToString() ?? "";

            erpScore?.Clear();
        }

        private void btnSaveScore_Click(object sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || cboCourse.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Sinh viên và Môn học!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtQT.Text.Trim(), out decimal qt) ||
                !decimal.TryParse(txtCK.Text.Trim(), out decimal ck))
            {
                MessageBox.Show("Điểm QT và CK phải là số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qt < 0 || qt > 10 || ck < 0 || ck > 10)
            {
                MessageBox.Show("Điểm phải từ 0 đến 10!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tk = Score.TinhDiemTK(qt, ck);
            string xepLoai = Score.XepLoaiTheoTK(tk);
            int mssv = Convert.ToInt32(cboStudent.SelectedValue);
            string mamh = cboCourse.SelectedValue.ToString();

            Score s = new Score(mssv, mamh, qt, ck, tk, xepLoai, txtMota.Text.Trim());

            if (s.SaveScore())
            {
                MessageBox.Show("Lưu điểm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayScoreBoard(mssv.ToString());
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Lưu điểm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            // Dùng chung logic với btnSaveScore (SaveScore đã xử lý UPDATE nếu tồn tại)
            btnSaveScore_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            if (cboStudent.SelectedValue != null)
                DisplayScoreBoard(cboStudent.SelectedValue.ToString());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            f_HomePage homeForm = new f_HomePage(Globals.GlobalUserName);
            homeForm.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) => VeBoGocPanel(panel1, 25, e);
        private void panel2_Paint(object sender, PaintEventArgs e) => VeBoGocPanel(panel2, 25, e);
        private void panel3_Paint(object sender, PaintEventArgs e) => VeBoGocPanel(panel3, 25, e);
        private void txtQT_TextChanged(object sender, EventArgs e) { }
        private void txtCK_TextChanged(object sender, EventArgs e) { }
    }
}