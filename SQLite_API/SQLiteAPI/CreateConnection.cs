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
    {
        public Status CreateConnection()
        /*
        ===============================================================================================
        PURPOSE:
        Create a connection to the SQLite database based on the type of connection to use.
        -----------------------------------------------------------------------------------------------
        NOTES:
        Depending on the setting of the database connection type (DB_Conn), the connection will be set
        appropriately.
        ===============================================================================================
        */
        {
            //=============
            // Variables - Standard
            //=============
            Status Results = Status.Good;

            //=============
            // Setup Environment
            //=============
            Error = string.Empty;

            if (DB_Name == null)
            {
                Error = "Database Name is missing; ";
                Results = Status.Error;
            }

            if (DB_Path == null)
            {
                Error += "Database Path is missing; ";
                Results = Status.Error;
            }

            //=============
            // Body
            //=============
            if (Results == Status.Good)
            {
                switch(DB_Conn)
                {
                    case ConnectionType.DS:
                        ConnectionString = "Data Source=\"" + DB_Path + DB_Name + "\"; Compress = True; ";
                        conn = new SQLiteConnection(ConnectionString);
                        break;

                    case ConnectionType.URI:
                        ConnectionString = "URI=file:" + DB_Path + DB_Name + "; Compress = True; ";
                        conn = new SQLiteConnection(ConnectionString);
                        break;

                    default:
                        Error += "Unknown Database Connection; ";
                        Results = Status.Error;
                        break;
                }
            }

            //=============
            // Cleanup Environment
            //=============
            return Results;
        } // public Status CreateConnection()
    } // public partial class SQLiteAPI
} // namespace SQLite_API
