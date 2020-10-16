using SQLite_API;  // Reference the SQLiteAPI Routines
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//=============
// Aliases
//=============
using Con = System.Console;
using ConnType = SQLite_API.SQLiteAPI.ConnectionType;
using ProcState = SQLite_API.SQLiteAPI.Status;

namespace SQLite
{
    partial class Program
    {
        static ProcState CreateTables(ref SQLiteAPI SQLiteDB)
        /*
        ===============================================================================================
        PURPOSE:
        Create the tables in the database that will be used.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - Execution will stop at the first error.

        - While it is possible that these two commands could be entered as one complex command; this
          shows an example of how the execution of the first will affect the execution of the second.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            ProcState Results = ProcState.Good;

            //=============
            // Body
            //=============
            // Create the first table
            SQLiteDB.SQL =
                "DROP TABLE IF EXISTS SampleTable0; " +
                "CREATE TABLE SampleTable0 " +
                "(" +
                " Col1 VARCHAR(20), " +
                " Col2 INT " +
                ")";
            Results = SQLiteDB.ExecuteNonQuery();

            // Create the second table
            if (Results == ProcState.Good)
            {
                SQLiteDB.SQL =
                    "DROP TABLE IF EXISTS SampleTable1; " +
                    "CREATE TABLE SampleTable1 " +
                    "(" +
                    " Col3 VARCHAR(20), " +
                    " Col4 INT " +
                    ");";
                Results = SQLiteDB.ExecuteNonQuery();
            }

            //=============
            // Cleanup Environment
            //=============
            // Return the results
            return Results;
        } // static ProcState CreateTables
    } // class Program
} // namespace SQLite
