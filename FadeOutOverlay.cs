using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    // Overlay panel vẽ snapshot cũ với alpha giảm dần, che phía sau trong khi UC mới load
    internal sealed class FadeOutOverlay : Panel
    {
        private Bitmap _snapshot;
        private Color _bgColor;
        private float _alpha = 1.0f;

        public FadeOutOverlay(Bitmap snapshot, Color bgColor)
        {
            _snapshot = snapshot;
            _bgColor = bgColor;
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.UserPaint, true);
        }

        public float Alpha
        {
            get => _alpha;
            set { _alpha = value; Invalidate(); }
        }

        // Cập nhật màu nền khi theme thay đổi giữa lúc đang animate
        public void UpdateBgColor(Color c) => _bgColor = c;

        protected override void OnPaintBackground(PaintEventArgs pe) { }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            var r = ClientRectangle;

            // Lấp nền bằng PageBg hiện tại trước
            using (var brush = new SolidBrush(_bgColor))
                g.FillRectangle(brush, r);

            if (_snapshot == null || _alpha <= 0f) return;

            // Vẽ snapshot cũ đè lên với alpha giảm dần
            var cm = new ColorMatrix { Matrix33 = _alpha };
            var ia = new ImageAttributes();
            ia.SetColorMatrix(cm);
            g.DrawImage(_snapshot, r,
                0, 0, _snapshot.Width, _snapshot.Height,
                GraphicsUnit.Pixel, ia);
            ia.Dispose();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _snapshot?.Dispose();
            base.Dispose(disposing);
        }
    }
}
