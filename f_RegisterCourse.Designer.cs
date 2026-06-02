namespace QuanLySinhVien
{
    partial class f_RegisterCourse
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDangKy = new System.Windows.Forms.TabPage();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnMoveSelected = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstKetqua = new System.Windows.Forms.ListBox();
            this.lstBandau = new System.Windows.Forms.ListBox();
            this.btnRemoveSelected = new System.Windows.Forms.Button();
            this.btnMoveAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChiTietMon = new System.Windows.Forms.Label();
            this.btn_AIExtra = new System.Windows.Forms.Button();
            this.lblTongTC = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboHky = new System.Windows.Forms.ComboBox();
            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblHethong = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabDanhSachDaDK = new System.Windows.Forms.TabPage();
            this.dgvDaDangKy = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnHuyDangKy = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabDangKy.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.tabDanhSachDaDK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDangKy)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDangKy);
            this.tabControl1.Controls.Add(this.tabDanhSachDaDK);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1141, 681);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDangKy
            // 
            this.tabDangKy.Controls.Add(this.btnRemoveAll);
            this.tabDangKy.Controls.Add(this.btnMoveSelected);
            this.tabDangKy.Controls.Add(this.label3);
            this.tabDangKy.Controls.Add(this.lstKetqua);
            this.tabDangKy.Controls.Add(this.lstBandau);
            this.tabDangKy.Controls.Add(this.btnRemoveSelected);
            this.tabDangKy.Controls.Add(this.btnMoveAll);
            this.tabDangKy.Controls.Add(this.panel1);
            this.tabDangKy.Controls.Add(this.pnlHeader);
            this.tabDangKy.Controls.Add(this.label4);
            this.tabDangKy.Location = new System.Drawing.Point(4, 22);
            this.tabDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.tabDangKy.Name = "tabDangKy";
            this.tabDangKy.Padding = new System.Windows.Forms.Padding(2);
            this.tabDangKy.Size = new System.Drawing.Size(1133, 655);
            this.tabDangKy.TabIndex = 0;
            this.tabDangKy.Text = "Đăng ký môn học";
            this.tabDangKy.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnRemoveAll.Location = new System.Drawing.Point(518, 468);
            this.btnRemoveAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(49, 70);
            this.btnRemoveAll.TabIndex = 36;
            this.btnRemoveAll.Text = "⇐";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnMoveSelected
            // 
            this.btnMoveSelected.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnMoveSelected.Location = new System.Drawing.Point(518, 290);
            this.btnMoveSelected.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoveSelected.Name = "btnMoveSelected";
            this.btnMoveSelected.Size = new System.Drawing.Size(49, 70);
            this.btnMoveSelected.TabIndex = 33;
            this.btnMoveSelected.Text = "⮕";
            this.btnMoveSelected.UseVisualStyleBackColor = true;
            this.btnMoveSelected.Click += new System.EventHandler(this.btnMoveSelected_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(589, 239);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 25);
            this.label3.TabIndex = 32;
            this.label3.Text = "Môn sẽ đăng ký :";
            // 
            // lstKetqua
            // 
            this.lstKetqua.FormattingEnabled = true;
            this.lstKetqua.Location = new System.Drawing.Point(594, 271);
            this.lstKetqua.Margin = new System.Windows.Forms.Padding(2);
            this.lstKetqua.Name = "lstKetqua";
            this.lstKetqua.Size = new System.Drawing.Size(532, 381);
            this.lstKetqua.TabIndex = 31;
            this.lstKetqua.SelectedIndexChanged += new System.EventHandler(this.lstKetqua_SelectedIndexChanged);
            // 
            // lstBandau
            // 
            this.lstBandau.FormattingEnabled = true;
            this.lstBandau.Location = new System.Drawing.Point(6, 271);
            this.lstBandau.Margin = new System.Windows.Forms.Padding(2);
            this.lstBandau.Name = "lstBandau";
            this.lstBandau.Size = new System.Drawing.Size(485, 381);
            this.lstBandau.TabIndex = 30;
            this.lstBandau.SelectedIndexChanged += new System.EventHandler(this.lstBandau_SelectedIndexChanged);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSelected.Location = new System.Drawing.Point(518, 558);
            this.btnRemoveSelected.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(49, 70);
            this.btnRemoveSelected.TabIndex = 35;
            this.btnRemoveSelected.Text = "⬅";
            this.btnRemoveSelected.UseVisualStyleBackColor = true;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnMoveAll
            // 
            this.btnMoveAll.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnMoveAll.Location = new System.Drawing.Point(518, 378);
            this.btnMoveAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnMoveAll.Name = "btnMoveAll";
            this.btnMoveAll.Size = new System.Drawing.Size(49, 70);
            this.btnMoveAll.TabIndex = 34;
            this.btnMoveAll.Text = "⇒";
            this.btnMoveAll.UseVisualStyleBackColor = true;
            this.btnMoveAll.Click += new System.EventHandler(this.btnMoveAll_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.lblChiTietMon);
            this.panel1.Controls.Add(this.btn_AIExtra);
            this.panel1.Controls.Add(this.lblTongTC);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboHky);
            this.panel1.Controls.Add(this.cboStudent);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 167);
            this.panel1.TabIndex = 29;
            // 
            // lblChiTietMon
            // 
            this.lblChiTietMon.AutoSize = true;
            this.lblChiTietMon.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblChiTietMon.Location = new System.Drawing.Point(4, 89);
            this.lblChiTietMon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChiTietMon.Name = "lblChiTietMon";
            this.lblChiTietMon.Size = new System.Drawing.Size(83, 19);
            this.lblChiTietMon.TabIndex = 12;
            this.lblChiTietMon.Text = "Thông báo: ";
            // 
            // btn_AIExtra
            // 
            this.btn_AIExtra.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btn_AIExtra.Location = new System.Drawing.Point(563, 13);
            this.btn_AIExtra.Margin = new System.Windows.Forms.Padding(2);
            this.btn_AIExtra.Name = "btn_AIExtra";
            this.btn_AIExtra.Size = new System.Drawing.Size(140, 56);
            this.btn_AIExtra.TabIndex = 11;
            this.btn_AIExtra.Text = "✨ AI Gợi ý lộ trình CDIO";
            this.btn_AIExtra.UseVisualStyleBackColor = true;
            this.btn_AIExtra.Click += new System.EventHandler(this.btn_AIExtra_Click);
            // 
            // lblTongTC
            // 
            this.lblTongTC.AutoSize = true;
            this.lblTongTC.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongTC.Location = new System.Drawing.Point(707, 13);
            this.lblTongTC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTC.Name = "lblTongTC";
            this.lblTongTC.Size = new System.Drawing.Size(110, 19);
            this.lblTongTC.TabIndex = 10;
            this.lblTongTC.Text = "Tổng số tín chỉ: ";
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Save.Location = new System.Drawing.Point(413, 13);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(134, 56);
            this.btn_Save.TabIndex = 9;
            this.btn_Save.Text = "💾 Lưu đăng ký";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Chọn Học kỳ :";
            // 
            // cboHky
            // 
            this.cboHky.FormattingEnabled = true;
            this.cboHky.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cboHky.Location = new System.Drawing.Point(135, 63);
            this.cboHky.Margin = new System.Windows.Forms.Padding(2);
            this.cboHky.Name = "cboHky";
            this.cboHky.Size = new System.Drawing.Size(263, 21);
            this.cboHky.TabIndex = 7;
            this.cboHky.SelectedIndexChanged += new System.EventHandler(this.cboHky_SelectedIndexChanged);
            // 
            // cboStudent
            // 
            this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudent.FormattingEnabled = true;
            this.cboStudent.Location = new System.Drawing.Point(135, 21);
            this.cboStudent.Margin = new System.Windows.Forms.Padding(2);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.Size = new System.Drawing.Size(263, 21);
            this.cboStudent.TabIndex = 3;
            this.cboStudent.SelectedIndexChanged += new System.EventHandler(this.cboStudent_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn Sinh viên :";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblHethong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(2, 2);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1129, 58);
            this.pnlHeader.TabIndex = 28;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1029, 0);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 58);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
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
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(54, 14);
            this.lblHethong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(225, 30);
            this.lblHethong.TabIndex = 0;
            this.lblHethong.Text = "ĐĂNG KÝ MÔN HỌC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(2, 239);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Môn chưa đăng ký :";
            // 
            // tabDanhSachDaDK
            // 
            this.tabDanhSachDaDK.Controls.Add(this.dgvDaDangKy);
            this.tabDanhSachDaDK.Controls.Add(this.panel3);
            this.tabDanhSachDaDK.Controls.Add(this.panel2);
            this.tabDanhSachDaDK.Location = new System.Drawing.Point(4, 22);
            this.tabDanhSachDaDK.Margin = new System.Windows.Forms.Padding(2);
            this.tabDanhSachDaDK.Name = "tabDanhSachDaDK";
            this.tabDanhSachDaDK.Padding = new System.Windows.Forms.Padding(2);
            this.tabDanhSachDaDK.Size = new System.Drawing.Size(1133, 655);
            this.tabDanhSachDaDK.TabIndex = 1;
            this.tabDanhSachDaDK.Text = "Môn đã đăng ký";
            this.tabDanhSachDaDK.UseVisualStyleBackColor = true;
            // 
            // dgvDaDangKy
            // 
            this.dgvDaDangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDaDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDaDangKy.Location = new System.Drawing.Point(0, 213);
            this.dgvDaDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDaDangKy.Name = "dgvDaDangKy";
            this.dgvDaDangKy.RowHeadersWidth = 62;
            this.dgvDaDangKy.RowTemplate.Height = 28;
            this.dgvDaDangKy.Size = new System.Drawing.Size(1131, 446);
            this.dgvDaDangKy.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.btnHuyDangKy);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.comboBox2);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(0, 58);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1131, 151);
            this.panel3.TabIndex = 30;
            // 
            // btnHuyDangKy
            // 
            this.btnHuyDangKy.BackColor = System.Drawing.Color.White;
            this.btnHuyDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyDangKy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuyDangKy.ForeColor = System.Drawing.Color.Firebrick;
            this.btnHuyDangKy.Location = new System.Drawing.Point(762, 35);
            this.btnHuyDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuyDangKy.Name = "btnHuyDangKy";
            this.btnHuyDangKy.Size = new System.Drawing.Size(126, 45);
            this.btnHuyDangKy.TabIndex = 13;
            this.btnHuyDangKy.Text = "Hủy Đăng Ký";
            this.btnHuyDangKy.UseVisualStyleBackColor = false;
            this.btnHuyDangKy.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(494, 30);
            this.label6.TabIndex = 12;
            this.label6.Text = "Danh sách môn học đã đăng ký của Sinh viên:  ";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(465, 59);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(263, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(522, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "Chọn Sinh viên :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 58);
            this.panel2.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1029, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 58);
            this.button1.TabIndex = 3;
            this.button1.Text = "⬅ Quay lại";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(54, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 30);
            this.label5.TabIndex = 0;
            this.label5.Text = "MÔN ĐÃ ĐĂNG KÝ";
            // 
            // f_RegisterCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 681);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "f_RegisterCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_RegisterCourse";
            this.Load += new System.EventHandler(this.f_RegisterCourse_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDangKy.ResumeLayout(false);
            this.tabDangKy.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.tabDanhSachDaDK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaDangKy)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDangKy;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnMoveSelected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstKetqua;
        private System.Windows.Forms.ListBox lstBandau;
        private System.Windows.Forms.Button btnRemoveSelected;
        private System.Windows.Forms.Button btnMoveAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChiTietMon;
        private System.Windows.Forms.Button btn_AIExtra;
        private System.Windows.Forms.Label lblTongTC;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboHky;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabDanhSachDaDK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvDaDangKy;
        private System.Windows.Forms.Button btnHuyDangKy;
    }
}