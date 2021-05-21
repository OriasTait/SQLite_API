# SQLite_API
Standardized API for SQLite databases written in .NET Framework 4.6.1.

NOTES:
* This requires that the NuGet packate system.data.sqlite be installed in the project as well.

## SQLite_API
The DLL containing the class that standardizes the API interfacing with a SQLite database.
* CreateConnection => Create a connection to the SQLite database based on the type of connection to use.
  * Data Source
  * Uniform Resource Identifier
* ExecuteNonQuery => Execute a query to the database that does not return a dataset.
* ExecuteQuery => Execute a query to the database that returns a dataset.
* Shrink => Re-organize the database, releasing unused space back to the OS.

## SQLite
The console program that provides examples of how these interfacings work.
* Setup Environment => Example how to use CreateConnection
* CreateTables, InsertData => Example how to use ExecuteNonQuery to execute complex T-SQL, including multiple statements in one call
* ReadFromDatabase => Example how to use ExecuteQuery and obtain multiple result sets from the Query Results
* Cleanup Environment => Example of how to use Shrink