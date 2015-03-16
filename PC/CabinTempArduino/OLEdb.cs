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
        protected static OleDbDataAdapter myDataAdapter;
        protected static OleDbCommandBuilder myCommandBuilder;
        protected static DataSet myDataset;
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

                myDataset = new DataSet();

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
        /// and reads the values i table "table" to a dataset
        /// </summary>
        /// <param name="table">Table to read</param>
        protected static void OpenDb(string table)
        {
            myAccessCommand.CommandText = "SELECT * FROM " + table;
            myDataset = new DataSet();
            myAccessConnection.Open();
            myDataAdapter.Fill(myDataset, table);
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

            myDataAdapter.Update(myDataset.Tables[table]);
            myAccessConnection.Close();
        }
        
    }
}
