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
using ProcState = SQLite_API.SQLiteAPI.Status;

namespace SQLite_API
{
    namespace SAID_Manager
    {
        public partial class SAID
        {
            private string Obtain_Recycled_SAID(ref SQLiteAPI SQLiteDB)
            /*
            ===============================================================================================
            PURPOSE:
            Return the oldest Recycled SAID if one exists.
            -----------------------------------------------------------------------------------------------
            PARAMETERS:
            - SQLiteDB   =>  The SQLite database reference
            -----------------------------------------------------------------------------------------------
            OUTPUT:
            - The oldest recycled SAID if one has been found; else 
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
                // Obtain the oldest SAID to be recycled
                SQLiteDB.SQL =
                    "SELECT Value " +
                    "FROM SAIDs " +
                    "WHERE Type = 'Recycle' " +
                    "ORDER BY ROWID ASC " +
                    "LIMIT 1 " +
                    ";";

                //=============
                // Body
                //=============
                // If we found a record
                if (SQLiteDB.ExecuteQuery() == ProcState.Good)
                {
                    // We know the result set is 1 record with 1 field named "Value" from the SQL above, so get the value
                    foreach (DataRow r in SQLiteDB.QueryResults.Tables[0].Rows)
                    {
                        // Obtain the results
                        Results = r[SQLiteDB.QueryResults.Tables[0].Columns[0].ColumnName].ToString();

                        // Remove the recycled SAID
                        SQLiteDB.SQL =
                            "DELETE FROM SAIDs " +
                            "WHERE Type = 'Recycle' " +
                            "  AND Value = '" + Results + "'" +
                            ";";
                        SQLiteDB.ExecuteNonQuery();
                    }
                }
                else { Results = SQLiteDB.Error; }

                //=============
                // Cleanup Environment
                //=============
                // Return the results
                return Results;
            } // private string Obtain_Recycled_SAID(ref SQLiteAPI SQLiteDB)
        } // public partial class SQLiteAPI
    } // namespace SAID_Manager
} // namespace SQLite_API
