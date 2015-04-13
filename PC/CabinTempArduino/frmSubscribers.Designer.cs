namespace CabinTempArduino
{
    partial class frmSubscribers
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.cboSelectSubscriber = new System.Windows.Forms.ComboBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.txtSurName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtConfirmEmail = new System.Windows.Forms.TextBox();
            this.lblConfirmEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(9, 36);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(55, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(12, 52);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 2;
            // 
            // cboSelectSubscriber
            // 
            this.cboSelectSubscriber.FormattingEnabled = true;
            this.cboSelectSubscriber.Items.AddRange(new object[] {
            "New"});
            this.cboSelectSubscriber.Location = new System.Drawing.Point(12, 12);
            this.cboSelectSubscriber.Name = "cboSelectSubscriber";
            this.cboSelectSubscriber.Size = new System.Drawing.Size(206, 21);
            this.cboSelectSubscriber.TabIndex = 1;
            this.cboSelectSubscriber.Text = "Select subscriber";
            this.cboSelectSubscriber.SelectedIndexChanged += new System.EventHandler(this.cboSelectSubscriber_SelectedIndexChanged);
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(115, 36);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(56, 13);
            this.lblSurname.TabIndex = 3;
            this.lblSurname.Text = "Last name";
            // 
            // txtSurName
            // 
            this.txtSurName.Location = new System.Drawing.Point(118, 52);
            this.txtSurName.Name = "txtSurName";
            this.txtSurName.Size = new System.Drawing.Size(100, 20);
            this.txtSurName.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(206, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 114);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 211);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(206, 20);
            this.txtUsername.TabIndex = 7;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(9, 195);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Username";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 250);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(118, 250);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(100, 20);
            this.txtConfirmPassword.TabIndex = 9;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(9, 234);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Password";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(115, 234);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(90, 13);
            this.lblConfirmPassword.TabIndex = 12;
            this.lblConfirmPassword.Text = "Confirm password";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 276);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(206, 23);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 305);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(206, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtConfirmEmail
            // 
            this.txtConfirmEmail.Location = new System.Drawing.Point(12, 169);
            this.txtConfirmEmail.Name = "txtConfirmEmail";
            this.txtConfirmEmail.Size = new System.Drawing.Size(206, 20);
            this.txtConfirmEmail.TabIndex = 6;
            // 
            // lblConfirmEmail
            // 
            this.lblConfirmEmail.AutoSize = true;
            this.lblConfirmEmail.Location = new System.Drawing.Point(9, 153);
            this.lblConfirmEmail.Name = "lblConfirmEmail";
            this.lblConfirmEmail.Size = new System.Drawing.Size(70, 13);
            this.lblConfirmEmail.TabIndex = 16;
            this.lblConfirmEmail.Text = "Confirm Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(12, 91);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(206, 20);
            this.txtPhone.TabIndex = 4;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(9, 75);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(78, 13);
            this.lblPhone.TabIndex = 18;
            this.lblPhone.Text = "Phone Number";
            // 
            // frmSubscribers
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 341);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblConfirmEmail);
            this.Controls.Add(this.txtConfirmEmail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSurName);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.cboSelectSubscriber);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSubscribers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Subscribers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.ComboBox cboSelectSubscriber;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtSurName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtConfirmEmail;
        private System.Windows.Forms.Label lblConfirmEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
    }
}