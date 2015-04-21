using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace WebApplication6.Classes
{
    /// <summary>
    /// Connects to a database and simplifies communication
    /// </summary>
    class Database:OLEdb
    {
        #region Initial
        // Tables to use
        string subscriberTable = "BrukerInformasjon";
        string alarmTable = "Feilmeldingslogg";
        string tempTable = "TemperaturLogg";
        string settingsTable = "Innstillinger";
        /// <summary>
        /// Initializes an instance of the Database class
        /// </summary>
        /// <param name="DbPath">Path to Database</param>
        public Database(string DbPath) : base(DbPath)
        {
            
        }
        #endregion
        #region Subscribers
        /// <summary>
        /// Adds a subscriber to BrukerInformasjon
        /// </summary>
        /// <param name="surName"></param>
        /// <param name="firstName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        public void AddSubscriber(string surName, string firstName, string userName, string password, string email, string phone)
        {
            try
            {

                OpenDb(subscriberTable);

                DataRow row = myDatatable.NewRow();

                row["Etternavn"] = surName;
                row["Fornavn"] = firstName;
                row["Brukernavn"] = userName;
                row["Passord"] = password;
                row["E-post"] = email;
                row["Telefon"] = phone;

                myDatatable.AcceptChanges();
                myDatatable.Rows.Add(row);

                CloseDb(subscriberTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
        }
        /// <summary>
        /// Deletes a row from BrukerInformasjon
        /// </summary>
        /// <param name="userID">Row to delete</param>
        public void DeleteSubscriber(int userID)
        {
            try
            {

                OpenDb(subscriberTable);

                myDatatable.Rows[userID].Delete();

                CloseDb(subscriberTable);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
        }
        /// <summary>
        /// Updates selected row with new values
        /// </summary>
        /// <param name="id">Row to update</param>
        /// <param name="values">New values to row</param>
        public void UpdateSubscriber(int id, string surName, string firstName, string userName, string password, string email, string phone)
        {
            
            try
            {
                OpenDb(subscriberTable);

                string updateQuery = string.Format(("UPDATE {0} SET [Etternavn]='{1}', [Fornavn]='{2}', [Brukernavn]='{3}', [Passord]='{4}', [E-post]='{5}', [Telefon]='{6}' WHERE [BrukerId]={7}")
                                            ,subscriberTable,surName,firstName,userName,password,email,phone,id);

                CloseDbMan(updateQuery);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// Gets all subscribers in 'BrukerInformasjon'
        /// </summary>
        /// <returns>
        /// Dynamic string array of all values in 'BrukerInformasjon'
        /// </returns>
        public string[,] GetSubscribers()
        {
            string[,] subscribers;
            try
            {
                OpenDb(subscriberTable);

                int rows = myDatatable.Rows.Count;
                int columns = myDatatable.Columns.Count;

                subscribers = new string[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        subscribers[i, j] = myDatatable.Rows[i].ItemArray[j].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                subscribers = new string[0, 0];
                subscribers[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return subscribers;
        }
        /// <summary>
        /// Search Functions
        /// </summary>
        /// <param name="username">Name to search for</param>
        /// <returns></returns>
        public bool SearchUsername(string username)
        {
            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE '{2}' = {1}"), 
                    alarmTable, "Brukernavn", username);

                OpenDbMan(connectionstring);

                if (myDatatable.Rows.Count > 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
        }
        public string SearchUsername(string username, string password)
        {
            try
            {
                string connectionstring = String.Format((
                    "SELECT [{2}] FROM {0} WHERE '{1}' = [{2}] OR '{1}' = [{3}] AND '{4}' = [{5}]"),
                    subscriberTable, username, "Brukernavn", "E-post", password, "Passord");

                OpenDbMan(connectionstring);

                if (myDatatable.Rows.Count > 0)
                {
                    return myDatatable.Rows[0][0].ToString();
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
        }
        /// <summary>
        /// Gets user Id from username
        /// </summary>
        /// <param name="username">Name to get</param>
        /// <returns>UserId</returns>
        public int GetUserID(string username)
        {
            int index = 0;
            string[,] subscribers = GetSubscribers();
            for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
            {
                if (username == subscribers[i, 3])
                    goto exit;
                else
                    index++;
            }

        exit:
            return Convert.ToInt32(subscribers[index, 0]);
        }
        /// <summary>
        /// Gets index from username
        /// </summary>
        /// <param name="username">Name to get</param>
        /// <returns>Index</returns>
        public int GetIndex(string username)
        {
            int index = 0;
            string[,] subscribers = GetSubscribers(); 
            for (int i = 0; i <= subscribers.GetUpperBound(0); i++)
            {
                if (username == subscribers[i, 3])
                    goto exit;
                else
                    index++;
            }

        exit:
            return index;
        }
        #endregion
        #region Alarms
        /// <summary>
        /// Adds an alarm to Feilmeldingslogg
        /// </summary>
        /// <param name="message"></param>
        /// <param name="alarmID"></param>
        /// <param name="temp"></param>
        public void LogAlarm(string message, string alarmID, string temp)
        {
            DateTime timestamp = new DateTime();
            timestamp = DateTime.Now;
            try
            {

                OpenDb(alarmTable);

                DataRow row = myDatatable.NewRow();

                row["Timestamp"] = timestamp.ToString("dd.MM.yyyy HH:mm:ss");
                row["Feilmelding"] = message;
                row["AlarmID"] = alarmID;
                row["Temperatur"] = temp;

                myDatatable.AcceptChanges();
                myDatatable.Rows.Add(row);

                CloseDb(alarmTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
        }
        #region Sign
        /// <summary>
        /// Signs all alarms
        /// </summary>
        public void SignAlarm() 
        {
            try {
                OpenDb(subscriberTable);

                string updateQuery = string.Format((
                    "UPDATE {0} SET [Status]='{1}'"),
                    alarmTable, 1);

                CloseDbMan(updateQuery);

            } catch (Exception ex) {

                throw ex;
            } finally {
                myAccessConnection.Close();
            }
        }
        /// <summary>
        /// Updates status of alarms with the specified Id
        /// </summary>
        /// <param name="alarmId">Id to sign</param>
        /// <param name="status">New status</param>
        public void SignAlarm(string alarmId, int status = 1) 
        {
            try {
                OpenDb(subscriberTable);

                string updateQuery = string.Format((
                    "UPDATE {0} SET [Status]='{1}' WHERE [AlarmId] = '{2}'"),
                    alarmTable, status, alarmId);

                CloseDbMan(updateQuery);

            } catch (Exception ex) {

                throw ex;
            } finally {
                myAccessConnection.Close();
            }
        }
        #endregion
        #region Get
        /// <summary>
        /// Gets all alarms in 'Feilmeldingslogg'
        /// </summary>
        /// <returns>
        /// Dynamic string array of all values in 'Feilmeldingslogg'
        /// </returns>
        public string[,] GetAlarm()
        {
            string[,] alarms;
            try
            {
                OpenDb(alarmTable);
                alarms = Itterate();
            }
            catch (Exception ex)
            {
                alarms = new string[0, 0];
                alarms[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return alarms;
        }
        /// <summary>
        /// Gets last alarms
        /// </summary>
        /// <param name="entities">Entities to get</param>
        /// <returns></returns>
        public string[,] GetAlarmLast(int entities = 1)
        {
            string[,] alarms;
            try
            {
                string connectionstring = String.Format((
                    "SELECT TOP {1} * FROM (SELECT * FROM {0} ORDER BY {2} DESC)"), 
                    alarmTable, entities, "Timestamp");
                OpenDbMan(connectionstring);
                alarms = Itterate();
            }
            catch (Exception ex)
            {
                alarms = new string[0, 0];
                alarms[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return alarms;
        }
        /// <summary>
        /// Gets alarms from last minute(s)
        /// </summary>
        /// <param name="minutes">Minutes to get</param>
        /// <returns></returns>
        public string[,] GetAlarmMinutes(int minutes = 1)
        {
            string[,] alarms;
            DateTime date = DateTime.Now.AddMinutes((Convert.ToDouble(minutes)) * (-1));

            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    alarmTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));

                OpenDbMan(connectionstring);
                alarms = Itterate();
            }
            catch (Exception ex)
            {
                alarms = new string[1, 1];
                alarms[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return alarms;
        }
        /// <summary>
        /// Gets alarms from last hour(s)
        /// </summary>
        /// <param name="hours">Hours to get</param>
        /// <returns></returns>
        public string[,] GetAlarmHours(int hours = 1)
        {
            string[,] alarms;
            DateTime date = DateTime.Now.AddHours((Convert.ToDouble(hours)) * (-1));

            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    alarmTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));
                OpenDbMan(connectionstring);
                alarms = Itterate();
            }
            catch (Exception ex)
            {
                alarms = new string[0, 0];
                alarms[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return alarms;
        }
        /// <summary>
        /// Gets alarms from last day(s)
        /// </summary>
        /// <param name="days">Days to get</param>
        /// <returns></returns>
        public string[,] GetAlarmDays(int days = 1)
        {
            string[,] alarms;
            DateTime date = DateTime.Now.AddDays((Convert.ToDouble(days)) * (-1));

            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    alarmTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));
                
                OpenDbMan(connectionstring);
                alarms = Itterate();
            }
            catch (Exception ex)
            {
                alarms = new string[0, 0];
                alarms[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return alarms;
        }
        /// <summary>
        /// Gets alarms from last week(s)
        /// </summary>
        /// <param name="weeks">Weeks to get</param>
        /// <returns></returns>
        public string[,] GetAlarmWeeks(int weeks = 1)
        {
            string[,] alarms;
            DateTime date = DateTime.Now.AddDays((Convert.ToDouble(weeks)) * (-7));
            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    alarmTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));
                OpenDbMan(connectionstring);
                alarms = Itterate();
            }
            catch (Exception ex)
            {
                alarms = new string[0, 0];
                alarms[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return alarms;
        }
        /// <summary>
        /// Gets alarms from last month(s)
        /// </summary>
        /// <param name="months">Months to get</param>
        /// <returns></returns>
        public string[,] GetAlarmMonths(int months = 1)
        {
            string[,] alarms;
            DateTime date = DateTime.Now.AddMonths(months * (-1));
            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    alarmTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));

                OpenDbMan(connectionstring);
                alarms = Itterate();
            }
            catch (Exception ex)
            {
                alarms = new string[0, 0];
                alarms[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return alarms;
        }
        /// <summary>
        /// Gets alarms in 'Feilmeldingslogg'
        /// </summary>
        /// <param name="values">Values to get as SQL syntax</param>
        /// <returns>
        /// Dynamic string array of all values in 'Feilmeldingslogg'
        /// </returns>
        public string[,] GetAlarm(string values)
        {
            string[,] alarms;
            try
            {
                OpenDb(alarmTable, values);
                alarms = Itterate();
                CloseDb(alarmTable);
            }
            catch (Exception ex)
            {
                alarms = new string[0, 0];
                alarms[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return alarms;
        }
        
        #endregion
        #endregion
        #region Temperature
        /// <summary>
        /// Adds a row to TemperaturLogg
        /// </summary>
        /// <param name="temp"></param>
        public void LogTemperature(string temp)
        {
            DateTime timestamp = new DateTime();
            timestamp = DateTime.Now;
            try
            {

                OpenDb(tempTable);

                DataRow row = myDatatable.NewRow();

                row["Timestamp"] = timestamp.ToString("dd.MM.yyyy HH:mm:ss");
                row["Temperatur"] = temp;

                myDatatable.AcceptChanges();
                myDatatable.Rows.Add(row);

                CloseDb(tempTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
        }
        #region get
        /// <summary>
        /// Gets all registered temperatures in TemperaturLogg
        /// </summary>
        /// <returns>Temperature table values as string</returns>
        public string[,] GetTemperature()
        {
            string[,] temperature;
            try
            {
                OpenDb(tempTable);
                temperature = Itterate();

            }
            catch (Exception ex)
            {
                temperature = new string[1, 1];
                temperature[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return temperature;
        }
        /// <summary>
        /// Gets last temperatures
        /// </summary>
        /// <param name="entities">Entities to get</param>
        /// <returns></returns>
        public string[,] GetTemperatureLast(int entities = 1)
        {
            string[,] temperature;
            try
            {
                string connectionstring = String.Format((
                    "SELECT TOP {1} * FROM (SELECT * FROM {0} ORDER BY {2} DESC)"), 
                    tempTable, entities, "Timestamp");
                OpenDbMan(connectionstring);
                temperature = Itterate();
            }
            catch (Exception ex)
            {
                temperature = new string[0, 0];
                temperature[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return temperature;
        }
        /// <summary>
        /// Gets temperatures from last minute(s)
        /// </summary>
        /// <param name="minutes">Minutes to get</param>
        /// <returns></returns>
        public string[,] GetTemperatureMinutes(int minutes = 1)
        {
            string[,] temperature;
            DateTime date = DateTime.Now.AddMinutes((Convert.ToDouble(minutes)) * (-1));

            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    tempTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));

                OpenDbMan(connectionstring);
                temperature = Itterate();
            }
            catch (Exception ex)
            {
                temperature = new string[1, 1];
                temperature[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return temperature;
        }
        /// <summary>
        /// Gets temperatures from last hour(s)
        /// </summary>
        /// <param name="hours">Hours to get</param>
        /// <returns></returns>
        public string[,] GetTemperatureHours(int hours = 1)
        {
            string[,] temperature;
            DateTime date = DateTime.Now.AddHours((Convert.ToDouble(hours)) * (-1));

            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    tempTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));
                OpenDbMan(connectionstring);
                temperature = Itterate();
            }
            catch (Exception ex)
            {
                temperature = new string[0, 0];
                temperature[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return temperature;
        }
        /// <summary>
        /// Gets temperatures from last day(s)
        /// </summary>
        /// <param name="days">Days to get</param>
        /// <returns></returns>
        public string[,] GetTemperatureDays(int days = 1)
        {
            string[,] temperature;
            DateTime date = DateTime.Now.AddDays((Convert.ToDouble(days)) * (-1));

            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    tempTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));

                OpenDbMan(connectionstring);
                temperature = Itterate();
            }
            catch (Exception ex)
            {
                temperature = new string[0, 0];
                temperature[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return temperature;
        }
        /// <summary>
        /// Gets temperatures from last week(s)
        /// </summary>
        /// <param name="weeks">Weeks to get</param>
        /// <returns></returns>
        public string[,] GetTemperatureWeeks(int weeks = 1)
        {
            string[,] temperature;
            DateTime date = DateTime.Now.AddDays((Convert.ToDouble(weeks)) * (-7));
            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    tempTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));
                OpenDbMan(connectionstring);
                temperature = Itterate();
            }
            catch (Exception ex)
            {
                temperature = new string[0, 0];
                temperature[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return temperature;
        }
        /// <summary>
        /// Gets temperatures from last month(s)
        /// </summary>
        /// <param name="months">Months to get</param>
        /// <returns></returns>
        public string[,] GetTemperatureMonths(int months = 1)
        {
            string[,] temperature;
            DateTime date = DateTime.Now.AddMonths(months * (-1));
            try
            {
                string connectionstring = String.Format((
                    "SELECT * FROM {0} WHERE {1} >= Cdate ('{2}')"),
                    tempTable, "Timestamp", date.ToString("dd.MM.yyyy HH:mm:ss"));

                OpenDbMan(connectionstring);
                temperature = Itterate();
            }
            catch (Exception ex)
            {
                temperature = new string[0, 0];
                temperature[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return temperature;
        }
        /// <summary>
        /// Gets registered temperatures in TemperaturLogg
        /// </summary>
        /// <param name="value">Values to get as SQL syntax</param>
        /// <returns>Temperature table values as string</returns>
        public string[,] GetTemperature(string value)
        {
            string[,] temperature;
            try
            {
                OpenDb(tempTable, value);
                int rows = myDatatable.Rows.Count;
                int columns = myDatatable.Columns.Count;
                temperature = new string[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        temperature[i, j] = myDatatable.Rows[i].ItemArray[j].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                temperature = new string[0, 0];
                temperature[0, 0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return temperature;
        }
        #endregion
        #endregion
        #region Settings
        /// <summary>
        /// Updates a single cell in tablesettings
        /// </summary>
        /// <param name="newSetting">New setting</param>
        /// <param name="column">name of column or type of setting</param>
        /// <param name="settingNr">The set of settings to change</param>
        public void UpdateSetting(string newSetting, int column,int settingNr)
        {

            try
            {
                OpenDb(settingsTable);

                myDatatable.AcceptChanges();

                myDatatable.Rows[settingNr][column] = newSetting;

                CloseDb(settingsTable);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
        }
        /// <summary>
        /// Gets settings from Innstillinger
        /// </summary>
        /// <param name="settingNr">Set of settings to get</param>
        /// <returns>Settings</returns>
        public string[] GetSettings(int settingNr)
        {
            string[] settings;
            try
            {
                OpenDb(settingsTable);
                int columns = myDatatable.Columns.Count;
                settings = new string[columns];

                for (int i = 0; i < columns; i++)
                {
                        settings[i] = myDatatable.Rows[settingNr].ItemArray[i].ToString();
                }

            }
            catch (Exception ex)
            {
                settings = new string[0];
                settings[0] = "N/A";

                throw ex;
            }
            finally
            {
                myAccessConnection.Close();
            }
            return settings;
        }
        #endregion
        private string[,] Itterate()
        {
            string[,] value;
            int rows = myDatatable.Rows.Count;
            int columns = myDatatable.Columns.Count;
            value = new string[rows, columns-1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 1; j < columns; j++)
                {
                    value[i, j-1] = myDatatable.Rows[i].ItemArray[j].ToString();
                }
            }
            return value;
        }
    }
}
