namespace QuanLySinhVien
{
    partial class f_ManageRequest
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
            this.pnlHeaderUTE = new System.Windows.Forms.Panel();
            this.lblTitleUTE = new System.Windows.Forms.Label();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.pnlFooterAction = new System.Windows.Forms.Panel();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlHeaderUTE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.pnlFooterAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeaderUTE
            // 
            this.pnlHeaderUTE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(90)))), ((int)(((byte)(160)))));
            this.pnlHeaderUTE.Controls.Add(this.pictureBox1);
            this.pnlHeaderUTE.Controls.Add(this.lblTitleUTE);
            this.pnlHeaderUTE.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderUTE.Location = new System.Drawing.Point(0, 0);
            this.pnlHeaderUTE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlHeaderUTE.Name = "pnlHeaderUTE";
            this.pnlHeaderUTE.Size = new System.Drawing.Size(1200, 92);
            this.pnlHeaderUTE.TabIndex = 3;
            // 
            // lblTitleUTE
            // 
            this.lblTitleUTE.AutoSize = true;
            this.lblTitleUTE.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleUTE.ForeColor = System.Drawing.Color.White;
            this.lblTitleUTE.Location = new System.Drawing.Point(94, 21);
            this.lblTitleUTE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitleUTE.Name = "lblTitleUTE";
            this.lblTitleUTE.Size = new System.Drawing.Size(467, 45);
            this.lblTitleUTE.TabIndex = 0;
            this.lblTitleUTE.Text = "CỔNG PHÊ DUYỆT XÁC MINH";
            // 
            // dgvRequests
            // 
            this.dgvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequests.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Location = new System.Drawing.Point(18, 115);
            this.dgvRequests.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.Size = new System.Drawing.Size(1164, 456);
            this.dgvRequests.TabIndex = 0;
            // 
            // pnlFooterAction
            // 
            this.pnlFooterAction.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooterAction.Controls.Add(this.btnApprove);
            this.pnlFooterAction.Controls.Add(this.btnDecline);
            this.pnlFooterAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooterAction.Location = new System.Drawing.Point(0, 592);
            this.pnlFooterAction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlFooterAction.Name = "pnlFooterAction";
            this.pnlFooterAction.Size = new System.Drawing.Size(1200, 100);
            this.pnlFooterAction.TabIndex = 4;
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(261, 19);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(300, 62);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "APPROVE (Chấp nhận)";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDecline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecline.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDecline.ForeColor = System.Drawing.Color.White;
            this.btnDecline.Location = new System.Drawing.Point(639, 19);
            this.btnDecline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(300, 62);
            this.btnDecline.TabIndex = 2;
            this.btnDecline.Text = "DECLINE (Từ chối)";
            this.btnDecline.UseVisualStyleBackColor = false;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // f_ManageRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.pnlFooterAction);
            this.Controls.Add(this.pnlHeaderUTE);
            this.Controls.Add(this.dgvRequests);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "f_ManageRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý yêu cầu xác thực";
            this.Load += new System.EventHandler(this.f_ManageRequest_Load);
            this.pnlHeaderUTE.ResumeLayout(false);
            this.pnlHeaderUTE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.pnlFooterAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.Panel pnlHeaderUTE;
        private System.Windows.Forms.Label lblTitleUTE;
        private System.Windows.Forms.Panel pnlFooterAction;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}