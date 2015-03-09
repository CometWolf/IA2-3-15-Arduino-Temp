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
            this.lblBatteryStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prbBatteryStatus = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbDatabaseValues = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFetchLast = new System.Windows.Forms.TextBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLimits = new System.Windows.Forms.Button();
            this.btnSubscribers = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grbFetchingValues = new System.Windows.Forms.GroupBox();
            this.cboAnnotation = new System.Windows.Forms.ComboBox();
            this.chbError = new System.Windows.Forms.CheckBox();
            this.chbTemperature = new System.Windows.Forms.CheckBox();
            this.grbBatteryStatus.SuspendLayout();
            this.grbFetchingValues.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBatteryStatus
            // 
            this.grbBatteryStatus.Controls.Add(this.lblBatteryStatus);
            this.grbBatteryStatus.Controls.Add(this.label2);
            this.grbBatteryStatus.Controls.Add(this.prbBatteryStatus);
            this.grbBatteryStatus.Location = new System.Drawing.Point(12, 320);
            this.grbBatteryStatus.Name = "grbBatteryStatus";
            this.grbBatteryStatus.Size = new System.Drawing.Size(465, 51);
            this.grbBatteryStatus.TabIndex = 0;
            this.grbBatteryStatus.TabStop = false;
            this.grbBatteryStatus.Text = "Battery Status";
            // 
            // lblBatteryStatus
            // 
            this.lblBatteryStatus.AutoSize = true;
            this.lblBatteryStatus.Location = new System.Drawing.Point(390, 29);
            this.lblBatteryStatus.Name = "lblBatteryStatus";
            this.lblBatteryStatus.Size = new System.Drawing.Size(27, 13);
            this.lblBatteryStatus.TabIndex = 4;
            this.lblBatteryStatus.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status: ";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current temp.";
            // 
            // rtbDatabaseValues
            // 
            this.rtbDatabaseValues.Location = new System.Drawing.Point(132, 24);
            this.rtbDatabaseValues.Name = "rtbDatabaseValues";
            this.rtbDatabaseValues.Size = new System.Drawing.Size(345, 290);
            this.rtbDatabaseValues.TabIndex = 3;
            this.rtbDatabaseValues.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(129, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fetched values from the database";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fetch for last:";
            // 
            // btnLimits
            // 
            this.btnLimits.Location = new System.Drawing.Point(12, 261);
            this.btnLimits.Name = "btnLimits";
            this.btnLimits.Size = new System.Drawing.Size(114, 23);
            this.btnLimits.TabIndex = 8;
            this.btnLimits.Text = "Limits";
            this.btnLimits.UseVisualStyleBackColor = true;
            this.btnLimits.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSubscribers
            // 
            this.btnSubscribers.Location = new System.Drawing.Point(12, 290);
            this.btnSubscribers.Name = "btnSubscribers";
            this.btnSubscribers.Size = new System.Drawing.Size(114, 23);
            this.btnSubscribers.TabIndex = 9;
            this.btnSubscribers.Text = "Subscribers";
            this.btnSubscribers.UseVisualStyleBackColor = true;
            this.btnSubscribers.Click += new System.EventHandler(this.btnSubscribers_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "What to fetch:";
            // 
            // grbFetchingValues
            // 
            this.grbFetchingValues.Controls.Add(this.cboAnnotation);
            this.grbFetchingValues.Controls.Add(this.chbError);
            this.grbFetchingValues.Controls.Add(this.chbTemperature);
            this.grbFetchingValues.Controls.Add(this.txtFetchLast);
            this.grbFetchingValues.Controls.Add(this.label5);
            this.grbFetchingValues.Controls.Add(this.btnFetch);
            this.grbFetchingValues.Controls.Add(this.label3);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 381);
            this.Controls.Add(this.grbFetchingValues);
            this.Controls.Add(this.btnSubscribers);
            this.Controls.Add(this.btnLimits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbDatabaseValues);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBatteryStatus;
        private System.Windows.Forms.ProgressBar prbBatteryStatus;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBatteryStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbDatabaseValues;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFetchLast;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLimits;
        private System.Windows.Forms.Button btnSubscribers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grbFetchingValues;
        private System.Windows.Forms.ComboBox cboAnnotation;
        private System.Windows.Forms.CheckBox chbError;
        private System.Windows.Forms.CheckBox chbTemperature;
    }
}

