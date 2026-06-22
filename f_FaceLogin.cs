using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class f_FaceLogin : Form
    {
        // ── avicap32 P/Invoke (Windows built-in, no extra NuGet) ─────────
        [DllImport("avicap32.dll", CharSet = CharSet.Ansi)]
        private static extern IntPtr capCreateCaptureWindowA(
            string lpszWindowName, int dwStyle,
            int x, int y, int nWidth, int nHeight,
            IntPtr hWndParent, int nID);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool DestroyWindow(IntPtr hWnd);

        private const int WM_CAP_START             = 0x0400;
        private const int WM_CAP_DRIVER_CONNECT    = WM_CAP_START + 10;
        private const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
        private const int WM_CAP_EDIT_COPY         = WM_CAP_START + 30;
        private const int WM_CAP_SET_PREVIEW       = WM_CAP_START + 50;
        private const int WM_CAP_SET_PREVIEWRATE   = WM_CAP_START + 52;
        private const int WM_CAP_GRAB_FRAME        = WM_CAP_START + 60;
        // ─────────────────────────────────────────────────────────────────

        private readonly string _username;
        private readonly int    _position;
        private byte[]  _storedFaceBytes;
        private byte[]  _capturedFaceBytes;
        private IntPtr  _capHwnd      = IntPtr.Zero;
        private bool    _webcamActive;

        // true = chưa đăng ký khuôn mặt → btnVerify hoạt động như nút đăng ký
        // false = đã đăng ký → btnVerify hoạt động như nút xác thực đăng nhập
        private bool _isRegisterMode;

        public f_FaceLogin(string username, int position)
        {
            InitializeComponent();
            _username = username;
            _position = position;
        }

        private void f_FaceLogin_Load(object sender, EventArgs e)
        {
            _storedFaceBytes = LoadStoredFace();

            if (_storedFaceBytes == null || _storedFaceBytes.Length == 0)
            {
                // ── Chế độ đăng ký khuôn mặt ──────────────────────────────
                _isRegisterMode     = true;
                lblStatus.Text      = "Chưa có khuôn mặt đăng ký.\nChụp ảnh của bạn rồi nhấn \"📷 Đăng ký\" để lưu.";
                lblStatus.ForeColor = Color.DarkOrange;
                btnVerify.Text      = "📷 Đăng ký khuôn mặt";
                SetVerifyEnabled(false); // bật sau khi có ảnh
            }
            else
            {
                // ── Chế độ xác thực ───────────────────────────────────────
                _isRegisterMode = false;
                try
                {
                    using (var ms = new MemoryStream(_storedFaceBytes))
                        pbStored.Image = Image.FromStream(ms);
                }
                catch { pbStored.Image = null; }

                lblStatus.Text      = "Nhấn \"📷 Chụp ảnh\" để chụp khuôn mặt từ webcam.";
                lblStatus.ForeColor = Color.DimGray;
                btnVerify.Text      = "✔ Xác nhận đăng nhập";
                SetVerifyEnabled(false); // bật sau khi có ảnh chụp
            }

            // Thử khởi động webcam
            _webcamActive = StartWebcam();
            if (!_webcamActive)
            {
                lblCaptureFace.Text  = "Ảnh xác thực của bạn:";
                btnCapture.Enabled   = false;
                btnCapture.BackColor = Color.Gray;
                btnCapture.Text      = "Không có webcam";

                var lbl = new Label
                {
                    Text      = "⚠ Không tìm thấy\nwebcam",
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock      = DockStyle.Fill,
                    Font      = new Font("Segoe UI", 9F)
                };
                pnlWebcam.Controls.Add(lbl);
            }
        }

        // ── Helper: đổi màu nút theo trạng thái để tránh nhầm lẫn ────────

        private void SetVerifyEnabled(bool enabled)
        {
            btnVerify.Enabled = enabled;
            if (!enabled)
            {
                btnVerify.BackColor = Color.FromArgb(160, 160, 160); // xám khi disable
            }
            else
            {
                btnVerify.BackColor = _isRegisterMode
                    ? Color.FromArgb(100, 70, 180)  // tím cho "Đăng ký"
                    : Color.FromArgb(0, 140, 60);   // xanh lá cho "Xác nhận"
            }
        }

        // ── Webcam ──────────────────────────────────────────────────────

        private bool StartWebcam()
        {
            try
            {
                _capHwnd = capCreateCaptureWindowA(
                    "WebcamFeed",
                    0x50000000 | 0x40000000, // WS_VISIBLE | WS_CHILD
                    0, 0,
                    pnlWebcam.Width, pnlWebcam.Height,
                    pnlWebcam.Handle, 0);

                if (_capHwnd == IntPtr.Zero) return false;

                bool ok = SendMessage(_capHwnd, WM_CAP_DRIVER_CONNECT, 0, 0) != 0;
                if (!ok)
                {
                    DestroyWindow(_capHwnd);
                    _capHwnd = IntPtr.Zero;
                    return false;
                }

                SendMessage(_capHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0); // ~15 fps
                SendMessage(_capHwnd, WM_CAP_SET_PREVIEW, 1, 0);
                return true;
            }
            catch { return false; }
        }

        private void StopWebcam()
        {
            if (_capHwnd != IntPtr.Zero)
            {
                SendMessage(_capHwnd, WM_CAP_DRIVER_DISCONNECT, 0, 0);
                DestroyWindow(_capHwnd);
                _capHwnd = IntPtr.Zero;
            }
        }

        private byte[] CaptureFrame()
        {
            try
            {
                SendMessage(_capHwnd, WM_CAP_GRAB_FRAME, 0, 0);
                System.Threading.Thread.Sleep(150);
                SendMessage(_capHwnd, WM_CAP_EDIT_COPY, 0, 0);

                IDataObject data = Clipboard.GetDataObject();
                if (data != null && data.GetDataPresent(DataFormats.Bitmap))
                {
                    using (var bmp = (Bitmap)data.GetData(DataFormats.Bitmap))
                    using (var ms  = new MemoryStream())
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        return ms.ToArray();
                    }
                }
            }
            catch { }
            return null;
        }

        // ── Handlers ────────────────────────────────────────────────────

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (_capHwnd == IntPtr.Zero)
            {
                lblStatus.Text      = "Webcam không khả dụng. Dùng \"📂 Chọn từ file\" thay thế.";
                lblStatus.ForeColor = Color.OrangeRed;
                return;
            }

            byte[] captured = CaptureFrame();
            if (captured == null || captured.Length == 0)
            {
                lblStatus.Text      = "Không thể chụp ảnh từ webcam. Thử lại hoặc dùng \"📂 Từ file\".";
                lblStatus.ForeColor = Color.OrangeRed;
                return;
            }

            ShowCapturedImage(captured);
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title  = "Chọn ảnh khuôn mặt để xác thực";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    ShowCapturedImage(File.ReadAllBytes(ofd.FileName));
                    lblCaptureFace.Text = "Ảnh đã chọn:";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể đọc ảnh: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Dùng chung cho cả "chụp webcam" và "chọn file"
        private void ShowCapturedImage(byte[] imageBytes)
        {
            _capturedFaceBytes = imageBytes;

            try
            {
                using (var ms = new MemoryStream(_capturedFaceBytes))
                    pbCapture.Image = Image.FromStream(ms);
            }
            catch { }

            pnlWebcam.Visible   = false;
            pbCapture.Visible   = true;
            pbCapture.BringToFront();
            btnCapture.Text     = "📷 Chụp lại";
            lblCaptureFace.Text = "Ảnh vừa chụp:";

            // Bật nút hành động chính và cập nhật label hướng dẫn
            SetVerifyEnabled(true);

            if (_isRegisterMode)
            {
                lblStatus.Text      = "Đã chụp ảnh. Nhấn \"📷 Đăng ký khuôn mặt\" để lưu khuôn mặt của bạn.";
                lblStatus.ForeColor = Color.DimGray;
            }
            else
            {
                lblStatus.Text      = "Đã chụp! Nhấn \"✔ Xác nhận đăng nhập\" để đối chiếu.";
                lblStatus.ForeColor = Color.DimGray;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (_capturedFaceBytes == null)
            {
                MessageBox.Show("Vui lòng chụp ảnh khuôn mặt trước!", "Thiếu ảnh",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isRegisterMode)
            {
                RegisterFaceFromCapture();
            }
            else
            {
                VerifyFace();
            }
        }

        // ── Đăng ký khuôn mặt (chế độ chưa có ảnh) ─────────────────────

        private void RegisterFaceFromCapture()
        {
            string msgv = GetMsgvByUsername();
            if (string.IsNullOrEmpty(msgv))
            {
                MessageBox.Show("Không tìm thấy tài khoản trong hệ thống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new My_DB())
                {
                    db.openConnection();
                    var cmd = new SqlCommand("UPDATE Login SET FacePhoto=@img WHERE MSGV=@id", db.conn);
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary, -1).Value = _capturedFaceBytes;
                    cmd.Parameters.AddWithValue("@id", msgv);
                    cmd.ExecuteNonQuery();
                }

                // Reload stored face
                _storedFaceBytes = LoadStoredFace();
                if (_storedFaceBytes != null && _storedFaceBytes.Length > 0)
                {
                    try
                    {
                        using (var ms = new MemoryStream(_storedFaceBytes))
                            pbStored.Image = Image.FromStream(ms);
                    }
                    catch { }
                }

                // Chuyển sang chế độ xác thực
                _isRegisterMode     = false;
                btnVerify.Text      = "✔ Xác nhận đăng nhập";
                _capturedFaceBytes  = null;
                pbCapture.Visible   = false;
                pnlWebcam.Visible   = true;
                btnCapture.Text     = "📷 Chụp ảnh";
                lblCaptureFace.Text = _webcamActive ? "Camera trực tiếp:" : "Ảnh xác thực của bạn:";
                SetVerifyEnabled(false);

                lblStatus.Text      = "✅ Đăng ký khuôn mặt thành công!\nGiờ hãy chụp ảnh để đăng nhập.";
                lblStatus.ForeColor = Color.Green;

                MessageBox.Show("Đăng ký khuôn mặt thành công!\nBây giờ hãy chụp ảnh của bạn để đăng nhập.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetMsgvByUsername()
        {
            try
            {
                using (var db = new My_DB())
                {
                    db.openConnection();
                    var cmd = new SqlCommand(
                        "SELECT MSGV FROM Login " +
                        "WHERE Username=@u COLLATE SQL_Latin1_General_CP1_CS_AS AND position=@p AND VALID=1",
                        db.conn);
                    cmd.Parameters.AddWithValue("@u", _username);
                    cmd.Parameters.AddWithValue("@p", _position);
                    var val = cmd.ExecuteScalar();
                    return val?.ToString();
                }
            }
            catch { return null; }
        }

        // ── Xác thực khuôn mặt (chế độ đã có ảnh) ───────────────────────

        private void VerifyFace()
        {
            double similarity = CompareFaceImages(_storedFaceBytes, _capturedFaceBytes);

            if (similarity >= 0.6)
            {
                StopWebcam();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = $"Khuôn mặt không khớp (Tương đồng: {similarity:P0}). " +
                                 "Thử chụp lại với đủ ánh sáng, nhìn thẳng vào camera.";

                // Reset về webcam để thử lại
                _capturedFaceBytes  = null;
                pbCapture.Visible   = false;
                pnlWebcam.Visible   = true;
                btnCapture.Text     = "📷 Chụp ảnh";
                lblCaptureFace.Text = _webcamActive ? "Camera trực tiếp:" : "Ảnh xác thực của bạn:";
                SetVerifyEnabled(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            StopWebcam();
            this.DialogResult = DialogResult.Cancel;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopWebcam();
            base.OnFormClosing(e);
        }

        // ── DB ─────────────────────────────────────────────────────────

        private byte[] LoadStoredFace()
        {
            try
            {
                using (var db = new My_DB())
                {
                    db.openConnection();
                    var cmd = new SqlCommand(
                        "SELECT FacePhoto FROM Login " +
                        "WHERE Username=@u COLLATE SQL_Latin1_General_CP1_CS_AS AND position=@p AND VALID=1",
                        db.conn);
                    cmd.Parameters.AddWithValue("@u", _username);
                    cmd.Parameters.AddWithValue("@p", _position);
                    var val = cmd.ExecuteScalar();
                    return (val == null || val == DBNull.Value) ? null : (byte[])val;
                }
            }
            catch { return null; }
        }

        // ── So sánh khuôn mặt: Histogram RGB + Structural Similarity ──

        private double CompareFaceImages(byte[] stored, byte[] captured)
        {
            try
            {
                using (var ms1 = new MemoryStream(stored))
                using (var ms2 = new MemoryStream(captured))
                using (var bmp1 = new Bitmap(ms1))
                using (var bmp2 = new Bitmap(ms2))
                using (var r1   = new Bitmap(bmp1, 64, 64))
                using (var r2   = new Bitmap(bmp2, 64, 64))
                {
                    // 1. Histogram so sánh (R, G, B riêng biệt)
                    double histSimilarity = CompareHistograms(r1, r2);

                    // 2. Structural Similarity (so sánh chi tiết pixel)
                    double structSimilarity = ComputeStructuralSimilarity(r1, r2);

                    // 3. Kết hợp: 70% histogram + 30% structural (weighted average)
                    double combined = (histSimilarity * 0.70) + (structSimilarity * 0.30);

                    return combined;
                }
            }
            catch { return 0; }
        }

        // ── So sánh Histogram (R, G, B riêng) ──
        private double CompareHistograms(Bitmap bmp1, Bitmap bmp2)
        {
            int[] histR1 = new int[256], histG1 = new int[256], histB1 = new int[256];
            int[] histR2 = new int[256], histG2 = new int[256], histB2 = new int[256];

            for (int y = 0; y < bmp1.Height; y++)
                for (int x = 0; x < bmp1.Width; x++)
                {
                    Color c1 = bmp1.GetPixel(x, y);
                    Color c2 = bmp2.GetPixel(x, y);
                    histR1[c1.R]++; histG1[c1.G]++; histB1[c1.B]++;
                    histR2[c2.R]++; histG2[c2.G]++; histB2[c2.B]++;
                }

            double sumR = 0, sumG = 0, sumB = 0;
            const int PIXELS = 64 * 64;
            
            for (int i = 0; i < 256; i++)
            {
                sumR += Math.Sqrt((double)histR1[i] / PIXELS * histR2[i] / PIXELS);
                sumG += Math.Sqrt((double)histG1[i] / PIXELS * histG2[i] / PIXELS);
                sumB += Math.Sqrt((double)histB1[i] / PIXELS * histB2[i] / PIXELS);
            }

            // Trung bình 3 channel
            return (sumR + sumG + sumB) / 3.0;
        }

        // ── Structural Similarity (so sánh chi tiết pixel) ──
        private double ComputeStructuralSimilarity(Bitmap bmp1, Bitmap bmp2)
        {
            const int BLOCK_SIZE = 8;
            const int BLOCKS_H = 64 / BLOCK_SIZE;
            const int BLOCKS_W = 64 / BLOCK_SIZE;

            double totalSimilarity = 0;
            int blockCount = 0;

            // Chia ảnh thành các block 8x8
            for (int by = 0; by < BLOCKS_H; by++)
            {
                for (int bx = 0; bx < BLOCKS_W; bx++)
                {
                    double blockSim = CompareBlock(bmp1, bmp2, bx * BLOCK_SIZE, by * BLOCK_SIZE, BLOCK_SIZE);
                    totalSimilarity += blockSim;
                    blockCount++;
                }
            }

            return blockCount > 0 ? totalSimilarity / blockCount : 0;
        }

        // ── So sánh từng block ──
        private double CompareBlock(Bitmap bmp1, Bitmap bmp2, int startX, int startY, int blockSize)
        {
            double mean1 = 0, mean2 = 0;
            double[] pixels1 = new double[blockSize * blockSize];
            double[] pixels2 = new double[blockSize * blockSize];

            // Lấy giá trị intensity (luminance) từng pixel
            int idx = 0;
            for (int y = startY; y < startY + blockSize; y++)
            {
                for (int x = startX; x < startX + blockSize; x++)
                {
                    Color c1 = bmp1.GetPixel(x, y);
                    Color c2 = bmp2.GetPixel(x, y);
                    pixels1[idx] = 0.299 * c1.R + 0.587 * c1.G + 0.114 * c1.B;
                    pixels2[idx] = 0.299 * c2.R + 0.587 * c2.G + 0.114 * c2.B;
                    mean1 += pixels1[idx];
                    mean2 += pixels2[idx];
                    idx++;
                }
            }

            mean1 /= pixels1.Length;
            mean2 /= pixels2.Length;

            // Tính variance
            double var1 = 0, var2 = 0, covar = 0;
            for (int i = 0; i < pixels1.Length; i++)
            {
                var1 += (pixels1[i] - mean1) * (pixels1[i] - mean1);
                var2 += (pixels2[i] - mean2) * (pixels2[i] - mean2);
                covar += (pixels1[i] - mean1) * (pixels2[i] - mean2);
            }

            var1 /= pixels1.Length;
            var2 /= pixels2.Length;
            covar /= pixels1.Length;

            // SSIM formula
            const double C1 = 6.5025;
            const double C2 = 58.5225;
            double ssim = ((2 * mean1 * mean2 + C1) * (2 * covar + C2)) /
                          ((mean1 * mean1 + mean2 * mean2 + C1) * (var1 + var2 + C2));

            return Math.Max(0, Math.Min(1, ssim)); // Clamp to [0, 1]
        }
    }
}
