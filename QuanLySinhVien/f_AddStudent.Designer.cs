namespace QuanLySinhVien
{
    partial class f_AddStudent
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblHethong = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lstSuggest = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.picStudent = new System.Windows.Forms.PictureBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.btnSpeech = new System.Windows.Forms.Button();
            this.btnScanCard = new System.Windows.Forms.Button();
            this.btnViewlist = new System.Windows.Forms.Button();
            this.erp2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();

            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp2)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ──
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblHethong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 90);
            this.pnlHeader.TabIndex = 0;

            this.btnBack.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(15, 50, 105);
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 85, 155);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(963, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 90);
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            this.ptLgo.Image = global::QuanLySinhVien.Properties.Resources.Logo1;
            this.ptLgo.Location = new System.Drawing.Point(0, 0);
            this.ptLgo.Name = "ptLgo";
            this.ptLgo.Size = new System.Drawing.Size(84, 90);
            this.ptLgo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptLgo.TabStop = false;

            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(90, 22);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Text = "THÊM SINH VIÊN";

            // ── pnlForm ──
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.label1);
            this.pnlForm.Controls.Add(this.txtMSSV);
            this.pnlForm.Controls.Add(this.label2);
            this.pnlForm.Controls.Add(this.txtFname);
            this.pnlForm.Controls.Add(this.label3);
            this.pnlForm.Controls.Add(this.txtLname);
            this.pnlForm.Controls.Add(this.label4);
            this.pnlForm.Controls.Add(this.dtpDob);
            this.pnlForm.Controls.Add(this.label5);
            this.pnlForm.Controls.Add(this.cboGender);
            this.pnlForm.Controls.Add(this.label6);
            this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.label7);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.label8);
            this.pnlForm.Controls.Add(this.txtAddress);
            this.pnlForm.Controls.Add(this.lstSuggest);
            this.pnlForm.Controls.Add(this.btnAdd);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Location = new System.Drawing.Point(20, 105);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20);
            this.pnlForm.Size = new System.Drawing.Size(700, 520);
            this.pnlForm.TabIndex = 1;

            // label1 – MSSV
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Text = "Mã số sinh viên (MSSV) *";

            this.txtMSSV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMSSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMSSV.Location = new System.Drawing.Point(20, 44);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(640, 28);

            // label2 – Họ
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label2.Location = new System.Drawing.Point(20, 85);
            this.label2.Name = "label2";
            this.label2.Text = "Họ *";

            this.txtFname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFname.Location = new System.Drawing.Point(20, 109);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(300, 28);

            // label3 – Tên
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label3.Location = new System.Drawing.Point(360, 85);
            this.label3.Name = "label3";
            this.label3.Text = "Tên *";

            this.txtLname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLname.Location = new System.Drawing.Point(360, 109);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(300, 28);

            // label4 – Ngày sinh
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label4.Location = new System.Drawing.Point(20, 150);
            this.label4.Name = "label4";
            this.label4.Text = "Ngày sinh *";

            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDob.Location = new System.Drawing.Point(20, 174);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(300, 28);

            // label5 – Giới tính
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label5.Location = new System.Drawing.Point(360, 150);
            this.label5.Name = "label5";
            this.label5.Text = "Giới tính *";

            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            this.cboGender.Location = new System.Drawing.Point(360, 174);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(300, 28);

            // label6 – Điện thoại
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label6.Location = new System.Drawing.Point(20, 215);
            this.label6.Name = "label6";
            this.label6.Text = "Điện thoại";

            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPhone.Location = new System.Drawing.Point(20, 239);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(300, 28);

            // label7 – Email
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label7.Location = new System.Drawing.Point(360, 215);
            this.label7.Name = "label7";
            this.label7.Text = "Email";

            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(360, 239);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 28);

            // label8 – Địa chỉ
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.label8.Location = new System.Drawing.Point(20, 280);
            this.label8.Name = "label8";
            this.label8.Text = "Địa chỉ";

            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAddress.Location = new System.Drawing.Point(20, 304);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(640, 28);
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);

            // lstSuggest
            this.lstSuggest.BackColor = System.Drawing.Color.White;
            this.lstSuggest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSuggest.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstSuggest.Location = new System.Drawing.Point(20, 334);
            this.lstSuggest.Name = "lstSuggest";
            this.lstSuggest.Size = new System.Drawing.Size(640, 80);
            this.lstSuggest.Visible = false;
            this.lstSuggest.Click += new System.EventHandler(this.lstSuggest_Click);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 61, 149);
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 440);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(300, 50);
            this.btnAdd.Text = "➕ THÊM SINH VIÊN";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnClear
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(360, 440);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(300, 50);
            this.btnClear.Text = "🗑️ XÓA TRẮNG";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ── pnlRight ──
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.picStudent);
            this.pnlRight.Controls.Add(this.btnChooseImage);
            this.pnlRight.Controls.Add(this.btnSpeech);
            this.pnlRight.Controls.Add(this.btnScanCard);
            this.pnlRight.Controls.Add(this.btnViewlist);
            this.pnlRight.Location = new System.Drawing.Point(740, 105);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRight.Size = new System.Drawing.Size(330, 520);
            this.pnlRight.TabIndex = 2;

            // picStudent
            this.picStudent.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.picStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picStudent.Location = new System.Drawing.Point(55, 20);
            this.picStudent.Name = "picStudent";
            this.picStudent.Size = new System.Drawing.Size(200, 200);
            this.picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStudent.TabStop = false;

            // btnChooseImage
            this.btnChooseImage.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnChooseImage.FlatAppearance.BorderSize = 0;
            this.btnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChooseImage.ForeColor = System.Drawing.Color.White;
            this.btnChooseImage.Location = new System.Drawing.Point(55, 235);
            this.btnChooseImage.Name = "btnChooseImage";
            this.btnChooseImage.Size = new System.Drawing.Size(200, 40);
            this.btnChooseImage.Text = "📷 Chọn ảnh";
            this.btnChooseImage.UseVisualStyleBackColor = false;
            this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);

            // btnSpeech
            this.btnSpeech.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnSpeech.FlatAppearance.BorderSize = 0;
            this.btnSpeech.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpeech.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSpeech.ForeColor = System.Drawing.Color.White;
            this.btnSpeech.Location = new System.Drawing.Point(55, 290);
            this.btnSpeech.Name = "btnSpeech";
            this.btnSpeech.Size = new System.Drawing.Size(200, 40);
            this.btnSpeech.Text = "🎤 Nhập bằng giọng nói";
            this.btnSpeech.UseVisualStyleBackColor = false;
            this.btnSpeech.Click += new System.EventHandler(this.btnSpeech_Click);

            // btnScanCard
            this.btnScanCard.BackColor = System.Drawing.Color.FromArgb(106, 90, 205);
            this.btnScanCard.FlatAppearance.BorderSize = 0;
            this.btnScanCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanCard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnScanCard.ForeColor = System.Drawing.Color.White;
            this.btnScanCard.Location = new System.Drawing.Point(55, 345);
            this.btnScanCard.Name = "btnScanCard";
            this.btnScanCard.Size = new System.Drawing.Size(200, 40);
            this.btnScanCard.Text = "🪪 Quét thẻ SV (OCR)";
            this.btnScanCard.UseVisualStyleBackColor = false;
            this.btnScanCard.Click += new System.EventHandler(this.btnScanCard_Click);

            // btnViewlist
            this.btnViewlist.BackColor = System.Drawing.Color.FromArgb(220, 80, 60);
            this.btnViewlist.FlatAppearance.BorderSize = 0;
            this.btnViewlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewlist.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewlist.ForeColor = System.Drawing.Color.White;
            this.btnViewlist.Location = new System.Drawing.Point(55, 400);
            this.btnViewlist.Name = "btnViewlist";
            this.btnViewlist.Size = new System.Drawing.Size(200, 40);
            this.btnViewlist.Text = "📋 Xem danh sách";
            this.btnViewlist.UseVisualStyleBackColor = false;
            this.btnViewlist.Click += new System.EventHandler(this.btnViewlist_Click);

            // Dummy panels
            this.panel1.Location = new System.Drawing.Point(-500, -500);
            this.panel1.Size = new System.Drawing.Size(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);

            this.panel2.Location = new System.Drawing.Point(-500, -500);
            this.panel2.Size = new System.Drawing.Size(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);

            this.panel3.Location = new System.Drawing.Point(-500, -500);
            this.panel3.Size = new System.Drawing.Size(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);

            // erp2
            this.erp2.ContainerControl = this;

            // ── f_AddStudent ──
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "f_AddStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Sinh Viên";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp2)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ListBox lstSuggest;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnSpeech;
        private System.Windows.Forms.Button btnScanCard;
        private System.Windows.Forms.Button btnViewlist;
        private System.Windows.Forms.ErrorProvider erp2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}