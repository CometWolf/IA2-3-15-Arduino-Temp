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
        bool criticalCharge = true;
        bool fiftyCharge = true;
        bool charging = true;

        #region Disable Visual Styles
        [DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public extern static Int32 SetWindowTheme(IntPtr hWnd,
                      String textSubAppName, String textSubIdList);

        //Source: http://stackoverflow.com/questions/3893622/windows-98-style-progress-bar 
        #endregion
        #region Initial
        public frmMain()
        {
            InitializeComponent();
            SetWindowTheme(prbBatteryStatus.Handle, "", ""); //Disable Visual Styles ProgressBar
            
            //ToolTips
            totGraph.SetToolTip(chartFetchedValues, "Click to enlarge");
            //END ToolTips

            //GUI
            if (cboAnnotation.Text == "Annotation")
            {
                btnFetch.Enabled = false;
                chbError.Enabled = false;
                chbTemperature.Enabled = false;
                txtFetchLast.ReadOnly = true;
            }
            //END GUI
            
        }
        #endregion
        #region Properties
        public string ComPort
        {
            get { return spComPort.PortName; }
            set { spComPort.PortName = value; }
        }
        #endregion
        #region Objects
        Database myDatabase = new Database("ArduinoTemperaturMåling.accdb");
        E_post mail = new E_post();
        Random rand = new Random();
        #endregion
        #region Open Limits
        private void btnLimits_Click(object sender, EventArgs e)
        {
            frmLimits limitForm = new frmLimits();
            limitForm.ShowDialog();
        }
        #endregion
        #region Subscribers
        private void btnSubscribers_Click(object sender, EventArgs e)
        {
            frmSubscribers subscribersForm = new frmSubscribers();
            subscribersForm.ShowDialog();
        }
        #endregion
        #region Settings
        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.ShowDialog();
        }
        #endregion
        #region Enlarge chart
        private void chartFetchedValues_Click(object sender, EventArgs e)
        {
            frmChart chart = new frmChart();
            chart.Show();
        }
        #endregion
        private void btnFetch_Click(object sender, EventArgs e)
        {
            rtbDatabaseValues.Clear();
            
            if(cboAnnotation.Text == "Entries")
            {
                
            }
        }
        #region BatterySurvailence
        private void tmrBatteryStatus_Tick(object sender, EventArgs e)
        {
            prbBatteryStatus.Value = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent*100);
            lblStatus.Text = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();

            string[,] emails = myDatabase.GetSubscribers();

            //GUI
            if (prbBatteryStatus.Value <= 50)
                prbBatteryStatus.ForeColor = Color.Yellow;
            else if (prbBatteryStatus.Value <= 30)
                prbBatteryStatus.ForeColor = Color.Red;
            else
                prbBatteryStatus.ForeColor = Color.Green;

            if (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "0")
            {
                lblStatus.Text = "Normal";
            }
            //END GUI

            if (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "Charging")
                charging = true;
            else if (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() != "Charging" && charging)
            {
                for (int i = 0; i <= emails.GetUpperBound(0); i++)
                {
                    mail.Send(emails[i, 5], "PC Lader ikke", "PCen lader ikke lenger. Enten er støpselet dratt ut eller laderen defekt.");
                }
                charging = false;
            }

            //50% charge
            if (prbBatteryStatus.Value > 50)
                fiftyCharge = true;
            else if (prbBatteryStatus.Value <= 50 && fiftyCharge)
            {
                for (int i = 0; i <= emails.GetUpperBound(0); i++)
                {
                    mail.Send(emails[i, 5], "PC har under 50% batteri igjen", "PCen har under 50% batteri igjen.");
                }
                fiftyCharge = false;
            }
            //END 50% charge

            //CRITICAL
            if (prbBatteryStatus.Value > 15)
                criticalCharge = true;

            else if (prbBatteryStatus.Value <= 15 && criticalCharge) //Critical
            {
                for (int i = 0; i <= emails.GetUpperBound(0); i++)
                {
                    mail.Send(emails[i, 5], "[Kritisk] PC har under 15% batteri igjen", "PCen har under 15% batteri igjen.");
                }
                criticalCharge = false;
            }
            //END CRITICAL
        }
        #endregion BatterySurvailence

        private void cboAnnotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAnnotation.Text == "Continous")
            {
                btnFetch.Enabled = false;
                chbError.Enabled = false;
                chbTemperature.Enabled = false;
                txtFetchLast.ReadOnly = true;
            }
            else
            {
                btnFetch.Enabled = true;
                chbError.Enabled = true;
                txtFetchLast.ReadOnly = false;
                chbTemperature.Enabled = true;
            }
        }

        private void tmrLogTemperature_Tick(object sender, EventArgs e)
        {
            if(Convert.ToInt32(DateTime.Now.ToString("mm")) == 23)
            myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("hh:mm:ss"), Convert.ToString(rand.Next(0,101)));


        }
    }
}
