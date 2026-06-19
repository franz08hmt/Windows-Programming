namespace QuanLySinhVien
{
    partial class f_AddStudent : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.erp2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblHethong = new System.Windows.Forms.Label();
            this.pnlForm = new Guna.UI2.WinForms.Guna2Panel();
            this.lstSuggest = new System.Windows.Forms.ListBox();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.cboGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpDob = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLname = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFname = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMSSV = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.triangle = new Guna.UI2.WinForms.Guna2ShapesTool(this.components);
            this.guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();
            this.btnViewlist = new Guna.UI2.WinForms.Guna2Button();
            this.btnScanCard = new Guna.UI2.WinForms.Guna2Button();
            this.btnSpeech = new Guna.UI2.WinForms.Guna2Button();
            this.picStudent = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnChooseImage = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.erp2)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(24, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã số sinh viên (MSSV) *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label2.Location = new System.Drawing.Point(24, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label3.Location = new System.Drawing.Point(512, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(23, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày sinh *";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label5.Location = new System.Drawing.Point(511, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 30);
            this.label5.TabIndex = 8;
            this.label5.Text = "Giới tính *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label6.Location = new System.Drawing.Point(23, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 30);
            this.label6.TabIndex = 10;
            this.label6.Text = "Điện thoại *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label7.Location = new System.Drawing.Point(511, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 30);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label8.Location = new System.Drawing.Point(24, 483);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 30);
            this.label8.TabIndex = 14;
            this.label8.Text = "Địa chỉ *";
            // 
            // erp2
            // 
            this.erp2.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-500, -500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 1);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(-500, -500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 1);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(-500, -500);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 1);
            this.panel3.TabIndex = 5;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.BackColor = System.Drawing.Color.Transparent;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(3, 0);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(349, 54);
            this.lblHethong.TabIndex = 2;
            this.lblHethong.Text = "THÊM SINH VIÊN";
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlForm.BorderColor = System.Drawing.Color.LightGray;
            this.pnlForm.BorderRadius = 20;
            this.pnlForm.BorderThickness = 2;
            this.pnlForm.Controls.Add(this.lstSuggest);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Controls.Add(this.btnAdd);
            this.pnlForm.Controls.Add(this.cboGender);
            this.pnlForm.Controls.Add(this.dtpDob);
            this.pnlForm.Controls.Add(this.txtAddress);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.txtLname);
            this.pnlForm.Controls.Add(this.txtFname);
            this.pnlForm.Controls.Add(this.txtMSSV);
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Controls.Add(this.label8);
            this.pnlForm.Controls.Add(this.label4);
            this.pnlForm.Controls.Add(this.label7);
            this.pnlForm.Controls.Add(this.label5);
            this.pnlForm.Controls.Add(this.label6);
            this.pnlForm.Controls.Add(this.guna2Panel2);
            this.pnlForm.FillColor = System.Drawing.Color.White;
            this.pnlForm.Location = new System.Drawing.Point(7, 108);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.ShadowDecoration.BorderRadius = 20;
            this.pnlForm.ShadowDecoration.Depth = 5;
            this.pnlForm.ShadowDecoration.Enabled = true;
            this.pnlForm.Size = new System.Drawing.Size(941, 783);
            this.pnlForm.TabIndex = 19;
            // 
            // lstSuggest
            // 
            this.lstSuggest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSuggest.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSuggest.FormattingEnabled = true;
            this.lstSuggest.ItemHeight = 30;
            this.lstSuggest.Location = new System.Drawing.Point(29, 554);
            this.lstSuggest.Name = "lstSuggest";
            this.lstSuggest.Size = new System.Drawing.Size(885, 92);
            this.lstSuggest.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Animated = true;
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BorderColor = System.Drawing.Color.Transparent;
            this.btnClear.BorderRadius = 15;
            this.btnClear.BorderThickness = 1;
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.Firebrick;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.HoverState.FillColor = System.Drawing.Color.IndianRed;
            this.btnClear.Location = new System.Drawing.Point(518, 673);
            this.btnClear.Name = "btnClear";
            this.btnClear.PressedDepth = 100;
            this.btnClear.ShadowDecoration.BorderRadius = 18;
            this.btnClear.ShadowDecoration.Depth = 10;
            this.btnClear.ShadowDecoration.Enabled = true;
            this.btnClear.Size = new System.Drawing.Size(268, 85);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "🗑️ XÓA TRẮNG";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            this.btnClear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClear_MouseDown);
            this.btnClear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnClear_MouseUp);
            // 
            // btnAdd
            // 
            this.btnAdd.Animated = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderRadius = 15;
            this.btnAdd.BorderThickness = 1;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.SeaGreen;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.HoverState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnAdd.Location = new System.Drawing.Point(158, 673);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PressedDepth = 100;
            this.btnAdd.ShadowDecoration.BorderRadius = 18;
            this.btnAdd.ShadowDecoration.Depth = 10;
            this.btnAdd.ShadowDecoration.Enabled = true;
            this.btnAdd.Size = new System.Drawing.Size(268, 85);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "➕ THÊM SINH VIÊN";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            this.btnAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAdd_MouseDown);
            this.btnAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAdd_MouseUp);
            // 
            // cboGender
            // 
            this.cboGender.BackColor = System.Drawing.Color.Transparent;
            this.cboGender.BorderRadius = 8;
            this.cboGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboGender.ItemHeight = 30;
            this.cboGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGender.Location = new System.Drawing.Point(518, 317);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(396, 36);
            this.cboGender.TabIndex = 26;
            this.cboGender.SelectedIndexChanged += new System.EventHandler(this.cboGender_SelectedIndexChanged_1);
            // 
            // dtpDob
            // 
            this.dtpDob.BackColor = System.Drawing.Color.White;
            this.dtpDob.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtpDob.BorderRadius = 8;
            this.dtpDob.BorderThickness = 1;
            this.dtpDob.Checked = true;
            this.dtpDob.FillColor = System.Drawing.Color.White;
            this.dtpDob.FocusedColor = System.Drawing.Color.White;
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDob.Location = new System.Drawing.Point(30, 317);
            this.dtpDob.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDob.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(396, 36);
            this.dtpDob.TabIndex = 25;
            this.dtpDob.Value = new System.DateTime(2026, 6, 16, 1, 13, 17, 429);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 8;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAddress.ForeColor = System.Drawing.Color.Black;
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtAddress.Location = new System.Drawing.Point(28, 519);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(886, 44);
            this.txtAddress.TabIndex = 24;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged_1);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 8;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtEmail.Location = new System.Drawing.Point(516, 418);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(398, 44);
            this.txtEmail.TabIndex = 23;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 8;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtPhone.Location = new System.Drawing.Point(30, 418);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(396, 44);
            this.txtPhone.TabIndex = 22;
            // 
            // txtLname
            // 
            this.txtLname.BorderRadius = 8;
            this.txtLname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLname.DefaultText = "";
            this.txtLname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtLname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtLname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtLname.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtLname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLname.ForeColor = System.Drawing.Color.Black;
            this.txtLname.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtLname.Location = new System.Drawing.Point(518, 210);
            this.txtLname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtLname.Name = "txtLname";
            this.txtLname.PlaceholderText = "";
            this.txtLname.SelectedText = "";
            this.txtLname.Size = new System.Drawing.Size(396, 44);
            this.txtLname.TabIndex = 21;
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
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFname.ForeColor = System.Drawing.Color.Black;
            this.txtFname.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtFname.Location = new System.Drawing.Point(30, 210);
            this.txtFname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtFname.Name = "txtFname";
            this.txtFname.PlaceholderText = "";
            this.txtFname.SelectedText = "";
            this.txtFname.Size = new System.Drawing.Size(396, 44);
            this.txtFname.TabIndex = 20;
            // 
            // txtMSSV
            // 
            this.txtMSSV.BorderRadius = 8;
            this.txtMSSV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMSSV.DefaultText = "";
            this.txtMSSV.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMSSV.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMSSV.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMSSV.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMSSV.FocusedState.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.txtMSSV.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMSSV.ForeColor = System.Drawing.Color.Black;
            this.txtMSSV.HoverState.BorderColor = System.Drawing.Color.SkyBlue;
            this.txtMSSV.Location = new System.Drawing.Point(30, 115);
            this.txtMSSV.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.PlaceholderText = "";
            this.txtMSSV.SelectedText = "";
            this.txtMSSV.Size = new System.Drawing.Size(884, 44);
            this.txtMSSV.TabIndex = 19;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 5;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.lblHethong);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.guna2Panel1.Location = new System.Drawing.Point(7, 18);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(351, 54);
            this.guna2Panel1.TabIndex = 20;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(7, 73);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1438, 10);
            this.guna2Separator1.TabIndex = 21;
            // 
            // triangle
            // 
            this.triangle.Location = new System.Drawing.Point(0, 0);
            this.triangle.PolygonSkip = 1;
            this.triangle.Rotate = 0F;
            this.triangle.Size = new System.Drawing.Size(200, 200);
            this.triangle.TargetControl = null;
            // 
            // guna2Shapes1
            // 
            this.guna2Shapes1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Shapes1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.BorderThickness = 0;
            this.guna2Shapes1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.Location = new System.Drawing.Point(317, 11);
            this.guna2Shapes1.Name = "guna2Shapes1";
            this.guna2Shapes1.PolygonSides = 3;
            this.guna2Shapes1.PolygonSkip = 1;
            this.guna2Shapes1.Rotate = 0F;
            this.guna2Shapes1.Size = new System.Drawing.Size(78, 80);
            this.guna2Shapes1.TabIndex = 22;
            this.guna2Shapes1.Text = "guna2Shapes1";
            this.guna2Shapes1.Zoom = 80;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.BorderColor = System.Drawing.Color.LightGray;
            this.pnlRight.BorderRadius = 20;
            this.pnlRight.BorderThickness = 2;
            this.pnlRight.Controls.Add(this.btnViewlist);
            this.pnlRight.Controls.Add(this.btnScanCard);
            this.pnlRight.Controls.Add(this.btnSpeech);
            this.pnlRight.Controls.Add(this.picStudent);
            this.pnlRight.Controls.Add(this.btnChooseImage);
            this.pnlRight.FillColor = System.Drawing.Color.White;
            this.pnlRight.Location = new System.Drawing.Point(985, 108);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.ShadowDecoration.BorderRadius = 20;
            this.pnlRight.ShadowDecoration.Depth = 2;
            this.pnlRight.ShadowDecoration.Enabled = true;
            this.pnlRight.Size = new System.Drawing.Size(460, 783);
            this.pnlRight.TabIndex = 29;
            // 
            // btnViewlist
            // 
            this.btnViewlist.Animated = true;
            this.btnViewlist.BackColor = System.Drawing.Color.Transparent;
            this.btnViewlist.BorderColor = System.Drawing.Color.Transparent;
            this.btnViewlist.BorderRadius = 15;
            this.btnViewlist.BorderThickness = 2;
            this.btnViewlist.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewlist.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewlist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewlist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewlist.FillColor = System.Drawing.Color.Sienna;
            this.btnViewlist.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnViewlist.ForeColor = System.Drawing.Color.White;
            this.btnViewlist.HoverState.FillColor = System.Drawing.Color.SandyBrown;
            this.btnViewlist.Location = new System.Drawing.Point(109, 677);
            this.btnViewlist.Name = "btnViewlist";
            this.btnViewlist.PressedDepth = 100;
            this.btnViewlist.ShadowDecoration.BorderRadius = 18;
            this.btnViewlist.ShadowDecoration.Depth = 18;
            this.btnViewlist.ShadowDecoration.Enabled = true;
            this.btnViewlist.Size = new System.Drawing.Size(268, 85);
            this.btnViewlist.TabIndex = 33;
            this.btnViewlist.Text = "📋 Xem danh sách";
            this.btnViewlist.Click += new System.EventHandler(this.btnViewlist_Click_1);
            this.btnViewlist.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnViewlist_MouseDown);
            this.btnViewlist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnViewlist_MouseUp);
            // 
            // btnScanCard
            // 
            this.btnScanCard.Animated = true;
            this.btnScanCard.BackColor = System.Drawing.Color.Transparent;
            this.btnScanCard.BorderColor = System.Drawing.Color.Transparent;
            this.btnScanCard.BorderRadius = 15;
            this.btnScanCard.BorderThickness = 2;
            this.btnScanCard.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnScanCard.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnScanCard.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnScanCard.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnScanCard.FillColor = System.Drawing.Color.DarkSlateBlue;
            this.btnScanCard.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnScanCard.ForeColor = System.Drawing.Color.White;
            this.btnScanCard.HoverState.FillColor = System.Drawing.Color.MediumSlateBlue;
            this.btnScanCard.Location = new System.Drawing.Point(109, 577);
            this.btnScanCard.Name = "btnScanCard";
            this.btnScanCard.PressedDepth = 100;
            this.btnScanCard.ShadowDecoration.BorderRadius = 18;
            this.btnScanCard.ShadowDecoration.Depth = 18;
            this.btnScanCard.ShadowDecoration.Enabled = true;
            this.btnScanCard.Size = new System.Drawing.Size(268, 85);
            this.btnScanCard.TabIndex = 32;
            this.btnScanCard.Text = "🪪 Quét thẻ SV (OCR)";
            this.btnScanCard.Click += new System.EventHandler(this.btnScanCard_Click_1);
            this.btnScanCard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnScanCard_MouseDown);
            this.btnScanCard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnScanCard_MouseUp);
            // 
            // btnSpeech
            // 
            this.btnSpeech.Animated = true;
            this.btnSpeech.BackColor = System.Drawing.Color.Transparent;
            this.btnSpeech.BorderColor = System.Drawing.Color.Transparent;
            this.btnSpeech.BorderRadius = 15;
            this.btnSpeech.BorderThickness = 2;
            this.btnSpeech.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSpeech.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSpeech.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSpeech.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSpeech.FillColor = System.Drawing.Color.SeaGreen;
            this.btnSpeech.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnSpeech.ForeColor = System.Drawing.Color.White;
            this.btnSpeech.HoverState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnSpeech.Location = new System.Drawing.Point(109, 477);
            this.btnSpeech.Name = "btnSpeech";
            this.btnSpeech.PressedDepth = 100;
            this.btnSpeech.ShadowDecoration.BorderRadius = 18;
            this.btnSpeech.ShadowDecoration.Depth = 18;
            this.btnSpeech.ShadowDecoration.Enabled = true;
            this.btnSpeech.Size = new System.Drawing.Size(268, 85);
            this.btnSpeech.TabIndex = 31;
            this.btnSpeech.Text = "🎤 Nhập bằng giọng nói";
            this.btnSpeech.Click += new System.EventHandler(this.btnSpeech_Click_1);
            this.btnSpeech.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSpeech_MouseDown);
            this.btnSpeech.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSpeech_MouseUp);
            // 
            // picStudent
            // 
            this.picStudent.BackColor = System.Drawing.Color.Transparent;
            this.picStudent.BorderRadius = 20;
            this.picStudent.ImageRotate = 0F;
            this.picStudent.Location = new System.Drawing.Point(112, 23);
            this.picStudent.Name = "picStudent";
            this.picStudent.ShadowDecoration.BorderRadius = 25;
            this.picStudent.ShadowDecoration.Depth = 20;
            this.picStudent.ShadowDecoration.Enabled = true;
            this.picStudent.Size = new System.Drawing.Size(261, 333);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStudent.TabIndex = 30;
            this.picStudent.TabStop = false;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.Animated = true;
            this.btnChooseImage.BackColor = System.Drawing.Color.Transparent;
            this.btnChooseImage.BorderColor = System.Drawing.Color.Transparent;
            this.btnChooseImage.BorderRadius = 15;
            this.btnChooseImage.BorderThickness = 2;
            this.btnChooseImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChooseImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChooseImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChooseImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChooseImage.FillColor = System.Drawing.Color.DarkCyan;
            this.btnChooseImage.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.HoverState.FillColor = System.Drawing.Color.MediumTurquoise;
            this.btnChooseImage.Location = new System.Drawing.Point(109, 378);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.PressedDepth = 100;
            this.btnChooseImage.ShadowDecoration.BorderRadius = 18;
            this.btnChooseImage.ShadowDecoration.Depth = 18;
            this.btnChooseImage.ShadowDecoration.Enabled = true;
            this.btnChooseImage.Size = new System.Drawing.Size(268, 85);
            this.btnChooseImage.TabIndex = 29;
            this.btnChooseImage.Text = "📷 Chọn ảnh";
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click_1);
            this.btnChooseImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnChooseImage_MouseDown);
            this.btnChooseImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnChooseImage_MouseUp);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillThickness = 3;
            this.guna2Separator2.Location = new System.Drawing.Point(7, 914);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(1438, 10);
            this.guna2Separator2.TabIndex = 30;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.LightGray;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.Controls.Add(this.label9);
            this.guna2Panel2.CustomizableEdges.BottomLeft = false;
            this.guna2Panel2.CustomizableEdges.BottomRight = false;
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel2.ShadowDecoration.Depth = 0;
            this.guna2Panel2.Size = new System.Drawing.Size(941, 62);
            this.guna2Panel2.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(282, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(368, 45);
            this.label9.TabIndex = 3;
            this.label9.Text = "THÔNG TIN SINH VIÊN";
            // 
            // f_AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Shapes1);
            this.Name = "f_AddStudent";
            this.Size = new System.Drawing.Size(1462, 957);
            this.Load += new System.EventHandler(this.f_AddStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erp2)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider erp2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblHethong;
        private Guna.UI2.WinForms.Guna2Panel pnlForm;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
        private Guna.UI2.WinForms.Guna2ShapesTool triangle;
        private Guna.UI2.WinForms.Guna2TextBox txtMSSV;
        private Guna.UI2.WinForms.Guna2TextBox txtFname;
        private Guna.UI2.WinForms.Guna2TextBox txtLname;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDob;
        private Guna.UI2.WinForms.Guna2ComboBox cboGender;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Panel pnlRight;
        private Guna.UI2.WinForms.Guna2Button btnChooseImage;
        private Guna.UI2.WinForms.Guna2PictureBox picStudent;
        private Guna.UI2.WinForms.Guna2Button btnSpeech;
        private Guna.UI2.WinForms.Guna2Button btnScanCard;
        private Guna.UI2.WinForms.Guna2Button btnViewlist;
        private System.Windows.Forms.ListBox lstSuggest;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label9;
    }
}