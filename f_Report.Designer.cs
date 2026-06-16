namespace QuanLySinhVien
{
    partial class f_Report
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.cboReportType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPreview = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportPDF = new Guna.UI2.WinForms.Guna2Button();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────────
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 56;
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Name = "pnlHeader";

            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Text = "BÁO CÁO & XUẤT DỮ LIỆU";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Name = "lblTitle";

            // ── pnlToolbar ─────────────────────────────────────────────────
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 60;
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.btnExportExcel);
            this.pnlToolbar.Controls.Add(this.btnExportPDF);
            this.pnlToolbar.Controls.Add(this.btnPreview);
            this.pnlToolbar.Controls.Add(this.txtSearch);
            this.pnlToolbar.Controls.Add(this.cboReportType);
            this.pnlToolbar.Name = "pnlToolbar";

            // cboReportType
            this.cboReportType.Location = new System.Drawing.Point(10, 13);
            this.cboReportType.Size = new System.Drawing.Size(200, 34);
            this.cboReportType.FillColor = System.Drawing.Color.White;
            this.cboReportType.BorderColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.cboReportType.BorderRadius = 6;
            this.cboReportType.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.Name = "cboReportType";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(220, 13);
            this.txtSearch.Size = new System.Drawing.Size(200, 34);
            this.txtSearch.PlaceholderText = "Tìm kiếm...";
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.txtSearch.BorderRadius = 6;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.txtSearch.Name = "txtSearch";

            // btnPreview
            this.btnPreview.Location = new System.Drawing.Point(432, 13);
            this.btnPreview.Size = new System.Drawing.Size(90, 34);
            this.btnPreview.Text = "Xem trước";
            this.btnPreview.FillColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnPreview.BorderRadius = 6;
            this.btnPreview.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Name = "btnPreview";

            // btnExportPDF
            this.btnExportPDF.Location = new System.Drawing.Point(532, 13);
            this.btnExportPDF.Size = new System.Drawing.Size(100, 34);
            this.btnExportPDF.Text = "Xuất PDF";
            this.btnExportPDF.FillColor = System.Drawing.Color.FromArgb(192, 0, 0);
            this.btnExportPDF.BorderRadius = 6;
            this.btnExportPDF.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Name = "btnExportPDF";

            // btnExportExcel
            this.btnExportExcel.Location = new System.Drawing.Point(642, 13);
            this.btnExportExcel.Size = new System.Drawing.Size(110, 34);
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnExportExcel.BorderRadius = 6;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Name = "btnExportExcel";

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(762, 13);
            this.btnRefresh.Size = new System.Drawing.Size(80, 34);
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnRefresh.BorderRadius = 6;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Name = "btnRefresh";

            // ── pnlBody ────────────────────────────────────────────────────
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBody.Controls.Add(this.dgvReport);
            this.pnlBody.Name = "pnlBody";

            // dgvReport
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.ReadOnly = true;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.EnableHeadersVisualStyles = false;
            this.dgvReport.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            this.dgvReport.ColumnHeadersHeight = 36;
            this.dgvReport.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.dgvReport.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 244, 255);
            this.dgvReport.BackgroundColor = System.Drawing.Color.White;
            this.dgvReport.GridColor = System.Drawing.Color.FromArgb(220, 230, 245);
            this.dgvReport.Name = "dgvReport";

            // ── pnlStatus ──────────────────────────────────────────────────
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatus.Height = 28;
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pnlStatus.Controls.Add(this.lblRowCount);
            this.pnlStatus.Name = "pnlStatus";

            this.lblRowCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRowCount.Text = "Tổng: 0 bản ghi";
            this.lblRowCount.Font = new System.Drawing.Font("Segoe UI", 8f);
            this.lblRowCount.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRowCount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblRowCount.Name = "lblRowCount";

            // ── f_Report ───────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "f_Report";
            this.Size = new System.Drawing.Size(1000, 600);

            this.pnlHeader.ResumeLayout(false);
            this.pnlToolbar.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.pnlStatus.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlToolbar;
        private Guna.UI2.WinForms.Guna2ComboBox cboReportType;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnPreview;
        private Guna.UI2.WinForms.Guna2Button btnExportPDF;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblRowCount;
    }
}
