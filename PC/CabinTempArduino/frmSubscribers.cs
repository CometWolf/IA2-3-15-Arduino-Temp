using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinTempArduino
{
    public partial class frmSubscribers : Form
    {
        #region Initial
        public frmSubscribers()
        {
            InitializeComponent();

            if (cboSelectSubscriber.Text == "Select subscriber")
            {
                TextBoxesReadOnlyTrue();
                btnDelete.Enabled = false; btnSubmit.Enabled = false;
            }

            subscribers = myDatabase.GetSubscribers();
            for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
            {
                cboSelectSubscriber.Items.Add(subscribers[i, 3]);
            }
        }
        #endregion
        #region Objects
        Database myDatabase = new Database("ArduinoTemperaturMåling.accdb");
        #endregion
        #region Variables
        string[,] subscribers;
        #endregion
        private void cboSelectSubscriber_SelectedIndexChanged(object sender, EventArgs e)
        {
            subscribers = myDatabase.GetSubscribers();
            if (cboSelectSubscriber.Text != "New")
                btnSubmit.Text = "Submit changes";

            if (cboSelectSubscriber.Text == "New")
            {
                TextBoxesReadOnlyFalse();

                btnDelete.Enabled = false; btnSubmit.Enabled = true;
                btnSubmit.Text = "Submit";

                ClearAllTextBoxes();
            }
            else if (cboSelectSubscriber.Text != "new" && cboSelectSubscriber.Text == myDatabase.SearchUsername(cboSelectSubscriber.Text))
            {
                TextBoxesReadOnlyFalse();
                btnDelete.Enabled = true; btnSubmit.Enabled = true;

                int index = myDatabase.getIndex(cboSelectSubscriber.Text);
                txtSurName.Text = subscribers[index, 1];
                txtFirstName.Text = subscribers[index, 2];
                txtUsername.Text = subscribers[index, 3];
                txtPassword.Text = subscribers[index, 4];
                txtConfirmPassword.Text = subscribers[index, 4];
                txtEmail.Text = subscribers[index, 5];
                txtConfirmEmail.Text = subscribers[index, 5];
                txtPhone.Text = subscribers[index, 6];
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cboSelectSubscriber.Text == "New")
            {
                bool email = matchingValues(txtEmail.Text,txtConfirmEmail.Text,"emails");
                bool password = matchingValues(txtPassword.Text, txtConfirmPassword.Text, "passwords");


                if ((txtFirstName.Text != "") && (txtSurName.Text != "") && (txtPhone.Text != "") && (txtUsername.Text != "") && password
                    && email && (txtEmail.Text != "") && (txtConfirmEmail.Text != "") && (txtPassword.Text != "") && (txtConfirmPassword.Text != "")
                    && (txtPassword.Text.Length >= 8) && (txtConfirmPassword.Text.Length >= 8))
                {
                    myDatabase.AddSubscriber(txtSurName.Text, txtFirstName.Text, txtUsername.Text, txtPassword.Text, txtEmail.Text, txtPhone.Text);
                    ClearAllTextBoxes();
                    MessageBox.Show("Subscriber successfully added.");

                    subscribers = myDatabase.GetSubscribers();
                    cboSelectSubscriber.Items.Clear();
                    cboSelectSubscriber.Items.Add("New");
                    for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
                    {
                        cboSelectSubscriber.Items.Add(subscribers[i, 3]);
                    }
                    cboSelectSubscriber.Text = "New";
                }
                else if ((txtPassword.Text.Length <= 7) || (txtConfirmPassword.Text.Length <= 7))
                {
                    MessageBox.Show("Password must be 8 characters or longer");
                }
                else
                    MessageBox.Show("Fill all textboxes.");
            }
            else if (cboSelectSubscriber.Text == myDatabase.SearchUsername(cboSelectSubscriber.Text))
            {
                int index = myDatabase.getIndex(cboSelectSubscriber.Text);
                //Legg til update av brukere her.
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(cboSelectSubscriber.Text == myDatabase.SearchUsername(cboSelectSubscriber.Text))
            {
                int index = myDatabase.getIndex(cboSelectSubscriber.Text);
                myDatabase.DeleteSubscriber(index);
            }

            subscribers = myDatabase.GetSubscribers();
            cboSelectSubscriber.Items.Clear();
            cboSelectSubscriber.Items.Add("New");
            for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
            {
                cboSelectSubscriber.Items.Add(subscribers[i, 3]);
            }
            

            ClearAllTextBoxes();
            cboSelectSubscriber.Text = "New";
            MessageBox.Show("User successfully deleted!");
        }
        #region Methods
        private void TextBoxesReadOnlyTrue()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                    ((TextBox)x).ReadOnly = true;
            }
        }
        private void TextBoxesReadOnlyFalse()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                    ((TextBox)x).ReadOnly = false;
            }
        }
        private void ClearAllTextBoxes()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                    ((TextBox)x).Clear();
            }
        }
        private bool matchingValues(string valueN1, string valueN2, string valueTypeTested)
        {
            bool matching = false;
            try
            {
                if (valueN1 == valueN2)
                    matching = true;
                else
                    throw new Exception("The " + valueTypeTested + " are not matching");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return matching;
        }
        #endregion
    }
}
