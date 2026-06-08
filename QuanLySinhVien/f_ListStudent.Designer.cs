namespace QuanLySinhVien
{
    partial class f_ListStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblHethong = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pctKinhLup = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbGioiTinh = new System.Windows.Forms.Label();
            this.cboFilterGender = new System.Windows.Forms.ComboBox();
            this.lbSort = new System.Windows.Forms.Label();
            this.cboSortBy = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDanhSach = new System.Windows.Forms.TabPage();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.tabImport = new System.Windows.Forms.TabPage();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.pnlToolbar.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctKinhLup)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.tabImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ──
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblHethong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 90);
            this.pnlHeader.TabIndex = 0;

            this.btnBack.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(15, 50, 105);
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 85, 155);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(963, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 90);
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(84, 90);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabStop = false;

            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(90, 22);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Text = "DANH SÁCH SINH VIÊN";

            // ── pnlToolbar ──
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.Controls.Add(this.pnlSearch);
            this.pnlToolbar.Controls.Add(this.lbGioiTinh);
            this.pnlToolbar.Controls.Add(this.cboFilterGender);
            this.pnlToolbar.Controls.Add(this.lbSort);
            this.pnlToolbar.Controls.Add(this.cboSortBy);
            this.pnlToolbar.Controls.Add(this.btnExport);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 90);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1100, 60);
            this.pnlToolbar.TabIndex = 1;

            // pnlSearch
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.pctKinhLup);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(15, 12);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(260, 36);
            this.pnlSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.pnlSearch.Leave += new System.EventHandler(this.txtSearch_Leave);

            this.pctKinhLup.Image = global::QuanLySinhVien.Properties.Resources.kinhlup;
            this.pctKinhLup.Location = new System.Drawing.Point(4, 4);
            this.pctKinhLup.Name = "pctKinhLup";
            this.pctKinhLup.Size = new System.Drawing.Size(26, 26);
            this.pctKinhLup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctKinhLup.TabStop = false;

            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(35, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(218, 22);
            this.txtSearch.Text = "Tìm kiếm...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);

            // lbGioiTinh
            this.lbGioiTinh.AutoSize = true;
            this.lbGioiTinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbGioiTinh.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.lbGioiTinh.Location = new System.Drawing.Point(290, 20);
            this.lbGioiTinh.Name = "lbGioiTinh";
            this.lbGioiTinh.Text = "Giới tính:";

            this.cboFilterGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFilterGender.Items.AddRange(new object[] { "Tất cả", "Nam", "Nữ" });
            this.cboFilterGender.Location = new System.Drawing.Point(365, 16);
            this.cboFilterGender.Name = "cboFilterGender";
            this.cboFilterGender.Size = new System.Drawing.Size(130, 28);
            this.cboFilterGender.SelectedIndexChanged += new System.EventHandler(this.cboFilterGender_SelectedIndexChanged_1);

            // lbSort
            this.lbSort.AutoSize = true;
            this.lbSort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbSort.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.lbSort.Location = new System.Drawing.Point(510, 20);
            this.lbSort.Name = "lbSort";
            this.lbSort.Text = "Sắp xếp:";

            this.cboSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortBy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSortBy.Items.AddRange(new object[] { "Mã sinh viên", "Tên" });
            this.cboSortBy.Location = new System.Drawing.Point(580, 16);
            this.cboSortBy.Name = "cboSortBy";
            this.cboSortBy.Size = new System.Drawing.Size(150, 28);
            this.cboSortBy.SelectedIndexChanged += new System.EventHandler(this.cboSortBy_SelectedIndexChanged_1);

            // btnExport
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(950, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(135, 36);
            this.btnExport.Text = "📤 Export Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);

            // ── tabControl1 ──
            this.tabControl1.Controls.Add(this.tabDanhSach);
            this.tabControl1.Controls.Add(this.tabImport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 150);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.TabIndex = 2;

            // tabDanhSach
            this.tabDanhSach.BackColor = System.Drawing.Color.White;
            this.tabDanhSach.Controls.Add(this.dgvStudents);
            this.tabDanhSach.Controls.Add(this.lblTotal);
            this.tabDanhSach.Name = "tabDanhSach";
            this.tabDanhSach.Padding = new System.Windows.Forms.Padding(5);
            this.tabDanhSach.Text = "  Danh sách  ";

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.lblTotal.Location = new System.Drawing.Point(8, 8);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Text = "Tổng số sinh viên: 0";

            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStudents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvStudents.ColumnHeadersHeight = 38;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 244, 255);
            this.dgvStudents.Location = new System.Drawing.Point(5, 38);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowTemplate.Height = 60;
            this.dgvStudents.Size = new System.Drawing.Size(1080, 400);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));

            // tabImport
            this.tabImport.BackColor = System.Drawing.Color.White;
            this.tabImport.Controls.Add(this.btnChonFile);
            this.tabImport.Controls.Add(this.lblFilePath);
            this.tabImport.Controls.Add(this.dgvPreview);
            this.tabImport.Controls.Add(this.lblStatus);
            this.tabImport.Controls.Add(this.btnLuu);
            this.tabImport.Name = "tabImport";
            this.tabImport.Padding = new System.Windows.Forms.Padding(5);
            this.tabImport.Text = "  Import Excel  ";

            this.btnChonFile.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnChonFile.FlatAppearance.BorderSize = 0;
            this.btnChonFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChonFile.ForeColor = System.Drawing.Color.White;
            this.btnChonFile.Location = new System.Drawing.Point(8, 8);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(160, 36);
            this.btnChonFile.Text = "📂 Chọn file Excel";
            this.btnChonFile.UseVisualStyleBackColor = false;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);

            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblFilePath.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.lblFilePath.Location = new System.Drawing.Point(180, 16);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Text = "";

            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.BackgroundColor = System.Drawing.Color.White;
            this.dgvPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPreview.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.dgvPreview.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPreview.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvPreview.ColumnHeadersHeight = 38;
            this.dgvPreview.EnableHeadersVisualStyles = false;
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.Location = new System.Drawing.Point(5, 52);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.RowTemplate.Height = 28;
            this.dgvPreview.Size = new System.Drawing.Size(1080, 350);
            this.dgvPreview.TabIndex = 1;
            this.dgvPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.dgvPreview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPreview_RowPrePaint);
            this.dgvPreview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPreview_CellContentClick);

            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.Location = new System.Drawing.Point(8, 410);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "";

            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.btnLuu.FlatAppearance.BorderSize = 0;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(920, 405);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 36);
            this.btnLuu.Text = "💾 Lưu vào DB";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Right));
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // ── f_ListStudent ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "f_ListStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên";
            this.Load += new System.EventHandler(this.f_ListStudent_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctKinhLup)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDanhSach.ResumeLayout(false);
            this.tabDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.tabImport.ResumeLayout(false);
            this.tabImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.PictureBox pctKinhLup;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbGioiTinh;
        private System.Windows.Forms.ComboBox cboFilterGender;
        private System.Windows.Forms.Label lbSort;
        private System.Windows.Forms.ComboBox cboSortBy;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDanhSach;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}