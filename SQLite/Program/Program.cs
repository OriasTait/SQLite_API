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
        static void Main(string[] args)
        {
            //=============
            // Variables - Standard
            //=============
            SQLiteAPI SQLiteDB = new SQLiteAPI();  // New instance of SQLite Database
            ProcState Results;

            //=============
            // Setup Environment
            //=============
            // Initialize the database with a Data Source Connection
            SQLiteDB.DB_Name = "database.db";  // Database Name
            SQLiteDB.DB_Path = @"D:\Work\Code\SQLite_API\Working\";  // Database Location
            SQLiteDB.DB_Conn = ConnType.DS;  // Use a connection type of Data Source

            // Create the database connection
            Con.WriteLine("Creating the connection");
            Results = SQLiteDB.CreateConnection();

            if (Results == ProcState.Error)
            {
                Con.Write("Error in creating database connection: ");
                Con.WriteLine(SQLiteDB.Error);
            }

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
            // Body
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

            //=============
            // Pause
            //=============
            Con.WriteLine(Environment.NewLine);
            Con.WriteLine("Press <Enter> to continue...");
            Con.ReadLine();
        } // static void Main
    } // class Program
} // namespace SQLite
