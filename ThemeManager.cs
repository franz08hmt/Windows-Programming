using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    internal static class ThemeManager
    {
        public static bool IsDark { get; private set; } = false;
        public static event EventHandler ThemeChanged;

        // ── Light palette ─────────────────────────────────────────────
        static readonly Color L_AppBg     = Color.FromArgb(240, 244, 248);
        static readonly Color L_CardBg    = Color.White;
        static readonly Color L_InputBg   = Color.White;
        static readonly Color L_InputFg   = Color.FromArgb(30, 30, 30);
        static readonly Color L_LabelFg   = Color.FromArgb(30, 30, 30);
        static readonly Color L_DgvBg     = Color.White;
        static readonly Color L_DgvAlt    = Color.FromArgb(240, 244, 255);
        static readonly Color L_DgvHdrBg  = Color.FromArgb(0, 61, 149);
        static readonly Color L_DgvHdrFg  = Color.White;
        static readonly Color L_DgvRowFg  = Color.Black;
        static readonly Color L_DgvGrid   = Color.FromArgb(180, 190, 210);
        static readonly Color L_Sidebar   = Color.FromArgb(21, 67, 137);
        static readonly Color L_NavBtn    = Color.FromArgb(21, 67, 137);
        static readonly Color L_ToggleBtn = Color.FromArgb(10, 50, 110);

        // ── Dark palette ──────────────────────────────────────────────
        static readonly Color D_AppBg     = Color.FromArgb(28, 32, 44);
        static readonly Color D_CardBg    = Color.FromArgb(38, 42, 58);
        static readonly Color D_InputBg   = Color.FromArgb(50, 55, 72);
        static readonly Color D_InputFg   = Color.FromArgb(210, 218, 235);
        static readonly Color D_LabelFg   = Color.FromArgb(195, 205, 225);
        static readonly Color D_DgvBg     = Color.FromArgb(33, 37, 52);
        static readonly Color D_DgvAlt    = Color.FromArgb(40, 46, 65);
        static readonly Color D_DgvHdrBg  = Color.FromArgb(20, 23, 38);
        static readonly Color D_DgvHdrFg  = Color.FromArgb(170, 185, 220);
        static readonly Color D_DgvRowFg  = Color.FromArgb(210, 218, 235);
        static readonly Color D_DgvGrid   = Color.FromArgb(55, 62, 85);
        static readonly Color D_Sidebar   = Color.FromArgb(16, 18, 30);
        static readonly Color D_NavBtn    = Color.FromArgb(20, 24, 40);
        static readonly Color D_ToggleBtn = Color.FromArgb(45, 52, 80);

        // ── Public color accessors ────────────────────────────────────
        public static Color AppBg     => IsDark ? D_AppBg     : L_AppBg;
        public static Color CardBg    => IsDark ? D_CardBg    : L_CardBg;
        public static Color InputBg   => IsDark ? D_InputBg   : L_InputBg;
        public static Color InputFg   => IsDark ? D_InputFg   : L_InputFg;
        public static Color LabelFg   => IsDark ? D_LabelFg   : L_LabelFg;
        public static Color DgvBg     => IsDark ? D_DgvBg     : L_DgvBg;
        public static Color DgvAlt    => IsDark ? D_DgvAlt    : L_DgvAlt;
        public static Color DgvHdrBg  => IsDark ? D_DgvHdrBg  : L_DgvHdrBg;
        public static Color DgvHdrFg  => IsDark ? D_DgvHdrFg  : L_DgvHdrFg;
        public static Color DgvRowFg  => IsDark ? D_DgvRowFg  : L_DgvRowFg;
        public static Color DgvGrid   => IsDark ? D_DgvGrid   : L_DgvGrid;
        public static Color SidebarBg => IsDark ? D_Sidebar   : L_Sidebar;
        public static Color NavBtnBg  => IsDark ? D_NavBtn    : L_NavBtn;
        public static Color ToggleBg  => IsDark ? D_ToggleBtn : L_ToggleBtn;

        public static void Toggle()
        {
            IsDark = !IsDark;
            ThemeChanged?.Invoke(null, EventArgs.Empty);
        }

        /// <summary>Apply current theme to <paramref name="root"/> and all descendants.</summary>
        public static void ApplyToTree(Control root)
        {
            if (root == null) return;
            root.SuspendLayout();
            ApplyRecursive(root, root.Name);
            root.ResumeLayout(true);
        }

        static void ApplyRecursive(Control c, string rootName)
        {
            ApplyOne(c, rootName);
            foreach (Control child in c.Controls)
                ApplyRecursive(child, rootName);
        }

        static void ApplyOne(Control c, string rootName)
        {
            // Never touch sidebar or header — they have their own theming
            if (c.Name == "pnlSidebar" || c.Name == "pnlHeader") return;
            if (IsDescendantOf(c, "pnlSidebar")) return;
            if (IsDescendantOf(c, "pnlHeader"))  return;

            string typeName = c.GetType().Name;

            // ── DataGridView (handles Guna2DataGridView too, which inherits it) ──
            if (c is DataGridView dgv)
            {
                dgv.BackgroundColor = DgvBg;
                dgv.GridColor = DgvGrid;
                dgv.DefaultCellStyle.BackColor  = DgvBg;
                dgv.DefaultCellStyle.ForeColor  = DgvRowFg;
                dgv.DefaultCellStyle.SelectionBackColor = DgvHdrBg;
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                dgv.AlternatingRowsDefaultCellStyle.BackColor = DgvAlt;
                dgv.AlternatingRowsDefaultCellStyle.ForeColor = DgvRowFg;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = DgvHdrBg;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = DgvHdrFg;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
                dgv.EnableHeadersVisualStyles = false;
                return;
            }

            // ── Panel (standard) ──────────────────────────────────────
            if (typeName == "Panel" || typeName == "FlowLayoutPanel" || typeName == "TableLayoutPanel")
            {
                c.BackColor = AppBg;
                return;
            }

            // ── Label ─────────────────────────────────────────────────
            if (c is Label lbl)
            {
                if (lbl.BackColor != Color.Transparent)
                    lbl.BackColor = AppBg;
                lbl.ForeColor = LabelFg;
                return;
            }

            // ── Standard text inputs ──────────────────────────────────
            if (c is TextBox tb)    { tb.BackColor = InputBg;  tb.ForeColor = InputFg;  return; }
            if (c is RichTextBox rt){ rt.BackColor = InputBg;  rt.ForeColor = InputFg;  return; }
            if (c is ListBox lb)    { lb.BackColor = InputBg;  lb.ForeColor = InputFg;  return; }
            if (c is ComboBox cb)   { cb.BackColor = InputBg;  cb.ForeColor = InputFg;  return; }

            // ── TabControl / TabPage ──────────────────────────────────
            if (c is TabPage tp)    { tp.BackColor = AppBg;    return; }
            if (c is TabControl tc) { tc.BackColor = AppBg;    return; }

            // ── UserControl (sub-forms) ───────────────────────────────
            if (c is UserControl)   { c.BackColor = AppBg;    return; }

            // ── GroupBox ──────────────────────────────────────────────
            if (c is GroupBox gb)   { gb.BackColor = AppBg; gb.ForeColor = LabelFg; return; }

            // ══ Guna2 controls — access via reflection ════════════════

            // Guna2Panel / Guna2CustomGradientPanel
            if (typeName == "Guna2Panel" || typeName.StartsWith("Guna2") && typeName.Contains("Panel"))
            {
                TrySetProp(c, "FillColor", AppBg);
                c.BackColor = AppBg;
                return;
            }

            // Guna2TextBox
            if (typeName == "Guna2TextBox")
            {
                TrySetProp(c, "FillColor", InputBg);
                c.ForeColor = InputFg;
                TrySetProp(c, "PlaceholderForeColor", IsDark ? Color.FromArgb(110, 120, 150) : Color.Gray);
                TrySetProp(c, "BorderColor", IsDark ? Color.FromArgb(65, 72, 100) : Color.FromArgb(180, 190, 210));
                return;
            }

            // Guna2ComboBox
            if (typeName == "Guna2ComboBox")
            {
                TrySetProp(c, "FillColor", InputBg);
                c.ForeColor = InputFg;
                TrySetProp(c, "BorderColor", IsDark ? Color.FromArgb(65, 72, 100) : Color.FromArgb(180, 190, 210));
                return;
            }

            // Guna2Button (content-area action buttons — keep their existing color)
            // These are purposely left alone; only sidebar nav buttons are themed.
        }

        static bool IsDescendantOf(Control c, string ancestorName)
        {
            Control p = c.Parent;
            while (p != null)
            {
                if (p.Name == ancestorName) return true;
                p = p.Parent;
            }
            return false;
        }

        static void TrySetProp(Control c, string propName, object value)
        {
            try
            {
                var prop = c.GetType().GetProperty(propName);
                prop?.SetValue(c, value);
            }
            catch { }
        }
    }
}
