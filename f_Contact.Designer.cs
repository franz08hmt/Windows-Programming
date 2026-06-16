namespace QuanLySinhVien
{
    partial class f_Contact : System.Windows.Forms.UserControl
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
            this.tcbContact = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblHethong = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.cboGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.bntSearchContact = new System.Windows.Forms.Button();
            this.txtTotalContact = new System.Windows.Forms.Label();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.btnAISuggestGroup = new System.Windows.Forms.Button();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.txtSearchContact = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefreshContact = new System.Windows.Forms.Button();
            this.btnFixContact = new System.Windows.Forms.Button();
            this.btnDeleteContact = new System.Windows.Forms.Button();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lstSuggest = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboGroup2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.picContact = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.erpContact = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcbContact.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpContact)).BeginInit();
            this.SuspendLayout();
            // 
            // tcbContact
            // 
            this.tcbContact.Controls.Add(this.tabPage1);
            this.tcbContact.Controls.Add(this.tabPage2);
            this.tcbContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcbContact.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcbContact.Location = new System.Drawing.Point(0, 0);
            this.tcbContact.Name = "tcbContact";
            this.tcbContact.SelectedIndex = 0;
            this.tcbContact.Size = new System.Drawing.Size(1462, 957);
            this.tcbContact.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.tabPage1.Controls.Add(this.lblHethong);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 39);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1454, 914);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Quản lý nhóm";
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblHethong.Location = new System.Drawing.Point(6, 3);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(337, 54);
            this.lblHethong.TabIndex = 3;
            this.lblHethong.Text = "QUẢN LÝ NHÓM";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgvGroup);
            this.panel2.Controls.Add(this.cboGroup);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(535, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(913, 848);
            this.panel2.TabIndex = 1;
            // 
            // dgvGroup
            // 
            this.dgvGroup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroup.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Location = new System.Drawing.Point(14, 157);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.RowHeadersWidth = 62;
            this.dgvGroup.RowTemplate.Height = 28;
            this.dgvGroup.Size = new System.Drawing.Size(883, 658);
            this.dgvGroup.TabIndex = 7;
            this.dgvGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroup_CellClick);
            // 
            // cboGroup
            // 
            this.cboGroup.FormattingEnabled = true;
            this.cboGroup.Location = new System.Drawing.Point(14, 77);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(494, 38);
            this.cboGroup.TabIndex = 6;
            this.cboGroup.SelectedIndexChanged += new System.EventHandler(this.cboGroup_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 38);
            this.label3.TabIndex = 5;
            this.label3.Text = "Danh sách nhóm";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnDeleteGroup);
            this.panel1.Controls.Add(this.btnAddGroup);
            this.panel1.Controls.Add(this.txtGroupName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 421);
            this.panel1.TabIndex = 0;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeleteGroup.Location = new System.Drawing.Point(261, 233);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(170, 62);
            this.btnDeleteGroup.TabIndex = 4;
            this.btnDeleteGroup.Text = "❌ Xóa";
            this.btnDeleteGroup.UseVisualStyleBackColor = false;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.BackColor = System.Drawing.Color.Azure;
            this.btnAddGroup.Location = new System.Drawing.Point(55, 233);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(170, 62);
            this.btnAddGroup.TabIndex = 3;
            this.btnAddGroup.Text = "➕ Thêm";
            this.btnAddGroup.UseVisualStyleBackColor = false;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtGroupName.Location = new System.Drawing.Point(12, 132);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(453, 39);
            this.txtGroupName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên nhóm mới:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm/Xóa Nhóm";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1454, 914);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Quản lý danh bạ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label17.Location = new System.Drawing.Point(9, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(391, 54);
            this.label17.TabIndex = 3;
            this.label17.Text = "QUẢN LÝ DANH BẠ";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.bntSearchContact);
            this.panel4.Controls.Add(this.txtTotalContact);
            this.panel4.Controls.Add(this.btnExportCSV);
            this.panel4.Controls.Add(this.btnImportCSV);
            this.panel4.Controls.Add(this.btnAISuggestGroup);
            this.panel4.Controls.Add(this.dgvContacts);
            this.panel4.Controls.Add(this.txtSearchContact);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Location = new System.Drawing.Point(823, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(625, 882);
            this.panel4.TabIndex = 2;
            // 
            // bntSearchContact
            // 
            this.bntSearchContact.BackColor = System.Drawing.Color.FloralWhite;
            this.bntSearchContact.Location = new System.Drawing.Point(467, 42);
            this.bntSearchContact.Name = "bntSearchContact";
            this.bntSearchContact.Size = new System.Drawing.Size(123, 45);
            this.bntSearchContact.TabIndex = 11;
            this.bntSearchContact.Text = "Tìm Kiếm";
            this.bntSearchContact.UseVisualStyleBackColor = false;
            this.bntSearchContact.Click += new System.EventHandler(this.bntSearchContact_Click);
            // 
            // txtTotalContact
            // 
            this.txtTotalContact.AutoSize = true;
            this.txtTotalContact.Location = new System.Drawing.Point(7, 804);
            this.txtTotalContact.Name = "txtTotalContact";
            this.txtTotalContact.Size = new System.Drawing.Size(191, 30);
            this.txtTotalContact.TabIndex = 10;
            this.txtTotalContact.Text = "Tổng số liên lạc: 0";
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.BackColor = System.Drawing.Color.Aquamarine;
            this.btnExportCSV.Location = new System.Drawing.Point(493, 795);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(129, 76);
            this.btnExportCSV.TabIndex = 9;
            this.btnExportCSV.Text = "💾 Xuất CSV";
            this.btnExportCSV.UseVisualStyleBackColor = false;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.btnImportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportCSV.FlatAppearance.BorderSize = 0;
            this.btnImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportCSV.ForeColor = System.Drawing.Color.White;
            this.btnImportCSV.Location = new System.Drawing.Point(252, 795);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(113, 76);
            this.btnImportCSV.TabIndex = 12;
            this.btnImportCSV.Text = "📥 Nhập CSV";
            this.btnImportCSV.UseVisualStyleBackColor = false;
            // 
            // btnAISuggestGroup
            // 
            this.btnAISuggestGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnAISuggestGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAISuggestGroup.FlatAppearance.BorderSize = 0;
            this.btnAISuggestGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAISuggestGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAISuggestGroup.ForeColor = System.Drawing.Color.White;
            this.btnAISuggestGroup.Location = new System.Drawing.Point(371, 795);
            this.btnAISuggestGroup.Name = "btnAISuggestGroup";
            this.btnAISuggestGroup.Size = new System.Drawing.Size(116, 76);
            this.btnAISuggestGroup.TabIndex = 13;
            this.btnAISuggestGroup.Text = "🤖 AI nhóm";
            this.btnAISuggestGroup.UseVisualStyleBackColor = false;
            // 
            // dgvContacts
            // 
            this.dgvContacts.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(12, 97);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowHeadersWidth = 62;
            this.dgvContacts.RowTemplate.Height = 28;
            this.dgvContacts.Size = new System.Drawing.Size(610, 692);
            this.dgvContacts.TabIndex = 8;
            this.dgvContacts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContacts_CellClick);
            // 
            // txtSearchContact
            // 
            this.txtSearchContact.ForeColor = System.Drawing.Color.Gray;
            this.txtSearchContact.Location = new System.Drawing.Point(12, 46);
            this.txtSearchContact.Name = "txtSearchContact";
            this.txtSearchContact.Size = new System.Drawing.Size(446, 37);
            this.txtSearchContact.TabIndex = 7;
            this.txtSearchContact.Text = "Tìm kiếm theo tên hoặc số điện thoại";
            this.txtSearchContact.TextChanged += new System.EventHandler(this.txtSearchContact_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(254, 38);
            this.label16.TabIndex = 6;
            this.label16.Text = "Tìm kiếm danh bạ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnRefreshContact);
            this.panel3.Controls.Add(this.btnFixContact);
            this.panel3.Controls.Add(this.btnDeleteContact);
            this.panel3.Controls.Add(this.btnAddContact);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.txtAddress);
            this.panel3.Controls.Add(this.lstSuggest);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.txtEmail);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtPhone);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cboGroup2);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cboGender);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.dtpDob);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtFname);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtLname);
            this.panel3.Controls.Add(this.btnChooseImage);
            this.panel3.Controls.Add(this.picContact);
            this.panel3.Location = new System.Drawing.Point(3, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(811, 804);
            this.panel3.TabIndex = 1;
            // 
            // btnRefreshContact
            // 
            this.btnRefreshContact.BackColor = System.Drawing.Color.PaleGreen;
            this.btnRefreshContact.Location = new System.Drawing.Point(401, 696);
            this.btnRefreshContact.Name = "btnRefreshContact";
            this.btnRefreshContact.Size = new System.Drawing.Size(170, 62);
            this.btnRefreshContact.TabIndex = 37;
            this.btnRefreshContact.Text = "↻ Làm mới";
            this.btnRefreshContact.UseVisualStyleBackColor = false;
            this.btnRefreshContact.Click += new System.EventHandler(this.btnRefreshContact_Click);
            // 
            // btnFixContact
            // 
            this.btnFixContact.BackColor = System.Drawing.Color.White;
            this.btnFixContact.Location = new System.Drawing.Point(216, 696);
            this.btnFixContact.Name = "btnFixContact";
            this.btnFixContact.Size = new System.Drawing.Size(170, 62);
            this.btnFixContact.TabIndex = 36;
            this.btnFixContact.Text = "✏️Sửa";
            this.btnFixContact.UseVisualStyleBackColor = false;
            this.btnFixContact.Click += new System.EventHandler(this.btnFixContact_Click);
            // 
            // btnDeleteContact
            // 
            this.btnDeleteContact.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeleteContact.Location = new System.Drawing.Point(600, 696);
            this.btnDeleteContact.Name = "btnDeleteContact";
            this.btnDeleteContact.Size = new System.Drawing.Size(170, 62);
            this.btnDeleteContact.TabIndex = 35;
            this.btnDeleteContact.Text = "❌ Xóa";
            this.btnDeleteContact.UseVisualStyleBackColor = false;
            // 
            // btnAddContact
            // 
            this.btnAddContact.BackColor = System.Drawing.Color.Azure;
            this.btnAddContact.Location = new System.Drawing.Point(25, 696);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(170, 62);
            this.btnAddContact.TabIndex = 34;
            this.btnAddContact.Text = "➕ Thêm";
            this.btnAddContact.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label11.Location = new System.Drawing.Point(397, 496);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 32);
            this.label11.TabIndex = 31;
            this.label11.Text = "Địa chỉ";
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAddress.Location = new System.Drawing.Point(401, 539);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(386, 41);
            this.txtAddress.TabIndex = 32;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // lstSuggest
            // 
            this.lstSuggest.BackColor = System.Drawing.Color.White;
            this.lstSuggest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSuggest.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstSuggest.ItemHeight = 32;
            this.lstSuggest.Location = new System.Drawing.Point(400, 581);
            this.lstSuggest.Name = "lstSuggest";
            this.lstSuggest.Size = new System.Drawing.Size(388, 66);
            this.lstSuggest.TabIndex = 33;
            this.lstSuggest.Visible = false;
            this.lstSuggest.Click += new System.EventHandler(this.lstSuggest_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label10.Location = new System.Drawing.Point(7, 496);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 32);
            this.label10.TabIndex = 29;
            this.label10.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEmail.Location = new System.Drawing.Point(13, 539);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(368, 44);
            this.txtEmail.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label9.Location = new System.Drawing.Point(9, 403);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 32);
            this.label9.TabIndex = 27;
            this.label9.Text = "Điện thoại";
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPhone.Location = new System.Drawing.Point(13, 454);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(365, 40);
            this.txtPhone.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label8.Location = new System.Drawing.Point(397, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 32);
            this.label8.TabIndex = 25;
            this.label8.Text = "Nhóm *";
            // 
            // cboGroup2
            // 
            this.cboGroup2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGroup2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboGroup2.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGroup2.Location = new System.Drawing.Point(401, 453);
            this.cboGroup2.Name = "cboGroup2";
            this.cboGroup2.Size = new System.Drawing.Size(386, 40);
            this.cboGroup2.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label7.Location = new System.Drawing.Point(397, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 32);
            this.label7.TabIndex = 23;
            this.label7.Text = "Giới tính *";
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cboGender.Location = new System.Drawing.Point(399, 353);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(386, 40);
            this.cboGender.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label6.Location = new System.Drawing.Point(397, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 32);
            this.label6.TabIndex = 21;
            this.label6.Text = "Ngày sinh *";
            // 
            // dtpDob
            // 
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDob.Location = new System.Drawing.Point(401, 250);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(387, 39);
            this.dtpDob.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(397, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 32);
            this.label4.TabIndex = 17;
            this.label4.Text = "Họ *";
            // 
            // txtFname
            // 
            this.txtFname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtFname.Location = new System.Drawing.Point(401, 70);
            this.txtFname.Multiline = true;
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(388, 40);
            this.txtFname.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label5.Location = new System.Drawing.Point(394, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 32);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tên *";
            // 
            // txtLname
            // 
            this.txtLname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLname.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtLname.Location = new System.Drawing.Point(401, 160);
            this.txtLname.Multiline = true;
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(387, 40);
            this.txtLname.TabIndex = 20;
            // 
            // btnChooseImage
            // 
            this.btnChooseImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnChooseImage.FlatAppearance.BorderSize = 0;
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseImage.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Bold);
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.Location = new System.Drawing.Point(96, 333);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(191, 67);
            this.btnChooseImage.TabIndex = 16;
            this.btnChooseImage.Text = "📷 Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = false;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
            // 
            // picContact
            // 
            this.picContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.picContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picContact.Location = new System.Drawing.Point(81, 18);
            this.picContact.Name = "picContact";
            this.picContact.Size = new System.Drawing.Size(230, 302);
            this.picContact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picContact.TabIndex = 15;
            this.picContact.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label12.Location = new System.Drawing.Point(-53, 416);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 32);
            this.label12.TabIndex = 34;
            this.label12.Text = "Địa chỉ";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox1.Location = new System.Drawing.Point(-47, 451);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(918, 44);
            this.textBox1.TabIndex = 35;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listBox1.ItemHeight = 32;
            this.listBox1.Location = new System.Drawing.Point(-47, 495);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(918, 66);
            this.listBox1.TabIndex = 36;
            this.listBox1.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label13.Location = new System.Drawing.Point(-53, 416);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 32);
            this.label13.TabIndex = 34;
            this.label13.Text = "Địa chỉ";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox2.Location = new System.Drawing.Point(-47, 451);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(918, 44);
            this.textBox2.TabIndex = 35;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.White;
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listBox2.ItemHeight = 32;
            this.listBox2.Location = new System.Drawing.Point(-47, 495);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(918, 66);
            this.listBox2.TabIndex = 36;
            this.listBox2.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.label14.Location = new System.Drawing.Point(343, 386);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 32);
            this.label14.TabIndex = 34;
            this.label14.Text = "Điện thoại";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(33, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(237, 38);
            this.label15.TabIndex = 5;
            this.label15.Text = "Danh sách nhóm";
            // 
            // erpContact
            // 
            this.erpContact.ContainerControl = this;
            // 
            // f_Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tcbContact);
            this.Name = "f_Contact";
            this.Size = new System.Drawing.Size(1462, 957);
            this.Load += new System.EventHandler(this.f_Contact_Load);
            this.tcbContact.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpContact)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcbContact;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.PictureBox picContact;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboGroup2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ListBox lstSuggest;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnImportCSV;
        private System.Windows.Forms.Button btnAISuggestGroup;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.TextBox txtSearchContact;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label txtTotalContact;
        private System.Windows.Forms.Button btnRefreshContact;
        private System.Windows.Forms.Button btnFixContact;
        private System.Windows.Forms.Button btnDeleteContact;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button bntSearchContact;
        private System.Windows.Forms.ErrorProvider erpContact;
    }
}