
## Eintech User Management Service

This project provides a web based interface to create and search users. There are five groups available to add the users to: Administrators, Moderators, Editors, Publishers, Read-Only Users.


## Project Structure

**Database** contains three tables:
 - **User** table where all user details are stored
 - **Group** table where the group details are stored
 - **UserGroups** table links users to the groups
 
 
**Eintech.Data** is a data layer that provides communication with a Microsoft SQL Server database, copy of which you can find in the database directory in the Git repository. It uses EntityFramework and LINQ queries to create and search users. 


**Eintech.Models** contains models for operations between the layers.


**Eintech.Services** is the heart of the project with two key services. 

 - **UserService** provides functionality to create and search users
 -    **UserGroupService** contains a method to associate a user to a number of groups.
 -    **Extensions** is a collection of type extensions to map data between models and entities.
 

Eintech.Website is the presentation layer built using .Net Core 2.2 with an internal API that provides endpoint to create and search users. The frontend uses JQuery and Semantic UI to speed up the test development.


## Assumptions
No authentication and security is required for the purpose of the test. Logging was not implemented. 

