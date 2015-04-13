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
        public frmSettings()
        {
            InitializeComponent();
            //GUI
            txtCustomInterval.Enabled = false;
            rbtSeconds.Enabled = false;
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
                rbtSeconds.Enabled = false;
                rbtMinutes.Enabled = false;
                btnInterval.Enabled = true;
            }
            else
            {
                txtCustomInterval.Enabled = true;
                rbtSeconds.Enabled = true;
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
            if(cboComPort.Text != "Ports")
            {
                frmMain main = new frmMain();
                main.ComPort = cboComPort.Text;
            }
        }

        private void cboComPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboComPort.Text == "Ports")
                btnComPort.Enabled = false;
            else
            btnComPort.Enabled = true;
        }
    }
}
