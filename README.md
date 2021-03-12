# ShopsRUs
A case test by Habaripay

# System Requirement
- Microsoft Visual Studio
- ASP .NETCORE >= 3

# Set Up
- Clone the project by clicking the clone button or downloading the file to your local system
- Open the cloned or downloaded project via visual studio by selecting the project file ShopsRUs.sln
- Add a migration by running the command on your package console "dotnet ef add migrations <name of migration>"
- Update database by running "dotnet ef update database"
- After updating database, run the application by clicking the play icon with the server name(IIS Express)
- After running the application, replace the served url from 'https://<Host>/weatherforecast' to 'https://<Host>/swagger'

# Important Note
- Database seeders for CustomerType, Customer, and Discount has already been included in the start up model and while running the migration commands above
- LocalDb was used as the database
- To open LocalDb got to view -> SQL Server Object Explorer -> SQL server -> (Localdb)MSSQLLocalDB
- To open your package console, go to tools -> NuGet Package Manager -> Package Manager Console

