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

namespace SQLite_API
{
    namespace SAID_Manager
    {
        public partial class SAID
        {
            public string New(ref SQLiteAPI SQLiteDB)
            /*
            ===============================================================================================
            PURPOSE:
            Obtain a new SAID to use.
            -----------------------------------------------------------------------------------------------
            PARAMETERS:
            - SQLiteDB  => Reference to the SQLite database used within the application
            -----------------------------------------------------------------------------------------------
            OUTPUT:
            - An SAID that is either recycled or is new
            ===============================================================================================
            */
            {
                //=============
                // Variables - Standard
                //=============
                // Clear the error message before attempting
                SQLiteDB.Error = string.Empty;

                // Check for a recycled number
                string Results = Obtain_Recycled_SAID(ref SQLiteDB);

                //=============
                // Body
                //=============
                // If there are no SAIDs to recycle, Create a new one
                if (Results == string.Empty)
                { Results = Obtain_New_SAID(ref SQLiteDB); }

                //=============
                // Cleanup Environment
                //=============
                return Results;
            } // public string New(ref SQLiteAPI SQLiteDB)
        } // public partial class SQLiteAPI
    } // namespace SAID_Manager
} // namespace SQLite_API
