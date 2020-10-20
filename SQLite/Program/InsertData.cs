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
        static ProcState InsertData(ref SQLiteAPI SQLiteDB)
        /*
        ===============================================================================================
        PURPOSE:
        Insert data into the tables created.
        -----------------------------------------------------------------------------------------------
        NOTES:
        - Execution will stop at the first error.

        - This shows an example of multiple commands sent as once.
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
            // Add data to the first table
            SQLiteDB.SQL =
                "INSERT INTO SampleTable0 " +
                "(Col1, Col2) " +
                "VALUES " +
                "('Test Text ', 1);" +
                "" +
                "INSERT INTO SampleTable0 " +
                "(Col1, Col2) " +
                "VALUES " +
                "('Test1 Text1 ', 2);" +
                "" +
                "INSERT INTO SampleTable1 " + 
                "(Col3, Col4) " + 
                "VALUES " + 
                "('Test4 Text4 ', 4);";
            Results = SQLiteDB.ExecuteNonQuery();

            //=============
            // Cleanup Environment
            //=============
            // Return the results
            return Results;
        } // static ProcState InsertData
    } // class Program
} // namespace SQLite
