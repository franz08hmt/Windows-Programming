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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSendOTP = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBackLogin = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblQuenmatkhau = new System.Windows.Forms.Label();
            this.lblDatlaimatkhau = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label1.Location = new System.Drawing.Point(262, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập email để nhận mã OTP đặt lại mật khẩu";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(333, 230);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(214, 25);
            this.txtEmail.TabIndex = 1;
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSendOTP.Location = new System.Drawing.Point(371, 268);
            this.btnSendOTP.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.Size = new System.Drawing.Size(140, 57);
            this.btnSendOTP.TabIndex = 2;
            this.btnSendOTP.Text = "Gửi mã OTP";
            this.btnSendOTP.UseVisualStyleBackColor = true;
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBackLogin);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblQuenmatkhau);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 58);
            this.pnlHeader.TabIndex = 17;
            // 
            // btnBackLogin
            // 
            this.btnBackLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBackLogin.FlatAppearance.BorderSize = 0;
            this.btnBackLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnBackLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnBackLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnBackLogin.ForeColor = System.Drawing.Color.White;
            this.btnBackLogin.Location = new System.Drawing.Point(887, 0);
            this.btnBackLogin.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackLogin.Name = "btnBackLogin";
            this.btnBackLogin.Size = new System.Drawing.Size(97, 58);
            this.btnBackLogin.TabIndex = 4;
            this.btnBackLogin.Text = "⬅ Quay lại";
            this.btnBackLogin.UseVisualStyleBackColor = false;
            this.btnBackLogin.Click += new System.EventHandler(this.btnBackLogin_Click);
            // 
            // ptLgo
            // 
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Margin = new System.Windows.Forms.Padding(2);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(56, 58);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabIndex = 1;
            this.ptLgo.TabStop = false;
            // 
            // lblQuenmatkhau
            // 
            this.lblQuenmatkhau.AutoSize = true;
            this.lblQuenmatkhau.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblQuenmatkhau.ForeColor = System.Drawing.Color.White;
            this.lblQuenmatkhau.Location = new System.Drawing.Point(58, 14);
            this.lblQuenmatkhau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuenmatkhau.Name = "lblQuenmatkhau";
            this.lblQuenmatkhau.Size = new System.Drawing.Size(217, 32);
            this.lblQuenmatkhau.TabIndex = 0;
            this.lblQuenmatkhau.Text = "QUÊN MẬT KHẨU";
            // 
            // lblDatlaimatkhau
            // 
            this.lblDatlaimatkhau.AutoSize = true;
            this.lblDatlaimatkhau.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblDatlaimatkhau.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDatlaimatkhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.lblDatlaimatkhau.Location = new System.Drawing.Point(346, 99);
            this.lblDatlaimatkhau.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDatlaimatkhau.Name = "lblDatlaimatkhau";
            this.lblDatlaimatkhau.Size = new System.Drawing.Size(201, 32);
            this.lblDatlaimatkhau.TabIndex = 19;
            this.lblDatlaimatkhau.Text = "Đặt lại mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.label2.Location = new System.Drawing.Point(329, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Email";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSendOTP);
            this.panel1.Controls.Add(this.lblDatlaimatkhau);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Location = new System.Drawing.Point(59, 96);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 429);
            this.panel1.TabIndex = 21;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // f_ForgetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSendOTP;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBackLogin;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblQuenmatkhau;
        private System.Windows.Forms.Label lblDatlaimatkhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}