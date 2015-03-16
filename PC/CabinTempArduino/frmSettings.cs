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
            //END GUI

            frmMain main = new frmMain();

            string[] serialPortNames = SerialPort.GetPortNames();
            foreach (string Port in serialPortNames)
            {
                cboComPort.Items.Add(Port);
            }
        }

        private void cboPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GUI
            if (cboPreset.Text != "Custom")
            { 
                txtCustomInterval.Enabled = false;
                rbtSeconds.Enabled = false;
                rbtMinutes.Enabled = false;
            }
            else
            {
                txtCustomInterval.Enabled = true;
                rbtSeconds.Enabled = true;
                rbtMinutes.Enabled = true;
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
    }
}
