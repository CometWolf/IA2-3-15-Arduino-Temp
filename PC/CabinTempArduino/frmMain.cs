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
using System.Runtime.InteropServices;
using System.Threading;

namespace CabinTempArduino
{
    public partial class frmMain : Form
    {
        #region Variables
        #region Battery
        private static bool criticalCharge = true;
        private static bool fiftyCharge = true;
        private static bool charging = true;
        #endregion

        #region TempLog
        private static string nextLog = "";
        private static int loggedMinute = 0;
        private static string nextMinutes = "";
        private static string nextHours = "";
        private static bool continous = false;
        string[] settings;
        private static bool logged = false;
        #endregion

        #region ArduinoTemp
        private static string arduinoPort = "";
        private static bool portSet = false;
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
            }
            //END GUI

            settings = myDatabase.GetSettings(0);
            myDatabase.UpdateSetting("false", 8, 0);
            nextLogTime();

            arduinoPort = settings[9];
        }
        #endregion
        #region Properties

        public bool StartArduinoTimer
        {
            set { tmrArduino.Enabled = value; }
        }
        #endregion
        #region Objects
        Database myDatabase = new Database("ArduinoTemperaturMåling.accdb");
        FurnaceController Temp;
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
            int fetchLast = Convert.ToInt32(txtFetchLast.Text);

            switch (cboAnnotation.Text)
            {
                case "Entries":
                    if (rbtTemperature.Checked) FetchTemp(myDatabase.GetTemperatureLast(fetchLast));
                    else if (rbtError.Checked) FetchAlarm(myDatabase.GetAlarmLast(fetchLast));
                    else MessageBox.Show("Check off for temperature or error");
                    break;
                case "Day(s)":
                    if (rbtTemperature.Checked) FetchTemp(myDatabase.GetTemperatureDays(fetchLast));
                    else if (rbtError.Checked) FetchAlarm(myDatabase.GetAlarmDays(fetchLast));
                    else MessageBox.Show("Check off for temperature or error");
                    break;
                case "Months(s)":
                    if (rbtTemperature.Checked) FetchTemp(myDatabase.GetTemperatureMonths(fetchLast));
                    else if (rbtError.Checked) FetchAlarm(myDatabase.GetAlarmMonths(fetchLast));
                    else MessageBox.Show("Check off for temperature or error");
                    break;

                default:
                    break;
            }


            if (cboAnnotation.Text == "Continous")
            {
                if (btnFetch.Text == "Start")
                {
                    continous = true;
                    btnFetch.Text = "Stop";
                    cboAnnotation.Enabled = false;
                    rtbDatabaseValues.Clear();
                    rtbDatabaseValues.Text = "Date \t Time \t Temperature \r\n";

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
        #region BatterySurveillance
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
                    mail.Send(emails[i, 5], "PC Lader ikke", "PCen lader ikke lenger. Enten er støpselet dratt ut, strømmen gått eller laderen defekt.");
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

            else if (prbBatteryStatus.Value <= 15 && criticalCharge && !charging) //Critical
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
                rbtError.Enabled = false;
                rbtTemperature.Enabled = false;
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

                    if (settings[7] == "false")
                    {
                        if (interval == 15 && ((Convert.ToInt32(DateTime.Now.ToString("mm")) == 00) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 15) ||
                            (Convert.ToInt32(DateTime.Now.ToString("mm")) == 30) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 45))
                            && !logged)
                        {
                            temperatureLogging();
                        }
                        else if (interval == 30 && ((Convert.ToInt32(DateTime.Now.ToString("mm")) == 00) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 30))
                            && !logged)
                        {
                            temperatureLogging();
                        }
                        else if (interval == 60 && Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && !logged)
                        {
                            temperatureLogging();
                        }
                        else if (((Convert.ToInt32(DateTime.Now.ToString("mm")) == 01) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 16) ||
                                (Convert.ToInt32(DateTime.Now.ToString("mm")) == 31) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 46))
                            && logged)
                            logged = false; //myDatabase.UpdateSetting("false", 8, 0);
                    }
                    else if (settings[7] == "true")
                    {
                        if(interval == 1440)
                        {
                            if (DateTime.Now.ToString("HH:mm") == settings[6] && settings[8] == "false")
                            {
                                temperatureLogging();
                                loggedMinute = Convert.ToInt32(DateTime.Now.ToString("mm"));
                            }
                            else if ((settings[8] == "true") && (Convert.ToInt32(DateTime.Now.ToString("mm")) == loggedMinute + 1))
                                myDatabase.UpdateSetting("false", 8, 0);
                        }
                        else if (DateTime.Now.ToString("HH:mm") == settings[6] && interval != 1440)
                        {
                            nextLogTime();
                            temperatureLogging();
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
            myDatabase.LogTemperature(Temp.GetTemp("TEMP"));
            if(continous)
            {
                string[,] lastValue;
                lastValue = myDatabase.GetTemperatureLast();
                rtbDatabaseValues.AppendText(lastValue[0,1] +"\t"+ lastValue[0,2] +"\r\n");
            }
            logged = true;
            //myDatabase.UpdateSetting("true", 8, 0);
        }
        public void newInterval()
        {
            myDatabase.LogTemperature(Temp.GetTemp("TEMP"));
            nextLogTime();
            logged = false;
            //myDatabase.UpdateSetting("false", 8, 0);
        }
        public void nextLogTime()
        {
            settings = myDatabase.GetSettings(0);
            int interval = Convert.ToInt32(settings[5]);

            int hours = interval / 60;
            int minutes = interval % 60;

            int hoursNow = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minutesNow = Convert.ToInt32(DateTime.Now.ToString("mm"));

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

            myDatabase.UpdateSetting(nextLog, 6, 0);
        }
        private void FetchTemp(string[,] values, string header = "Time" + "\t" + "Temperature" + "\r\n")
        {
            rtbDatabaseValues.Clear();
            rtbDatabaseValues.Text = header;
            for (int i = 0; i <= values.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= values.GetUpperBound(1); j++)
                {
                    rtbDatabaseValues.AppendText(values[i, j]);
                    rtbDatabaseValues.AppendText("\t");
                }
                rtbDatabaseValues.AppendText("\r\n");
            }
        }
        private void FetchAlarm(string[,] values, string header = "Time" + "\t" + "Temperature" + "\r\n")
        {
            FetchTemp(values, header);
        }
        #endregion

        private void tmrArduino_Tick(object sender, EventArgs e)
        {
            try
            {
                settings = myDatabase.GetSettings(0);

                if (arduinoPort != settings[9])
                {
                    Temp = new FurnaceController(Convert.ToDouble(settings[1]), Convert.ToDouble(settings[4]),
                                                 Convert.ToDouble(settings[2]), Convert.ToDouble(settings[3]), 9600, settings[9]);
                    arduinoPort = settings[9];
                }
                txtCurrent.Text = Temp.GetTemp("TEMP");

                //Temp.SetAlarmLower(settings[4]);
                //Temp.SetAlarmUpper(settings[1]);
                //Temp.SetFurnaceLower(settings[3]);
                //Temp.SetFurnaceUpper(settings[2]);

                Temp.AlarmLowerLimit = Convert.ToDouble(settings[4]);

            }
            catch(NullReferenceException)
            {
                txtCurrent.Text = "Arduino is not plugged in";
            }
            catch(Exception ex)
            {
                txtCurrent.Text = "Set port in settings";
                MessageBox.Show(ex.GetType().ToString());
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try 
            {
                Temp = new FurnaceController(Convert.ToDouble(settings[1]), Convert.ToDouble(settings[4]),
                                             Convert.ToDouble(settings[2]), Convert.ToDouble(settings[3]), 9600, settings[9]);
                arduinoPort = settings[9];
            }
            catch(Exception)
            {
                txtCurrent.Text = "Set port in settings";
            }
        }
    }
}
