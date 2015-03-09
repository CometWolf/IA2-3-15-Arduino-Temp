namespace CabinTempArduino
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grbBatteryStatus = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusStatic = new System.Windows.Forms.Label();
            this.prbBatteryStatus = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblCurrentTemp = new System.Windows.Forms.Label();
            this.rtbDatabaseValues = new System.Windows.Forms.RichTextBox();
            this.lblFetchedValuesDB = new System.Windows.Forms.Label();
            this.txtFetchLast = new System.Windows.Forms.TextBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.lblFetchForLast = new System.Windows.Forms.Label();
            this.btnLimits = new System.Windows.Forms.Button();
            this.btnSubscribers = new System.Windows.Forms.Button();
            this.lblWhatToFetch = new System.Windows.Forms.Label();
            this.grbFetchingValues = new System.Windows.Forms.GroupBox();
            this.cboAnnotation = new System.Windows.Forms.ComboBox();
            this.chbError = new System.Windows.Forms.CheckBox();
            this.chbTemperature = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grbEdit = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.tabGraph = new System.Windows.Forms.TabPage();
            this.chartFetchedValues = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.totGraph = new System.Windows.Forms.ToolTip(this.components);
            this.grbBatteryStatus.SuspendLayout();
            this.grbFetchingValues.SuspendLayout();
            this.grbEdit.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.tabGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFetchedValues)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBatteryStatus
            // 
            this.grbBatteryStatus.Controls.Add(this.lblStatus);
            this.grbBatteryStatus.Controls.Add(this.lblStatusStatic);
            this.grbBatteryStatus.Controls.Add(this.prbBatteryStatus);
            resources.ApplyResources(this.grbBatteryStatus, "grbBatteryStatus");
            this.grbBatteryStatus.Name = "grbBatteryStatus";
            this.grbBatteryStatus.TabStop = false;
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // lblStatusStatic
            // 
            resources.ApplyResources(this.lblStatusStatic, "lblStatusStatic");
            this.lblStatusStatic.Name = "lblStatusStatic";
            // 
            // prbBatteryStatus
            // 
            resources.ApplyResources(this.prbBatteryStatus, "prbBatteryStatus");
            this.prbBatteryStatus.Name = "prbBatteryStatus";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // lblCurrentTemp
            // 
            resources.ApplyResources(this.lblCurrentTemp, "lblCurrentTemp");
            this.lblCurrentTemp.Name = "lblCurrentTemp";
            // 
            // rtbDatabaseValues
            // 
            resources.ApplyResources(this.rtbDatabaseValues, "rtbDatabaseValues");
            this.rtbDatabaseValues.Name = "rtbDatabaseValues";
            // 
            // lblFetchedValuesDB
            // 
            resources.ApplyResources(this.lblFetchedValuesDB, "lblFetchedValuesDB");
            this.lblFetchedValuesDB.Name = "lblFetchedValuesDB";
            // 
            // txtFetchLast
            // 
            resources.ApplyResources(this.txtFetchLast, "txtFetchLast");
            this.txtFetchLast.Name = "txtFetchLast";
            // 
            // btnFetch
            // 
            resources.ApplyResources(this.btnFetch, "btnFetch");
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            // 
            // lblFetchForLast
            // 
            resources.ApplyResources(this.lblFetchForLast, "lblFetchForLast");
            this.lblFetchForLast.Name = "lblFetchForLast";
            // 
            // btnLimits
            // 
            resources.ApplyResources(this.btnLimits, "btnLimits");
            this.btnLimits.Name = "btnLimits";
            this.btnLimits.UseVisualStyleBackColor = true;
            this.btnLimits.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSubscribers
            // 
            resources.ApplyResources(this.btnSubscribers, "btnSubscribers");
            this.btnSubscribers.Name = "btnSubscribers";
            this.btnSubscribers.UseVisualStyleBackColor = true;
            this.btnSubscribers.Click += new System.EventHandler(this.btnSubscribers_Click);
            // 
            // lblWhatToFetch
            // 
            resources.ApplyResources(this.lblWhatToFetch, "lblWhatToFetch");
            this.lblWhatToFetch.Name = "lblWhatToFetch";
            // 
            // grbFetchingValues
            // 
            this.grbFetchingValues.Controls.Add(this.cboAnnotation);
            this.grbFetchingValues.Controls.Add(this.chbError);
            this.grbFetchingValues.Controls.Add(this.chbTemperature);
            this.grbFetchingValues.Controls.Add(this.txtFetchLast);
            this.grbFetchingValues.Controls.Add(this.lblWhatToFetch);
            this.grbFetchingValues.Controls.Add(this.btnFetch);
            this.grbFetchingValues.Controls.Add(this.lblFetchForLast);
            resources.ApplyResources(this.grbFetchingValues, "grbFetchingValues");
            this.grbFetchingValues.Name = "grbFetchingValues";
            this.grbFetchingValues.TabStop = false;
            // 
            // cboAnnotation
            // 
            this.cboAnnotation.FormattingEnabled = true;
            this.cboAnnotation.Items.AddRange(new object[] {
            resources.GetString("cboAnnotation.Items"),
            resources.GetString("cboAnnotation.Items1"),
            resources.GetString("cboAnnotation.Items2"),
            resources.GetString("cboAnnotation.Items3")});
            resources.ApplyResources(this.cboAnnotation, "cboAnnotation");
            this.cboAnnotation.Name = "cboAnnotation";
            // 
            // chbError
            // 
            resources.ApplyResources(this.chbError, "chbError");
            this.chbError.Name = "chbError";
            this.chbError.UseVisualStyleBackColor = true;
            // 
            // chbTemperature
            // 
            resources.ApplyResources(this.chbTemperature, "chbTemperature");
            this.chbTemperature.Name = "chbTemperature";
            this.chbTemperature.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // grbEdit
            // 
            this.grbEdit.Controls.Add(this.btnLimits);
            this.grbEdit.Controls.Add(this.button1);
            this.grbEdit.Controls.Add(this.btnSubscribers);
            resources.ApplyResources(this.grbEdit, "grbEdit");
            this.grbEdit.Name = "grbEdit";
            this.grbEdit.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTable);
            this.tabControl1.Controls.Add(this.tabGraph);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.rtbDatabaseValues);
            resources.ApplyResources(this.tabTable, "tabTable");
            this.tabTable.Name = "tabTable";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // tabGraph
            // 
            this.tabGraph.Controls.Add(this.chartFetchedValues);
            resources.ApplyResources(this.tabGraph, "tabGraph");
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.UseVisualStyleBackColor = true;
            // 
            // chartFetchedValues
            // 
            chartArea4.Name = "ChartArea1";
            this.chartFetchedValues.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            legend4.Position.Auto = false;
            legend4.Position.Height = 4F;
            legend4.Position.Width = 24.92401F;
            legend4.Position.X = 44F;
            legend4.Position.Y = 95F;
            legend4.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.chartFetchedValues.Legends.Add(legend4);
            resources.ApplyResources(this.chartFetchedValues, "chartFetchedValues");
            this.chartFetchedValues.Name = "chartFetchedValues";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.LegendText = "#SERIESNAME";
            series4.Name = "Temp.";
            this.chartFetchedValues.Series.Add(series4);
            this.chartFetchedValues.Click += new System.EventHandler(this.chartFetchedValues_Click);
            // 
            // totGraph
            // 
            this.totGraph.AutoPopDelay = 3000;
            this.totGraph.InitialDelay = 500;
            this.totGraph.ReshowDelay = 10000;
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grbEdit);
            this.Controls.Add(this.grbFetchingValues);
            this.Controls.Add(this.lblFetchedValuesDB);
            this.Controls.Add(this.lblCurrentTemp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.grbBatteryStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.grbBatteryStatus.ResumeLayout(false);
            this.grbBatteryStatus.PerformLayout();
            this.grbFetchingValues.ResumeLayout(false);
            this.grbFetchingValues.PerformLayout();
            this.grbEdit.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartFetchedValues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBatteryStatus;
        private System.Windows.Forms.ProgressBar prbBatteryStatus;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCurrentTemp;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusStatic;
        private System.Windows.Forms.RichTextBox rtbDatabaseValues;
        private System.Windows.Forms.Label lblFetchedValuesDB;
        private System.Windows.Forms.TextBox txtFetchLast;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Label lblFetchForLast;
        private System.Windows.Forms.Button btnLimits;
        private System.Windows.Forms.Button btnSubscribers;
        private System.Windows.Forms.Label lblWhatToFetch;
        private System.Windows.Forms.GroupBox grbFetchingValues;
        private System.Windows.Forms.ComboBox cboAnnotation;
        private System.Windows.Forms.CheckBox chbError;
        private System.Windows.Forms.CheckBox chbTemperature;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grbEdit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.TabPage tabGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFetchedValues;
        private System.Windows.Forms.ToolTip totGraph;
    }
}

