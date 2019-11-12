# Dev Readme

### Entity Framework 

Run the EF commands from Visual Studio package manger console or powershell. Note you will need the EFcore tools and SQL Server design packages installed.

##### Add Migration

`Add-Migration MigrationName`

##### Update Database

`Update-Database`

### Debugging

The solution is setup using conditional compilation symbols to either point to the hosted MockBank or a locally running version dependant on if you are running Checkout.API in debug or release mode.

If running the API locally in debug mode you will need to start an instance of Checkout.MockBank