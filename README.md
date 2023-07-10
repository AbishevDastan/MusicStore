# MusicStore
An e-commerce application.

## Description

This application is a part of the diploma thesis that I'm working on. It is an e-commerce web project, the functionality of which includes role-based Authorization and Authintication of the user, Admin Panel with CRUD operations available for products and categories, an option to add products to the shopping cart and place orders. 

## Technology Stack
* Frameworks: ASP.NET Core Web API | Blazor WebAssembly | Entity Framework (EF) Core
* Programming Languages: C# | HTML/CSS
* Database: Microsoft SQL Server
* Libraries: MudBlazor

## Getting Started

### Dependencies
NuGet Packages:
* Microsoft.AspNetCore.Authentication.JwtBearer
* Microsoft.AspNetCore.Components.Authorization
* Microsoft.AspNetCore.Components.WebAssembly
* Microsoft.AspNetCore.Components.WebAssembly.DevServer
* Microsoft.AspNetCore.Http.Abstractions
* Microsoft.AspNetCore.WebUtilities
* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.EntityFrameworkCore.SqlServer
* MudBlazor
* Blazored.LocalStorage
* Newtonsoft.Json
* Swashbuckle.AspNetCore
* AutoMapper.Extensions.Microsoft.DependencyInjection

### Installing

* Place the folder with the project anywhere on the PC

### Executing program

* Adding an Entity Framework (EF) Core migration 
```
dotnet ef migrations add [NAME HERE] --project Diploma.DataAccess --startup-project Diploma.Api
```
* Creating the local database and seeding the data
```
dotnet ef database update --project Diploma.DataAccess --startup-project Diploma.Api
```
* Set Diploma.Api and Diploma.Client as startup projects via right-clicking the solution in Solution Explorer and going to Properties. 
```
* Run the application 
