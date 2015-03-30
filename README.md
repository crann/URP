## Read Me

This repo is a reminder for me on how to implement the Unit of Work and Repository patterns with Entity Framework. It contains two examples:

##### Example One
A console application located in the [examples/URP_Console_App] folder. 

This application inserts country data into a database, selects, updates and finally deletes the country data. This demonstrates the basic CRUD operations using the repository pattern.

Technologies used:
- Microsoft .Net 4.5
- Entity Framework 6.1.1
- Unity 3.5

##### Example Two
A web application located in the [examples/URP_Mvc_App] folder.

This application allows the user to insert, update and delete movie data into a database through a web based GUI. It also demonstrates how to seed a database on the application's first run.
(There's no paging, validation or funky functionality as this is intended to be a basic demonstration of the unit of work and repository pattern in a web application).

Technologies used:
- Microsoft .Net 4.5
- Entity Framework 6.1.1
- Unity 3.5
- ASP.Net MVC 5
- AngularJS 1.3.0
 

##### Configuring the examples
Both examples require privileges to create and drop a database on an Microsoft SQL Database Server.
- Update the [app.config] file in the [URP.Console] project of example one to point to this database server.
- Update the [web.config] file in the [URP.Web] project of example two to point to this database server.

##### Future Enhancements:
Convert the URP.DataAccess project into a Visual Studio template. The template will create the basic scaffolding for these patterns when using Entity Framework in future solutions.
 

##### Credit
I originally grabbed the implementations for the patterns from the articles below, so a huge thanks to the coder that wrote them:

http://weblogs.asp.net/shijuvarghese/archive/2011/01/06/developing-web-apps-using-asp-net-mvc-3-razor-and-ef-code-first-part-1.aspx

http://weblogs.asp.net/shijuvarghese/archive/2011/01/06/developing-web-apps-using-asp-net-mvc-3-razor-and-ef-code-first-part-2.aspx
