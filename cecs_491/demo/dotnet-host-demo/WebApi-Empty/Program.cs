
/* 
 * Only use the Empty Web API template if you are familiar with the ASP.NET Core Framework 
 * or if you wish to explore/learn the framework from the ground up
 */
// An Empty project removes the fluff that most Visual Studio templates will add
// keeping the project as lightweight as possible


// Dotnet bootstrapping provided by the Visual Studio template below

var builder = WebApplication.CreateBuilder(args);

// Creation of the WebApplication host object
var app = builder.Build(); // Only part needed to execute Web API project

/* Everything inbetween Build() and Run() is OPTIONAL as it is meant to be customizable */

// Defines an HTTP GET endpoint
app.MapGet("/", () => "Hello World!");


// By default, Kestral will listen on port 5,000,
// but can be changed in launchSettings.json or Environmental Variables
app.Run(); // Only part needed to execute Web API project

