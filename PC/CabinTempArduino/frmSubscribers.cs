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
        public frmSubscribers()
        {
            InitializeComponent();

            //GUI
            if (cboSelectSubscriber.Text == "Select subscriber")
            {
                TextBoxesReadOnlyTrue();
                btnDelete.Enabled = false; btnSubmit.Enabled = false;
            }

            subscribers = myDatabase.GetSubscribers();
            //END GUI
            for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
            {
                cboSelectSubscriber.Items.Add(subscribers[i, 3]);
            }
        }

        //Objects
        Database myDatabase = new Database("ArduinoTemperaturMåling.accdb");
        //END Objects

        //Variables
        string[,] subscribers;
        //END Variables
        private void cboSelectSubscriber_SelectedIndexChanged(object sender, EventArgs e)
        {
            subscribers = myDatabase.GetSubscribers();
            // GUI
            if (cboSelectSubscriber.Text != "New")
                btnSubmit.Text = "Submit changes";

            if (cboSelectSubscriber.Text == "New")
            {
                TextBoxesReadOnlyFalse();

                btnDelete.Enabled = false; btnSubmit.Enabled = true;
                btnSubmit.Text = "Submit";

                ClearAllTextBoxes();
            }
            else if (cboSelectSubscriber.Text != "new" && cboSelectSubscriber.Text == myDatabase.searchUsername(cboSelectSubscriber.Text, subscribers))
            {
                TextBoxesReadOnlyFalse();
                btnDelete.Enabled = true; btnSubmit.Enabled = true;

                int index = myDatabase.getIndex(cboSelectSubscriber.Text, subscribers);
                txtSurName.Text = subscribers[index, 1];
                txtFirstName.Text = subscribers[index, 2];
                txtUsername.Text = subscribers[index, 3];
                txtEmail.Text = subscribers[index, 5];
                txtConfirmEmail.Text = subscribers[index, 5];
                txtPhone.Text = subscribers[index, 6];
            }
            //END GUI


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = "";
            string password = "";

            if (cboSelectSubscriber.Text == "New")
            {
                if (txtEmail.Text == txtConfirmEmail.Text)
                    email = txtEmail.Text;
                else
                    MessageBox.Show("Email is not matching.");

                if (txtPassword.Text == txtConfirmPassword.Text && txtPassword.TextLength >= 8)
                {
                    password = txtPassword.Text;
                }
                else
                    MessageBox.Show("Password must be 8 character or longer.");

                if (password == txtPassword.Text && email == txtEmail.Text && txtFirstName.Text != "" && txtSurName.Text != ""
                    && txtPhone.Text != "" && txtUsername.Text != "")
                {
                    myDatabase.AddSubscriber(txtSurName.Text, txtFirstName.Text, txtUsername.Text, password, txtEmail.Text, txtPhone.Text);
                    ClearAllTextBoxes();
                    MessageBox.Show("Subscriber successfully added.");
                }
                else
                    MessageBox.Show("Fill all textboxes.");
            }
            else if (cboSelectSubscriber.Text == myDatabase.searchUsername(cboSelectSubscriber.Text,subscribers))
            {
                int index = myDatabase.getIndex(cboSelectSubscriber.Text, subscribers);
                //Legg til update av brukere her.
            }

            subscribers = myDatabase.GetSubscribers();
            cboSelectSubscriber.Items.Clear();
            cboSelectSubscriber.Items.Add("New");
            for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
            {
                cboSelectSubscriber.Items.Add(subscribers[i, 3]);
            }
            cboSelectSubscriber.Text = "New";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(cboSelectSubscriber.Text == myDatabase.searchUsername(cboSelectSubscriber.Text,subscribers))
            {
                int index = myDatabase.getIndex(cboSelectSubscriber.Text, subscribers);
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
    }
}
