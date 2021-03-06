
## Eintech User Management Service

This project provides a web based interface to create and search users. There are five groups available to add the users to: Administrators, Moderators, Editors, Publishers, Read-Only Users.

## Project Structure

**Database** contains three tables:
 - **User** table where all user details are stored. Last name could be empty as not required in some countries.
 - **Group** table where the group details are stored. It contains a Unique Constraint and non-clustered index on the name name column.
 - **UserGroups** table links users to the groups. It also contains a unique Constraint and a non-clustered index on UserId and GroupId.
 
 
**Eintech.Data** is a data layer that provides communication with a Microsoft SQL Server database, copy of which you can find in the database directory in the Git repository. It uses EntityFramework and LINQ queries to create and search users. 

**Eintech.Models** contains models for operations between the layers.

**Eintech.Services** is the heart of the project with two key services. 

 - **UserService** provides functionality to create and search users
 -    **UserGroupService** contains a method to associate a user to a number of groups.
 -    **Extensions** is a collection of type extensions to map data between models and entities.

**Eintech.Website** is the presentation layer built using .Net Core 2.2 with an internal API that provides endpoint to create and search users. The frontend uses JQuery and Semantic UI to speed up the test development. 

## Unit Tests

I've created tests for the all methods, services and classes with exception to the data layer, to save time. You will find examples of usage of Moq and FluentAssertions. The website project contains tests for Extensions and Web API. I did not write the UI Javascript tests to save time. But of course in the real application Jasmine can be used to test the frontend code.

## Assumptions
No authentication and security is required for the purpose of the test. Logging was not implemented as it was assumed as out of scope.

## Deployment Steps

 1. Restore the database backup file to a Microsoft SQL Server instance.
 2. Create an SQL server login and asssign relevant permissions to access the database.
 3. Update ConnectionString parameter in the appsettings.json file in the website project.
 4. Open the solution in Visual Studio 2015 or higher and launch in debug mode.
