﻿namespace CabinTempArduino
{
    partial class frmLimits
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
            this.cboLimitType = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnSetLimit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboLimitType
            // 
            this.cboLimitType.FormattingEnabled = true;
            this.cboLimitType.Items.AddRange(new object[] {
            "Høy alarm",
            "Stopp varmeovn",
            "Start varmeovn",
            "Lav alarm"});
            this.cboLimitType.Location = new System.Drawing.Point(12, 12);
            this.cboLimitType.Name = "cboLimitType";
            this.cboLimitType.Size = new System.Drawing.Size(109, 21);
            this.cboLimitType.TabIndex = 0;
            this.cboLimitType.Text = "Type grense";
            this.cboLimitType.SelectedIndexChanged += new System.EventHandler(this.cboLimitType_SelectedIndexChanged);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(127, 13);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(65, 20);
            this.txtValue.TabIndex = 1;
            this.txtValue.Text = "Verdi (C)";
            this.txtValue.Click += new System.EventHandler(this.txtValue_Click);
            // 
            // btnSetLimit
            // 
            this.btnSetLimit.Location = new System.Drawing.Point(12, 39);
            this.btnSetLimit.Name = "btnSetLimit";
            this.btnSetLimit.Size = new System.Drawing.Size(180, 23);
            this.btnSetLimit.TabIndex = 2;
            this.btnSetLimit.Text = "Sett grense";
            this.btnSetLimit.UseVisualStyleBackColor = true;
            this.btnSetLimit.Click += new System.EventHandler(this.btnSetLimit_Click);
            // 
            // frmLimits
            // 
            this.AcceptButton = this.btnSetLimit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 69);
            this.Controls.Add(this.btnSetLimit);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cboLimitType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmLimits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grenseverdier";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLimitType;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnSetLimit;
    }
}