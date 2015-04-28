namespace CabinTempArduino
{
    partial class frmSettings
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
            this.grbLogging = new System.Windows.Forms.GroupBox();
            this.btnInterval = new System.Windows.Forms.Button();
            this.rbtMinutes = new System.Windows.Forms.RadioButton();
            this.rbtHours = new System.Windows.Forms.RadioButton();
            this.txtCustomInterval = new System.Windows.Forms.TextBox();
            this.cboPreset = new System.Windows.Forms.ComboBox();
            this.grbPort = new System.Windows.Forms.GroupBox();
            this.btnComPort = new System.Windows.Forms.Button();
            this.cboComPort = new System.Windows.Forms.ComboBox();
            this.grbLogging.SuspendLayout();
            this.grbPort.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbLogging
            // 
            this.grbLogging.Controls.Add(this.btnInterval);
            this.grbLogging.Controls.Add(this.rbtMinutes);
            this.grbLogging.Controls.Add(this.rbtHours);
            this.grbLogging.Controls.Add(this.txtCustomInterval);
            this.grbLogging.Controls.Add(this.cboPreset);
            this.grbLogging.Location = new System.Drawing.Point(12, 12);
            this.grbLogging.Name = "grbLogging";
            this.grbLogging.Size = new System.Drawing.Size(223, 95);
            this.grbLogging.TabIndex = 0;
            this.grbLogging.TabStop = false;
            this.grbLogging.Text = "Intervall logging";
            // 
            // btnInterval
            // 
            this.btnInterval.Location = new System.Drawing.Point(6, 46);
            this.btnInterval.Name = "btnInterval";
            this.btnInterval.Size = new System.Drawing.Size(121, 40);
            this.btnInterval.TabIndex = 2;
            this.btnInterval.Text = "Sett intervall";
            this.btnInterval.UseVisualStyleBackColor = true;
            this.btnInterval.Click += new System.EventHandler(this.btnInterval_Click);
            // 
            // rbtMinutes
            // 
            this.rbtMinutes.AutoSize = true;
            this.rbtMinutes.Location = new System.Drawing.Point(133, 69);
            this.rbtMinutes.Name = "rbtMinutes";
            this.rbtMinutes.Size = new System.Drawing.Size(63, 17);
            this.rbtMinutes.TabIndex = 4;
            this.rbtMinutes.TabStop = true;
            this.rbtMinutes.Text = "Minutter";
            this.rbtMinutes.UseVisualStyleBackColor = true;
            // 
            // rbtHours
            // 
            this.rbtHours.AutoSize = true;
            this.rbtHours.Location = new System.Drawing.Point(133, 46);
            this.rbtHours.Name = "rbtHours";
            this.rbtHours.Size = new System.Drawing.Size(51, 17);
            this.rbtHours.TabIndex = 3;
            this.rbtHours.TabStop = true;
            this.rbtHours.Text = "Timer";
            this.rbtHours.UseVisualStyleBackColor = true;
            // 
            // txtCustomInterval
            // 
            this.txtCustomInterval.Location = new System.Drawing.Point(133, 19);
            this.txtCustomInterval.Name = "txtCustomInterval";
            this.txtCustomInterval.Size = new System.Drawing.Size(81, 20);
            this.txtCustomInterval.TabIndex = 1;
            this.txtCustomInterval.Text = "Verdi";
            this.txtCustomInterval.Click += new System.EventHandler(this.txtCustomInterval_Click);
            // 
            // cboPreset
            // 
            this.cboPreset.FormattingEnabled = true;
            this.cboPreset.Items.AddRange(new object[] {
            "60 minutter",
            "30 minutter",
            "15 minutter",
            "Egendefinert"});
            this.cboPreset.Location = new System.Drawing.Point(6, 19);
            this.cboPreset.Name = "cboPreset";
            this.cboPreset.Size = new System.Drawing.Size(121, 21);
            this.cboPreset.TabIndex = 0;
            this.cboPreset.Text = "Fohåndsinnstillinger";
            this.cboPreset.SelectedIndexChanged += new System.EventHandler(this.cboPreset_SelectedIndexChanged);
            // 
            // grbPort
            // 
            this.grbPort.Controls.Add(this.btnComPort);
            this.grbPort.Controls.Add(this.cboComPort);
            this.grbPort.Location = new System.Drawing.Point(12, 113);
            this.grbPort.Name = "grbPort";
            this.grbPort.Size = new System.Drawing.Size(223, 54);
            this.grbPort.TabIndex = 1;
            this.grbPort.TabStop = false;
            this.grbPort.Text = "COM Port";
            // 
            // btnComPort
            // 
            this.btnComPort.Location = new System.Drawing.Point(133, 19);
            this.btnComPort.Name = "btnComPort";
            this.btnComPort.Size = new System.Drawing.Size(81, 23);
            this.btnComPort.TabIndex = 6;
            this.btnComPort.Text = "Sett COM Port";
            this.btnComPort.UseVisualStyleBackColor = true;
            this.btnComPort.Click += new System.EventHandler(this.btnComPort_Click);
            // 
            // cboComPort
            // 
            this.cboComPort.FormattingEnabled = true;
            this.cboComPort.Location = new System.Drawing.Point(6, 19);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(121, 21);
            this.cboComPort.TabIndex = 5;
            this.cboComPort.Text = "Port";
            this.cboComPort.SelectedIndexChanged += new System.EventHandler(this.cboComPort_SelectedIndexChanged);
            // 
            // frmSettings
            // 
            this.AcceptButton = this.btnInterval;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 178);
            this.Controls.Add(this.grbPort);
            this.Controls.Add(this.grbLogging);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Innstillinger";
            this.grbLogging.ResumeLayout(false);
            this.grbLogging.PerformLayout();
            this.grbPort.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbLogging;
        private System.Windows.Forms.TextBox txtCustomInterval;
        private System.Windows.Forms.ComboBox cboPreset;
        private System.Windows.Forms.Button btnInterval;
        private System.Windows.Forms.RadioButton rbtMinutes;
        private System.Windows.Forms.RadioButton rbtHours;
        private System.Windows.Forms.GroupBox grbPort;
        private System.Windows.Forms.Button btnComPort;
        private System.Windows.Forms.ComboBox cboComPort;
    }
}