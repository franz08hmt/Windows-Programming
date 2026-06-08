namespace QuanLySinhVien
{
    partial class f_ManageClassroom
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInputCard = new System.Windows.Forms.Panel();
            this.pnlInputHeader = new System.Windows.Forms.Panel();
            this.lblInputTitle = new System.Windows.Forms.Label();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.lblSiSo = new System.Windows.Forms.Label();
            this.txtSiSo = new System.Windows.Forms.TextBox();
            this.lblGVCN = new System.Windows.Forms.Label();
            this.txtGVCN = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlDataCard = new System.Windows.Forms.Panel();
            this.pnlDataHeader = new System.Windows.Forms.Panel();
            this.lblDataTitle = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvClassroom = new System.Windows.Forms.DataGridView();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlInputCard.SuspendLayout();
            this.pnlInputHeader.SuspendLayout();
            this.pnlDataCard.SuspendLayout();
            this.pnlDataHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassroom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.lblTitle.Location = new System.Drawing.Point(34, 31);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(339, 48);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ LỚP HỌC";
            // 
            // pnlInputCard
            // 
            this.pnlInputCard.BackColor = System.Drawing.Color.White;
            this.pnlInputCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInputCard.Controls.Add(this.pnlInputHeader);
            this.pnlInputCard.Controls.Add(this.lblMaLop);
            this.pnlInputCard.Controls.Add(this.txtMaLop);
            this.pnlInputCard.Controls.Add(this.lblTenLop);
            this.pnlInputCard.Controls.Add(this.txtTenLop);
            this.pnlInputCard.Controls.Add(this.lblSiSo);
            this.pnlInputCard.Controls.Add(this.txtSiSo);
            this.pnlInputCard.Controls.Add(this.lblGVCN);
            this.pnlInputCard.Controls.Add(this.txtGVCN);
            this.pnlInputCard.Controls.Add(this.btnAdd);
            this.pnlInputCard.Controls.Add(this.btnEdit);
            this.pnlInputCard.Controls.Add(this.btnDelete);
            this.pnlInputCard.Controls.Add(this.btnRefresh);
            this.pnlInputCard.Location = new System.Drawing.Point(44, 115);
            this.pnlInputCard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlInputCard.Name = "pnlInputCard";
            this.pnlInputCard.Size = new System.Drawing.Size(479, 799);
            this.pnlInputCard.TabIndex = 1;
            // 
            // pnlInputHeader
            // 
            this.pnlInputHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(166)))));
            this.pnlInputHeader.Controls.Add(this.ptLgo);
            this.pnlInputHeader.Controls.Add(this.lblInputTitle);
            this.pnlInputHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlInputHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlInputHeader.Name = "pnlInputHeader";
            this.pnlInputHeader.Size = new System.Drawing.Size(477, 58);
            this.pnlInputHeader.TabIndex = 12;
            // 
            // lblInputTitle
            // 
            this.lblInputTitle.AutoSize = true;
            this.lblInputTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInputTitle.ForeColor = System.Drawing.Color.White;
            this.lblInputTitle.Location = new System.Drawing.Point(60, 15);
            this.lblInputTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputTitle.Name = "lblInputTitle";
            this.lblInputTitle.Size = new System.Drawing.Size(216, 28);
            this.lblInputTitle.TabIndex = 0;
            this.lblInputTitle.Text = "THÔNG TIN LỚP HỌC";
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblMaLop.Location = new System.Drawing.Point(32, 92);
            this.lblMaLop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(88, 28);
            this.lblMaLop.TabIndex = 0;
            this.lblMaLop.Text = "Mã Lớp:";
            // 
            // txtMaLop
            // 
            this.txtMaLop.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMaLop.Location = new System.Drawing.Point(36, 128);
            this.txtMaLop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(406, 37);
            this.txtMaLop.TabIndex = 1;
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTenLop.Location = new System.Drawing.Point(32, 200);
            this.lblTenLop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(91, 28);
            this.lblTenLop.TabIndex = 2;
            this.lblTenLop.Text = "Tên Lớp:";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTenLop.Location = new System.Drawing.Point(36, 235);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(406, 37);
            this.txtTenLop.TabIndex = 3;
            // 
            // lblSiSo
            // 
            this.lblSiSo.AutoSize = true;
            this.lblSiSo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSiSo.Location = new System.Drawing.Point(32, 308);
            this.lblSiSo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSiSo.Name = "lblSiSo";
            this.lblSiSo.Size = new System.Drawing.Size(63, 28);
            this.lblSiSo.TabIndex = 4;
            this.lblSiSo.Text = "Sĩ Số:";
            // 
            // txtSiSo
            // 
            this.txtSiSo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSiSo.Location = new System.Drawing.Point(36, 343);
            this.txtSiSo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSiSo.Name = "txtSiSo";
            this.txtSiSo.Size = new System.Drawing.Size(406, 37);
            this.txtSiSo.TabIndex = 5;
            this.txtSiSo.Text = "0";
            // 
            // lblGVCN
            // 
            this.lblGVCN.AutoSize = true;
            this.lblGVCN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGVCN.Location = new System.Drawing.Point(32, 415);
            this.lblGVCN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGVCN.Name = "lblGVCN";
            this.lblGVCN.Size = new System.Drawing.Size(155, 28);
            this.lblGVCN.TabIndex = 6;
            this.lblGVCN.Text = "GV Chủ Nhiệm:";
            // 
            // txtGVCN
            // 
            this.txtGVCN.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtGVCN.Location = new System.Drawing.Point(36, 451);
            this.txtGVCN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGVCN.Name = "txtGVCN";
            this.txtGVCN.Size = new System.Drawing.Size(406, 37);
            this.txtGVCN.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(36, 554);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(188, 62);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm Mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(256, 554);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(188, 62);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Cập Nhật";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(36, 646);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(188, 62);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Xóa Lớp";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Gray;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(256, 646);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(188, 62);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlDataCard
            // 
            this.pnlDataCard.BackColor = System.Drawing.Color.White;
            this.pnlDataCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDataCard.Controls.Add(this.pnlDataHeader);
            this.pnlDataCard.Controls.Add(this.lblSearch);
            this.pnlDataCard.Controls.Add(this.txtSearch);
            this.pnlDataCard.Controls.Add(this.btnSearch);
            this.pnlDataCard.Controls.Add(this.dgvClassroom);
            this.pnlDataCard.Location = new System.Drawing.Point(562, 115);
            this.pnlDataCard.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDataCard.Name = "pnlDataCard";
            this.pnlDataCard.Size = new System.Drawing.Size(802, 799);
            this.pnlDataCard.TabIndex = 2;
            // 
            // pnlDataHeader
            // 
            this.pnlDataHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(166)))));
            this.pnlDataHeader.Controls.Add(this.pictureBox1);
            this.pnlDataHeader.Controls.Add(this.lblDataTitle);
            this.pnlDataHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDataHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDataHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDataHeader.Name = "pnlDataHeader";
            this.pnlDataHeader.Size = new System.Drawing.Size(800, 58);
            this.pnlDataHeader.TabIndex = 4;
            // 
            // lblDataTitle
            // 
            this.lblDataTitle.AutoSize = true;
            this.lblDataTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDataTitle.ForeColor = System.Drawing.Color.White;
            this.lblDataTitle.Location = new System.Drawing.Point(60, 15);
            this.lblDataTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataTitle.Name = "lblDataTitle";
            this.lblDataTitle.Size = new System.Drawing.Size(222, 28);
            this.lblDataTitle.TabIndex = 0;
            this.lblDataTitle.Text = "DANH SÁCH LỚP HỌC";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(30, 97);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(182, 28);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm theo Tên Lớp:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(219, 89);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(358, 37);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(592, 86);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(172, 46);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvClassroom
            // 
            this.dgvClassroom.AllowUserToAddRows = false;
            this.dgvClassroom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassroom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.dgvClassroom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClassroom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassroom.Location = new System.Drawing.Point(34, 162);
            this.dgvClassroom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvClassroom.Name = "dgvClassroom";
            this.dgvClassroom.ReadOnly = true;
            this.dgvClassroom.RowHeadersVisible = false;
            this.dgvClassroom.RowHeadersWidth = 62;
            this.dgvClassroom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClassroom.Size = new System.Drawing.Size(730, 600);
            this.dgvClassroom.TabIndex = 3;
            this.dgvClassroom.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClassroom_CellClick);
            // 
            // ptLgo
            // 
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(-3, -1);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(66, 59);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabIndex = 2;
            this.ptLgo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // f_ManageClassroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1416, 955);
            this.Controls.Add(this.pnlDataCard);
            this.Controls.Add(this.pnlInputCard);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "f_ManageClassroom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Lớp học";
            this.Load += new System.EventHandler(this.f_ManageClassroom_Load);
            this.pnlInputCard.ResumeLayout(false);
            this.pnlInputCard.PerformLayout();
            this.pnlInputHeader.ResumeLayout(false);
            this.pnlInputHeader.PerformLayout();
            this.pnlDataCard.ResumeLayout(false);
            this.pnlDataCard.PerformLayout();
            this.pnlDataHeader.ResumeLayout(false);
            this.pnlDataHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassroom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlInputCard;
        private System.Windows.Forms.Panel pnlInputHeader;
        private System.Windows.Forms.Label lblInputTitle;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtSiSo;
        private System.Windows.Forms.TextBox txtGVCN;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.Label lblTenLop;
        private System.Windows.Forms.Label lblSiSo;
        private System.Windows.Forms.Label lblGVCN;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlDataCard;
        private System.Windows.Forms.Panel pnlDataHeader;
        private System.Windows.Forms.Label lblDataTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvClassroom;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}