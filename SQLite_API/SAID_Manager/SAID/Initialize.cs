using System;
using System.Collections.Generic;
using System.Data;          // System data objects and routines
using System.Data.SQLite;   // NuGet Package => system.data.sqlite
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_API
{
    namespace SAID_Manager
    {
        public partial class SAID
        {
            public void Initialize(ref SQLiteAPI SQLiteDB)
            /*
            ===============================================================================================
            PURPOSE:
            Initialize the SAID information to be used within the application.
            -----------------------------------------------------------------------------------------------
            PARAMETERS:
            SQLiteDB    =>  Reference to the SQLite Database
            -----------------------------------------------------------------------------------------------
            NOTES:
            - It is assumed that the given database has been configured and is able to be connected to.
            - It is assumed that if the table SAIDs exists, it is associated with this class.
            ===============================================================================================
            */
            {
                //=============
                // Remove the SAIDs table
                //=============
                SQLiteDB.SQL =
                    "DROP TABLE IF EXISTS SAIDs " +
                    ";";
                SQLiteDB.ExecuteNonQuery();

                //=============
                // Create the SAIDs table
                //=============
                SQLiteDB.SQL =
                    "CREATE TABLE SAIDs " +
                    "(" +
                    " Type VARCHAR(20), " +
                    " Value CHAR(40) " +
                    ") " +
                    ";";
                SQLiteDB.ExecuteNonQuery();

                //=============
                // Create indexes on the SAIDs table
                //=============
                SQLiteDB.SQL =
                    "CREATE INDEX ndx_KeyFields " +
                    "ON SAIDs(Type ASC) " +
                    ";";
                SQLiteDB.ExecuteNonQuery();

                //=============
                // Create the initial SAID Value
                //=============
                SQLiteDB.SQL =
                    "INSERT INTO SAIDs " +
                    "(Type, Value) " +
                    "VALUES " +
                    "('New', '                                        ') " +
                    ";";

                SQLiteDB.ExecuteNonQuery();
            } // public void Initialize(ref SQLiteAPI SQLiteDB)
        } // public partial class SQLiteAPI
    } // namespace SAID_Manager
} // namespace SQLite_API
