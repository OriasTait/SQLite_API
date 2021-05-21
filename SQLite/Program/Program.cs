using SQLite_API;  // Reference the SQLiteAPI Routines
using SQLite_API.SAID_Manager;  // Reference the SAID Routines
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
        static void Main(/*string[] args*/)
        {
            //=============
            // Variables - Standard
            //=============
            SAID AppSAID = new SAID();  // New instance of the SAID
            SQLiteAPI SQLiteDB = new SQLiteAPI();  // New instance of SQLite Database
            ProcState Results;

            //=============
            // Setup Environment
            //=============
            Results = SetupDatabase(ref SQLiteDB);

            //=============
            // Work with SAIDs
            //=============
            Con.WriteLine(Environment.NewLine);
            Con.WriteLine("Work with SAIDs");

            AppSAID.Initialize(ref SQLiteDB);
            
            // Obtain a new SAID
            string NewSAID = AppSAID.New(ref SQLiteDB);

            //=============
            //=============
            // Duplicate the following for all processing at this level; use the ProcState to identify appropriate errors to indicate in the error field
            //=============
            //=============
            if (SQLiteDB.Error != string.Empty)
            { Con.WriteLine("New SAID => {0}", NewSAID); }
            else
            { Con.WriteLine("New SAID => {0}", SQLiteDB.Error); }

            // Recycle the SAID
            AppSAID.Recycle(ref SQLiteDB, NewSAID);

            //=============
            // Work with Tables
            //=============
            // Create the appropriate tables
            Con.WriteLine(Environment.NewLine);
            Con.WriteLine("Creating the tables.");
            if (Results == ProcState.Good)
            {
                Results = CreateTables(ref SQLiteDB);
                if (Results == ProcState.Error)
                {
                    Con.Write("Error in creating database tables: ");
                    Con.WriteLine(SQLiteDB.Error);
                }
            }

            // Populate the tables with data
            Con.WriteLine(Environment.NewLine);
            Con.WriteLine("Adding data to the tables.");
            if (Results == ProcState.Good)
            {
                Results = InsertData(ref SQLiteDB);
                if (Results == ProcState.Error)
                {
                    Con.Write("Error in adding data to the tables: ");
                    Con.WriteLine(SQLiteDB.Error);
                }
            }

            //=============
            // Read from Tables
            //=============
            // Read information from the database
            Con.WriteLine(Environment.NewLine);
            Con.WriteLine("Reading from the database.");
            if (Results == ProcState.Good)
            {
                Results = ReadFromDatabase(ref SQLiteDB);
                if (Results == ProcState.Error)
                {
                    Con.Write("Error reading from database: ");
                    Con.WriteLine(SQLiteDB.Error);
                }
            }

            //=============
            // Cleanup Environment
            //=============
            Con.WriteLine(Environment.NewLine);
            Con.WriteLine("Shrink the database.");
            if (Results == ProcState.Good)
            {
                Results = SQLiteDB.Shrink();
                if (Results == ProcState.Error)
                {
                    Con.Write("Error reading from database: ");
                    Con.WriteLine(SQLiteDB.Error);
                }
            }

            //=============
            // Pause
            //=============
            Con.WriteLine(Environment.NewLine);
            Con.WriteLine("Press <Enter> to continue...");
            Con.ReadLine();
        } // static void Main
    } // class Program
} // namespace SQLite
