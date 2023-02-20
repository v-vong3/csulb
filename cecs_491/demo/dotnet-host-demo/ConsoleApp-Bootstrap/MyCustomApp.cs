using Microsoft.Extensions.Hosting; // Needed for IHostedService interface
using Microsoft.Extensions.Options;  // Needed for Options Pattern

namespace ConsoleApp_Bootstrap
{


    public class MyCustomApp : IHostedService
    {
        private readonly MyCustomAppOptions _options;
        private readonly IHostApplicationLifetime _appLifetime;

        // .NET's DI container will always provide the IHostApplicationLifetime object for you whenever you
        // have it as a parameter in the constructor, so there is no need to manually register the object 
        public MyCustomApp(IOptions<MyCustomAppOptions> options, IHostApplicationLifetime appLifetime)
        {
            _options = options.Value;
            _appLifetime = appLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            if (_options.ArchivePath is null) // Example of using configuration values stored in Options object
            {
                // The CLR will consolidate and expose as AggregateExecption object automatically
                throw new ArgumentException($"{nameof(_options.ArchivePath)} cannot be null");
            }

            // This is the entry point to your application
            // .
            // .
            // .



            // When using .NET 6's Minimum API structure, host will linger after completion of 
            // hosted service so we need to kill the host explicitly
            _appLifetime.StopApplication();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask; // NOOP
        }
    }
}

