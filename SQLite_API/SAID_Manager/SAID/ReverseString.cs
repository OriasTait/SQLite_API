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
            private string ReverseString(string GivenString)
            /*
            ===============================================================================================
            PURPOSE:
            Reverse the given string
            -----------------------------------------------------------------------------------------------
            PARAMETERS:
            - GivenString   =>  The string to reverse.
            -----------------------------------------------------------------------------------------------
            OUTPUT:
            - The given string in reverse order.
            ===============================================================================================
            */
            {
                //=============
                // Setup Environment
                //=============
                // Convert the given string to an array
                char[] array = GivenString.ToCharArray();

                //=============
                // Body
                //=============
                // Reverse the Array
                Array.Reverse(array);

                // Convert the array back to a string
                string Results = new string(array);

                //=============
                // Cleanup Environment
                //=============
                // Return the results
                return Results;
            } // private string ReverseString(string GivenString)
        } // public partial class SQLiteAPI
    } // namespace SAID_Manager
} // namespace SQLite_API
