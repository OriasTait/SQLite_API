using System;
using System.Collections.Generic;
using System.Data;          // System data objects and routines
using System.Data.SQLite;   // NuGet Package => system.data.sqlite
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_API
{
    public partial class SQLiteAPI
    {
        public Status ExecuteQuery()
        /*
        ===============================================================================================
        PURPOSE:
        Execute a query to the database that returns a dataset.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - An instance of the object SQLiteCommand is created and destroyed each time this is called.
          This allows for the calling routines to only be concerned about the query to be sent, not
          the maintence routines associated with executing the query.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            Status Results = Status.Good;

            //=============
            // Setup Environment
            //=============
            // Error message
            Error = string.Empty;

            //=============
            // Body
            //=============
            try
            {
                // Create an instance of the command
                SQL_cmd = conn.CreateCommand();   // Create SQLite Command instance
                SQL_cmd.CommandText = SQL;

                // Create Query Results
                SQLiteDataAdapter da = new SQLiteDataAdapter(SQL_cmd.CommandText, conn);
                QueryResults = null;  // Ensure the dataset is empty before continuing
                QueryResults = new DataSet();

                // Execute the command
                conn.Open();
                da.Fill(QueryResults);
            }
            catch (SQLiteException ex)
            {
                // Save the error message
                Error = ex.Message;
                Results = Status.Error;
            }

            //=============
            // Cleanup Environment
            //=============
            finally
            {
                conn.Close();   // Close the connection the database
                SQL_cmd.Dispose();  // Remove the command from memory
                SQL = string.Empty;  // Ensure the SQL is empty
            }

            // Return the results
            return Results;
        } // public Status ExecuteNonQuery
    } // public partial class SQLiteAPI
} // namespace SQLite_API
