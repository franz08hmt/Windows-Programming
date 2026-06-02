using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLySinhVien
{
    public partial class f_Statistic : Form
    {
        public f_Statistic()
        {
            InitializeComponent();
        }

        private void f_Statistic_Load(object sender, EventArgs e)
        {
            LoadStatisticData();
        }

        private void LoadStatisticData()
        {
            // ── Bảng xếp loại ──
            DataTable dtXepLoai = Score.GetCountByXepLoai();
            dgvReport.DataSource = dtXepLoai;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ── Biểu đồ cột: xếp loại ──
            chartGpa.Series.Clear();
            chartGpa.Titles.Clear();
            chartGpa.Titles.Add("Phổ Điểm Học Lực");
            chartGpa.Titles[0].Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            chartGpa.Titles[0].ForeColor = Color.FromArgb(21, 67, 137);

            Series seriesCol = new Series("Học Lực");
            seriesCol.ChartType = SeriesChartType.Column;
            seriesCol.IsValueShownAsLabel = true;
            seriesCol.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            seriesCol.LabelForeColor = Color.FromArgb(21, 67, 137);

            // Màu theo xếp loại
            string[] colors = { "#8B0000", "#FF8C00", "#1E90FF", "#228B22", "#9932CC" };
            int colorIdx = 0;

            if (dtXepLoai != null)
            {
                foreach (DataRow row in dtXepLoai.Rows)
                {
                    int pointIdx = seriesCol.Points.AddXY(
                        row["Xếp Loại"].ToString(),
                        Convert.ToInt32(row["Số Lượng"])
                    );
                    seriesCol.Points[pointIdx].Color =
                        ColorTranslator.FromHtml(colors[colorIdx % colors.Length]);
                    colorIdx++;
                }
            }

            chartGpa.Series.Add(seriesCol);
            chartGpa.ChartAreas[0].AxisX.Interval = 1;
            chartGpa.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9f);
            chartGpa.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 9f);
            chartGpa.ChartAreas[0].BackColor = Color.WhiteSmoke;
            chartGpa.BackColor = Color.White;

            // ── Bảng thống kê chi tiết từng SV ──
            DataTable dtStats = Score.GetScoreStatistics();
            dgvDetail.DataSource = dtStats;
            dgvDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ── Label tổng quan ──
            lblTongSV.Text = $"Tổng SV có điểm: {(dtStats?.Rows.Count ?? 0)}";
            lblTongMon.Text = $"Tổng môn học: {Score.GetAvgScoreBySubject()?.Rows.Count ?? 0}";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatisticData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}