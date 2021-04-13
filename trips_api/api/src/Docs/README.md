
1. Make sure you do execute a restore command.
1. Update your instrumentation key and connection string in the appsettings.json

Make sure you have installed:

## Init EF Core
```
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.Extensions.Logging.Debug
```

## Recreate DB - In case you update your model
```
dotnet ef database drop
rm -r Migrations  
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Scaffold a Model
If in the future you need to scaffold a new model
```
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install -g dotnet-aspnet-codegenerator
```

## Example
```
dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers

dotnet aspnet-codegenerator controller -name ServiceTypesController -async -api -m ServiceType -dc TripContext -outDir Controllers

dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers
```


## Install packages
`dotnet add package <PACKAGE_NAME>`



# API Requests Examples
Use [rest-client vscode extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) vscode extension. Please find test files [here](trips_api/api/src/Docs) and some examples on how to permute the query filters [here](trips_api/api/src/.vscode/settings.json)  

The file [trips_api/api/src/Docs/TripsTests.http](trips_api/api/src/Docs/TripsTests.http) contains the full list of query actions available in the API.


