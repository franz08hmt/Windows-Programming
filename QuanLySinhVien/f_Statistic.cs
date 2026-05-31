using System;
using System.Data;
using System.Data.SqlClient;
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
            My_DB db = new My_DB();
            try
            {
                db.openConnection();

                string query = @"
    SELECT 
        XepLoai AS [Xếp Loại], 
        COUNT(*) AS [Số Lượng]
    FROM (
        SELECT MSSV,
            AVG(ISNULL(Diem, 0)) AS DiemTB,
            CASE 
                WHEN AVG(ISNULL(Diem, 0)) >= 9.0 THEN N'Xuất Sắc'
                WHEN AVG(ISNULL(Diem, 0)) >= 8.0 THEN N'Giỏi'
                WHEN AVG(ISNULL(Diem, 0)) >= 6.5 THEN N'Khá'
                WHEN AVG(ISNULL(Diem, 0)) >= 5.0 THEN N'Trung Bình'
                ELSE N'Yếu'
            END AS XepLoai
        FROM Score
        GROUP BY MSSV
    ) AS TableXepLoai
    GROUP BY XepLoai";

                SqlCommand cmd = new SqlCommand(query, db.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvReport.DataSource = dt;
                dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                chartGpa.Series.Clear();
                Series series = new Series("Học Lực");
                series.ChartType = SeriesChartType.Column;

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(row["Xếp Loại"].ToString(), Convert.ToInt32(row["Số Lượng"]));
                }

                chartGpa.Series.Add(series);
                chartGpa.Titles.Clear();
                chartGpa.Titles.Add("Biểu Đồ Phổ Điểm Học Lực Sinh Viên");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

      
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatisticData();
        }
    }
}