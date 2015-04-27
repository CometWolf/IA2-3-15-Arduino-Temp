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
using System.Threading;
using System.Timers;

namespace CabinTempArduino
{   /*
        Wrtitten by: Martin Terjesen
        The main part of the program, with temperature logging and battery surveillance.
    */

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
        private static bool alarmLogged = false;
        private static string temp;
        string prevTemp = "";
        double differenceTemp = 0;
        #endregion

        #endregion
        #region Disable Visual Styles
        [DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public extern static Int32 SetWindowTheme(IntPtr hWnd,
                      String textSubAppName, String textSubIdList); //Used for reverting back to win98 visual style.
        
        //Source: http://stackoverflow.com/questions/3893622/windows-98-style-progress-bar 
        #endregion
        #region Initial
        public frmMain()
        {
            InitializeComponent();
            SetWindowTheme(prbBatteryStatus.Handle, "", ""); //Reverts the style of the progressbar to win98, this allows us to change the color of the progressbar.

            //GUI
            if (cboAnnotation.Text == "Benevning")
            {
                btnFetch.Enabled = false;
                rbtError.Enabled = false;
                rbtTemperature.Enabled = false;
                txtFetchLast.ReadOnly = true;
            }
            //END GUI

            settings = myDatabase.GetSettings(0);
            chartFetchedValues.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            chartFetchedValues.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
        }
        #endregion
        #region Objects
        Database myDatabase = new Database("ArduinoTemperaturMåling.accdb");
        FurnaceController Temp;
        E_post mail = new E_post();
        #endregion
        #region Open Limits
        private void btnLimits_Click(object sender, EventArgs e)
        {
            frmLimits limitForm = new frmLimits();
            limitForm.ShowDialog();
        }
        #endregion
        #region Open Subscribers
        private void btnSubscribers_Click(object sender, EventArgs e)
        {
            frmSubscribers subscribersForm = new frmSubscribers();
            subscribersForm.ShowDialog();
        }
        #endregion
        #region Open Settings
        private void btnSettings_Click_1(object sender, EventArgs e)
        {
            frmSettings settingsForm = new frmSettings();
            settingsForm.ShowDialog();
        }
        #endregion
        private void btnFetch_Click(object sender, EventArgs e)
        {
            //Fetches values from the database.
            rtbDatabaseValues.Clear();
            int fetchLast = 1;
            int.TryParse(txtFetchLast.Text, out fetchLast);


            switch (cboAnnotation.SelectedIndex)
            {
                case 0:
                    if (rbtTemperature.Checked) FetchTemp(myDatabase.GetTemperatureLast(fetchLast));
                    else if (rbtError.Checked) FetchAlarm(myDatabase.GetAlarmLast(fetchLast));
                    else MessageBox.Show("Velg Temperatur eller Alarm");
                    break;
                case 1:
                    if (rbtTemperature.Checked) FetchTemp(myDatabase.GetTemperatureDays(fetchLast));
                    else if (rbtError.Checked) FetchAlarm(myDatabase.GetAlarmDays(fetchLast));
                    else MessageBox.Show("Velg Temperatur eller Alarm");
                    break;
                case 2:
                    if (rbtTemperature.Checked) FetchTemp(myDatabase.GetTemperatureMonths(fetchLast));
                    else if (rbtError.Checked) FetchAlarm(myDatabase.GetAlarmMonths(fetchLast));
                    else MessageBox.Show("Velg Temperatur eller Alarm");
                    break;
                case 3:
                    if (btnFetch.Text == "Start")
                    {
                        continous = true;
                        btnFetch.Text = "Stopp";
                        cboAnnotation.Enabled = false;
                        rtbDatabaseValues.Clear();
                        rtbDatabaseValues.Text = "Tid" + "\t\t\t" + "Temperatur" + "\r\n";

                    }
                    else if (btnFetch.Text == "Stopp")
                    {
                        continous = false;
                        btnFetch.Text = "Start";
                        cboAnnotation.Enabled = true;
                        rbtError.Enabled = true;
                        rbtTemperature.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }
        #region BatterySurveillance
        private void tmrBatteryStatus_Tick(object sender, EventArgs e)
        {
            //Checks the batterypercentage. Logs alarm and sends emails if the percentage goes under certain points.
            try
            {
                prbBatteryStatus.Value = Convert.ToInt32(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                lblStatus.Text = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();

                string[,] emails = myDatabase.GetSubscribers();

                #region GUI
                //Changing color and text in status.
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
                    (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "High, Charging") ||
                    (SystemInformation.PowerStatus.BatteryChargeStatus.ToString() == "Low, Charging"))
                    charging = true;
                else if (prbBatteryStatus.Value <= 95 && charging) //Checks if the battery is not charging, and sends emails and logs it in the database.
                {
                    LogAlarmAndSendEmail("PC Lader ikke", "PCen lader ikke lenger. Enten er støpselet dratt ut, strømmen gått eller laderen defekt.", "001");
                    charging = false; 
                }

                //50% charge
                if (prbBatteryStatus.Value > 50)
                    fiftyCharge = true;
                else if (prbBatteryStatus.Value <= 50 && fiftyCharge && !charging) //Checks if the battery is under 50%, and sends emails and logs it in the database.
                {
                    LogAlarmAndSendEmail("PC har under 50% batteri igjen", "PCen har under 50% batteri igjen.", "002");
                    fiftyCharge = false;
                }
                //END 50% charge

                //CRITICAL
                if (prbBatteryStatus.Value > 15)
                    criticalCharge = true;

                else if (prbBatteryStatus.Value <= 15 && criticalCharge && !charging) //Checks if the battery is at a critical level, and sends emails and logs it in the database.
                {
                    LogAlarmAndSendEmail("[Kritisk] PC har under 15% batteri igjen", "PCen har under 15% batteri igjen.", "003");
                    criticalCharge = false;
                }
            }
            catch(Exception ex)
            {
                LogAlarmAndSendEmailException(ex.GetType().ToString(), ex.Message, "004");
            }
            //END CRITICAL
        }
        #endregion BatterySurvailence
        private void cboAnnotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GUI //Changes GUI depeding on what cboAnnotation shows.
            if (cboAnnotation.SelectedIndex == 3)
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
                btnFetch.Text = "Hent";
            }
            //END GUI
        }
        #region TemperatureLogging
        private void tmrLogTemperature_Tick(object sender, EventArgs e)
        {
            try
            {
                settings = myDatabase.GetSettings(0);
                int interval = Convert.ToInt32(settings[5]);

                //Arduino

                //Gets the temperature from the arduino.
                if(Temp != null)
                {
                    temp = Temp.GetTemp();
                }

                if (prevTemp == "") 
                    prevTemp = temp;
                differenceTemp = Convert.ToDouble(prevTemp.Replace(".",",")) - Convert.ToDouble(temp.Replace(".",",")); //Calulates the difference between the new temperature and the previous one.

                if (differenceTemp > 10) //If the difference is higher than 10, the temperaturesensor is inaccurate and possibly damaged.
                {
                    txtCurrent.Text = "Temp. feil";
                    throw new Exception("Temperaturføleren er ustabil, muligens ødelagt. Må sjekkes.");
                }
                else if (differenceTemp < -10) //If the difference is lower than -10, the temperaturesensor is inaccurate and possibly damaged.
                {
                    txtCurrent.Text = "Temp. feil";
                    throw new Exception("Temperaturføleren er ustabil, muligens ødelagt. Må sjekkes.");
                }
                else if (Convert.ToDouble(temp.Replace(".", ",")) <= -50) //If the temperature is lower or equal to the lowest value possible, the plus connector on the sensor has been broken.
                {
                    txtCurrent.Text = "Temp. feil";
                    throw new Exception("Temperaturføleren er ustabil, muligens ødelagt. Må sjekkes.");
                }
                else if (Convert.ToDouble(temp.Replace(".", ",")) > 100) //If the temperature is higher than the highest value possible, the minus or analog connector on the sensor is broken.
                {
                    txtCurrent.Text = "Temp. feil";
                    throw new Exception("Temperaturføleren er ustabil, muligens ødelagt. Må sjekkes.");
                }

                txtCurrent.Text = temp;

                //Send new limits to the Arduino.
                Temp.AlarmLowerLimit = Convert.ToDouble(settings[4]);
                Temp.AlarmUpperLimit = Convert.ToDouble(settings[1]);
                Temp.FurnaceLowerLimit = Convert.ToDouble(settings[3]);
                Temp.FurnaceUpperLimit = Convert.ToDouble(settings[2]);

                string checkAlarm = Temp.CheckAlarm();

                //Checks if any alarms are active in the arduino.
                if (checkAlarm == "ALARM_UP" && !alarmLogged)
                {
                    LogAlarmAndSendEmail("Høy temperatur", "Den øvre alarmgrensen har blitt nådd", "010");
                    txtCurrent.BackColor = Color.Red;
                    alarmLogged = true;
                }
                else if (checkAlarm == "ALARM_LOW" && !alarmLogged)
                {
                    LogAlarmAndSendEmail("Lav temperatur", "Den nedre alarmgrensen har blitt nådd", "020");
                    txtCurrent.BackColor = Color.Aqua;
                    alarmLogged = true;
                }
                else if (checkAlarm == "NO_ALARM")
                {
                    txtCurrent.BackColor = Color.White;
                    alarmLogged = false;
                }
                //END Arduino

                //Logging
                if (settings[7] == "false") //Checks if a preset interval has been used.
                {
                    if (interval == 15 && ((Convert.ToInt32(DateTime.Now.ToString("mm")) == 00) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 15) ||
                        (Convert.ToInt32(DateTime.Now.ToString("mm")) == 30) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 45))
                        && !logged) //Checks the system clock. Gets disabled by logged in temperatureLogging()
                    {
                        TemperatureLogging();
                    }
                    else if (interval == 30 && ((Convert.ToInt32(DateTime.Now.ToString("mm")) == 00) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 30))
                        && !logged) //Checks the system clock. Gets disabled by logged in temperatureLogging()
                    {
                        TemperatureLogging();
                    }
                    else if (interval == 60 && Convert.ToInt32(DateTime.Now.ToString("mm")) == 00 && !logged) //Checks the system clock. Gets disabled by logged in temperatureLogging()
                    {
                        TemperatureLogging();
                    }
                    else if (((Convert.ToInt32(DateTime.Now.ToString("mm")) == 01) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 16) ||
                            (Convert.ToInt32(DateTime.Now.ToString("mm")) == 31) || (Convert.ToInt32(DateTime.Now.ToString("mm")) == 46))
                        && logged) //Logged is set to false after a minute, so that it can log the next time.
                        logged = false;
                }
                else if (settings[7] == "true") //Checks if a custom interval has been used.
                {
                    if (interval == 1440) //Checks if the interval is equal to 24hrs.
                    {
                        if (DateTime.Now.ToString("HH:mm") == settings[6] && !logged)
                        {
                            TemperatureLogging();
                            loggedMinute = Convert.ToInt32(DateTime.Now.ToString("mm"));
                        }
                        else if ((settings[8] == "true") && (Convert.ToInt32(DateTime.Now.ToString("mm")) == loggedMinute + 1))
                            logged = false;
                    }
                    else if (DateTime.Now.ToString("HH:mm") == settings[6] && interval != 1440) //Normal custom logging.
                    {
                        NextLogTime();
                        TemperatureLogging();
                    }
                }
                //END Logging
            }
            catch(NullReferenceException error) //Temp = null
            {
                LogAlarmAndSendEmailException(error.GetType().ToString(), error.Message, "005");
                tmrLogTemperature.Stop();
                MessageBox.Show(error.GetType().ToString() + "\r\n" + error.Message + "\r\n" + "Programmet må restartes før videre bruk.");
            }
            catch (System.IO.IOException IOex) //The connection between the computer and the Arduino is broken.
            {
                LogAlarmAndSendEmailException(IOex.GetType().ToString(), IOex.Message, "006");
                txtCurrent.Text = "Mistet kontakt";
                tmrLogTemperature.Stop();
                MessageBox.Show("Det har oppstått en feil i forbindelsen mellom Arduinoen og datamaskinen.\r\nSjekk kabelen og restart programmet.");
            }
            catch(Exception ex)
            {
                LogAlarmAndSendEmailException(ex.GetType().ToString(), ex.Message, "007");
                tmrLogTemperature.Stop();
                MessageBox.Show(ex.GetType().ToString() +"\r\n"+ ex.Message + "\r\n" + "Programmet må restartes før videre bruk.");
            }
        }
        #endregion

        #region Methods
        private void TemperatureLogging()
        {
            //Logs a temperature and puts the temperature into the rich textbox if continous is chosen.
            myDatabase.LogTemperature(Temp.GetTemp());
            if(continous)
            {
                string[,] lastValue;
                lastValue = myDatabase.GetTemperatureLast();
                FetchContinous(lastValue, "Tid" + "\t\t\t" + "Temperatur" + "\r\n");
                ChartAddPoint(lastValue[0, 0], lastValue[0, 1]);
            }
            logged = true;
        }
        public void NewInterval()
        {
            //Logs a temperature when a new interval is set.
            myDatabase.LogTemperature(Temp.GetTemp());
            NextLogTime();
            logged = false;
        }
        private void StartUPlog()
        {
            //Logs a temperature at startUP.
            if (settings[7] != "1440")
            {
                NextLogTime();
                TemperatureLogging();
            }
            else if (settings[7] == "1440") //If the interval is set to 24hrs it only needs to set a new log time, because next logtime is the same time as the program was started.
                NextLogTime();
        }
        public void NextLogTime()
        {
            //Sets the next time a log shall happen if the interval is custom. By using the system clock.
            settings = myDatabase.GetSettings(0);
            int interval = Convert.ToInt32(settings[5]);

            int hours = interval / 60;
            int minutes = interval % 60;

            int hoursNow = Convert.ToInt32(DateTime.Now.ToString("HH"));
            int minutesNow = Convert.ToInt32(DateTime.Now.ToString("mm"));

            nextHours = Convert.ToString(hoursNow + hours);
            nextMinutes = Convert.ToString(minutesNow + minutes);

            if (Convert.ToInt32(nextHours) >= 24) 
                nextHours = (Convert.ToInt32(nextHours) % 24).ToString(); //Resets the hours if it goes above 24:00, and sets the new time as the rest value.
            if (Convert.ToInt32(nextMinutes) >= 60)
                nextMinutes = (Convert.ToInt32(nextMinutes) % 60).ToString(); //Resets the minutes if it goes above 60, and sets the new time as the rest value.
            if (nextHours.Length == 1)
                nextHours = "0" + nextHours; //Checks if the value it less than two digits and inserts a zero if it is.
            if (nextMinutes.Length == 1)
                nextMinutes = "0" + nextMinutes;

            nextLog = nextHours + ":" + nextMinutes; //Puts a time togheter with the right format.

            myDatabase.UpdateSetting(nextLog, 6, 0);
        }
        private void FetchTemp(string[,] values, string header = "Tid" + "\t\t\t" + "Temperatur" + "\r\n")
        {
            //Written by: Jørund Marthinsen
            //Fetches temperatures from the database, by using the FetchAlarm method.
            FetchAlarm(values, header);
            ChartUpdateTemp(values);
        }
        private void FetchAlarm(string[,] values, string header = "Tid" + "\t\t\t" + "ID" + "\t" + "Temp" + "\t" + "Beskrivelse" + "\r\n")
        {
            //Written by: Jørund Marthinsen
            //Fetches alarms from the database.
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
        private void FetchContinous(string[,] addValues, string header)
        {
            //Written by: Jørund Marthinsen
            //Fetches values continously.
            rtbDatabaseValues.Lines[0] = header;
            for (int i = 0; i <= addValues.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= addValues.GetUpperBound(1); j++)
                {
                    rtbDatabaseValues.AppendText(addValues[i, j]);
                    rtbDatabaseValues.AppendText("\t");
                }
                rtbDatabaseValues.AppendText("\r\n");
            }
        }
        private void ChartUpdateTemp(string[,] xy)
        {
            //Written by: Jørund Marthinsen
            //Shows fetched values in the chart.
            DateTime myDate;
            double temp;

            chartFetchedValues.Series[0].Points.Clear();


            chartFetchedValues.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;


            for (int i = 0; i < xy.GetUpperBound(0); i++)
            {
                myDate = DateTime.ParseExact(xy[i, 0], "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                xy[i, 1] = xy[i, 1].Replace('.', ',');

                double.TryParse(xy[i, 1], out temp);


                chartFetchedValues.Series[0].Points.AddXY(myDate, temp);
            }


            chartFetchedValues.Series[0].Sort(System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Ascending, "X");
            //if (chartFetchedValues.Series[0].Points.Count > 0)
            //{
                //if (chartFetchedValues.Series[0].Points[0].XValue > DateTime.Now.AddDays(-2.0).ToOADate()) chartFetchedValues.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            //}
            chartFetchedValues.Refresh();
        }
        private void ChartAddPoint(string x, string y)
        {
            //Written by: Jørund Marthinsen
            //Adds points to the chart continously.
            double myDouble;
            y = y.Replace('.', ',');
            double.TryParse(y, out myDouble);

            chartFetchedValues.Series[0].Points.AddXY(
                DateTime.ParseExact(x, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture),
                myDouble);

            chartFetchedValues.Series[0].Sort(System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Ascending, "X");
            chartFetchedValues.Refresh();
        }
        private void LogAlarmAndSendEmail(string subject, string message, string alarmID)
        {
            //Sends email and logs alarms.
            string[,] emails = myDatabase.GetSubscribers();
            for (int i = 0; i <= emails.GetUpperBound(0); i++)
            {
                mail.Send(emails[i, 5], subject, message);
            }
            myDatabase.LogAlarm(subject, alarmID, temp);
        }
        private void LogAlarmAndSendEmailException(string subject, string message, string alarmID)
        {
            //Sends email and logs alarm/Exception.
            string[,] emails = myDatabase.GetSubscribers();
            for (int i = 0; i <= emails.GetUpperBound(0); i++)
            {
                mail.Send(emails[i, 5], subject, message);
            }
            myDatabase.LogAlarm(subject + ": " + message, alarmID, temp);
        }
        public void SetPortArduino(string port)
        {
            //Sets the comPort for the arduino, if the has not been set before.
            Temp = new FurnaceController(Convert.ToDouble(settings[1]), Convert.ToDouble(settings[4]),
                             Convert.ToDouble(settings[2]), Convert.ToDouble(settings[3]), 9600, port);
            arduinoPort = settings[8];
            StartUPlog();
            tmrLogTemperature.Start(); //Logging starts.
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Sets the comPort, if the correct comPort is in the database.
            try
            {
                Temp = new FurnaceController(Convert.ToDouble(settings[1]), Convert.ToDouble(settings[4]),
                                             Convert.ToDouble(settings[2]), Convert.ToDouble(settings[3]), 9600, settings[8]);
                arduinoPort = settings[8];
                StartUPlog();

            }
            catch (System.IO.IOException)
            {
                tmrLogTemperature.Stop(); //If not, the port must be manually entered in frmSettings.
                txtCurrent.Text = "Velg port i innstillinger";
            }
        }
    }
}
