namespace CabinTempArduino
{
    partial class SettingsForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.rbtMinutes = new System.Windows.Forms.RadioButton();
            this.rbtSeconds = new System.Windows.Forms.RadioButton();
            this.txtCustomInterval = new System.Windows.Forms.TextBox();
            this.cboPreset = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rbtMinutes);
            this.groupBox1.Controls.Add(this.rbtSeconds);
            this.groupBox1.Controls.Add(this.txtCustomInterval);
            this.groupBox1.Controls.Add(this.cboPreset);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log interval";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Set interval";
            this.button1.UseVisualStyleBackColor = true;
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
            // rbtSeconds
            // 
            this.rbtSeconds.AutoSize = true;
            this.rbtSeconds.Location = new System.Drawing.Point(133, 46);
            this.rbtSeconds.Name = "rbtSeconds";
            this.rbtSeconds.Size = new System.Drawing.Size(67, 17);
            this.rbtSeconds.TabIndex = 2;
            this.rbtSeconds.TabStop = true;
            this.rbtSeconds.Text = "Seconds";
            this.rbtSeconds.UseVisualStyleBackColor = true;
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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 122);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomInterval;
        private System.Windows.Forms.ComboBox cboPreset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbtMinutes;
        private System.Windows.Forms.RadioButton rbtSeconds;
    }
}