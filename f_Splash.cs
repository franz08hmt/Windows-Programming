using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_Splash : Form
    {
        private Timer tmrProgress = new Timer();
        private int progress = 0;

        public f_Splash()
        {
            InitializeComponent();
        }

        private void f_Splash_Load(object sender, EventArgs e)
        {
            string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Logo.png");
            if (File.Exists(logoPath))
                picLogo.Image = Image.FromFile(logoPath);

            tmrProgress.Interval = 30;
            tmrProgress.Tick += TmrProgress_Tick;
            tmrProgress.Start();
        }

        private void TmrProgress_Tick(object sender, EventArgs e)
        {
            progress += 2;
            if (progress > 100) progress = 100;

            progressBar.Value = progress;

            if (progress < 30)        lblStatus.Text = "Đang khởi tạo hệ thống...";
            else if (progress < 60)   lblStatus.Text = "Đang kết nối cơ sở dữ liệu...";
            else if (progress < 85)   lblStatus.Text = "Đang tải giao diện...";
            else                      lblStatus.Text = "Hoàn tất!";

            if (progress >= 100)
            {
                tmrProgress.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Vẽ gradient background
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(0, 61, 149),
                Color.FromArgb(0, 120, 215),
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
