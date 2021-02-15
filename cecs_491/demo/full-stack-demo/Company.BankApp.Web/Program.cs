using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Company.BankApp.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                              // Lecture: Same as the security note in Startup.cs
                              // We are limiting Kestral from advertising that the 
                              // web server is Kestral.
                              .UseKestrel(options => options.AddServerHeader = false);
                });
    }
}
