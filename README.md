# ASPdotNet-Core-Web-API
C# application constructed in ASP.NET Core and comprised of a database made in SQL Server through EF Core with a RESTful API to allow users to manipulate the data. The database stores information about characters, movies they appear in, and the franchises these movies belong to. 

## Detailed Description

### Apendix A: Entity Framework Core Code First
The following sub-sections described how the above-mentioned entities interact and what rules they are 
governed by
#### Business Rules:
  *  One **movie** contains many **characters**, and a **character** can play in multiple **movies**
  *  One **movie** belongs to one **franchise**, but a **franchise** can contain many **movies**.

#### Relationship Diagram:

![GitHub Logo](https://github.com/s325909/ASPdotNet-Core-Web-API/blob/main/MovieFranchiseWebAPI/Diagram_Movie_Franchise.png)

#### Seeding:
Creating some dummy data using seeded data.

### Apendix B: Web API using ASP.NET Core
This section and subsections detail the requirements of the endpoints of the system on a high level.

#### API Requirments:

##### _Generic CRUD_
Full CRUD is done for **Movies**, **Characters**, and **Franchises**. 
Proper deletes are done by ensuring related data is not deleted by setting the foreign keys to null. 
This means that Movies can have no Characters, and Franchises can have no Movies

##### _Updating Related Data_
In addition to generic “update entity” methods are implemnted, with dedicated endpoints to:
 * Updating **Characters** in a **Movie**
    * This is done by taking in an integer array of character Ids in the body, and a Movie Id in the path
 * Updating **Movies** in a **Franchise**
    * This is don by taking in an integer array of movie Id’s in the body, and a Franchise Id in the path 

##### _Reporting_
At a high level, the application is able to provide the following reports in addition to the basic reads for each 
entity:
 * Get all the **movies** in a **franchise**.
 * Get all the **characters** in a **movie**.
 * Get all the **characters** in a **franchise**.

#### _DTOs with AutoMapper_
Made Data Transfer Objects (DTOs) for all the model classes clients will interact with. 
**_CharacterDTO_**, **_MovieDTO_**, and **_FranchiseDTO_** were made as to handle the creates, updates and reads / reporting ones.
AutomMapper is further used to create mappings between the domain models (entities) and these DTOs.

#### _Documentation with Swagger_
Created proper documentation using Swagger / Open API. 
This implementation required extra attributes to be added to controller methods.

#### _Services or Repositories_
The use of Services helps clean up controllers when there is a lot of DbContext manipulation that needs to be done. 
The Services made are injected (configured in startup.cs under ConfigureServices(…)).

## Getting Started

### Tools installed 

* Visual Studio 2019 with .NET 5.
  * AutoMapper.Extensions.Microsoft.Dependenices (11.0.0)
  * Microsoft.Enity.FrameworkCore (5.0.13)
  * Microsoft.Enity.FrameworkCore.Design (5.0.13)
  * Microsoft.Enity.FrameworkCore.SqlServer (5.0.13)
  * Microsoft.Enity.FrameworkCore.Tools (5.0.13)
* SQL Server Management Studio
  
## Author and Developer

Jasotharan Cyril 
