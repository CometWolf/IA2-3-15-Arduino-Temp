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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //GUI
            totGraph.SetToolTip(chartFetchedValues, "Click to enlarge");
            //END GUI
        }

        //PROPERTIES
        public string ComPort
        {
            get { return spComPort.PortName; }
            set { spComPort.PortName = value; }
        }
        //END PROPERTIES

        //OBJECTS
        Database myDatabase = new Database("ArduinoTemperaturMåling.accdb");
        //END OBJECTS

        private void btnLimits_Click(object sender, EventArgs e)
        {
            //GUI
            frmLimits limitForm = new frmLimits();
            limitForm.ShowDialog();
            //END GUI
        }

        private void btnSubscribers_Click(object sender, EventArgs e)
        {
            //GUI
            frmSubscribers subscribersForm = new frmSubscribers();
            subscribersForm.ShowDialog();
            //END GUI
        }

        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            //GUI
            frmSettings settingsForm = new frmSettings();
            settingsForm.ShowDialog();
            //END GUI
        }

        private void chartFetchedValues_Click(object sender, EventArgs e)
        {
            //GUI
            frmChart chart = new frmChart();
            chart.Show();
            //END GUI
        }
        Random rand = new Random();
        private void btnFetch_Click(object sender, EventArgs e)
        {
            rtbDatabaseValues.Clear();

            for (int i = 0; i < 10; i++)
            {
                
            myDatabase.LogTemperature(DateTime.Now.Date.ToString(), DateTime.Now.TimeOfDay.ToString(), rand.Next(-100, 100).ToString());
            }
            string[,] alarms = myDatabase.GetTemperature();

            foreach (string x in alarms)
            {
                rtbDatabaseValues.AppendText(x + "\r\n");
            }
        }

        private void tmrBattery_Tick(object sender, EventArgs e)
        {
            prbBatteryStatus.Value = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent);
            lblStatus.Text = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();

            //Endre farge avhengig av prosent.

            if(SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "Low")
            {
                //Legg inn Email sending.
            }
            else if (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "Low, Critical")
            {
                //Legg inn Email sending.
            }
        }
    }
}
