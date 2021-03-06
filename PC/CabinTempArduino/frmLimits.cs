﻿/*
    Limits form

    Wrtitten by: Martin Terjesen  
    Change the limits of the Arduino.
*/
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
            //GUI
            InitializeComponent();
            txtValue.ReadOnly = true;
            btnSetLimit.Enabled = false;
            //END GUI
        }

        private void txtValue_Click(object sender, EventArgs e)
        {
            //GUI
            if (txtValue.Text == "Verdi (C)")
                txtValue.Text = "";
            //END GUI
        }
        private void btnSetLimit_Click(object sender, EventArgs e)
        {
            //Updates limits
            double value = 0;
            if (double.TryParse(txtValue.Text, out value))
            {
                try
                {
                    switch (cboLimitType.SelectedIndex)
                    {
                        case 2:
                            myDatabase.UpdateSetting(txtValue.Text, 3, 0);
                            break;
                        case 1:
                            myDatabase.UpdateSetting(txtValue.Text, 2, 0);
                            break;
                        case 0:
                            myDatabase.UpdateSetting(txtValue.Text, 1, 0);
                            break;
                        case 3:
                            myDatabase.UpdateSetting(txtValue.Text, 4, 0);
                            break;
                    }
                    MessageBox.Show("Grense satt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else MessageBox.Show("Verdi må være et tall");
        }
        private void cboLimitType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Shows limits in textboxes when changing cboLimitType.
            txtValue.ReadOnly = false;
            btnSetLimit.Enabled = true;
            settings = myDatabase.GetSettings(0);

            try
            {
                switch (cboLimitType.SelectedIndex)
                {
                    case 2:
                        txtValue.Text = settings[3];
                        break;
                    case 1:
                        txtValue.Text = settings[2];
                        break;
                    case 0:
                        txtValue.Text = settings[1];
                        break;
                    case 3:
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
