# Downing
Solution for Downing technical test.

To run this application, the connection string for a SQL Server target database must be set.

This solution uses a code-first approach for database entities.
On first run, if the database is missing it will be created (providing the user has permissions to do so).  Two tables will also be created in accordance with the instructions; Companies & Investors.  The auto-migration will add a third table _EFMigrationsHistory.

Both the database and tables can also be created in Visual Studio by running update-database in package-manager-console, with default project set to Downing.Data.

