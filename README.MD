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