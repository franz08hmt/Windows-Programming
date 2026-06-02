namespace QuanLySinhVien
{
    partial class f_ListStudent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pctKinhLup = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cboFilterGender = new System.Windows.Forms.ComboBox();
            this.cboSortBy = new System.Windows.Forms.ComboBox();
            this.lbGioiTinh = new System.Windows.Forms.Label();
            this.lbSort = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblHethong = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDanhSach = new System.Windows.Forms.TabPage();
            this.tabImport = new System.Windows.Forms.TabPage();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnChonFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctKinhLup)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDanhSach.SuspendLayout();
            this.tabImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(41, 7);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(505, 19);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Tìm kiếm...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged_1);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(16, 183);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(2);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 62;
            this.dgvStudents.RowTemplate.Height = 28;
            this.dgvStudents.Size = new System.Drawing.Size(1112, 484);
            this.dgvStudents.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.pctKinhLup);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(17, 74);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(550, 34);
            this.pnlSearch.TabIndex = 3;
            this.pnlSearch.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSearch_Paint);
            this.pnlSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.pnlSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pctKinhLup
            // 
            this.pctKinhLup.Image = global::QuanLySinhVien.Properties.Resources.kinhlup;
            this.pctKinhLup.Location = new System.Drawing.Point(1, 1);
            this.pctKinhLup.Margin = new System.Windows.Forms.Padding(2);
            this.pctKinhLup.Name = "pctKinhLup";
            this.pctKinhLup.Size = new System.Drawing.Size(37, 32);
            this.pctKinhLup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctKinhLup.TabIndex = 1;
            this.pctKinhLup.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(2, 2);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(160, 21);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Tổng số sinh viên: 0";
            // 
            // cboFilterGender
            // 
            this.cboFilterGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterGender.FormattingEnabled = true;
            this.cboFilterGender.Items.AddRange(new object[] {
            "Tất cả",
            "Nam",
            "Nữ"});
            this.cboFilterGender.Location = new System.Drawing.Point(669, 76);
            this.cboFilterGender.Margin = new System.Windows.Forms.Padding(2);
            this.cboFilterGender.Name = "cboFilterGender";
            this.cboFilterGender.Size = new System.Drawing.Size(151, 21);
            this.cboFilterGender.TabIndex = 11;
            this.cboFilterGender.SelectedIndexChanged += new System.EventHandler(this.cboFilterGender_SelectedIndexChanged_1);
            // 
            // cboSortBy
            // 
            this.cboSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSortBy.FormattingEnabled = true;
            this.cboSortBy.Items.AddRange(new object[] {
            "Mã sinh viên",
            "Tên"});
            this.cboSortBy.Location = new System.Drawing.Point(971, 76);
            this.cboSortBy.Margin = new System.Windows.Forms.Padding(2);
            this.cboSortBy.Name = "cboSortBy";
            this.cboSortBy.Size = new System.Drawing.Size(147, 21);
            this.cboSortBy.TabIndex = 12;
            this.cboSortBy.SelectedIndexChanged += new System.EventHandler(this.cboSortBy_SelectedIndexChanged_1);
            // 
            // lbGioiTinh
            // 
            this.lbGioiTinh.AutoSize = true;
            this.lbGioiTinh.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbGioiTinh.Location = new System.Drawing.Point(590, 74);
            this.lbGioiTinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbGioiTinh.Name = "lbGioiTinh";
            this.lbGioiTinh.Size = new System.Drawing.Size(75, 21);
            this.lbGioiTinh.TabIndex = 13;
            this.lbGioiTinh.Text = "Giới tính:";
            // 
            // lbSort
            // 
            this.lbSort.AutoSize = true;
            this.lbSort.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lbSort.Location = new System.Drawing.Point(857, 73);
            this.lbSort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSort.Name = "lbSort";
            this.lbSort.Size = new System.Drawing.Size(110, 21);
            this.lbSort.TabIndex = 14;
            this.lbSort.Text = "Sắp xếp theo:";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblHethong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1141, 58);
            this.pnlHeader.TabIndex = 15;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1044, 0);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(97, 58);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ptLgo
            // 
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Margin = new System.Windows.Forms.Padding(2);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(56, 58);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabIndex = 1;
            this.ptLgo.TabStop = false;
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(57, 14);
            this.lblHethong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(284, 32);
            this.lblHethong.TabIndex = 0;
            this.lblHethong.Text = "DANH SÁCH SINH VIÊN";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnExport.Location = new System.Drawing.Point(592, 110);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(127, 39);
            this.btnExport.TabIndex = 16;
            this.btnExport.Text = "Export Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDanhSach);
            this.tabControl1.Controls.Add(this.tabImport);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.tabControl1.Location = new System.Drawing.Point(13, 142);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1117, 528);
            this.tabControl1.TabIndex = 17;
            // 
            // tabDanhSach
            // 
            this.tabDanhSach.Controls.Add(this.lblTotal);
            this.tabDanhSach.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDanhSach.Location = new System.Drawing.Point(4, 26);
            this.tabDanhSach.Margin = new System.Windows.Forms.Padding(2);
            this.tabDanhSach.Name = "tabDanhSach";
            this.tabDanhSach.Padding = new System.Windows.Forms.Padding(2);
            this.tabDanhSach.Size = new System.Drawing.Size(1109, 498);
            this.tabDanhSach.TabIndex = 0;
            this.tabDanhSach.Text = "Danh sách";
            this.tabDanhSach.UseVisualStyleBackColor = true;
            // 
            // tabImport
            // 
            this.tabImport.Controls.Add(this.btnLuu);
            this.tabImport.Controls.Add(this.lblStatus);
            this.tabImport.Controls.Add(this.dgvPreview);
            this.tabImport.Controls.Add(this.lblFilePath);
            this.tabImport.Controls.Add(this.btnChonFile);
            this.tabImport.Location = new System.Drawing.Point(4, 26);
            this.tabImport.Margin = new System.Windows.Forms.Padding(2);
            this.tabImport.Name = "tabImport";
            this.tabImport.Padding = new System.Windows.Forms.Padding(2);
            this.tabImport.Size = new System.Drawing.Size(1109, 498);
            this.tabImport.TabIndex = 1;
            this.tabImport.Text = "Import Excel";
            this.tabImport.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnLuu.Location = new System.Drawing.Point(971, 345);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(130, 43);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu vào DB";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(2, 217);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 3;
            // 
            // dgvPreview
            // 
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(6, 86);
            this.dgvPreview.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.RowHeadersWidth = 62;
            this.dgvPreview.RowTemplate.Height = 28;
            this.dgvPreview.Size = new System.Drawing.Size(1095, 255);
            this.dgvPreview.TabIndex = 2;
            this.dgvPreview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvPreview_RowPrePaint);
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(106, 8);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 17);
            this.lblFilePath.TabIndex = 1;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btnChonFile.Location = new System.Drawing.Point(3, 5);
            this.btnChonFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(127, 48);
            this.btnChonFile.TabIndex = 0;
            this.btnChonFile.Text = "Chọn file Excel";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // f_ListStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1141, 681);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lbSort);
            this.Controls.Add(this.lbGioiTinh);
            this.Controls.Add(this.cboSortBy);
            this.Controls.Add(this.cboFilterGender);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvStudents);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "f_ListStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_ListStudent";
            this.Load += new System.EventHandler(this.f_ListStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctKinhLup)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDanhSach.ResumeLayout(false);
            this.tabDanhSach.PerformLayout();
            this.tabImport.ResumeLayout(false);
            this.tabImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.PictureBox pctKinhLup;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cboFilterGender;
        private System.Windows.Forms.ComboBox cboSortBy;
        private System.Windows.Forms.Label lbGioiTinh;
        private System.Windows.Forms.Label lbSort;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDanhSach;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblStatus;
    }
}