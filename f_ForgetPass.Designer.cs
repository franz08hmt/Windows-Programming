namespace QuanLySinhVien
{
    partial class f_ForgetPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblQuenmatkhau = new System.Windows.Forms.Label();
            this.lblDatlaimatkhau = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSendOTP = new Guna.UI2.WinForms.Guna2Button();
            this.txtFname = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBackLogin = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(50, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập email để nhận mã OTP đặt lại mật khẩu";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBackLogin);
            this.pnlHeader.Controls.Add(this.txtEmail);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblQuenmatkhau);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(799, 90);
            this.pnlHeader.TabIndex = 17;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.txtEmail.FlatAppearance.BorderSize = 0;
            this.txtEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.txtEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.txtEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(841, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(137, 90);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Text = "<- Quay lại";
            this.txtEmail.UseVisualStyleBackColor = false;
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
            // lblQuenmatkhau
            // 
            this.lblQuenmatkhau.AutoSize = true;
            this.lblQuenmatkhau.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuenmatkhau.ForeColor = System.Drawing.Color.White;
            this.lblQuenmatkhau.Location = new System.Drawing.Point(81, 22);
            this.lblQuenmatkhau.Name = "lblQuenmatkhau";
            this.lblQuenmatkhau.Size = new System.Drawing.Size(292, 45);
            this.lblQuenmatkhau.TabIndex = 0;
            this.lblQuenmatkhau.Text = "QUÊN MẬT KHẨU";
            // 
            // lblDatlaimatkhau
            // 
            this.lblDatlaimatkhau.AutoSize = true;
            this.lblDatlaimatkhau.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDatlaimatkhau.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatlaimatkhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.lblDatlaimatkhau.Location = new System.Drawing.Point(109, 51);
            this.lblDatlaimatkhau.Name = "lblDatlaimatkhau";
            this.lblDatlaimatkhau.Size = new System.Drawing.Size(236, 38);
            this.lblDatlaimatkhau.TabIndex = 19;
            this.lblDatlaimatkhau.Text = "Đặt lại mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.label2.Location = new System.Drawing.Point(50, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Email";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.txtFname);
            this.panel1.Controls.Add(this.btnSendOTP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblDatlaimatkhau);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(176, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 341);
            this.panel1.TabIndex = 21;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.Animated = true;
            this.btnSendOTP.BackColor = System.Drawing.Color.Transparent;
            this.btnSendOTP.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.BorderRadius = 10;
            this.btnSendOTP.BorderThickness = 2;
            this.btnSendOTP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendOTP.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.btnSendOTP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendOTP.ForeColor = System.Drawing.Color.White;
            this.btnSendOTP.HoverState.FillColor = System.Drawing.Color.SteelBlue;
            this.btnSendOTP.Location = new System.Drawing.Point(127, 241);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.PressedDepth = 100;
            this.btnSendOTP.ShadowDecoration.BorderRadius = 15;
            this.btnSendOTP.ShadowDecoration.Depth = 10;
            this.btnSendOTP.ShadowDecoration.Enabled = true;
            this.btnSendOTP.Size = new System.Drawing.Size(166, 50);
            this.btnSendOTP.TabIndex = 38;
            this.btnSendOTP.Text = "Gửi mã OTP";
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click_1);
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
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtFname.ForeColor = System.Drawing.Color.Black;
            this.txtFname.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtFname.Location = new System.Drawing.Point(54, 179);
            this.txtFname.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFname.Name = "txtFname";
            this.txtFname.PlaceholderText = "";
            this.txtFname.SelectedText = "";
            this.txtFname.Size = new System.Drawing.Size(323, 31);
            this.txtFname.TabIndex = 40;
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
            this.btnBackLogin.Location = new System.Drawing.Point(662, 4);
            this.btnBackLogin.Name = "btnBackLogin";
            this.btnBackLogin.PressedDepth = 100;
            this.btnBackLogin.ShadowDecoration.BorderRadius = 18;
            this.btnBackLogin.ShadowDecoration.Depth = 10;
            this.btnBackLogin.ShadowDecoration.Enabled = true;
            this.btnBackLogin.Size = new System.Drawing.Size(137, 83);
            this.btnBackLogin.TabIndex = 35;
            this.btnBackLogin.Text = "🡰 Quay lại";
            this.btnBackLogin.Click += new System.EventHandler(this.btnBackLogin_Click_1);
            // 
            // f_ForgetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(799, 460);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Name = "f_ForgetPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_ForgetPass";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button txtEmail;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblQuenmatkhau;
        private System.Windows.Forms.Label lblDatlaimatkhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnSendOTP;
        private Guna.UI2.WinForms.Guna2TextBox txtFname;
        private Guna.UI2.WinForms.Guna2Button btnBackLogin;
    }
}