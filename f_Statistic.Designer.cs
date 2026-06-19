namespace QuanLySinhVien
{
    partial class f_Statistic : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGpa = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlMale = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitleDetail = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.lblTitleTable = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblThongKeNam = new System.Windows.Forms.Label();
            this.dgvNam = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTongSV = new System.Windows.Forms.Label();
            this.lblTongMon = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlTotal = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMale = new System.Windows.Forms.Label();
            this.lblFemale = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHethong = new System.Windows.Forms.Label();
            this.guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.pnlFemale = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlOther = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAIDashboard = new Guna.UI2.WinForms.Guna2Button();
            this.btnAIPredict = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNam)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlMale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNam)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.pnlFemale.SuspendLayout();
            this.pnlOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlMain.Controls.Add(this.guna2Separator1);
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Controls.Add(this.pnlCards);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 81);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(1462, 876);
            this.pnlMain.TabIndex = 1;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(6, 2);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1438, 10);
            this.guna2Separator1.TabIndex = 30;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.pnlRight);
            this.pnlContent.Controls.Add(this.pnlLeft);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 167);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1432, 694);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.chartPie);
            this.pnlRight.Controls.Add(this.chartGpa);
            this.pnlRight.Controls.Add(this.chartNam);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(420, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(1012, 694);
            this.pnlRight.TabIndex = 1;
            // 
            // chartPie
            // 
            chartArea7.Name = "ChartArea2";
            this.chartPie.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend2";
            this.chartPie.Legends.Add(legend7);
            this.chartPie.Location = new System.Drawing.Point(10, 241);
            this.chartPie.Name = "chartPie";
            this.chartPie.Size = new System.Drawing.Size(980, 197);
            this.chartPie.TabIndex = 1;
            // 
            // chartGpa
            // 
            chartArea8.Name = "ChartArea1";
            this.chartGpa.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartGpa.Legends.Add(legend8);
            this.chartGpa.Location = new System.Drawing.Point(6, 6);
            this.chartGpa.Name = "chartGpa";
            this.chartGpa.Size = new System.Drawing.Size(990, 209);
            this.chartGpa.TabIndex = 0;
            // 
            // chartNam
            // 
            chartArea9.Name = "ChartArea3";
            this.chartNam.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend3";
            this.chartNam.Legends.Add(legend9);
            this.chartNam.Location = new System.Drawing.Point(10, 444);
            this.chartNam.Name = "chartNam";
            this.chartNam.Size = new System.Drawing.Size(986, 230);
            this.chartNam.TabIndex = 2;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.lblTitleDetail);
            this.pnlLeft.Controls.Add(this.dgvDetail);
            this.pnlLeft.Controls.Add(this.lblTitleTable);
            this.pnlLeft.Controls.Add(this.dgvReport);
            this.pnlLeft.Controls.Add(this.lblThongKeNam);
            this.pnlLeft.Controls.Add(this.dgvNam);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(420, 694);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlMale
            // 
            this.pnlMale.BackColor = System.Drawing.Color.Transparent;
            this.pnlMale.BorderRadius = 20;
            this.pnlMale.BorderThickness = 2;
            this.pnlMale.Controls.Add(this.lblMale);
            this.pnlMale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMale.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlMale.Location = new System.Drawing.Point(373, 7);
            this.pnlMale.Name = "pnlMale";
            this.pnlMale.ShadowDecoration.BorderRadius = 20;
            this.pnlMale.ShadowDecoration.Depth = 10;
            this.pnlMale.ShadowDecoration.Enabled = true;
            this.pnlMale.Size = new System.Drawing.Size(338, 100);
            this.pnlMale.TabIndex = 27;
            // 
            // lblTitleDetail
            // 
            this.lblTitleDetail.AutoSize = true;
            this.lblTitleDetail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblTitleDetail.Location = new System.Drawing.Point(10, 241);
            this.lblTitleDetail.Name = "lblTitleDetail";
            this.lblTitleDetail.Size = new System.Drawing.Size(330, 25);
            this.lblTitleDetail.TabIndex = 0;
            this.lblTitleDetail.Text = "ĐIỂM TRUNG BÌNH TỪNG SINH VIÊN";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(10, 269);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 40;
            this.dgvDetail.RowTemplate.Height = 30;
            this.dgvDetail.Size = new System.Drawing.Size(400, 174);
            this.dgvDetail.TabIndex = 3;
            // 
            // lblTitleTable
            // 
            this.lblTitleTable.AutoSize = true;
            this.lblTitleTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblTitleTable.Location = new System.Drawing.Point(13, 10);
            this.lblTitleTable.Name = "lblTitleTable";
            this.lblTitleTable.Size = new System.Drawing.Size(190, 25);
            this.lblTitleTable.TabIndex = 4;
            this.lblTitleTable.Text = "THỐNG KÊ XẾP LOẠI";
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(10, 38);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 40;
            this.dgvReport.RowTemplate.Height = 30;
            this.dgvReport.Size = new System.Drawing.Size(400, 200);
            this.dgvReport.TabIndex = 1;
            // 
            // lblThongKeNam
            // 
            this.lblThongKeNam.AutoSize = true;
            this.lblThongKeNam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThongKeNam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblThongKeNam.Location = new System.Drawing.Point(10, 446);
            this.lblThongKeNam.Name = "lblThongKeNam";
            this.lblThongKeNam.Size = new System.Drawing.Size(309, 25);
            this.lblThongKeNam.TabIndex = 5;
            this.lblThongKeNam.Text = "THỐNG KÊ THEO NĂM NHẬP HỌC";
            // 
            // dgvNam
            // 
            this.dgvNam.AllowUserToAddRows = false;
            this.dgvNam.BackgroundColor = System.Drawing.Color.White;
            this.dgvNam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNam.Location = new System.Drawing.Point(13, 506);
            this.dgvNam.Name = "dgvNam";
            this.dgvNam.ReadOnly = true;
            this.dgvNam.RowHeadersWidth = 40;
            this.dgvNam.RowTemplate.Height = 28;
            this.dgvNam.Size = new System.Drawing.Size(400, 177);
            this.dgvNam.TabIndex = 4;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnAIPredict);
            this.pnlTop.Controls.Add(this.btnAIDashboard);
            this.pnlTop.Controls.Add(this.lblTongSV);
            this.pnlTop.Controls.Add(this.lblTongMon);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 122);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1432, 45);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTongSV
            // 
            this.lblTongSV.AutoSize = true;
            this.lblTongSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblTongSV.Location = new System.Drawing.Point(-2, 8);
            this.lblTongSV.Name = "lblTongSV";
            this.lblTongSV.Size = new System.Drawing.Size(195, 28);
            this.lblTongSV.TabIndex = 0;
            this.lblTongSV.Text = "Tổng SV có điểm: 0";
            // 
            // lblTongMon
            // 
            this.lblTongMon.AutoSize = true;
            this.lblTongMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblTongMon.Location = new System.Drawing.Point(239, 8);
            this.lblTongMon.Name = "lblTongMon";
            this.lblTongMon.Size = new System.Drawing.Size(171, 28);
            this.lblTongMon.TabIndex = 1;
            this.lblTongMon.Text = "Tổng môn học: 0";
            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.Transparent;
            this.pnlCards.Controls.Add(this.pnlOther);
            this.pnlCards.Controls.Add(this.pnlFemale);
            this.pnlCards.Controls.Add(this.pnlMale);
            this.pnlCards.Controls.Add(this.pnlTotal);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(15, 15);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1432, 107);
            this.pnlCards.TabIndex = 0;
            this.pnlCards.MouseEnter += new System.EventHandler(this.pnlCards_MouseEnter);
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.Transparent;
            this.pnlTotal.BorderRadius = 20;
            this.pnlTotal.BorderThickness = 2;
            this.pnlTotal.Controls.Add(this.lblTotalTitle);
            this.pnlTotal.Controls.Add(this.lblTotal);
            this.pnlTotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlTotal.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlTotal.Location = new System.Drawing.Point(10, 7);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.ShadowDecoration.BorderRadius = 20;
            this.pnlTotal.ShadowDecoration.Depth = 10;
            this.pnlTotal.ShadowDecoration.Enabled = true;
            this.pnlTotal.Size = new System.Drawing.Size(338, 97);
            this.pnlTotal.TabIndex = 26;
            this.pnlTotal.MouseEnter += new System.EventHandler(this.pnlTotal_MouseEnter_1);
            this.pnlTotal.MouseLeave += new System.EventHandler(this.pnlTotal_MouseLeave_1);
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitle.Location = new System.Drawing.Point(93, 12);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(160, 25);
            this.lblTotalTitle.TabIndex = 0;
            this.lblTotalTitle.Text = "TỔNG SINH VIÊN";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(145, 33);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 65);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0";
            // 
            // lblMale
            // 
            this.lblMale.AutoSize = true;
            this.lblMale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblMale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMale.ForeColor = System.Drawing.Color.White;
            this.lblMale.Location = new System.Drawing.Point(145, 5);
            this.lblMale.Name = "lblMale";
            this.lblMale.Size = new System.Drawing.Size(57, 84);
            this.lblMale.TabIndex = 0;
            this.lblMale.Text = "Nam\n0 SV\n0%";
            this.lblMale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFemale
            // 
            this.lblFemale.AutoSize = true;
            this.lblFemale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblFemale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFemale.ForeColor = System.Drawing.Color.White;
            this.lblFemale.Location = new System.Drawing.Point(142, 5);
            this.lblFemale.Name = "lblFemale";
            this.lblFemale.Size = new System.Drawing.Size(54, 84);
            this.lblFemale.TabIndex = 0;
            this.lblFemale.Text = "Nữ\n0 SV\n0%";
            this.lblFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblOther.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOther.ForeColor = System.Drawing.Color.White;
            this.lblOther.Location = new System.Drawing.Point(144, 5);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(58, 84);
            this.lblOther.TabIndex = 0;
            this.lblOther.Text = "Khác\n0 SV\n0%";
            this.lblOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlHeader.Controls.Add(this.guna2Panel1);
            this.pnlHeader.Controls.Add(this.guna2Shapes1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1462, 81);
            this.pnlHeader.TabIndex = 0;
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
            this.guna2Panel1.Size = new System.Drawing.Size(234, 54);
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
            this.lblHethong.Size = new System.Drawing.Size(225, 54);
            this.lblHethong.TabIndex = 2;
            this.lblHethong.Text = "THỐNG KÊ";
            // 
            // guna2Shapes1
            // 
            this.guna2Shapes1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Shapes1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.BorderThickness = 0;
            this.guna2Shapes1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.Location = new System.Drawing.Point(200, 11);
            this.guna2Shapes1.Name = "guna2Shapes1";
            this.guna2Shapes1.PolygonSides = 3;
            this.guna2Shapes1.PolygonSkip = 1;
            this.guna2Shapes1.Rotate = 0F;
            this.guna2Shapes1.Size = new System.Drawing.Size(78, 80);
            this.guna2Shapes1.TabIndex = 31;
            this.guna2Shapes1.Text = "guna2Shapes1";
            this.guna2Shapes1.Zoom = 80;
            // 
            // pnlFemale
            // 
            this.pnlFemale.BackColor = System.Drawing.Color.Transparent;
            this.pnlFemale.BorderRadius = 20;
            this.pnlFemale.BorderThickness = 2;
            this.pnlFemale.Controls.Add(this.lblFemale);
            this.pnlFemale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlFemale.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.pnlFemale.Location = new System.Drawing.Point(729, 5);
            this.pnlFemale.Name = "pnlFemale";
            this.pnlFemale.ShadowDecoration.BorderRadius = 20;
            this.pnlFemale.ShadowDecoration.Depth = 10;
            this.pnlFemale.ShadowDecoration.Enabled = true;
            this.pnlFemale.Size = new System.Drawing.Size(338, 100);
            this.pnlFemale.TabIndex = 28;
            // 
            // pnlOther
            // 
            this.pnlOther.BackColor = System.Drawing.Color.Transparent;
            this.pnlOther.BorderRadius = 20;
            this.pnlOther.BorderThickness = 2;
            this.pnlOther.Controls.Add(this.lblOther);
            this.pnlOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlOther.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.pnlOther.Location = new System.Drawing.Point(1091, 3);
            this.pnlOther.Name = "pnlOther";
            this.pnlOther.ShadowDecoration.BorderRadius = 20;
            this.pnlOther.ShadowDecoration.Depth = 10;
            this.pnlOther.ShadowDecoration.Enabled = true;
            this.pnlOther.Size = new System.Drawing.Size(338, 100);
            this.pnlOther.TabIndex = 29;
            // 
            // btnAIDashboard
            // 
            this.btnAIDashboard.Animated = true;
            this.btnAIDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnAIDashboard.BorderColor = System.Drawing.Color.Transparent;
            this.btnAIDashboard.BorderRadius = 15;
            this.btnAIDashboard.BorderThickness = 1;
            this.btnAIDashboard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAIDashboard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAIDashboard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAIDashboard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAIDashboard.FillColor = System.Drawing.Color.Indigo;
            this.btnAIDashboard.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAIDashboard.ForeColor = System.Drawing.Color.White;
            this.btnAIDashboard.HoverState.FillColor = System.Drawing.Color.SlateBlue;
            this.btnAIDashboard.Location = new System.Drawing.Point(430, 6);
            this.btnAIDashboard.Name = "btnAIDashboard";
            this.btnAIDashboard.PressedDepth = 100;
            this.btnAIDashboard.ShadowDecoration.BorderRadius = 18;
            this.btnAIDashboard.ShadowDecoration.Depth = 10;
            this.btnAIDashboard.ShadowDecoration.Enabled = true;
            this.btnAIDashboard.Size = new System.Drawing.Size(343, 33);
            this.btnAIDashboard.TabIndex = 31;
            this.btnAIDashboard.Text = "📊 AI Insight - Phân tích xu hướng";
            this.btnAIDashboard.Click += new System.EventHandler(this.btnAIDashboard_Click_1);
            // 
            // btnAIPredict
            // 
            this.btnAIPredict.Animated = true;
            this.btnAIPredict.BackColor = System.Drawing.Color.Transparent;
            this.btnAIPredict.BorderColor = System.Drawing.Color.Transparent;
            this.btnAIPredict.BorderRadius = 15;
            this.btnAIPredict.BorderThickness = 1;
            this.btnAIPredict.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAIPredict.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAIPredict.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAIPredict.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAIPredict.FillColor = System.Drawing.Color.DarkCyan;
            this.btnAIPredict.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAIPredict.ForeColor = System.Drawing.Color.White;
            this.btnAIPredict.HoverState.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnAIPredict.Location = new System.Drawing.Point(817, 6);
            this.btnAIPredict.Name = "btnAIPredict";
            this.btnAIPredict.PressedDepth = 100;
            this.btnAIPredict.ShadowDecoration.BorderRadius = 18;
            this.btnAIPredict.ShadowDecoration.Depth = 10;
            this.btnAIPredict.ShadowDecoration.Enabled = true;
            this.btnAIPredict.Size = new System.Drawing.Size(283, 33);
            this.btnAIPredict.TabIndex = 30;
            this.btnAIPredict.Text = "📐 AI Đề xuất TC/Tuần (CDIO)";
            this.btnAIPredict.Click += new System.EventHandler(this.btnAICDIO_Click);
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
            this.btnRefresh.FillColor = System.Drawing.Color.Gainsboro;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1209, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PressedDepth = 100;
            this.btnRefresh.ShadowDecoration.BorderRadius = 18;
            this.btnRefresh.ShadowDecoration.Depth = 10;
            this.btnRefresh.ShadowDecoration.Enabled = true;
            this.btnRefresh.Size = new System.Drawing.Size(220, 31);
            this.btnRefresh.TabIndex = 38;
            this.btnRefresh.Text = "🔄 LÀM MỚI";
            // 
            // f_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "f_Statistic";
            this.Size = new System.Drawing.Size(1462, 957);
            this.Load += new System.EventHandler(this.f_Statistic_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNam)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlMale.ResumeLayout(false);
            this.pnlMale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNam)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.pnlFemale.ResumeLayout(false);
            this.pnlFemale.PerformLayout();
            this.pnlOther.ResumeLayout(false);
            this.pnlOther.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMale;
        private System.Windows.Forms.Label lblFemale;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTongSV;
        private System.Windows.Forms.Label lblTongMon;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblTitleTable;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblTitleDetail;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblThongKeNam;
        private System.Windows.Forms.DataGridView dgvNam;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNam;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGpa;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        private System.Windows.Forms.Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblHethong;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
        private Guna.UI2.WinForms.Guna2Panel pnlTotal;
        private Guna.UI2.WinForms.Guna2Panel pnlMale;
        private Guna.UI2.WinForms.Guna2Panel pnlFemale;
        private Guna.UI2.WinForms.Guna2Panel pnlOther;
        private Guna.UI2.WinForms.Guna2Button btnAIDashboard;
        private Guna.UI2.WinForms.Guna2Button btnAIPredict;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
    }
}