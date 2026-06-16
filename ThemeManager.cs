using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    internal static class ThemeManager
    {
        public static bool IsDark { get; private set; } = false;

        // ── Bảng màu ──────────────────────────────────────────────────────
        public static Color PageBg   => IsDark ? Color.FromArgb( 15,  20,  30) : Color.FromArgb(242, 246, 252);
        public static Color CardBg   => IsDark ? Color.FromArgb( 24,  32,  46) : Color.White;
        public static Color InputBg  => IsDark ? Color.FromArgb( 32,  41,  58) : Color.FromArgb(248, 250, 252);
        public static Color TextMain => IsDark ? Color.FromArgb(218, 228, 242) : Color.FromArgb( 18,  31,  53);
        public static Color Primary  => IsDark ? Color.FromArgb(100, 160, 255) : Color.FromArgb(  0,  61, 149);
        public static Color Border   => IsDark ? Color.FromArgb( 48,  62,  82) : Color.FromArgb(222, 231, 242);
        public static Color GridAlt  => IsDark ? Color.FromArgb( 28,  38,  56) : Color.FromArgb(248, 250, 252);
        public static Color GridSel  => IsDark ? Color.FromArgb( 45,  80, 140) : Color.FromArgb(219, 234, 254);

        // Panel/control cần giữ nguyên màu gốc (sidebar, header)
        private static readonly HashSet<string> _skipBranch =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "pnlSidebar", "pnlHeader" };

        // Panel đóng vai trò container trang (nền tổng), không phải card
        private static readonly HashSet<string> _pagePanels =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "pnlMainContent" };

        // ── Toggle ────────────────────────────────────────────────────────
        public static void Toggle() => IsDark = !IsDark;

        // ── Entry point ───────────────────────────────────────────────────
        public static void Apply(Control root)
        {
            if (root == null) return;
            ApplyNode(root);
        }

        // ── Duyệt đệ quy, không dùng depth — Panel nào cũng là CardBg ──
        private static void ApplyNode(Control ctrl)
        {
            if (_skipBranch.Contains(ctrl.Name)) return;

            string typeName = ctrl.GetType().Name;

            // Chart (System.Windows.Forms.DataVisualization) — xử lý qua reflection
            if (typeName == "Chart")
            {
                ApplyChart(ctrl);
                return;
            }

            // Guna2Panel — set FillColor qua reflection, sau đó recurse bình thường
            if (typeName.StartsWith("Guna2", StringComparison.Ordinal) &&
                typeName.IndexOf("Panel", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                TrySetProp(ctrl, "FillColor", CardBg);
                ctrl.ForeColor = TextMain;
            }

            switch (ctrl)
            {
                case DataGridView dgv:
                    ApplyGrid(dgv);
                    return; // không recurse vào cells

                case UserControl _:
                case Form _:
                    ctrl.BackColor = PageBg;
                    break;

                case TabPage _:
                    ctrl.BackColor = PageBg;
                    break;

                case TabControl tc:
                    tc.BackColor = PageBg;
                    break;

                case Panel _:
                    // pnlMainContent = nền trang; mọi panel khác = card
                    ctrl.BackColor = _pagePanels.Contains(ctrl.Name) ? PageBg : CardBg;
                    break;

                case GroupBox gb:
                    gb.BackColor = CardBg;
                    gb.ForeColor = TextMain;
                    break;

                case Label lbl:
                    lbl.ForeColor = lbl.Font.Size >= 16 ? Primary : TextMain;
                    break;

                case TextBox txt:
                    txt.BackColor = InputBg;
                    txt.ForeColor = TextMain;
                    break;

                case ComboBox cbo:
                    cbo.BackColor = InputBg;
                    cbo.ForeColor = TextMain;
                    break;

                case DateTimePicker dtp:
                    dtp.BackColor = InputBg;
                    dtp.ForeColor = TextMain;
                    break;

                case NumericUpDown nud:
                    nud.BackColor = InputBg;
                    nud.ForeColor = TextMain;
                    break;

                case ListBox lst:
                    lst.BackColor = InputBg;
                    lst.ForeColor = TextMain;
                    break;

                case RichTextBox rtb:
                    rtb.BackColor = InputBg;
                    rtb.ForeColor = TextMain;
                    break;

                case CheckBox chk:
                    chk.ForeColor = TextMain;
                    break;

                case RadioButton rb:
                    rb.ForeColor = TextMain;
                    break;
            }

            // Recurse
            foreach (Control child in ctrl.Controls)
                ApplyNode(child);
        }

        // ── DataGridView ──────────────────────────────────────────────────
        public static void ApplyGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = CardBg;
            dgv.DefaultCellStyle.BackColor = CardBg;
            dgv.DefaultCellStyle.ForeColor = TextMain;
            dgv.DefaultCellStyle.SelectionBackColor = GridSel;
            dgv.DefaultCellStyle.SelectionForeColor = TextMain;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAlt;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextMain;
            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                IsDark ? Color.FromArgb(20, 50, 105) : Color.FromArgb(0, 61, 149);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.GridColor = Border;
        }

        // ── Chart (reflection vì không muốn hard-reference assembly) ──────
        private static void ApplyChart(Control chartCtrl)
        {
            chartCtrl.BackColor = CardBg;
            try
            {
                var t = chartCtrl.GetType();
                // ChartAreas
                var areasProp = t.GetProperty("ChartAreas");
                if (areasProp != null)
                {
                    var areas = areasProp.GetValue(chartCtrl) as System.Collections.IEnumerable;
                    if (areas != null)
                        foreach (object area in areas)
                            ApplyChartArea(area);
                }
                // Legends
                var legendsProp = t.GetProperty("Legends");
                if (legendsProp != null)
                {
                    var legends = legendsProp.GetValue(chartCtrl) as System.Collections.IEnumerable;
                    if (legends != null)
                        foreach (object leg in legends)
                        {
                            TrySetProp(leg, "BackColor", CardBg);
                            TrySetProp(leg, "ForeColor", TextMain);
                        }
                }
            }
            catch { }
        }

        private static void ApplyChartArea(object area)
        {
            TrySetProp(area, "BackColor", CardBg);
            ApplyChartAxis(area, "AxisX");
            ApplyChartAxis(area, "AxisY");
            ApplyChartAxis(area, "AxisX2");
            ApplyChartAxis(area, "AxisY2");
        }

        private static void ApplyChartAxis(object area, string axisName)
        {
            var at = area.GetType();
            var axisProp = at.GetProperty(axisName);
            if (axisProp == null) return;
            object axis = axisProp.GetValue(area);
            TrySetProp(axis, "LineColor", Border);
            TrySetProp(axis, "TitleForeColor", TextMain);
            // LabelStyle.ForeColor
            var lsProp = axis.GetType().GetProperty("LabelStyle");
            if (lsProp != null) TrySetProp(lsProp.GetValue(axis), "ForeColor", TextMain);
            // MajorGrid.LineColor
            var mgProp = axis.GetType().GetProperty("MajorGrid");
            if (mgProp != null) TrySetProp(mgProp.GetValue(axis), "LineColor", Border);
        }

        private static void TrySetProp(object target, string prop, object value)
        {
            if (target == null) return;
            try { target.GetType().GetProperty(prop)?.SetValue(target, value); }
            catch { }
        }
    }
}
