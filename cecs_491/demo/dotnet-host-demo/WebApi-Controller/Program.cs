
/*
 * Recommend choosing Web API with Controllers Visual Studio template for new users
 * of the ASP.NET Core Framework for the following reasons:
 * 
 * 1. Controllers provide a good separation of concerns between Kestral configurations and application code
 * 2. Easier to identify and requiring dependencies through constructor injection with Controllers
 */

using Microsoft.Net.Http.Headers;
using LibAccount;

var builder = WebApplication.CreateBuilder(args);

/* Registration of objects for .NET's DI Container */

builder.Services.AddControllers(); // Controllers are executed as a service within Kestral

builder.Services.AddTransient<AuthDAO>(); // Registering the dependencies for Controller example
builder.Services.AddTransient<AuthChecker>(); // Registering the dependencies for Controller example

// Creation of the WebApplication host object
var app = builder.Build(); // Only part needed to execute Web API project

/* Setup of Middleware Pipeline */
// NOTE: The order for the middleware matters
// The middleware pipeline is how the HTTP request will flow through Kestral to your application code


app.UseHttpsRedirection();

// Defining a custom middleware AND adding it to Kestral's request pipeline
// Custom middleware to improve security by stopping web server from advertising itself 
app.Use(async (httpContext, next) =>
{

    // No inbound code to be executed
    //
    //

    // Go to next middleware
    await next(httpContext);

    // Explicitly only wanting code to execite on the way out of pipeline (Response/outbound direction)
    if (httpContext.Response.Headers.ContainsKey(HeaderNames.XPoweredBy))
    {
        httpContext.Response.Headers.Remove(HeaderNames.XPoweredBy);
    }

    httpContext.Response.Headers.Server = "";
});


// Defining a custom middleware AND adding it to Kestral's request pipeline
app.Use((httpContext, next) =>
{
    // Example of explicitly targeting preflight requests
    // NOT production ready implementation as X-Requested-With can 
    if (httpContext.Request.Method.ToUpper() == nameof(HttpMethod.Options).ToUpper() &&
        httpContext.Request.Headers.XRequestedWith == "XMLHttpRequest")
    {
        var allowedMethods = new List<string>()
        {
            HttpMethods.Get,
            HttpMethods.Post,
            HttpMethods.Options,
            HttpMethods.Head
        };

        httpContext.Response.Headers.Append(HeaderNames.AccessControlAllowOrigin, "*");
        httpContext.Response.Headers.AccessControlAllowMethods = string.Join(",", allowedMethods); // "GET, POST, OPTIONS, HEAD"
        httpContext.Response.Headers.AccessControlAllowHeaders = "*";
        httpContext.Response.Headers.AccessControlMaxAge = TimeSpan.FromHours(2).Seconds.ToString();
    }

    // If you need code to execute both downstream and upstream the middleware pipeline
    // next.Invoke(httpContext);

    return next(httpContext);
});

/*
 * If using ASP.NET's built-in Authentication and Authorization
 * make sure to run Authentication before Authorization
 */
//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers(); // Needed for mapping the routes defined in Controllers


/* IApplicationBuilder.Run() middleware version is only useful for directly manipulating response */
//app.Run(httpContext =>
//{
//    var validVersionPath = new PathString("/v1");

//    if (!httpContext.Request.Path.StartsWithSegments(validVersionPath))
//    {
//        httpContext.Response.Redirect($"v1/{httpContext.Request.Path}");
//    }

//    return Task.CompletedTask; // Terminates the middleware pipeline
//});


// By default, Kestral will listen on port 5,000,
// but can be changed in launchSettings.json or Environmental Variables
app.Run(); // Only part needed to execute Web API project