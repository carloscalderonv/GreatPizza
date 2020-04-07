# Welcome to Great Pizza project!

This is the project **GreatPizza**. the project allows to create pizzas, create toppings and add/remove toppings from pizzas.

# Database

The project uses **SQL Server** as Database, connected throught **Entity Framework**, if you want to change the connection you need to check appsettings.json on dotnet core Backend. if the user wants to create the database needs to run 2 commands **update-database** command on package manager console.

# Backend

For backend the project uses **dot net core** v 3.1, it is a WebAPI, the user needs to open the solution **GreatPizza.sln** then all NuGet packages needs to be restored, the project has 2 controllers (Pizza and topping),  all methods are documented with Swagger on [https://localhost:5001/swagger/index.html](https://localhost:5001/swagger/index.html).

# Frontend

Frontend was created on **Angular 9**, it has a structure for Pages, Components, services, and models, the user needs to run **npm install** on **GreatPizzaWebApp** folder, a proxy file was created for API integration, proxy.config.json, and package.json was updated in order to use that file, the project needs to be started with **npm start**, this will start the server on [http://localhost:4200/](http://localhost:4200/).

## External Packages

On Frontend were used the packages: Swashbuckle.AspNetCore for documentation on swagger.
On Backend were used the packages: sweetalert2 for messages, ngx-pagination for grids pagination, bootstrap for styles. 

## Suggestions

There is a couple of actions that i suggest to do:

 - Complete documentation for Swagger.
 - Security objects needs to be implemented on Frontend and Backend.
 - A Loging page needs to be created and token needs to be implemented, i suggest JWT.
 - Response objects could be create on contracts folder on Backend, this will improve the compatibility and let the developer know the information
