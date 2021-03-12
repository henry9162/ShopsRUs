# ShopsRUs
A case test by Habaripay

# System Requirement
- Microsoft Visual Studio
- ASP .NETCORE >= 3

# Api Documentation Used
- Swagger

# Set Up
- Clone the project by clicking the clone button or downloading the file to your local system
- Open the cloned or downloaded project via visual studio by selecting the project file ShopsRUs.sln
- Add a migration by running the command on your package console "dotnet ef add migrations <name of migration>"
- Update database by running "dotnet ef update database" in package console.
- After updating database, run the application by clicking the play icon with the server name(IIS Express)

# Important Note
- Database seeder for CustomerType has already been included in the start up model and while running the migration commands above.
- LocalDb was used as the database
- Also an api for seeding customer details have been provided (CustomerSeeder), use it once to seed Customer data to db.
- To open LocalDb, go to view -> SQL Server Object Explorer -> SQL server -> (Localdb)MSSQLLocalDB
- To open your package console, go to tools -> NuGet Package Manager -> Package Manager Console

# Guide to Use Api
- We would need to create 4 discount records that meet the requirement to get the total invoive given a bill, 
- Such record represent discount for Affiliate, Employee, customer of over 2 years, and customers below 2 years but over a $100 bill transaction.
- To calculate the total invoice amount, we would need to supply a customerId, and bill Amount, this would now be calculated based on the customer type to return the dicounted amount the customer would pay.
- Unit Testing is done last

# Looking forward to meeting with you!

