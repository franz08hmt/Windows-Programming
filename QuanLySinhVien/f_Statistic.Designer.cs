namespace QuanLySinhVien
{
    partial class f_Statistic
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGpa = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAIPredict = new System.Windows.Forms.Button();
            this.btnAIDashboard = new System.Windows.Forms.Button();
            this.chartNam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblTitleDetail = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.lblTitleTable = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblThongKeNam = new System.Windows.Forms.Label();
            this.dgvNam = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTongSV = new System.Windows.Forms.Label();
            this.lblTongMon = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlMale = new System.Windows.Forms.Panel();
            this.lblMale = new System.Windows.Forms.Label();
            this.pnlFemale = new System.Windows.Forms.Panel();
            this.lblFemale = new System.Windows.Forms.Label();
            this.pnlOther = new System.Windows.Forms.Panel();
            this.lblOther = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNam)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNam)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlMale.SuspendLayout();
            this.pnlFemale.SuspendLayout();
            this.pnlOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1177, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1037, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 90);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ptLogo
            // 
            this.ptLogo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLogo.Location = new System.Drawing.Point(0, 0);
            this.ptLogo.Name = "ptLogo";
            this.ptLogo.Size = new System.Drawing.Size(84, 90);
            this.ptLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLogo.TabIndex = 1;
            this.ptLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(90, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(358, 45);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "THỐNG KÊ - BÁO CÁO";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Controls.Add(this.pnlCards);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(1177, 918);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.pnlRight);
            this.pnlContent.Controls.Add(this.pnlLeft);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 160);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1147, 743);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.chartPie);
            this.pnlRight.Controls.Add(this.chartGpa);
            this.pnlRight.Controls.Add(this.btnAIPredict);
            this.pnlRight.Controls.Add(this.btnAIDashboard);
            this.pnlRight.Controls.Add(this.chartNam);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(420, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(727, 743);
            this.pnlRight.TabIndex = 1;
            // 
            // chartPie
            // 
            chartArea1.Name = "ChartArea2";
            this.chartPie.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend2";
            this.chartPie.Legends.Add(legend1);
            this.chartPie.Location = new System.Drawing.Point(10, 241);
            this.chartPie.Name = "chartPie";
            this.chartPie.Size = new System.Drawing.Size(730, 197);
            this.chartPie.TabIndex = 1;
            // 
            // chartGpa
            // 
            chartArea2.Name = "ChartArea1";
            this.chartGpa.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartGpa.Legends.Add(legend2);
            this.chartGpa.Location = new System.Drawing.Point(10, 6);
            this.chartGpa.Name = "chartGpa";
            this.chartGpa.Size = new System.Drawing.Size(730, 232);
            this.chartGpa.TabIndex = 0;
            // 
            // btnAIPredict
            // 
            this.btnAIPredict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAIPredict.FlatAppearance.BorderSize = 0;
            this.btnAIPredict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIPredict.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAIPredict.ForeColor = System.Drawing.Color.White;
            this.btnAIPredict.Location = new System.Drawing.Point(370, 690);
            this.btnAIPredict.Name = "btnAIPredict";
            this.btnAIPredict.Size = new System.Drawing.Size(335, 38);
            this.btnAIPredict.TabIndex = 2;
            this.btnAIPredict.Text = "🔮 AI Dự đoán số lượng năm sau";
            this.btnAIPredict.UseVisualStyleBackColor = false;
            this.btnAIPredict.Click += new System.EventHandler(this.btnAIPredict_Click);
            // 
            // btnAIDashboard
            // 
            this.btnAIDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(90)))), ((int)(((byte)(205)))));
            this.btnAIDashboard.FlatAppearance.BorderSize = 0;
            this.btnAIDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIDashboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAIDashboard.ForeColor = System.Drawing.Color.White;
            this.btnAIDashboard.Location = new System.Drawing.Point(10, 690);
            this.btnAIDashboard.Name = "btnAIDashboard";
            this.btnAIDashboard.Size = new System.Drawing.Size(337, 38);
            this.btnAIDashboard.TabIndex = 3;
            this.btnAIDashboard.Text = "📊 AI Insight - Phân tích xu hướng";
            this.btnAIDashboard.UseVisualStyleBackColor = false;
            this.btnAIDashboard.Click += new System.EventHandler(this.btnAIDashboard_Click);
            // 
            // chartNam
            // 
            chartArea3.Name = "ChartArea3";
            this.chartNam.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend3";
            this.chartNam.Legends.Add(legend3);
            this.chartNam.Location = new System.Drawing.Point(10, 444);
            this.chartNam.Name = "chartNam";
            this.chartNam.Size = new System.Drawing.Size(720, 240);
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
            this.pnlLeft.Size = new System.Drawing.Size(420, 743);
            this.pnlLeft.TabIndex = 0;
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
            this.dgvNam.Location = new System.Drawing.Point(10, 495);
            this.dgvNam.Name = "dgvNam";
            this.dgvNam.ReadOnly = true;
            this.dgvNam.RowHeadersWidth = 40;
            this.dgvNam.RowTemplate.Height = 28;
            this.dgvNam.Size = new System.Drawing.Size(400, 150);
            this.dgvNam.TabIndex = 4;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.lblTongSV);
            this.pnlTop.Controls.Add(this.lblTongMon);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 115);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1147, 45);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTongSV
            // 
            this.lblTongSV.AutoSize = true;
            this.lblTongSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblTongSV.Location = new System.Drawing.Point(0, 10);
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
            this.lblTongMon.Location = new System.Drawing.Point(280, 10);
            this.lblTongMon.Name = "lblTongMon";
            this.lblTongMon.Size = new System.Drawing.Size(171, 28);
            this.lblTongMon.TabIndex = 1;
            this.lblTongMon.Text = "Tổng môn học: 0";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(959, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(166, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.Transparent;
            this.pnlCards.Controls.Add(this.pnlTotal);
            this.pnlCards.Controls.Add(this.pnlMale);
            this.pnlCards.Controls.Add(this.pnlFemale);
            this.pnlCards.Controls.Add(this.pnlOther);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(15, 15);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(1147, 100);
            this.pnlCards.TabIndex = 0;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlTotal.Controls.Add(this.lblTotalTitle);
            this.pnlTotal.Controls.Add(this.lblTotal);
            this.pnlTotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlTotal.Location = new System.Drawing.Point(0, 5);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(270, 85);
            this.pnlTotal.TabIndex = 0;
            this.pnlTotal.MouseEnter += new System.EventHandler(this.pnlTotal_MouseEnter);
            this.pnlTotal.MouseLeave += new System.EventHandler(this.pnlTotal_MouseLeave);
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitle.Location = new System.Drawing.Point(10, 8);
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
            this.lblTotal.Location = new System.Drawing.Point(90, 30);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 65);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "0";
            // 
            // pnlMale
            // 
            this.pnlMale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlMale.Controls.Add(this.lblMale);
            this.pnlMale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMale.Location = new System.Drawing.Point(285, 5);
            this.pnlMale.Name = "pnlMale";
            this.pnlMale.Size = new System.Drawing.Size(270, 85);
            this.pnlMale.TabIndex = 1;
            this.pnlMale.MouseEnter += new System.EventHandler(this.pnlMale_MouseEnter);
            this.pnlMale.MouseLeave += new System.EventHandler(this.pnlMale_MouseLeave);
            // 
            // lblMale
            // 
            this.lblMale.AutoSize = true;
            this.lblMale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblMale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMale.ForeColor = System.Drawing.Color.White;
            this.lblMale.Location = new System.Drawing.Point(91, 0);
            this.lblMale.Name = "lblMale";
            this.lblMale.Size = new System.Drawing.Size(57, 84);
            this.lblMale.TabIndex = 0;
            this.lblMale.Text = "Nam\n0 SV\n0%";
            this.lblMale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFemale
            // 
            this.pnlFemale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.pnlFemale.Controls.Add(this.lblFemale);
            this.pnlFemale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlFemale.Location = new System.Drawing.Point(570, 5);
            this.pnlFemale.Name = "pnlFemale";
            this.pnlFemale.Size = new System.Drawing.Size(270, 85);
            this.pnlFemale.TabIndex = 2;
            this.pnlFemale.MouseEnter += new System.EventHandler(this.pnlFemale_MouseEnter);
            this.pnlFemale.MouseLeave += new System.EventHandler(this.pnlFemale_MouseLeave);
            // 
            // lblFemale
            // 
            this.lblFemale.AutoSize = true;
            this.lblFemale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblFemale.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFemale.ForeColor = System.Drawing.Color.White;
            this.lblFemale.Location = new System.Drawing.Point(96, 1);
            this.lblFemale.Name = "lblFemale";
            this.lblFemale.Size = new System.Drawing.Size(54, 84);
            this.lblFemale.TabIndex = 0;
            this.lblFemale.Text = "Nữ\n0 SV\n0%";
            this.lblFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOther
            // 
            this.pnlOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.pnlOther.Controls.Add(this.lblOther);
            this.pnlOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlOther.Location = new System.Drawing.Point(855, 5);
            this.pnlOther.Name = "pnlOther";
            this.pnlOther.Size = new System.Drawing.Size(270, 85);
            this.pnlOther.TabIndex = 3;
            this.pnlOther.MouseEnter += new System.EventHandler(this.pnlOther_MouseEnter);
            this.pnlOther.MouseLeave += new System.EventHandler(this.pnlOther_MouseLeave);
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblOther.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOther.ForeColor = System.Drawing.Color.White;
            this.lblOther.Location = new System.Drawing.Point(90, 1);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(58, 84);
            this.lblOther.TabIndex = 0;
            this.lblOther.Text = "Khác\n0 SV\n0%";
            this.lblOther.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // f_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 1008);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "f_Statistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê - Báo cáo";
            this.Load += new System.EventHandler(this.f_Statistic_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNam)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNam)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.pnlMale.ResumeLayout(false);
            this.pnlMale.PerformLayout();
            this.pnlFemale.ResumeLayout(false);
            this.pnlFemale.PerformLayout();
            this.pnlOther.ResumeLayout(false);
            this.pnlOther.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox ptLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlMale;
        private System.Windows.Forms.Label lblMale;
        private System.Windows.Forms.Panel pnlFemale;
        private System.Windows.Forms.Label lblFemale;
        private System.Windows.Forms.Panel pnlOther;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTongSV;
        private System.Windows.Forms.Label lblTongMon;
        private System.Windows.Forms.Button btnRefresh;
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
        private System.Windows.Forms.Button btnAIDashboard;
        private System.Windows.Forms.Button btnAIPredict;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGpa;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
    }
}