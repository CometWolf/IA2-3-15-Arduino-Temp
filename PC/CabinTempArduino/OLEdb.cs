using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace CabinTempArduino
{
    class OLEdb
    {
        protected static OleDbConnection myAccessConnection;
        protected static OleDbCommand myAccessCommand;
        protected static OleDbCommand myCommand;
        protected static OleDbDataAdapter myDataAdapter;
        protected static OleDbCommandBuilder myCommandBuilder;
        protected static DataTable myDatatable;
        static string connectionString;
        /// <summary>
        /// Initializes an instance of the OLEDB class
        /// Provider =  Microsoft.ACE.OLEDB.12.0
        /// </summary>
        /// <param name="DbPath">Path to the database</param>
        public OLEdb(string DbPath)
        {
            connectionString =
                "Provider=Microsoft.ACE.OLEDB.12.0;" +
                "Data Source=" +
                DbPath +
                ";" +
                "Persist Security Info=False";
            try
            {
                myAccessConnection = new OleDbConnection(connectionString);
                myAccessCommand = new OleDbCommand("SELECT * FROM Brukerinformasjon", myAccessConnection);

                myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myDatatable = new DataTable();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Runs any given query
        /// </summary>
        /// <param name="query">Query to run</param>
        public void RunQuery(string query)
        {
            try
            {
                myAccessConnection.Open();
                myAccessCommand = new OleDbCommand(query, myAccessConnection);
                myAccessCommand.ExecuteNonQuery();
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
        /// Opens a connection to the database
        /// and reads the values in table "table" to a dataset
        /// </summary>
        /// <param name="table">Table to read</param>
        protected static void OpenDb(string table)
        {
            myAccessCommand.CommandText = string.Format("SELECT * FROM {0}", table);
            myDatatable = new DataTable();
            myAccessConnection.Open();
            myDataAdapter.Fill(myDatatable);
            
        }
        /// <summary>
        /// Opens a connection to the database
        /// and reads the chosen values in table "table" to a dataset
        /// </summary>
        /// <param name="table">Table to read</param>
        /// <param name="value">Values to select as SQL</param>
        protected static void OpenDb(string table, string value)
        {
            myAccessCommand.CommandText = string.Format("SELECT {0} FROM {1}", value, table);
            myDatatable = new DataTable();
            myAccessConnection.Open();
            myDataAdapter.Fill(myDatatable);
        }
        protected static void OpenDbMan(string selectQuery)
        {
            myAccessCommand.CommandText = selectQuery;
            myDatatable = new DataTable();
            myAccessConnection.Open();
            myDataAdapter.Fill(myDatatable);
        }
        /// <summary>
        /// Commits the values in dataset to the database
        /// and closes the connection
        /// </summary>
        /// <param name="table">Table to commit</param>
        protected static void CloseDb(string table)
        {
            myCommandBuilder = new OleDbCommandBuilder(myDataAdapter);
            myCommandBuilder.QuotePrefix = "[";
            myCommandBuilder.QuoteSuffix = "]";

            myDataAdapter.UpdateCommand = myCommandBuilder.GetUpdateCommand();

            myDataAdapter.Update(myDatatable);
            myAccessConnection.Close();
        }
        protected static void CloseDbMan(string updateCommand)
        {
            //myDataAdapter.UpdateCommand.CommandType = CommandType.Text;
            //myDataAdapter.UpdateCommand.CommandText = updateCommand;

            myCommand = new OleDbCommand(updateCommand, myAccessConnection);
            myCommand.ExecuteNonQuery();

            myAccessConnection.Close();
        }
    }
}
