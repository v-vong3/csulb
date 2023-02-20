
using WebApi_MinApi;
using Microsoft.AspNetCore.Cors; // Needed for using .NET's builtin CORS objects

var builder = WebApplication.CreateBuilder(args);

/* Registration of objects for .NET's DI Container */

// Adding .NET's built-in CORS package
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCustomCors",
                              policyBuilder =>
                              {
                                  policyBuilder.WithOrigins("http://localhost:3000");
                              });
});

// Creation of the WebApplication host object
var app = builder.Build(); // Only part needed to execute Web API project

/* Setup of Middleware Pipeline */
// NOTE: The order for the middleware matters
// The middleware pipeline is how the HTTP request will flow through Kestral to your application code

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Required for enabling CORS
app.UseCors("MyCustomCors");

// Defining the HTTP Verb and URL route for endpoint
app.MapGet("/data", () =>
{
    // This lambda expression acts as the handler for the endpoint
    // which can become verbose if everything is implemented in this one file
    var vehicleData = new List<Vehicle>()
    {
        new Vehicle("Ford", "F-150E", 2020),
        new Vehicle("Tesla", "Model X", 2020),
        new Vehicle("Toyota", "Prius", 2023),
    };

    return vehicleData;
});


// By default, Kestral will listen on port 5,000,
// but can be changed in launchSettings.json or Environmental Variables
app.Run(); // Only part needed to execute Web API project
