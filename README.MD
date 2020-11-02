# CIDM 3312 Notes

ASP.NET Core 3.x Stuff

## Using Git

So, we'll want to create a local repo.

* (do this just once): `git init`
* (do this just once): `git remote add origin https://github.com/<youraccount>/<yourrepo>`

* (do this whenever there are new files): `git add -A`
* (do this on every commit - kinda like a save): `git init -m 'a descriptive message indicating what is new'`
* (do this everytime you want to save to the server): `git push -u origin master`

Here is a [quick and dirty guide](http://rogerdudler.github.io/git-guide/)

## Projects

* Party Invites (from the book)
* LINQ queries
* VATSIM Data

## ASP.NET Core Materials

I will do most of the work in the VatsimData project.

### Chapter 12

ASP.NET Core Platform Basics:

* Request Pipeline (from browser to server and web app, and back)
* Role of Middleware in the request pipeline
* Use of services in the request pipeline


![ASPNETCore Request Pipeline](https://i.imgur.com/p2M0aK3.png)

![ASPNETCORE Services and Pipeline](https://i.imgur.com/FsO9yKk.png)

#### Understanding Basic ASP.NET Core Projects

Most ASP.NET Core projects contain a few of the same types of files:

* `Program.cs` contains the entry point (`public static void main`)
    * This creates a host builder so that ASP.NET Core processes can run
    * We often use the default builder
    * We also specify which source file should be called to kick the party off
* `Startup.cs` contains the `Startup` class
* `.csproj` file contains directives about which dependencies the project has and how it associates with other resources

For illustration:

```
dotnet new globaljson --sdk-version 3.1.101 --output Platform 
dotnet new web --no-https --output Platform --framework netcoreapp3.1 
dotnet new sln -o Platform 
dotnet sln Platform add Platform

```

#### Custom Middleware to Understand the Request System

Freeman has us create some custom middleware to simply understand how Microsoft's built-in services contribute to the request/response pipeline.

* we can do one-off method based middleware
* or, reusable class-based middle ware

Generally, all middle ware takes the request object and provides additoinal material on the way back out as a response.

![Requests and Responses in the ASP.NET Core Middleware Pipline](https://i.imgur.com/572gxiU.png)

The pipeline only continues if the `next()` method is called.  If it is not, then the Request / Response cycle is ***short-cicruited***.

#### Configuring Middleware

We configure our middleware with the so-called ***options pattern***.

We can do so by defining a class:

``` cs
namespace Platform 
{ 
    public class MessageOptions 
    { 
        public string CityName { get; set; } = "New York"; 
        public string CountryName { get; set; } = "USA"; 
    } 
}
```

The first chapter in the ASP.NET Core Platform is indeed strange, but it sets an important foundation for how ASP.NET Core works with the web.

### Chapter 13 URL Routing

Routing is at the heart of a web application framework as it is a vital aspect of the Input => Processing => Output value chain of applications.

We previously discussed the Request and Response chain and middleware, routing is the means by which those "chains" are matched with incoming requests.

Freeman describes it thusly:

>URL routing consolidates the processing and matching of URLs, allowing components known as endpoints to generate responses.

Freeman populates a brief data object to illustrate how we can provided different data responses depending on route matching.

We learn that, although we can do it manually, we want to use Routing middleware to define endpoints:

*An **endpoint** is the match of a distinct route string in the URL.*

![URL Anatomy](https://i.imgur.com/ycyiHJO.png)

#### Using Route Segments to Define Variables

The general pattern for a web application is to create routes that are semantically important (have meaning) for the underlying purpose of the application.

We want the routing system to parse route segments as values to use in the application.

#### Managing URL Matching

ASP.NET provides even deeper capabilities to ensure that a given URL can be parsed into the correct route to ensure that requests are handled as you would expect.

Typically however, segment variables correct directly to a segment in the URL path.  However, middleware routing enables more complex handling, should we need it.

##### Default and Optional route segment values

We can also express default values for a route segment:

``` cs
endpoints.MapGet("capital/{country=France}", Capital.Endpoint);
```

We can also indicate that a route segment is optional:

``` cs
endpoints.MapGet("size/{city?}", Population.Endpoint);
```

Lastly, we can specify a "wildcard" or catch-all

```cs
endpoints.MapGet("{first}/{second}/{*catchall}", delegate);
```
##### Segment Matching Constraints

While default values, optional segments, and catchall segments broadened the range of URL matching, contraints constrict what can be matched.

We commonly constrain segments by data types allowed (e.g. integers, strings, and whatnot).

Here is an example:

``` cs
endpoints.MapGet("{first:int}/{second:bool}", delegate)
```

### Chapter 14 Dependency Injection

From Freeman:

>Services are objects that are shared between middleware components and endpoints. There are no restrictions on the features that services can provide, but they are usually used for tasks that are needed in multiple parts of the application, such as logging or database access. The ASP.NET Core dependency injection feature is used to create and consume services. This is a topic that causes confusion and can be difficult to understand. In this chapter, I describe the problems that dependency injection solves and explain how dependency injection is supported by the ASP.NET Core platform.

Further:

> Dependency Injection makes it easy to create loosely coupled components, which typically means that components consume functionality defined by interfaces without having any firsthand knowledge of which implementation classes are being used.

