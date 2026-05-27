namespace QuanLySinhVien
{
    partial class f_ManageCourse
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
            this.tabAdd = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nudAddHky = new System.Windows.Forms.NumericUpDown();
            this.txtAddMota = new System.Windows.Forms.TextBox();
            this.nudAddTuan = new System.Windows.Forms.NumericUpDown();
            this.nudAddSotc = new System.Windows.Forms.NumericUpDown();
            this.txtAddTen = new System.Windows.Forms.TextBox();
            this.txtAddMa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEdit = new System.Windows.Forms.TabPage();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtEditMota = new System.Windows.Forms.TextBox();
            this.nudEditHky = new System.Windows.Forms.NumericUpDown();
            this.nudEditTuan = new System.Windows.Forms.NumericUpDown();
            this.nudEditSotc = new System.Windows.Forms.NumericUpDown();
            this.txtEditTen = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtEditMa = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabList = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvCourse = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearchList = new System.Windows.Forms.TextBox();
            this.btnSearchList = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cboFilterSemester = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddHky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddTuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddSotc)).BeginInit();
            this.tabEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditHky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditTuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditSotc)).BeginInit();
            this.tabList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabAdd);
            this.tabControl1.Controls.Add(this.tabEdit);
            this.tabControl1.Controls.Add(this.tabList);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 594);
            this.tabControl1.TabIndex = 0;
            // 
            // tabAdd
            // 
            this.tabAdd.BackgroundImage = global::QuanLySinhVien.Properties.Resources.background;
            this.tabAdd.Controls.Add(this.btnAdd);
            this.tabAdd.Controls.Add(this.label6);
            this.tabAdd.Controls.Add(this.nudAddHky);
            this.tabAdd.Controls.Add(this.txtAddMota);
            this.tabAdd.Controls.Add(this.nudAddTuan);
            this.tabAdd.Controls.Add(this.nudAddSotc);
            this.tabAdd.Controls.Add(this.txtAddTen);
            this.tabAdd.Controls.Add(this.txtAddMa);
            this.tabAdd.Controls.Add(this.label5);
            this.tabAdd.Controls.Add(this.label4);
            this.tabAdd.Controls.Add(this.label3);
            this.tabAdd.Controls.Add(this.label2);
            this.tabAdd.Controls.Add(this.label1);
            this.tabAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabAdd.Location = new System.Drawing.Point(4, 29);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdd.Size = new System.Drawing.Size(970, 561);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Text = "Thêm môn học";
            this.tabAdd.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(428, 461);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(342, 35);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "THÊM";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(126, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mô tả";
            // 
            // nudAddHky
            // 
            this.nudAddHky.Location = new System.Drawing.Point(314, 305);
            this.nudAddHky.Name = "nudAddHky";
            this.nudAddHky.Size = new System.Drawing.Size(558, 26);
            this.nudAddHky.TabIndex = 10;
            // 
            // txtAddMota
            // 
            this.txtAddMota.Location = new System.Drawing.Point(314, 371);
            this.txtAddMota.Multiline = true;
            this.txtAddMota.Name = "txtAddMota";
            this.txtAddMota.Size = new System.Drawing.Size(558, 26);
            this.txtAddMota.TabIndex = 9;
            // 
            // nudAddTuan
            // 
            this.nudAddTuan.Location = new System.Drawing.Point(314, 236);
            this.nudAddTuan.Name = "nudAddTuan";
            this.nudAddTuan.Size = new System.Drawing.Size(558, 26);
            this.nudAddTuan.TabIndex = 8;
            // 
            // nudAddSotc
            // 
            this.nudAddSotc.Location = new System.Drawing.Point(314, 163);
            this.nudAddSotc.Name = "nudAddSotc";
            this.nudAddSotc.Size = new System.Drawing.Size(558, 26);
            this.nudAddSotc.TabIndex = 7;
            // 
            // txtAddTen
            // 
            this.txtAddTen.Location = new System.Drawing.Point(314, 98);
            this.txtAddTen.Name = "txtAddTen";
            this.txtAddTen.Size = new System.Drawing.Size(558, 26);
            this.txtAddTen.TabIndex = 6;
            // 
            // txtAddMa
            // 
            this.txtAddMa.Location = new System.Drawing.Point(314, 32);
            this.txtAddMa.Name = "txtAddMa";
            this.txtAddMa.Size = new System.Drawing.Size(558, 26);
            this.txtAddMa.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Học kỳ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(126, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số tuần";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(126, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số tín chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(126, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên môn học";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã môn học";
            // 
            // tabEdit
            // 
            this.tabEdit.BackgroundImage = global::QuanLySinhVien.Properties.Resources.background;
            this.tabEdit.Controls.Add(this.btnDel);
            this.tabEdit.Controls.Add(this.btnEdit);
            this.tabEdit.Controls.Add(this.txtEditMota);
            this.tabEdit.Controls.Add(this.nudEditHky);
            this.tabEdit.Controls.Add(this.nudEditTuan);
            this.tabEdit.Controls.Add(this.nudEditSotc);
            this.tabEdit.Controls.Add(this.txtEditTen);
            this.tabEdit.Controls.Add(this.btnSearch);
            this.tabEdit.Controls.Add(this.txtEditMa);
            this.tabEdit.Controls.Add(this.label12);
            this.tabEdit.Controls.Add(this.label11);
            this.tabEdit.Controls.Add(this.label10);
            this.tabEdit.Controls.Add(this.label9);
            this.tabEdit.Controls.Add(this.label8);
            this.tabEdit.Controls.Add(this.label7);
            this.tabEdit.Location = new System.Drawing.Point(4, 29);
            this.tabEdit.Name = "tabEdit";
            this.tabEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdit.Size = new System.Drawing.Size(970, 561);
            this.tabEdit.TabIndex = 1;
            this.tabEdit.Text = "Sửa môn học";
            this.tabEdit.UseVisualStyleBackColor = true;
            this.tabEdit.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(409, 456);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(247, 35);
            this.btnDel.TabIndex = 14;
            this.btnDel.Text = "XÓA";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(104, 456);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(254, 35);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "LƯU SỬA";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtEditMota
            // 
            this.txtEditMota.Location = new System.Drawing.Point(225, 363);
            this.txtEditMota.Name = "txtEditMota";
            this.txtEditMota.Size = new System.Drawing.Size(431, 26);
            this.txtEditMota.TabIndex = 12;
            // 
            // nudEditHky
            // 
            this.nudEditHky.Location = new System.Drawing.Point(225, 302);
            this.nudEditHky.Name = "nudEditHky";
            this.nudEditHky.Size = new System.Drawing.Size(431, 26);
            this.nudEditHky.TabIndex = 11;
            // 
            // nudEditTuan
            // 
            this.nudEditTuan.Location = new System.Drawing.Point(225, 241);
            this.nudEditTuan.Name = "nudEditTuan";
            this.nudEditTuan.Size = new System.Drawing.Size(431, 26);
            this.nudEditTuan.TabIndex = 10;
            // 
            // nudEditSotc
            // 
            this.nudEditSotc.Location = new System.Drawing.Point(225, 177);
            this.nudEditSotc.Name = "nudEditSotc";
            this.nudEditSotc.Size = new System.Drawing.Size(431, 26);
            this.nudEditSotc.TabIndex = 9;
            // 
            // txtEditTen
            // 
            this.txtEditTen.Location = new System.Drawing.Point(225, 117);
            this.txtEditTen.Name = "txtEditTen";
            this.txtEditTen.Size = new System.Drawing.Size(431, 26);
            this.txtEditTen.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(686, 51);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 27);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "TÌM";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtEditMa
            // 
            this.txtEditMa.Location = new System.Drawing.Point(225, 51);
            this.txtEditMa.Name = "txtEditMa";
            this.txtEditMa.Size = new System.Drawing.Size(431, 26);
            this.txtEditMa.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(100, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 5;
            this.label12.Text = "Mô tả";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(100, 302);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Học kỳ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(100, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Số tuần";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(100, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Số tín chỉ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(100, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tên môn học";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(100, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã môn học";
            // 
            // tabList
            // 
            this.tabList.BackgroundImage = global::QuanLySinhVien.Properties.Resources.background;
            this.tabList.Controls.Add(this.cboFilterSemester);
            this.tabList.Controls.Add(this.label14);
            this.tabList.Controls.Add(this.btnSearchList);
            this.tabList.Controls.Add(this.txtSearchList);
            this.tabList.Controls.Add(this.label13);
            this.tabList.Controls.Add(this.btnRefresh);
            this.tabList.Controls.Add(this.dgvCourse);
            this.tabList.Location = new System.Drawing.Point(4, 29);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(970, 561);
            this.tabList.TabIndex = 2;
            this.tabList.Text = "Danh sách";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(60, 35);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(157, 35);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "LÀM MỚI";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvCourse
            // 
            this.dgvCourse.BackgroundColor = System.Drawing.Color.White;
            this.dgvCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCourse.Location = new System.Drawing.Point(3, 101);
            this.dgvCourse.Name = "dgvCourse";
            this.dgvCourse.RowHeadersWidth = 62;
            this.dgvCourse.RowTemplate.Height = 28;
            this.dgvCourse.Size = new System.Drawing.Size(964, 457);
            this.dgvCourse.TabIndex = 1;
            this.dgvCourse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourse_CellContentClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(292, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Tìm kiếm :";
            // 
            // txtSearchList
            // 
            this.txtSearchList.Location = new System.Drawing.Point(402, 12);
            this.txtSearchList.Name = "txtSearchList";
            this.txtSearchList.Size = new System.Drawing.Size(289, 26);
            this.txtSearchList.TabIndex = 3;
            this.txtSearchList.TextChanged += new System.EventHandler(this.txtSearchList_TextChanged);
            // 
            // btnSearchList
            // 
            this.btnSearchList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchList.Location = new System.Drawing.Point(763, 35);
            this.btnSearchList.Name = "btnSearchList";
            this.btnSearchList.Size = new System.Drawing.Size(75, 29);
            this.btnSearchList.TabIndex = 4;
            this.btnSearchList.Text = "TÌM";
            this.btnSearchList.UseVisualStyleBackColor = true;
            this.btnSearchList.Click += new System.EventHandler(this.btnSearchList_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(292, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 20);
            this.label14.TabIndex = 5;
            this.label14.Text = "Lọc học kỳ :";
            // 
            // cboFilterSemester
            // 
            this.cboFilterSemester.FormattingEnabled = true;
            this.cboFilterSemester.Items.AddRange(new object[] {
            "Tất cả",
            "1",
            "2",
            "3"});
            this.cboFilterSemester.Location = new System.Drawing.Point(403, 54);
            this.cboFilterSemester.Name = "cboFilterSemester";
            this.cboFilterSemester.Size = new System.Drawing.Size(121, 28);
            this.cboFilterSemester.TabIndex = 6;
            this.cboFilterSemester.SelectedIndexChanged += new System.EventHandler(this.cboFilterSemester_SelectedIndexChanged);
            // 
            // f_ManageCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 594);
            this.Controls.Add(this.tabControl1);
            this.Name = "f_ManageCourse";
            this.Text = "f_ManageCourse";
            this.tabControl1.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddHky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddTuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAddSotc)).EndInit();
            this.tabEdit.ResumeLayout(false);
            this.tabEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditHky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditTuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEditSotc)).EndInit();
            this.tabList.ResumeLayout(false);
            this.tabList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAdd;
        private System.Windows.Forms.TabPage tabEdit;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddMota;
        private System.Windows.Forms.NumericUpDown nudAddTuan;
        private System.Windows.Forms.NumericUpDown nudAddSotc;
        private System.Windows.Forms.TextBox txtAddTen;
        private System.Windows.Forms.TextBox txtAddMa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudAddHky;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEditMota;
        private System.Windows.Forms.NumericUpDown nudEditHky;
        private System.Windows.Forms.NumericUpDown nudEditTuan;
        private System.Windows.Forms.NumericUpDown nudEditSotc;
        private System.Windows.Forms.TextBox txtEditTen;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtEditMa;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvCourse;
        private System.Windows.Forms.Button btnSearchList;
        private System.Windows.Forms.TextBox txtSearchList;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboFilterSemester;
        private System.Windows.Forms.Label label14;
    }
}