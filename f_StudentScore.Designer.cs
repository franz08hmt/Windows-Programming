namespace QuanLySinhVien
{
    partial class f_StudentScore : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblFname = new System.Windows.Forms.Label();
            this.lblLname = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblTongTC = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.chartScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHethong = new System.Windows.Forms.Label();
            this.guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.txtMSSV = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFname = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLname = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnXemDiem = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuuWord = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.btnAINhanXet = new Guna.UI2.WinForms.Guna2Button();
            this.btnAIGoiY = new Guna.UI2.WinForms.Guna2Button();
            this.dgvScore = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlInput.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.btnAIGoiY);
            this.pnlInput.Controls.Add(this.btnAINhanXet);
            this.pnlInput.Controls.Add(this.btnPrint);
            this.pnlInput.Controls.Add(this.btnLuuWord);
            this.pnlInput.Controls.Add(this.btnXemDiem);
            this.pnlInput.Controls.Add(this.txtLname);
            this.pnlInput.Controls.Add(this.txtFname);
            this.pnlInput.Controls.Add(this.txtMSSV);
            this.pnlInput.Controls.Add(this.lblMSSV);
            this.pnlInput.Controls.Add(this.lblFname);
            this.pnlInput.Controls.Add(this.lblLname);
            this.pnlInput.Location = new System.Drawing.Point(0, 91);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1459, 108);
            this.pnlInput.TabIndex = 1;
            this.pnlInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlInput.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInput_Paint);
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMSSV.Location = new System.Drawing.Point(18, 31);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(79, 30);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV:";
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFname.Location = new System.Drawing.Point(276, 6);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(49, 30);
            this.lblFname.TabIndex = 2;
            this.lblFname.Text = "Họ:";
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLname.Location = new System.Drawing.Point(270, 59);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(55, 30);
            this.lblLname.TabIndex = 4;
            this.lblLname.Text = "Tên:";
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlSummary.Controls.Add(this.lblDiemTB);
            this.pnlSummary.Controls.Add(this.lblTongTC);
            this.pnlSummary.Controls.Add(this.lblXepLoai);
            this.pnlSummary.Location = new System.Drawing.Point(0, 414);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1462, 57);
            this.pnlSummary.TabIndex = 3;
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblDiemTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblDiemTB.Location = new System.Drawing.Point(20, 13);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(225, 31);
            this.lblDiemTB.TabIndex = 0;
            this.lblDiemTB.Text = "Điểm Trung Bình: --";
            // 
            // lblTongTC
            // 
            this.lblTongTC.AutoSize = true;
            this.lblTongTC.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTongTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblTongTC.Location = new System.Drawing.Point(340, 13);
            this.lblTongTC.Name = "lblTongTC";
            this.lblTongTC.Size = new System.Drawing.Size(213, 31);
            this.lblTongTC.TabIndex = 1;
            this.lblTongTC.Text = "Tổng Số Tín Chỉ: --";
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblXepLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblXepLoai.Location = new System.Drawing.Point(650, 13);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(136, 31);
            this.lblXepLoai.TabIndex = 2;
            this.lblXepLoai.Text = "Xếp Loại: --";
            // 
            // chartScore
            // 
            chartArea1.Name = "ChartArea1";
            this.chartScore.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartScore.Legends.Add(legend1);
            this.chartScore.Location = new System.Drawing.Point(0, 477);
            this.chartScore.Name = "chartScore";
            this.chartScore.Size = new System.Drawing.Size(1462, 480);
            this.chartScore.TabIndex = 4;
            this.chartScore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(7, 73);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1438, 10);
            this.guna2Separator1.TabIndex = 27;
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
            this.guna2Panel1.Size = new System.Drawing.Size(465, 54);
            this.guna2Panel1.TabIndex = 26;
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.BackColor = System.Drawing.Color.Transparent;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(3, 0);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(463, 54);
            this.lblHethong.TabIndex = 2;
            this.lblHethong.Text = "BẢNG ĐIỂM SINH VIÊN";
            // 
            // guna2Shapes1
            // 
            this.guna2Shapes1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Shapes1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.BorderThickness = 0;
            this.guna2Shapes1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.Location = new System.Drawing.Point(430, 11);
            this.guna2Shapes1.Name = "guna2Shapes1";
            this.guna2Shapes1.PolygonSides = 3;
            this.guna2Shapes1.PolygonSkip = 1;
            this.guna2Shapes1.Rotate = 0F;
            this.guna2Shapes1.Size = new System.Drawing.Size(78, 80);
            this.guna2Shapes1.TabIndex = 28;
            this.guna2Shapes1.Text = "guna2Shapes1";
            this.guna2Shapes1.Zoom = 80;
            // 
            // txtMSSV
            // 
            this.txtMSSV.BorderRadius = 8;
            this.txtMSSV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMSSV.DefaultText = "";
            this.txtMSSV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMSSV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMSSV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMSSV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMSSV.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtMSSV.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMSSV.ForeColor = System.Drawing.Color.Black;
            this.txtMSSV.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtMSSV.Location = new System.Drawing.Point(103, 28);
            this.txtMSSV.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.PlaceholderText = "";
            this.txtMSSV.SelectedText = "";
            this.txtMSSV.Size = new System.Drawing.Size(155, 44);
            this.txtMSSV.TabIndex = 21;
            // 
            // txtFname
            // 
            this.txtFname.BorderRadius = 8;
            this.txtFname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFname.DefaultText = "";
            this.txtFname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFname.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFname.ForeColor = System.Drawing.Color.Black;
            this.txtFname.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtFname.Location = new System.Drawing.Point(333, 6);
            this.txtFname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtFname.Name = "txtFname";
            this.txtFname.PlaceholderText = "";
            this.txtFname.SelectedText = "";
            this.txtFname.Size = new System.Drawing.Size(155, 44);
            this.txtFname.TabIndex = 22;
            // 
            // txtLname
            // 
            this.txtLname.BorderRadius = 8;
            this.txtLname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLname.DefaultText = "";
            this.txtLname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLname.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtLname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLname.ForeColor = System.Drawing.Color.Black;
            this.txtLname.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtLname.Location = new System.Drawing.Point(333, 59);
            this.txtLname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtLname.Name = "txtLname";
            this.txtLname.PlaceholderText = "";
            this.txtLname.SelectedText = "";
            this.txtLname.Size = new System.Drawing.Size(155, 44);
            this.txtLname.TabIndex = 23;
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.Animated = true;
            this.btnXemDiem.BackColor = System.Drawing.Color.Transparent;
            this.btnXemDiem.BorderColor = System.Drawing.Color.Transparent;
            this.btnXemDiem.BorderRadius = 15;
            this.btnXemDiem.BorderThickness = 2;
            this.btnXemDiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXemDiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXemDiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXemDiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXemDiem.FillColor = System.Drawing.Color.DarkCyan;
            this.btnXemDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemDiem.ForeColor = System.Drawing.Color.White;
            this.btnXemDiem.HoverState.FillColor = System.Drawing.Color.MediumTurquoise;
            this.btnXemDiem.Location = new System.Drawing.Point(501, 20);
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.PressedDepth = 100;
            this.btnXemDiem.ShadowDecoration.BorderRadius = 18;
            this.btnXemDiem.ShadowDecoration.Depth = 18;
            this.btnXemDiem.ShadowDecoration.Enabled = true;
            this.btnXemDiem.Size = new System.Drawing.Size(154, 60);
            this.btnXemDiem.TabIndex = 33;
            this.btnXemDiem.Text = "🔍 Xem điểm";
            this.btnXemDiem.Click += new System.EventHandler(this.btnXemDiem_Click_1);
            // 
            // btnLuuWord
            // 
            this.btnLuuWord.Animated = true;
            this.btnLuuWord.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuWord.BorderColor = System.Drawing.Color.Transparent;
            this.btnLuuWord.BorderRadius = 15;
            this.btnLuuWord.BorderThickness = 2;
            this.btnLuuWord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuuWord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuuWord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuuWord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuuWord.FillColor = System.Drawing.Color.MidnightBlue;
            this.btnLuuWord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuuWord.ForeColor = System.Drawing.Color.White;
            this.btnLuuWord.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnLuuWord.Location = new System.Drawing.Point(684, 20);
            this.btnLuuWord.Name = "btnLuuWord";
            this.btnLuuWord.PressedDepth = 100;
            this.btnLuuWord.ShadowDecoration.BorderRadius = 18;
            this.btnLuuWord.ShadowDecoration.Depth = 18;
            this.btnLuuWord.ShadowDecoration.Enabled = true;
            this.btnLuuWord.Size = new System.Drawing.Size(154, 60);
            this.btnLuuWord.TabIndex = 34;
            this.btnLuuWord.Text = "💾 Lưu Word";
            this.btnLuuWord.Click += new System.EventHandler(this.btnLuuWord_Click_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Animated = true;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.BorderColor = System.Drawing.Color.Transparent;
            this.btnPrint.BorderRadius = 15;
            this.btnPrint.BorderThickness = 2;
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.FillColor = System.Drawing.Color.SeaGreen;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.HoverState.FillColor = System.Drawing.Color.MediumSpringGreen;
            this.btnPrint.Location = new System.Drawing.Point(865, 20);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PressedDepth = 100;
            this.btnPrint.ShadowDecoration.BorderRadius = 18;
            this.btnPrint.ShadowDecoration.Depth = 18;
            this.btnPrint.ShadowDecoration.Enabled = true;
            this.btnPrint.Size = new System.Drawing.Size(154, 60);
            this.btnPrint.TabIndex = 35;
            this.btnPrint.Text = "🖨️ In";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // btnAINhanXet
            // 
            this.btnAINhanXet.Animated = true;
            this.btnAINhanXet.BackColor = System.Drawing.Color.Transparent;
            this.btnAINhanXet.BorderColor = System.Drawing.Color.Transparent;
            this.btnAINhanXet.BorderRadius = 15;
            this.btnAINhanXet.BorderThickness = 2;
            this.btnAINhanXet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAINhanXet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAINhanXet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAINhanXet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAINhanXet.FillColor = System.Drawing.Color.Indigo;
            this.btnAINhanXet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAINhanXet.ForeColor = System.Drawing.Color.White;
            this.btnAINhanXet.HoverState.FillColor = System.Drawing.Color.BlueViolet;
            this.btnAINhanXet.Location = new System.Drawing.Point(1055, 20);
            this.btnAINhanXet.Name = "btnAINhanXet";
            this.btnAINhanXet.PressedDepth = 100;
            this.btnAINhanXet.ShadowDecoration.BorderRadius = 18;
            this.btnAINhanXet.ShadowDecoration.Depth = 18;
            this.btnAINhanXet.ShadowDecoration.Enabled = true;
            this.btnAINhanXet.Size = new System.Drawing.Size(154, 60);
            this.btnAINhanXet.TabIndex = 36;
            this.btnAINhanXet.Text = "🤖 AI Nhận xét";
            this.btnAINhanXet.Click += new System.EventHandler(this.btnAINhanXet_Click_1);
            // 
            // btnAIGoiY
            // 
            this.btnAIGoiY.Animated = true;
            this.btnAIGoiY.BackColor = System.Drawing.Color.Transparent;
            this.btnAIGoiY.BorderColor = System.Drawing.Color.Transparent;
            this.btnAIGoiY.BorderRadius = 15;
            this.btnAIGoiY.BorderThickness = 2;
            this.btnAIGoiY.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAIGoiY.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAIGoiY.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAIGoiY.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAIGoiY.FillColor = System.Drawing.Color.SteelBlue;
            this.btnAIGoiY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAIGoiY.ForeColor = System.Drawing.Color.White;
            this.btnAIGoiY.HoverState.FillColor = System.Drawing.Color.SkyBlue;
            this.btnAIGoiY.Location = new System.Drawing.Point(1246, 20);
            this.btnAIGoiY.Name = "btnAIGoiY";
            this.btnAIGoiY.PressedDepth = 100;
            this.btnAIGoiY.ShadowDecoration.BorderRadius = 18;
            this.btnAIGoiY.ShadowDecoration.Depth = 18;
            this.btnAIGoiY.ShadowDecoration.Enabled = true;
            this.btnAIGoiY.Size = new System.Drawing.Size(154, 60);
            this.btnAIGoiY.TabIndex = 37;
            this.btnAIGoiY.Text = "📅 AI Gợi ý môn";
            this.btnAIGoiY.Click += new System.EventHandler(this.btnAIGoiY_Click_1);
            // 
            // dgvScore
            // 
            this.dgvScore.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvScore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvScore.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvScore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScore.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvScore.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvScore.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvScore.Location = new System.Drawing.Point(-2, 203);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.RowHeadersVisible = false;
            this.dgvScore.RowHeadersWidth = 62;
            this.dgvScore.RowTemplate.Height = 28;
            this.dgvScore.Size = new System.Drawing.Size(1459, 205);
            this.dgvScore.TabIndex = 29;
            this.dgvScore.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvScore.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvScore.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvScore.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvScore.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvScore.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvScore.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvScore.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvScore.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvScore.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvScore.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvScore.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvScore.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvScore.ThemeStyle.ReadOnly = false;
            this.dgvScore.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvScore.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvScore.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvScore.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvScore.ThemeStyle.RowsStyle.Height = 28;
            this.dgvScore.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvScore.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // f_StudentScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.dgvScore);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Shapes1);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.chartScore);
            this.Name = "f_StudentScore";
            this.Size = new System.Drawing.Size(1462, 957);
            this.Load += new System.EventHandler(this.f_StudentScore_Load);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Label lblTongTC;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartScore;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblHethong;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
        private Guna.UI2.WinForms.Guna2TextBox txtLname;
        private Guna.UI2.WinForms.Guna2TextBox txtFname;
        private Guna.UI2.WinForms.Guna2TextBox txtMSSV;
        private Guna.UI2.WinForms.Guna2Button btnXemDiem;
        private Guna.UI2.WinForms.Guna2Button btnAIGoiY;
        private Guna.UI2.WinForms.Guna2Button btnAINhanXet;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private Guna.UI2.WinForms.Guna2Button btnLuuWord;
        private Guna.UI2.WinForms.Guna2DataGridView dgvScore;
    }
}