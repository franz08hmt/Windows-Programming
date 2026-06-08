namespace QuanLySinhVien
{
    partial class f_HomePage
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
            this.lblXinChao = new System.Windows.Forms.Label();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblHethong = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.bttAdd = new System.Windows.Forms.Button();
            this.bttList = new System.Windows.Forms.Button();
            this.bttFix = new System.Windows.Forms.Button();
            this.btnManageClassroom = new System.Windows.Forms.Button();
            this.btnRegisterMenu = new System.Windows.Forms.Button();
            this.btnManageCourse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStudentScore = new System.Windows.Forms.Button();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.btnAccountManage = new System.Windows.Forms.Button();
            this.btnManageRequest = new System.Windows.Forms.Button();
            this.bttLogout = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.txtChatInput = new System.Windows.Forms.TextBox();
            this.rtbChatHistory = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCardHR = new System.Windows.Forms.Panel();
            this.lblCardHRTitle = new System.Windows.Forms.Label();
            this.lblTotalHR = new System.Windows.Forms.Label();
            this.pnlCardPending = new System.Windows.Forms.Panel();
            this.lblCardPendingTitle = new System.Windows.Forms.Label();
            this.lblTotalPending = new System.Windows.Forms.Label();
            this.pnlCardSV = new System.Windows.Forms.Panel();
            this.lblCardSVTitle = new System.Windows.Forms.Label();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.pnlTaiKhoanHR = new System.Windows.Forms.Panel();
            this.pnlChoDuyet = new System.Windows.Forms.Panel();
            this.pnlTongSinhVien = new System.Windows.Forms.Panel();
            this.lblTongQuan = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlChat.SuspendLayout();
            this.pnlCardHR.SuspendLayout();
            this.pnlCardPending.SuspendLayout();
            this.pnlCardSV.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.lblXinChao);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblHethong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1105, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblXinChao
            // 
            this.lblXinChao.AutoSize = true;
            this.lblXinChao.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblXinChao.ForeColor = System.Drawing.Color.Silver;
            this.lblXinChao.Location = new System.Drawing.Point(870, 34);
            this.lblXinChao.Name = "lblXinChao";
            this.lblXinChao.Size = new System.Drawing.Size(91, 25);
            this.lblXinChao.TabIndex = 0;
            this.lblXinChao.Text = "Xin chào, ";
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
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(90, 22);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(502, 45);
            this.lblHethong.TabIndex = 2;
            this.lblHethong.Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(137)))));
            this.pnlSidebar.Controls.Add(this.bttAdd);
            this.pnlSidebar.Controls.Add(this.bttList);
            this.pnlSidebar.Controls.Add(this.bttFix);
            this.pnlSidebar.Controls.Add(this.btnManageClassroom);
            this.pnlSidebar.Controls.Add(this.btnRegisterMenu);
            this.pnlSidebar.Controls.Add(this.btnManageCourse);
            this.pnlSidebar.Controls.Add(this.button1);
            this.pnlSidebar.Controls.Add(this.btnStudentScore);
            this.pnlSidebar.Controls.Add(this.btnStatistic);
            this.pnlSidebar.Controls.Add(this.btnAccountManage);
            this.pnlSidebar.Controls.Add(this.btnManageRequest);
            this.pnlSidebar.Controls.Add(this.bttLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 90);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(210, 625);
            this.pnlSidebar.TabIndex = 1;
            // 
            // bttAdd
            // 
            this.bttAdd.FlatAppearance.BorderSize = 0;
            this.bttAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.bttAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.bttAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bttAdd.ForeColor = System.Drawing.Color.White;
            this.bttAdd.Location = new System.Drawing.Point(0, 0);
            this.bttAdd.Name = "bttAdd";
            this.bttAdd.Size = new System.Drawing.Size(210, 44);
            this.bttAdd.TabIndex = 0;
            this.bttAdd.Text = "➕ Thêm sinh viên";
            this.bttAdd.UseVisualStyleBackColor = true;
            this.bttAdd.Click += new System.EventHandler(this.bttAdd_Click);
            // 
            // bttList
            // 
            this.bttList.FlatAppearance.BorderSize = 0;
            this.bttList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.bttList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.bttList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bttList.ForeColor = System.Drawing.Color.White;
            this.bttList.Location = new System.Drawing.Point(0, 44);
            this.bttList.Name = "bttList";
            this.bttList.Size = new System.Drawing.Size(210, 44);
            this.bttList.TabIndex = 1;
            this.bttList.Text = "📋 Danh sách SV";
            this.bttList.UseVisualStyleBackColor = true;
            this.bttList.Click += new System.EventHandler(this.bttList_Click);
            // 
            // bttFix
            // 
            this.bttFix.FlatAppearance.BorderSize = 0;
            this.bttFix.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.bttFix.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.bttFix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttFix.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bttFix.ForeColor = System.Drawing.Color.White;
            this.bttFix.Location = new System.Drawing.Point(0, 88);
            this.bttFix.Name = "bttFix";
            this.bttFix.Size = new System.Drawing.Size(210, 44);
            this.bttFix.TabIndex = 2;
            this.bttFix.Text = "✏️ Sửa/Xóa SV";
            this.bttFix.UseVisualStyleBackColor = true;
            this.bttFix.Click += new System.EventHandler(this.bttFix_Click);
            // 
            // btnManageClassroom
            // 
            this.btnManageClassroom.FlatAppearance.BorderSize = 0;
            this.btnManageClassroom.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnManageClassroom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnManageClassroom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageClassroom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageClassroom.ForeColor = System.Drawing.Color.White;
            this.btnManageClassroom.Location = new System.Drawing.Point(0, 132);
            this.btnManageClassroom.Name = "btnManageClassroom";
            this.btnManageClassroom.Size = new System.Drawing.Size(210, 44);
            this.btnManageClassroom.TabIndex = 3;
            this.btnManageClassroom.Text = "🏫 Quản lý lớp học";
            this.btnManageClassroom.UseVisualStyleBackColor = true;
            this.btnManageClassroom.Click += new System.EventHandler(this.btnManageClassroom_Click);
            // 
            // btnRegisterMenu
            // 
            this.btnRegisterMenu.FlatAppearance.BorderSize = 0;
            this.btnRegisterMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnRegisterMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnRegisterMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRegisterMenu.ForeColor = System.Drawing.Color.White;
            this.btnRegisterMenu.Location = new System.Drawing.Point(0, 176);
            this.btnRegisterMenu.Name = "btnRegisterMenu";
            this.btnRegisterMenu.Size = new System.Drawing.Size(210, 44);
            this.btnRegisterMenu.TabIndex = 4;
            this.btnRegisterMenu.Text = "📚 Đăng ký môn học";
            this.btnRegisterMenu.UseVisualStyleBackColor = true;
            this.btnRegisterMenu.Click += new System.EventHandler(this.btnRegisterMenu_Click);
            // 
            // btnManageCourse
            // 
            this.btnManageCourse.FlatAppearance.BorderSize = 0;
            this.btnManageCourse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnManageCourse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnManageCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageCourse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageCourse.ForeColor = System.Drawing.Color.White;
            this.btnManageCourse.Location = new System.Drawing.Point(0, 220);
            this.btnManageCourse.Name = "btnManageCourse";
            this.btnManageCourse.Size = new System.Drawing.Size(210, 44);
            this.btnManageCourse.TabIndex = 5;
            this.btnManageCourse.Text = "📖 Quản lý môn học";
            this.btnManageCourse.UseVisualStyleBackColor = true;
            this.btnManageCourse.Click += new System.EventHandler(this.btnManageCourse_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "📊 Quản lý điểm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStudentScore
            // 
            this.btnStudentScore.FlatAppearance.BorderSize = 0;
            this.btnStudentScore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnStudentScore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnStudentScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentScore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStudentScore.ForeColor = System.Drawing.Color.White;
            this.btnStudentScore.Location = new System.Drawing.Point(0, 308);
            this.btnStudentScore.Name = "btnStudentScore";
            this.btnStudentScore.Size = new System.Drawing.Size(210, 44);
            this.btnStudentScore.TabIndex = 11;
            this.btnStudentScore.Text = "🎓 Xem bảng điểm";
            this.btnStudentScore.UseVisualStyleBackColor = true;
            this.btnStudentScore.Visible = false;
            this.btnStudentScore.Click += new System.EventHandler(this.btnStudentScore_Click);
            // 
            // btnStatistic
            // 
            this.btnStatistic.FlatAppearance.BorderSize = 0;
            this.btnStatistic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnStatistic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistic.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnStatistic.ForeColor = System.Drawing.Color.White;
            this.btnStatistic.Location = new System.Drawing.Point(0, 352);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(210, 44);
            this.btnStatistic.TabIndex = 7;
            this.btnStatistic.Text = "📈 Thống kê";
            this.btnStatistic.UseVisualStyleBackColor = true;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // btnAccountManage
            // 
            this.btnAccountManage.FlatAppearance.BorderSize = 0;
            this.btnAccountManage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnAccountManage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnAccountManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountManage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAccountManage.ForeColor = System.Drawing.Color.White;
            this.btnAccountManage.Location = new System.Drawing.Point(0, 396);
            this.btnAccountManage.Name = "btnAccountManage";
            this.btnAccountManage.Size = new System.Drawing.Size(210, 44);
            this.btnAccountManage.TabIndex = 8;
            this.btnAccountManage.Text = "👤 Quản lý tài khoản";
            this.btnAccountManage.UseVisualStyleBackColor = true;
            this.btnAccountManage.Visible = false;
            this.btnAccountManage.Click += new System.EventHandler(this.btnAccountManage_Click);
            // 
            // btnManageRequest
            // 
            this.btnManageRequest.FlatAppearance.BorderSize = 0;
            this.btnManageRequest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnManageRequest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnManageRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageRequest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnManageRequest.ForeColor = System.Drawing.Color.White;
            this.btnManageRequest.Location = new System.Drawing.Point(0, 440);
            this.btnManageRequest.Name = "btnManageRequest";
            this.btnManageRequest.Size = new System.Drawing.Size(210, 44);
            this.btnManageRequest.TabIndex = 10;
            this.btnManageRequest.Text = "📨 Quản lý yêu cầu";
            this.btnManageRequest.UseVisualStyleBackColor = true;
            this.btnManageRequest.Visible = false;
            this.btnManageRequest.Click += new System.EventHandler(this.btnManageRequest_Click);
            // 
            // bttLogout
            // 
            this.bttLogout.FlatAppearance.BorderSize = 0;
            this.bttLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.bttLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.bttLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bttLogout.ForeColor = System.Drawing.Color.OrangeRed;
            this.bttLogout.Location = new System.Drawing.Point(0, 572);
            this.bttLogout.Name = "bttLogout";
            this.bttLogout.Size = new System.Drawing.Size(210, 44);
            this.bttLogout.TabIndex = 9;
            this.bttLogout.Text = "🚪 Đăng xuất";
            this.bttLogout.UseVisualStyleBackColor = true;
            this.bttLogout.Click += new System.EventHandler(this.bttLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlContent.Controls.Add(this.pnlChat);
            this.pnlContent.Controls.Add(this.pnlCardHR);
            this.pnlContent.Controls.Add(this.pnlCardPending);
            this.pnlContent.Controls.Add(this.pnlCardSV);
            this.pnlContent.Controls.Add(this.pnlTaiKhoanHR);
            this.pnlContent.Controls.Add(this.pnlChoDuyet);
            this.pnlContent.Controls.Add(this.pnlTongSinhVien);
            this.pnlContent.Controls.Add(this.lblTongQuan);
            this.pnlContent.Location = new System.Drawing.Point(210, 90);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContent.Size = new System.Drawing.Size(895, 625);
            this.pnlContent.TabIndex = 2;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pnlChat
            // 
            this.pnlChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChat.BackColor = System.Drawing.Color.White;
            this.pnlChat.Controls.Add(this.btnSendChat);
            this.pnlChat.Controls.Add(this.txtChatInput);
            this.pnlChat.Controls.Add(this.rtbChatHistory);
            this.pnlChat.Controls.Add(this.label1);
            this.pnlChat.Location = new System.Drawing.Point(20, 200);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(840, 360);
            this.pnlChat.TabIndex = 6;
            // 
            // btnSendChat
            // 
            this.btnSendChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnSendChat.FlatAppearance.BorderSize = 0;
            this.btnSendChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendChat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSendChat.ForeColor = System.Drawing.Color.White;
            this.btnSendChat.Location = new System.Drawing.Point(725, 303);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(100, 34);
            this.btnSendChat.TabIndex = 0;
            this.btnSendChat.Text = "Gửi ➤";
            this.btnSendChat.UseVisualStyleBackColor = false;
            this.btnSendChat.Click += new System.EventHandler(this.btnSendChat_Click);
            // 
            // txtChatInput
            // 
            this.txtChatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChatInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChatInput.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtChatInput.Location = new System.Drawing.Point(15, 305);
            this.txtChatInput.Name = "txtChatInput";
            this.txtChatInput.Size = new System.Drawing.Size(700, 34);
            this.txtChatInput.TabIndex = 1;
            this.txtChatInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatInput_KeyDown);
            // 
            // rtbChatHistory
            // 
            this.rtbChatHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChatHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.rtbChatHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChatHistory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtbChatHistory.Location = new System.Drawing.Point(15, 40);
            this.rtbChatHistory.Name = "rtbChatHistory";
            this.rtbChatHistory.ReadOnly = true;
            this.rtbChatHistory.Size = new System.Drawing.Size(810, 250);
            this.rtbChatHistory.TabIndex = 2;
            this.rtbChatHistory.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "🤖 Trợ lý hệ thống";
            // 
            // pnlCardHR
            // 
            this.pnlCardHR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
            this.pnlCardHR.Controls.Add(this.lblCardHRTitle);
            this.pnlCardHR.Controls.Add(this.lblTotalHR);
            this.pnlCardHR.Location = new System.Drawing.Point(540, 60);
            this.pnlCardHR.Name = "pnlCardHR";
            this.pnlCardHR.Size = new System.Drawing.Size(240, 120);
            this.pnlCardHR.TabIndex = 5;
            this.pnlCardHR.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTaiKhoanHR_Paint);
            // 
            // lblCardHRTitle
            // 
            this.lblCardHRTitle.AutoSize = true;
            this.lblCardHRTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardHRTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(230)))), ((int)(((byte)(190)))));
            this.lblCardHRTitle.Location = new System.Drawing.Point(15, 12);
            this.lblCardHRTitle.Name = "lblCardHRTitle";
            this.lblCardHRTitle.Size = new System.Drawing.Size(144, 25);
            this.lblCardHRTitle.TabIndex = 0;
            this.lblCardHRTitle.Text = "TÀI KHOẢN HR";
            // 
            // lblTotalHR
            // 
            this.lblTotalHR.AutoSize = true;
            this.lblTotalHR.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalHR.ForeColor = System.Drawing.Color.White;
            this.lblTotalHR.Location = new System.Drawing.Point(15, 35);
            this.lblTotalHR.Name = "lblTotalHR";
            this.lblTotalHR.Size = new System.Drawing.Size(74, 86);
            this.lblTotalHR.TabIndex = 1;
            this.lblTotalHR.Text = "0";
            // 
            // pnlCardPending
            // 
            this.pnlCardPending.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(60)))));
            this.pnlCardPending.Controls.Add(this.lblCardPendingTitle);
            this.pnlCardPending.Controls.Add(this.lblTotalPending);
            this.pnlCardPending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlCardPending.Location = new System.Drawing.Point(280, 60);
            this.pnlCardPending.Name = "pnlCardPending";
            this.pnlCardPending.Size = new System.Drawing.Size(240, 120);
            this.pnlCardPending.TabIndex = 4;
            this.pnlCardPending.Click += new System.EventHandler(this.pnlChoDuyet_Click);
            this.pnlCardPending.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChoDuyet_Paint);
            // 
            // lblCardPendingTitle
            // 
            this.lblCardPendingTitle.AutoSize = true;
            this.lblCardPendingTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardPendingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.lblCardPendingTitle.Location = new System.Drawing.Point(15, 12);
            this.lblCardPendingTitle.Name = "lblCardPendingTitle";
            this.lblCardPendingTitle.Size = new System.Drawing.Size(154, 25);
            this.lblCardPendingTitle.TabIndex = 0;
            this.lblCardPendingTitle.Text = "CHỜ PHÊ DUYỆT";
            // 
            // lblTotalPending
            // 
            this.lblTotalPending.AutoSize = true;
            this.lblTotalPending.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalPending.ForeColor = System.Drawing.Color.White;
            this.lblTotalPending.Location = new System.Drawing.Point(15, 35);
            this.lblTotalPending.Name = "lblTotalPending";
            this.lblTotalPending.Size = new System.Drawing.Size(74, 86);
            this.lblTotalPending.TabIndex = 1;
            this.lblTotalPending.Text = "0";
            this.lblTotalPending.Click += new System.EventHandler(this.pnlChoDuyet_Click);
            // 
            // pnlCardSV
            // 
            this.pnlCardSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlCardSV.Controls.Add(this.lblCardSVTitle);
            this.pnlCardSV.Controls.Add(this.lblTotalStudents);
            this.pnlCardSV.Location = new System.Drawing.Point(20, 60);
            this.pnlCardSV.Name = "pnlCardSV";
            this.pnlCardSV.Size = new System.Drawing.Size(240, 120);
            this.pnlCardSV.TabIndex = 3;
            this.pnlCardSV.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTongSinhVien_Paint);
            // 
            // lblCardSVTitle
            // 
            this.lblCardSVTitle.AutoSize = true;
            this.lblCardSVTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardSVTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.lblCardSVTitle.Location = new System.Drawing.Point(15, 12);
            this.lblCardSVTitle.Name = "lblCardSVTitle";
            this.lblCardSVTitle.Size = new System.Drawing.Size(160, 25);
            this.lblCardSVTitle.TabIndex = 0;
            this.lblCardSVTitle.Text = "TỔNG SINH VIÊN";
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudents.ForeColor = System.Drawing.Color.White;
            this.lblTotalStudents.Location = new System.Drawing.Point(15, 35);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(74, 86);
            this.lblTotalStudents.TabIndex = 1;
            this.lblTotalStudents.Text = "0";
            // 
            // pnlTaiKhoanHR
            // 
            this.pnlTaiKhoanHR.Location = new System.Drawing.Point(-500, -500);
            this.pnlTaiKhoanHR.Name = "pnlTaiKhoanHR";
            this.pnlTaiKhoanHR.Size = new System.Drawing.Size(1, 1);
            this.pnlTaiKhoanHR.TabIndex = 7;
            this.pnlTaiKhoanHR.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTaiKhoanHR_Paint);
            // 
            // pnlChoDuyet
            // 
            this.pnlChoDuyet.Location = new System.Drawing.Point(-500, -500);
            this.pnlChoDuyet.Name = "pnlChoDuyet";
            this.pnlChoDuyet.Size = new System.Drawing.Size(1, 1);
            this.pnlChoDuyet.TabIndex = 8;
            this.pnlChoDuyet.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChoDuyet_Paint);
            // 
            // pnlTongSinhVien
            // 
            this.pnlTongSinhVien.Location = new System.Drawing.Point(-500, -500);
            this.pnlTongSinhVien.Name = "pnlTongSinhVien";
            this.pnlTongSinhVien.Size = new System.Drawing.Size(1, 1);
            this.pnlTongSinhVien.TabIndex = 9;
            this.pnlTongSinhVien.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTongSinhVien_Paint);
            // 
            // lblTongQuan
            // 
            this.lblTongQuan.AutoSize = true;
            this.lblTongQuan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongQuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblTongQuan.Location = new System.Drawing.Point(20, 15);
            this.lblTongQuan.Name = "lblTongQuan";
            this.lblTongQuan.Size = new System.Drawing.Size(338, 38);
            this.lblTongQuan.TabIndex = 10;
            this.lblTongQuan.Text = "TỔNG QUAN HỆ THỐNG";
            // 
            // f_HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 715);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "f_HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Sinh Viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.f_HomePage_FormClosed);
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            this.pnlCardHR.ResumeLayout(false);
            this.pnlCardHR.PerformLayout();
            this.pnlCardPending.ResumeLayout(false);
            this.pnlCardPending.PerformLayout();
            this.pnlCardSV.ResumeLayout(false);
            this.pnlCardSV.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button bttAdd;
        private System.Windows.Forms.Button bttList;
        private System.Windows.Forms.Button bttFix;
        private System.Windows.Forms.Button btnManageClassroom;
        private System.Windows.Forms.Button btnRegisterMenu;
        private System.Windows.Forms.Button btnManageCourse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStudentScore;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.Button btnAccountManage;
        private System.Windows.Forms.Button btnManageRequest;
        private System.Windows.Forms.Button bttLogout;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblTongQuan;
        private System.Windows.Forms.Panel pnlCardSV;
        private System.Windows.Forms.Label lblCardSVTitle;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Panel pnlCardPending;
        private System.Windows.Forms.Label lblCardPendingTitle;
        private System.Windows.Forms.Label lblTotalPending;
        private System.Windows.Forms.Panel pnlCardHR;
        private System.Windows.Forms.Label lblCardHRTitle;
        private System.Windows.Forms.Label lblTotalHR;
        private System.Windows.Forms.Panel pnlTongSinhVien;
        private System.Windows.Forms.Panel pnlChoDuyet;
        private System.Windows.Forms.Panel pnlTaiKhoanHR;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbChatHistory;
        private System.Windows.Forms.TextBox txtChatInput;
        private System.Windows.Forms.Button btnSendChat;
    }
}