using Company.BankApp.DataAccess;
using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.Managers;
using Company.BankApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Company.APIs.Users
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient(typeof(IBankDAO), typeof(InMemoryBankDAO));
            services.AddTransient<BankAccountService>();
            services.AddTransient<BankAccountManager>();
            services.AddTransient<BankAppUserManager>();



            //services.AddHsts(options =>
            //{
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(180);
            //});


            services.AddCors(opts =>
            {
                // Lecture: Get the configuration from an external source to make
                // development and deployment easier to manage.
                var env = "DEV";//Configuration.GetSection("Environment");

                if (env == "DEV")
                {
                    // Lecture: Only use these CORS setting for development. Never deploy to 
                    // production with these settings.
                    opts.AddPolicy(name: "CorsPolicy", builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
                }
                else
                {

                    // Lecture: Make sure to specify the exact origins that you want to allow
                    // cross origin communication with your code.
                    opts.AddPolicy(name: "CorsPolicy", builder =>
                    {
                        builder.WithMethods("GET", "POST", "OPTIONS")
                               .WithOrigins("http://localhost:8080") // Change this
                               .AllowAnyHeader();
                    });
                }
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Company.APIs.Users", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Company.APIs.Users v1"));
            }
            else
            {
                // Only in prod
                //app.UseHsts();
            }



            app.UseRouting();

            //#region Security Headers
            //// Adds security headers to all responses
            //// Must be added before UseEndpoints and UseMvc
            //app.Use(async (context, next) =>
            //{
            //    if (!context.Response.Headers.ContainsKey("Content-Security-Policy"))
            //    {
            //        context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
            //    }

            //    if (!context.Response.Headers.ContainsKey("X-Frame-Options"))
            //    {
            //        context.Response.Headers.Add("X-Frame-Options", "DENY");
            //    }

            //    if (!context.Response.Headers.ContainsKey("X-Xss-Protection"))
            //    {
            //        context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
            //    }

            //    if (!context.Response.Headers.ContainsKey("X-Content-Type-Options"))
            //    {
            //        context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            //    }

            //    if (!context.Response.Headers.ContainsKey("Referrer-Policy"))
            //    {
            //        context.Response.Headers.Add("Referrer-Policy", "no-referrer");
            //    }

            //    if (!context.Response.Headers.ContainsKey("X-Permitted-Cross-Domain-Policies"))
            //    {
            //        context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
            //    }


            //    await next();
            //});
            //#endregion

            app.UseCors(policyName: "CorsPolicy");

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "index.html");

                // Lecture: When building any web application, URL routing needs to account
                // for users going to invalid URLs within your application. It is best
                // practice to have a fallback route that the user will be redirected to if
                // they go to an invalid URL.
                endpoints.MapGet("/{*url}", async context =>
                {
                    if (!context.Response.HasStarted)
                    {
                        context.Response.ContentType = "text/html";
                        context.Response.StatusCode = 200;
                    }

                    var file = new FileInfo(path);

                    await context.Response.SendFileAsync(new PhysicalFileInfo(file));
                    await context.Response.CompleteAsync();
                });

                endpoints.MapControllers();
            });

        }
    }
}
