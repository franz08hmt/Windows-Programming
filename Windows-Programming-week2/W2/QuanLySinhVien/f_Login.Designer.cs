namespace QuanLySinhVien
{
    partial class f_Login
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.pctLock = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlUserWrapper = new System.Windows.Forms.Panel();
            this.pctUserIcon = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.rdHR = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.rdStudent = new System.Windows.Forms.RadioButton();
            this.lnkForgetPass = new System.Windows.Forms.LinkLabel();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.picLoginIcon = new System.Windows.Forms.PictureBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.lblDesigned = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLock)).BeginInit();
            this.pnlUserWrapper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctUserIcon)).BeginInit();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.pnlPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPassword.Controls.Add(this.pctLock);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(97, 268);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(276, 36);
            this.pnlPassword.TabIndex = 11;
            // 
            // pctLock
            // 
            this.pctLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.pctLock.Image = global::QuanLySinhVien.Properties.Resources.LockIcon2;
            this.pctLock.Location = new System.Drawing.Point(0, 0);
            this.pctLock.Name = "pctLock";
            this.pctLock.Size = new System.Drawing.Size(43, 33);
            this.pctLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLock.TabIndex = 10;
            this.pctLock.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.Location = new System.Drawing.Point(47, 7);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(228, 19);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "●●●●●●●●●●";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // pnlUserWrapper
            // 
            this.pnlUserWrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.pnlUserWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUserWrapper.Controls.Add(this.pctUserIcon);
            this.pnlUserWrapper.Controls.Add(this.txtUsername);
            this.pnlUserWrapper.Location = new System.Drawing.Point(97, 179);
            this.pnlUserWrapper.Name = "pnlUserWrapper";
            this.pnlUserWrapper.Size = new System.Drawing.Size(276, 36);
            this.pnlUserWrapper.TabIndex = 8;
            // 
            // pctUserIcon
            // 
            this.pctUserIcon.Image = global::QuanLySinhVien.Properties.Resources.UserIcon;
            this.pctUserIcon.Location = new System.Drawing.Point(-1, -2);
            this.pctUserIcon.Name = "pctUserIcon";
            this.pctUserIcon.Size = new System.Drawing.Size(43, 37);
            this.pctUserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctUserIcon.TabIndex = 9;
            this.pctUserIcon.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsername.Location = new System.Drawing.Point(43, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(232, 24);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Text = "Họ và tên";
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(99, 384);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(274, 44);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // rdHR
            // 
            this.rdHR.AutoSize = true;
            this.rdHR.Location = new System.Drawing.Point(214, 332);
            this.rdHR.Name = "rdHR";
            this.rdHR.Size = new System.Drawing.Size(159, 24);
            this.rdHR.TabIndex = 5;
            this.rdHR.TabStop = true;
            this.rdHR.Text = "Human Resource";
            this.rdHR.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(91, 39);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(292, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // rdStudent
            // 
            this.rdStudent.AutoSize = true;
            this.rdStudent.Location = new System.Drawing.Point(97, 332);
            this.rdStudent.Name = "rdStudent";
            this.rdStudent.Size = new System.Drawing.Size(91, 24);
            this.rdStudent.TabIndex = 4;
            this.rdStudent.TabStop = true;
            this.rdStudent.Text = "Student";
            this.rdStudent.UseVisualStyleBackColor = true;
            // 
            // lnkForgetPass
            // 
            this.lnkForgetPass.AutoSize = true;
            this.lnkForgetPass.LinkColor = System.Drawing.Color.CadetBlue;
            this.lnkForgetPass.Location = new System.Drawing.Point(234, 446);
            this.lnkForgetPass.Name = "lnkForgetPass";
            this.lnkForgetPass.Size = new System.Drawing.Size(127, 20);
            this.lnkForgetPass.TabIndex = 7;
            this.lnkForgetPass.TabStop = true;
            this.lnkForgetPass.Text = "Quên mật khẩu?";
            this.lnkForgetPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgetPass_LinkClicked);
            // 
            // lnkRegister
            // 
            this.lnkRegister.AutoSize = true;
            this.lnkRegister.LinkColor = System.Drawing.Color.CadetBlue;
            this.lnkRegister.Location = new System.Drawing.Point(127, 446);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(88, 20);
            this.lnkRegister.TabIndex = 6;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "New user ?";
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lbLogin.Location = new System.Drawing.Point(95, 154);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(116, 21);
            this.lbLogin.TabIndex = 10;
            this.lbLogin.Text = "Tên đăng nhập";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lbPassword.Location = new System.Drawing.Point(95, 243);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(77, 21);
            this.lbPassword.TabIndex = 11;
            this.lbPassword.Text = "Mật khẩu";
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.White;
            this.pnlBackground.Controls.Add(this.lblSeparator);
            this.pnlBackground.Controls.Add(this.lbPassword);
            this.pnlBackground.Controls.Add(this.lbLogin);
            this.pnlBackground.Controls.Add(this.picLoginIcon);
            this.pnlBackground.Controls.Add(this.lnkRegister);
            this.pnlBackground.Controls.Add(this.lnkForgetPass);
            this.pnlBackground.Controls.Add(this.rdStudent);
            this.pnlBackground.Controls.Add(this.lblTitle);
            this.pnlBackground.Controls.Add(this.rdHR);
            this.pnlBackground.Controls.Add(this.btnLogin);
            this.pnlBackground.Controls.Add(this.pnlUserWrapper);
            this.pnlBackground.Controls.Add(this.pnlPassword);
            this.pnlBackground.Location = new System.Drawing.Point(272, 38);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(450, 489);
            this.pnlBackground.TabIndex = 8;
            // 
            // lblSeparator
            // 
            this.lblSeparator.AutoSize = true;
            this.lblSeparator.Location = new System.Drawing.Point(219, 446);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(14, 20);
            this.lblSeparator.TabIndex = 12;
            this.lblSeparator.Text = "|";
            // 
            // picLoginIcon
            // 
            this.picLoginIcon.Image = global::QuanLySinhVien.Properties.Resources.LoginIcon;
            this.picLoginIcon.Location = new System.Drawing.Point(204, 88);
            this.picLoginIcon.Name = "picLoginIcon";
            this.picLoginIcon.Size = new System.Drawing.Size(57, 50);
            this.picLoginIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoginIcon.TabIndex = 9;
            this.picLoginIcon.TabStop = false;
            // 
            // pctLogo
            // 
            this.pctLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLogo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.pctLogo.Location = new System.Drawing.Point(383, 531);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(74, 57);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctLogo.TabIndex = 12;
            this.pctLogo.TabStop = false;
            // 
            // lblDesigned
            // 
            this.lblDesigned.AutoSize = true;
            this.lblDesigned.BackColor = System.Drawing.Color.Transparent;
            this.lblDesigned.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lblDesigned.ForeColor = System.Drawing.Color.Gray;
            this.lblDesigned.Location = new System.Drawing.Point(448, 551);
            this.lblDesigned.Name = "lblDesigned";
            this.lblDesigned.Size = new System.Drawing.Size(164, 21);
            this.lblDesigned.TabIndex = 12;
            this.lblDesigned.Text = "Designed by Group 3";
            // 
            // f_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.BackgroundImage = global::QuanLySinhVien.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.lblDesigned);
            this.Controls.Add(this.pctLogo);
            this.Controls.Add(this.pnlBackground);
            this.Name = "f_Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.f_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctLock)).EndInit();
            this.pnlUserWrapper.ResumeLayout(false);
            this.pnlUserWrapper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctUserIcon)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.PictureBox picLoginIcon;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.LinkLabel lnkForgetPass;
        private System.Windows.Forms.RadioButton rdStudent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton rdHR;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel pnlUserWrapper;
        private System.Windows.Forms.PictureBox pctUserIcon;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.PictureBox pctLock;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Label lblDesigned;
        private System.Windows.Forms.Label lblSeparator;
    }
}

