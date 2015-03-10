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

                DataRow row = myDataset.Tables[table].NewRow();

                row["Etternavn"] = surName;
                row["Fornavn"] = firstName;
                row["Brukernavn"] = userName;
                row["Passord"] = password;
                row["E-post"] = email;
                row["Telefon"] = phone;

                myDataset.AcceptChanges();
                myDataset.Tables[table].Rows.Add(row);

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

                myDataset.Tables[table].Rows[userID].Delete();

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

                int rows = myDataset.Tables[table].Rows.Count;
                int columns = myDataset.Tables[table].Columns.Count;

                subscribers = new string[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        subscribers[i, j] = myDataset.Tables[table].Rows[i].ItemArray[j].ToString();
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

                DataRow row = myDataset.Tables[table].NewRow();

                row["Dato"] = date;
                row["Tid"] = time;
                row["Feilmelding"] = message;
                row["AlarmID"] = alarmID;
                row["Temperatur"] = temp;

                myDataset.AcceptChanges();
                myDataset.Tables[table].Rows.Add(row);

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
            string table = "Feilmeldingslogg";
            try
            {
                OpenDb(table);
                int rows = myDataset.Tables[table].Rows.Count;
                int columns = myDataset.Tables[table].Columns.Count;
                alarms = new string[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        alarms[i, j] = myDataset.Tables[table].Rows[i].ItemArray[j].ToString();                        
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

                DataRow row = myDataset.Tables[table].NewRow();

                row["Dato"] = date;
                row["Tid"] = time;
                row["Temperatur"] = temp;

                myDataset.AcceptChanges();
                myDataset.Tables[table].Rows.Add(row);

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
        public string[,] GetTemperature()
        {
            string[,] temperature;
            string table = "Feilmeldingslogg";
            try
            {
                OpenDb(table);
                int rows = myDataset.Tables[table].Rows.Count;
                int columns = myDataset.Tables[table].Columns.Count;
                temperature = new string[rows, columns];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        temperature[i, j] = myDataset.Tables[table].Rows[i].ItemArray[j].ToString();
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
    }
}
