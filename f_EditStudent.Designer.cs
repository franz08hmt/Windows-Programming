namespace QuanLySinhVien
{
    partial class f_EditStudent
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblHethong = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFix = new System.Windows.Forms.Button();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.erpEdit = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblHethong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1141, 58);
            this.pnlHeader.TabIndex = 16;
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
            this.btnBack.Location = new System.Drawing.Point(1045, 0);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(96, 58);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ptLgo
            // 
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.lblHethong.Location = new System.Drawing.Point(60, 13);
            this.lblHethong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(253, 32);
            this.lblHethong.TabIndex = 0;
            this.lblHethong.Text = "SỬA/XÓA SINH VIÊN";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.btnChooseImage);
            this.panel1.Controls.Add(this.picStudent);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtLname);
            this.panel1.Controls.Add(this.dtpDob);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboGender);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnFix);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMSSV);
            this.panel1.Controls.Add(this.txtFname);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(572, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 604);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseImage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseImage.Location = new System.Drawing.Point(389, 226);
            this.btnChooseImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(132, 47);
            this.btnChooseImage.TabIndex = 20;
            this.btnChooseImage.Text = "📷 Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = true;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // picStudent
            // 
            this.picStudent.BackColor = System.Drawing.Color.White;
            this.picStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStudent.Location = new System.Drawing.Point(376, 22);
            this.picStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(154, 190);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStudent.TabIndex = 19;
            this.picStudent.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.Location = new System.Drawing.Point(400, 408);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(111, 42);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDelete.Location = new System.Drawing.Point(400, 346);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 47);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(22, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên (First Name)";
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(26, 172);
            this.txtLname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLname.Multiline = true;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(315, 26);
            this.txtLname.TabIndex = 9;
            // 
            // dtpDob
            // 
            this.dtpDob.Location = new System.Drawing.Point(25, 298);
            this.dtpDob.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(185, 20);
            this.dtpDob.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(22, 275);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày sinh (Date of Birth)";
            // 
            // cboGender
            // 
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGender.Location = new System.Drawing.Point(26, 242);
            this.cboGender.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(134, 21);
            this.cboGender.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(25, 418);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(315, 26);
            this.txtEmail.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(21, 215);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giới tính (Gender)";
            // 
            // btnFix
            // 
            this.btnFix.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnFix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFix.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnFix.ForeColor = System.Drawing.Color.White;
            this.btnFix.Location = new System.Drawing.Point(400, 285);
            this.btnFix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(111, 47);
            this.btnFix.TabIndex = 16;
            this.btnFix.Text = "Sửa";
            this.btnFix.UseVisualStyleBackColor = false;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(26, 362);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(315, 26);
            this.txtPhone.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(23, 395);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số sinh viên (Student ID)";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(25, 45);
            this.txtMSSV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMSSV.Multiline = true;
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(316, 26);
            this.txtMSSV.TabIndex = 7;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(25, 108);
            this.txtFname.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFname.Multiline = true;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(316, 26);
            this.txtFname.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(22, 339);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(21, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ (Last Name)";
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(8, 66);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.RowHeadersWidth = 62;
            this.dgvStudents.RowTemplate.Height = 28;
            this.dgvStudents.Size = new System.Drawing.Size(535, 604);
            this.dgvStudents.TabIndex = 21;
            this.dgvStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellClick);
            // 
            // erpEdit
            // 
            this.erpEdit.ContainerControl = this;
            // 
            // f_EditStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 681);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "f_EditStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_EditStudent";
            this.Load += new System.EventHandler(this.f_EditStudent_Load_1);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.ErrorProvider erpEdit;
    }
}