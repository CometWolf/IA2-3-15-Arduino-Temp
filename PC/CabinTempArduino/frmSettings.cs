using System;
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
                string[] usedValue = settings.GetSettings(0);

                if (cboPreset.Text == "60 minutes")
                {
                    if (usedValue[5] == "60")
                        MessageBox.Show("Interval already in use.");
                    else
                    {
                        setNewInterval("60", "false");
                    }

                }
                else if (cboPreset.Text == "30 minutes")
                {
                    if (usedValue[5] == "30")
                        MessageBox.Show("Interval already in use.");
                    else
                    {
                        setNewInterval("30", "false");
                    }
                }
                else if (cboPreset.Text == "15 minutes")
                {
                    if (usedValue[5] == "15")
                        MessageBox.Show("Interval already in use.");
                    else
                    {
                        setNewInterval("15", "false");
                    }
                }
                else if (cboPreset.Text == "Custom")
                {
                    int value = 0;
                    if (rbtHours.Checked || rbtMinutes.Checked)
                    {
                        if (!int.TryParse(txtCustomInterval.Text, out value) || txtCustomInterval.Text == "0")
                        {
                            MessageBox.Show("Do not use decimal numbers, text or zero.");
                        }
                        else
                        {
                            if (rbtHours.Checked)
                            {
                                if (value > 24)
                                    MessageBox.Show("Do not go above 24 hours.");
                                else if (Convert.ToString(value * 60) == usedValue[5])
                                    MessageBox.Show("Interval already in use.");
                                else
                                {
                                    setNewInterval(Convert.ToString(value*60), "true");
                                }
                            }
                            else if (rbtMinutes.Checked)
                            {
                                if (value > 1440)
                                    MessageBox.Show("Do not go above 24 hours.");
                                else if (Convert.ToString(value) == usedValue[5])
                                    MessageBox.Show("Interval already in use.");
                                else
                                {
                                    setNewInterval(Convert.ToString(value), "true");
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
        private void setNewInterval(string newInterval, string custom)
        {
            settings.UpdateSetting(newInterval, 5, 0);
            settings.UpdateSetting(custom, 7, 0);
            main.newInterval();
            MessageBox.Show("Interval successfully changed.");
        }
    }
}
