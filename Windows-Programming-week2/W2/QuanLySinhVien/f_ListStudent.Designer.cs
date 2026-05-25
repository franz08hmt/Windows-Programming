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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.pctKinhLup = new System.Windows.Forms.PictureBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cboFilterGender = new System.Windows.Forms.ComboBox();
            this.cboSortBy = new System.Windows.Forms.ComboBox();
            this.lbGioiTinh = new System.Windows.Forms.Label();
            this.lbSort = new System.Windows.Forms.Label();
            this.lbListStudent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctKinhLup)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(35, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 19);
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
            this.dgvStudents.Location = new System.Drawing.Point(12, 136);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 62;
            this.dgvStudents.RowTemplate.Height = 28;
            this.dgvStudents.Size = new System.Drawing.Size(954, 418);
            this.dgvStudents.TabIndex = 1;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.pctKinhLup);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Location = new System.Drawing.Point(592, 85);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(374, 31);
            this.pnlSearch.TabIndex = 3;
            // 
            // pctKinhLup
            // 
            this.pctKinhLup.Image = global::QuanLySinhVien.Properties.Resources.kinhlup;
            this.pctKinhLup.Location = new System.Drawing.Point(2, 1);
            this.pctKinhLup.Name = "pctKinhLup";
            this.pctKinhLup.Size = new System.Drawing.Size(30, 25);
            this.pctKinhLup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctKinhLup.TabIndex = 1;
            this.pctKinhLup.TabStop = false;
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btDelete.Font = new System.Drawing.Font("Segoe UI Black", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btDelete.Location = new System.Drawing.Point(157, 22);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(139, 50);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "Xóa";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btAdd
            // 
            this.btAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.btAdd.Font = new System.Drawing.Font("Segoe UI Black", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btAdd.Location = new System.Drawing.Point(12, 22);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(139, 50);
            this.btAdd.TabIndex = 5;
            this.btAdd.Text = "Thêm";
            this.btAdd.UseVisualStyleBackColor = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUpdate.Location = new System.Drawing.Point(302, 22);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(139, 50);
            this.btUpdate.TabIndex = 6;
            this.btUpdate.Text = "Sửa";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRefresh.Location = new System.Drawing.Point(447, 22);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(139, 50);
            this.btRefresh.TabIndex = 7;
            this.btRefresh.Text = "Làm mới";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(7, 557);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(201, 28);
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
            this.cboFilterGender.Location = new System.Drawing.Point(114, 88);
            this.cboFilterGender.Name = "cboFilterGender";
            this.cboFilterGender.Size = new System.Drawing.Size(179, 28);
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
            this.cboSortBy.Location = new System.Drawing.Point(438, 88);
            this.cboSortBy.Name = "cboSortBy";
            this.cboSortBy.Size = new System.Drawing.Size(148, 28);
            this.cboSortBy.TabIndex = 12;
            this.cboSortBy.SelectedIndexChanged += new System.EventHandler(this.cboSortBy_SelectedIndexChanged_1);
            // 
            // lbGioiTinh
            // 
            this.lbGioiTinh.AutoSize = true;
            this.lbGioiTinh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGioiTinh.Location = new System.Drawing.Point(12, 87);
            this.lbGioiTinh.Name = "lbGioiTinh";
            this.lbGioiTinh.Size = new System.Drawing.Size(95, 28);
            this.lbGioiTinh.TabIndex = 13;
            this.lbGioiTinh.Text = "Giới tính:";
            // 
            // lbSort
            // 
            this.lbSort.AutoSize = true;
            this.lbSort.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lbSort.Location = new System.Drawing.Point(298, 84);
            this.lbSort.Name = "lbSort";
            this.lbSort.Size = new System.Drawing.Size(137, 28);
            this.lbSort.TabIndex = 14;
            this.lbSort.Text = "Sắp xếp theo:";
            // 
            // lbListStudent
            // 
            this.lbListStudent.AutoSize = true;
            this.lbListStudent.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListStudent.Location = new System.Drawing.Point(587, 23);
            this.lbListStudent.Name = "lbListStudent";
            this.lbListStudent.Size = new System.Drawing.Size(381, 45);
            this.lbListStudent.TabIndex = 15;
            this.lbListStudent.Text = "DANH SÁCH SINH VIÊN";
            // 
            // f_ListStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.lbListStudent);
            this.Controls.Add(this.lbSort);
            this.Controls.Add(this.lbGioiTinh);
            this.Controls.Add(this.cboSortBy);
            this.Controls.Add(this.cboFilterGender);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.dgvStudents);
            this.Name = "f_ListStudent";
            this.Text = "f_ListStudent";
            this.Load += new System.EventHandler(this.f_ListStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctKinhLup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.PictureBox pctKinhLup;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cboFilterGender;
        private System.Windows.Forms.ComboBox cboSortBy;
        private System.Windows.Forms.Label lbGioiTinh;
        private System.Windows.Forms.Label lbSort;
        private System.Windows.Forms.Label lbListStudent;
        private System.Windows.Forms.Button btUpdate;
    }
}