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
        /// Initializes an instance of the Database class
      /// </summary>
      /// <param name="DbPath">Path to Database</param>
        public Database(string DbPath) : base(DbPath)
        {
            
        }
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
            string table = "BrukerInformasjon";

            try
            {

                OpenDb(table);

                DataRow row = myDatatable.NewRow();

                row["Etternavn"] = surName;
                row["Fornavn"] = firstName;
                row["Brukernavn"] = userName;
                row["Passord"] = password;
                row["E-post"] = email;
                row["Telefon"] = phone;

                myDatatable.AcceptChanges();
                myDatatable.Rows.Add(row);

                CloseDb(table);
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
            string table="Brukerinformasjon";
            try
            {

                OpenDb(table);

                myDatatable.Rows[userID].Delete();

                CloseDb(table);

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
        /// Gets all subscribers in 'BrukerInformasjon'
        /// </summary>
        /// <returns>
        /// Dynamic string array of all values in 'BrukerInformasjon'
        /// </returns>
        public string[,] GetSubscribers()
        {
            string[,] subscribers;
            string table = "BrukerInformasjon";
            try
            {
                OpenDb(table);

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
        /// Adds an alarm to Feilmeldingslogg
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="message"></param>
        /// <param name="alarmID"></param>
        /// <param name="temp"></param>
        public void LogAlarm(string date, string time, string message, string alarmID, string temp)
        {
            string table = "Feilmeldingslogg";

            try
            {

                OpenDb(table);

                DataRow row = myDatatable.NewRow();

                row["Dato"] = date;
                row["Tid"] = time;
                row["Feilmelding"] = message;
                row["AlarmID"] = alarmID;
                row["Temperatur"] = temp;

                myDatatable.AcceptChanges();
                myDatatable.Rows.Add(row);

                CloseDb(table);
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
            string table = "TemperaturLogg";
            try
            {
                OpenDb(table);
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
                CloseDb(table);
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
            string table = "Feilmeldingslogg";
            try
            {
                OpenDb(table, values);
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
                CloseDb(table);
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
        /// Adds a row to TemperaturLogg
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="temp"></param>
        public void LogTemperature(string date, string time, string temp)
        {
            string table = "TemperaturLogg";

            try
            {

                OpenDb(table);

                DataRow row = myDatatable.NewRow();

                row["Dato"] = date;
                row["Tid"] = time;
                row["Temperatur"] = temp;

                myDatatable.AcceptChanges();
                myDatatable.Rows.Add(row);

                CloseDb(table);
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
            string table = "Feilmeldingslogg";
            try
            {
                OpenDb(table);
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
            string table = "Feilmeldingslogg";
            try
            {
                OpenDb(table, value);
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
        /// Updates a single cell in tablesettings
        /// </summary>
        /// <param name="newSetting">New setting</param>
        /// <param name="columnName">name of column or type of setting</param>
        /// <param name="settingNr">The set of settings to change</param>
        public void UpdateSetting(string newSetting, string columnName,int settingNr)
        {
            string table = "Innstillinger";

            try
            {

                OpenDb(table);

                myDatatable.AcceptChanges();

                myDatatable.Rows[settingNr][columnName] = newSetting;

                CloseDb(table);
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
            string table = "Innstillinger";
            try
            {
                OpenDb(table);
                int rows = myDatatable.Rows.Count;
                int columns = myDatatable.Columns.Count;
                settings = new string[columns];

                for (int i = 0; i < rows; i++)
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

    }
}
