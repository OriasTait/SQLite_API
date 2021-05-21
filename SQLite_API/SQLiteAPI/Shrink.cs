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
        public Status Shrink()
        /*
        ===============================================================================================
        PURPOSE:
        Re-organize the database, releasing unused space back to the OS.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - This leverages the SQLite command "VACUUM".  The VACUUM command rebuilds the database file,
          repacking it into a minimal amount of disk space.
          Reference: https://www.sqlite.org/lang_vacuum.html
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
            Error = string.Empty;

            //=============
            // Body
            //=============
            try
            {
                // Create an instance of the command
                SQL_cmd = conn.CreateCommand();   // Create SQLite Command instance
                SQL_cmd.CommandText = "VACUUM;";

                // Execute the command
                conn.Open();
                SQL_cmd.ExecuteNonQuery();
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

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // public Status Shrink
    } // public partial class SQLiteAPI
} // namespace SQLite_API
