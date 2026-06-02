namespace QuanLySinhVien
{
    partial class f_ManageScore
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblHethong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStudent = new System.Windows.Forms.ComboBox();
            this.cboCourse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.txtCK = new System.Windows.Forms.TextBox();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.btnSaveScore = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvScores = new System.Windows.Forms.DataGridView();
            this.lblGPA = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFix = new System.Windows.Forms.Button();
            this.txtXepLoai = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.erpScore = new System.Windows.Forms.ErrorProvider(this.components);
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScores)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblHethong);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(978, 90);
            this.pnlHeader.TabIndex = 17;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(50)))), ((int)(((byte)(105)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(85)))), ((int)(((byte)(155)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(841, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 90);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHethong.ForeColor = System.Drawing.Color.White;
            this.lblHethong.Location = new System.Drawing.Point(81, 22);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(463, 45);
            this.lblHethong.TabIndex = 0;
            this.lblHethong.Text = "QUẢN LÝ ĐIỂM - NHẬP ĐIỂM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sinh viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 38);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nhập và cập nhật điểm";
            // 
            // cboStudent
            // 
            this.cboStudent.FormattingEnabled = true;
            this.cboStudent.Location = new System.Drawing.Point(177, 164);
            this.cboStudent.Name = "cboStudent";
            this.cboStudent.Size = new System.Drawing.Size(280, 28);
            this.cboStudent.TabIndex = 20;
            this.cboStudent.SelectedIndexChanged += new System.EventHandler(this.cboStudent_SelectedIndexChanged);
            // 
            // cboCourse
            // 
            this.cboCourse.FormattingEnabled = true;
            this.cboCourse.Location = new System.Drawing.Point(177, 217);
            this.cboCourse.Name = "cboCourse";
            this.cboCourse.Size = new System.Drawing.Size(280, 28);
            this.cboCourse.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 28);
            this.label3.TabIndex = 21;
            this.label3.Text = "Môn học";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 28);
            this.label4.TabIndex = 23;
            this.label4.Text = "Điểm quá trình";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 28);
            this.label5.TabIndex = 25;
            this.label5.Text = "Điểm cuối kỳ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 28);
            this.label6.TabIndex = 27;
            this.label6.Text = "Điểm tổng kết";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 28);
            this.label7.TabIndex = 29;
            this.label7.Text = "Ghi chú/Mô tả";
            // 
            // txtQT
            // 
            this.txtQT.Location = new System.Drawing.Point(177, 274);
            this.txtQT.Name = "txtQT";
            this.txtQT.Size = new System.Drawing.Size(280, 26);
            this.txtQT.TabIndex = 30;
            this.txtQT.TextChanged += new System.EventHandler(this.txtQT_TextChanged);
            // 
            // txtCK
            // 
            this.txtCK.Location = new System.Drawing.Point(165, 224);
            this.txtCK.Name = "txtCK";
            this.txtCK.Size = new System.Drawing.Size(280, 26);
            this.txtCK.TabIndex = 31;
            this.txtCK.TextChanged += new System.EventHandler(this.txtCK_TextChanged);
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(165, 275);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(280, 26);
            this.txtTK.TabIndex = 32;
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(165, 373);
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(280, 26);
            this.txtMota.TabIndex = 33;
            // 
            // btnSaveScore
            // 
            this.btnSaveScore.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSaveScore.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveScore.ForeColor = System.Drawing.Color.White;
            this.btnSaveScore.Location = new System.Drawing.Point(18, 413);
            this.btnSaveScore.Name = "btnSaveScore";
            this.btnSaveScore.Size = new System.Drawing.Size(132, 63);
            this.btnSaveScore.TabIndex = 34;
            this.btnSaveScore.Text = "💾 Lưu điểm";
            this.btnSaveScore.UseVisualStyleBackColor = false;
            this.btnSaveScore.Click += new System.EventHandler(this.btnSaveScore_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnRefresh.Location = new System.Drawing.Point(313, 413);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(132, 63);
            this.btnRefresh.TabIndex = 35;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(494, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(471, 38);
            this.label8.TabIndex = 36;
            this.label8.Text = "Bảng điểm chi tiết - Thống kê GPA";
            // 
            // dgvScores
            // 
            this.dgvScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScores.Location = new System.Drawing.Point(488, 164);
            this.dgvScores.Name = "dgvScores";
            this.dgvScores.RowHeadersWidth = 62;
            this.dgvScores.RowTemplate.Height = 28;
            this.dgvScores.Size = new System.Drawing.Size(478, 321);
            this.dgvScores.TabIndex = 37;
            this.dgvScores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScores_CellClick);
            // 
            // lblGPA
            // 
            this.lblGPA.AutoSize = true;
            this.lblGPA.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblGPA.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblGPA.Location = new System.Drawing.Point(3, 6);
            this.lblGPA.Name = "lblGPA";
            this.lblGPA.Size = new System.Drawing.Size(290, 38);
            this.lblGPA.TabIndex = 38;
            this.lblGPA.Text = "ĐIỂM GPA TÍCH LŨY:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnFix);
            this.panel1.Controls.Add(this.txtXepLoai);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtTK);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.txtCK);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnSaveScore);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtMota);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 486);
            this.panel1.TabIndex = 39;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnFix
            // 
            this.btnFix.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnFix.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnFix.Location = new System.Drawing.Point(165, 413);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(132, 63);
            this.btnFix.TabIndex = 36;
            this.btnFix.Text = "Sửa";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // txtXepLoai
            // 
            this.txtXepLoai.Location = new System.Drawing.Point(165, 327);
            this.txtXepLoai.Name = "txtXepLoai";
            this.txtXepLoai.Size = new System.Drawing.Size(280, 26);
            this.txtXepLoai.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 323);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 28);
            this.label9.TabIndex = 34;
            this.label9.Text = "Xếp loại";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(488, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 389);
            this.panel2.TabIndex = 40;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.lblXepLoai);
            this.panel3.Controls.Add(this.lblGPA);
            this.panel3.Location = new System.Drawing.Point(488, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 76);
            this.panel3.TabIndex = 41;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXepLoai.Location = new System.Drawing.Point(7, 46);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(73, 21);
            this.lblXepLoai.TabIndex = 39;
            this.lblXepLoai.Text = "Xếp loại:";
            // 
            // erpScore
            // 
            this.erpScore.ContainerControl = this;
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
            // f_ManageScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.dgvScores);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCourse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "f_ManageScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f_ManageScore";
            this.Load += new System.EventHandler(this.f_ManageScore_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblHethong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.ComboBox cboCourse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQT;
        private System.Windows.Forms.TextBox txtCK;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.Button btnSaveScore;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvScores;
        private System.Windows.Forms.Label lblGPA;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtXepLoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.ErrorProvider erpScore;
    }
}