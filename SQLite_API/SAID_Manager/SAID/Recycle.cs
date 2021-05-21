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
            public void Recycle(ref SQLiteAPI SQLiteDB, string OldSAID)
            /*
            ===============================================================================================
            PURPOSE:
            Recycle the given SAID
            -----------------------------------------------------------------------------------------------
            PARAMETERS:
            - SQLiteDB  => Reference to the SQLite database used within the application
            - OldSAID   => The SAID to recycle
            ===============================================================================================
            */
            {
                //=============
                // Body
                //=============
                SQLiteDB.SQL =
                    "INSERT INTO SAIDs " +
                    "(Type, Value) " +
                    "VALUES " +
                    "('Recycle', '" + OldSAID + "') " +
                    ";";
                SQLiteDB.ExecuteNonQuery();
            }
        } // public partial class SQLiteAPI
    } // namespace SAID_Manager
} // namespace SQLite_API
