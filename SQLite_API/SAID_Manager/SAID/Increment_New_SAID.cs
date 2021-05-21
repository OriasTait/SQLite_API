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
            private string Increment_New_SAID(string SAID)
            /*
            ===============================================================================================
            PURPOSE:
            Increment the given SAID by 1.
            -----------------------------------------------------------------------------------------------
            PARAMETERS:
            - SAID  =>  The SAID to increment
            -----------------------------------------------------------------------------------------------
            OUTPUT:
            - The new SAID if it could be incremented; otherwise the return value will be NULL.
            -----------------------------------------------------------------------------------------------
            NOTES:
            - The only way an SAID could not be incremented is if all values in the array are at the
              maximum ASCII value.
            ===============================================================================================
            */
            {
                //=============
                // Variables - Standard
                //=============
                //string Results = string.Empty;
                int ASCII_Min = 32;
                int ASCII_Max = 126;
                bool Incremented = false;

                //=============
                // Setup Environment
                //=============
                // Reverse the string
                string Results = ReverseString(SAID);

                // Identify the maximum length of the array
                int MaxLen = Results.Length - 1;  // Arrays start at 0, not 1

                //=============
                // Body
                //=============
                // Create a character array
                char[] charArr = Results.ToCharArray();

                // Parse the array to identify where to increment
                for (int i = 0; i < MaxLen; i++)
                {
                    // Check if we can perform a straight increment
                    if ((charArr[i] >= ASCII_Min) && (charArr[i] < ASCII_Max))
                    {
                        // Increment the SAID
                        charArr[i] = (char)(charArr[i] + 1);

                        // Set the flag to indicate the SAID has been incremented
                        Incremented = true;
                    }
                    else // Current ASCII value at max
                    {
                        if ((i + 1 <= MaxLen) && charArr[i + 1] < ASCII_Max)
                        {
                            // Increment the SAID
                            charArr[i + 1] = (char)((int)charArr[i + 1] + 1);

                            // Set the flag to indicate the SAID has been incremented
                            Incremented = true;
                        }
                    }

                    // If we were able to increment and are not on the first element of the array
                    if ((Incremented == true) && (i > 0))
                    {
                        // Set everything examined so far to the starting value (32)
                        while (i >= 0)
                        {
                            // Set the current location in the array to the starting value
                            charArr[i] = (char)(32);

                            // Decrement the array index
                            i--;
                        }

                        // Exit the loop
                        i = MaxLen;
                    }
                    // Incremented at the first element
                    else if (Incremented == true)
                    { i = MaxLen; }
                }

                // if the SAID could not be incremented, send back an error
                if (Incremented == false)
                { charArr = null; }

                //=============
                // Cleanup Environment
                //=============
                if (charArr != null)
                {
                    // Convert array back to a string
                    Results = new string(charArr);

                    // Reverse the string back to the original way
                    Results = ReverseString(Results);
                }
                else
                { Results = null; }

                //=============
                // Cleanup Environment
                //=============
                // Return the results
                return Results;
            } // private string Increment_New_SAID(string SAID)
        } // public partial class SQLiteAPI
    } // namespace SAID_Manager
} // namespace SQLite_API
