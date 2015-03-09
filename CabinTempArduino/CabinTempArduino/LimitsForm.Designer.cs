namespace CabinTempArduino
{
    partial class LimitsForm
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cboLimitType = new System.Windows.Forms.ComboBox();
            this.btnSetLimit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(115, 12);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(60, 20);
            this.txtValue.TabIndex = 0;
            // 
            // cboLimitType
            // 
            this.cboLimitType.FormattingEnabled = true;
            this.cboLimitType.Items.AddRange(new object[] {
            "High alarm",
            "Upper limit",
            "Lower limit",
            "Low alarm"});
            this.cboLimitType.Location = new System.Drawing.Point(12, 11);
            this.cboLimitType.Name = "cboLimitType";
            this.cboLimitType.Size = new System.Drawing.Size(97, 21);
            this.cboLimitType.TabIndex = 1;
            this.cboLimitType.Text = "Limit type";
            // 
            // btnSetLimit
            // 
            this.btnSetLimit.Location = new System.Drawing.Point(12, 38);
            this.btnSetLimit.Name = "btnSetLimit";
            this.btnSetLimit.Size = new System.Drawing.Size(163, 23);
            this.btnSetLimit.TabIndex = 2;
            this.btnSetLimit.Text = "Set limit";
            this.btnSetLimit.UseVisualStyleBackColor = true;
            // 
            // LimitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 72);
            this.Controls.Add(this.btnSetLimit);
            this.Controls.Add(this.cboLimitType);
            this.Controls.Add(this.txtValue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LimitsForm";
            this.Text = "Limits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.ComboBox cboLimitType;
        private System.Windows.Forms.Button btnSetLimit;

    }
}