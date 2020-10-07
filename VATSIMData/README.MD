# VATSIM Data with ENTITY FRAMEWORK CORE

This program creates a library and client to fetch and load VATSIM flight data into a [SQLite database](https://sqlite.org/index.html) using [EntityFramework Core](Install-Package Microsoft.EntityFrameworkCore -Version 3.1.8).

We'll be able to review the data directly, and even double-check with SQL queries, using the [DB Browser for SQLite](https://sqlitebrowser.org/).

We'll also develop some comfort with pushing our code to Github for [source code management](https://en.wikipedia.org/wiki/Version_control).

## Library

The lirbary reads from a text file on the Internet/WWW every two minutes and writes data to the database.  We can then query the database to answer a few basic questions.  We also collect [METAR](https://en.wikipedia.org/wiki/METAR) and PILOT information.

## Client

We will query for airports or aircraft to find flights where we can then view some basic data about those flights.