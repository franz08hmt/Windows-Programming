namespace QuanLySinhVien
{
    partial class f_RegisterCourse
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
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblHethong = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.lblBandau = new System.Windows.Forms.Label();
            this.lblKetqua = new System.Windows.Forms.Label();
            this.lstBandau = new System.Windows.Forms.ListBox();
            this.lstKetqua = new System.Windows.Forms.ListBox();
            this.btnMoveOne = new System.Windows.Forms.Button();
            this.btnMoveAll = new System.Windows.Forms.Button();
            this.btnRemoveOne = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.lblMonInfo = new System.Windows.Forms.Label();  // ← NÂNG CAO
            this.btnAISuggest = new System.Windows.Forms.Button();
            this.btnAICheckConflict = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUnregister = new System.Windows.Forms.Button();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvRegisterList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblHethong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 90);
            this.pnlHeader.TabIndex = 0;

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(863, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 90);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ptLgo
            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(84, 90);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabIndex = 1;
            this.ptLgo.TabStop = false;

            // lblHethong
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(90, 22);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(331, 45);
            this.lblHethong.TabIndex = 2;
            this.lblHethong.Text = "ĐĂNG KÝ MÔN HỌC";

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn Sinh viên :";
            this.label2.Click += new System.EventHandler(this.label2_Click);

            // cboStudent
            this.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudent.FormattingEnabled = true;
            this.cboStudent.Location = new System.Drawing.Point(172, 105);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.Size = new System.Drawing.Size(380, 28);
            this.cboStudent.TabIndex = 0;
            this.cboStudent.SelectedIndexChanged += new System.EventHandler(this.cboStudent_SelectedIndexChanged);

            // lblBandau
            this.lblBandau.AutoSize = true;
            this.lblBandau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBandau.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.lblBandau.Location = new System.Drawing.Point(15, 148);
            this.lblBandau.Name = "lblBandau";
            this.lblBandau.Size = new System.Drawing.Size(247, 28);
            this.lblBandau.TabIndex = 3;
            this.lblBandau.Text = "Môn học có thể đăng ký:";

            // lstBandau
            this.lstBandau.FormattingEnabled = true;
            this.lstBandau.ItemHeight = 20;
            this.lstBandau.Location = new System.Drawing.Point(15, 175);
            this.lstBandau.Name = "lstBandau";
            this.lstBandau.Size = new System.Drawing.Size(380, 184);
            this.lstBandau.TabIndex = 1;
            this.lstBandau.SelectedIndexChanged += new System.EventHandler(this.lstBandau_SelectedIndexChanged);

            // lblKetqua
            this.lblKetqua.AutoSize = true;
            this.lblKetqua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKetqua.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.lblKetqua.Location = new System.Drawing.Point(565, 148);
            this.lblKetqua.Name = "lblKetqua";
            this.lblKetqua.Size = new System.Drawing.Size(208, 28);
            this.lblKetqua.TabIndex = 5;
            this.lblKetqua.Text = "Môn học sẽ đăng ký:";

            // lstKetqua
            this.lstKetqua.FormattingEnabled = true;
            this.lstKetqua.ItemHeight = 20;
            this.lstKetqua.Location = new System.Drawing.Point(565, 175);
            this.lstKetqua.Name = "lstKetqua";
            this.lstKetqua.Size = new System.Drawing.Size(380, 184);
            this.lstKetqua.TabIndex = 6;
            this.lstKetqua.SelectedIndexChanged += new System.EventHandler(this.lstKetqua_SelectedIndexChanged);

            // panel1 – 4 nút chuyển
            this.panel1.BackColor = System.Drawing.Color.FromArgb(240, 244, 247);
            this.panel1.Controls.Add(this.btnMoveOne);
            this.panel1.Controls.Add(this.btnMoveAll);
            this.panel1.Controls.Add(this.btnRemoveOne);
            this.panel1.Controls.Add(this.btnRemoveAll);
            this.panel1.Location = new System.Drawing.Point(408, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 220);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);

            // btnMoveOne →
            this.btnMoveOne.BackColor = System.Drawing.Color.FromArgb(0, 64, 128);
            this.btnMoveOne.FlatAppearance.BorderSize = 0;
            this.btnMoveOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveOne.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMoveOne.ForeColor = System.Drawing.Color.White;
            this.btnMoveOne.Location = new System.Drawing.Point(22, 20);
            this.btnMoveOne.Name = "btnMoveOne";
            this.btnMoveOne.Size = new System.Drawing.Size(100, 38);
            this.btnMoveOne.TabIndex = 2;
            this.btnMoveOne.Text = "→";
            this.btnMoveOne.UseVisualStyleBackColor = false;
            this.btnMoveOne.Click += new System.EventHandler(this.btnMoveOne_Click);

            // btnMoveAll ⇒
            this.btnMoveAll.BackColor = System.Drawing.Color.FromArgb(0, 64, 128);
            this.btnMoveAll.FlatAppearance.BorderSize = 0;
            this.btnMoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoveAll.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMoveAll.ForeColor = System.Drawing.Color.White;
            this.btnMoveAll.Location = new System.Drawing.Point(22, 68);
            this.btnMoveAll.Name = "btnMoveAll";
            this.btnMoveAll.Size = new System.Drawing.Size(100, 38);
            this.btnMoveAll.TabIndex = 3;
            this.btnMoveAll.Text = "⇒";
            this.btnMoveAll.UseVisualStyleBackColor = false;
            this.btnMoveAll.Click += new System.EventHandler(this.btnMoveAll_Click);

            // btnRemoveOne ←
            this.btnRemoveOne.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRemoveOne.FlatAppearance.BorderSize = 0;
            this.btnRemoveOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveOne.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRemoveOne.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRemoveOne.Location = new System.Drawing.Point(22, 116);
            this.btnRemoveOne.Name = "btnRemoveOne";
            this.btnRemoveOne.Size = new System.Drawing.Size(100, 38);
            this.btnRemoveOne.TabIndex = 4;
            this.btnRemoveOne.Text = "←";
            this.btnRemoveOne.UseVisualStyleBackColor = false;
            this.btnRemoveOne.Click += new System.EventHandler(this.btnRemoveOne_Click);

            // btnRemoveAll ⇐
            this.btnRemoveAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRemoveAll.FlatAppearance.BorderSize = 0;
            this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAll.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRemoveAll.ForeColor = System.Drawing.Color.Firebrick;
            this.btnRemoveAll.Location = new System.Drawing.Point(22, 164);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(100, 38);
            this.btnRemoveAll.TabIndex = 5;
            this.btnRemoveAll.Text = "⇐";
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);

            // lblMonInfo ← NÂNG CAO: hiển thị thông tin môn khi chọn
            this.lblMonInfo.AutoSize = true;
            this.lblMonInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblMonInfo.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.lblMonInfo.Location = new System.Drawing.Point(15, 368);
            this.lblMonInfo.Name = "lblMonInfo";
            this.lblMonInfo.Size = new System.Drawing.Size(700, 20);
            this.lblMonInfo.TabIndex = 11;
            this.lblMonInfo.Text = "← Chọn môn để xem thông tin";

            // btnRegister
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(15, 395);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(215, 45);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "💾 LƯU ĐĂNG KÝ";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // btnUnregister
            this.btnUnregister.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnUnregister.FlatAppearance.BorderSize = 0;
            this.btnUnregister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnregister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUnregister.ForeColor = System.Drawing.Color.Firebrick;
            this.btnUnregister.Location = new System.Drawing.Point(250, 395);
            this.btnUnregister.Name = "btnUnregister";
            this.btnUnregister.Size = new System.Drawing.Size(246, 45);
            this.btnUnregister.TabIndex = 8;
            this.btnUnregister.Text = "HỦY ĐĂNG KÝ";
            this.btnUnregister.UseVisualStyleBackColor = false;
            this.btnUnregister.Click += new System.EventHandler(this.btnUnregister_Click);

            // btnSendRequest – CÂU 4
            this.btnSendRequest.BackColor = System.Drawing.Color.FromArgb(255, 140, 0);
            this.btnSendRequest.FlatAppearance.BorderSize = 0;
            this.btnSendRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendRequest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendRequest.ForeColor = System.Drawing.Color.White;
            this.btnSendRequest.Location = new System.Drawing.Point(502, 395);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(220, 45);
            this.btnSendRequest.TabIndex = 9;
            this.btnSendRequest.Text = "📨 GỬI YÊU CẦU XÁC NHẬN";
            this.btnSendRequest.UseVisualStyleBackColor = false;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);

            // btnAISuggest
            this.btnAISuggest.BackColor = System.Drawing.Color.FromArgb(106, 90, 205);
            this.btnAISuggest.FlatAppearance.BorderSize = 0;
            this.btnAISuggest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAISuggest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAISuggest.ForeColor = System.Drawing.Color.White;
            this.btnAISuggest.Location = new System.Drawing.Point(730, 395);
            this.btnAISuggest.Size = new System.Drawing.Size(215, 45);
            this.btnAISuggest.Name = "btnAISuggest";
            this.btnAISuggest.TabIndex = 13;
            this.btnAISuggest.Text = "🤖 AI Gợi ý môn học";
            this.btnAISuggest.UseVisualStyleBackColor = false;

            // btnAICheckConflict
            this.btnAICheckConflict.BackColor = System.Drawing.Color.FromArgb(220, 100, 0);
            this.btnAICheckConflict.FlatAppearance.BorderSize = 0;
            this.btnAICheckConflict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAICheckConflict.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAICheckConflict.ForeColor = System.Drawing.Color.White;
            this.btnAICheckConflict.Location = new System.Drawing.Point(730, 450);
            this.btnAICheckConflict.Size = new System.Drawing.Size(215, 45);
            this.btnAICheckConflict.Name = "btnAICheckConflict";
            this.btnAICheckConflict.TabIndex = 14;
            this.btnAICheckConflict.Text = "⚠️ AI Kiểm tra trùng lịch";
            this.btnAICheckConflict.UseVisualStyleBackColor = false;

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label4.Location = new System.Drawing.Point(15, 453);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(315, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "Danh sách môn học đã đăng ký:";

            // dgvRegisterList
            this.dgvRegisterList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegisterList.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRegisterList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRegisterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegisterList.Location = new System.Drawing.Point(15, 480);
            this.dgvRegisterList.Name = "dgvRegisterList";
            this.dgvRegisterList.RowHeadersWidth = 62;
            this.dgvRegisterList.RowTemplate.Height = 28;
            this.dgvRegisterList.Size = new System.Drawing.Size(960, 200);
            this.dgvRegisterList.TabIndex = 10;
            this.dgvRegisterList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegisterList_CellDoubleClick);

            // label3 (hidden placeholder)
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 2;
            this.label3.Visible = false;

            // f_RegisterCourse
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 247);
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStudent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBandau);
            this.Controls.Add(this.lstBandau);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblKetqua);
            this.Controls.Add(this.lstKetqua);
            this.Controls.Add(this.lblMonInfo);   // ← NÂNG CAO
            this.Controls.Add(this.btnAICheckConflict);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnUnregister);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.btnAISuggest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvRegisterList);
            this.Name = "f_RegisterCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký môn học";
            this.Load += new System.EventHandler(this.f_RegisterCourse_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegisterList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Label lblBandau;
        private System.Windows.Forms.Label lblKetqua;
        private System.Windows.Forms.ListBox lstBandau;
        private System.Windows.Forms.ListBox lstKetqua;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMoveOne;
        private System.Windows.Forms.Button btnMoveAll;
        private System.Windows.Forms.Button btnRemoveOne;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Label lblMonInfo;    // ← NÂNG CAO
        private System.Windows.Forms.Button btnAICheckConflict;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUnregister;
        private System.Windows.Forms.Button btnSendRequest;
        private System.Windows.Forms.Button btnAISuggest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvRegisterList;
    }
}