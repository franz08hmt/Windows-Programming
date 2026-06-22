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
            this.pctLock = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pctUserIcon = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lnkForgetPass = new System.Windows.Forms.LinkLabel();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.lbLogin = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.picLoginIcon = new System.Windows.Forms.PictureBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.lblDesigned = new System.Windows.Forms.Label();
            this.pnlForm = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.rdHR = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdStudent = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdAdmin = new Guna.UI2.WinForms.Guna2RadioButton();
            this.pnlPassword = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlUserWrapper = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctUserIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlUserWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pctLock
            // 
            this.pctLock.BackColor = System.Drawing.Color.Transparent;
            this.pctLock.Image = global::QuanLySinhVien.Properties.Resources.LockIcon2;
            this.pctLock.Location = new System.Drawing.Point(1, 1);
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
            this.txtPassword.Location = new System.Drawing.Point(48, 7);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(225, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "●●●●●●●●●●";
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // pctUserIcon
            // 
            this.pctUserIcon.Image = global::QuanLySinhVien.Properties.Resources.UserIcon;
            this.pctUserIcon.Location = new System.Drawing.Point(0, -1);
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
            this.txtUsername.Location = new System.Drawing.Point(44, 5);
            this.txtUsername.Multiline = true;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(229, 26);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Text = "Họ và tên";
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(83, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(292, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // lnkForgetPass
            // 
            this.lnkForgetPass.AutoSize = true;
            this.lnkForgetPass.LinkColor = System.Drawing.Color.CadetBlue;
            this.lnkForgetPass.Location = new System.Drawing.Point(218, 451);
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
            this.lnkRegister.Location = new System.Drawing.Point(111, 451);
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
            this.lbLogin.Location = new System.Drawing.Point(85, 166);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(116, 21);
            this.lbLogin.TabIndex = 10;
            this.lbLogin.Text = "Tên đăng nhập";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.lbPassword.Location = new System.Drawing.Point(87, 245);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(77, 21);
            this.lbPassword.TabIndex = 11;
            this.lbPassword.Text = "Mật khẩu";
            // 
            // lblSeparator
            // 
            this.lblSeparator.AutoSize = true;
            this.lblSeparator.Location = new System.Drawing.Point(203, 451);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(14, 20);
            this.lblSeparator.TabIndex = 12;
            this.lblSeparator.Text = "|";
            // 
            // picLoginIcon
            // 
            this.picLoginIcon.Image = global::QuanLySinhVien.Properties.Resources.LoginIcon;
            this.picLoginIcon.Location = new System.Drawing.Point(195, 78);
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
            this.pctLogo.Location = new System.Drawing.Point(377, 649);
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
            this.lblDesigned.Location = new System.Drawing.Point(442, 669);
            this.lblDesigned.Name = "lblDesigned";
            this.lblDesigned.Size = new System.Drawing.Size(164, 21);
            this.lblDesigned.TabIndex = 12;
            this.lblDesigned.Text = "Designed by Group 3";
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlForm.BorderColor = System.Drawing.Color.White;
            this.pnlForm.BorderRadius = 20;
            this.pnlForm.BorderThickness = 2;
            this.pnlForm.Controls.Add(this.rdHR);
            this.pnlForm.Controls.Add(this.rdStudent);
            this.pnlForm.Controls.Add(this.rdAdmin);
            this.pnlForm.Controls.Add(this.pnlPassword);
            this.pnlForm.Controls.Add(this.pnlUserWrapper);
            this.pnlForm.Controls.Add(this.btnLogin);
            this.pnlForm.Controls.Add(this.lblSeparator);
            this.pnlForm.Controls.Add(this.picLoginIcon);
            this.pnlForm.Controls.Add(this.lbPassword);
            this.pnlForm.Controls.Add(this.lbLogin);
            this.pnlForm.Controls.Add(this.lnkRegister);
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Controls.Add(this.lnkForgetPass);
            this.pnlForm.Location = new System.Drawing.Point(280, 121);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.ShadowDecoration.BorderRadius = 20;
            this.pnlForm.ShadowDecoration.Depth = 10;
            this.pnlForm.ShadowDecoration.Enabled = true;
            this.pnlForm.Size = new System.Drawing.Size(450, 508);
            this.pnlForm.TabIndex = 29;
            // 
            // rdHR
            // 
            this.rdHR.AutoSize = true;
            this.rdHR.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.rdHR.CheckedState.BorderThickness = 0;
            this.rdHR.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.rdHR.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdHR.CheckedState.InnerOffset = 12;
            this.rdHR.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdHR.Location = new System.Drawing.Point(305, 322);
            this.rdHR.Name = "rdHR";
            this.rdHR.Size = new System.Drawing.Size(57, 25);
            this.rdHR.TabIndex = 35;
            this.rdHR.Text = "HR";
            this.rdHR.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.rdHR.UncheckedState.BorderThickness = 2;
            this.rdHR.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdHR.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rdStudent
            // 
            this.rdStudent.AutoSize = true;
            this.rdStudent.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.rdStudent.CheckedState.BorderThickness = 0;
            this.rdStudent.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.rdStudent.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdStudent.CheckedState.InnerOffset = 12;
            this.rdStudent.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdStudent.Location = new System.Drawing.Point(191, 322);
            this.rdStudent.Name = "rdStudent";
            this.rdStudent.Size = new System.Drawing.Size(93, 25);
            this.rdStudent.TabIndex = 34;
            this.rdStudent.Text = "Student";
            this.rdStudent.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.rdStudent.UncheckedState.BorderThickness = 2;
            this.rdStudent.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdStudent.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rdAdmin
            // 
            this.rdAdmin.AutoSize = true;
            this.rdAdmin.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.rdAdmin.CheckedState.BorderThickness = 0;
            this.rdAdmin.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.rdAdmin.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdAdmin.CheckedState.InnerOffset = -4;
            this.rdAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAdmin.Location = new System.Drawing.Point(92, 322);
            this.rdAdmin.Name = "rdAdmin";
            this.rdAdmin.Size = new System.Drawing.Size(83, 25);
            this.rdAdmin.TabIndex = 33;
            this.rdAdmin.Text = "Admin";
            this.rdAdmin.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.rdAdmin.UncheckedState.BorderThickness = 2;
            this.rdAdmin.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdAdmin.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.Transparent;
            this.pnlPassword.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlPassword.BorderRadius = 8;
            this.pnlPassword.BorderThickness = 1;
            this.pnlPassword.Controls.Add(this.pctLock);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.pnlPassword.Location = new System.Drawing.Point(91, 269);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.ShadowDecoration.BorderRadius = 10;
            this.pnlPassword.ShadowDecoration.Depth = 10;
            this.pnlPassword.ShadowDecoration.Enabled = true;
            this.pnlPassword.Size = new System.Drawing.Size(276, 36);
            this.pnlPassword.TabIndex = 32;
            // 
            // pnlUserWrapper
            // 
            this.pnlUserWrapper.BackColor = System.Drawing.Color.Transparent;
            this.pnlUserWrapper.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlUserWrapper.BorderRadius = 8;
            this.pnlUserWrapper.BorderThickness = 1;
            this.pnlUserWrapper.Controls.Add(this.pctUserIcon);
            this.pnlUserWrapper.Controls.Add(this.txtUsername);
            this.pnlUserWrapper.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.pnlUserWrapper.Location = new System.Drawing.Point(89, 190);
            this.pnlUserWrapper.Name = "pnlUserWrapper";
            this.pnlUserWrapper.ShadowDecoration.BorderRadius = 10;
            this.pnlUserWrapper.ShadowDecoration.Depth = 10;
            this.pnlUserWrapper.ShadowDecoration.Enabled = true;
            this.pnlUserWrapper.Size = new System.Drawing.Size(276, 36);
            this.pnlUserWrapper.TabIndex = 31;
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderRadius = 15;
            this.btnLogin.BorderThickness = 2;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(112)))), ((int)(((byte)(184)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.MidnightBlue;
            this.btnLogin.Location = new System.Drawing.Point(87, 369);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PressedDepth = 100;
            this.btnLogin.ShadowDecoration.BorderRadius = 18;
            this.btnLogin.ShadowDecoration.Depth = 18;
            this.btnLogin.ShadowDecoration.Enabled = true;
            this.btnLogin.Size = new System.Drawing.Size(276, 48);
            this.btnLogin.TabIndex = 30;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // f_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.BackgroundImage = global::QuanLySinhVien.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 810);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.lblDesigned);
            this.Controls.Add(this.pctLogo);
            this.Name = "f_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập Hệ Thống";
            this.Load += new System.EventHandler(this.f_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctUserIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlUserWrapper.ResumeLayout(false);
            this.pnlUserWrapper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.PictureBox picLoginIcon;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.LinkLabel lnkForgetPass;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pctUserIcon;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.PictureBox pctLock;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.Label lblDesigned;
        private System.Windows.Forms.Label lblSeparator;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel pnlForm;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Panel pnlUserWrapper;
        private Guna.UI2.WinForms.Guna2Panel pnlPassword;
        private Guna.UI2.WinForms.Guna2RadioButton rdAdmin;
        private Guna.UI2.WinForms.Guna2RadioButton rdStudent;
        private Guna.UI2.WinForms.Guna2RadioButton rdHR;
    }
}