var builder = WebApplication.CreateBuilder(args);

// For auto registering ASP.NET Core Controllers to project
builder.Services.AddControllers();
builder.Services.AddCors( options => {
    options.AddPolicy("default",
        policy =>
        {
            policy.WithOrigins("*");
        });
});

var app = builder.Build();


app.UseCors();
// For mapping ASP.NET Core Controllers to endpoints
app.MapControllers();


app.Run();
