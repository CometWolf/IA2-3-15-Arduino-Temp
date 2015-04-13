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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInterval = new System.Windows.Forms.Button();
            this.rbtMinutes = new System.Windows.Forms.RadioButton();
            this.rbtHours = new System.Windows.Forms.RadioButton();
            this.txtCustomInterval = new System.Windows.Forms.TextBox();
            this.cboPreset = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnComPort = new System.Windows.Forms.Button();
            this.cboComPort = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInterval);
            this.groupBox1.Controls.Add(this.rbtMinutes);
            this.groupBox1.Controls.Add(this.rbtHours);
            this.groupBox1.Controls.Add(this.txtCustomInterval);
            this.groupBox1.Controls.Add(this.cboPreset);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log interval";
            // 
            // btnInterval
            // 
            this.btnInterval.Location = new System.Drawing.Point(6, 46);
            this.btnInterval.Name = "btnInterval";
            this.btnInterval.Size = new System.Drawing.Size(121, 40);
            this.btnInterval.TabIndex = 3;
            this.btnInterval.Text = "Set interval";
            this.btnInterval.UseVisualStyleBackColor = true;
            this.btnInterval.Click += new System.EventHandler(this.btnInterval_Click);
            // 
            // rbtMinutes
            // 
            this.rbtMinutes.AutoSize = true;
            this.rbtMinutes.Location = new System.Drawing.Point(133, 69);
            this.rbtMinutes.Name = "rbtMinutes";
            this.rbtMinutes.Size = new System.Drawing.Size(62, 17);
            this.rbtMinutes.TabIndex = 1;
            this.rbtMinutes.TabStop = true;
            this.rbtMinutes.Text = "Minutes";
            this.rbtMinutes.UseVisualStyleBackColor = true;
            // 
            // rbtHours
            // 
            this.rbtHours.AutoSize = true;
            this.rbtHours.Location = new System.Drawing.Point(133, 46);
            this.rbtHours.Name = "rbtHours";
            this.rbtHours.Size = new System.Drawing.Size(53, 17);
            this.rbtHours.TabIndex = 2;
            this.rbtHours.TabStop = true;
            this.rbtHours.Text = "Hours";
            this.rbtHours.UseVisualStyleBackColor = true;
            // 
            // txtCustomInterval
            // 
            this.txtCustomInterval.Location = new System.Drawing.Point(133, 19);
            this.txtCustomInterval.Name = "txtCustomInterval";
            this.txtCustomInterval.Size = new System.Drawing.Size(81, 20);
            this.txtCustomInterval.TabIndex = 1;
            this.txtCustomInterval.Text = "Custom interval";
            this.txtCustomInterval.Click += new System.EventHandler(this.txtCustomInterval_Click);
            // 
            // cboPreset
            // 
            this.cboPreset.FormattingEnabled = true;
            this.cboPreset.Items.AddRange(new object[] {
            "60 minutes",
            "30 minutes",
            "15 minutes",
            "Custom"});
            this.cboPreset.Location = new System.Drawing.Point(6, 19);
            this.cboPreset.Name = "cboPreset";
            this.cboPreset.Size = new System.Drawing.Size(121, 21);
            this.cboPreset.TabIndex = 0;
            this.cboPreset.Text = "Preset";
            this.cboPreset.SelectedIndexChanged += new System.EventHandler(this.cboPreset_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnComPort);
            this.groupBox2.Controls.Add(this.cboComPort);
            this.groupBox2.Location = new System.Drawing.Point(12, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(223, 54);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "COM Port";
            // 
            // btnComPort
            // 
            this.btnComPort.Location = new System.Drawing.Point(133, 19);
            this.btnComPort.Name = "btnComPort";
            this.btnComPort.Size = new System.Drawing.Size(81, 23);
            this.btnComPort.TabIndex = 1;
            this.btnComPort.Text = "Set COM Port";
            this.btnComPort.UseVisualStyleBackColor = true;
            this.btnComPort.Click += new System.EventHandler(this.btnComPort_Click);
            // 
            // cboComPort
            // 
            this.cboComPort.FormattingEnabled = true;
            this.cboComPort.Location = new System.Drawing.Point(6, 19);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(121, 21);
            this.cboComPort.TabIndex = 0;
            this.cboComPort.Text = "Ports";
            this.cboComPort.SelectedIndexChanged += new System.EventHandler(this.cboComPort_SelectedIndexChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 178);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomInterval;
        private System.Windows.Forms.ComboBox cboPreset;
        private System.Windows.Forms.Button btnInterval;
        private System.Windows.Forms.RadioButton rbtMinutes;
        private System.Windows.Forms.RadioButton rbtHours;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnComPort;
        private System.Windows.Forms.ComboBox cboComPort;
    }
}