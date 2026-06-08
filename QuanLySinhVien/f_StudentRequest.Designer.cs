namespace QuanLySinhVien
{
    partial class f_StudentRequest
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMSSVLabel = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvMyRequests = new System.Windows.Forms.DataGridView();
            this.lblNoteLabel = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(90, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(453, 38);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "YÊU CẦU XÁC NHẬN THÔNG TIN";
            // 
            // lblMSSVLabel
            // 
            this.lblMSSVLabel.AutoSize = true;
            this.lblMSSVLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMSSVLabel.Location = new System.Drawing.Point(15, 98);
            this.lblMSSVLabel.Name = "lblMSSVLabel";
            this.lblMSSVLabel.Size = new System.Drawing.Size(151, 28);
            this.lblMSSVLabel.TabIndex = 1;
            this.lblMSSVLabel.Text = "MSSV của bạn:";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMSSV.Location = new System.Drawing.Point(172, 95);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(180, 34);
            this.txtMSSV.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(387, 95);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 30);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "🔍 Xem lịch sử";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.lblStatus.Location = new System.Drawing.Point(15, 135);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(325, 28);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Nhập MSSV và nhấn Xem lịch sử.";
            // 
            // dgvMyRequests
            // 
            this.dgvMyRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMyRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyRequests.Location = new System.Drawing.Point(15, 163);
            this.dgvMyRequests.Name = "dgvMyRequests";
            this.dgvMyRequests.RowHeadersWidth = 62;
            this.dgvMyRequests.RowTemplate.Height = 30;
            this.dgvMyRequests.Size = new System.Drawing.Size(770, 220);
            this.dgvMyRequests.TabIndex = 2;
            // 
            // lblNoteLabel
            // 
            this.lblNoteLabel.AutoSize = true;
            this.lblNoteLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNoteLabel.Location = new System.Drawing.Point(15, 400);
            this.lblNoteLabel.Name = "lblNoteLabel";
            this.lblNoteLabel.Size = new System.Drawing.Size(287, 28);
            this.lblNoteLabel.TabIndex = 3;
            this.lblNoteLabel.Text = "Nội dung yêu cầu (tuỳ chọn):";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNote.Location = new System.Drawing.Point(15, 430);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(770, 34);
            this.txtNote.TabIndex = 3;
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnSendRequest.FlatAppearance.BorderSize = 0;
            this.btnSendRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendRequest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendRequest.ForeColor = System.Drawing.Color.White;
            this.btnSendRequest.Location = new System.Drawing.Point(190, 475);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(180, 45);
            this.btnSendRequest.TabIndex = 4;
            this.btnSendRequest.Text = "📨 GỬI YÊU CẦU";
            this.btnSendRequest.UseVisualStyleBackColor = false;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(410, 475);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 45);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "✖ ĐÓNG";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ptLgo
            // 
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(80, 80);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabIndex = 0;
            this.ptLgo.TabStop = false;
            // 
            // f_StudentRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 540);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblMSSVLabel);
            this.Controls.Add(this.txtMSSV);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvMyRequests);
            this.Controls.Add(this.lblNoteLabel);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.btnClose);
            this.Name = "f_StudentRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yêu cầu xác nhận thông tin";
            this.Load += new System.EventHandler(this.f_StudentRequest_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMSSVLabel;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dgvMyRequests;
        private System.Windows.Forms.Label lblNoteLabel;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.Button btnClose;
    }
}