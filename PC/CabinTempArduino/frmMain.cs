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
        #region Variables
        bool criticalCharge = true;
        bool fiftyCharge = true;
        bool charging = true;
        bool logged = false;

        string nextLog = "";
        int loggedMinute = 0;
        string nextMinutes = "";
        string nextHours = "";
        #endregion
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

            if (cboAnnotation.Text == "Entries")
            {

            }
        }
        #region BatterySurvailence
        private void tmrBatteryStatus_Tick(object sender, EventArgs e)
        {
            prbBatteryStatus.Value = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent * 100);
            lblStatus.Text = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();

            string[,] emails = myDatabase.GetSubscribers();

            #region GUI
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
            #endregion

            if ((SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "Charging") ||
                (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "High, Charging"))
                charging = true;
            else if (prbBatteryStatus.Value<=95 && charging)
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
            string[] settings = myDatabase.GetSettings(0);
            int interval = Convert.ToInt32(settings[5]);


            if (interval == 15)
            {
                if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 15 && logged != true)
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));
                    logged = true;
                }
                else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 30 && logged != true)
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));
                    logged = true;
                }
                else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 45 && logged != true)
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));
                    logged = true;
                }
                else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && logged != true)
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));
                    logged = true;
                }
                else if ((Convert.ToInt32(DateTime.Now.ToString("mm")) == 16) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 31) ||
                    (Convert.ToInt32(DateTime.Now.ToString("mm")) == 46) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 01))
                    logged = false;

            }
            else if (interval == 30)
            {
                if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && logged != true)
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));
                    logged = true;
                }
                else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 30 && logged != true)
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));
                    logged = true;
                }
                else if ((Convert.ToInt32(DateTime.Now.ToString("mm")) == 01) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 31))
                    logged = false;
            }
            else if (interval == 60)
            {
                if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && logged != true)
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));
                    logged = true;
                }
                else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 01)
                    logged = false;
            }
            else
            {
                int hours = interval / 60;
                int minutes = interval % 60;

                int hoursNow = Convert.ToInt32(DateTime.Now.ToString("HH"));
                int minutesNow = Convert.ToInt32(DateTime.Now.ToString("mm"));

                if(nextLog == "")
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));

                    nextHours = Convert.ToString(hoursNow + hours);
                    nextMinutes = Convert.ToString(minutesNow + minutes);

                    if (Convert.ToInt32(nextHours) >= 24)
                        nextHours = (Convert.ToInt32(nextHours) % 24).ToString();
                    if (Convert.ToInt32(nextMinutes) >= 60)
                        nextMinutes = (Convert.ToInt32(nextMinutes) % 60).ToString();
                    if (nextHours.Length == 1)
                        nextHours = "0" + nextHours;
                    if (nextMinutes.Length == 1)
                        nextMinutes = "0" + nextMinutes;

                    nextLog = nextHours + ":" + nextMinutes;
                    loggedMinute = minutesNow;

                    logged = true;
                }

                else if(DateTime.Now.ToString("HH:mm") == nextLog && logged != true)
                {
                    myDatabase.LogTemperature(DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm:ss"), Convert.ToString(rand.Next(0, 101)));

                    nextHours = Convert.ToString(hoursNow + hours);
                    nextMinutes = Convert.ToString(minutesNow + minutes);

                    if (Convert.ToInt32(nextHours) >= 24)
                        nextHours = (Convert.ToInt32(nextHours) % 24).ToString();
                    if (Convert.ToInt32(nextMinutes) >= 60)
                        nextMinutes = (Convert.ToInt32(nextMinutes) % 60).ToString();
                    if (nextHours.Length == 1)
                        nextHours = "0" + nextHours;
                    if (nextMinutes.Length == 1)
                        nextMinutes = "0" + nextMinutes;

                    nextLog = nextHours + ":" + nextMinutes;
                    loggedMinute = minutesNow;

                    logged = true;
                }
                else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == (loggedMinute + 1))
                {
                    logged = false;
                }
            }
        }
    }
}
