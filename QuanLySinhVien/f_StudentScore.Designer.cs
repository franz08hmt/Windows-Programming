namespace QuanLySinhVien
{
    partial class f_StudentScore
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.ptLgo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.lblFname = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.btnXemDiem = new System.Windows.Forms.Button();
            this.btnLuuWord = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAINhanXet = new System.Windows.Forms.Button();
            this.btnAIGoiY = new System.Windows.Forms.Button();
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.lblTongTC = new System.Windows.Forms.Label();
            this.lblXepLoai = new System.Windows.Forms.Label();
            this.chartScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).BeginInit();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.ptLgo);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 65);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(963, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(137, 90);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "⬅ Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(90, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(372, 45);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "BẢNG ĐIỂM SINH VIÊN";
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
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(1100, 65);
            this.pnlInput.TabIndex = 1;
            // 
            // lblMSSV
            // 
            this.lblMSSV.AutoSize = true;
            this.lblMSSV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMSSV.Location = new System.Drawing.Point(3, 26);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(71, 28);
            this.lblMSSV.TabIndex = 0;
            this.lblMSSV.Text = "MSSV:";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMSSV.Location = new System.Drawing.Point(80, 20);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(155, 34);
            this.txtMSSV.TabIndex = 1;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFname.Location = new System.Drawing.Point(238, 24);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(44, 28);
            this.lblFname.TabIndex = 2;
            this.lblFname.Text = "Họ:";
            // 
            // txtFname
            // 
            this.txtFname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFname.Location = new System.Drawing.Point(288, 18);
            this.txtFname.Name = "txtFname";
            this.txtFname.ReadOnly = true;
            this.txtFname.Size = new System.Drawing.Size(130, 34);
            this.txtFname.TabIndex = 3;
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLname.Location = new System.Drawing.Point(424, 20);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(50, 28);
            this.lblLname.TabIndex = 4;
            this.lblLname.Text = "Tên:";
            // 
            // txtLname
            // 
            this.txtLname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLname.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLname.Location = new System.Drawing.Point(480, 17);
            this.txtLname.Name = "txtLname";
            this.txtLname.ReadOnly = true;
            this.txtLname.Size = new System.Drawing.Size(130, 34);
            this.txtLname.TabIndex = 5;
            // 
            // btnXemDiem
            // 
            this.btnXemDiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnXemDiem.FlatAppearance.BorderSize = 0;
            this.btnXemDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemDiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXemDiem.ForeColor = System.Drawing.Color.White;
            this.btnXemDiem.Location = new System.Drawing.Point(625, 11);
            this.btnXemDiem.Name = "btnXemDiem";
            this.btnXemDiem.Size = new System.Drawing.Size(90, 41);
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
            this.btnLuuWord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuuWord.ForeColor = System.Drawing.Color.White;
            this.btnLuuWord.Location = new System.Drawing.Point(721, 11);
            this.btnLuuWord.Name = "btnLuuWord";
            this.btnLuuWord.Size = new System.Drawing.Size(88, 41);
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
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(815, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(69, 40);
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
            this.btnAINhanXet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAINhanXet.ForeColor = System.Drawing.Color.White;
            this.btnAINhanXet.Location = new System.Drawing.Point(890, 12);
            this.btnAINhanXet.Name = "btnAINhanXet";
            this.btnAINhanXet.Size = new System.Drawing.Size(75, 40);
            this.btnAINhanXet.TabIndex = 9;
            this.btnAINhanXet.Text = "🤖 AI Nhận xét";
            this.btnAINhanXet.UseVisualStyleBackColor = false;
            this.btnAINhanXet.Click += new System.EventHandler(this.btnAINhanXet_Click);
            // 
            // btnAIGoiY
            // 
            this.btnAIGoiY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAIGoiY.FlatAppearance.BorderSize = 0;
            this.btnAIGoiY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAIGoiY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAIGoiY.ForeColor = System.Drawing.Color.White;
            this.btnAIGoiY.Location = new System.Drawing.Point(971, 12);
            this.btnAIGoiY.Name = "btnAIGoiY";
            this.btnAIGoiY.Size = new System.Drawing.Size(120, 40);
            this.btnAIGoiY.TabIndex = 10;
            this.btnAIGoiY.Text = "📅 AI Gợi ý môn";
            this.btnAIGoiY.UseVisualStyleBackColor = false;
            this.btnAIGoiY.Click += new System.EventHandler(this.btnAIGoiY_Click);
            // 
            // dgvScore
            // 
            this.dgvScore.AllowUserToAddRows = false;
            this.dgvScore.AllowUserToDeleteRows = false;
            this.dgvScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScore.BackgroundColor = System.Drawing.Color.White;
            this.dgvScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(61)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvScore.ColumnHeadersHeight = 35;
            this.dgvScore.EnableHeadersVisualStyles = false;
            this.dgvScore.Location = new System.Drawing.Point(0, 155);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.ReadOnly = true;
            this.dgvScore.RowHeadersVisible = false;
            this.dgvScore.RowHeadersWidth = 62;
            this.dgvScore.RowTemplate.Height = 28;
            this.dgvScore.Size = new System.Drawing.Size(1100, 280);
            this.dgvScore.TabIndex = 2;
            // 
            // pnlSummary
            // 
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlSummary.Controls.Add(this.lblDiemTB);
            this.pnlSummary.Controls.Add(this.lblTongTC);
            this.pnlSummary.Controls.Add(this.lblXepLoai);
            this.pnlSummary.Location = new System.Drawing.Point(0, 435);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1100, 50);
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
            chartArea2.Name = "ChartArea1";
            this.chartScore.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartScore.Legends.Add(legend2);
            this.chartScore.Location = new System.Drawing.Point(0, 485);
            this.chartScore.Name = "chartScore";
            this.chartScore.Size = new System.Drawing.Size(1100, 230);
            this.chartScore.TabIndex = 4;
            // 
            // f_StudentScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.dgvScore);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.chartScore);
            this.Name = "f_StudentScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bảng Điểm Sinh Viên";
            this.Load += new System.EventHandler(this.f_StudentScore_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptLgo)).EndInit();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartScore)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.PictureBox ptLgo;
        private System.Windows.Forms.Label lblTitle;
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
    }
}