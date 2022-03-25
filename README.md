## Installation
Clone from GitHub
```git bash
git clone https://github.com/ismailak06/CafeMenuProject
```
## Database Migration
*Make sure [connection string](https://github.com/ismailak06/CafeMenuProject/blob/master/DataAccess/Concrete/EntityFramework/Contexts/CMPDbContext.cs#L34) is correct*
<br><br>
Firstly, install dotnet tool if it does not have
```git bash
dotnet tool install --global dotnet-ef
```
To create migration run in PMC:
```git bash
dotnet ef migrations add InitialMigration --project DataAccess
```
to build database run in PMC:
```git bash
dotnet ef database update --project DataAccess
```
When you build the database you can start the project and you can login with default user:
<br><br>
Username: <b>thos</b> <br>
Password: <b>123456</b>
<br> <br>

You should enable multiple startup and select AdminPanel, CustomerPanel projects

## Technologies
- .Net 5.0
- MSSQL
- EntityFrameworkCore
- FluentValidation
- AutoMapper

