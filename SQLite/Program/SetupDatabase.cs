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
        static private ProcState SetupDatabase(ref SQLiteAPI SQLiteDB)
        /*
        ===============================================================================================
        PURPOSE:
        Setup the environment of the program.
        -----------------------------------------------------------------------------------------------
        PARAMETERS:
        SQLiteDB    =>  Reference to the SQLite database used in the application.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            ProcState Results;

            //=============
            // Initialize the database with a Data Source Connection
            //=============
            // Database Name
            SQLiteDB.DB_Name = "database.db";

            // Database Location
            SQLiteDB.DB_Path = @"D:\Work\Code\SQLite_API\SQLite_API_C#\Working\";

            // Use a connection type of Data Source
            SQLiteDB.DB_Conn = ConnType.DS;

            //=============
            // Create the database connection
            //=============
            Con.WriteLine("Creating the connection");
            Results = SQLiteDB.CreateConnection();

            if (Results == ProcState.Error)
            {
                Con.Write("Error in creating database connection: ");
                Con.WriteLine(SQLiteDB.Error);
            }
            else
            {
                Con.WriteLine("Connection made => " + SQLiteDB.ConnectionString);
            }

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // static private void SetupDatabase(ref SQLiteAPI SQLiteDB)
    } // class Program
} // namespace SQLite
