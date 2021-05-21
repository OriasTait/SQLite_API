using System;
using System.Collections.Generic;
using System.Data;          // System data objects and routines
using System.Data.SQLite;   // NuGet Package => system.data.sqlite
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//=============
// Aliases
//=============
using Con = System.Console;
using ProcState = SQLite_API.SQLiteAPI.Status;

namespace SQLite_API
{
    namespace SAID_Manager
    {
        public partial class SAID
        {
            private string Obtain_New_SAID(ref SQLiteAPI SQLiteDB)
            /*
            ===============================================================================================
            PURPOSE:
            Return the new SAID from the SAIDs table and update table entry to the next incremental value.
            -----------------------------------------------------------------------------------------------
            PARAMETERS:
            - SQLiteDB   =>  The SQLite database reference
            -----------------------------------------------------------------------------------------------
            OUTPUT:
            - The new SAID from the table SAIDs.
            ===============================================================================================
            */
            {
                //=============
                // Variables - Standard
                //=============
                string Results = string.Empty;

                //=============
                // Setup Environment
                //=============
                // Obtain the new SAID
                SQLiteDB.SQL =
                    "SELECT Value " +
                    "FROM SAIDs " +
                    "WHERE Type = 'New' " +
                    ";";

                //=============
                // Body
                //=============
                if (SQLiteDB.ExecuteQuery() == ProcState.Good)
                {
                    // Access the data using the DataRow class and parse the results
                    foreach (DataRow r in SQLiteDB.QueryResults.Tables[0].Rows)
                    {
                        // Obtain the results of the first table, first column in the dataset
                        Results = r[SQLiteDB.QueryResults.Tables[0].Columns[0].ColumnName].ToString();  // Procedurally identify the column name for the DataRow
                    }

                    // Increment the SAID received
                    string SAID_Inc = Increment_New_SAID(Results);
                    if (SAID_Inc != null)
                    {
                        Con.WriteLine("Incremented SAID => {0}", SAID_Inc);
                    }
                    else
                    {
                        Con.WriteLine("Incremented SAID => {0}", "Max SAID reached.");
                        SQLiteDB.Error = "Maximumn SAID has been reached.";
                    }

                    // Save incremented SAID
                    SQLiteDB.SQL =
                        "UPDATE SAIDs " +
                        "SET Value = '"+ SAID_Inc +"' " +
                        " WHERE Type = 'New' " +
                        ";";
                    SQLiteDB.ExecuteNonQuery();
                }
                else { Results = SQLiteDB.Error; }

                //=============
                // Cleanup Environment
                //=============
                // Return the results
                return Results;
            } // private string Obtain_New_SAID(ref SQLiteAPI SQLiteDB)
        } // public partial class SQLiteAPI
    } // namespace SAID_Manager
} // namespace SQLite_API
