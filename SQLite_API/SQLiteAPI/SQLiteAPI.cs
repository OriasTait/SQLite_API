using System;
using System.Collections.Generic;
using System.Data;          // System data objects and routines
using System.Data.SQLite;   // NuGet Package => system.data.sqlite
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_API
{
    public partial class SQLiteAPI
    /*
    ===============================================================================================
    PURPOSE:
    Standardize the Aplication Programming Interface (API) to an SQLite database.
    -----------------------------------------------------------------------------------------------
    NOTES:
    - This library leverages the NuGet Package system.data.sqlite.  It is required to include this
      package into this project.

    - If the package compilation generates the error:
      'Unable to load DLL 'SQLite.Interop.dll': The specified module could not be found. 
      This is resolved by adding the system.data.sqlite NuGet Package to the Main program; Even
      though it is never touched in the main, this causes the required dll to be copied to the
      appropriate bin directory.
    ===============================================================================================
    */
    {
        //=============
        // Enumerations
        //=============
        public enum ConnectionType
        {
            DS,  // Data Source; Default value
            URI  // Uniform Resource Identifier
        }

        public enum Status
        {
            Error,
            Good
        }

        //=============
        // Fields - Standard
        //=============
        public string DB_Name;          // Name of the database
        public string DB_Path;          // Location of the database
        public string Error;            // Current Error message

        //=============
        // Fields - SQLite Specific
        //=============
        public ConnectionType DB_Conn;  // Database Connection Type
        public string ConnectionString; // Connection String
        public SQLiteConnection conn;   // SQLite Connection
        public DataSet QueryResults;    // Results of a query of the database
        public string SQL;              // SQLite SQL text
        private SQLiteCommand SQL_cmd;  // SQLite SQL Command
    } // public partial class SQLiteAPI
} // namespace SQLite_API
