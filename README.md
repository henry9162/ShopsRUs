# ShopsRUs
A case test by Habaripay

# System Requirement
- Microsoft Visual Studio
- ASP .NETCORE >= 3

# Api Documentation Used
- Swagger

# Database Used
- LocalDB

# Set Up
- Clone the project by clicking the clone button or downloading the file to your local system
- Open the cloned or downloaded project via visual studio by selecting the project file ShopsRUs.sln
- Add a migration by running the command on your package console "dotnet ef add migrations <name of migration>"
- Update database by running "dotnet ef update database" in package console.
- After updating database, run the application by clicking the play icon with the server name(IIS Express)

# Seeding Database 
- Three (3) API endpoint for CustomerType, Customer, and Discount has been created to seed static data into the DB for test purposes.
- The API names are CustomerTypeSeeder, CustomerSeeder, and DiscountSeeder.
- First run the CustomerTypeSeeder in other to establish relationship and prevent foreign key constraints.

# Looking forward to meeting with you!

