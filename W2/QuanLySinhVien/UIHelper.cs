using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public static class UIHelper
    {
        // Màu chủ đạo HCMUTE
        public static Color PrimaryBlue = Color.FromArgb(0, 48, 135);
        public static Color LightBlue = Color.FromArgb(235, 240, 250);
        public static Color BgGray = Color.FromArgb(240, 242, 245);
        public static Color DarkBlue = Color.FromArgb(20, 60, 120);

        // ===== APPLY FORM BASE =====
        public static void ApplyFormStyle(Form form, string title, int width, int height)
        {
            form.BackColor = BgGray;
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.MaximizeBox = true;
            form.MinimumSize = new Size(width, height);
            form.Size = new Size(width, height);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Text = title + " - HCMUTE";
            // Xóa Region khi resize để không bị kẹt
            form.Resize += (s, e) => form.Region = null;
        }

        // ===== CARD PANEL =====
        public static Panel CreateCard(int x, int y, int width, int height)
        {
            Panel card = new Panel();
            card.Size = new Size(width, height);
            card.Location = new Point(x, y);
            card.BackColor = Color.White;
            RoundControl(card, 10);
            return card;
        }

        // ===== LABEL TIÊU ĐỀ =====
        public static Label CreateTitle(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Arial", 16, FontStyle.Bold);
            lbl.ForeColor = PrimaryBlue;
            lbl.AutoSize = false;
            lbl.Size = new Size(400, 40);
            lbl.Location = new Point(x, y);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            return lbl;
        }

        // ===== LABEL NHỎ =====
        public static Label CreateLabel(string text, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Arial", 8);
            lbl.ForeColor = PrimaryBlue;
            lbl.AutoSize = true;
            lbl.Location = new Point(x, y);
            return lbl;
        }

        // ===== TEXTBOX =====
        public static TextBox CreateTextBox(int x, int y, int width, bool isPassword = false)
        {
            TextBox txt = new TextBox();
            txt.Font = new Font("Arial", 10);
            txt.Size = new Size(width, 30);
            txt.Location = new Point(x, y);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = LightBlue;
            if (isPassword) txt.PasswordChar = '*';
            return txt;
        }

        // ===== BUTTON PRIMARY =====
        public static Button CreatePrimaryButton(string text, int x, int y, int width, int height = 40)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Arial", 10, FontStyle.Bold);
            btn.Size = new Size(width, height);
            btn.Location = new Point(x, y);
            btn.BackColor = PrimaryBlue;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            RoundControl(btn, 6);
            return btn;
        }

        // ===== BUTTON SECONDARY =====
        public static Button CreateSecondaryButton(string text, int x, int y, int width, int height = 40)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Font = new Font("Arial", 10);
            btn.Size = new Size(width, height);
            btn.Location = new Point(x, y);
            btn.BackColor = Color.White;
            btn.ForeColor = PrimaryBlue;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = PrimaryBlue;
            btn.FlatAppearance.BorderSize = 1;
            btn.Cursor = Cursors.Hand;
            RoundControl(btn, 6);
            return btn;
        }

        // ===== ROUND CONTROL =====
        public static void RoundControl(Control ctrl, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(ctrl.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(ctrl.Width - radius * 2, ctrl.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, ctrl.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);
        }

        // ===== LOAD LOGO =====
        public static Image LoadLogo()
        {
            try
            {
                var stream = Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("QuanLySinhVien.logo_hcmute.png");
                if (stream != null) return Image.FromStream(stream);
            }
            catch { }
            return null;
        }

        // ===== HEADER NHỎ CHO FORM CON =====
        public static Panel CreateSmallHeader(Form form, string title)
        {
            Panel header = new Panel();
            header.Size = new Size(form.Width, 55);
            header.Location = new Point(0, 0);
            header.BackColor = PrimaryBlue;

            PictureBox logo = new PictureBox();
            logo.Size = new Size(40, 40);
            logo.Location = new Point(8, 8);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.BackColor = Color.Transparent;
            logo.Image = LoadLogo();
            header.Controls.Add(logo);

            Label lbl = new Label();
            lbl.Text = title;
            lbl.Font = new Font("Arial", 12, FontStyle.Bold);
            lbl.ForeColor = Color.White;
            lbl.AutoSize = false;
            lbl.Size = new Size(500, 40);
            lbl.Location = new Point(55, 8);
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            header.Controls.Add(lbl);

            return header;
        }
    }
}