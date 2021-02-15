using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Company.BankApp.Web
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Lecture: Example of a very simple middleware. It is best to 
            // build middleware using the extension method pattern that Microsoft
            // as laid out for reusability of code.
            app.Use(async (context, next) =>
            {
                // Lecture: Web servers (IIS) and web frameworks (ASP.NET Core) have the 
                // tendencies to want to advertise themselves to the world.  This is nice
                // for the developers to get credit and free advertisement, but bad for you
                // since it narrows down what attacking vectors malicious users should target
                // you with.  Thus, it is a good security practice to make the guessing game
                // harder for malicious users by removing any identifying content.
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Remove("Server");
                    context.Response.Headers.Remove("X-Powered-By");

                    return Task.FromResult(0);
                });

                await next();

            });
        }
    }
}
