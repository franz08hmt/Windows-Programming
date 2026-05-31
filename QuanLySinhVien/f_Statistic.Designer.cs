namespace QuanLySinhVien
{
    partial class f_Statistic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.chartGpa = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpa)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(0, 2);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersWidth = 62;
            this.dgvReport.RowTemplate.Height = 28;
            this.dgvReport.Size = new System.Drawing.Size(388, 447);
            this.dgvReport.TabIndex = 0;
            // 
            // chartGpa
            // 
            chartArea1.Name = "ChartArea1";
            this.chartGpa.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartGpa.Legends.Add(legend1);
            this.chartGpa.Location = new System.Drawing.Point(385, 2);
            this.chartGpa.Name = "chartGpa";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartGpa.Series.Add(series1);
            this.chartGpa.Size = new System.Drawing.Size(412, 447);
            this.chartGpa.TabIndex = 1;
            this.chartGpa.Text = "chart1";
            // 
            // f_Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartGpa);
            this.Controls.Add(this.dgvReport);
            this.Name = "f_Statistic";
            this.Text = "f_Statistic";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGpa)).EndInit();
            this.Load += new System.EventHandler(this.f_Statistic_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGpa;
    }
}