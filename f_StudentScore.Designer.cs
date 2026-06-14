namespace QuanLySinhVien
{
    partial class f_StudentScore : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.lblFname = new System.Windows.Forms.Label();
            this.btnAIGoiY = new System.Windows.Forms.Button();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.btnXemDiem = new System.Windows.Forms.Button();
            this.btnLuuWord = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAINhanXet = new System.Windows.Forms.Button();
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblTongTC = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.chartScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblHethong = new System.Windows.Forms.Label();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.lblMSSV);
            this.pnlInput.Controls.Add(this.txtMSSV);
            this.pnlInput.Controls.Add(this.lblFname);
            this.pnlInput.Controls.Add(this.btnAIGoiY);
            this.pnlInput.Controls.Add(this.txtFname);
            this.pnlInput.Controls.Add(this.lblLname);
            this.pnlInput.Controls.Add(this.txtLname);
            this.pnlInput.Controls.Add(this.btnXemDiem);
            this.pnlInput.Controls.Add(this.btnLuuWord);
            this.pnlInput.Controls.Add(this.btnPrint);
            this.pnlInput.Controls.Add(this.btnAINhanXet);
            this.pnlInput.Location = new System.Drawing.Point(0, 91);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1459, 99);
            this.pnlInput.TabIndex = 1;
            this.pnlInput.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlInput_Paint);
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMSSV.Location = new System.Drawing.Point(17, 9);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(79, 30);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV:";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMSSV.Location = new System.Drawing.Point(102, 9);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(155, 37);
            this.txtMSSV.TabIndex = 1;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFname.Location = new System.Drawing.Point(47, 57);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(49, 30);
            this.lblFname.TabIndex = 2;
            this.lblFname.Text = "Họ:";
            // 
            // btnAIGoiY
            // 
            this.btnAIGoiY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAIGoiY.FlatAppearance.BorderSize = 0;
            this.btnAIGoiY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIGoiY.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAIGoiY.ForeColor = System.Drawing.Color.White;
            this.btnAIGoiY.Location = new System.Drawing.Point(1267, 28);
            this.btnAIGoiY.Name = "btnAIGoiY";
            this.btnAIGoiY.Size = new System.Drawing.Size(161, 46);
            this.btnAIGoiY.TabIndex = 10;
            this.btnAIGoiY.Text = "📅 AI Gợi ý môn";
            this.btnAIGoiY.UseVisualStyleBackColor = false;
            this.btnAIGoiY.Click += new System.EventHandler(this.btnAIGoiY_Click);
            // 
            // txtFname
            // 
            this.txtFname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtFname.Location = new System.Drawing.Point(102, 54);
            this.txtFname.Name = "txtFname";
            this.txtFname.ReadOnly = true;
            this.txtFname.Size = new System.Drawing.Size(155, 37);
            this.txtFname.TabIndex = 3;
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLname.Location = new System.Drawing.Point(281, 50);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(55, 30);
            this.lblLname.TabIndex = 4;
            this.lblLname.Text = "Tên:";
            // 
            // txtLname
            // 
            this.txtLname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLname.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLname.Location = new System.Drawing.Point(342, 50);
            this.txtLname.Name = "txtLname";
            this.txtLname.ReadOnly = true;
            this.txtLname.Size = new System.Drawing.Size(130, 37);
            this.txtLname.TabIndex = 5;
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnXemDiem.FlatAppearance.BorderSize = 0;
            this.btnXemDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemDiem.ForeColor = System.Drawing.Color.White;
            this.btnXemDiem.Location = new System.Drawing.Point(496, 28);
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.Size = new System.Drawing.Size(154, 46);
            this.btnXemDiem.TabIndex = 6;
            this.btnXemDiem.Text = "🔍 Xem điểm";
            this.btnXemDiem.UseVisualStyleBackColor = false;
            this.btnXemDiem.Click += new System.EventHandler(this.btnXemDiem_Click);
            // 
            // btnLuuWord
            // 
            this.btnLuuWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnLuuWord.FlatAppearance.BorderSize = 0;
            this.btnLuuWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuWord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuWord.ForeColor = System.Drawing.Color.White;
            this.btnLuuWord.Location = new System.Drawing.Point(683, 28);
            this.btnLuuWord.Name = "btnLuuWord";
            this.btnLuuWord.Size = new System.Drawing.Size(163, 46);
            this.btnLuuWord.TabIndex = 7;
            this.btnLuuWord.Text = "💾 Lưu Word";
            this.btnLuuWord.UseVisualStyleBackColor = false;
            this.btnLuuWord.Click += new System.EventHandler(this.btnLuuWord_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(882, 28);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(147, 46);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "🖨️ In";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAINhanXet
            // 
            this.btnAINhanXet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(90)))), ((int)(((byte)(205)))));
            this.btnAINhanXet.FlatAppearance.BorderSize = 0;
            this.btnAINhanXet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAINhanXet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAINhanXet.ForeColor = System.Drawing.Color.White;
            this.btnAINhanXet.Location = new System.Drawing.Point(1064, 28);
            this.btnAINhanXet.Name = "btnAINhanXet";
            this.btnAINhanXet.Size = new System.Drawing.Size(175, 46);
            this.btnAINhanXet.TabIndex = 9;
            this.btnAINhanXet.Text = "🤖 AI Nhận xét";
            this.btnAINhanXet.UseVisualStyleBackColor = false;
            this.btnAINhanXet.Click += new System.EventHandler(this.btnAINhanXet_Click);
            // 
            // dgvScore
            // 
            this.dgvScore.AllowUserToAddRows = false;
            this.dgvScore.AllowUserToDeleteRows = false;
            this.dgvScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScore.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvScore.ColumnHeadersHeight = 35;
            this.dgvScore.EnableHeadersVisualStyles = false;
            this.dgvScore.Location = new System.Drawing.Point(0, 196);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.ReadOnly = true;
            this.dgvScore.RowHeadersVisible = false;
            this.dgvScore.RowHeadersWidth = 62;
            this.dgvScore.RowTemplate.Height = 28;
            this.dgvScore.Size = new System.Drawing.Size(1462, 212);
            this.dgvScore.TabIndex = 2;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlSummary.Controls.Add(this.lblDiemTB);
            this.pnlSummary.Controls.Add(this.lblTongTC);
            this.pnlSummary.Controls.Add(this.lblXepLoai);
            this.pnlSummary.Location = new System.Drawing.Point(0, 414);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1462, 57);
            this.pnlSummary.TabIndex = 3;
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDiemTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblDiemTB.Location = new System.Drawing.Point(20, 13);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(215, 30);
            this.lblDiemTB.TabIndex = 0;
            this.lblDiemTB.Text = "Điểm Trung Bình: --";
            // 
            // lblTongTC
            // 
            this.lblTongTC.AutoSize = true;
            this.lblTongTC.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongTC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblTongTC.Location = new System.Drawing.Point(340, 13);
            this.lblTongTC.Name = "lblTongTC";
            this.lblTongTC.Size = new System.Drawing.Size(204, 30);
            this.lblTongTC.TabIndex = 1;
            this.lblTongTC.Text = "Tổng Số Tín Chỉ: --";
            // 
            // lblXepLoai
            // 
            this.lblXepLoai.AutoSize = true;
            this.lblXepLoai.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblXepLoai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblXepLoai.Location = new System.Drawing.Point(650, 13);
            this.lblXepLoai.Name = "lblXepLoai";
            this.lblXepLoai.Size = new System.Drawing.Size(131, 30);
            this.lblXepLoai.TabIndex = 2;
            this.lblXepLoai.Text = "Xếp Loại: --";
            // 
            // chartScore
            // 
            chartArea6.Name = "ChartArea1";
            this.chartScore.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartScore.Legends.Add(legend6);
            this.chartScore.Location = new System.Drawing.Point(0, 477);
            this.chartScore.Name = "chartScore";
            this.chartScore.Size = new System.Drawing.Size(1462, 480);
            this.chartScore.TabIndex = 4;
            // 
            // lblHethong
            // 
            this.lblHethong.AutoSize = true;
            this.lblHethong.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHethong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.lblHethong.Location = new System.Drawing.Point(9, 19);
            this.lblHethong.Name = "lblHethong";
            this.lblHethong.Size = new System.Drawing.Size(463, 54);
            this.lblHethong.TabIndex = 5;
            this.lblHethong.Text = "BẢNG ĐIỂM SINH VIÊN";
            // 
            // f_StudentScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.lblHethong);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.dgvScore);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.chartScore);
            this.Name = "f_StudentScore";
            this.Size = new System.Drawing.Size(1462, 957);
            this.Load += new System.EventHandler(this.f_StudentScore_Load);
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label lblFname;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Button btnXemDiem;
        private System.Windows.Forms.Button btnLuuWord;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAINhanXet;
        private System.Windows.Forms.Button btnAIGoiY;
        private System.Windows.Forms.DataGridView dgvScore;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Label lblTongTC;
        private System.Windows.Forms.Label lblXepLoai;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartScore;
        private System.Windows.Forms.Label lblHethong;
    }
}