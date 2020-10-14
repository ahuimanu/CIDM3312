# VATSIM Data with ENTITY FRAMEWORK CORE

This program creates a library and client to fetch and load VATSIM flight data into a [SQLite database](https://sqlite.org/index.html) using [EntityFramework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/3.1.9).

We'll be able to review the data directly, and even double-check with SQL queries, using the [DB Browser for SQLite](https://sqlitebrowser.org/).

We'll also develop some comfort with pushing our code to Github for [source code management](https://en.wikipedia.org/wiki/Version_control).

## Library

The lirbary reads from a text file on the Internet/WWW every two minutes and writes data to the database.  We can then query the database to answer a few basic questions.  We also collect [METAR](https://en.wikipedia.org/wiki/METAR) and PILOT information.

## Client

We will query for airports or aircraft to find flights where we can then view some basic data about those flights.

## Entity Framework Core

Follow the steps in this tutorial carefully: [Getting Started with EF Core](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli)

In general, the concepts of [Entity Framework as an Object/Relational Mapper](https://docs.microsoft.com/en-us/ef/core/) are also mentioned in Microsoft's documentation.

* **Install EF Core from Nuget** `dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
* **Install Tooling** `dotnet tool install --global dotnet-ef`
* **Install Design Package** `dotnet add package Microsoft.EntityFrameworkCore.Design`
* **Create Migration** `dotnet ef migrations add InitialCreate`
* **Make changes to database** `dotnet ef database update`

