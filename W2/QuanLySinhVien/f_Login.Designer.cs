namespace QuanLySinhVien
{
    partial class f_Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.rdStudent = new System.Windows.Forms.RadioButton();
            this.rdHR = new System.Windows.Forms.RadioButton();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 620);
            this.Name = "f_Login";
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.RadioButton rdStudent;
        private System.Windows.Forms.RadioButton rdHR;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
    }
}