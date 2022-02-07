# ASPdotNet-Core-Web-API
C# application constructed in ASP.NET Core and comprised of a database made in SQL Server through EF Core with a RESTful API to allow users to manipulate the data. The database stores information about characters, movies they appear in, and the franchises these movies belong to. 

## Detailed Description

### Apendix A: Entity Framework Core Code First
The following sub-sections described how the above-mentioned entities interact and what rules they are 
governed by
#### Business Rules:
  *  One **movie** contains many **characters**, and a **character** can play in multiple **movies**
  *  One **movie** belongs to one **franchise**, but a **franchise** can contain many **movies**.


#### Data Requirments:
  * Character
    *  Autoincremented Id
    *  Full name
    *  Alias (if applicable)
    *  Gender
    *  Picture (URL to photo) 
  * Movie
    *  Autoincremented Id
    *  Movie title
    *  Genre (simple string of comma separated genres)
    *  Gender
    *  Director (string name)
    *  Picture (URL to movie poster) 
    *  Trailer (YouTube link)
  * Franchsie  
    * Autoincremented Id
    * Name
    * Description
#### Seeding
Create some dummy data using seeded data.

### Apendix B: Web API using ASP.NET Core
This section and subsections detail the requirements of the endpoints of the system on a high level.

#### API Requirments


## Getting Started

### Tools installed 

* Visual Studio 2019 with .NET 5.
* Unit testing project added to project solution

## Author and Developer

Jasotharan Cyril 
