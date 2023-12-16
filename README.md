# Users API
## Description
This is a example of a API REST with .NET Core and C# and MySQL 8.0

## Installation
1. Clone the repository `git clone https://github.com/roninJosue/users-api.git`
2. Navigate to project directory `cd users-api`
3. Install the necessary packages with `.NET CLI` `dotnet restore`
4. Create migrations `dotnet ef migrations add InitialCreate`
5. Update database `dotnet ef database update`
6. Run the project `dotnet run`

## Usage
Once the project is running, you can interact with the API using the following endpoints:

### Get All Users
`GET /api/users`

### Create a User
`POST /api/users`

## Dependencies
This project is developed with **ASP .NET Core** and **Entity Framework Core**. It uses the **Pomelo MySQL provider for
Entity Framework Core** as the data access layer.

You also need a local **MySQL Database Server** where the API will create and manipulate the user data. 
You can install [MySQL Server](https://dev.mysql.com/doc/mysql-installation-excerpt/8.0/en/) 
locally and [MySQL Workbench](https://www.mysql.com/products/workbench/) for a GUI to view and manage your databases.

You need to create a **users** database, the user root with password mOWzX86dYxuRj1ji, 
or any other password you configure in the MySQL installation

Please ensure all the dependencies are correctly installed and configured before running the project