namespace QuanLySinhVien
{
    partial class f_ManageCourse : System.Windows.Forms.UserControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.lblHethong = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddMa = new System.Windows.Forms.TextBox();
            this.txtAddTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudAddSotc = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAddTuan = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudAddHky = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddMota = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAICDIO = new System.Windows.Forms.Button();
            this.btnAIGenMota = new System.Windows.Forms.Button();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEditMa = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEditTen = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudEditSotc = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.nudEditTuan = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.nudEditHky = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEditMota = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.tabList = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearchList = new System.Windows.Forms.TextBox();
            this.btnSearchList = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cboFilterSemester = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvCourse = new System.Windows.Forms.DataGridView();
            this.erpCourse = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabAdd.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddSotc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddTuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddHky)).BeginInit();
            this.tabEdit.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditSotc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditTuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditHky)).BeginInit();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAdd);
            this.tabControl1.Controls.Add(this.tabEdit);
            this.tabControl1.Controls.Add(this.tabList);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1462, 957);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAdd
            // 
            this.tabAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.tabAdd.Controls.Add(this.lblHethong);
            this.tabAdd.Controls.Add(this.panel1);
            this.tabAdd.Location = new System.Drawing.Point(4, 39);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(1454, 914);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Text = "  Thêm môn học  ";
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblHethong.Location = new System.Drawing.Point(9, 19);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(721, 54);
            this.lblHethong.TabIndex = 15;
            this.lblHethong.Text = "QUẢN LÝ MÔN HỌC - Thêm môn học";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAddMa);
            this.panel1.Controls.Add(this.txtAddTen);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.nudAddSotc);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.nudAddTuan);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nudAddHky);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAddMota);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnAICDIO);
            this.panel1.Controls.Add(this.btnAIGenMota);
            this.panel1.Location = new System.Drawing.Point(4, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1444, 800);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(45, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã môn học *";
            // 
            // txtAddMa
            // 
            this.txtAddMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddMa.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAddMa.Location = new System.Drawing.Point(51, 76);
            this.txtAddMa.Multiline = true;
            this.txtAddMa.Name = "txtAddMa";
            this.txtAddMa.Size = new System.Drawing.Size(910, 42);
            this.txtAddMa.TabIndex = 1;
            // 
            // txtAddTen
            // 
            this.txtAddTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddTen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAddTen.Location = new System.Drawing.Point(52, 184);
            this.txtAddTen.Multiline = true;
            this.txtAddTen.Name = "txtAddTen";
            this.txtAddTen.Size = new System.Drawing.Size(909, 42);
            this.txtAddTen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label2.Location = new System.Drawing.Point(46, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên môn học *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label3.Location = new System.Drawing.Point(47, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số tín chỉ *";
            // 
            // nudAddSotc
            // 
            this.nudAddSotc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudAddSotc.Location = new System.Drawing.Point(51, 289);
            this.nudAddSotc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAddSotc.Name = "nudAddSotc";
            this.nudAddSotc.Size = new System.Drawing.Size(376, 39);
            this.nudAddSotc.TabIndex = 5;
            this.nudAddSotc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(520, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Số tuần *";
            // 
            // nudAddTuan
            // 
            this.nudAddTuan.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudAddTuan.Location = new System.Drawing.Point(526, 289);
            this.nudAddTuan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudAddTuan.Name = "nudAddTuan";
            this.nudAddTuan.Size = new System.Drawing.Size(376, 39);
            this.nudAddTuan.TabIndex = 7;
            this.nudAddTuan.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label5.Location = new System.Drawing.Point(957, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Học kỳ *";
            // 
            // nudAddHky
            // 
            this.nudAddHky.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudAddHky.Location = new System.Drawing.Point(963, 289);
            this.nudAddHky.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudAddHky.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAddHky.Name = "nudAddHky";
            this.nudAddHky.Size = new System.Drawing.Size(376, 39);
            this.nudAddHky.TabIndex = 9;
            this.nudAddHky.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label6.Location = new System.Drawing.Point(47, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mô tả";
            // 
            // txtAddMota
            // 
            this.txtAddMota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddMota.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAddMota.Location = new System.Drawing.Point(53, 408);
            this.txtAddMota.Multiline = true;
            this.txtAddMota.Name = "txtAddMota";
            this.txtAddMota.Size = new System.Drawing.Size(1286, 193);
            this.txtAddMota.TabIndex = 11;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(550, 630);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(262, 93);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "➕ THÊM";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_Handler);
            // 
            // btnAICDIO
            // 
            this.btnAICDIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAICDIO.FlatAppearance.BorderSize = 0;
            this.btnAICDIO.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAICDIO.ForeColor = System.Drawing.Color.White;
            this.btnAICDIO.Location = new System.Drawing.Point(200, 630);
            this.btnAICDIO.Name = "btnAICDIO";
            this.btnAICDIO.Size = new System.Drawing.Size(262, 93);
            this.btnAICDIO.TabIndex = 13;
            this.btnAICDIO.Text = "📐 AI Đề xuất TC/Tuần (CDIO)";
            this.btnAICDIO.UseVisualStyleBackColor = false;
            // 
            // btnAIGenMota
            // 
            this.btnAIGenMota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(90)))), ((int)(((byte)(205)))));
            this.btnAIGenMota.FlatAppearance.BorderSize = 0;
            this.btnAIGenMota.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAIGenMota.ForeColor = System.Drawing.Color.White;
            this.btnAIGenMota.Location = new System.Drawing.Point(904, 630);
            this.btnAIGenMota.Name = "btnAIGenMota";
            this.btnAIGenMota.Size = new System.Drawing.Size(262, 93);
            this.btnAIGenMota.TabIndex = 14;
            this.btnAIGenMota.Text = "🤖 AI Sinh mô tả";
            this.btnAIGenMota.UseVisualStyleBackColor = false;
            // 
            // tabEdit
            // 
            this.tabEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.tabEdit.Controls.Add(this.label15);
            this.tabEdit.Controls.Add(this.panel3);
            this.tabEdit.Location = new System.Drawing.Point(4, 39);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(1454, 914);
            this.tabEdit.TabIndex = 1;
            this.tabEdit.Text = "  Sửa môn học  ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label15.Location = new System.Drawing.Point(9, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(686, 54);
            this.label15.TabIndex = 16;
            this.label15.Text = "QUẢN LÝ MÔN HỌC - Sửa môn học";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtEditMa);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.txtEditTen);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.nudEditSotc);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.nudEditTuan);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.nudEditHky);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.txtEditMota);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnDel);
            this.panel3.Location = new System.Drawing.Point(4, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1447, 586);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label7.Location = new System.Drawing.Point(173, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã môn học";
            // 
            // txtEditMa
            // 
            this.txtEditMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEditMa.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEditMa.Location = new System.Drawing.Point(178, 67);
            this.txtEditMa.Name = "txtEditMa";
            this.txtEditMa.Size = new System.Drawing.Size(730, 37);
            this.txtEditMa.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(957, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(147, 48);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔎 TÌM";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label8.Location = new System.Drawing.Point(173, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 30);
            this.label8.TabIndex = 3;
            this.label8.Text = "Tên môn học";
            // 
            // txtEditTen
            // 
            this.txtEditTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEditTen.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEditTen.Location = new System.Drawing.Point(178, 157);
            this.txtEditTen.Name = "txtEditTen";
            this.txtEditTen.Size = new System.Drawing.Size(730, 37);
            this.txtEditTen.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label9.Location = new System.Drawing.Point(173, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 30);
            this.label9.TabIndex = 5;
            this.label9.Text = "Số tín chỉ";
            // 
            // nudEditSotc
            // 
            this.nudEditSotc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudEditSotc.Location = new System.Drawing.Point(178, 260);
            this.nudEditSotc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEditSotc.Name = "nudEditSotc";
            this.nudEditSotc.Size = new System.Drawing.Size(278, 37);
            this.nudEditSotc.TabIndex = 6;
            this.nudEditSotc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label10.Location = new System.Drawing.Point(604, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 30);
            this.label10.TabIndex = 7;
            this.label10.Text = "Số tuần";
            // 
            // nudEditTuan
            // 
            this.nudEditTuan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudEditTuan.Location = new System.Drawing.Point(609, 260);
            this.nudEditTuan.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudEditTuan.Name = "nudEditTuan";
            this.nudEditTuan.Size = new System.Drawing.Size(278, 37);
            this.nudEditTuan.TabIndex = 8;
            this.nudEditTuan.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label11.Location = new System.Drawing.Point(952, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 30);
            this.label11.TabIndex = 9;
            this.label11.Text = "Học kỳ";
            // 
            // nudEditHky
            // 
            this.nudEditHky.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.nudEditHky.Location = new System.Drawing.Point(957, 260);
            this.nudEditHky.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nudEditHky.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudEditHky.Name = "nudEditHky";
            this.nudEditHky.Size = new System.Drawing.Size(278, 37);
            this.nudEditHky.TabIndex = 10;
            this.nudEditHky.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label12.Location = new System.Drawing.Point(173, 334);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 30);
            this.label12.TabIndex = 11;
            this.label12.Text = "Mô tả";
            // 
            // txtEditMota
            // 
            this.txtEditMota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEditMota.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEditMota.Location = new System.Drawing.Point(178, 367);
            this.txtEditMota.Name = "txtEditMota";
            this.txtEditMota.Size = new System.Drawing.Size(730, 37);
            this.txtEditMota.TabIndex = 12;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(328, 470);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(340, 73);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "✏️ LƯU SỬA";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDel.ForeColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(736, 470);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(340, 73);
            this.btnDel.TabIndex = 14;
            this.btnDel.Text = "🗑️ XÓA";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tabList
            // 
            this.tabList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.tabList.Controls.Add(this.label16);
            this.tabList.Controls.Add(this.label13);
            this.tabList.Controls.Add(this.txtSearchList);
            this.tabList.Controls.Add(this.btnSearchList);
            this.tabList.Controls.Add(this.label14);
            this.tabList.Controls.Add(this.cboFilterSemester);
            this.tabList.Controls.Add(this.btnRefresh);
            this.tabList.Controls.Add(this.dgvCourse);
            this.tabList.Location = new System.Drawing.Point(4, 39);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(1454, 914);
            this.tabList.TabIndex = 2;
            this.tabList.Text = "  Danh sách môn học";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label16.Location = new System.Drawing.Point(9, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(809, 54);
            this.label16.TabIndex = 16;
            this.label16.Text = "QUẢN LÝ MÔN HỌC - Danh sách môn học";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label13.Location = new System.Drawing.Point(18, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 30);
            this.label13.TabIndex = 1;
            this.label13.Text = "Tìm kiếm:";
            // 
            // txtSearchList
            // 
            this.txtSearchList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchList.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearchList.Location = new System.Drawing.Point(138, 99);
            this.txtSearchList.Name = "txtSearchList";
            this.txtSearchList.Size = new System.Drawing.Size(280, 37);
            this.txtSearchList.TabIndex = 2;
            // 
            // btnSearchList
            // 
            this.btnSearchList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSearchList.FlatAppearance.BorderSize = 0;
            this.btnSearchList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearchList.ForeColor = System.Drawing.Color.White;
            this.btnSearchList.Location = new System.Drawing.Point(439, 94);
            this.btnSearchList.Name = "btnSearchList";
            this.btnSearchList.Size = new System.Drawing.Size(126, 48);
            this.btnSearchList.TabIndex = 3;
            this.btnSearchList.Text = "🔎 Tìm";
            this.btnSearchList.UseVisualStyleBackColor = false;
            this.btnSearchList.Click += new System.EventHandler(this.btnSearchList_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label14.Location = new System.Drawing.Point(601, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 30);
            this.label14.TabIndex = 4;
            this.label14.Text = "Lọc HK:";
            // 
            // cboFilterSemester
            // 
            this.cboFilterSemester.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboFilterSemester.Location = new System.Drawing.Point(698, 99);
            this.cboFilterSemester.Name = "cboFilterSemester";
            this.cboFilterSemester.Size = new System.Drawing.Size(282, 38);
            this.cboFilterSemester.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1004, 90);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(173, 57);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "🔄 LÀM MỚI";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_Handler);
            // 
            // dgvCourse
            // 
            this.dgvCourse.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.dgvCourse.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCourse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourse.BackgroundColor = System.Drawing.Color.White;
            this.dgvCourse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCourse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCourse.ColumnHeadersHeight = 38;
            this.dgvCourse.EnableHeadersVisualStyles = false;
            this.dgvCourse.Location = new System.Drawing.Point(4, 153);
            this.dgvCourse.Name = "dgvCourse";
            this.dgvCourse.RowHeadersVisible = false;
            this.dgvCourse.RowHeadersWidth = 62;
            this.dgvCourse.RowTemplate.Height = 30;
            this.dgvCourse.Size = new System.Drawing.Size(1444, 746);
            this.dgvCourse.TabIndex = 1;
            this.dgvCourse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourse_CellContentClick);
            // 
            // erpCourse
            // 
            this.erpCourse.ContainerControl = this;
            // 
            // f_ManageCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "f_ManageCourse";
            this.Size = new System.Drawing.Size(1462, 957);
            this.Load += new System.EventHandler(this.f_ManageCourse_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddSotc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddTuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddHky)).EndInit();
            this.tabEdit.ResumeLayout(false);
            this.tabEdit.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditSotc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditTuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditHky)).EndInit();
            this.tabList.ResumeLayout(false);
            this.tabList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCourse)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAddSotc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAddTuan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudAddHky;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddMota;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAICDIO;
        private System.Windows.Forms.Button btnAIGenMota;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEditMa;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEditTen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudEditSotc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudEditTuan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudEditHky;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEditMota;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSearchList;
        private System.Windows.Forms.Button btnSearchList;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboFilterSemester;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvCourse;
        private System.Windows.Forms.ErrorProvider erpCourse;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}