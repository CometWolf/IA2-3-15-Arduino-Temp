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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grbBatteryStatus = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusStatic = new System.Windows.Forms.Label();
            this.prbBatteryStatus = new System.Windows.Forms.ProgressBar();
            this.txtCurrent = new System.Windows.Forms.TextBox();
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
            this.rbtError = new System.Windows.Forms.RadioButton();
            this.rbtTemperature = new System.Windows.Forms.RadioButton();
            this.cboAnnotation = new System.Windows.Forms.ComboBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.grbEdit = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.tabGraph = new System.Windows.Forms.TabPage();
            this.chartFetchedValues = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.spComPort = new System.IO.Ports.SerialPort(this.components);
            this.tmrBatteryStatus = new System.Windows.Forms.Timer(this.components);
            this.tmrLogTemperature = new System.Windows.Forms.Timer(this.components);
            this.tmrArduino = new System.Windows.Forms.Timer(this.components);
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
            resources.ApplyResources(this.grbBatteryStatus, "grbBatteryStatus");
            this.grbBatteryStatus.Controls.Add(this.lblStatus);
            this.grbBatteryStatus.Controls.Add(this.lblStatusStatic);
            this.grbBatteryStatus.Controls.Add(this.prbBatteryStatus);
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
            this.prbBatteryStatus.BackColor = System.Drawing.Color.White;
            this.prbBatteryStatus.Name = "prbBatteryStatus";
            this.prbBatteryStatus.Step = 1;
            this.prbBatteryStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prbBatteryStatus.Value = 100;
            // 
            // txtCurrent
            // 
            resources.ApplyResources(this.txtCurrent, "txtCurrent");
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
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
            this.rtbDatabaseValues.ReadOnly = true;
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
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
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
            this.btnLimits.Click += new System.EventHandler(this.btnLimits_Click);
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
            this.grbFetchingValues.Controls.Add(this.rbtError);
            this.grbFetchingValues.Controls.Add(this.rbtTemperature);
            this.grbFetchingValues.Controls.Add(this.cboAnnotation);
            this.grbFetchingValues.Controls.Add(this.txtFetchLast);
            this.grbFetchingValues.Controls.Add(this.lblWhatToFetch);
            this.grbFetchingValues.Controls.Add(this.btnFetch);
            this.grbFetchingValues.Controls.Add(this.lblFetchForLast);
            resources.ApplyResources(this.grbFetchingValues, "grbFetchingValues");
            this.grbFetchingValues.Name = "grbFetchingValues";
            this.grbFetchingValues.TabStop = false;
            // 
            // rbtError
            // 
            resources.ApplyResources(this.rbtError, "rbtError");
            this.rbtError.Name = "rbtError";
            this.rbtError.TabStop = true;
            this.rbtError.UseVisualStyleBackColor = true;
            // 
            // rbtTemperature
            // 
            resources.ApplyResources(this.rbtTemperature, "rbtTemperature");
            this.rbtTemperature.Name = "rbtTemperature";
            this.rbtTemperature.TabStop = true;
            this.rbtTemperature.UseVisualStyleBackColor = true;
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
            this.cboAnnotation.SelectedIndexChanged += new System.EventHandler(this.cboAnnotation_SelectedIndexChanged);
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click_1);
            // 
            // grbEdit
            // 
            this.grbEdit.Controls.Add(this.btnLimits);
            this.grbEdit.Controls.Add(this.btnSettings);
            this.grbEdit.Controls.Add(this.btnSubscribers);
            resources.ApplyResources(this.grbEdit, "grbEdit");
            this.grbEdit.Name = "grbEdit";
            this.grbEdit.TabStop = false;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabTable);
            this.tabControl1.Controls.Add(this.tabGraph);
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
            resources.ApplyResources(this.chartFetchedValues, "chartFetchedValues");
            chartArea1.Name = "ChartArea1";
            this.chartFetchedValues.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 4F;
            legend1.Position.Width = 24.92401F;
            legend1.Position.X = 44F;
            legend1.Position.Y = 95F;
            legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
            this.chartFetchedValues.Legends.Add(legend1);
            this.chartFetchedValues.Name = "chartFetchedValues";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.LegendText = "#SERIESNAME";
            series1.Name = "Temp.";
            this.chartFetchedValues.Series.Add(series1);
            // 
            // spComPort
            // 
            this.spComPort.PortName = "COM6";
            // 
            // tmrBatteryStatus
            // 
            this.tmrBatteryStatus.Enabled = true;
            this.tmrBatteryStatus.Interval = 1000;
            this.tmrBatteryStatus.Tick += new System.EventHandler(this.tmrBatteryStatus_Tick);
            // 
            // tmrLogTemperature
            // 
            this.tmrLogTemperature.Enabled = true;
            this.tmrLogTemperature.Interval = 500;
            this.tmrLogTemperature.Tick += new System.EventHandler(this.tmrLogTemperature_Tick);
            // 
            // tmrArduino
            // 
            this.tmrArduino.Enabled = true;
            this.tmrArduino.Tick += new System.EventHandler(this.tmrArduino_Tick);
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
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.grbBatteryStatus);
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
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
        private System.Windows.Forms.TextBox txtCurrent;
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
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.GroupBox grbEdit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.TabPage tabGraph;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFetchedValues;
        private System.IO.Ports.SerialPort spComPort;
        private System.Windows.Forms.Timer tmrBatteryStatus;
        private System.Windows.Forms.Timer tmrLogTemperature;
        private System.Windows.Forms.RadioButton rbtError;
        private System.Windows.Forms.RadioButton rbtTemperature;
        private System.Windows.Forms.Timer tmrArduino;
    }
}

