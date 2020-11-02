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

