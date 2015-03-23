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
using System.Runtime.InteropServices;

namespace CabinTempArduino
{
    public partial class frmMain : Form
    {
        
        //Disable Visual Styles
        [DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public extern static Int32 SetWindowTheme(IntPtr hWnd,
                      String textSubAppName, String textSubIdList);

        //Source: http://stackoverflow.com/questions/3893622/windows-98-style-progress-bar 

        //END Disable Visual Styles
        public frmMain()
        {
            InitializeComponent();
            SetWindowTheme(prbBatteryStatus.Handle, "", ""); //Disable Visual Styles ProgressBar
            
            //ToolTips
            totGraph.SetToolTip(chartFetchedValues, "Click to enlarge");
            //END ToolTips
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
        E_post mail = new E_post();
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

        private void tmrBatteryStatus_Tick(object sender, EventArgs e)
        {
            prbBatteryStatus.Value = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent*100);
            lblStatus.Text = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();

            if (prbBatteryStatus.Value <= 50)
                prbBatteryStatus.ForeColor = Color.Yellow;

            if(SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "0")
            {
                lblStatus.Text = "Normal";
            }
            else if(SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "Low")
            {
                prbBatteryStatus.ForeColor = Color.Red;

                //Legg inn Email sending
            }
            else if (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "Critical")
            {
                bool blink = false;

                if (blink == false)
                {
                    prbBatteryStatus.ForeColor = Color.White;
                    blink = true;
                }
                else if (blink)
                {
                    prbBatteryStatus.ForeColor = Color.Red;
                    blink = false;
                }
                //Legg inn Email sending.
            }
        }
    }
}
