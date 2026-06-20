namespace QuanLySinhVien
{
    partial class f_RegisterCourse : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBandau = new System.Windows.Forms.Label();
            this.lblKetqua = new System.Windows.Forms.Label();
            this.lstBandau = new System.Windows.Forms.ListBox();
            this.lstKetqua = new System.Windows.Forms.ListBox();
            this.lblMonInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnMoveAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnRemoveOne = new Guna.UI2.WinForms.Guna2Button();
            this.btnMoveOne = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHethong = new System.Windows.Forms.Label();
            this.guna2Shapes1 = new Guna.UI2.WinForms.Guna2Shapes();
            this.btnRegister = new Guna.UI2.WinForms.Guna2Button();
            this.btnUnregister = new Guna.UI2.WinForms.Guna2Button();
            this.btnSendRequest = new Guna.UI2.WinForms.Guna2Button();
            this.btnAISuggest = new Guna.UI2.WinForms.Guna2Button();
            this.btnAICheckConflict = new Guna.UI2.WinForms.Guna2Button();
            this.dgvRegisterList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cboStudent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.panel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterList)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn Sinh viên :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblBandau
            // 
            this.lblBandau.AutoSize = true;
            this.lblBandau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBandau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblBandau.Location = new System.Drawing.Point(3, 133);
            this.lblBandau.Name = "lblBandau";
            this.lblBandau.Size = new System.Drawing.Size(297, 32);
            this.lblBandau.TabIndex = 3;
            this.lblBandau.Text = "Môn học có thể đăng ký:";
            // 
            // lblKetqua
            // 
            this.lblKetqua.AutoSize = true;
            this.lblKetqua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblKetqua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblKetqua.Location = new System.Drawing.Point(787, 133);
            this.lblKetqua.Name = "lblKetqua";
            this.lblKetqua.Size = new System.Drawing.Size(251, 32);
            this.lblKetqua.TabIndex = 5;
            this.lblKetqua.Text = "Môn học sẽ đăng ký:";
            // 
            // lstBandau
            // 
            this.lstBandau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBandau.FormattingEnabled = true;
            this.lstBandau.ItemHeight = 20;
            this.lstBandau.Location = new System.Drawing.Point(7, 168);
            this.lstBandau.Name = "lstBandau";
            this.lstBandau.Size = new System.Drawing.Size(630, 224);
            this.lstBandau.TabIndex = 1;
            this.lstBandau.SelectedIndexChanged += new System.EventHandler(this.lstBandau_SelectedIndexChanged);
            // 
            // lstKetqua
            // 
            this.lstKetqua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lstKetqua.FormattingEnabled = true;
            this.lstKetqua.ItemHeight = 20;
            this.lstKetqua.Location = new System.Drawing.Point(793, 168);
            this.lstKetqua.Name = "lstKetqua";
            this.lstKetqua.Size = new System.Drawing.Size(666, 224);
            this.lstKetqua.TabIndex = 6;
            this.lstKetqua.SelectedIndexChanged += new System.EventHandler(this.lstKetqua_SelectedIndexChanged);
            // 
            // lblMonInfo
            // 
            this.lblMonInfo.AutoSize = true;
            this.lblMonInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblMonInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblMonInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblMonInfo.Location = new System.Drawing.Point(6, 392);
            this.lblMonInfo.Name = "lblMonInfo";
            this.lblMonInfo.Size = new System.Drawing.Size(279, 28);
            this.lblMonInfo.TabIndex = 11;
            this.lblMonInfo.Text = "← Chọn môn để xem thông tin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(4, 488);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "Danh sách môn học đã đăng ký:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.panel1.Controls.Add(this.btnRemoveAll);
            this.panel1.Controls.Add(this.btnMoveAll);
            this.panel1.Controls.Add(this.btnRemoveOne);
            this.panel1.Controls.Add(this.btnMoveOne);
            this.panel1.Location = new System.Drawing.Point(643, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 224);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Animated = true;
            this.btnRemoveAll.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveAll.BorderColor = System.Drawing.Color.DimGray;
            this.btnRemoveAll.BorderRadius = 15;
            this.btnRemoveAll.BorderThickness = 1;
            this.btnRemoveAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveAll.FillColor = System.Drawing.Color.Gainsboro;
            this.btnRemoveAll.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnRemoveAll.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRemoveAll.HoverState.FillColor = System.Drawing.Color.White;
            this.btnRemoveAll.Location = new System.Drawing.Point(25, 161);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.PressedDepth = 100;
            this.btnRemoveAll.ShadowDecoration.BorderRadius = 18;
            this.btnRemoveAll.ShadowDecoration.Depth = 10;
            this.btnRemoveAll.ShadowDecoration.Enabled = true;
            this.btnRemoveAll.Size = new System.Drawing.Size(100, 38);
            this.btnRemoveAll.TabIndex = 31;
            this.btnRemoveAll.Text = "⇐";
            this.btnRemoveAll.TextFormatNoPrefix = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click_1);
            // 
            // btnMoveAll
            // 
            this.btnMoveAll.Animated = true;
            this.btnMoveAll.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveAll.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnMoveAll.BorderRadius = 15;
            this.btnMoveAll.BorderThickness = 1;
            this.btnMoveAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoveAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoveAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMoveAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMoveAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnMoveAll.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnMoveAll.ForeColor = System.Drawing.Color.White;
            this.btnMoveAll.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnMoveAll.Location = new System.Drawing.Point(25, 65);
            this.btnMoveAll.Name = "btnMoveAll";
            this.btnMoveAll.PressedDepth = 100;
            this.btnMoveAll.ShadowDecoration.BorderRadius = 18;
            this.btnMoveAll.ShadowDecoration.Depth = 10;
            this.btnMoveAll.ShadowDecoration.Enabled = true;
            this.btnMoveAll.Size = new System.Drawing.Size(100, 38);
            this.btnMoveAll.TabIndex = 29;
            this.btnMoveAll.Text = "⇒";
            this.btnMoveAll.TextFormatNoPrefix = true;
            this.btnMoveAll.Click += new System.EventHandler(this.btnMoveAll_Click_1);
            // 
            // btnRemoveOne
            // 
            this.btnRemoveOne.Animated = true;
            this.btnRemoveOne.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveOne.BorderColor = System.Drawing.Color.DimGray;
            this.btnRemoveOne.BorderRadius = 15;
            this.btnRemoveOne.BorderThickness = 1;
            this.btnRemoveOne.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveOne.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemoveOne.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemoveOne.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemoveOne.FillColor = System.Drawing.Color.Gainsboro;
            this.btnRemoveOne.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnRemoveOne.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRemoveOne.HoverState.FillColor = System.Drawing.Color.White;
            this.btnRemoveOne.Location = new System.Drawing.Point(25, 113);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.PressedDepth = 100;
            this.btnRemoveOne.ShadowDecoration.BorderRadius = 18;
            this.btnRemoveOne.ShadowDecoration.Depth = 10;
            this.btnRemoveOne.ShadowDecoration.Enabled = true;
            this.btnRemoveOne.Size = new System.Drawing.Size(100, 38);
            this.btnRemoveOne.TabIndex = 30;
            this.btnRemoveOne.Text = "←";
            this.btnRemoveOne.TextFormatNoPrefix = true;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click_1);
            // 
            // btnMoveOne
            // 
            this.btnMoveOne.Animated = true;
            this.btnMoveOne.BackColor = System.Drawing.Color.Transparent;
            this.btnMoveOne.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnMoveOne.BorderRadius = 15;
            this.btnMoveOne.BorderThickness = 1;
            this.btnMoveOne.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMoveOne.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMoveOne.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMoveOne.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMoveOne.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.btnMoveOne.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnMoveOne.ForeColor = System.Drawing.Color.White;
            this.btnMoveOne.HoverState.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnMoveOne.Location = new System.Drawing.Point(25, 17);
            this.btnMoveOne.Name = "btnMoveOne";
            this.btnMoveOne.PressedDepth = 100;
            this.btnMoveOne.ShadowDecoration.BorderRadius = 18;
            this.btnMoveOne.ShadowDecoration.Depth = 10;
            this.btnMoveOne.ShadowDecoration.Enabled = true;
            this.btnMoveOne.Size = new System.Drawing.Size(100, 38);
            this.btnMoveOne.TabIndex = 28;
            this.btnMoveOne.Text = "→";
            this.btnMoveOne.TextFormatNoPrefix = true;
            this.btnMoveOne.Click += new System.EventHandler(this.btnMoveOne_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 2;
            this.label3.Visible = false;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.FillThickness = 3;
            this.guna2Separator1.Location = new System.Drawing.Point(7, 73);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1452, 13);
            this.guna2Separator1.TabIndex = 27;
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
            this.guna2Panel1.Size = new System.Drawing.Size(402, 54);
            this.guna2Panel1.TabIndex = 26;
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.BackColor = System.Drawing.Color.Transparent;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(-1, 0);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(410, 54);
            this.lblHethong.TabIndex = 2;
            this.lblHethong.Text = "ĐĂNG KÝ MÔN HỌC";
            // 
            // guna2Shapes1
            // 
            this.guna2Shapes1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Shapes1.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.BorderThickness = 0;
            this.guna2Shapes1.FillColor = System.Drawing.Color.DarkGray;
            this.guna2Shapes1.Location = new System.Drawing.Point(369, 15);
            this.guna2Shapes1.Name = "guna2Shapes1";
            this.guna2Shapes1.PolygonSides = 3;
            this.guna2Shapes1.PolygonSkip = 1;
            this.guna2Shapes1.Rotate = 0F;
            this.guna2Shapes1.Size = new System.Drawing.Size(78, 80);
            this.guna2Shapes1.TabIndex = 28;
            this.guna2Shapes1.Text = "guna2Shapes1";
            this.guna2Shapes1.Zoom = 80;
            // 
            // btnRegister
            // 
            this.btnRegister.Animated = true;
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.BorderColor = System.Drawing.Color.Transparent;
            this.btnRegister.BorderRadius = 15;
            this.btnRegister.BorderThickness = 1;
            this.btnRegister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRegister.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRegister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRegister.FillColor = System.Drawing.Color.SeaGreen;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.HoverState.FillColor = System.Drawing.Color.LimeGreen;
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))));
            this.btnRegister.Location = new System.Drawing.Point(63, 426);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.PressedDepth = 100;
            this.btnRegister.ShadowDecoration.BorderRadius = 18;
            this.btnRegister.ShadowDecoration.Depth = 10;
            this.btnRegister.ShadowDecoration.Enabled = true;
            this.btnRegister.Size = new System.Drawing.Size(216, 58);
            this.btnRegister.TabIndex = 29;
            this.btnRegister.Text = "💾 LƯU ĐĂNG KÝ";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click_1);
            // 
            // btnUnregister
            // 
            this.btnUnregister.Animated = true;
            this.btnUnregister.BackColor = System.Drawing.Color.Transparent;
            this.btnUnregister.BorderColor = System.Drawing.Color.Transparent;
            this.btnUnregister.BorderRadius = 15;
            this.btnUnregister.BorderThickness = 1;
            this.btnUnregister.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUnregister.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUnregister.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUnregister.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUnregister.FillColor = System.Drawing.Color.Maroon;
            this.btnUnregister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUnregister.ForeColor = System.Drawing.Color.White;
            this.btnUnregister.HoverState.FillColor = System.Drawing.Color.Crimson;
            this.btnUnregister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))));
            this.btnUnregister.Location = new System.Drawing.Point(343, 426);
            this.btnUnregister.Name = "btnUnregister";
            this.btnUnregister.PressedDepth = 100;
            this.btnUnregister.ShadowDecoration.BorderRadius = 18;
            this.btnUnregister.ShadowDecoration.Depth = 10;
            this.btnUnregister.ShadowDecoration.Enabled = true;
            this.btnUnregister.Size = new System.Drawing.Size(216, 58);
            this.btnUnregister.TabIndex = 30;
            this.btnUnregister.Text = "🚫 HỦY ĐĂNG KÝ";
            this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click_1);
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.Animated = true;
            this.btnSendRequest.BackColor = System.Drawing.Color.Transparent;
            this.btnSendRequest.BorderColor = System.Drawing.Color.Transparent;
            this.btnSendRequest.BorderRadius = 15;
            this.btnSendRequest.BorderThickness = 1;
            this.btnSendRequest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendRequest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendRequest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendRequest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendRequest.FillColor = System.Drawing.Color.Coral;
            this.btnSendRequest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendRequest.ForeColor = System.Drawing.Color.White;
            this.btnSendRequest.HoverState.FillColor = System.Drawing.Color.Orange;
            this.btnSendRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))));
            this.btnSendRequest.Location = new System.Drawing.Point(623, 426);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.PressedDepth = 100;
            this.btnSendRequest.ShadowDecoration.BorderRadius = 18;
            this.btnSendRequest.ShadowDecoration.Depth = 10;
            this.btnSendRequest.ShadowDecoration.Enabled = true;
            this.btnSendRequest.Size = new System.Drawing.Size(216, 58);
            this.btnSendRequest.TabIndex = 31;
            this.btnSendRequest.Text = "📨 GỬI YÊU CẦU XÁC NHẬN";
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click_1);
            // 
            // btnAISuggest
            // 
            this.btnAISuggest.Animated = true;
            this.btnAISuggest.BackColor = System.Drawing.Color.Transparent;
            this.btnAISuggest.BorderColor = System.Drawing.Color.Transparent;
            this.btnAISuggest.BorderRadius = 15;
            this.btnAISuggest.BorderThickness = 1;
            this.btnAISuggest.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAISuggest.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAISuggest.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAISuggest.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAISuggest.FillColor = System.Drawing.Color.Indigo;
            this.btnAISuggest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAISuggest.ForeColor = System.Drawing.Color.White;
            this.btnAISuggest.HoverState.FillColor = System.Drawing.Color.SlateBlue;
            this.btnAISuggest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))));
            this.btnAISuggest.Location = new System.Drawing.Point(903, 426);
            this.btnAISuggest.Name = "btnAISuggest";
            this.btnAISuggest.PressedDepth = 100;
            this.btnAISuggest.ShadowDecoration.BorderRadius = 18;
            this.btnAISuggest.ShadowDecoration.Depth = 10;
            this.btnAISuggest.ShadowDecoration.Enabled = true;
            this.btnAISuggest.Size = new System.Drawing.Size(216, 58);
            this.btnAISuggest.TabIndex = 32;
            this.btnAISuggest.Text = "🤖 AI Gợi ý môn học";
            this.btnAISuggest.Click += new System.EventHandler(this.btnAISuggest_Click_1);
            // 
            // btnAICheckConflict
            // 
            this.btnAICheckConflict.Animated = true;
            this.btnAICheckConflict.BackColor = System.Drawing.Color.Transparent;
            this.btnAICheckConflict.BorderColor = System.Drawing.Color.Transparent;
            this.btnAICheckConflict.BorderRadius = 15;
            this.btnAICheckConflict.BorderThickness = 1;
            this.btnAICheckConflict.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAICheckConflict.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAICheckConflict.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAICheckConflict.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAICheckConflict.FillColor = System.Drawing.Color.DarkGoldenrod;
            this.btnAICheckConflict.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAICheckConflict.ForeColor = System.Drawing.Color.White;
            this.btnAICheckConflict.HoverState.FillColor = System.Drawing.Color.PaleGoldenrod;
            this.btnAICheckConflict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left))));
            this.btnAICheckConflict.Location = new System.Drawing.Point(1183, 426);
            this.btnAICheckConflict.Name = "btnAICheckConflict";
            this.btnAICheckConflict.PressedDepth = 100;
            this.btnAICheckConflict.ShadowDecoration.BorderRadius = 18;
            this.btnAICheckConflict.ShadowDecoration.Depth = 10;
            this.btnAICheckConflict.ShadowDecoration.Enabled = true;
            this.btnAICheckConflict.Size = new System.Drawing.Size(216, 58);
            this.btnAICheckConflict.TabIndex = 33;
            this.btnAICheckConflict.Text = "⚠️ AI Kiểm tra trùng lịch";
            this.btnAICheckConflict.Click += new System.EventHandler(this.btnAICheckConflict_Click);
            // 
            // dgvRegisterList
            // 
            this.dgvRegisterList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dgvRegisterList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRegisterList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegisterList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegisterList.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRegisterList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRegisterList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvRegisterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegisterList.Location = new System.Drawing.Point(7, 521);
            this.dgvRegisterList.Name = "dgvRegisterList";
            this.dgvRegisterList.RowHeadersVisible = false;
            this.dgvRegisterList.RowHeadersWidth = 62;
            this.dgvRegisterList.RowTemplate.Height = 28;
            this.dgvRegisterList.Size = new System.Drawing.Size(1452, 391);
            this.dgvRegisterList.TabIndex = 34;
            this.dgvRegisterList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRegisterList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvRegisterList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvRegisterList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvRegisterList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvRegisterList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvRegisterList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvRegisterList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvRegisterList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRegisterList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRegisterList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRegisterList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRegisterList.ThemeStyle.HeaderStyle.Height = 35;
            this.dgvRegisterList.ThemeStyle.ReadOnly = false;
            this.dgvRegisterList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvRegisterList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRegisterList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRegisterList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvRegisterList.ThemeStyle.RowsStyle.Height = 28;
            this.dgvRegisterList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvRegisterList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // cboStudent
            // 
            this.cboStudent.BackColor = System.Drawing.Color.Transparent;
            this.cboStudent.BorderColor = System.Drawing.Color.DarkGray;
            this.cboStudent.BorderRadius = 8;
            this.cboStudent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudent.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStudent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStudent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboStudent.ItemHeight = 30;
            this.cboStudent.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStudent.Location = new System.Drawing.Point(209, 89);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.Size = new System.Drawing.Size(593, 36);
            this.cboStudent.TabIndex = 35;
            this.cboStudent.SelectedIndexChanged += new System.EventHandler(this.cboStudent_SelectedIndexChanged_1);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator2.FillThickness = 3;
            this.guna2Separator2.Location = new System.Drawing.Point(7, 918);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(1452, 16);
            this.guna2Separator2.TabIndex = 36;
            // 
            // f_RegisterCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.cboStudent);
            this.Controls.Add(this.dgvRegisterList);
            this.Controls.Add(this.btnAICheckConflict);
            this.Controls.Add(this.btnAISuggest);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.btnUnregister);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Shapes1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBandau);
            this.Controls.Add(this.lstBandau);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblKetqua);
            this.Controls.Add(this.lstKetqua);
            this.Controls.Add(this.lblMonInfo);
            this.Controls.Add(this.label4);
            this.Name = "f_RegisterCourse";
            this.Size = new System.Drawing.Size(1462, 957);
            this.Load += new System.EventHandler(this.f_RegisterCourse_Load);
            this.panel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBandau;
        private System.Windows.Forms.Label lblKetqua;
        private System.Windows.Forms.ListBox lstBandau;
        private System.Windows.Forms.ListBox lstKetqua;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMonInfo;    // ← NÂNG CAO
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblHethong;
        private Guna.UI2.WinForms.Guna2Shapes guna2Shapes1;
        private Guna.UI2.WinForms.Guna2Button btnRemoveAll;
        private Guna.UI2.WinForms.Guna2Button btnMoveAll;
        private Guna.UI2.WinForms.Guna2Button btnRemoveOne;
        private Guna.UI2.WinForms.Guna2Button btnMoveOne;
        private Guna.UI2.WinForms.Guna2Button btnRegister;
        private Guna.UI2.WinForms.Guna2Button btnUnregister;
        private Guna.UI2.WinForms.Guna2Button btnSendRequest;
        private Guna.UI2.WinForms.Guna2Button btnAISuggest;
        private Guna.UI2.WinForms.Guna2Button btnAICheckConflict;
        private Guna.UI2.WinForms.Guna2DataGridView dgvRegisterList;
        private Guna.UI2.WinForms.Guna2ComboBox cboStudent;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
    }
}