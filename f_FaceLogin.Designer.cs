namespace QuanLySinhVien
{
    partial class f_FaceLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle        = new System.Windows.Forms.Label();
            this.lblStoredFace   = new System.Windows.Forms.Label();
            this.pbStored        = new System.Windows.Forms.PictureBox();
            this.lblCaptureFace  = new System.Windows.Forms.Label();
            this.pnlWebcam       = new System.Windows.Forms.Panel();
            this.pbCapture       = new System.Windows.Forms.PictureBox();
            this.lblStatus       = new System.Windows.Forms.Label();
            this.btnCapture      = new System.Windows.Forms.Button();
            this.btnSelectPhoto  = new System.Windows.Forms.Button();
            this.btnVerify       = new System.Windows.Forms.Button();
            this.btnCancel       = new System.Windows.Forms.Button();
            this.lblHint         = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbStored)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location  = new System.Drawing.Point(12, 12);
            this.lblTitle.Size      = new System.Drawing.Size(440, 32);
            this.lblTitle.Text      = "NHẬN DIỆN KHUÔN MẶT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblStoredFace
            //
            this.lblStoredFace.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStoredFace.Location = new System.Drawing.Point(25, 52);
            this.lblStoredFace.Size     = new System.Drawing.Size(180, 20);
            this.lblStoredFace.Text     = "Ảnh đã đăng ký:";
            //
            // pbStored
            //
            this.pbStored.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbStored.Location    = new System.Drawing.Point(25, 74);
            this.pbStored.Size        = new System.Drawing.Size(185, 185);
            this.pbStored.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbStored.BackColor   = System.Drawing.Color.FromArgb(240, 244, 248);
            //
            // lblCaptureFace
            //
            this.lblCaptureFace.Font     = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCaptureFace.Location = new System.Drawing.Point(252, 52);
            this.lblCaptureFace.Size     = new System.Drawing.Size(200, 20);
            this.lblCaptureFace.Text     = "Camera trực tiếp:";
            //
            // pnlWebcam  — host cho luồng hình webcam (avicap32 child window)
            //
            this.pnlWebcam.BackColor   = System.Drawing.Color.Black;
            this.pnlWebcam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlWebcam.Location    = new System.Drawing.Point(252, 74);
            this.pnlWebcam.Size        = new System.Drawing.Size(185, 185);
            //
            // pbCapture  — hiện ảnh vừa chụp / chọn, ẩn ban đầu
            //
            this.pbCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCapture.Location    = new System.Drawing.Point(252, 74);
            this.pbCapture.Size        = new System.Drawing.Size(185, 185);
            this.pbCapture.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCapture.BackColor   = System.Drawing.Color.FromArgb(240, 244, 248);
            this.pbCapture.Visible     = false;
            //
            // lblStatus
            //
            this.lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location  = new System.Drawing.Point(12, 270);
            this.lblStatus.Size      = new System.Drawing.Size(440, 40);
            this.lblStatus.Text      = "Nhấn \"📷 Chụp ảnh\" để chụp khuôn mặt từ webcam.";
            //
            // btnCapture  — chụp từ webcam
            //
            this.btnCapture.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapture.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCapture.ForeColor = System.Drawing.Color.White;
            this.btnCapture.Location  = new System.Drawing.Point(25, 320);
            this.btnCapture.Size      = new System.Drawing.Size(200, 38);
            this.btnCapture.Text      = "📷 Chụp ảnh";
            this.btnCapture.Click    += new System.EventHandler(this.btnCapture_Click);
            //
            // btnSelectPhoto  — fallback: chọn từ file
            //
            this.btnSelectPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectPhoto.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSelectPhoto.Location  = new System.Drawing.Point(238, 320);
            this.btnSelectPhoto.Size      = new System.Drawing.Size(200, 38);
            this.btnSelectPhoto.Text      = "📂 Chọn từ file";
            this.btnSelectPhoto.Click    += new System.EventHandler(this.btnSelectPhoto_Click);
            //
            // btnVerify
            //
            this.btnVerify.BackColor = System.Drawing.Color.FromArgb(0, 140, 60);
            this.btnVerify.Enabled   = false;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location  = new System.Drawing.Point(25, 368);
            this.btnVerify.Size      = new System.Drawing.Size(300, 38);
            this.btnVerify.Text      = "✔ Xác nhận đăng nhập";
            this.btnVerify.Click    += new System.EventHandler(this.btnVerify_Click);
            //
            // btnCancel
            //
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location  = new System.Drawing.Point(340, 368);
            this.btnCancel.Size      = new System.Drawing.Size(99, 38);
            this.btnCancel.Text      = "Hủy";
            this.btnCancel.Click    += new System.EventHandler(this.btnCancel_Click);
            //
            // lblHint
            //
            this.lblHint.Font      = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location  = new System.Drawing.Point(12, 416);
            this.lblHint.Size      = new System.Drawing.Size(440, 30);
            this.lblHint.Text      = "Gợi ý: Nhìn thẳng vào camera, đủ ánh sáng. Nếu không có webcam, dùng \"📂 Chọn từ file\".";
            //
            // f_FaceLogin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode  = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize     = new System.Drawing.Size(464, 460);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle, this.lblStoredFace, this.pbStored,
                this.lblCaptureFace, this.pnlWebcam, this.pbCapture,
                this.lblStatus, this.btnCapture, this.btnSelectPhoto,
                this.btnVerify, this.btnCancel, this.lblHint
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "f_FaceLogin";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text            = "Đăng nhập bằng khuôn mặt";
            this.Load           += new System.EventHandler(this.f_FaceLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbStored)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCapture)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label       lblTitle;
        private System.Windows.Forms.Label       lblStoredFace;
        private System.Windows.Forms.PictureBox  pbStored;
        private System.Windows.Forms.Label       lblCaptureFace;
        private System.Windows.Forms.Panel       pnlWebcam;
        private System.Windows.Forms.PictureBox  pbCapture;
        private System.Windows.Forms.Label       lblStatus;
        private System.Windows.Forms.Button      btnCapture;
        private System.Windows.Forms.Button      btnSelectPhoto;
        private System.Windows.Forms.Button      btnVerify;
        private System.Windows.Forms.Button      btnCancel;
        private System.Windows.Forms.Label       lblHint;
    }
}
