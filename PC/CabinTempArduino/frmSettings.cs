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
        public frmSettings()
        {
            InitializeComponent();
            //GUI
            txtCustomInterval.Enabled = false;
            rbtHours.Enabled = false;
            rbtMinutes.Enabled = false;
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
            }
            else
            {
                txtCustomInterval.Enabled = true;
                rbtHours.Enabled = true;
                rbtMinutes.Enabled = true;
            }
            //END GUI

            if(cboPreset.Text == "60 minutes")
            {
                settings.UpdateSetting("60", "Oppdateringsinterval", 0);
            }
            else if (cboPreset.Text == "30 minutes")
            {
                settings.UpdateSetting("30", "Oppdateringsinterval", 0);
            }
            else if (cboPreset.Text == "15 minutes")
            {
                settings.UpdateSetting("15", "Oppdateringsinterval", 0);
            }
            else if(cboPreset.Text == "Custom")
            {
                if (rbtHours.Checked)
                {
                    int value = 0;
                    int.TryParse(txtCustomInterval.Text,out value);
                    settings.UpdateSetting(Convert.ToString(value * 60), "Oppdateringsinterval", 0);
                }
                else if (rbtMinutes.Checked)
                    settings.UpdateSetting(txtCustomInterval.Text, "Oppdateringsinterval", 0);
            }

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
            if(cboComPort.Text != "Ports")
            {
                frmMain main = new frmMain();
                main.ComPort = cboComPort.Text;
            }
        }
    }
}
