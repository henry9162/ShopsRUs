# ShopsRUs
A case test by Habaripay

# System Requirement
- Microsoft Visual Studio
- ASP .NETCORE >= 3

# Api Documentation Used
- Swagger

# Database Used
- LocalDB

# Table Of Content

- ** Set Up **
- ** Seeding Database **
- ** Database Design **
- ** Get Total Invoice Amount Given A Bill And Generate Invoice **
- **  Code Base and Structure **

# Set Up
- Clone the project by clicking the clone button or downloading the file to your local system
- Open the cloned or downloaded project via visual studio by selecting the project file ShopsRUs.sln
- Add a migration by running the command on your package console "dotnet ef add migrations <name of migration>"
- Update database by running "Update-Database" in package manager console.
- After updating database, run the application by clicking the play icon with the server name(e.g IIS Express)

# Seeding Database 
- Three (3) API endpoint for CustomerType, Customer, and Discount has been created to seed static data into the DB for test purposes.
- The API names are CustomerTypeSeeder, CustomerSeeder, and DiscountSeeder.
- After the application is served, seeding should be done once and first in this particular order: (1) CustomerTypeSeeder, (2) CustomerSeeder, (3) DiscountSeeder

# Database Design 
For the purpose of this challenge, Four (4) database tables were created which are Customer, CustomerType, Discount, and Invoice Tables.
Below are descriptions of the table relationships:

## Table Relationship
- A ONE-to-ONE relationship exist betwen Customer and CustomerType such that a customer can only have one (1) customerType.
- Also a ONE-to-ONE relationship exist between Discount and CustomerType such that a discount can only belong to a specific customerType.
- Finally, a ONE-to-ONE relationship exist between Invoice and Customer such that an invoice can only belong to a specific customer.

## Customer Table
The customer table comprises of the following entities
- Id: A Guid that serves as primary key.
- FirstName: A string that serves as customer first name.
- LastName: A string that serves as customer last name.
- Email: A string that serves as customer email address.
- CustomerTypeId: A Guid and foreign key that establishes its relationship with CustomerType table.

## CustomerType Table
The CustomerType table comprises of the following entities
- Id: A Guid that serves as primary key.
- Name: A String that serves as the name

For the purpose of this challenge, four (4) specific CustomerType was used which are described below:
(1) Affiliate - Individuals with a percentage dicount of 10%
(2) Employee  - Individuals with a percentage discount of 30%
(3) OldCustomers - Customers above 2 years with a percentage discount of 5%
(4) NewCustomers - Customers below 2 years, having a discount of $5 on every $100.

## Discount Table
The discount table comprises of the following entities
- Id: A Guid that serves as primary key.
- Key: A string whose value serves as a customerType identifier e.g 'Affiliate'.
- Value: A decimal that serves as the actual dicount.
- IsPercent: A boolean that indicate if its percentage based.
- IsFixed: A boolean that indicate if its fixed based.
- CustomerTypeId: A Guid and foreign key that establishes its relationship with CustomerType table.

Note: The discount relationship with customerType ensures a customer is entitled to only one dicount. 

## Invoice Table
The discount table comprises of the following entities
- Id: A Guid that serves as primary key.
- CustomerTypeId: A Guid and foreign key that establishes its relationship with CustomerType table.
- TotalAmount: A double that serves as the bill amount
- TotalInvoiceAmount: A double that serves as the total invoice amount calculated using customer discount.  

# Get Total Invoice Amount Given A Bill And Generate Invoice
- The GenerateInvoice Api is used to generate an invoice and get the total invoice amount given a bill amount e.g $1000.
- You can do is by supplying a customerId and the bill amount to the API request.
- The customerId can be gotten from the result of the GetAllCustomers API.

Note: 
**Since each customer supplied via customerId has a customertype relationship, the GenerateInvoice Api automatically uses this relationship to determine and apply the appropriate discount accessible for that customer.**

# Code Base and Structure
- All interfaces are located in the services folder.
- Implementations are located in the repository folder.
- Database Context are located in the data folder.
- Utility classes and hard codes are located in the HardCodes folder




