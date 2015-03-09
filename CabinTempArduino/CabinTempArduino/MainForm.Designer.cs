namespace CabinTempArduino
{
    partial class MainForm
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
            this.grbBatteryStatus.SuspendLayout();
            this.grbFetchingValues.SuspendLayout();
            this.grbEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBatteryStatus
            // 
            this.grbBatteryStatus.Controls.Add(this.lblStatus);
            this.grbBatteryStatus.Controls.Add(this.lblStatusStatic);
            this.grbBatteryStatus.Controls.Add(this.prbBatteryStatus);
            this.grbBatteryStatus.Location = new System.Drawing.Point(11, 363);
            this.grbBatteryStatus.Name = "grbBatteryStatus";
            this.grbBatteryStatus.Size = new System.Drawing.Size(465, 51);
            this.grbBatteryStatus.TabIndex = 0;
            this.grbBatteryStatus.TabStop = false;
            this.grbBatteryStatus.Text = "Battery Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(390, 29);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(27, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "N/A";
            // 
            // lblStatusStatic
            // 
            this.lblStatusStatic.AutoSize = true;
            this.lblStatusStatic.Location = new System.Drawing.Point(390, 16);
            this.lblStatusStatic.Name = "lblStatusStatic";
            this.lblStatusStatic.Size = new System.Drawing.Size(43, 13);
            this.lblStatusStatic.TabIndex = 3;
            this.lblStatusStatic.Text = "Status: ";
            // 
            // prbBatteryStatus
            // 
            this.prbBatteryStatus.Location = new System.Drawing.Point(6, 19);
            this.prbBatteryStatus.Name = "prbBatteryStatus";
            this.prbBatteryStatus.Size = new System.Drawing.Size(378, 23);
            this.prbBatteryStatus.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lblCurrentTemp
            // 
            this.lblCurrentTemp.AutoSize = true;
            this.lblCurrentTemp.Location = new System.Drawing.Point(12, 8);
            this.lblCurrentTemp.Name = "lblCurrentTemp";
            this.lblCurrentTemp.Size = new System.Drawing.Size(70, 13);
            this.lblCurrentTemp.TabIndex = 2;
            this.lblCurrentTemp.Text = "Current temp.";
            // 
            // rtbDatabaseValues
            // 
            this.rtbDatabaseValues.Location = new System.Drawing.Point(132, 24);
            this.rtbDatabaseValues.Name = "rtbDatabaseValues";
            this.rtbDatabaseValues.Size = new System.Drawing.Size(345, 333);
            this.rtbDatabaseValues.TabIndex = 3;
            this.rtbDatabaseValues.Text = "";
            // 
            // lblFetchedValuesDB
            // 
            this.lblFetchedValuesDB.AutoSize = true;
            this.lblFetchedValuesDB.Location = new System.Drawing.Point(129, 9);
            this.lblFetchedValuesDB.Name = "lblFetchedValuesDB";
            this.lblFetchedValuesDB.Size = new System.Drawing.Size(168, 13);
            this.lblFetchedValuesDB.TabIndex = 4;
            this.lblFetchedValuesDB.Text = "Fetched values from the database";
            // 
            // txtFetchLast
            // 
            this.txtFetchLast.Location = new System.Drawing.Point(6, 38);
            this.txtFetchLast.Name = "txtFetchLast";
            this.txtFetchLast.Size = new System.Drawing.Size(101, 20);
            this.txtFetchLast.TabIndex = 5;
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(6, 154);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(101, 23);
            this.btnFetch.TabIndex = 6;
            this.btnFetch.Text = "Fetch values";
            this.btnFetch.UseVisualStyleBackColor = true;
            // 
            // lblFetchForLast
            // 
            this.lblFetchForLast.AutoSize = true;
            this.lblFetchForLast.Location = new System.Drawing.Point(3, 22);
            this.lblFetchForLast.Name = "lblFetchForLast";
            this.lblFetchForLast.Size = new System.Drawing.Size(71, 13);
            this.lblFetchForLast.TabIndex = 7;
            this.lblFetchForLast.Text = "Fetch for last:";
            // 
            // btnLimits
            // 
            this.btnLimits.Location = new System.Drawing.Point(6, 48);
            this.btnLimits.Name = "btnLimits";
            this.btnLimits.Size = new System.Drawing.Size(101, 23);
            this.btnLimits.TabIndex = 8;
            this.btnLimits.Text = "Limits";
            this.btnLimits.UseVisualStyleBackColor = true;
            this.btnLimits.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSubscribers
            // 
            this.btnSubscribers.Location = new System.Drawing.Point(6, 77);
            this.btnSubscribers.Name = "btnSubscribers";
            this.btnSubscribers.Size = new System.Drawing.Size(101, 23);
            this.btnSubscribers.TabIndex = 9;
            this.btnSubscribers.Text = "Subscribers";
            this.btnSubscribers.UseVisualStyleBackColor = true;
            this.btnSubscribers.Click += new System.EventHandler(this.btnSubscribers_Click);
            // 
            // lblWhatToFetch
            // 
            this.lblWhatToFetch.AutoSize = true;
            this.lblWhatToFetch.Location = new System.Drawing.Point(3, 93);
            this.lblWhatToFetch.Name = "lblWhatToFetch";
            this.lblWhatToFetch.Size = new System.Drawing.Size(75, 13);
            this.lblWhatToFetch.TabIndex = 13;
            this.lblWhatToFetch.Text = "What to fetch:";
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
            this.grbFetchingValues.Location = new System.Drawing.Point(12, 61);
            this.grbFetchingValues.Name = "grbFetchingValues";
            this.grbFetchingValues.Size = new System.Drawing.Size(114, 183);
            this.grbFetchingValues.TabIndex = 14;
            this.grbFetchingValues.TabStop = false;
            this.grbFetchingValues.Text = "Fetching values";
            // 
            // cboAnnotation
            // 
            this.cboAnnotation.FormattingEnabled = true;
            this.cboAnnotation.Items.AddRange(new object[] {
            "Values",
            "Day(s)",
            "Month(s)",
            "Year(s)"});
            this.cboAnnotation.Location = new System.Drawing.Point(6, 64);
            this.cboAnnotation.Name = "cboAnnotation";
            this.cboAnnotation.Size = new System.Drawing.Size(101, 21);
            this.cboAnnotation.TabIndex = 16;
            this.cboAnnotation.Text = "Annotation";
            // 
            // chbError
            // 
            this.chbError.AutoSize = true;
            this.chbError.Location = new System.Drawing.Point(6, 132);
            this.chbError.Name = "chbError";
            this.chbError.Size = new System.Drawing.Size(48, 17);
            this.chbError.TabIndex = 15;
            this.chbError.Text = "Error";
            this.chbError.UseVisualStyleBackColor = true;
            // 
            // chbTemperature
            // 
            this.chbTemperature.AutoSize = true;
            this.chbTemperature.Location = new System.Drawing.Point(6, 109);
            this.chbTemperature.Name = "chbTemperature";
            this.chbTemperature.Size = new System.Drawing.Size(86, 17);
            this.chbTemperature.TabIndex = 14;
            this.chbTemperature.Text = "Temperature";
            this.chbTemperature.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // grbEdit
            // 
            this.grbEdit.Controls.Add(this.btnLimits);
            this.grbEdit.Controls.Add(this.button1);
            this.grbEdit.Controls.Add(this.btnSubscribers);
            this.grbEdit.Location = new System.Drawing.Point(12, 250);
            this.grbEdit.Name = "grbEdit";
            this.grbEdit.Size = new System.Drawing.Size(114, 107);
            this.grbEdit.TabIndex = 16;
            this.grbEdit.TabStop = false;
            this.grbEdit.Text = "Edit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 425);
            this.Controls.Add(this.grbEdit);
            this.Controls.Add(this.grbFetchingValues);
            this.Controls.Add(this.lblFetchedValuesDB);
            this.Controls.Add(this.rtbDatabaseValues);
            this.Controls.Add(this.lblCurrentTemp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.grbBatteryStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Morten\'s cabin temperature!";
            this.grbBatteryStatus.ResumeLayout(false);
            this.grbBatteryStatus.PerformLayout();
            this.grbFetchingValues.ResumeLayout(false);
            this.grbFetchingValues.PerformLayout();
            this.grbEdit.ResumeLayout(false);
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
    }
}

