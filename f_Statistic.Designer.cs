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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 =
                new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 =
                new System.Windows.Forms.DataVisualization.Charting.Legend();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.ptLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTongSV = new System.Windows.Forms.Label();
            this.lblTongMon = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblTitleTable = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblTitleDetail = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.chartGpa = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpa)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ──
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLogo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 90);
            this.pnlHeader.TabIndex = 0;

            // ptLogo
            this.ptLogo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLogo.Location = new System.Drawing.Point(0, 0);
            this.ptLogo.Name = "ptLogo";
            this.ptLogo.Size = new System.Drawing.Size(84, 90);
            this.ptLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLogo.TabIndex = 0;
            this.ptLogo.TabStop = false;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(90, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "THỐNG KÊ - BÁO CÁO";

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 85, 155);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(970, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 90);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "<- Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ── pnlMain ──
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15);
            this.pnlMain.Size = new System.Drawing.Size(1100, 560);
            this.pnlMain.TabIndex = 1;

            // ── pnlTop (summary cards) ──
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.lblTongSV);
            this.pnlTop.Controls.Add(this.lblTongMon);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(15, 15);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1070, 50);
            this.pnlTop.TabIndex = 0;

            // lblTongSV
            this.lblTongSV.AutoSize = true;
            this.lblTongSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongSV.ForeColor = System.Drawing.Color.FromArgb(21, 67, 137);
            this.lblTongSV.Location = new System.Drawing.Point(0, 12);
            this.lblTongSV.Name = "lblTongSV";
            this.lblTongSV.TabIndex = 0;
            this.lblTongSV.Text = "Tổng SV có điểm: 0";

            // lblTongMon
            this.lblTongMon.AutoSize = true;
            this.lblTongMon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongMon.ForeColor = System.Drawing.Color.FromArgb(21, 67, 137);
            this.lblTongMon.Location = new System.Drawing.Point(250, 12);
            this.lblTongMon.Name = "lblTongMon";
            this.lblTongMon.TabIndex = 1;
            this.lblTongMon.Text = "Tổng môn học: 0";

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(21, 67, 137);
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(950, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // ── pnlContent ──
            this.pnlContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlContent.Controls.Add(this.pnlRight);
            this.pnlContent.Controls.Add(this.pnlLeft);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(15, 65);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1070, 480);
            this.pnlContent.TabIndex = 1;

            // ── pnlLeft ──
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.lblTitleDetail);
            this.pnlLeft.Controls.Add(this.dgvDetail);
            this.pnlLeft.Controls.Add(this.lblTitleTable);
            this.pnlLeft.Controls.Add(this.dgvReport);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            this.pnlLeft.Size = new System.Drawing.Size(420, 480);
            this.pnlLeft.TabIndex = 0;

            // lblTitleTable
            this.lblTitleTable.AutoSize = true;
            this.lblTitleTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleTable.ForeColor = System.Drawing.Color.FromArgb(21, 67, 137);
            this.lblTitleTable.Location = new System.Drawing.Point(10, 10);
            this.lblTitleTable.Name = "lblTitleTable";
            this.lblTitleTable.TabIndex = 0;
            this.lblTitleTable.Text = "THỐNG KÊ XẾP LOẠI";

            // dgvReport
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(10, 35);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 40;
            this.dgvReport.RowTemplate.Height = 30;
            this.dgvReport.Size = new System.Drawing.Size(400, 180);
            this.dgvReport.TabIndex = 1;

            // lblTitleDetail
            this.lblTitleDetail.AutoSize = true;
            this.lblTitleDetail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTitleDetail.ForeColor = System.Drawing.Color.FromArgb(21, 67, 137);
            this.lblTitleDetail.Location = new System.Drawing.Point(10, 225);
            this.lblTitleDetail.Name = "lblTitleDetail";
            this.lblTitleDetail.TabIndex = 2;
            this.lblTitleDetail.Text = "ĐIỂM TRUNG BÌNH TỪNG SINH VIÊN";

            // dgvDetail
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(10, 250);
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 40;
            this.dgvDetail.RowTemplate.Height = 30;
            this.dgvDetail.Size = new System.Drawing.Size(400, 215);
            this.dgvDetail.TabIndex = 3;

            // ── pnlRight ──
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.chartGpa);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(420, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(10);
            this.pnlRight.Size = new System.Drawing.Size(650, 480);
            this.pnlRight.TabIndex = 1;

            // chartGpa
            chartArea1.Name = "ChartArea1";
            this.chartGpa.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGpa.Legends.Add(legend1);
            this.chartGpa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGpa.Location = new System.Drawing.Point(10, 10);
            this.chartGpa.Name = "chartGpa";
            this.chartGpa.Size = new System.Drawing.Size(630, 460);
            this.chartGpa.TabIndex = 0;
            this.chartGpa.Text = "chartGpa";

            // ── f_Statistic ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
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
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartGpa)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox ptLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlMain;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGpa;
    }
}