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
* [VATSIM Data](https://github.com/ahuimanu/CIDM3312/tree/master/VATSIMData)

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

Freeman readily acknowledges how sticky the Dependency Injection topic can be for beginners.  However, he proceeds to discuss two compelling use cases and also points out how fundamental DI is to the design of ASP.NET:

> Most projects have features that need to be used in different parts of the application, which are known as services. There are many ways to make services locatable, but there are two main approaches, aside from the one that is the main topic of this chapter. The first approach is to create an object and use it as a constructor or method argument to pass it to the part of the application where it is required. The other approach is to add a static property to the service class that provides direct access to the shared instance; this is known as the singleton pattern, and it was a common approach before the widespread use of dependency injection.

#### Singleton Just Works

The singleton pattern is great because the service "just works."  However, Freeman makes the point that, as services proliferate, keeping track of them throughout your code will become more cumbersome.

Freeman elaborates:

> Although I defined an interface in Listing 14-1, the way that I have used the singleton pattern means that consumers are always aware of the implementation class they are using because that’s the class whose static property is used to get the shared object. If I want to switch to a different implementation of the `IResponseFormatter` interface, I must locate every use of the service and replace the existing implementation class with the new one.

#### DI Just Works Better

DI removes most management decisions from the point where a service is used.

Freeman puts it this way:

> Dependency injection provides an alternative approach to providing services that tidy up the rough edges that arise in the singleton and type broker pattern, and it is integrated with other ASP.NET Core features. 

With dependency injection, we remove decision-making from the point where a service is used to an "upstream" point of configuration.  Thus, it isn't "magic," but it is a way to keep code cleaner.

>Because the object that resolves the dependency is provided from outside the class or function that uses it, it is said to have been injected, which is why the process is known as dependency injection.

Because ASPNET Core provides a place to configure services in `startup.cs` then we now have access to that service throughout the application.

Freeman:

> Defining a service in the ConfigureServices method and consuming it in the Configure method may not seem impressive, but once a service is defined, it can be used almost anywhere in an ASP.NET Core application.

#### Service Lifecycles.

So, in our Startup class, we specify that we will configure services for our ASP.NET application. Like so:

``` cs
public void ConfigureServices(IServiceCollection services) { 
    services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>(); 
}
```

In this example we add one class to handle a number of services - specified in the list between the angle braces.  There are other options here as well:

* ***AddSingleton*** - `AddSingleton<T, U>()` This method creates a single object of type U that is used to resolve all dependencies on type T. 
* ***AddTransient*** - `AddTransient<T, U>()` This method creates a new object of type U to resolve each dependency on type T. 
* ***Add scoped*** - `AddScoped<T, U>()` This method creates a new object of type U that is used to resolve dependencies on T within a single scope, such as request.

##### Transient

To resolve a new transient each time the depedency is called upon, we'll need to return to using `Invoke()`.  In general, this changes the DI structuring to ensure that a new service object is created per call.

##### Scoped

Freeman:

>Scoped services strike a balance between singleton and transient services. Within a scope, dependencies are resolved with the same object. A new scope is started for each HTTP request, which means that a service object will be shared by all the components that handle that request.

### Chapter 15 and 16 - Built-in Platform Features

These two chapters provide a tour of the built-in services that utilize the concepts from chapters 12 - 14 as a part of the design of the ASP.NET Core foundation.

Here is a list of some of those features:

Chapter 15:
* `IConfiguration` Service - Accessing configuration data for the application
* Using launch settings
* `IWebHostEnvironment` Service - Inquiring about the application execution environment
* User secrets - a pretty nifty way to store API keys, passwords, and database access information
* `ILogger<T>` Service - All programs that run persistently ultimately need logging.
* Static content middleware - Since your web application will serve static files such as images, javascript, and css, this built-in middleware handles it.
* client-side packages - typically web css and js frameworks.

Chapter 16:
* Cookie handling - the web is a stateless set of protocols, so cookies help the useragent (browser) to remember between page visits
* Managing cookies - the consent middleware allows for consent to issue and maintain cookies
* Session variable handling - a variation on cookies that is commonly controlled server-side
* HTTPS - Uses SSL/TLS to ensure that web traffic is encrypted - fairly standard now
* Error handling - middleware to handle applicaiton errors and communicating that to useragents
* Restricting access - use the AllowedHosts configuration

### Chapter 17 - Working with Data

Coming full circle, this chapter begins a basic understanding of various data aspects including Entity Framework Core.

In detail, the following key aspects are covered:

* Caching - ensure that we don't have to reprocess/recalcuate the same content repeatedly
* Persistent Caching - use a database to store the cached content
* Applicaiton Peristence with Entity Framework Core
* Creating database schema - establishing model classes
* Accessing data through EFCore's `DbContext`
* Request logging

This chapter contains much of what is present in the VATSIMData project on the library side.