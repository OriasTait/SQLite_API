using SQLite_API;  // Reference the SQLiteAPI Routines
using System;
using System.Collections.Generic;
using System.Data;
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
        static ProcState ReadFromDatabase(ref SQLiteAPI SQLiteDB)
        /*
        ===============================================================================================
        PURPOSE:
        Obtain some data from the database and read the results from the QueryResults object.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            ProcState Results = ProcState.Good;

            //=============
            // Setup Environment
            //=============
            SQLiteDB.SQL =
                "SELECT Col1, Col2 FROM SampleTable0; " +
                "SELECT Col3, Col4 FROM SampleTable1;";
            Results = SQLiteDB.ExecuteQuery();

            //=============
            // Body
            //=============
            //=============
            // Show some information about the results
            //=============
            if (Results == ProcState.Good)
            {
                Con.WriteLine("There are {0} tables in the result.", SQLiteDB.QueryResults.Tables.Count);

                DataTableCollection collection = SQLiteDB.QueryResults.Tables;
                for (int i = 0; i < collection.Count; i++)
                {
                    Con.WriteLine(Environment.NewLine);

                    // Table Information
                    DataTable table = collection[i];  // Collection ID
                    Con.WriteLine("Table Collection {0}: Table Name \"{1}\"", i, table.TableName);  // Table name

                    // Column Information
                    foreach (DataColumn column in SQLiteDB.QueryResults.Tables[i].Columns)
                    {
                        Con.WriteLine("Column Name: {0} => Column Type: {1}", column.ColumnName, column.DataType);
                    }

                    // We know there are 2 columns, so they are hard-coded
                    string Col1Name = SQLiteDB.QueryResults.Tables[i].Columns[0].ColumnName;
                    string Col2Name = SQLiteDB.QueryResults.Tables[i].Columns[1].ColumnName;

                    // Table Data
                    foreach (DataRow r in SQLiteDB.QueryResults.Tables[i].Rows)
                    {
                        Con.WriteLine(r[Col1Name].ToString() + " " + r[Col2Name].ToString());
                    }
                }
            }

            //=============
            // Cleanup Environment
            //=============
            // Return the results
            return Results;
        } // static int ReadFromDatabase
    } // class Program
} // namespace SQLite
