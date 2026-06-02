namespace QuanLySinhVien
{
    partial class f_OTP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_OTP));
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBackLogin = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblXacnhanotp = new System.Windows.Forms.Label();
            this.ptGmail = new System.Windows.Forms.PictureBox();
            this.lblTongQuan = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnResend = new System.Windows.Forms.Button();
            this.timerOTP = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptGmail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(134, 166);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(159, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Nhập mã OTP đã gửi về email:";
            // 
            // txtOTP
            // 
            this.txtOTP.Location = new System.Drawing.Point(190, 229);
            this.txtOTP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(146, 20);
            this.txtOTP.TabIndex = 1;
            this.txtOTP.TextChanged += new System.EventHandler(this.txtOTP_TextChanged);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(151, 252);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(111, 32);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBackLogin);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblXacnhanotp);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(533, 58);
            this.pnlHeader.TabIndex = 16;
            // 
            // btnBackLogin
            // 
            this.btnBackLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBackLogin.FlatAppearance.BorderSize = 0;
            this.btnBackLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnBackLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnBackLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackLogin.ForeColor = System.Drawing.Color.White;
            this.btnBackLogin.Location = new System.Drawing.Point(442, 0);
            this.btnBackLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBackLogin.Name = "btnBackLogin";
            this.btnBackLogin.Size = new System.Drawing.Size(91, 58);
            this.btnBackLogin.TabIndex = 4;
            this.btnBackLogin.Text = "⬅ Quay lại";
            this.btnBackLogin.UseVisualStyleBackColor = false;
            this.btnBackLogin.Click += new System.EventHandler(this.btnBackLogin_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(561, 0);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(91, 58);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "<- Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // ptLgo
            // 
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(56, 58);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabIndex = 1;
            this.ptLgo.TabStop = false;
            // 
            // lblXacnhanotp
            // 
            this.lblXacnhanotp.AutoSize = true;
            this.lblXacnhanotp.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblXacnhanotp.ForeColor = System.Drawing.Color.White;
            this.lblXacnhanotp.Location = new System.Drawing.Point(58, 14);
            this.lblXacnhanotp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblXacnhanotp.Name = "lblXacnhanotp";
            this.lblXacnhanotp.Size = new System.Drawing.Size(195, 32);
            this.lblXacnhanotp.TabIndex = 0;
            this.lblXacnhanotp.Text = "XÁC NHẬN OTP";
            // 
            // ptGmail
            // 
            this.ptGmail.Image = ((System.Drawing.Image)(resources.GetObject("ptGmail.Image")));
            this.ptGmail.Location = new System.Drawing.Point(235, 62);
            this.ptGmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptGmail.Name = "ptGmail";
            this.ptGmail.Size = new System.Drawing.Size(67, 65);
            this.ptGmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptGmail.TabIndex = 17;
            this.ptGmail.TabStop = false;
            // 
            // lblTongQuan
            // 
            this.lblTongQuan.AutoSize = true;
            this.lblTongQuan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongQuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.lblTongQuan.Location = new System.Drawing.Point(203, 136);
            this.lblTongQuan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongQuan.Name = "lblTongQuan";
            this.lblTongQuan.Size = new System.Drawing.Size(133, 25);
            this.lblTongQuan.TabIndex = 18;
            this.lblTongQuan.Text = "Nhập mã OTP";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTimer.Location = new System.Drawing.Point(227, 186);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(43, 13);
            this.lblTimer.TabIndex = 19;
            this.lblTimer.Text = "Còn lại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.label3.Location = new System.Drawing.Point(227, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mã OTP (6 số)";
            // 
            // btnResend
            // 
            this.btnResend.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnResend.Location = new System.Drawing.Point(266, 252);
            this.btnResend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(111, 32);
            this.btnResend.TabIndex = 21;
            this.btnResend.Text = "Gửi lại";
            this.btnResend.UseVisualStyleBackColor = true;
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click);
            // 
            // timerOTP
            // 
            this.timerOTP.Interval = 1000;
            this.timerOTP.Tick += new System.EventHandler(this.timerOTP_Tick);
            // 
            // f_OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.btnResend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblTongQuan);
            this.Controls.Add(this.ptGmail);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.lblMessage);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "f_OTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_OTP";
            this.Load += new System.EventHandler(this.f_OTP_Load_1);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptGmail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblXacnhanotp;
        private System.Windows.Forms.PictureBox ptGmail;
        private System.Windows.Forms.Label lblTongQuan;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBackLogin;
        private System.Windows.Forms.Button btnResend;
        private System.Windows.Forms.Timer timerOTP;
    }
}