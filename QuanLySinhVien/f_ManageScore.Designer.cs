namespace QuanLySinhVien
{
    partial class f_ManageScore
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblHethong = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCK = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtXepLoai = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.lblWeight = new System.Windows.Forms.Label();
            this.nudQTWeight = new System.Windows.Forms.NumericUpDown();
            this.lblWeightCK = new System.Windows.Forms.Label();
            this.nudCKWeight = new System.Windows.Forms.NumericUpDown();
            this.btnSaveScore = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvScores = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblGPA = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.btnOCRScore = new System.Windows.Forms.Button();
            this.erpScore = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQTWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCKWeight)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScores)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpScore)).BeginInit();
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
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(963, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 90);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ptLgo
            // 
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(84, 90);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabIndex = 1;
            this.ptLgo.TabStop = false;
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(90, 22);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(463, 45);
            this.lblHethong.TabIndex = 2;
            this.lblHethong.Text = "QUẢN LÝ ĐIỂM - NHẬP ĐIỂM";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboStudent);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboCourse);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtQT);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCK);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTK);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtXepLoai);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtMota);
            this.panel1.Controls.Add(this.lblWeight);
            this.panel1.Controls.Add(this.nudQTWeight);
            this.panel1.Controls.Add(this.lblWeightCK);
            this.panel1.Controls.Add(this.nudCKWeight);
            this.panel1.Controls.Add(this.btnSaveScore);
            this.panel1.Controls.Add(this.btnFix);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnImportExcel);
            this.panel1.Location = new System.Drawing.Point(12, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 570);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập và cập nhật điểm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sinh viên";
            // 
            // cboStudent
            // 
            this.cboStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboStudent.Location = new System.Drawing.Point(15, 80);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.Size = new System.Drawing.Size(490, 33);
            this.cboStudent.TabIndex = 1;
            this.cboStudent.SelectedIndexChanged += new System.EventHandler(this.cboStudent_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label3.Location = new System.Drawing.Point(15, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Môn học";
            // 
            // cboCourse
            // 
            this.cboCourse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboCourse.Location = new System.Drawing.Point(15, 140);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(490, 33);
            this.cboCourse.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(15, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Điểm quá trình (QT)";
            // 
            // txtQT
            // 
            this.txtQT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQT.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtQT.Location = new System.Drawing.Point(15, 202);
            this.txtQT.Name = "txtQT";
            this.txtQT.Size = new System.Drawing.Size(230, 34);
            this.txtQT.TabIndex = 3;
            this.txtQT.TextChanged += new System.EventHandler(this.txtQT_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label5.Location = new System.Drawing.Point(275, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điểm cuối kỳ (CK)";
            // 
            // txtCK
            // 
            this.txtCK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCK.Location = new System.Drawing.Point(275, 202);
            this.txtCK.Name = "txtCK";
            this.txtCK.Size = new System.Drawing.Size(230, 34);
            this.txtCK.TabIndex = 4;
            this.txtCK.TextChanged += new System.EventHandler(this.txtCK_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label6.Location = new System.Drawing.Point(15, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Điểm tổng kết (TK)";
            // 
            // txtTK
            // 
            this.txtTK.BackColor = System.Drawing.Color.LightGray;
            this.txtTK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTK.Location = new System.Drawing.Point(15, 265);
            this.txtTK.Name = "txtTK";
            this.txtTK.ReadOnly = true;
            this.txtTK.Size = new System.Drawing.Size(230, 34);
            this.txtTK.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label9.Location = new System.Drawing.Point(275, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 25);
            this.label9.TabIndex = 6;
            this.label9.Text = "Xếp loại";
            // 
            // txtXepLoai
            // 
            this.txtXepLoai.BackColor = System.Drawing.Color.LightGray;
            this.txtXepLoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXepLoai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXepLoai.Location = new System.Drawing.Point(275, 265);
            this.txtXepLoai.Name = "txtXepLoai";
            this.txtXepLoai.ReadOnly = true;
            this.txtXepLoai.Size = new System.Drawing.Size(230, 34);
            this.txtXepLoai.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label7.Location = new System.Drawing.Point(15, 306);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ghi chú / Mô tả";
            // 
            // txtMota
            // 
            this.txtMota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMota.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMota.Location = new System.Drawing.Point(15, 328);
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(490, 34);
            this.txtMota.TabIndex = 7;
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblWeight.Location = new System.Drawing.Point(15, 372);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(124, 25);
            this.lblWeight.TabIndex = 8;
            this.lblWeight.Text = "Hệ số QT(%):";
            // 
            // nudQTWeight
            // 
            this.nudQTWeight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQTWeight.Location = new System.Drawing.Point(145, 370);
            this.nudQTWeight.Name = "nudQTWeight";
            this.nudQTWeight.Size = new System.Drawing.Size(65, 31);
            this.nudQTWeight.TabIndex = 8;
            this.nudQTWeight.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudQTWeight.ValueChanged += new System.EventHandler(this.nudWeight_ValueChanged);
            // 
            // lblWeightCK
            // 
            this.lblWeightCK.AutoSize = true;
            this.lblWeightCK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWeightCK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblWeightCK.Location = new System.Drawing.Point(234, 372);
            this.lblWeightCK.Name = "lblWeightCK";
            this.lblWeightCK.Size = new System.Drawing.Size(70, 25);
            this.lblWeightCK.TabIndex = 9;
            this.lblWeightCK.Text = "CK(%):";
            // 
            // nudCKWeight
            // 
            this.nudCKWeight.BackColor = System.Drawing.Color.LightGray;
            this.nudCKWeight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudCKWeight.Location = new System.Drawing.Point(310, 370);
            this.nudCKWeight.Name = "nudCKWeight";
            this.nudCKWeight.ReadOnly = true;
            this.nudCKWeight.Size = new System.Drawing.Size(65, 31);
            this.nudCKWeight.TabIndex = 9;
            this.nudCKWeight.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // btnSaveScore
            // 
            this.btnSaveScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnSaveScore.FlatAppearance.BorderSize = 0;
            this.btnSaveScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveScore.ForeColor = System.Drawing.Color.White;
            this.btnSaveScore.Location = new System.Drawing.Point(15, 420);
            this.btnSaveScore.Name = "btnSaveScore";
            this.btnSaveScore.Size = new System.Drawing.Size(150, 45);
            this.btnSaveScore.TabIndex = 10;
            this.btnSaveScore.Text = "💾 Lưu điểm";
            this.btnSaveScore.UseVisualStyleBackColor = false;
            this.btnSaveScore.Click += new System.EventHandler(this.btnSaveScore_Click);
            // 
            // btnFix
            // 
            this.btnFix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnFix.FlatAppearance.BorderSize = 0;
            this.btnFix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFix.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFix.ForeColor = System.Drawing.Color.White;
            this.btnFix.Location = new System.Drawing.Point(175, 420);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(150, 45);
            this.btnFix.TabIndex = 11;
            this.btnFix.Text = "✏️ Làm mới";
            this.btnFix.UseVisualStyleBackColor = false;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(335, 420);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 45);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnImportExcel.FlatAppearance.BorderSize = 0;
            this.btnImportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Location = new System.Drawing.Point(15, 478);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(490, 45);
            this.btnImportExcel.TabIndex = 13;
            this.btnImportExcel.Text = "📥 Import Excel (MSSV | MaMH | DiemQT | DiemCK)";
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dgvScores);
            this.panel2.Location = new System.Drawing.Point(558, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 460);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label8.Location = new System.Drawing.Point(10, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(433, 36);
            this.label8.TabIndex = 0;
            this.label8.Text = "Bảng điểm chi tiết - Thống kê GPA";
            // 
            // dgvScores
            // 
            this.dgvScores.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.dgvScores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScores.BackgroundColor = System.Drawing.Color.White;
            this.dgvScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScores.ColumnHeadersHeight = 38;
            this.dgvScores.EnableHeadersVisualStyles = false;
            this.dgvScores.Location = new System.Drawing.Point(5, 50);
            this.dgvScores.Name = "dgvScores";
            this.dgvScores.RowHeadersVisible = false;
            this.dgvScores.RowHeadersWidth = 62;
            this.dgvScores.RowTemplate.Height = 28;
            this.dgvScores.Size = new System.Drawing.Size(518, 400);
            this.dgvScores.TabIndex = 0;
            this.dgvScores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScores_CellClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.lblGPA);
            this.panel3.Controls.Add(this.lblXepLoai);
            this.panel3.Controls.Add(this.btnOCRScore);
            this.panel3.Location = new System.Drawing.Point(558, 570);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(530, 100);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblGPA
            // 
            this.lblGPA.AutoSize = true;
            this.lblGPA.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblGPA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblGPA.Location = new System.Drawing.Point(10, 12);
            this.lblGPA.Name = "lblGPA";
            this.lblGPA.Size = new System.Drawing.Size(252, 30);
            this.lblGPA.TabIndex = 0;
            this.lblGPA.Text = "ĐIỂM GPA TÍCH LŨY: --";
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblXepLoai.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblXepLoai.Location = new System.Drawing.Point(10, 45);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(191, 25);
            this.lblXepLoai.TabIndex = 1;
            this.lblXepLoai.Text = "XẾP LOẠI HỌC LỰC: --";
            // 
            // btnOCRScore
            // 
            this.btnOCRScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(90)))), ((int)(((byte)(205)))));
            this.btnOCRScore.FlatAppearance.BorderSize = 0;
            this.btnOCRScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOCRScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOCRScore.ForeColor = System.Drawing.Color.White;
            this.btnOCRScore.Location = new System.Drawing.Point(280, 20);
            this.btnOCRScore.Name = "btnOCRScore";
            this.btnOCRScore.Size = new System.Drawing.Size(240, 55);
            this.btnOCRScore.TabIndex = 2;
            this.btnOCRScore.Text = "📷 OCR Đọc điểm từ ảnh";
            this.btnOCRScore.UseVisualStyleBackColor = false;
            this.btnOCRScore.Click += new System.EventHandler(this.btnOCRScore_Click);
            // 
            // erpScore
            // 
            this.erpScore.ContainerControl = this;
            // 
            // f_ManageScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1100, 690);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlHeader);
            this.Name = "f_ManageScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý điểm";
            this.Load += new System.EventHandler(this.f_ManageScore_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQTWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCKWeight)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScores)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpScore)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtXepLoai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.NumericUpDown nudQTWeight;
        private System.Windows.Forms.Label lblWeightCK;
        private System.Windows.Forms.NumericUpDown nudCKWeight;
        private System.Windows.Forms.Button btnSaveScore;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvScores;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblGPA;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.Button btnOCRScore;
        private System.Windows.Forms.ErrorProvider erpScore;
    }
}