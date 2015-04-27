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
    /*
        Wrtitten by: Martin Terjesen
        Adds, edits and deletes subscribers.
    */
    public partial class frmSubscribers : Form
    {
        #region Initial
        public frmSubscribers()
        {
            InitializeComponent();

            if (cboSelectSubscriber.Text == "Velg bruker")
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
            //Changes GUI depending on the value of cboSelectSubscriber
            subscribers = myDatabase.GetSubscribers();
            if (cboSelectSubscriber.Text != "Ny bruker")
                btnSubmit.Text = "Lagre endringer";

            if (cboSelectSubscriber.Text == "Ny bruker")
            {
                TextBoxesReadOnlyFalse();

                btnDelete.Enabled = false; btnSubmit.Enabled = true;
                btnSubmit.Text = "Lagre";

                ClearAllTextBoxes();
            }
            else if (cboSelectSubscriber.Text != "Ny bruker" && myDatabase.SearchUsername(cboSelectSubscriber.Text))
            {
                TextBoxesReadOnlyFalse();
                btnDelete.Enabled = true; btnSubmit.Enabled = true;

                int index = myDatabase.GetIndex(cboSelectSubscriber.Text);
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
            //Submits or changes a user in the database.
            bool username = false;
            bool lengthPassword = false;
            bool uniqueEmail = false;
            bool email = MatchingValues(txtEmail.Text, txtConfirmEmail.Text, "E-Post"); //Checks if the emails are matching
            bool password = MatchingValues(txtPassword.Text, txtConfirmPassword.Text, "Passord"); //Checks if the password are matching
            if (password)
            {
                lengthPassword = PasswordLength(txtPassword.Text, txtConfirmPassword.Text);
            }
            try
            {
                if (cboSelectSubscriber.Text == "Ny bruker")
                {
                    username = Unique(txtUsername.Text,3,"Brukernavn"); //Checks the uniqueness of Username and email.
                    uniqueEmail = Unique(txtEmail.Text, 5, "E-Post");

                    if ((txtFirstName.Text != "") && (txtSurName.Text != "") && (txtPhone.Text != "") && (txtUsername.Text != "") && password
                        && email && username && (txtEmail.Text != "") && (txtConfirmEmail.Text != "") && (txtPassword.Text != "") && (txtConfirmPassword.Text != "")
                        && lengthPassword)
                    {
                        myDatabase.AddSubscriber(txtSurName.Text, txtFirstName.Text, txtUsername.Text, txtPassword.Text, txtEmail.Text, txtPhone.Text);
                        ClearAllTextBoxes();
                        MessageBox.Show("Ny bruker lagret");

                        FillCboWithUsers();
                        cboSelectSubscriber.Text = "Ny bruker";
                    }
                    else if ((txtFirstName.Text == "") || (txtSurName.Text == "") || (txtPhone.Text == "") || (txtUsername.Text == "") ||
                        (txtEmail.Text == "") || (txtConfirmEmail.Text == "") || (txtPassword.Text == "") || (txtConfirmPassword.Text == ""))
                        MessageBox.Show("Fyll i alle tekstbokser");
                }
                else if (myDatabase.SearchUsername(cboSelectSubscriber.Text))
                {
                    int userID = myDatabase.GetUserID(cboSelectSubscriber.Text);
                    int index = myDatabase.GetIndex(cboSelectSubscriber.Text);

                    if (txtUsername.Text != subscribers[index, 3]) //Checks if the same username is being used.
                        username = Unique(txtUsername.Text,3,"Brukernavn"); //If not a unique test is perfomed.
                    if(txtEmail.Text != subscribers[index,5]) //The same happens with email.
                        uniqueEmail = Unique(txtEmail.Text, 5, "E-Post");

                    if ((txtFirstName.Text != "") && (txtSurName.Text != "") && (txtPhone.Text != "") && (txtUsername.Text != "") && password
                    && email && (txtEmail.Text != "") && (txtConfirmEmail.Text != "") && (txtPassword.Text != "") && (txtConfirmPassword.Text != "")
                    && lengthPassword && (txtUsername.Text == subscribers[index, 3] || username))
                    {
                        myDatabase.UpdateSubscriber(userID, txtSurName.Text, txtFirstName.Text, txtUsername.Text, txtPassword.Text, txtEmail.Text, txtPhone.Text);
                        MessageBox.Show("Endringer lagret");

                        FillCboWithUsers();
                        cboSelectSubscriber.Text = txtUsername.Text;
                    }
                    else if ((txtFirstName.Text == "") || (txtSurName.Text == "") || (txtPhone.Text == "") || (txtUsername.Text == "") ||
                        (txtEmail.Text == "") || (txtConfirmEmail.Text == "") || (txtPassword.Text == "") || (txtConfirmPassword.Text == ""))
                        MessageBox.Show("Fyll i alle tekstbokser");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Deletes the user from the database.
            try
            {
                if (myDatabase.SearchUsername(cboSelectSubscriber.Text))
                {
                    int index = myDatabase.GetIndex(cboSelectSubscriber.Text);
                    myDatabase.DeleteSubscriber(index);
                }

                FillCboWithUsers();

                ClearAllTextBoxes();
                cboSelectSubscriber.Text = "Ny bruker";
                MessageBox.Show("Bruker slettet");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region Methods
        private void TextBoxesReadOnlyTrue()
        {
            //Makes all textboxes ReadOnly.
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                    ((TextBox)x).ReadOnly = true;
            }
        }
        private void TextBoxesReadOnlyFalse()
        {
            //Makes all textboxes not ReadOnly.
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                    ((TextBox)x).ReadOnly = false;
            }
        }
        private void ClearAllTextBoxes()
        {
            //Clears all textboxes.
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                    ((TextBox)x).Clear();
            }
        }
        private bool MatchingValues(string valueN1, string valueN2, string valueTypeTested)
        {
            //Checks if two values are matching. (Password and email)
            bool matching = false;
            try
            {
                if (valueN1 == valueN2)
                    matching = true;
                else
                    throw new Exception(valueTypeTested + " er ulik");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return matching;
        }

        private bool PasswordLength(string password, string confirmPassword)
        {
            //Checks if the password equal to or longer than 8 characters.
            bool length = false;
            try
            {
                if (password.Length >7 && confirmPassword.Length >7)
                    length = true;
                else
                    throw new Exception("Passordet må være 8 tegn eller større");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return length;
        }
        private bool Unique(string value, int col, string valueType)
        {
            //Checks if the value is not already in the database. (Username and email)
            bool isUnique = false; 
            try
            {
                for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
                {
                    if (value != subscribers[i, col])
                        isUnique = true;
                    else
                        isUnique = false;
                }
                if (!isUnique)
                    throw new Exception(valueType +" er i bruk");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return isUnique;
        }
        private void FillCboWithUsers()
        {
            //Fills cboSelectSubsribers with updated usernames.
            subscribers = myDatabase.GetSubscribers();
            cboSelectSubscriber.Items.Clear();
            cboSelectSubscriber.Items.Add("Ny bruker");
            for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
            {
                cboSelectSubscriber.Items.Add(subscribers[i, 3]);
            }
        }
        #endregion
    }
}
