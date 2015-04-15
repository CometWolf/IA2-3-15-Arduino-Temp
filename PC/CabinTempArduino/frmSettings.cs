﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace CabinTempArduino
{
    public partial class frmSettings : Form
    {
        Database settings = new Database("ArduinoTemperaturMåling.accdb");
        frmMain main = new frmMain();
        public frmSettings()
        {
            InitializeComponent();
            //GUI
            txtCustomInterval.Enabled = false;
            rbtHours.Enabled = false;
            rbtMinutes.Enabled = false;
            btnInterval.Enabled = false;
            btnComPort.Enabled = false;
            //END GUI

            //Valid ports
            string[] serialPortNames = SerialPort.GetPortNames();
            foreach (string port in serialPortNames)
            {
                cboComPort.Items.Add(port);
            }
            //END Valid ports

            
        }

        private void cboPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GUI
            if (cboPreset.Text != "Custom")
            { 
                txtCustomInterval.Enabled = false;
                rbtHours.Enabled = false;
                rbtMinutes.Enabled = false;
                btnInterval.Enabled = true;
            }
            else
            {
                txtCustomInterval.Enabled = true;
                rbtHours.Enabled = true;
                rbtMinutes.Enabled = true;
                btnInterval.Enabled = true;
            }
            //END GUI
        }

        private void txtCustomInterval_Click(object sender, EventArgs e)
        {
            //GUI
            if (txtCustomInterval.Text == "Custom interval")
                txtCustomInterval.Text = "";
            //END GUI
        }

        private void btnComPort_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboComPort.Text != "Ports")
                {
                    main.ComPort = cboComPort.Text;
                    settings.UpdateSetting(cboComPort.Text, 6, 0);
                    MessageBox.Show("Port successfully changed");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboComPort.Text == "Ports")
                btnComPort.Enabled = false;
            else
            btnComPort.Enabled = true;
        }

        private void btnInterval_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboPreset.Text == "60 minutes")
                {
                    settings.UpdateSetting("60", 5, 0);
                    MessageBox.Show("Interval successfully changes.");
                    main.Custom = false;
                }
                else if (cboPreset.Text == "30 minutes")
                {
                    settings.UpdateSetting("30", 5, 0);
                    MessageBox.Show("Interval successfully changes.");
                    main.Custom = false;
                }
                else if (cboPreset.Text == "15 minutes")
                {
                    settings.UpdateSetting("15", 5, 0);
                    MessageBox.Show("Interval successfully changes.");
                    main.Custom = false;
                }
                else if (cboPreset.Text == "Custom")
                {
                    int value = 0;
                    if (rbtHours.Checked || rbtMinutes.Checked)
                    {
                        if (!int.TryParse(txtCustomInterval.Text, out value) || txtCustomInterval.Text == "0")
                        {
                            MessageBox.Show("Do not use decimal numbers or zero.");
                        }
                        else
                        {
                            if (rbtHours.Checked)
                            {
                                if (value > 24)
                                    MessageBox.Show("Do not go above 24 hours.");
                                else
                                {
                                    settings.UpdateSetting(Convert.ToString(value * 60), 5, 0);
                                    MessageBox.Show("Interval successfully set changes.");
                                }
                            }
                            else if (rbtMinutes.Checked)
                            {
                                if (value > 1440)
                                    MessageBox.Show("Do not go above 24 hours.");
                                else
                                {
                                    settings.UpdateSetting(txtCustomInterval.Text, 5, 0);
                                    MessageBox.Show("Interval successfully set changes.");
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Check off 'Hours' og 'Minutes'.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
