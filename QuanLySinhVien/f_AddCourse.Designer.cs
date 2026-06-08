namespace QuanLySinhVien
{
    partial class f_AddCourse
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblMaMH = new System.Windows.Forms.Label();
            this.txb_MaMH = new System.Windows.Forms.TextBox();
            this.lblTenMH = new System.Windows.Forms.Label();
            this.txb_TenMH = new System.Windows.Forms.TextBox();
            this.lblSoTC = new System.Windows.Forms.Label();
            this.txb_SoTC = new System.Windows.Forms.TextBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.Updown_Period = new System.Windows.Forms.NumericUpDown();
            this.lblHocky = new System.Windows.Forms.Label();
            this.cbb_Hocky = new System.Windows.Forms.ComboBox();
            this.lblDecription = new System.Windows.Forms.Label();
            this.rtb_Decription = new System.Windows.Forms.RichTextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Updown_Period)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(166)))));
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(434, 45);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(12, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(264, 32);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "THÊM MÔN HỌC MỚI";
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.lblMaMH);
            this.pnlContent.Controls.Add(this.txb_MaMH);
            this.pnlContent.Controls.Add(this.lblTenMH);
            this.pnlContent.Controls.Add(this.txb_TenMH);
            this.pnlContent.Controls.Add(this.lblSoTC);
            this.pnlContent.Controls.Add(this.txb_SoTC);
            this.pnlContent.Controls.Add(this.lblPeriod);
            this.pnlContent.Controls.Add(this.Updown_Period);
            this.pnlContent.Controls.Add(this.lblHocky);
            this.pnlContent.Controls.Add(this.cbb_Hocky);
            this.pnlContent.Controls.Add(this.lblDecription);
            this.pnlContent.Controls.Add(this.rtb_Decription);
            this.pnlContent.Controls.Add(this.btn_Add);
            this.pnlContent.Location = new System.Drawing.Point(16, 60);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(402, 440);
            this.pnlContent.TabIndex = 0;
            // 
            // lblMaMH
            // 
            this.lblMaMH.Location = new System.Drawing.Point(20, 23);
            this.lblMaMH.Name = "lblMaMH";
            this.lblMaMH.Size = new System.Drawing.Size(100, 23);
            this.lblMaMH.TabIndex = 0;
            this.lblMaMH.Text = "Mã môn học:";
            // 
            // txb_MaMH
            // 
            this.txb_MaMH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_MaMH.Location = new System.Drawing.Point(120, 20);
            this.txb_MaMH.Name = "txb_MaMH";
            this.txb_MaMH.Size = new System.Drawing.Size(255, 33);
            this.txb_MaMH.TabIndex = 1;
            // 
            // lblTenMH
            // 
            this.lblTenMH.Location = new System.Drawing.Point(20, 63);
            this.lblTenMH.Name = "lblTenMH";
            this.lblTenMH.Size = new System.Drawing.Size(100, 23);
            this.lblTenMH.TabIndex = 2;
            this.lblTenMH.Text = "Tên môn học:";
            // 
            // txb_TenMH
            // 
            this.txb_TenMH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_TenMH.Location = new System.Drawing.Point(120, 60);
            this.txb_TenMH.Name = "txb_TenMH";
            this.txb_TenMH.Size = new System.Drawing.Size(255, 33);
            this.txb_TenMH.TabIndex = 3;
            // 
            // lblSoTC
            // 
            this.lblSoTC.Location = new System.Drawing.Point(20, 103);
            this.lblSoTC.Name = "lblSoTC";
            this.lblSoTC.Size = new System.Drawing.Size(100, 23);
            this.lblSoTC.TabIndex = 4;
            this.lblSoTC.Text = "Số tín chỉ:";
            // 
            // txb_SoTC
            // 
            this.txb_SoTC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_SoTC.Location = new System.Drawing.Point(120, 100);
            this.txb_SoTC.Name = "txb_SoTC";
            this.txb_SoTC.Size = new System.Drawing.Size(255, 33);
            this.txb_SoTC.TabIndex = 5;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Location = new System.Drawing.Point(20, 143);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(100, 23);
            this.lblPeriod.TabIndex = 6;
            this.lblPeriod.Text = "Số tuần học:";
            // 
            // Updown_Period
            // 
            this.Updown_Period.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Updown_Period.Location = new System.Drawing.Point(120, 140);
            this.Updown_Period.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Updown_Period.Name = "Updown_Period";
            this.Updown_Period.Size = new System.Drawing.Size(255, 33);
            this.Updown_Period.TabIndex = 7;
            this.Updown_Period.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblHocky
            // 
            this.lblHocky.Location = new System.Drawing.Point(20, 183);
            this.lblHocky.Name = "lblHocky";
            this.lblHocky.Size = new System.Drawing.Size(100, 23);
            this.lblHocky.TabIndex = 8;
            this.lblHocky.Text = "Học kỳ:";
            // 
            // cbb_Hocky
            // 
            this.cbb_Hocky.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbb_Hocky.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Hocky.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbb_Hocky.Location = new System.Drawing.Point(120, 180);
            this.cbb_Hocky.Name = "cbb_Hocky";
            this.cbb_Hocky.Size = new System.Drawing.Size(255, 33);
            this.cbb_Hocky.TabIndex = 9;
            // 
            // lblDecription
            // 
            this.lblDecription.Location = new System.Drawing.Point(20, 223);
            this.lblDecription.Name = "lblDecription";
            this.lblDecription.Size = new System.Drawing.Size(100, 23);
            this.lblDecription.TabIndex = 10;
            this.lblDecription.Text = "Mô tả môn:";
            // 
            // rtb_Decription
            // 
            this.rtb_Decription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_Decription.Location = new System.Drawing.Point(120, 220);
            this.rtb_Decription.Name = "rtb_Decription";
            this.rtb_Decription.Size = new System.Drawing.Size(255, 140);
            this.rtb_Decription.TabIndex = 11;
            this.rtb_Decription.Text = "";
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(275, 381);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 35);
            this.btn_Add.TabIndex = 12;
            this.btn_Add.Text = "Thêm Mới";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // f_AddCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(434, 515);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(450, 550);
            this.Name = "f_AddCourse";
            this.Text = "Thêm Môn Học";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Updown_Period)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblMaMH;
        private System.Windows.Forms.TextBox txb_MaMH;
        private System.Windows.Forms.Label lblTenMH;
        private System.Windows.Forms.TextBox txb_TenMH;
        private System.Windows.Forms.Label lblSoTC;
        private System.Windows.Forms.TextBox txb_SoTC;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.NumericUpDown Updown_Period;
        private System.Windows.Forms.Label lblHocky;
        private System.Windows.Forms.ComboBox cbb_Hocky;
        private System.Windows.Forms.Label lblDecription;
        private System.Windows.Forms.RichTextBox rtb_Decription;
        private System.Windows.Forms.Button btn_Add;
    }
}