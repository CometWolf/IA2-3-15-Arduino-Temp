namespace CabinTempArduino
{
    partial class frmChart
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
            this.chartFetchedValues = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartFetchedValues)).BeginInit();
            this.SuspendLayout();
            // 
            // chartFetchedValues
            // 
            chartArea1.Name = "ChartArea1";
            this.chartFetchedValues.ChartAreas.Add(chartArea1);
            this.chartFetchedValues.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 4F;
            legend1.Position.Width = 24.92401F;
            legend1.Position.X = 44F;
            legend1.Position.Y = 95F;
            legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.chartFetchedValues.Legends.Add(legend1);
            this.chartFetchedValues.Location = new System.Drawing.Point(0, 0);
            this.chartFetchedValues.Name = "chartFetchedValues";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.LegendText = "#SERIESNAME";
            series1.Name = "Temp.";
            this.chartFetchedValues.Series.Add(series1);
            this.chartFetchedValues.Size = new System.Drawing.Size(1387, 612);
            this.chartFetchedValues.TabIndex = 19;
            // 
            // frmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 612);
            this.Controls.Add(this.chartFetchedValues);
            this.Name = "frmChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chart";
            ((System.ComponentModel.ISupportInitialize)(this.chartFetchedValues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartFetchedValues;
    }
}