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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBackLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblXacnhanotp = new System.Windows.Forms.Label();
            this.ptGmail = new System.Windows.Forms.PictureBox();
            this.lblTongQuan = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerOTP = new System.Windows.Forms.Timer(this.components);
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.txtOTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnResend = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptGmail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(201, 256);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(218, 21);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Nhập mã OTP đã gửi về email:";
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
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 90);
            this.pnlHeader.TabIndex = 16;
            // 
            // btnBackLogin
            // 
            this.btnBackLogin.Animated = true;
            this.btnBackLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnBackLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnBackLogin.BorderRadius = 15;
            this.btnBackLogin.BorderThickness = 2;
            this.btnBackLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBackLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBackLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBackLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBackLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBackLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnBackLogin.ForeColor = System.Drawing.Color.White;
            this.btnBackLogin.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnBackLogin.Location = new System.Drawing.Point(663, 4);
            this.btnBackLogin.Name = "btnBackLogin";
            this.btnBackLogin.PressedDepth = 100;
            this.btnBackLogin.ShadowDecoration.BorderRadius = 18;
            this.btnBackLogin.ShadowDecoration.Depth = 10;
            this.btnBackLogin.ShadowDecoration.Enabled = true;
            this.btnBackLogin.Size = new System.Drawing.Size(137, 83);
            this.btnBackLogin.TabIndex = 33;
            this.btnBackLogin.Text = "🡰 Quay lại";
            this.btnBackLogin.Click += new System.EventHandler(this.btnBackLogin_Click_1);
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
            this.btnBack.Location = new System.Drawing.Point(841, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 90);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "<- Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // ptLgo
            // 
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(84, 90);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabIndex = 1;
            this.ptLgo.TabStop = false;
            // 
            // lblXacnhanotp
            // 
            this.lblXacnhanotp.AutoSize = true;
            this.lblXacnhanotp.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXacnhanotp.ForeColor = System.Drawing.Color.White;
            this.lblXacnhanotp.Location = new System.Drawing.Point(81, 22);
            this.lblXacnhanotp.Name = "lblXacnhanotp";
            this.lblXacnhanotp.Size = new System.Drawing.Size(262, 45);
            this.lblXacnhanotp.TabIndex = 0;
            this.lblXacnhanotp.Text = "XÁC NHẬN OTP";
            // 
            // ptGmail
            // 
            this.ptGmail.Image = ((System.Drawing.Image)(resources.GetObject("ptGmail.Image")));
            this.ptGmail.Location = new System.Drawing.Point(353, 96);
            this.ptGmail.Name = "ptGmail";
            this.ptGmail.Size = new System.Drawing.Size(100, 100);
            this.ptGmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptGmail.TabIndex = 17;
            this.ptGmail.TabStop = false;
            // 
            // lblTongQuan
            // 
            this.lblTongQuan.AutoSize = true;
            this.lblTongQuan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongQuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.lblTongQuan.Location = new System.Drawing.Point(304, 209);
            this.lblTongQuan.Name = "lblTongQuan";
            this.lblTongQuan.Size = new System.Drawing.Size(198, 38);
            this.lblTongQuan.TabIndex = 18;
            this.lblTongQuan.Text = "Nhập mã OTP";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTimer.Location = new System.Drawing.Point(341, 286);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(63, 21);
            this.lblTimer.TabIndex = 19;
            this.lblTimer.Text = "Còn lại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.label3.Location = new System.Drawing.Point(341, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "Mã OTP (6 số)";
            // 
            // timerOTP
            // 
            this.timerOTP.Interval = 1000;
            this.timerOTP.Tick += new System.EventHandler(this.timerOTP_Tick);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Animated = true;
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm.BorderRadius = 10;
            this.btnConfirm.BorderThickness = 2;
            this.btnConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.btnConfirm.Location = new System.Drawing.Point(238, 388);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.PressedDepth = 100;
            this.btnConfirm.ShadowDecoration.BorderRadius = 15;
            this.btnConfirm.ShadowDecoration.Depth = 10;
            this.btnConfirm.ShadowDecoration.Enabled = true;
            this.btnConfirm.Size = new System.Drawing.Size(166, 50);
            this.btnConfirm.TabIndex = 33;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click_1);
            // 
            // txtOTP
            // 
            this.txtOTP.BorderRadius = 8;
            this.txtOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOTP.DefaultText = "";
            this.txtOTP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOTP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOTP.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtOTP.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtOTP.ForeColor = System.Drawing.Color.Black;
            this.txtOTP.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtOTP.Location = new System.Drawing.Point(275, 345);
            this.txtOTP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.PlaceholderText = "";
            this.txtOTP.SelectedText = "";
            this.txtOTP.Size = new System.Drawing.Size(256, 31);
            this.txtOTP.TabIndex = 34;
            // 
            // btnResend
            // 
            this.btnResend.Animated = true;
            this.btnResend.BackColor = System.Drawing.Color.Transparent;
            this.btnResend.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResend.BorderRadius = 10;
            this.btnResend.BorderThickness = 2;
            this.btnResend.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResend.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResend.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnResend.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnResend.ForeColor = System.Drawing.Color.Black;
            this.btnResend.HoverState.FillColor = System.Drawing.Color.Gray;
            this.btnResend.Location = new System.Drawing.Point(410, 388);
            this.btnResend.Name = "btnResend";
            this.btnResend.PressedDepth = 100;
            this.btnResend.ShadowDecoration.BorderRadius = 15;
            this.btnResend.ShadowDecoration.Depth = 10;
            this.btnResend.ShadowDecoration.Enabled = true;
            this.btnResend.Size = new System.Drawing.Size(166, 50);
            this.btnResend.TabIndex = 35;
            this.btnResend.Text = "Gửi lại";
            this.btnResend.Click += new System.EventHandler(this.btnResend_Click_1);
            // 
            // f_OTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnResend);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblTongQuan);
            this.Controls.Add(this.ptGmail);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblMessage);
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
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblXacnhanotp;
        private System.Windows.Forms.PictureBox ptGmail;
        private System.Windows.Forms.Label lblTongQuan;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerOTP;
        private Guna.UI2.WinForms.Guna2Button btnBackLogin;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2TextBox txtOTP;
        private Guna.UI2.WinForms.Guna2Button btnResend;
    }
}