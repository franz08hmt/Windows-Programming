using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_ManageClassroom : UserControl
    {
        private Classroom classroom = new Classroom();

        // Khai báo biến chứa logo của trường để tái sử dụng
        private Image logoUTE = null;

        public f_ManageClassroom()
        {
            InitializeComponent();
            TaiLogoTruong();
            this.Resize += (s, e) => ArrangeClassroomLayout();
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

        private void f_ManageClassroom_Load(object sender, EventArgs e)
        {
            LoadData();
            ArrangeClassroomLayout();
            dgvClassroom.CellClick += new DataGridViewCellEventHandler(this.dgvClassroom_CellClick_1);
        }

        // Hàm tự động tìm và nạp Logo từ Resources của hệ thống
        private void TaiLogoTruong()
        {
            try
            {
                System.Resources.ResourceManager rm = new System.Resources.ResourceManager("QuanLySinhVien.Properties.Resources", typeof(f_ManageClassroom).Assembly);
                logoUTE = (Image)rm.GetObject("logo");
            }
            catch
            {
                // Nếu không tìm thấy, hệ thống sẽ bỏ qua và không làm crash ứng dụng
                logoUTE = null;
            }
        }

        // Hàm nạp dữ liệu lên DataGridView
        private void LoadData()
        {
            dgvClassroom.DataSource = classroom.GetClassrooms();
            ApplyClassroomGridColumnLayout();
        }

        private void ArrangeClassroomLayout()
        {
            if (pnlInputCard == null || pnlDataCard == null || dgvClassroom == null) return;

            SuspendLayout();

            const int left = 7;
            const int top = 91;
            const int gap = 24;
            const int rightMargin = 18;
            int panelHeight = Math.Max(780, Math.Min(870, ClientSize.Height - top - 28));
            int inputWidth = Math.Min(570, Math.Max(535, ClientSize.Width / 3));

            pnlInputCard.Location = new Point(left, top);
            pnlInputCard.Size = new Size(inputWidth, panelHeight);
            guna2CustomGradientPanel1.Location = new Point(pnlInputCard.Left, pnlInputCard.Top - 4);
            guna2CustomGradientPanel1.Size = new Size(pnlInputCard.Width, 62);

            int dataLeft = pnlInputCard.Right + gap;
            int dataWidth = Math.Max(620, ClientSize.Width - dataLeft - rightMargin);
            pnlDataCard.Location = new Point(dataLeft, top - 2);
            pnlDataCard.Size = new Size(dataWidth, panelHeight + 2);
            guna2CustomGradientPanel2.Location = new Point(pnlDataCard.Left, top);
            guna2CustomGradientPanel2.Size = new Size(pnlDataCard.Width, 62);

            txtMaLop.Width = pnlInputCard.Width - 70;
            txtTenLop.Width = txtMaLop.Width;
            txtSiSo.Width = txtMaLop.Width;
            txtGVCN.Width = txtMaLop.Width;

            int buttonGap = 34;
            int buttonLeft = Math.Max(34, (pnlInputCard.Width - btnAdd.Width - btnEdit.Width - buttonGap) / 2);
            btnAdd.Left = buttonLeft;
            btnEdit.Left = btnAdd.Right + buttonGap;
            btnDelete.Left = buttonLeft;
            btnRefresh.Left = btnEdit.Left;
            btnDelete.Top = pnlInputCard.Height - btnDelete.Height - 54;
            btnRefresh.Top = btnDelete.Top;
            btnAdd.Top = btnDelete.Top - btnAdd.Height - 28;
            btnEdit.Top = btnAdd.Top;

            txtSearch.Width = Math.Max(240, pnlDataCard.Width - txtSearch.Left - btnSearch.Width - 28);
            btnSearch.Left = txtSearch.Right + 10;
            dgvClassroom.Location = new Point(pnlDataCard.Left + 17, pnlDataCard.Top + 149);
            dgvClassroom.Size = new Size(pnlDataCard.Width - 34, pnlDataCard.Height - 166);

            guna2Separator1.Width = Math.Max(600, ClientSize.Width - 24);
            guna2Separator2.Width = guna2Separator1.Width;
            guna2Separator2.Top = Math.Max(pnlInputCard.Bottom, pnlDataCard.Bottom) + 24;

            ApplyClassroomGridColumnLayout();
            ResumeLayout(false);
        }

        private void ApplyClassroomGridColumnLayout()
        {
            if (dgvClassroom == null || dgvClassroom.Columns.Count == 0) return;

            dgvClassroom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SetClassroomColumn("Mã Lớp", 90, 90);
            SetClassroomColumn("Tên Lớp", 230, 180);
            SetClassroomColumn("Sĩ Số", 70, 70);
            SetClassroomColumn("GV Chủ Nhiệm", 220, 180);
        }

        private void SetClassroomColumn(string columnName, float fillWeight, int minimumWidth)
        {
            if (!dgvClassroom.Columns.Contains(columnName)) return;

            dgvClassroom.Columns[columnName].FillWeight = fillWeight;
            dgvClassroom.Columns[columnName].MinimumWidth = minimumWidth;
        }

        // Hàm kiểm tra xem người dùng nhập đầy đủ thông tin chưa
        private bool VerifyInputs()
        {
            return !string.IsNullOrEmpty(txtMaLop.Text.Trim()) &&
                   !string.IsNullOrEmpty(txtTenLop.Text.Trim()) &&
                   !string.IsNullOrEmpty(txtGVCN.Text.Trim());
        }

        // Xóa sạch dữ liệu trên các ô nhập liệu và reset trạng thái Mã Lớp
        private void ClearFields()
        {
            txtMaLop.ReadOnly = false;
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtSiSo.Text = "0";
            txtGVCN.Clear();
        }

        // --- CÂU 2: THÊM LỚP HỌC ---
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!VerifyInputs())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            classroom.MaLop = txtMaLop.Text.Trim();
            classroom.TenLop = txtTenLop.Text.Trim();

            int siso = 0;
            int.TryParse(txtSiSo.Text, out siso);
            classroom.SiSo = siso;

            classroom.Gvcn = txtGVCN.Text.Trim();

            if (classroom.AddClassroom())
            {
                MessageBox.Show("Thêm lớp học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Lỗi: " + classroom.Exception, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CÂU 2: TÌM KIẾM THEO TÊN LỚP ---
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            My_DB db = new My_DB();
            SqlCommand command = new SqlCommand("SELECT MaLop AS [Mã Lớp], TenLop AS [Tên Lớp], SiSo AS [Sĩ Số], GVCN AS [GV Chủ Nhiệm] FROM Classroom WHERE TenLop LIKE @name", db.conn);
            command.Parameters.AddWithValue("@name", "%" + txtSearch.Text.Trim() + "%");

            dgvClassroom.DataSource = classroom.GetClassrooms(command);
        }

        // --- CÂU 3: SỬA LỚP HỌC ---
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (!VerifyInputs())
            {
                MessageBox.Show("Chọn lớp học từ danh sách hoặc nhập đủ thông tin để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            classroom.MaLop = txtMaLop.Text.Trim();
            classroom.TenLop = txtTenLop.Text.Trim();

            int siso = 0;
            int.TryParse(txtSiSo.Text, out siso);
            classroom.SiSo = siso;

            classroom.Gvcn = txtGVCN.Text.Trim();

            if (classroom.UpdateClassroom())
            {
                MessageBox.Show("Cập nhật thông tin lớp học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật: " + classroom.Exception, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CÂU 3: XÓA LỚP HỌC ---
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string id = txtMaLop.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã Lớp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa lớp học [{id}] không?", "Xác nhận xóa",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (classroom.DeleteClassroom(id))
                {
                    MessageBox.Show("Xóa lớp học thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa: " + classroom.Exception, "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvClassroom_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvClassroom.Rows.Count)
            {
                DataGridViewRow row = dgvClassroom.Rows[e.RowIndex];

                txtMaLop.Text = row.Cells[0].Value?.ToString().Trim() ?? "";
                txtTenLop.Text = row.Cells[1].Value?.ToString().Trim() ?? "";
                txtSiSo.Text = row.Cells[2].Value?.ToString().Trim() ?? "0";
                txtGVCN.Text = row.Cells[3].Value?.ToString().Trim() ?? "";

                txtMaLop.ReadOnly = true;
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadData();
            ClearFields();
            txtSearch.Clear();
        }


        private void VePanelCardHienDai(Panel pnl, PaintEventArgs e, Color headerColor, string headerText)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Chống răng cưa góc bo mượt mà

            int radius = 16;       // Độ bo tròn của góc khung
            int headerHeight = 35; // Chiều cao dải màu tiêu đề

            // 1. Vẽ khung nền trắng phẳng mịn cho toàn bộ Panel Card
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                path.AddArc(new Rectangle(pnl.Width - radius - 1, 0, radius, radius), 270, 90);
                path.AddArc(new Rectangle(pnl.Width - radius - 1, pnl.Height - radius - 1, radius, radius), 0, 90);
                path.AddArc(new Rectangle(0, pnl.Height - radius - 1, radius, radius), 90, 90);
                path.CloseFigure();

                using (SolidBrush bgBrush = new SolidBrush(Color.White))
                {
                    g.FillPath(bgBrush, path);
                }
                pnl.Region = new Region(path); // Giới hạn vùng chứa để các control con không tràn góc bo
            }

            // 2. Vẽ dải màu phẳng Header thương hiệu phía trên cùng
            using (GraphicsPath headerPath = new GraphicsPath())
            {
                headerPath.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                headerPath.AddArc(new Rectangle(pnl.Width - radius - 1, 0, radius, radius), 270, 90);
                headerPath.AddLine(pnl.Width - 1, headerHeight, 0, headerHeight);
                headerPath.CloseFigure();

                using (SolidBrush headerBrush = new SolidBrush(headerColor))
                {
                    g.FillPath(headerBrush, headerPath);
                }
            }

            // 3. Xử lý căn chỉnh vị trí vẽ LOGO UTE và Tiêu đề chữ trắng
            int textXStart = 15; // Lề bắt đầu chữ mặc định nếu không có logo

            if (logoUTE != null)
            {
                int logoSize = 24; // Kích cỡ hình vuông thu nhỏ của logo trên thanh tiêu đề
                int logoX = 12;
                int logoY = (headerHeight - logoSize) / 2; // Căn giữa logo theo trục dọc thanh

                // Tiến hành vẽ trực tiếp Logo trường lên thanh tiêu đề phẳng
                g.DrawImage(logoUTE, new Rectangle(logoX, logoY, logoSize, logoSize));
                textXStart = logoX + logoSize + 8; // Đẩy chữ tiêu đề dịch sang phải để tránh đè đè lên logo
            }

            // Vẽ văn bản tiêu đề (Chữ trắng nổi bật trên nền xanh)
            if (!string.IsNullOrEmpty(headerText))
            {
                using (Font font = new Font("Segoe UI", 10, FontStyle.Bold))
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Near,
                        LineAlignment = StringAlignment.Center
                    };
                    g.DrawString(headerText, font, textBrush, new RectangleF(textXStart, 0, pnl.Width - textXStart, headerHeight), sf);
                }
            }

            // 4. Vẽ một đường viền mảnh tinh tế tạo chiều sâu cho Card phẳng
            using (GraphicsPath borderPath = new GraphicsPath())
            {
                borderPath.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
                borderPath.AddArc(new Rectangle(pnl.Width - radius - 1, 0, radius, radius), 270, 90);
                borderPath.AddArc(new Rectangle(pnl.Width - radius - 1, pnl.Height - radius - 1, radius, radius), 0, 90);
                borderPath.AddArc(new Rectangle(0, pnl.Height - radius - 1, radius, radius), 90, 90);
                borderPath.CloseFigure();

                using (Pen pen = new Pen(Color.FromArgb(232, 232, 232), 1))
                {
                    g.DrawPath(pen, borderPath);
                }
            }
        }

        private void pnlInputCard_Paint(object sender, PaintEventArgs e)
        {
            VePanelCardHienDai(sender as Panel, e, Color.FromArgb(0, 82, 166), "THÔNG TIN LỚP HỌC");
        }

        private void pnlDataCard_Paint(object sender, PaintEventArgs e)
        {
            VePanelCardHienDai(sender as Panel, e, Color.FromArgb(0, 82, 166), "DANH SÁCH LỚP HỌC");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
        }

        private void pnlInputCard_Paint_1(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlInputCard, 25, e);
        }

        private void lblInputTitle_Click(object sender, EventArgs e)
        {

        }

        private void pnlDataCard_Paint_1(object sender, PaintEventArgs e)
        {
            VeBoGocPanel(pnlDataCard, 25, e);
        }

    }
}
