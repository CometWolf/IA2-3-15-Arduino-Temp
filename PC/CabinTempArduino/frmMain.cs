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

        #region Battery
        bool criticalCharge = true;
        bool fiftyCharge = true;
        bool charging = true;
        bool logged = false;
        #endregion

        #region TempLog
        string nextLog = "";
        int loggedMinute = 0;
        string nextMinutes = "";
        string nextHours = "";
        int oldInterval;
        bool continous = false;
        string[] settings;
        #endregion

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
            //GUI
            if (cboAnnotation.Text == "Annotation")
            {
                btnFetch.Enabled = false;
                rbtError.Enabled = false;
                rbtTemperature.Enabled = false;
                txtFetchLast.ReadOnly = true;
                settings = myDatabase.GetSettings(0);
                oldInterval = Convert.ToInt32(settings[5]);
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
        private void btnFetch_Click(object sender, EventArgs e)
        {
            rtbDatabaseValues.Clear();
            string[,] fetchedArray;

            if (cboAnnotation.Text == "Entries")
            {
                if (rbtTemperature.Checked)
                {
                    rtbDatabaseValues.Clear();
                    rtbDatabaseValues.Text = "Date \t Time \t Temperature \r\n";
                    fetchedArray = myDatabase.GetTemperatureLast(Convert.ToInt32(txtFetchLast.Text));
                    for (int i = 0; i <= fetchedArray.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= fetchedArray.GetUpperBound(1); j++)
                        {
                            rtbDatabaseValues.AppendText(fetchedArray[i, j]);
                        }
                        rtbDatabaseValues.AppendText("\r\n");
                    }
                }
                else if (rbtError.Checked)
                {
                    rtbDatabaseValues.Clear();
                    rtbDatabaseValues.Text = "Date \t Time \t Temperature \r\n";
                    fetchedArray = myDatabase.GetAlarmLast(Convert.ToInt32(txtFetchLast.Text));
                    for (int i = 0; i <= fetchedArray.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= fetchedArray.GetUpperBound(1); j++)
                        {
                            rtbDatabaseValues.AppendText(fetchedArray[i, j]);
                        }
                        rtbDatabaseValues.AppendText("\r\n");
                    }
                }
                else
                    throw new Exception("Check off for temperature or error");
            }
            else if (cboAnnotation.Text == "Day(s)")
            {
                if (rbtTemperature.Checked)
                {
                    rtbDatabaseValues.Clear();
                    rtbDatabaseValues.Text = "Date \t Time \t Temperature \r\n";
                    fetchedArray = myDatabase.GetTemperatureDays(Convert.ToInt32(txtFetchLast.Text));
                    for (int i = 0; i <= fetchedArray.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= fetchedArray.GetUpperBound(1); j++)
                        {
                            rtbDatabaseValues.AppendText(fetchedArray[i, j]);
                        }
                        rtbDatabaseValues.AppendText("\r\n");
                    }
                }
                else if (rbtError.Checked)
                {
                    rtbDatabaseValues.Clear();
                    fetchedArray = myDatabase.GetAlarmDays(Convert.ToInt32(txtFetchLast.Text));
                    for (int i = 0; i <= fetchedArray.GetUpperBound(0); i++)
                    {
                        for (int j = 1; j <= fetchedArray.GetUpperBound(1); j++)
                        {
                            rtbDatabaseValues.AppendText(fetchedArray[i, j]);
                        }
                        rtbDatabaseValues.AppendText("\r\n");
                    }
                }
                else
                    throw new Exception("Check off for temperature or error");
            }
            else if(cboAnnotation.Text == "Month(s)")
            {
                if (rbtTemperature.Checked)
                {
                    rtbDatabaseValues.Clear();
                    rtbDatabaseValues.Text = "Date \t Time \t Temperature \r\n";
                    fetchedArray = myDatabase.GetTemperatureMonths(Convert.ToInt32(txtFetchLast.Text));
                    for (int i = 0; i <= fetchedArray.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= fetchedArray.GetUpperBound(1); j++)
                        {
                            rtbDatabaseValues.AppendText(fetchedArray[i, j]);
                        }
                        rtbDatabaseValues.AppendText("\r\n");
                    }
                }
                else if (rbtError.Checked)
                {
                    rtbDatabaseValues.Clear();
                    rtbDatabaseValues.Text = "Date \t Time \t Temperature \r\n";
                    fetchedArray = myDatabase.GetAlarmMonths(Convert.ToInt32(txtFetchLast.Text));
                    for (int i = 0; i <= fetchedArray.GetUpperBound(0); i++)
                    {
                        for (int j = 1; j <= fetchedArray.GetUpperBound(1); j++)
                        {
                            rtbDatabaseValues.AppendText(fetchedArray[i, j]);
                        }
                        rtbDatabaseValues.AppendText("\r\n");
                    }
                }
                else
                    MessageBox.Show("Check off for temperature or error");
            }
            else if(cboAnnotation.Text == "Continous")
            {
                if (btnFetch.Text == "Start")
                {
                    if (rbtTemperature.Checked || rbtError.Checked)
                    {
                        continous = true;
                        btnFetch.Text = "Stop";
                        cboAnnotation.Enabled = false;
                        rbtError.Enabled = false;
                        rbtTemperature.Enabled = false;
                        rtbDatabaseValues.Clear();
                    }
                    else
                        MessageBox.Show("Check off for temperature or error");

                }
                else if (btnFetch.Text == "Stop")
                {
                    continous = false;
                    btnFetch.Text = "Start";
                    cboAnnotation.Enabled = true;
                    rbtError.Enabled = true;
                    rbtTemperature.Enabled = true;
                }
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
                (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "High, Charging")||
                (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "Low, Charging"))
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
            else if (prbBatteryStatus.Value <= 50 && fiftyCharge && !charging)
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
                
                rbtError.Enabled = true;
                rbtTemperature.Enabled = true;
                txtFetchLast.ReadOnly = true;
                btnFetch.Text = "Start";
                btnFetch.Enabled = true;
            }
            else
            {
                btnFetch.Enabled = true;
                rbtError.Enabled = true;
                rbtTemperature.Enabled = true;
                txtFetchLast.ReadOnly = false;
                btnFetch.Text = "Fetch values";
            }
        }
        #region TemperatureLogging



        private void tmrLogTemperature_Tick(object sender, EventArgs e)
        {
            try
            {
                settings = myDatabase.GetSettings(0);
                int interval = Convert.ToInt32(settings[5]);

                if (interval == 15 && settings[7] == "false")
                {
                    if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && logged != true)
                    {
                        temperatureLogging();
                    }
                    else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 30 && logged != true)
                    {
                        temperatureLogging();
                    }
                    else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 45 && logged != true)
                    {
                        temperatureLogging();
                    }
                    else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && logged != true)
                    {
                        temperatureLogging();
                    }
                    else if ((Convert.ToInt32(DateTime.Now.ToString("mm")) == 01) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 31) ||
                        (Convert.ToInt32(DateTime.Now.ToString("mm")) == 46) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 01))
                        logged = false;

                }
                else if (interval == 30 && settings[7] == "false")
                {
                    if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && logged != true)
                    {
                        temperatureLogging();
                    }
                    else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 30 && logged != true)
                    {
                        temperatureLogging();
                    }
                    else if ((Convert.ToInt32(DateTime.Now.ToString("mm")) == 01) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 31))
                        logged = false;
                }
                else if (interval == 60 && settings[7] == "false")
                {
                    if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && logged != true)
                    {
                        temperatureLogging();
                    }
                    else if (Convert.ToInt32(DateTime.Now.ToString("mm")) == 01)
                        logged = false;
                }
                else if (settings[7] == "true")
                {
                    int hours = interval / 60;
                    int minutes = interval % 60;

                    int hoursNow = Convert.ToInt32(DateTime.Now.ToString("HH"));
                    int minutesNow = Convert.ToInt32(DateTime.Now.ToString("mm"));

                    if (oldInterval != interval)
                        nextLog = "";

                    if (nextLog == "")
                    {
                        temperatureLogging();

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

                        oldInterval = interval;
                        logged = true;
                    }

                    else if (DateTime.Now.ToString("HH:mm") == nextLog && logged != true)
                    {
                        temperatureLogging();

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Methods
        private void temperatureLogging()
        {
            string temp = Convert.ToString(rand.Next(0, 101));
            myDatabase.LogTemperature(temp);
            logged = true;
            if(continous)
            {
                string[,] lastValue;
                if(rbtTemperature.Checked)
                {
                    lastValue = myDatabase.GetTemperatureLast();
                    rtbDatabaseValues.Text = lastValue[0, 0];
                }
            }
        }
        #endregion
    }
}
