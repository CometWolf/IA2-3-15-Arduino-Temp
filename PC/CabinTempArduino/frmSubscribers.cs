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
                txtFirstName.ReadOnly = true; txtSurName.ReadOnly = true; txtEmail.ReadOnly = true; txtConfirmEmail.ReadOnly = true;
                txtPhone.ReadOnly = true; txtPassword.ReadOnly = true; txtConfirmPassword.ReadOnly = true; txtUsername.ReadOnly = true;
                btnDelete.Enabled = false; btnSubmit.Enabled = false;
            }

            subscribers = myDatabase.GetSubscribers();
            //END GUI
            for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
            {
                cboSelectSubscriber.Items.Add(subscribers[i, 2] + subscribers[i, 1]);
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
            // GUI
            if (cboSelectSubscriber.Text != "New")
                btnSubmit.Text = "Submit changes";

            if (cboSelectSubscriber.Text == "New")
            {
                txtFirstName.ReadOnly = false; txtSurName.ReadOnly = false; txtEmail.ReadOnly = false; txtConfirmEmail.ReadOnly = false;
                txtPhone.ReadOnly = false; txtPassword.ReadOnly = false; txtConfirmPassword.ReadOnly = false; txtUsername.ReadOnly = false;
                btnDelete.Enabled = false; btnSubmit.Enabled = true;
                btnSubmit.Text = "Submit";
            }
            else
            {
                txtFirstName.ReadOnly = false; txtSurName.ReadOnly = false; txtEmail.ReadOnly = false; txtConfirmEmail.ReadOnly = false;
                txtPhone.ReadOnly = false; txtPassword.ReadOnly = false; txtConfirmPassword.ReadOnly = false; txtUsername.ReadOnly = false;
                btnDelete.Enabled = true; btnSubmit.Enabled = true;
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
                    txtFirstName.Clear(); txtSurName.Clear(); txtEmail.Clear(); txtConfirmEmail.Clear();
                    txtPhone.Clear(); txtPassword.Clear(); txtConfirmPassword.Clear(); txtUsername.Clear();
                    MessageBox.Show("Subscriber successfully added.");

                    subscribers = myDatabase.GetSubscribers();
                    cboSelectSubscriber.Items.Clear();
                    for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
                    {
                        cboSelectSubscriber.Items.Add(subscribers[i, 2] + subscribers[i, 1]);
                    }
                }
                else
                    MessageBox.Show("Fill all textboxes.");
            }
        }
    }
}
