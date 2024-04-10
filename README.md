# RSMIntegrationsAPISession

## Requirements
To ensure the proper functioning of the project, the following requirements must be met:

1. **Database Setup:** 
   - There must be a database named `AdventureWorksAuth`.
     ```sql
     CREATE DATABASE AdventureWorksAuth;
     ```

2. **User Table:**
   - Within the `AdventureWorksAuth` database, there must be a table named `Users`.
     ```sql
     CREATE TABLE Users (
         UserId INT PRIMARY KEY IDENTITY, 
         Name NVARCHAR(100) NOT NULL, 
         Email NVARCHAR(100) NOT NULL UNIQUE,
         Password NVARCHAR(500) NOT NULL,
         Role NVARCHAR(20) DEFAULT 'user'
     );
     ```

These requirements are necessary for the project to function as expected. Make sure to set up the database and table accordingly before running the application.
