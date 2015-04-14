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
    public partial class frmLimits : Form
    {
        #region Objects
        Database myDatabase = new Database("ArduinoTemperaturMåling.accdb");
        #endregion

        #region Variables
        string[] settings;
        #endregion

        public frmLimits()
        {
            InitializeComponent();
            txtValue.ReadOnly = true;
            btnSetLimit.Enabled = false;
        }

        private void txtValue_Click(object sender, EventArgs e)
        {
            //GUI
            if (txtValue.Text == "Value (C)")
                txtValue.Text = "";
            //END GUI
        }

        private void btnSetLimit_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cboLimitType.Text)
                {
                    case "Lower limit":
                        myDatabase.UpdateSetting(txtValue.Text, 3, 0);
                        break;
                    case "Upper limit":
                        myDatabase.UpdateSetting(txtValue.Text, 2, 0);
                        break;
                    case "High alarm":
                        myDatabase.UpdateSetting(txtValue.Text, 1, 0);
                        break;
                    case "Low alarm":
                        myDatabase.UpdateSetting(txtValue.Text, 4, 0);
                        break;
                }
                MessageBox.Show("Limit successfully changed.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboLimitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.ReadOnly = false;
            btnSetLimit.Enabled = true;
            settings = myDatabase.GetSettings(0);

            try
            {
                switch (cboLimitType.Text)
                {
                    case "Lower limit":
                        txtValue.Text = settings[3];
                        break;
                    case "Upper limit":
                        txtValue.Text = settings[2];
                        break;
                    case "High alarm":
                        txtValue.Text = settings[1];
                        break;
                    case "Low alarm":
                        txtValue.Text = settings[4];
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
