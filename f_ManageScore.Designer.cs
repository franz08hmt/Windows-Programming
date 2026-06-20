namespace QuanLySinhVien
{
    partial class f_ManageScore : System.Windows.Forms.UserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_ManageScore));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblWeightCK = new System.Windows.Forms.Label();
            this.lblGPA = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.erpScore = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHethong = new System.Windows.Forms.Label();
            this.guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnFix = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveScore = new Guna.UI2.WinForms.Guna2Button();
            this.nudCKWeight = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.nudQTWeight = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.txtMota = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtXepLoai = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtTK = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCK = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtQT = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboCourse = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboStudent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvScores = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPDF = new Guna.UI2.WinForms.Guna2Button();
            this.btnOCRScore = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            ((System.ComponentModel.ISupportInitialize)(this.erpScore)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCKWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQTWeight)).BeginInit();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScores)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(18, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sinh viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label3.Location = new System.Drawing.Point(18, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Môn học";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(18, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Điểm quá trình (QT)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label5.Location = new System.Drawing.Point(437, 297);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điểm cuối kỳ (CK)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label6.Location = new System.Drawing.Point(18, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "Điểm tổng kết (TK)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label9.Location = new System.Drawing.Point(437, 395);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 30);
            this.label9.TabIndex = 6;
            this.label9.Text = "Xếp loại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label7.Location = new System.Drawing.Point(18, 487);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 30);
            this.label7.TabIndex = 7;
            this.label7.Text = "Ghi chú / Mô tả";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWeight.Location = new System.Drawing.Point(18, 659);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(141, 30);
            this.lblWeight.TabIndex = 8;
            this.lblWeight.Text = "Hệ số QT(%):";
            // 
            // lblWeightCK
            // 
            this.lblWeightCK.AutoSize = true;
            this.lblWeightCK.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblWeightCK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblWeightCK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWeightCK.Location = new System.Drawing.Point(286, 659);
            this.lblWeightCK.Name = "lblWeightCK";
            this.lblWeightCK.Size = new System.Drawing.Size(80, 30);
            this.lblWeightCK.TabIndex = 9;
            this.lblWeightCK.Text = "CK(%):";
            // 
            // lblGPA
            // 
            this.lblGPA.AutoSize = true;
            this.lblGPA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGPA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblGPA.Location = new System.Drawing.Point(3, 13);
            this.lblGPA.Name = "lblGPA";
            this.lblGPA.Size = new System.Drawing.Size(278, 32);
            this.lblGPA.TabIndex = 0;
            this.lblGPA.Text = "ĐIỂM GPA TÍCH LŨY: --";
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblXepLoai.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblXepLoai.Location = new System.Drawing.Point(4, 45);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(191, 25);
            this.lblXepLoai.TabIndex = 1;
            this.lblXepLoai.Text = "XẾP LOẠI HỌC LỰC: --";
            // 
            // erpScore
            // 
            this.erpScore.ContainerControl = this;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(7, 73);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1438, 10);
            this.guna2Separator1.TabIndex = 30;
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            //
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 5;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.lblHethong);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.guna2Panel1.Location = new System.Drawing.Point(7, 18);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(312, 54);
            this.guna2Panel1.TabIndex = 29;
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.BackColor = System.Drawing.Color.Transparent;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(3, 0);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(308, 54);
            this.lblHethong.TabIndex = 2;
            this.lblHethong.Text = "QUẢN LÝ ĐIỂM";
            // 
            // guna2Shapes1
            // 
            this.guna2Shapes1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Shapes1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.BorderThickness = 0;
            this.guna2Shapes1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.Location = new System.Drawing.Point(277, 11);
            this.guna2Shapes1.Name = "guna2Shapes1";
            this.guna2Shapes1.PolygonSides = 3;
            this.guna2Shapes1.PolygonSkip = 1;
            this.guna2Shapes1.Rotate = 0F;
            this.guna2Shapes1.Size = new System.Drawing.Size(78, 80);
            this.guna2Shapes1.TabIndex = 31;
            this.guna2Shapes1.Text = "guna2Shapes1";
            this.guna2Shapes1.Zoom = 80;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderColor = System.Drawing.Color.LightGray;
            this.guna2Panel4.BorderRadius = 20;
            this.guna2Panel4.BorderThickness = 2;
            this.guna2Panel4.Controls.Add(this.btnRefresh);
            this.guna2Panel4.Controls.Add(this.btnFix);
            this.guna2Panel4.Controls.Add(this.btnSaveScore);
            this.guna2Panel4.Controls.Add(this.nudCKWeight);
            this.guna2Panel4.Controls.Add(this.nudQTWeight);
            this.guna2Panel4.Controls.Add(this.txtMota);
            this.guna2Panel4.Controls.Add(this.txtXepLoai);
            this.guna2Panel4.Controls.Add(this.txtTK);
            this.guna2Panel4.Controls.Add(this.txtCK);
            this.guna2Panel4.Controls.Add(this.txtQT);
            this.guna2Panel4.Controls.Add(this.cboCourse);
            this.guna2Panel4.Controls.Add(this.cboStudent);
            this.guna2Panel4.Controls.Add(this.guna2Panel5);
            this.guna2Panel4.Controls.Add(this.label1);
            this.guna2Panel4.Controls.Add(this.label3);
            this.guna2Panel4.Controls.Add(this.label4);
            this.guna2Panel4.Controls.Add(this.lblWeightCK);
            this.guna2Panel4.Controls.Add(this.label5);
            this.guna2Panel4.Controls.Add(this.lblWeight);
            this.guna2Panel4.Controls.Add(this.label6);
            this.guna2Panel4.Controls.Add(this.label7);
            this.guna2Panel4.Controls.Add(this.label9);
            this.guna2Panel4.FillColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(7, 97);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel4.ShadowDecoration.Depth = 5;
            this.guna2Panel4.ShadowDecoration.Enabled = true;
            this.guna2Panel4.Size = new System.Drawing.Size(809, 827);
            this.guna2Panel4.TabIndex = 33;
            this.guna2Panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Bottom)));
            // 
            // btnRefresh
            // 
            this.btnRefresh.Animated = true;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderRadius = 15;
            this.btnRefresh.BorderThickness = 1;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.DimGray;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.Silver;
            this.btnRefresh.Location = new System.Drawing.Point(522, 729);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PressedDepth = 100;
            this.btnRefresh.ShadowDecoration.BorderRadius = 18;
            this.btnRefresh.ShadowDecoration.Depth = 10;
            this.btnRefresh.ShadowDecoration.Enabled = true;
            this.btnRefresh.Size = new System.Drawing.Size(198, 76);
            this.btnRefresh.TabIndex = 41;
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btnFix
            // 
            this.btnFix.Animated = true;
            this.btnFix.BackColor = System.Drawing.Color.Transparent;
            this.btnFix.BorderColor = System.Drawing.Color.Transparent;
            this.btnFix.BorderRadius = 15;
            this.btnFix.BorderThickness = 1;
            this.btnFix.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFix.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFix.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFix.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFix.FillColor = System.Drawing.Color.Navy;
            this.btnFix.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnFix.ForeColor = System.Drawing.Color.White;
            this.btnFix.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnFix.Location = new System.Drawing.Point(300, 729);
            this.btnFix.Name = "btnFix";
            this.btnFix.PressedDepth = 100;
            this.btnFix.ShadowDecoration.BorderRadius = 18;
            this.btnFix.ShadowDecoration.Depth = 10;
            this.btnFix.ShadowDecoration.Enabled = true;
            this.btnFix.Size = new System.Drawing.Size(198, 76);
            this.btnFix.TabIndex = 40;
            this.btnFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFix.Text = "✏️ Sửa điểm";
            this.btnFix.Click += new System.EventHandler(this.btnExportScorePDF_Click);
            // 
            // btnSaveScore
            // 
            this.btnSaveScore.Animated = true;
            this.btnSaveScore.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveScore.BorderColor = System.Drawing.Color.Transparent;
            this.btnSaveScore.BorderRadius = 15;
            this.btnSaveScore.BorderThickness = 1;
            this.btnSaveScore.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveScore.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveScore.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveScore.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveScore.FillColor = System.Drawing.Color.SeaGreen;
            this.btnSaveScore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveScore.ForeColor = System.Drawing.Color.White;
            this.btnSaveScore.HoverState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnSaveScore.Location = new System.Drawing.Point(81, 729);
            this.btnSaveScore.Name = "btnSaveScore";
            this.btnSaveScore.PressedDepth = 100;
            this.btnSaveScore.ShadowDecoration.BorderRadius = 18;
            this.btnSaveScore.ShadowDecoration.Depth = 10;
            this.btnSaveScore.ShadowDecoration.Enabled = true;
            this.btnSaveScore.Size = new System.Drawing.Size(198, 76);
            this.btnSaveScore.TabIndex = 39;
            this.btnSaveScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveScore.Text = "💾 Lưu điểm";
            this.btnSaveScore.Click += new System.EventHandler(this.btnSaveScore_Click_1);
            // 
            // nudCKWeight
            // 
            this.nudCKWeight.BackColor = System.Drawing.Color.Transparent;
            this.nudCKWeight.BorderRadius = 8;
            this.nudCKWeight.BorderThickness = 2;
            this.nudCKWeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudCKWeight.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudCKWeight.Location = new System.Drawing.Point(375, 657);
            this.nudCKWeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudCKWeight.Name = "nudCKWeight";
            this.nudCKWeight.Size = new System.Drawing.Size(107, 44);
            this.nudCKWeight.TabIndex = 38;
            this.nudCKWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudCKWeight.UpDownButtonFillColor = System.Drawing.Color.DarkTurquoise;
            this.nudCKWeight.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // nudQTWeight
            // 
            this.nudQTWeight.BackColor = System.Drawing.Color.Transparent;
            this.nudQTWeight.BorderRadius = 8;
            this.nudQTWeight.BorderThickness = 2;
            this.nudQTWeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nudQTWeight.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudQTWeight.Location = new System.Drawing.Point(172, 657);
            this.nudQTWeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudQTWeight.Name = "nudQTWeight";
            this.nudQTWeight.Size = new System.Drawing.Size(107, 44);
            this.nudQTWeight.TabIndex = 37;
            this.nudQTWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudQTWeight.UpDownButtonFillColor = System.Drawing.Color.DarkCyan;
            this.nudQTWeight.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // txtMota
            // 
            this.txtMota.BorderRadius = 8;
            this.txtMota.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMota.DefaultText = "";
            this.txtMota.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMota.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMota.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMota.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMota.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtMota.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMota.ForeColor = System.Drawing.Color.Black;
            this.txtMota.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtMota.Location = new System.Drawing.Point(23, 523);
            this.txtMota.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtMota.Name = "txtMota";
            this.txtMota.PlaceholderText = "";
            this.txtMota.SelectedText = "";
            this.txtMota.Size = new System.Drawing.Size(766, 123);
            this.txtMota.TabIndex = 36;
            this.txtMota.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // txtXepLoai
            // 
            this.txtXepLoai.BorderRadius = 8;
            this.txtXepLoai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtXepLoai.DefaultText = "";
            this.txtXepLoai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtXepLoai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtXepLoai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtXepLoai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtXepLoai.FillColor = System.Drawing.Color.LightGray;
            this.txtXepLoai.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtXepLoai.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtXepLoai.ForeColor = System.Drawing.Color.Black;
            this.txtXepLoai.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtXepLoai.Location = new System.Drawing.Point(438, 431);
            this.txtXepLoai.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtXepLoai.Name = "txtXepLoai";
            this.txtXepLoai.PlaceholderText = "";
            this.txtXepLoai.ReadOnly = true;
            this.txtXepLoai.SelectedText = "";
            this.txtXepLoai.Size = new System.Drawing.Size(351, 44);
            this.txtXepLoai.TabIndex = 35;
            // 
            // txtTK
            // 
            this.txtTK.BorderRadius = 8;
            this.txtTK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTK.DefaultText = "";
            this.txtTK.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTK.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTK.FillColor = System.Drawing.Color.LightGray;
            this.txtTK.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtTK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTK.ForeColor = System.Drawing.Color.Black;
            this.txtTK.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtTK.Location = new System.Drawing.Point(23, 431);
            this.txtTK.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtTK.Name = "txtTK";
            this.txtTK.PlaceholderText = "";
            this.txtTK.ReadOnly = true;
            this.txtTK.SelectedText = "";
            this.txtTK.Size = new System.Drawing.Size(350, 44);
            this.txtTK.TabIndex = 34;
            // 
            // txtCK
            // 
            this.txtCK.BorderRadius = 8;
            this.txtCK.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCK.DefaultText = "";
            this.txtCK.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCK.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCK.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtCK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtCK.ForeColor = System.Drawing.Color.Black;
            this.txtCK.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtCK.Location = new System.Drawing.Point(438, 330);
            this.txtCK.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtCK.Name = "txtCK";
            this.txtCK.PlaceholderText = "";
            this.txtCK.SelectedText = "";
            this.txtCK.Size = new System.Drawing.Size(351, 44);
            this.txtCK.TabIndex = 33;
            // 
            // txtQT
            // 
            this.txtQT.BorderRadius = 8;
            this.txtQT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQT.DefaultText = "";
            this.txtQT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtQT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtQT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtQT.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtQT.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtQT.ForeColor = System.Drawing.Color.Black;
            this.txtQT.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtQT.Location = new System.Drawing.Point(23, 330);
            this.txtQT.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtQT.Name = "txtQT";
            this.txtQT.PlaceholderText = "";
            this.txtQT.SelectedText = "";
            this.txtQT.Size = new System.Drawing.Size(350, 44);
            this.txtQT.TabIndex = 32;
            // 
            // cboCourse
            // 
            this.cboCourse.BackColor = System.Drawing.Color.Transparent;
            this.cboCourse.BorderRadius = 8;
            this.cboCourse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourse.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCourse.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCourse.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCourse.ItemHeight = 30;
            this.cboCourse.Location = new System.Drawing.Point(23, 226);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(766, 36);
            this.cboCourse.TabIndex = 31;
            this.cboCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            // 
            // cboStudent
            // 
            this.cboStudent.BackColor = System.Drawing.Color.Transparent;
            this.cboStudent.BorderRadius = 8;
            this.cboStudent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudent.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStudent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStudent.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboStudent.ItemHeight = 30;
            this.cboStudent.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboStudent.Location = new System.Drawing.Point(23, 130);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.Size = new System.Drawing.Size(766, 36);
            this.cboStudent.TabIndex = 30;
            this.cboStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.BorderColor = System.Drawing.Color.LightGray;
            this.guna2Panel5.BorderRadius = 20;
            this.guna2Panel5.Controls.Add(this.label17);
            this.guna2Panel5.CustomizableEdges.BottomLeft = false;
            this.guna2Panel5.CustomizableEdges.BottomRight = false;
            this.guna2Panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.guna2Panel5.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel5.ShadowDecoration.Depth = 0;
            this.guna2Panel5.Size = new System.Drawing.Size(809, 62);
            this.guna2Panel5.TabIndex = 29;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(203, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(372, 38);
            this.label17.TabIndex = 3;
            this.label17.Text = "NHẬP VÀ CẬP NHẬT ĐIỂM";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.LightGray;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 2;
            this.guna2Panel2.Controls.Add(this.dgvScores);
            this.guna2Panel2.Controls.Add(this.guna2Panel3);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(843, 104);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel2.ShadowDecoration.Depth = 5;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.Size = new System.Drawing.Size(602, 631);
            this.guna2Panel2.TabIndex = 42;
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // dgvScores
            // 
            this.dgvScores.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvScores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScores.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScores.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScores.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvScores.Location = new System.Drawing.Point(0, 62);
            this.dgvScores.Name = "dgvScores";
            this.dgvScores.RowHeadersVisible = false;
            this.dgvScores.RowHeadersWidth = 62;
            this.dgvScores.RowTemplate.Height = 28;
            this.dgvScores.Size = new System.Drawing.Size(602, 569);
            this.dgvScores.TabIndex = 30;
            this.dgvScores.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvScores.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvScores.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvScores.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvScores.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvScores.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvScores.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvScores.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvScores.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvScores.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvScores.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvScores.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvScores.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvScores.ThemeStyle.ReadOnly = false;
            this.dgvScores.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvScores.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvScores.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvScores.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvScores.ThemeStyle.RowsStyle.Height = 28;
            this.dgvScores.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvScores.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvScores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScores_CellClick_1);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderColor = System.Drawing.Color.LightGray;
            this.guna2Panel3.BorderRadius = 20;
            this.guna2Panel3.Controls.Add(this.label2);
            this.guna2Panel3.CustomizableEdges.BottomLeft = false;
            this.guna2Panel3.CustomizableEdges.BottomRight = false;
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel3.ShadowDecoration.Depth = 0;
            this.guna2Panel3.Size = new System.Drawing.Size(602, 62);
            this.guna2Panel3.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(527, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "BẢNG ĐIỂM CHI TIẾT - THỐNG KÊ GPA";
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel6.BorderColor = System.Drawing.Color.LightGray;
            this.guna2Panel6.BorderRadius = 20;
            this.guna2Panel6.BorderThickness = 2;
            this.guna2Panel6.Controls.Add(this.label10);
            this.guna2Panel6.Controls.Add(this.btnExport);
            this.guna2Panel6.Controls.Add(this.label8);
            this.guna2Panel6.Controls.Add(this.btnPDF);
            this.guna2Panel6.Controls.Add(this.btnOCRScore);
            this.guna2Panel6.Controls.Add(this.lblGPA);
            this.guna2Panel6.Controls.Add(this.lblXepLoai);
            this.guna2Panel6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.guna2Panel6.Location = new System.Drawing.Point(843, 741);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel6.ShadowDecoration.Depth = 5;
            this.guna2Panel6.ShadowDecoration.Enabled = true;
            this.guna2Panel6.Size = new System.Drawing.Size(602, 183);
            this.guna2Panel6.TabIndex = 43;
            this.guna2Panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(54)))));
            this.label10.Location = new System.Drawing.Point(462, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 21);
            this.label10.TabIndex = 46;
            this.label10.Text = "Xuất File EXCEL";
            // 
            // btnExport
            // 
            this.btnExport.Animated = true;
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderRadius = 15;
            this.btnExport.BorderThickness = 2;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(54)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExport.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnExport.HoverState.FillColor = System.Drawing.Color.ForestGreen;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageSize = new System.Drawing.Size(70, 70);
            this.btnExport.Location = new System.Drawing.Point(477, 55);
            this.btnExport.Name = "btnExport";
            this.btnExport.PressedDepth = 100;
            this.btnExport.ShadowDecoration.BorderRadius = 18;
            this.btnExport.ShadowDecoration.Depth = 18;
            this.btnExport.ShadowDecoration.Enabled = true;
            this.btnExport.Size = new System.Drawing.Size(90, 80);
            this.btnExport.TabIndex = 45;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Brown;
            this.label8.Location = new System.Drawing.Point(334, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 21);
            this.label8.TabIndex = 44;
            this.label8.Text = "Xuất File PDF";
            // 
            // btnPDF
            // 
            this.btnPDF.Animated = true;
            this.btnPDF.BackColor = System.Drawing.Color.Transparent;
            this.btnPDF.BorderColor = System.Drawing.Color.Transparent;
            this.btnPDF.BorderRadius = 15;
            this.btnPDF.BorderThickness = 2;
            this.btnPDF.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPDF.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPDF.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPDF.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPDF.FillColor = System.Drawing.Color.Brown;
            this.btnPDF.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPDF.ForeColor = System.Drawing.Color.OliveDrab;
            this.btnPDF.HoverState.FillColor = System.Drawing.Color.OrangeRed;
            this.btnPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnPDF.Image")));
            this.btnPDF.ImageSize = new System.Drawing.Size(70, 70);
            this.btnPDF.Location = new System.Drawing.Point(342, 58);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.PressedDepth = 100;
            this.btnPDF.ShadowDecoration.BorderRadius = 18;
            this.btnPDF.ShadowDecoration.Depth = 18;
            this.btnPDF.ShadowDecoration.Enabled = true;
            this.btnPDF.Size = new System.Drawing.Size(90, 80);
            this.btnPDF.TabIndex = 43;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnOCRScore
            // 
            this.btnOCRScore.Animated = true;
            this.btnOCRScore.BackColor = System.Drawing.Color.Transparent;
            this.btnOCRScore.BorderColor = System.Drawing.Color.Transparent;
            this.btnOCRScore.BorderRadius = 15;
            this.btnOCRScore.BorderThickness = 1;
            this.btnOCRScore.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOCRScore.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOCRScore.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOCRScore.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOCRScore.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnOCRScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOCRScore.ForeColor = System.Drawing.Color.White;
            this.btnOCRScore.HoverState.FillColor = System.Drawing.Color.SlateBlue;
            this.btnOCRScore.Location = new System.Drawing.Point(76, 85);
            this.btnOCRScore.Name = "btnOCRScore";
            this.btnOCRScore.PressedDepth = 100;
            this.btnOCRScore.ShadowDecoration.BorderRadius = 18;
            this.btnOCRScore.ShadowDecoration.Depth = 10;
            this.btnOCRScore.ShadowDecoration.Enabled = true;
            this.btnOCRScore.Size = new System.Drawing.Size(198, 76);
            this.btnOCRScore.TabIndex = 42;
            this.btnOCRScore.Text = "📷 OCR Đọc điểm từ ảnh";
            this.btnOCRScore.Click += new System.EventHandler(this.btnOCRScore_Click_1);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillThickness = 3;
            this.guna2Separator2.Location = new System.Drawing.Point(4, 930);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(1438, 10);
            this.guna2Separator2.TabIndex = 44;
            this.guna2Separator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // f_ManageScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.guna2Panel6);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Shapes1);
            this.Name = "f_ManageScore";
            this.Size = new System.Drawing.Size(1462, 957);
            this.Load += new System.EventHandler(this.f_ManageScore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erpScore)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCKWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQTWeight)).EndInit();
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel5.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScores)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel6.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblWeightCK;
        private System.Windows.Forms.Label lblGPA;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.ErrorProvider erpScore;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblHethong;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2ComboBox cboCourse;
        private Guna.UI2.WinForms.Guna2ComboBox cboStudent;
        private Guna.UI2.WinForms.Guna2TextBox txtMota;
        private Guna.UI2.WinForms.Guna2TextBox txtXepLoai;
        private Guna.UI2.WinForms.Guna2TextBox txtTK;
        private Guna.UI2.WinForms.Guna2TextBox txtCK;
        private Guna.UI2.WinForms.Guna2TextBox txtQT;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudQTWeight;
        private Guna.UI2.WinForms.Guna2NumericUpDown nudCKWeight;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnFix;
        private Guna.UI2.WinForms.Guna2Button btnSaveScore;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private Guna.UI2.WinForms.Guna2Button btnOCRScore;
        private Guna.UI2.WinForms.Guna2DataGridView dgvScores;
        private Guna.UI2.WinForms.Guna2Button btnPDF;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button btnExport;
    }
}