using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace CabinTempArduino
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

                myDatatable.Rows[id]["Etternavn"] = surName;
                myDatatable.Rows[id]["Fornavn"] = firstName;
                myDatatable.Rows[id]["Brukernavn"] = userName;
                myDatatable.Rows[id]["Passord"] = password;
                myDatatable.Rows[id]["E-post"] = email;
                myDatatable.Rows[id]["Telefon"] = phone;

                //myDatatable.Rows[id].SetModified();
                myDatatable.AcceptChanges();

                CloseDb(subscriberTable);

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
        public string SearchUsername(string username)
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
        return subscribers[index,3];
        }
        public int getUserID(string username)
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
        public int getIndex(string username)
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
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="message"></param>
        /// <param name="alarmID"></param>
        /// <param name="temp"></param>
        public void LogAlarm(string date, string time, string message, string alarmID, string temp)
        {
            try
            {

                OpenDb(alarmTable);

                DataRow row = myDatatable.NewRow();

                row["Dato"] = date;
                row["Tid"] = time;
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
                int rows = myDatatable.Rows.Count;
                int columns = myDatatable.Columns.Count;
                alarms = new string[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        alarms[i, j] = myDatatable.Rows[i].ItemArray[j].ToString();                        
                    }
                }
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
                int rows = myDatatable.Rows.Count;
                int columns = myDatatable.Columns.Count;
                alarms = new string[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        alarms[i, j] = myDatatable.Rows[i].ItemArray[j].ToString();
                    }
                }
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
        #region Temperature
        /// <summary>
        /// Adds a row to TemperaturLogg
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="temp"></param>
        public void LogTemperature(string date, string time, string temp)
        {
            DateTime timestamp = new DateTime();
            timestamp = DateTime.Now;
            try
            {

                OpenDb(tempTable);

                DataRow row = myDatatable.NewRow();

                //row["Dato"] = timestamp.Date.ToString();
                //row["Tid"] = timestamp.TimeOfDay.ToString();
                //row["Temperatur"] = temp;

                row["Dato"] = date;
                row["Tid"] = time;
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
                int rows = myDatatable.Rows.Count;
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

    }
}
