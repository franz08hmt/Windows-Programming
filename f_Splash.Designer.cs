namespace QuanLySinhVien
{
    partial class f_Splash
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
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblSchool = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();

            // picLogo
            this.picLogo.Location = new System.Drawing.Point(185, 40);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(90, 90);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.BackColor = System.Drawing.Color.Transparent;

            // lblSchool
            this.lblSchool.AutoSize = false;
            this.lblSchool.Location = new System.Drawing.Point(20, 140);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(420, 30);
            this.lblSchool.Text = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ KỸ THUẬT TP.HCM";
            this.lblSchool.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular);
            this.lblSchool.ForeColor = System.Drawing.Color.FromArgb(200, 220, 255);
            this.lblSchool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSchool.BackColor = System.Drawing.Color.Transparent;

            // lblAppName
            this.lblAppName.AutoSize = false;
            this.lblAppName.Location = new System.Drawing.Point(20, 170);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(420, 50);
            this.lblAppName.Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 20f, System.Drawing.FontStyle.Bold);
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAppName.BackColor = System.Drawing.Color.Transparent;

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(40, 270);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(380, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(0, 200, 150);
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(0, 40, 100);

            // lblStatus
            this.lblStatus.AutoSize = false;
            this.lblStatus.Location = new System.Drawing.Point(40, 295);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(380, 22);
            this.lblStatus.Text = "Đang khởi tạo hệ thống...";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(200, 220, 255);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;

            // lblVersion
            this.lblVersion.AutoSize = false;
            this.lblVersion.Location = new System.Drawing.Point(40, 330);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(380, 20);
            this.lblVersion.Text = "v1.0 — WIPR 2025–2026 — Huỳnh Minh Tài";
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Italic);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(150, 180, 220);
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;

            // f_Splash
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 360);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblSchool);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "f_Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading...";
            this.Load += new System.EventHandler(this.f_Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblVersion;
    }
}
